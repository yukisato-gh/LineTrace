Imports System.Runtime.CompilerServices

Public Module LineTraceSim
    'センサ位置
    Public Enum SensorPosIndex
        START_X = 0
        END_X
        START_Y
        END_Y
    End Enum

    Public sensor_pos(,) As Integer = {
        {-38, -33, -24, -19},   'CH0
        {-38, -33, -18, -13},   'CH1
        {-38, -33, -12, -7},    'CH2
        {-38, -33, -6, -1},     'CH3
        {-38, -33, 0, 5},       'Ch4
        {-38, -33, 6, 11},      'CH5
        {-38, -33, 12, 17},     'CH6
        {-38, -33, 18, 23}      'CH7
    }

    Public Const CH0 As Byte = &H1
    Public Const CH1 As Byte = &H2
    Public Const CH2 As Byte = &H4
    Public Const CH3 As Byte = &H8
    Public Const CH4 As Byte = &H10
    Public Const CH5 As Byte = &H20
    Public Const CH6 As Byte = &H40
    Public Const CH7 As Byte = &H80
    Public Const CHMAX As Byte = 7

    Public Const PWM_L As Byte = &H1
    Public Const PWM_R As Byte = &H2

    Public Const COURSE_SIZE_X As Integer = 800
    Public Const COURSE_SIZE_Y As Integer = 600

    Public Const CAR_SIZE_X As Integer = 120
    Public Const CAR_SIZE_Y As Integer = 120

    Public Const CAR_CENTER_X As Double = CAR_SIZE_X / 2.0
    Public Const CAR_CENTER_Y As Double = CAR_SIZE_Y / 2.0

    Public Const DEFAULT_SPEED As Double = 10.0
    Public Const DEFAULT_ROTATE_SPEED As Double = 90

    '位置情報
    Public Structure PosInfo
        Dim x As Double
        Dim y As Double
        Dim angle As Double
    End Structure

    'センサ位置
    Public Structure SensorPos
        Dim start_x As Integer
        Dim end_x As Integer
        Dim start_y As Integer
        Dim end_y As Integer
    End Structure

    '排他制御
    Private ReadOnly lock As New Object()

    'アプリケーション生存
    Private alive As Boolean = True

    'センサ値
    Private sensor_value As Byte = 0

    'PWM
    Private pwm_value As Byte = 0

    '初期位置
    Private default_pos_info As PosInfo

    '現在位置
    Private pos_info As PosInfo

    'コース情報
    Private course_info As Bitmap

    'カー情報
    Private car_info As Bitmap

    '速度[pix/s]
    Private speed As Double = DEFAULT_SPEED

    '回転速度[deg/s]
    Private rotate_speed As Double = DEFAULT_ROTATE_SPEED

    '動作させるか
    Private is_moving As Boolean = False

    'コース位置によるオフセットX
    Private offset_x As Integer = 0

    'コース位置によるオフセットY
    Private offset_y As Integer = 0

    Public Sub SetAlive(ByVal value As Boolean)
        SyncLock lock
            alive = value
        End SyncLock
    End Sub

    Public Function IsAlive() As Boolean
        SyncLock lock
            IsAlive = alive
        End SyncLock
    End Function

    Public Sub SetSensorValue(ByVal value As Byte)
        SyncLock lock
            sensor_value = value
        End SyncLock
    End Sub

    Public Function GetSensorValue() As Byte
        SyncLock lock
            GetSensorValue = sensor_value
        End SyncLock
    End Function

    Public Sub SetPwmValue(ByVal value As Byte)
        SyncLock lock
            pwm_value = value
        End SyncLock
    End Sub

    Public Function GetPwmValue() As Byte
        SyncLock lock
            GetPwmValue = pwm_value
        End SyncLock
    End Function

    Public Sub SetDefaultPosInfo(ByRef info As PosInfo)
        SyncLock lock
            default_pos_info = info
            pos_info = info
        End SyncLock
    End Sub

    Public Function GetDefaultPosInfo() As PosInfo
        SyncLock lock
            GetDefaultPosInfo = default_pos_info
        End SyncLock
    End Function

    Public Sub SetPosInfo(ByRef info As PosInfo)
        SyncLock lock
            pos_info = info
        End SyncLock
    End Sub

    Public Function GetPosInfo() As PosInfo
        SyncLock lock
            GetPosInfo = pos_info
        End SyncLock
    End Function

    Public Sub SetCourseInfo(ByRef info As Bitmap, ByVal x As Integer, ByVal y As Integer)
        SyncLock lock
            course_info = info.Clone()
            offset_x = x
            offset_y = y
        End SyncLock
    End Sub

    Public Function GetCourseInfo(ByRef x As Integer, ByRef y As Integer) As Bitmap
        SyncLock lock
            x = offset_x
            y = offset_y
            GetCourseInfo = course_info
        End SyncLock
    End Function

    Public Sub SetCarInfo(ByRef info As Bitmap)
        SyncLock lock
            car_info = info.Clone()
        End SyncLock
    End Sub

    Public Function GetCarInfo() As Bitmap
        SyncLock lock
            GetCarInfo = car_info
        End SyncLock
    End Function

    Public Sub SetSpeed(ByVal value As Double)
        SyncLock lock
            speed = value
        End SyncLock
    End Sub

    Public Function GetSpeed() As Double
        SyncLock lock
            GetSpeed = speed
        End SyncLock
    End Function

    Public Sub SetRotateSpeed(ByVal value As Double)
        SyncLock lock
            rotate_speed = value
        End SyncLock
    End Sub

    Public Function GetRotateSpeed() As Double
        SyncLock lock
            GetRotateSpeed = rotate_speed
        End SyncLock
    End Function

    Public Function IsMoving() As Boolean
        SyncLock lock
            IsMoving = is_moving
        End SyncLock
    End Function

    Public Sub SetMoving(ByVal value As Boolean)
        SyncLock lock
            is_moving = value
        End SyncLock
    End Sub
End Module
