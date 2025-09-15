Imports System.Reflection.Metadata
Imports LineTraceSim.LineTraceSim
Imports Windows.Win32.UI.Input

Public Class FormMain
    Private Const TEXT_ON As String = "●"
    Private Const TEXT_OFF As String = "〇"

    'センサ
    Private Const SENSOR_NUM As Integer = 8
    Private m_sensor(SENSOR_NUM - 1) As Label

    'カーのドラッグ＆ドロップ
    Private m_is_car_drag As Boolean = False
    Private m_drag_start_pos As Point
    Private m_car_start_pos As Point

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitControl()

        'デフォルトの位置を設定
        Dim pos_info As PosInfo
        pos_info.x = PB_Car.Location.X + CAR_CENTER_X
        pos_info.y = PB_Car.Location.Y + CAR_CENTER_Y
        pos_info.angle = 0
        SetDefaultPosInfo(pos_info)

        'DPI情報を取得
        Dim g As Graphics = CreateGraphics()
        Dim dpi_x As Integer = g.DpiX
        Dim dpi_y As Integer = g.DpiY
        SetDpiX(dpi_x)
        SetDpiY(dpi_y)

        'デフォルトのコース情報を設定
        Dim course As Bitmap = PB_Course.Image
        course.SetResolution(dpi_x, dpi_y)
        SetCourseInfo(PB_Course.Image, PB_Course.Location.X, PB_Course.Location.Y)

        'デフォルトのカー情報を設定
        Dim car As Bitmap = PB_Car.Image
        car.SetResolution(dpi_x, dpi_y)
        SetCarInfo(PB_Car.Image)

        'メインループを開始
        StartMainLoop()

        '定期更新タイマを開始
        TimerCyclic.Enabled = True
    End Sub

    'コントロールを初期化
    Private Sub InitControl()
        m_sensor(0) = L_Sensor_0
        m_sensor(1) = L_Sensor_1
        m_sensor(2) = L_Sensor_2
        m_sensor(3) = L_Sensor_3
        m_sensor(4) = L_Sensor_4
        m_sensor(5) = L_Sensor_5
        m_sensor(6) = L_Sensor_6
        m_sensor(7) = L_Sensor_7
    End Sub

    '定期更新タイマ
    Private Sub TimerCyclic_Tick() Handles TimerCyclic.Tick
        Try
            TimerCyclic.Enabled = False

            If m_is_car_drag Then
                'ドラッグ中は処理しない
                Exit Sub
            End If

            'センサ状態を反映
            DispSensor()

            'PWM状態を反映
            DispPwm()

            '現在位置を反映
            DispPos()

        Catch ex As Exception

        Finally
            TimerCyclic.Enabled = True
        End Try
    End Sub

    'センサ状態を反映
    Private Sub DispSensor()
        Dim sensor_value As Byte = GetSensorValue()

        For ch As Integer = 0 To SENSOR_NUM - 1
            Dim enable As Boolean
            Select Case ch
                Case 0
                    enable = ((sensor_value And CH0) <> 0)
                Case 1
                    enable = ((sensor_value And CH1) <> 0)
                Case 2
                    enable = ((sensor_value And CH2) <> 0)
                Case 3
                    enable = ((sensor_value And CH3) <> 0)
                Case 4
                    enable = ((sensor_value And CH4) <> 0)
                Case 5
                    enable = ((sensor_value And CH5) <> 0)
                Case 6
                    enable = ((sensor_value And CH6) <> 0)
                Case 7
                    enable = ((sensor_value And CH7) <> 0)
            End Select

            If enable Then
                m_sensor(ch).Text = TEXT_ON
            Else
                m_sensor(ch).Text = TEXT_OFF
            End If
        Next
    End Sub

    'PWM状態を反映
    Private Sub DispPwm()
        Dim pwm_value As Byte = GetPwmValue()

        If ((pwm_value And PWM_L) <> 0) Then
            L_PWM_L.Text = TEXT_ON
        Else
            L_PWM_L.Text = TEXT_OFF
        End If

        If ((pwm_value And PWM_R) <> 0) Then
            L_PWM_R.Text = TEXT_ON
        Else
            L_PWM_R.Text = TEXT_OFF
        End If
    End Sub

    '現在位置を反映
    Private Sub DispPos()
        Dim pos_info As PosInfo = GetPosInfo()
        L_Status_X.Text = pos_info.x.ToString("0.0")
        L_Status_Y.Text = pos_info.y.ToString("0.0")
        L_Status_Angle.Text = pos_info.angle.ToString("0.0")

        'カーの位置を更新
        Dim x As Integer = Math.Max(CInt(pos_info.x - CAR_CENTER_X), 0)
        Dim y As Integer = Math.Max(CInt(pos_info.y - CAR_CENTER_Y), 0)
        PB_Car.Location = New Point(x, y)

        'カーの回転
        Dim car As Bitmap = GetCarInfo()
        Dim rotate_car As Bitmap = RotateBitmap(car, pos_info.angle, CAR_CENTER_X, CAR_CENTER_Y)
        PB_Car.Image = rotate_car
    End Sub

    Private Function RotateBitmap(ByVal org As Bitmap, ByVal angle As Double, ByVal center_x As Double, ByVal center_y As Double) As Bitmap
        Dim ret As New Bitmap(CAR_SIZE_X, CAR_SIZE_Y)
        Dim g As Graphics = Graphics.FromImage(ret)

        g.TranslateTransform(-center_x, -center_y)
        g.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Append)
        g.TranslateTransform(center_x, center_y, System.Drawing.Drawing2D.MatrixOrder.Append)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
        g.DrawImageUnscaled(org, 0, 0)
        g.Dispose()

        RotateBitmap = ret
    End Function

    Private Sub B_POS_SET_Click(sender As Object, e As EventArgs) Handles B_POS_SET.Click
        Dim pos_info As PosInfo

        Double.TryParse(T_Pos_X.Text, pos_info.x)
        Double.TryParse(T_Pos_Y.Text, pos_info.y)
        Double.TryParse(T_Pos_Angle.Text, pos_info.angle)

        SetPosInfo(pos_info)
    End Sub

    Private Sub B_POS_DEFAULT_Click(sender As Object, e As EventArgs) Handles B_POS_DEFAULT.Click
        Dim pos_info As PosInfo = GetDefaultPosInfo()

        T_Pos_X.Text = pos_info.x.ToString("0.0")
        T_Pos_Y.Text = pos_info.y.ToString("0.0")
        T_Pos_Angle.Text = pos_info.angle.ToString("0.0")

        SetPosInfo(pos_info)
    End Sub

    Private Sub SetAngleCommon(ByVal angle As Double)
        Dim pos_info As PosInfo = GetPosInfo()

        pos_info.angle = angle

        T_Pos_X.Text = pos_info.x.ToString("0.0")
        T_Pos_Y.Text = pos_info.y.ToString("0.0")
        T_Pos_Angle.Text = pos_info.angle.ToString("0.0")

        SetPosInfo(pos_info)
    End Sub

    Private Sub B_Angle_0_Click(sender As Object, e As EventArgs) Handles B_Angle_0.Click
        SetAngleCommon(0)
    End Sub

    Private Sub B_Angle_1_Click(sender As Object, e As EventArgs) Handles B_Angle_1.Click
        SetAngleCommon(45)
    End Sub

    Private Sub B_Angle_2_Click(sender As Object, e As EventArgs) Handles B_Angle_2.Click
        SetAngleCommon(90)
    End Sub

    Private Sub B_Angle_3_Click(sender As Object, e As EventArgs) Handles B_Angle_3.Click
        SetAngleCommon(135)
    End Sub

    Private Sub B_Angle_4_Click(sender As Object, e As EventArgs) Handles B_Angle_4.Click
        SetAngleCommon(180)
    End Sub

    Private Sub B_Angle_5_Click(sender As Object, e As EventArgs) Handles B_Angle_5.Click
        SetAngleCommon(225)
    End Sub

    Private Sub B_Angle_6_Click(sender As Object, e As EventArgs) Handles B_Angle_6.Click
        SetAngleCommon(270)
    End Sub

    Private Sub B_Angle_7_Click(sender As Object, e As EventArgs) Handles B_Angle_7.Click
        SetAngleCommon(315)
    End Sub

    Private Sub B_AUTO_Click(sender As Object, e As EventArgs) Handles B_AUTO.Click
        Dim speed As Double = 0
        If Double.TryParse(T_Spd.Text, speed) = False Then
            MsgBox("速度が不正です。")
            Exit Sub
        End If

        Dim rotate_speed As Double
        If Double.TryParse(T_Rotate.Text, rotate_speed) = False Then
            MsgBox("回転速度パラメータが不正です。")
            Exit Sub
        End If

        '速度パラメータを設定
        SetSpeed(speed)
        SetRotateSpeed(rotate_speed)

        '動作開始
        SetMoving(True)
    End Sub

    Private Sub B_STOP_Click(sender As Object, e As EventArgs) Handles B_STOP.Click
        '動作停止
        SetMoving(False)
    End Sub

    Private Sub B_GO_MouseDown(sender As Object, e As MouseEventArgs) Handles B_GO.MouseDown
        Dim speed As Double = 0
        If Double.TryParse(T_Spd.Text, speed) = False Then
            MsgBox("速度が不正です。")
            Exit Sub
        End If

        Dim rotate_speed As Double
        If Double.TryParse(T_Rotate.Text, rotate_speed) = False Then
            MsgBox("回転速度パラメータが不正です。")
            Exit Sub
        End If

        '速度パラメータを設定
        SetSpeed(speed)
        SetRotateSpeed(rotate_speed)

        '動作開始
        SetMoving(True)
    End Sub

    Private Sub B_GO_MouseUp(sender As Object, e As MouseEventArgs) Handles B_GO.MouseUp
        '動作停止
        SetMoving(False)
    End Sub

    Private Sub SelectCourseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCourseToolStripMenuItem.Click
        Dim dialog As New OpenFileDialog()
        With dialog
            .Title = "Select course file"
            .Filter = "Image File (*.bmp)|*.bmp"
            .InitialDirectory = My.Application.Info.DirectoryPath
            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            Dim course = New Bitmap(.FileName)
            course.SetResolution(GetDpiX(), GetDpiY())
            PB_Course.Image = course
            SetCourseInfo(course, PB_Course.Location.X, PB_Course.Location.Y)
        End With
    End Sub

    Private Sub SelectCarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCarToolStripMenuItem.Click
        Dim dialog As New OpenFileDialog()
        With dialog
            .Title = "Select car file"
            .Filter = "Image File (*.bmp)|*.bmp"
            .InitialDirectory = My.Application.Info.DirectoryPath
            If .ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            Dim car = New Bitmap(.FileName)
            car.SetResolution(GetDpiX(), GetDpiY())
            PB_Car.Image = car
            SetCarInfo(car)
        End With
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        SetAlive(False)
    End Sub

    Private Sub PB_Car_MouseDown(sender As Object, e As MouseEventArgs) Handles PB_Car.MouseDown
        If e.Button <> MouseButtons.Left Then
            Exit Sub
        End If

        If m_is_car_drag = False Then
            m_car_start_pos.X = PB_Car.Left
            m_car_start_pos.Y = PB_Car.Top
        End If

        m_is_car_drag = True
        m_drag_start_pos = e.Location
    End Sub

    Private Sub PB_Car_MouseMove(sender As Object, e As MouseEventArgs) Handles PB_Car.MouseMove
        If m_is_car_drag = False Then
            Exit Sub
        End If

        PB_Car.Left += e.X - m_drag_start_pos.X
        PB_Car.Top += e.Y - m_drag_start_pos.Y
    End Sub

    Private Sub PB_Car_MouseUp(sender As Object, e As MouseEventArgs) Handles PB_Car.MouseUp
        If e.Button <> MouseButtons.Left Then
            Exit Sub
        End If

        Dim pos_info As PosInfo = GetPosInfo()
        pos_info.x += PB_Car.Left - m_car_start_pos.X
        pos_info.x = Math.Max(pos_info.x, 0)
        pos_info.x = Math.Min(pos_info.x, COURSE_SIZE_X - 1)
        pos_info.y += PB_Car.Top - m_car_start_pos.Y
        pos_info.y = Math.Max(pos_info.y, 0)
        pos_info.y = Math.Min(pos_info.y, COURSE_SIZE_Y - 1)
        SetPosInfo(pos_info)

        m_is_car_drag = False
    End Sub
End Class
