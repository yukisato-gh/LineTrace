//#define HARDWARE

#include <stdio.h>
#include <math.h>
#include <stdint.h>

#if defined(HARDWARE)
#include "pico/stdlib.h"
#include "hardware/pwm.h"
#else
#include "LineTraceAlgorithm.h"
#endif

/* GPIO番号対応付け */
#define AIN1 21   // OUTA1, phase(正転/逆転)
#define AIN2 20   // OUTA2, enable(PWM制御)
#define BIN1 19   // OUTB1, phase(正転/逆転)
#define BIN2 18   // OUTB2, enable(PWM制御)
const uint sens[8] = {9, 8, 7, 6, 5, 4, 3, 2}; // センサIN1-IN8

/* モータ出力設定 */
// PWMの最大値
// 16bit=65535
#define PWM_MAX      65535U
// PWMの最小値
#define PWM_MIN      0U
// 直進時の基準出力をパーセントで設定
#define BASE_SPEED_PCT   40.0f     // [%]
// 補正量の上限をパーセントで設定
#define MAX_U_PCT        BASE_SPEED_PCT
// カーブ係数%(大きいほど減速する)
#define CURVE_COEF       0.6f

/* PIDパラメータ */
// 比例ゲイン
#define KP  20.0f
// 積分ゲイン
#define KI   0.5f
// 微分ゲイン
#define KD   5.0f
// PID用変数
float integral = 0.0f;
float prev_error = 0.0f;
// 制御周期(ms)
const float dt = 0.01f; // 10ms

/* センサ関連 */
// センサ数
#define SENSORS   8
// センサ位置(左マイナス、右プラス)
const float sensor_pos[SENSORS] = {-4, -3, -2, -1, 1, 2, 3, 4};

/* 関数プロトタイプ宣言 */
uint init_pwm(uint gpio); // PWM出力設定
float calcLinePosition(void); // センサから位置を計算する
void lineTraceControl(float dt); // 誤差修正
void setMotorPWM(uint16_t left, uint16_t right); // モータPWM出力
void debug_senser(); // センサデバッグ用
void debug_motor(uint16_t left, uint16_t right); // モータデバッグ用

#if defined(HARDWARE)
int main() {
    stdio_init_all();
    setup_default_uart();

    const uint motorA1 = AIN1; // Right
    const uint motorA2 = AIN2; // Right
    const uint motorB1 = BIN1; // Left
    const uint motorB2 = BIN2; // Left

    // INPUT SET (Sensers)
    for (int i = 0; i < 8; i++) {
        gpio_init(sens[i]);
        gpio_set_dir(sens[i], GPIO_IN); // Set as input (change to GPIO_OUT if needed)
    }

    // OUTPUT SET (Motors)
    gpio_init(motorA1);
    gpio_set_dir(motorA1, GPIO_OUT);
    gpio_init(motorA2);
    gpio_set_dir(motorA2, GPIO_OUT);
    gpio_init(motorB1);
    gpio_set_dir(motorB1, GPIO_OUT);
    gpio_init(motorB2);
    gpio_set_dir(motorB2, GPIO_OUT);

    // PWM SET (Motors)
    uint slice1 = init_pwm(motorA1);
    uint slice2 = init_pwm(motorA2);
    uint slice3 = init_pwm(motorB1);
    uint slice4 = init_pwm(motorB2);

    //メインループ
    while (true) {
        lineTraceControl(dt);
        sleep_ms(10);
    }
}

// PWM出力設定
uint init_pwm(uint gpio) {
    gpio_set_function(gpio, GPIO_FUNC_PWM);
    uint slice = pwm_gpio_to_slice_num(gpio);
    pwm_set_wrap(slice, PWM_MAX);          // デューティ比を0-100で扱う
    pwm_set_clkdiv(slice, 1.0f);       // PWMクロック分周
    pwm_set_enabled(slice, true);
    return slice;
}
#endif

//センサから位置を計算する
float calcLinePosition(void)
{
    float sum_value = 0.0f;
    float sum_weight = 0.0f;

    for (int i = 0; i < SENSORS; i++) {
        float v = (float)gpio_get(sens[i]);     // 各センサ値
        sum_value  += v * sensor_pos[i]; // 位置×値
        sum_weight += v;                 // 値の合計
    }

    if (sum_weight == 0.0f) {
        // ラインを見失った場合は0を返す（中央と仮定）
        return 0.0f;
    }

    return sum_value / sum_weight; // 重心位置
}

// 誤差修正
void lineTraceControl(float dt)
{
    // 誤差計算
    float pos = calcLinePosition();     // ライン位置
    float error = pos;                  // 目標は中央=0

    // PID計算
    integral += error * dt;
    float derivative = (error - prev_error) / dt;
    prev_error = error;

    float u_pct = KP * error + KI * integral + KD * derivative; // 補正量[%]

    // 補正量を制限（±MAX_U_PCT）
    if (u_pct >  MAX_U_PCT) u_pct =  MAX_U_PCT;
    if (u_pct < -MAX_U_PCT) u_pct = -MAX_U_PCT;

    // カーブ減速用ベース速度
    // 誤差に比例してベースを下げる（0以下にならないよう制限）
    const float k_curve = CURVE_COEF;       // 調整パラメータ
    float base_pct = BASE_SPEED_PCT - k_curve * fabsf(error);

    //if (base_pct < 20.0f) base_pct = 20.0f;  // 最低速度を確保

    // 左右のPWMをパーセントで計算
    float left_pct  = base_pct - u_pct;
    float right_pct = base_pct + u_pct;

    // 0-100%にクリップ
    if (left_pct  < 0.0f)  left_pct  = 0.0f;
    if (left_pct  > 100.0f) left_pct = 100.0f;
    if (right_pct < 0.0f)  right_pct = 0.0f;
    if (right_pct > 100.0f) right_pct = 100.0f;

    // PWM_MAXスケーリング＆整数化
    uint16_t left_pwm  = (uint16_t)(left_pct  / 100.0f * PWM_MAX);
    uint16_t right_pwm = (uint16_t)(right_pct / 100.0f * PWM_MAX);

    //モータへ出力
    setMotorPWM(left_pwm, right_pwm);

    //デバッグ出力用
    debug_senser();
    debug_motor(left_pwm, right_pwm);
}

#if defined(HARDWARE)
// モータPWM出力
void setMotorPWM(uint16_t left, uint16_t right)
{
    pwm_set_gpio_level(AIN1, PWM_MIN);
    pwm_set_gpio_level(AIN2, right);
    pwm_set_gpio_level(BIN1, PWM_MAX);
    pwm_set_gpio_level(BIN2, left);
}
#endif

// センサデバッグ用
void debug_senser()
{
    for (int i = 0; i < SENSORS; i++) {
        printf("#%d=%d, ", i, gpio_get(sens[i]));     // 各センサ入力値
    }
}

// モータデバッグ用
void debug_motor(uint16_t left, uint16_t right)
{
    printf("; #L=%d, #R=%d\n", left, right);    // モータPWM出力値
}