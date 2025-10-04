#pragma once

#define CH(index)   (1 << index)
#define PWM_L       (1)
#define PWM_R       (2)

#define uint unsigned int
#define BYTE unsigned char
#define uint16_t unsigned short

extern int gpio_get(unsigned int gpio_no);
extern void setMotorPWM(uint16_t left, uint16_t right);

extern const uint sens[8];
extern const float dt;
extern void lineTraceControl(float dt);
