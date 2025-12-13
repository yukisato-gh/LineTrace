<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        PB_Course = New PictureBox()
        PB_Car = New PictureBox()
        GroupBox1 = New GroupBox()
        L_Sensor_7 = New Label()
        L_Sensor_6 = New Label()
        L_Sensor_5 = New Label()
        L_Sensor_4 = New Label()
        L_Sensor_3 = New Label()
        L_Sensor_2 = New Label()
        L_Sensor_1 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        L_Sensor_0 = New Label()
        GroupBox2 = New GroupBox()
        L_PWM_PCT_R = New Label()
        L_PWM_PCT_L = New Label()
        L_PWM_R = New Label()
        Label11 = New Label()
        L_PWM_L = New Label()
        Label1 = New Label()
        GroupBox3 = New GroupBox()
        L_Status_Angle = New Label()
        L_Status_Y = New Label()
        L_Status_X = New Label()
        Label10 = New Label()
        Label12 = New Label()
        Label14 = New Label()
        GroupBox4 = New GroupBox()
        Label18 = New Label()
        T_Rotate = New TextBox()
        Label17 = New Label()
        T_Spd = New TextBox()
        B_STOP = New Button()
        B_GO = New Button()
        B_AUTO = New Button()
        GroupBox5 = New GroupBox()
        B_POS_DEFAULT = New Button()
        B_POS_SET = New Button()
        B_Angle_7 = New Button()
        B_Angle_6 = New Button()
        B_Angle_5 = New Button()
        B_Angle_4 = New Button()
        B_Angle_3 = New Button()
        B_Angle_2 = New Button()
        B_Angle_1 = New Button()
        B_Angle_0 = New Button()
        T_Pos_Angle = New TextBox()
        T_Pos_Y = New TextBox()
        T_Pos_X = New TextBox()
        Label13 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        TimerCyclic = New Timer(components)
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        SelectCourseToolStripMenuItem = New ToolStripMenuItem()
        SelectCarToolStripMenuItem = New ToolStripMenuItem()
        OnlineToolStripMenuItem_0 = New ToolStripMenuItem()
        OnlineToolStripMenuItem_1 = New ToolStripMenuItem()
        GroupBox6 = New GroupBox()
        L_Score = New Label()
        Label22 = New Label()
        Label19 = New Label()
        L_Score_Speed = New Label()
        L_Score_Rotate = New Label()
        CType(PB_Course, ComponentModel.ISupportInitialize).BeginInit()
        CType(PB_Car, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox5.SuspendLayout()
        MenuStrip1.SuspendLayout()
        GroupBox6.SuspendLayout()
        SuspendLayout()
        ' 
        ' PB_Course
        ' 
        PB_Course.Image = CType(resources.GetObject("PB_Course.Image"), Image)
        PB_Course.InitialImage = CType(resources.GetObject("PB_Course.InitialImage"), Image)
        PB_Course.Location = New Point(8, 25)
        PB_Course.Margin = New Padding(2)
        PB_Course.Name = "PB_Course"
        PB_Course.Size = New Size(800, 600)
        PB_Course.SizeMode = PictureBoxSizeMode.CenterImage
        PB_Course.TabIndex = 0
        PB_Course.TabStop = False
        ' 
        ' PB_Car
        ' 
        PB_Car.BackColor = Color.White
        PB_Car.Image = CType(resources.GetObject("PB_Car.Image"), Image)
        PB_Car.Location = New Point(173, 480)
        PB_Car.Margin = New Padding(2)
        PB_Car.Name = "PB_Car"
        PB_Car.Size = New Size(120, 120)
        PB_Car.SizeMode = PictureBoxSizeMode.CenterImage
        PB_Car.TabIndex = 1
        PB_Car.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(L_Sensor_7)
        GroupBox1.Controls.Add(L_Sensor_6)
        GroupBox1.Controls.Add(L_Sensor_5)
        GroupBox1.Controls.Add(L_Sensor_4)
        GroupBox1.Controls.Add(L_Sensor_3)
        GroupBox1.Controls.Add(L_Sensor_2)
        GroupBox1.Controls.Add(L_Sensor_1)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(L_Sensor_0)
        GroupBox1.Location = New Point(812, 26)
        GroupBox1.Margin = New Padding(2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(2)
        GroupBox1.Size = New Size(273, 61)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Sensor"
        ' 
        ' L_Sensor_7
        ' 
        L_Sensor_7.AutoSize = True
        L_Sensor_7.Location = New Point(237, 37)
        L_Sensor_7.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_7.Name = "L_Sensor_7"
        L_Sensor_7.Size = New Size(19, 15)
        L_Sensor_7.TabIndex = 15
        L_Sensor_7.Text = "〇"
        ' 
        ' L_Sensor_6
        ' 
        L_Sensor_6.AutoSize = True
        L_Sensor_6.Location = New Point(204, 37)
        L_Sensor_6.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_6.Name = "L_Sensor_6"
        L_Sensor_6.Size = New Size(19, 15)
        L_Sensor_6.TabIndex = 14
        L_Sensor_6.Text = "〇"
        ' 
        ' L_Sensor_5
        ' 
        L_Sensor_5.AutoSize = True
        L_Sensor_5.Location = New Point(172, 37)
        L_Sensor_5.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_5.Name = "L_Sensor_5"
        L_Sensor_5.Size = New Size(19, 15)
        L_Sensor_5.TabIndex = 13
        L_Sensor_5.Text = "〇"
        ' 
        ' L_Sensor_4
        ' 
        L_Sensor_4.AutoSize = True
        L_Sensor_4.Location = New Point(140, 37)
        L_Sensor_4.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_4.Name = "L_Sensor_4"
        L_Sensor_4.Size = New Size(19, 15)
        L_Sensor_4.TabIndex = 12
        L_Sensor_4.Text = "〇"
        ' 
        ' L_Sensor_3
        ' 
        L_Sensor_3.AutoSize = True
        L_Sensor_3.Location = New Point(108, 37)
        L_Sensor_3.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_3.Name = "L_Sensor_3"
        L_Sensor_3.Size = New Size(19, 15)
        L_Sensor_3.TabIndex = 11
        L_Sensor_3.Text = "〇"
        ' 
        ' L_Sensor_2
        ' 
        L_Sensor_2.AutoSize = True
        L_Sensor_2.Location = New Point(76, 37)
        L_Sensor_2.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_2.Name = "L_Sensor_2"
        L_Sensor_2.Size = New Size(19, 15)
        L_Sensor_2.TabIndex = 10
        L_Sensor_2.Text = "〇"
        ' 
        ' L_Sensor_1
        ' 
        L_Sensor_1.AutoSize = True
        L_Sensor_1.Location = New Point(43, 37)
        L_Sensor_1.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_1.Name = "L_Sensor_1"
        L_Sensor_1.Size = New Size(19, 15)
        L_Sensor_1.TabIndex = 9
        L_Sensor_1.Text = "〇"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(237, 22)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(26, 15)
        Label9.TabIndex = 8
        Label9.Text = "ch7"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(204, 22)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(26, 15)
        Label8.TabIndex = 7
        Label8.Text = "ch6"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(172, 22)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(26, 15)
        Label7.TabIndex = 6
        Label7.Text = "ch5"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(140, 22)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(26, 15)
        Label6.TabIndex = 5
        Label6.Text = "ch4"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(108, 22)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(26, 15)
        Label5.TabIndex = 4
        Label5.Text = "ch3"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(76, 22)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(26, 15)
        Label4.TabIndex = 3
        Label4.Text = "ch2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(43, 22)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(26, 15)
        Label3.TabIndex = 2
        Label3.Text = "ch1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(11, 22)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(26, 15)
        Label2.TabIndex = 1
        Label2.Text = "ch0"
        ' 
        ' L_Sensor_0
        ' 
        L_Sensor_0.AutoSize = True
        L_Sensor_0.Location = New Point(11, 37)
        L_Sensor_0.Margin = New Padding(2, 0, 2, 0)
        L_Sensor_0.Name = "L_Sensor_0"
        L_Sensor_0.Size = New Size(19, 15)
        L_Sensor_0.TabIndex = 0
        L_Sensor_0.Text = "〇"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(L_PWM_PCT_R)
        GroupBox2.Controls.Add(L_PWM_PCT_L)
        GroupBox2.Controls.Add(L_PWM_R)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(L_PWM_L)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Location = New Point(812, 90)
        GroupBox2.Margin = New Padding(2)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(2)
        GroupBox2.Size = New Size(92, 100)
        GroupBox2.TabIndex = 3
        GroupBox2.TabStop = False
        GroupBox2.Text = "PWM"
        ' 
        ' L_PWM_PCT_R
        ' 
        L_PWM_PCT_R.Location = New Point(50, 71)
        L_PWM_PCT_R.Margin = New Padding(2, 0, 2, 0)
        L_PWM_PCT_R.Name = "L_PWM_PCT_R"
        L_PWM_PCT_R.Size = New Size(34, 15)
        L_PWM_PCT_R.TabIndex = 8
        L_PWM_PCT_R.Text = "000.0"
        L_PWM_PCT_R.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_PWM_PCT_L
        ' 
        L_PWM_PCT_L.Location = New Point(11, 71)
        L_PWM_PCT_L.Margin = New Padding(2, 0, 2, 0)
        L_PWM_PCT_L.Name = "L_PWM_PCT_L"
        L_PWM_PCT_L.Size = New Size(34, 15)
        L_PWM_PCT_L.TabIndex = 7
        L_PWM_PCT_L.Text = "000.0"
        L_PWM_PCT_L.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_PWM_R
        ' 
        L_PWM_R.AutoSize = True
        L_PWM_R.Location = New Point(50, 46)
        L_PWM_R.Margin = New Padding(2, 0, 2, 0)
        L_PWM_R.Name = "L_PWM_R"
        L_PWM_R.Size = New Size(19, 15)
        L_PWM_R.TabIndex = 5
        L_PWM_R.Text = "〇"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(44, 25)
        Label11.Margin = New Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(35, 15)
        Label11.TabIndex = 4
        Label11.Text = "Right"
        ' 
        ' L_PWM_L
        ' 
        L_PWM_L.AutoSize = True
        L_PWM_L.Location = New Point(11, 46)
        L_PWM_L.Margin = New Padding(2, 0, 2, 0)
        L_PWM_L.Name = "L_PWM_L"
        L_PWM_L.Size = New Size(19, 15)
        L_PWM_L.TabIndex = 3
        L_PWM_L.Text = "〇"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(11, 25)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(27, 15)
        Label1.TabIndex = 2
        Label1.Text = "Left"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(L_Status_Angle)
        GroupBox3.Controls.Add(L_Status_Y)
        GroupBox3.Controls.Add(L_Status_X)
        GroupBox3.Controls.Add(Label10)
        GroupBox3.Controls.Add(Label12)
        GroupBox3.Controls.Add(Label14)
        GroupBox3.Location = New Point(914, 90)
        GroupBox3.Margin = New Padding(2)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(2)
        GroupBox3.Size = New Size(172, 100)
        GroupBox3.TabIndex = 4
        GroupBox3.TabStop = False
        GroupBox3.Text = "Status"
        ' 
        ' L_Status_Angle
        ' 
        L_Status_Angle.Location = New Point(111, 71)
        L_Status_Angle.Margin = New Padding(2, 0, 2, 0)
        L_Status_Angle.Name = "L_Status_Angle"
        L_Status_Angle.Size = New Size(34, 15)
        L_Status_Angle.TabIndex = 8
        L_Status_Angle.Text = "000.0"
        L_Status_Angle.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_Status_Y
        ' 
        L_Status_Y.Location = New Point(59, 71)
        L_Status_Y.Margin = New Padding(2, 0, 2, 0)
        L_Status_Y.Name = "L_Status_Y"
        L_Status_Y.Size = New Size(34, 15)
        L_Status_Y.TabIndex = 7
        L_Status_Y.Text = "000.0"
        L_Status_Y.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_Status_X
        ' 
        L_Status_X.Location = New Point(11, 71)
        L_Status_X.Margin = New Padding(2, 0, 2, 0)
        L_Status_X.Name = "L_Status_X"
        L_Status_X.Size = New Size(34, 15)
        L_Status_X.TabIndex = 6
        L_Status_X.Text = "000.0"
        L_Status_X.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(111, 25)
        Label10.Margin = New Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(38, 15)
        Label10.TabIndex = 5
        Label10.Text = "Angle"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(59, 25)
        Label12.Margin = New Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(14, 15)
        Label12.TabIndex = 4
        Label12.Text = "Y"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(11, 25)
        Label14.Margin = New Padding(2, 0, 2, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(14, 15)
        Label14.TabIndex = 2
        Label14.Text = "X"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Label18)
        GroupBox4.Controls.Add(T_Rotate)
        GroupBox4.Controls.Add(Label17)
        GroupBox4.Controls.Add(T_Spd)
        GroupBox4.Controls.Add(B_STOP)
        GroupBox4.Controls.Add(B_GO)
        GroupBox4.Controls.Add(B_AUTO)
        GroupBox4.Location = New Point(813, 271)
        GroupBox4.Margin = New Padding(2)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(2)
        GroupBox4.Size = New Size(273, 80)
        GroupBox4.TabIndex = 5
        GroupBox4.TabStop = False
        GroupBox4.Text = "Control"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(234, 50)
        Label18.Margin = New Padding(2, 0, 2, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(37, 15)
        Label18.TabIndex = 13
        Label18.Text = "deg/s"
        Label18.Visible = False
        ' 
        ' T_Rotate
        ' 
        T_Rotate.Location = New Point(183, 47)
        T_Rotate.Margin = New Padding(2)
        T_Rotate.Name = "T_Rotate"
        T_Rotate.Size = New Size(51, 23)
        T_Rotate.TabIndex = 12
        T_Rotate.Text = "90.0"
        T_Rotate.TextAlign = HorizontalAlignment.Right
        T_Rotate.Visible = False
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(234, 26)
        Label17.Margin = New Padding(2, 0, 2, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(33, 15)
        Label17.TabIndex = 11
        Label17.Text = "pix/s"
        Label17.Visible = False
        ' 
        ' T_Spd
        ' 
        T_Spd.Location = New Point(183, 23)
        T_Spd.Margin = New Padding(2)
        T_Spd.Name = "T_Spd"
        T_Spd.Size = New Size(51, 23)
        T_Spd.TabIndex = 10
        T_Spd.Text = "100.0"
        T_Spd.TextAlign = HorizontalAlignment.Right
        T_Spd.Visible = False
        ' 
        ' B_STOP
        ' 
        B_STOP.Location = New Point(94, 47)
        B_STOP.Margin = New Padding(2)
        B_STOP.Name = "B_STOP"
        B_STOP.Size = New Size(78, 20)
        B_STOP.TabIndex = 2
        B_STOP.Text = "Stop"
        B_STOP.UseVisualStyleBackColor = True
        ' 
        ' B_GO
        ' 
        B_GO.Location = New Point(11, 47)
        B_GO.Margin = New Padding(2)
        B_GO.Name = "B_GO"
        B_GO.Size = New Size(78, 20)
        B_GO.TabIndex = 1
        B_GO.Text = "Go"
        B_GO.UseVisualStyleBackColor = True
        ' 
        ' B_AUTO
        ' 
        B_AUTO.Location = New Point(11, 23)
        B_AUTO.Margin = New Padding(2)
        B_AUTO.Name = "B_AUTO"
        B_AUTO.Size = New Size(161, 20)
        B_AUTO.TabIndex = 0
        B_AUTO.Text = "Auto"
        B_AUTO.UseVisualStyleBackColor = True
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(B_POS_DEFAULT)
        GroupBox5.Controls.Add(B_POS_SET)
        GroupBox5.Controls.Add(B_Angle_7)
        GroupBox5.Controls.Add(B_Angle_6)
        GroupBox5.Controls.Add(B_Angle_5)
        GroupBox5.Controls.Add(B_Angle_4)
        GroupBox5.Controls.Add(B_Angle_3)
        GroupBox5.Controls.Add(B_Angle_2)
        GroupBox5.Controls.Add(B_Angle_1)
        GroupBox5.Controls.Add(B_Angle_0)
        GroupBox5.Controls.Add(T_Pos_Angle)
        GroupBox5.Controls.Add(T_Pos_Y)
        GroupBox5.Controls.Add(T_Pos_X)
        GroupBox5.Controls.Add(Label13)
        GroupBox5.Controls.Add(Label15)
        GroupBox5.Controls.Add(Label16)
        GroupBox5.Location = New Point(813, 355)
        GroupBox5.Margin = New Padding(2)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Padding = New Padding(2)
        GroupBox5.Size = New Size(273, 137)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Posioning"
        ' 
        ' B_POS_DEFAULT
        ' 
        B_POS_DEFAULT.Location = New Point(179, 63)
        B_POS_DEFAULT.Margin = New Padding(2)
        B_POS_DEFAULT.Name = "B_POS_DEFAULT"
        B_POS_DEFAULT.Size = New Size(78, 20)
        B_POS_DEFAULT.TabIndex = 23
        B_POS_DEFAULT.Text = "Default"
        B_POS_DEFAULT.UseVisualStyleBackColor = True
        ' 
        ' B_POS_SET
        ' 
        B_POS_SET.Location = New Point(179, 40)
        B_POS_SET.Margin = New Padding(2)
        B_POS_SET.Name = "B_POS_SET"
        B_POS_SET.Size = New Size(78, 20)
        B_POS_SET.TabIndex = 22
        B_POS_SET.Text = "Set"
        B_POS_SET.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_7
        ' 
        B_Angle_7.Location = New Point(173, 111)
        B_Angle_7.Margin = New Padding(2)
        B_Angle_7.Name = "B_Angle_7"
        B_Angle_7.Size = New Size(50, 20)
        B_Angle_7.TabIndex = 19
        B_Angle_7.Text = "315°"
        B_Angle_7.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_6
        ' 
        B_Angle_6.Location = New Point(118, 111)
        B_Angle_6.Margin = New Padding(2)
        B_Angle_6.Name = "B_Angle_6"
        B_Angle_6.Size = New Size(50, 20)
        B_Angle_6.TabIndex = 18
        B_Angle_6.Text = "270°"
        B_Angle_6.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_5
        ' 
        B_Angle_5.Location = New Point(65, 111)
        B_Angle_5.Margin = New Padding(2)
        B_Angle_5.Name = "B_Angle_5"
        B_Angle_5.Size = New Size(50, 20)
        B_Angle_5.TabIndex = 17
        B_Angle_5.Text = "225°"
        B_Angle_5.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_4
        ' 
        B_Angle_4.Location = New Point(11, 111)
        B_Angle_4.Margin = New Padding(2)
        B_Angle_4.Name = "B_Angle_4"
        B_Angle_4.Size = New Size(50, 20)
        B_Angle_4.TabIndex = 16
        B_Angle_4.Text = "180°"
        B_Angle_4.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_3
        ' 
        B_Angle_3.Location = New Point(172, 87)
        B_Angle_3.Margin = New Padding(2)
        B_Angle_3.Name = "B_Angle_3"
        B_Angle_3.Size = New Size(50, 20)
        B_Angle_3.TabIndex = 15
        B_Angle_3.Text = "135°"
        B_Angle_3.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_2
        ' 
        B_Angle_2.Location = New Point(118, 87)
        B_Angle_2.Margin = New Padding(2)
        B_Angle_2.Name = "B_Angle_2"
        B_Angle_2.Size = New Size(50, 20)
        B_Angle_2.TabIndex = 14
        B_Angle_2.Text = "90°"
        B_Angle_2.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_1
        ' 
        B_Angle_1.Location = New Point(64, 87)
        B_Angle_1.Margin = New Padding(2)
        B_Angle_1.Name = "B_Angle_1"
        B_Angle_1.Size = New Size(50, 20)
        B_Angle_1.TabIndex = 13
        B_Angle_1.Text = "45°"
        B_Angle_1.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_0
        ' 
        B_Angle_0.Location = New Point(11, 87)
        B_Angle_0.Margin = New Padding(2)
        B_Angle_0.Name = "B_Angle_0"
        B_Angle_0.Size = New Size(50, 20)
        B_Angle_0.TabIndex = 12
        B_Angle_0.Text = "0°"
        B_Angle_0.UseVisualStyleBackColor = True
        ' 
        ' T_Pos_Angle
        ' 
        T_Pos_Angle.Location = New Point(122, 41)
        T_Pos_Angle.Margin = New Padding(2)
        T_Pos_Angle.Name = "T_Pos_Angle"
        T_Pos_Angle.Size = New Size(51, 23)
        T_Pos_Angle.TabIndex = 11
        T_Pos_Angle.Text = "000.0"
        T_Pos_Angle.TextAlign = HorizontalAlignment.Right
        ' 
        ' T_Pos_Y
        ' 
        T_Pos_Y.Location = New Point(65, 41)
        T_Pos_Y.Margin = New Padding(2)
        T_Pos_Y.Name = "T_Pos_Y"
        T_Pos_Y.Size = New Size(51, 23)
        T_Pos_Y.TabIndex = 10
        T_Pos_Y.Text = "000.0"
        T_Pos_Y.TextAlign = HorizontalAlignment.Right
        ' 
        ' T_Pos_X
        ' 
        T_Pos_X.Location = New Point(11, 41)
        T_Pos_X.Margin = New Padding(2)
        T_Pos_X.Name = "T_Pos_X"
        T_Pos_X.Size = New Size(51, 23)
        T_Pos_X.TabIndex = 9
        T_Pos_X.Text = "000.0"
        T_Pos_X.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(122, 24)
        Label13.Margin = New Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(38, 15)
        Label13.TabIndex = 8
        Label13.Text = "Angle"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(65, 24)
        Label15.Margin = New Padding(2, 0, 2, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(14, 15)
        Label15.TabIndex = 7
        Label15.Text = "Y"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(11, 24)
        Label16.Margin = New Padding(2, 0, 2, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(14, 15)
        Label16.TabIndex = 6
        Label16.Text = "X"
        ' 
        ' TimerCyclic
        ' 
        TimerCyclic.Interval = 50
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, OnlineToolStripMenuItem_0})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(4, 1, 0, 1)
        MenuStrip1.Size = New Size(1094, 24)
        MenuStrip1.TabIndex = 7
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SelectCourseToolStripMenuItem, SelectCarToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 22)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' SelectCourseToolStripMenuItem
        ' 
        SelectCourseToolStripMenuItem.Name = "SelectCourseToolStripMenuItem"
        SelectCourseToolStripMenuItem.Size = New Size(144, 22)
        SelectCourseToolStripMenuItem.Text = "Select Course"
        ' 
        ' SelectCarToolStripMenuItem
        ' 
        SelectCarToolStripMenuItem.Name = "SelectCarToolStripMenuItem"
        SelectCarToolStripMenuItem.Size = New Size(144, 22)
        SelectCarToolStripMenuItem.Text = "Select Car"
        ' 
        ' OnlineToolStripMenuItem_0
        ' 
        OnlineToolStripMenuItem_0.DropDownItems.AddRange(New ToolStripItem() {OnlineToolStripMenuItem_1})
        OnlineToolStripMenuItem_0.Name = "OnlineToolStripMenuItem_0"
        OnlineToolStripMenuItem_0.Size = New Size(66, 22)
        OnlineToolStripMenuItem_0.Text = "≠Offline"
        ' 
        ' OnlineToolStripMenuItem_1
        ' 
        OnlineToolStripMenuItem_1.Name = "OnlineToolStripMenuItem_1"
        OnlineToolStripMenuItem_1.Size = New Size(121, 22)
        OnlineToolStripMenuItem_1.Text = "＝Online"
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(L_Score)
        GroupBox6.Controls.Add(Label22)
        GroupBox6.Controls.Add(Label19)
        GroupBox6.Controls.Add(L_Score_Speed)
        GroupBox6.Controls.Add(L_Score_Rotate)
        GroupBox6.Location = New Point(812, 194)
        GroupBox6.Margin = New Padding(2)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Padding = New Padding(2)
        GroupBox6.Size = New Size(273, 73)
        GroupBox6.TabIndex = 8
        GroupBox6.TabStop = False
        GroupBox6.Text = "Score"
        ' 
        ' L_Score
        ' 
        L_Score.Font = New Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        L_Score.Location = New Point(167, 18)
        L_Score.Margin = New Padding(2, 0, 2, 0)
        L_Score.Name = "L_Score"
        L_Score.Size = New Size(95, 45)
        L_Score.TabIndex = 15
        L_Score.Text = "000.0"
        L_Score.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(49, 45)
        Label22.Margin = New Padding(2, 0, 2, 0)
        Label22.Name = "Label22"
        Label22.Size = New Size(37, 15)
        Label22.TabIndex = 14
        Label22.Text = "deg/s"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(49, 18)
        Label19.Margin = New Padding(2, 0, 2, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(33, 15)
        Label19.TabIndex = 12
        Label19.Text = "pix/s"
        ' 
        ' L_Score_Speed
        ' 
        L_Score_Speed.Location = New Point(11, 18)
        L_Score_Speed.Margin = New Padding(2, 0, 2, 0)
        L_Score_Speed.Name = "L_Score_Speed"
        L_Score_Speed.Size = New Size(34, 15)
        L_Score_Speed.TabIndex = 7
        L_Score_Speed.Text = "000.0"
        L_Score_Speed.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_Score_Rotate
        ' 
        L_Score_Rotate.Location = New Point(11, 45)
        L_Score_Rotate.Margin = New Padding(2, 0, 2, 0)
        L_Score_Rotate.Name = "L_Score_Rotate"
        L_Score_Rotate.Size = New Size(34, 15)
        L_Score_Rotate.TabIndex = 6
        L_Score_Rotate.Text = "000.0"
        L_Score_Rotate.TextAlign = ContentAlignment.TopRight
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1094, 641)
        Controls.Add(MenuStrip1)
        Controls.Add(GroupBox6)
        Controls.Add(GroupBox5)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(PB_Car)
        Controls.Add(PB_Course)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(2)
        Name = "FormMain"
        Text = "LineTraceSim"
        CType(PB_Course, ComponentModel.ISupportInitialize).EndInit()
        CType(PB_Car, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        GroupBox6.ResumeLayout(False)
        GroupBox6.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PB_Course As PictureBox
    Friend WithEvents PB_Car As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents L_Sensor_0 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents L_Sensor_7 As Label
    Friend WithEvents L_Sensor_6 As Label
    Friend WithEvents L_Sensor_5 As Label
    Friend WithEvents L_Sensor_4 As Label
    Friend WithEvents L_Sensor_3 As Label
    Friend WithEvents L_Sensor_2 As Label
    Friend WithEvents L_Sensor_1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents L_PWM_R As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents L_PWM_L As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents L_Status_Angle As Label
    Friend WithEvents L_Status_Y As Label
    Friend WithEvents L_Status_X As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents B_AUTO As Button
    Friend WithEvents B_STOP As Button
    Friend WithEvents B_GO As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents T_Pos_X As TextBox
    Friend WithEvents T_Pos_Angle As TextBox
    Friend WithEvents T_Pos_Y As TextBox
    Friend WithEvents B_Angle_1 As Button
    Friend WithEvents B_Angle_0 As Button
    Friend WithEvents B_Angle_7 As Button
    Friend WithEvents B_Angle_6 As Button
    Friend WithEvents B_Angle_5 As Button
    Friend WithEvents B_Angle_4 As Button
    Friend WithEvents B_Angle_3 As Button
    Friend WithEvents B_Angle_2 As Button
    Friend WithEvents TimerCyclic As Timer
    Friend WithEvents B_POS_SET As Button
    Friend WithEvents B_POS_DEFAULT As Button
    Friend WithEvents T_Spd As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents T_Rotate As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectCourseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectCarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnlineToolStripMenuItem_0 As ToolStripMenuItem
    Friend WithEvents OnlineToolStripMenuItem_1 As ToolStripMenuItem
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents L_Score_Speed As Label
    Friend WithEvents L_Score_Rotate As Label
    Friend WithEvents L_Score As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents L_PWM_PCT_R As Label
    Friend WithEvents L_PWM_PCT_L As Label

End Class
