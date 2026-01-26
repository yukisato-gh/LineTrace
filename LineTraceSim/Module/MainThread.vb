Imports System.Threading
Imports System.Diagnostics ' Stopwatchのために必要

Module MainThread

    ' --- 物理パラメータ (LineTraceSim.vbなどで定義・設定することを想定) ---
    ' 質量 (kg)
    Private Const MASS As Double = 1.0
    ' 慣性モーメント (kg*m^2)
    Private Const INERTIA_MOMENT As Double = 0.1
    ' モーターの推力 (N)
    Private Const MOTOR_FORCE As Double = 100 '暫定
    ' モーターによるトルク (N*m)
    Private Const MOTOR_TORQUE As Double = 50 '暫定
    ' 直線運動の摩擦係数
    Private Const FRICTION_COEFFICIENT As Double = 0.8
    ' 回転運動の摩擦係数
    Private Const ROTATIONAL_FRICTION_COEFFICIENT As Double = 0.5

    ' --- 状態変数 ---
    ' 現在の速度 (m/s)
    Private currentSpeed As Double = 0.0
    ' 現在の角速度 (deg/s)
    Private currentAngularVelocity As Double = 0.0

    'メインループを開始
    Public Sub StartMainLoop()
        Dim thread As New Thread(AddressOf MainLoop)
        thread.Start()
    End Sub

    'メインループ処理
    Private Sub MainLoop()
        While IsAlive()
            '現在位置をシミュレーション
            SimulatePos()

            If IsMoving() = True Then
                'センサをシミュレーション
                SimulateSensor()

                If IsOnline() = False Then
                    'PWM制御
                    AlgorithmOffline()
                End If
            End If

            Thread.Sleep(10)
        End While
    End Sub

    '現在位置をシミュレーション (物理ベースのロジックに更新)
    Private Sub SimulatePos()
        Static sw As New Stopwatch

        If IsMoving() = False Then
            '停止中
            sw.Stop()
            currentSpeed = 0
            currentAngularVelocity = 0
            Exit Sub
        End If

        If sw.IsRunning = False Then
            '動作開始
            sw.Restart()
            Exit Sub
        End If

        '経過時間を計算
        Dim elapsedSec As Double = sw.ElapsedMilliseconds / 1000.0
        sw.Restart() ' 次のフレームのためにリスタート

        If elapsedSec <= 0 Then Exit Sub '経過時間がなければ何もしない

        Dim before_pos As PosInfo = GetPosInfo()
        Dim pwm As Byte = GetPwmValue()

        Dim pwm_coef_left As Double = GetPwmLeftPercent() / 100
        Dim pwm_coef_right As Double = GetPwmRightPercent() / 100
        Dim pwm_coef As Double = (pwm_coef_left + pwm_coef_right) / 2

        ' --- 1. 力とトルクの計算 ---
        Dim thrust As Double = 0
        Dim torque As Double = 0

        If (pwm_coef_left = pwm_coef_right) Then
            '直進
            thrust = MOTOR_FORCE
            torque = 0
        ElseIf (pwm_coef_left > pwm_coef_right) Then
            '＋回転
            thrust = 0 ' 回転時は直進しないと仮定
            torque = MOTOR_TORQUE
        ElseIf (pwm_coef_right > pwm_coef_left) Then
            '－回転
            thrust = 0 ' 回転時は直進しないと仮定
            torque = -MOTOR_TORQUE
        End If

        ' --- 2. 摩擦の計算 ---
        ' 速度に比例する抵抗を計算
        Dim frictionForce As Double = currentSpeed * FRICTION_COEFFICIENT
        ' 角速度に比例する抵抗を計算
        Dim rotationalFriction As Double = currentAngularVelocity * ROTATIONAL_FRICTION_COEFFICIENT

        ' --- 3. 加速度と角加速度の計算 (F=ma, τ=Iα) ---
        Dim netForce As Double = thrust - frictionForce
        Dim acceleration As Double = netForce / MASS

        Dim netTorque As Double = torque - rotationalFriction
        Dim angularAcceleration As Double = netTorque / INERTIA_MOMENT

        ' --- 4. 速度と角速度の更新 ---
        currentSpeed += acceleration * elapsedSec
        currentSpeed = Math.Max(0, currentSpeed) ' 速度は負にならない
        SetSpeed(currentSpeed)

        currentAngularVelocity += angularAcceleration * elapsedSec
        SetRotateSpeed(Math.Abs(currentAngularVelocity))

        ' --- 5. 位置と角度の更新 ---
        Dim after_pos As PosInfo = before_pos

        ' 角度更新
        after_pos.angle = (after_pos.angle + (currentAngularVelocity * elapsedSec * pwm_coef)) Mod 360
        If after_pos.angle < 0 Then
            after_pos.angle += 360
        End If

        ' 位置更新
        Dim distance As Double = currentSpeed * elapsedSec * pwm_coef
        Dim rad As Double = after_pos.angle / 180 * Math.PI
        after_pos.x -= distance * Math.Cos(rad)
        after_pos.y -= distance * Math.Sin(rad)

        ' 範囲チェック
        after_pos.x = Math.Max(after_pos.x, 0)
        after_pos.x = Math.Min(after_pos.x, COURSE_SIZE_X - 1)
        after_pos.y = Math.Max(after_pos.y, 0)
        after_pos.y = Math.Min(after_pos.y, COURSE_SIZE_Y - 1)
        
        SetPosInfo(after_pos)
    End Sub

    'センサをシミュレーション
    Private Sub SimulateSensor()
        Static ch_table() As Byte = {CH0, CH1, CH2, CH3, CH4, CH5, CH6, CH7}
        Dim pos_info As PosInfo = GetPosInfo()
        Dim sensor As Byte = 0
        Dim ok As Boolean = False

        For i = 0 To CHMAX
            If IsSensorOn(i, pos_info) Then
                sensor += ch_table(i)
                If i = 3 Or i = 4 Then
                    'CH3かCH4がONならOKとする
                    ok = True
                End If
            End If
        Next

        'スコアを設定
        SetScore(ok)

        SetSensorValue(sensor)
    End Sub

    'センサがONか
    Private Function IsSensorOn(ByVal ch As Integer, ByVal pos_info As PosInfo) As Boolean
        IsSensorOn = True

        Try
            Dim offset_x As Integer = 0
            Dim offset_y As Integer = 0
            Dim course_info As Bitmap = GetCourseInfo(offset_x, offset_y)
            Dim start_x As Integer = sensor_pos(ch, SensorPosIndex.START_X)
            Dim end_x As Integer = sensor_pos(ch, SensorPosIndex.END_X)
            Dim start_y As Integer = sensor_pos(ch, SensorPosIndex.START_Y)
            Dim end_y As Integer = sensor_pos(ch, SensorPosIndex.END_Y)
            Dim rad As Double = pos_info.angle / 180 * Math.PI

            For x As Integer = start_x To end_x
                For y As Integer = start_y To end_y
                    '回転後のセンサ位置を計算
                    Dim rotate_x As Integer = CInt(x * Math.Cos(rad) - y * Math.Sin(rad))
                    rotate_x += CInt(pos_info.x)
                    rotate_x = Math.Max(rotate_x, 0)
                    rotate_x = Math.Min(rotate_x, COURSE_SIZE_X - 1)
                    Dim rotate_y As Integer = CInt(x * Math.Sin(rad) + y * Math.Cos(rad))
                    rotate_y += CInt(pos_info.y)
                    rotate_y = Math.Max(rotate_y, 0)
                    rotate_y = Math.Min(rotate_y, COURSE_SIZE_Y - 1)

                    'センサ位置の画素が黒か
                    Dim color As Color = course_info.GetPixel(Math.Max(rotate_x - offset_x, 0), Math.Max(rotate_y - offset_y, 0))
                    If color.R = 0 Then
                        Exit Function
                    End If
                Next y
            Next x
        Catch ex As Exception
        End Try

        IsSensorOn = False
    End Function

    'PWM制御(オフライン)
    Private Sub AlgorithmOffline()
        Static reserve_pwm As Byte = 0
        Dim sensor As Byte = GetSensorValue()
        Dim pwm As Byte

        '標識認識
        If (sensor And CH7) Then
            'CH7なら左側のみON
            reserve_pwm = PWM_L
        ElseIf (sensor And CH0) Then
            'CH0なら右側のみON
            reserve_pwm = PWM_R
        End If

        If (sensor And CH3) Or (sensor And CH4) Then
            'CH3か4なら両方ON
            pwm = PWM_L + PWM_R
        ElseIf (sensor And CH5) Then
            'CH5なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH2) Then
            'CH2なら右側のみON
            pwm = PWM_R
        ElseIf (sensor And CH6) Then
            'CH6なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH1) Then
            'CH1なら右側のみON
            pwm = PWM_R
        ElseIf (sensor And CH7) Then
            'CH7なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH0) Then
            'CH0なら右側のみON
            pwm = PWM_R
        Else
            'センサが反応していない場合は標識に従う
            pwm = reserve_pwm
        End If

        'PWM状態を設定
        SetPwmValue(pwm)

        'PWM出力を設定
        If (pwm And PWM_L) = 0 Then
            SetPwmLeftPercent(0)
        Else
            SetPwmLeftPercent(100)
        End If
        If (pwm And PWM_R) = 0 Then
            SetPwmRightPercent(0)
        Else
            SetPwmRightPercent(100)
        End If
    End Sub
End Module