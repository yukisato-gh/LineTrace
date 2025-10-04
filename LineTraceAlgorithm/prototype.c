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

/* GPIO�ԍ��Ή��t�� */
#define AIN1 21   // OUTA1, phase(���]/�t�])
#define AIN2 20   // OUTA2, enable(PWM����)
#define BIN1 19   // OUTB1, phase(���]/�t�])
#define BIN2 18   // OUTB2, enable(PWM����)
const uint sens[8] = {9, 8, 7, 6, 5, 4, 3, 2}; // �Z���TIN1?IN8

/* ���[�^�o�͐ݒ� */
// PWM�̍ő�l
// 16bit=65535
#define PWM_MAX      65535U
// PWM�̍ŏ��l
#define PWM_MIN      0U
// ���i���̊�o�͂��p�[�Z���g�Őݒ�
#define BASE_SPEED_PCT   50.0f     // [%]
// �␳�ʂ̏�����p�[�Z���g�Őݒ�
#define MAX_U_PCT        BASE_SPEED_PCT
// �J�[�u�W��%(�傫���قǌ�������)
#define CURVE_COEF       0.5f

/* PID�p�����[�^ */
// ���Q�C��
#define KP  20.0f
// �ϕ��Q�C��
#define KI   0.5f
// �����Q�C��
#define KD   5.0f
// PID�p�ϐ�
float integral = 0.0f;
float prev_error = 0.0f;
// �������(ms)
const float dt = 0.01f; // 10ms

/* �Z���T�֘A */
// �Z���T��
#define SENSORS   8
// �Z���T�ʒu(���}�C�i�X�A�E�v���X)
const float sensor_pos[SENSORS] = {-4, -3, -2, -1, 1, 2, 3, 4};

/* �֐��v���g�^�C�v�錾 */
uint init_pwm(uint gpio); // PWM�o�͐ݒ�
float calcLinePosition(void); // �Z���T����ʒu���v�Z����
void lineTraceControl(float dt); // �덷�C��
void setMotorPWM(uint16_t left, uint16_t right); // ���[�^PWM�o��
void debug_senser(); // �Z���T�f�o�b�O�p
void debug_motor(uint16_t left, uint16_t right); // ���[�^�f�o�b�O�p

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

    //���C�����[�v
    while (true) {
        lineTraceControl(dt);
        sleep_ms(10);
    }
}

// PWM�o�͐ݒ�
uint init_pwm(uint gpio) {
    gpio_set_function(gpio, GPIO_FUNC_PWM);
    uint slice = pwm_gpio_to_slice_num(gpio);
    pwm_set_wrap(slice, PWM_MAX);          // �f���[�e�B���0-100�ň���
    pwm_set_clkdiv(slice, 4.0f);       // PWM�N���b�N����
    pwm_set_enabled(slice, true);
    return slice;
}
#endif

//�Z���T����ʒu���v�Z����
float calcLinePosition(void)
{
    float sum_value = 0.0f;
    float sum_weight = 0.0f;

    for (int i = 0; i < SENSORS; i++) {
        float v = gpio_get(sens[i]);     // �e�Z���T�l
        sum_value  += v * sensor_pos[i]; // �ʒu�~�l
        sum_weight += v;                 // �l�̍��v
    }

    if (sum_weight == 0.0f) {
        // ���C�������������ꍇ��0��Ԃ��i�����Ɖ���j
        return 0.0f;
    }

    return sum_value / sum_weight; // �d�S�ʒu
}

// �덷�C��
void lineTraceControl(float dt)
{
    // �덷�v�Z
    float pos = calcLinePosition();     // ���C���ʒu
    float error = pos;                  // �ڕW�͒���=0

    // PID�v�Z
    integral += error * dt;
    float derivative = (error - prev_error) / dt;
    prev_error = error;

    float u_pct = KP * error + KI * integral + KD * derivative; // �␳��[%]

    // �␳�ʂ𐧌��i�}MAX_U_PCT�j
    if (u_pct >  MAX_U_PCT) u_pct =  MAX_U_PCT;
    if (u_pct < -MAX_U_PCT) u_pct = -MAX_U_PCT;

    // �J�[�u�����p�x�[�X���x
    // �덷�ɔ�Ⴕ�ăx�[�X��������i0�ȉ��ɂȂ�Ȃ��悤�����j
    const float k_curve = CURVE_COEF;       // �����p�����[�^
    float base_pct = BASE_SPEED_PCT - k_curve * fabsf(error);

    if (base_pct < 20.0f) base_pct = 20.0f;  // �Œᑬ�x���m��

    // ���E��PWM���p�[�Z���g�Ōv�Z
    float left_pct  = BASE_SPEED_PCT - u_pct;
    float right_pct = BASE_SPEED_PCT + u_pct;

    // 0?100%�ɃN���b�v
    if (left_pct  < 0.0f)  left_pct  = 0.0f;
    if (left_pct  > 100.0f) left_pct = 100.0f;
    if (right_pct < 0.0f)  right_pct = 0.0f;
    if (right_pct > 100.0f) right_pct = 100.0f;

    // PWM_MAX�X�P�[�����O��������
    uint16_t left_pwm  = (uint16_t)(left_pct  / 100.0f * PWM_MAX);
    uint16_t right_pwm = (uint16_t)(right_pct / 100.0f * PWM_MAX);

    //���[�^�֏o��
    setMotorPWM(left_pwm, right_pwm);

    //�f�o�b�O�o�͗p
    debug_senser();
    debug_motor(left_pwm, right_pwm);
}

#if defined(HARDWARE)
// ���[�^PWM�o��
void setMotorPWM(uint16_t left, uint16_t right)
{
    pwm_set_gpio_level(AIN1, PWM_MIN);
    pwm_set_gpio_level(AIN2, right);
    pwm_set_gpio_level(BIN1, PWM_MAX);
    pwm_set_gpio_level(BIN2, left);
}
#endif

// �Z���T�f�o�b�O�p
void debug_senser()
{
    for (int i = 0; i < SENSORS; i++) {
        printf("#%d=%d, ", i, gpio_get(sens[i]));     // �e�Z���T���͒l
    }
}

// ���[�^�f�o�b�O�p
void debug_motor(uint16_t left, uint16_t right)
{
    printf("; #L=%d, #R=%d\n", left, right);    // ���[�^PWM�o�͒l
}