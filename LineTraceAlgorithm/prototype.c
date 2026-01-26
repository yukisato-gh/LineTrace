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
#define MOTOR_A1 21U   // Left, OUTA1, phase(正転/逆転)
#define MOTOR_A2 20U   // Left, OUTA2, enable(PWM制御)
#define MOTOR_B1 19U   // Right, OUTB1, phase(正転/逆転)
#define MOTOR_B2 18U   // Right, OUTB2, enable(PWM制御)

const uint sens[8] = {9U, 8U, 7U, 6U, 5U, 4U, 3U, 2U}; // センサIN1-IN8(左から順)

/* モータ出力設定 */
//左出力オフセットパーセント[%]
#define LEFT_OFFSET     0.0f
//右出力オフセットパーセント[%]
#define RIGHT_OFFSET    0.0f
// PWMの最大値 16bit=65535→13bit=8192
#define PWM_MAX         8192U
// PWMの最小値
#define PWM_MIN         0U
// 直進時の基準出力をパーセント[%]で設定
#define BASE_SPEED_PCT  50.0f
// 最小の出力をパーセント[%]で設定
#define MIN_SPEED_PCT   10.0f
// 補正量の上限をパーセントで設定
#define MAX_U_PCT       40.0f
// カーブ係数%(大きいほど減速する)
#define CURVE_COEF      0.6f

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
const float dt = 0.005f; // 10ms→5ms
const uint64_t interval_us = 5000; // 10ms→5ms周期(単位はマイクロ秒)

/* センサ関連 */
// センサ数
#define SENSORS   8
// センサ位置(左マイナス、右プラス)
const float sensor_pos[SENSORS] = {0, -5, -2, 0, 0, 2, 5, 0};

/* 走行モード */
typedef enum {
    MODE_IDLE,
    MODE_START,
    MODE_LINE_TRACE,
    MODE_CORNER,
    MODE_CORNERING,
    MODE_GOAL
} RunMode;
RunMode mode = MODE_LINE_TRACE;

/* マーカー判定関連 */
const int th_repeat = 5; // 連続検出閾値(threshold) 3回→5回

/* 関数プロトタイプ宣言 */
void init_pwm(uint);                    // PWM出力設定
float calcLinePosition(void);           // センサから位置を計算する
void lineTraceControl(float);           // ライントレース制御
void doLineTrace(float);                // PID制御にてライントレース(誤差に応じた出力調整)
void rotateForce(int);                  // 強制転回(コーナーマーカー検出時)
void straightForce(int);                // 強制直進(交差点検出時)
void setMotor(uint16_t, uint16_t);      // モータ出力
void checkMarker(void);                 // マーカー検出とモード切替
void debug_senser(void);                // センサデバッグ用
void debug_motor(uint16_t, uint16_t);   // モータデバッグ用

/* スタートフラグ */
static int flag_start = 0;

#if defined(HARDWARE)
int main() {
    stdio_init_all();
    setup_default_uart();

    // INPUT SET (Sensers)
    for (int i = 0; i < SENSORS; i++) {
        gpio_init(sens[i]);
        gpio_set_dir(sens[i], GPIO_IN); // Set as input (change to GPIO_OUT if needed)
    }

    // OUTPUTセット (モーター)
    gpio_init(MOTOR_A1);
    gpio_set_dir(MOTOR_A1, GPIO_OUT);
    gpio_init(MOTOR_A2);
    gpio_set_dir(MOTOR_A2, GPIO_OUT);
    gpio_init(MOTOR_B1);
    gpio_set_dir(MOTOR_B1, GPIO_OUT);
    gpio_init(MOTOR_B2);
    gpio_set_dir(MOTOR_B2, GPIO_OUT);

    // PWMセット (モーター)
    init_pwm(MOTOR_A2);
    init_pwm(MOTOR_B2);

    // ハードウェアタイマーによる現在時間取得
    absolute_time_t next_time = get_absolute_time();

    //メインループ(実行時間遅延に応じた遅延を考慮)
    while (true) {
        lineTraceControl(dt);
        next_time = delayed_by_us(next_time, interval_us);
        sleep_until(next_time);
    }
    //旧メインループ
    // while (true) {
    //     lineTraceControl(dt);
    //     sleep_ms(10);
    // }
}

// PWM出力設定（初期化）
void init_pwm(uint gpio) {
    gpio_set_function(gpio, GPIO_FUNC_PWM); // GPIOをPWM機能に切り替え
    uint slice = pwm_gpio_to_slice_num(gpio); // GPIOが属するslice番号を取得
    pwm_set_wrap(slice, PWM_MAX); // デューティ比をPWM_MAXで扱う(分解能)
    pwm_set_clkdiv(slice, 0.5f);  // PWMクロック分周(分周比)
    pwm_set_enabled(slice, true);
}
#endif

//センサから位置を計算する
float calcLinePosition(void)
{
    float sum_value = 0.0f;
    float sum_weight = 0.0f;

    for (int i = 1; i < (SENSORS - 1); i++) {   // 一番両端のセンサー(マーカ検出用)を除く
        float v = gpio_get(sens[i]);            // 各センサ値
        sum_value  += v * sensor_pos[i];        // 位置×値
        sum_weight += v;                        // 値の合計
    }

    if (sum_weight == 0.0f) {
        // ラインを見失った場合は0を返す（中央と仮定）
        return 0.0f;
    }

    // デバッグ用
    debug_senser();

    return sum_value / sum_weight;  // 重心位置
}

// ライントレース制御
void lineTraceControl(float dt)
{
    checkMarker();

    switch (mode) {
    case MODE_IDLE:
        setMotor(0, 0);
        break;

    case MODE_START:
    case MODE_LINE_TRACE:
    case MODE_CORNER:
    case MODE_CORNERING:
        // PID制御にてライントレース(誤差に応じた出力調整)
        doLineTrace(dt);
        break;

    case MODE_GOAL:
        sleep_ms(1000);
        setMotor(0, 0);
        printf("Goal reached!\n");
        mode = MODE_IDLE;
        flag_start = 0;
        break;
    
    default: //ここに入ることはない
        //どのモードでもない時、ライントレース動作をする
        doLineTrace(dt);
    }
}

// PID制御にてライントレース(マーカー非検出時)
void doLineTrace(float dt) {
    // 誤差計算
    float pos = calcLinePosition(); // ライン位置
    float error = pos;              // 目標は中央=0

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

    if (base_pct < 20.0f) base_pct = MIN_SPEED_PCT; // 最低速度を確保

    // 左右のPWMをパーセントで計算
    float left_pct  = base_pct + u_pct + LEFT_OFFSET;
    float right_pct = base_pct - u_pct + RIGHT_OFFSET;

    // 0-100%にクリップ
    if (left_pct  < 0.0f)  left_pct  = 0.0f;
    if (left_pct  > 100.0f) left_pct = 100.0f;
    if (right_pct < 0.0f)  right_pct = 0.0f;
    if (right_pct > 100.0f) right_pct = 100.0f;

    // PWM_MAXスケーリング＆整数化
    uint16_t left_pwm  = (uint16_t)(left_pct  / 100.0f * PWM_MAX);
    uint16_t right_pwm = (uint16_t)(right_pct / 100.0f * PWM_MAX);


    // ある程度直線なら左右トップスピードで走行する
    if (-1.5f < error && error < 1.5f) {
        left_pwm  = PWM_MAX * (BASE_SPEED_PCT/100.0f);
        right_pwm = PWM_MAX * (BASE_SPEED_PCT/100.0f);
        prev_error = 0.0f;
    }

    // モータへ出力
    setMotor(left_pwm, right_pwm);
}

// 強制転回(コーナーマーカー検出時)
void rotateForce(int continue_time) {
    uint16_t lr_out = PWM_MAX * (BASE_SPEED_PCT/100.0f);
    setMotor(lr_out, lr_out);
    
    /*
    sleep_ms(5);
    float pos = calcLinePosition(); // ライン位置
    if (pos < 0.0f) { //左に曲がっている時
        for (int i = 0; i < continue_time; i++) {
            setMotor(PWM_MAX * (BASE_SPEED_PCT/100.0f), 0);
            sleep_ms(1);
        }
    }
    else if (0.0f < pos) {
        for (int i = 0; i < continue_time; i++) {
            setMotor(0, PWM_MAX * (BASE_SPEED_PCT/100.0f));
            sleep_ms(1);
        }
    }
    */
}

// 強制直進(交差点検出時)
void straightForce(int continue_time) {
    uint16_t lr_out = PWM_MAX * (BASE_SPEED_PCT/100.0f);
    setMotor(lr_out, lr_out);
    sleep_ms(10);
}

#if defined(HARDWARE)
// モータPWM出力
void setMotor(uint16_t left, uint16_t right)
{
    gpio_put(MOTOR_A1, false);               //正転
    pwm_set_gpio_level(MOTOR_A2, right); //右モータPWM出力(左では無くなぜか右)
    gpio_put(MOTOR_B1, true);               //後転(モータの向きが反転しているため)
    pwm_set_gpio_level(MOTOR_B2, left);  //左モータPWM出力(右では無くなぜか左)

    // デバッグ用
    debug_motor(left, right);
}
#endif

// 左マーカーの検出
int checkLeftMarker() {
    int flag = 0;

    for (int i = 0; i < SENSORS; i++) {
        if (flag == 0) {
            if (gpio_get(sens[i]) == 1) {
                // 反応するセンサ有り
                flag = 1;
            }
            else if (mode != MODE_CORNERING) {
                // コーナー中じゃなければ1つ目のセンサだけ確認する
                return 0;
            }
            else if (i >= 1) {
                // コーナー中は2つ目のセンサまで確認する
                return 0;
            }
        }
        else if (flag == 1) {
            if (gpio_get(sens[i]) == 0) {
                // 反応していないセンサ有り
                flag = 2;
            }
        }
        else {
            if (gpio_get(sens[i]) == 1) {
                // 反応していないセンサを挟んで反応するセンサ有り
                return 1;
            }
        }
    }

    return 0;
}

// 右マーカーの検出
int checkRightMarker() {
    int flag = 0;

    for (int i = SENSORS - 1; i >= 0; i--) {
        if (flag == 0) {
            if (gpio_get(sens[i]) == 1) {
                // 反応するセンサ有り
                flag = 1;
            }
            else {
                return 0;
            }
        }
        else if (flag == 1) {
            if (gpio_get(sens[i]) == 0) {
                // 反応していないセンサ有り
                flag = 2;
            }
        }
        else {
            if (gpio_get(sens[i]) == 1) {
                // 反応していないセンサを挟んで反応するセンサ有り
                return 1;
            }
        }
    }

    return 0;
}

// センサ反応有りの検出
int checkSensor() {
    for (int i = 0; i < SENSORS; i++) {
        if (gpio_get(sens[i]) == 1) {
            return 1;
        }
    }

    return 0;
}


// マーカー検出とモード切替
void checkMarker(void) {
    static int cnt_left = 0, cnt_right = 0;

    if (checkLeftMarker() == 1) cnt_left++; else cnt_left = 0;
    if (checkRightMarker() == 1) cnt_right++; else cnt_right = 0;

    // 再送判定
    if (mode == MODE_IDLE) {
        if (checkSensor() == 0) {
            // センサ反応無しで走行状態に戻す
            mode = MODE_LINE_TRACE;
            flag_start = 0;
            printf("### [MARKER] RESTART ###\n");
        }
        return;
    }

    // スタート判定
    if (flag_start == 0) {
        if ((cnt_left <= th_repeat) && (cnt_right >= th_repeat)) {
            mode = MODE_START; // スタート開始
            flag_start = 1;
            printf("### [MARKER] START ###\n");
        }
        return;
    }

    // スタート完了判定
    if (mode == MODE_START) {
        if (cnt_right == 0) {
            mode = MODE_LINE_TRACE;
            printf("### [MARKER] LINE TRACE ###\n");
        }
        return;
    }

    // ゴール判定
    if (mode == MODE_LINE_TRACE) {
        if ((cnt_left <= th_repeat) && (cnt_right >= th_repeat)) {
            if (flag_start == 1) {
                mode = MODE_GOAL; // ゴール検出
                printf("### [MARKER] GOAL ###\n");
                return;
            }
        }
    }

    // カーブ終了判定
    if (mode == MODE_CORNERING) {
        if ((cnt_left >= th_repeat) && (cnt_right <= th_repeat)) {
            mode = MODE_LINE_TRACE;
            printf("### [MARKER] CORNER END ###\n");
        }
        return;
    }

    // カーブ判定
    if ((cnt_left >= th_repeat) && (cnt_right <= th_repeat)) {
        mode = MODE_CORNER;
        printf("### [MARKER] CORNER START ###\n");
        return;
    }

    // カーブ中判定
    if (mode == MODE_CORNER) {
        if (cnt_left == 0) {
            mode = MODE_CORNERING;
            printf("### [MARKER] CORNERING ###\n");
        }
        return;
    }

    // 通常
    mode = MODE_LINE_TRACE;
}

// センサデバッグ用
void debug_senser(void)
{
    for (int i = 0; i < SENSORS; i++) {
        //printf("#%d=%d, ", i, gpio_get(sens[i]));   // 各センサ入力値
    }
}

// モータデバッグ用
void debug_motor(uint16_t left, uint16_t right)
{
    //printf("; #L=%d, #R=%d\n", left, right);    // モータPWM出力値
}
