Imports System.Threading

Module MainThread
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

                'PWM制御
                AlgorithmOffline()
            End If

            Thread.Sleep(1)
        End While
    End Sub

    '現在位置をシミュレーション
    Private Sub SimulatePos()
        Static sw As New Stopwatch

        If IsMoving() = False Then
            '停止中
            sw.Stop()
            Exit Sub
        End If

        If sw.IsRunning = False Then
            '動作開始
            sw.Restart()
            Exit Sub
        End If

        '停止
        sw.Stop()

        Dim sec As Double = sw.ElapsedMilliseconds / 1000.0
        Dim before_pos As PosInfo = GetPosInfo()
        Dim pwm As Byte = GetPwmValue()
        Dim speed As Double = GetSpeed()
        Dim rotate_speed As Double = GetRotateSpeed()

        '位置更新
        Dim after_pos As PosInfo = before_pos
        If (pwm = (PWM_L + PWM_R)) Then
            '直進
        ElseIf (pwm = PWM_L) Then
            '＋回転
            after_pos.angle = (after_pos.angle + (rotate_speed * sec)) Mod 360
        ElseIf (pwm = PWM_R) Then
            '－回転
            after_pos.angle = (after_pos.angle - (rotate_speed * sec)) Mod 360
        End If
        If after_pos.angle < 0 Then
            after_pos.angle += 360
        End If
        Dim distance As Double = speed * sec
        Dim rad As Double = after_pos.angle / 180 * Math.PI
        after_pos.x -= distance * Math.Cos(rad)
        after_pos.x = Math.Max(after_pos.x, 0)
        after_pos.x = Math.Min(after_pos.x, COURSE_SIZE_X - 1)
        after_pos.y -= distance * Math.Sin(rad)
        after_pos.y = Math.Max(after_pos.y, 0)
        after_pos.y = Math.Min(after_pos.y, COURSE_SIZE_Y - 1)
        SetPosInfo(after_pos)

        '再開
        sw.Restart()
    End Sub

    'センサをシミュレーション
    Private Sub SimulateSensor()
        Static ch_table() As Byte = {CH0, CH1, CH2, CH3, CH4, CH5, CH6, CH7}
        Dim pos_info As PosInfo = GetPosInfo()
        Dim sensor As Byte = 0

        For i = 0 To CHMAX
            If IsSensorOn(i, pos_info) Then
                sensor += ch_table(i)
            End If
        Next

        SetSensorValue(sensor)
    End Sub

    'センサがONか
    Private Function IsSensorOn(ByVal ch As Integer, ByVal pos_info As PosInfo) As Boolean
        IsSensorOn = True

        Try
            Dim offset_x As Integer = 0
            Dim offset_y As Integer = 0
            Dim course_info As Bitmap = GetCourseInfo(offset_x, offset_y)
            Dim start_x As Integer = GetSensorPosX(ch)
            Dim end_x As Integer = start_x + SENSOR_SIZE_X - 1
            Dim start_y As Integer = GetSensorPosY(ch)
            Dim end_y As Integer = start_y + SENSOR_SIZE_Y - 1
            Dim rad As Double = pos_info.angle / 180 * Math.PI

            For x As Integer = start_x To end_x
                For y As Integer = start_y To end_y
                    '回転後のセンサ位置を計算
                    Dim rotate_x As Integer = CInt(x * Math.Cos(rad) - y * Math.Sin(rad))
                    rotate_x += pos_info.x
                    rotate_x = Math.Max(rotate_x, 0)
                    rotate_x = Math.Min(rotate_x, COURSE_SIZE_X - 1)
                    Dim rotate_y As Integer = CInt(x * Math.Sin(rad) + y * Math.Cos(rad))
                    rotate_y += pos_info.y
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
        If (sensor And CH0) Then
            'CH0なら左側のみON
            reserve_pwm = PWM_L
        ElseIf (sensor And CH7) Then
            'CH7なら右側のみON
            reserve_pwm = PWM_R
        End If

        If (sensor And CH3) Or (sensor And CH4) Then
            'CH3か4なら両方ON
            pwm = PWM_L + PWM_R
        ElseIf (sensor And CH2) Then
            'CH2なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH5) Then
            'CH5なら右側のみON
            pwm = PWM_R
        ElseIf (sensor And CH1) Then
            'CH1なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH6) Then
            'CH6なら右側のみON
            pwm = PWM_R
        ElseIf (sensor And CH0) Then
            'CH0なら左側のみON
            pwm = PWM_L
        ElseIf (sensor And CH7) Then
            'CH7なら右側のみON
            pwm = PWM_R
        Else
            'センサが反応していない場合は標識に従う
            pwm = reserve_pwm
        End If

        'PWM状態を設定
        SetPwmValue(pwm)
    End Sub
End Module
