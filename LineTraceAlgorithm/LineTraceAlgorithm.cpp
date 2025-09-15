#include <windows.h>
#include <stdio.h>

#define CH(index)   (1 << index)
#define PWM_L       (1)
#define PWM_R       (2)

void AlgorithmOnline(BYTE *sensor, BYTE *pwm);

/* メイン関数 */
int main()
{
	volatile BYTE *sensor;
	volatile BYTE *pwm;

	/* センサー値の共有メモリ初期化 */
	HANDLE sensor_handle = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1, L"Sensor");
	if (sensor_handle == NULL)
	{
		return 1;
	}
	sensor = (BYTE *)MapViewOfFile(sensor_handle, FILE_MAP_ALL_ACCESS, 0, 0, 1);
	if (sensor == NULL)
	{
		return 1;
	}

	/* PWM値の共有メモリ初期化 */
	HANDLE pwm_handle = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1, L"Pwm");
	if (pwm_handle == NULL)
	{
		return 1;
	}
	pwm = (BYTE *)MapViewOfFile(pwm_handle, FILE_MAP_ALL_ACCESS, 0, 0, 1);
	if (pwm == NULL)
	{
		return 1;
	}

	/* 走行アルゴリズム */
	while (true)
	{
		AlgorithmOnline((BYTE *)sensor, (BYTE *)pwm);
        printf("sensor=%d, pwm=%d\n", *sensor, *pwm);
	}

	/* 共有メモリ解放 */
	UnmapViewOfFile((void *)sensor);
	CloseHandle(sensor_handle);
	UnmapViewOfFile((void*)pwm);
	CloseHandle(pwm_handle);

	return 0;
}

/* 走行アルゴリズム */
void AlgorithmOnline(BYTE* sensor, BYTE* pwm)
{
    static BYTE reserve_pwm = 0;

    /* 標識認識 */
    if (*sensor & CH(0))
    {
        /* CH0なら左側のみON */
        reserve_pwm = PWM_L;
    }
    else if (*sensor & CH(7))
    {
        /* CH7なら右側のみON */
        reserve_pwm = PWM_R;
    }

    if ((*sensor & CH(3)) || (*sensor & CH(4)))
    {
        /* CH3か4なら両方ON */
        *pwm = PWM_L + PWM_R;
    }
    else if (*sensor & CH(2))
    {
        /* CH2なら左側のみON */
        *pwm = PWM_L;
    }
    else if (*sensor & CH(5))
    {
        /* CH5なら右側のみON */
        *pwm = PWM_R;
    }
    else if (*sensor & CH(1))
    {
        /* CH1なら左側のみON */
        *pwm = PWM_L;
    }
    else if (*sensor & CH(6))
    {
        /* CH6なら右側のみON */
        *pwm = PWM_R;
    }
    else if (*sensor & CH(0))
    {
        /* CH0なら左側のみON */
        *pwm = PWM_L;
    }
    else if (*sensor & CH(7))
    {
        /* CH7なら右側のみON */
        *pwm = PWM_R;
    }
    else
    {
        /* センサが反応していない場合は標識に従う */
        *pwm = reserve_pwm;
    }
}
