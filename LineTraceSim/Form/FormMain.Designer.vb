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
        CType(PB_Course, ComponentModel.ISupportInitialize).BeginInit()
        CType(PB_Car, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox5.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PB_Course
        ' 
        PB_Course.Image = CType(resources.GetObject("PB_Course.Image"), Image)
        PB_Course.InitialImage = CType(resources.GetObject("PB_Course.InitialImage"), Image)
        PB_Course.Location = New Point(12, 42)
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
        PB_Car.Location = New Point(360, 132)
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
        GroupBox1.Location = New Point(826, 42)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(390, 101)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Sensor"
        ' 
        ' L_Sensor_7
        ' 
        L_Sensor_7.AutoSize = True
        L_Sensor_7.Location = New Point(338, 62)
        L_Sensor_7.Name = "L_Sensor_7"
        L_Sensor_7.Size = New Size(30, 25)
        L_Sensor_7.TabIndex = 15
        L_Sensor_7.Text = "〇"
        ' 
        ' L_Sensor_6
        ' 
        L_Sensor_6.AutoSize = True
        L_Sensor_6.Location = New Point(292, 62)
        L_Sensor_6.Name = "L_Sensor_6"
        L_Sensor_6.Size = New Size(30, 25)
        L_Sensor_6.TabIndex = 14
        L_Sensor_6.Text = "〇"
        ' 
        ' L_Sensor_5
        ' 
        L_Sensor_5.AutoSize = True
        L_Sensor_5.Location = New Point(246, 62)
        L_Sensor_5.Name = "L_Sensor_5"
        L_Sensor_5.Size = New Size(30, 25)
        L_Sensor_5.TabIndex = 13
        L_Sensor_5.Text = "〇"
        ' 
        ' L_Sensor_4
        ' 
        L_Sensor_4.AutoSize = True
        L_Sensor_4.Location = New Point(200, 62)
        L_Sensor_4.Name = "L_Sensor_4"
        L_Sensor_4.Size = New Size(30, 25)
        L_Sensor_4.TabIndex = 12
        L_Sensor_4.Text = "〇"
        ' 
        ' L_Sensor_3
        ' 
        L_Sensor_3.AutoSize = True
        L_Sensor_3.Location = New Point(154, 62)
        L_Sensor_3.Name = "L_Sensor_3"
        L_Sensor_3.Size = New Size(30, 25)
        L_Sensor_3.TabIndex = 11
        L_Sensor_3.Text = "〇"
        ' 
        ' L_Sensor_2
        ' 
        L_Sensor_2.AutoSize = True
        L_Sensor_2.Location = New Point(108, 62)
        L_Sensor_2.Name = "L_Sensor_2"
        L_Sensor_2.Size = New Size(30, 25)
        L_Sensor_2.TabIndex = 10
        L_Sensor_2.Text = "〇"
        ' 
        ' L_Sensor_1
        ' 
        L_Sensor_1.AutoSize = True
        L_Sensor_1.Location = New Point(62, 62)
        L_Sensor_1.Name = "L_Sensor_1"
        L_Sensor_1.Size = New Size(30, 25)
        L_Sensor_1.TabIndex = 9
        L_Sensor_1.Text = "〇"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(338, 37)
        Label9.Name = "Label9"
        Label9.Size = New Size(40, 25)
        Label9.TabIndex = 8
        Label9.Text = "ch7"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(292, 37)
        Label8.Name = "Label8"
        Label8.Size = New Size(40, 25)
        Label8.TabIndex = 7
        Label8.Text = "ch6"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(246, 37)
        Label7.Name = "Label7"
        Label7.Size = New Size(40, 25)
        Label7.TabIndex = 6
        Label7.Text = "ch5"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(200, 37)
        Label6.Name = "Label6"
        Label6.Size = New Size(40, 25)
        Label6.TabIndex = 5
        Label6.Text = "ch4"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(154, 37)
        Label5.Name = "Label5"
        Label5.Size = New Size(40, 25)
        Label5.TabIndex = 4
        Label5.Text = "ch3"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(108, 37)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 25)
        Label4.TabIndex = 3
        Label4.Text = "ch2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(62, 37)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 25)
        Label3.TabIndex = 2
        Label3.Text = "ch1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 37)
        Label2.Name = "Label2"
        Label2.Size = New Size(40, 25)
        Label2.TabIndex = 1
        Label2.Text = "ch0"
        ' 
        ' L_Sensor_0
        ' 
        L_Sensor_0.AutoSize = True
        L_Sensor_0.Location = New Point(16, 62)
        L_Sensor_0.Name = "L_Sensor_0"
        L_Sensor_0.Size = New Size(30, 25)
        L_Sensor_0.TabIndex = 0
        L_Sensor_0.Text = "〇"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(L_PWM_R)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(L_PWM_L)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Location = New Point(826, 149)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(131, 121)
        GroupBox2.TabIndex = 3
        GroupBox2.TabStop = False
        GroupBox2.Text = "PWM"
        ' 
        ' L_PWM_R
        ' 
        L_PWM_R.AutoSize = True
        L_PWM_R.Location = New Point(72, 76)
        L_PWM_R.Name = "L_PWM_R"
        L_PWM_R.Size = New Size(30, 25)
        L_PWM_R.TabIndex = 5
        L_PWM_R.Text = "〇"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(63, 42)
        Label11.Name = "Label11"
        Label11.Size = New Size(54, 25)
        Label11.TabIndex = 4
        Label11.Text = "Right"
        ' 
        ' L_PWM_L
        ' 
        L_PWM_L.AutoSize = True
        L_PWM_L.Location = New Point(16, 76)
        L_PWM_L.Name = "L_PWM_L"
        L_PWM_L.Size = New Size(30, 25)
        L_PWM_L.TabIndex = 3
        L_PWM_L.Text = "〇"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 25)
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
        GroupBox3.Location = New Point(971, 149)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(245, 121)
        GroupBox3.TabIndex = 4
        GroupBox3.TabStop = False
        GroupBox3.Text = "Status"
        ' 
        ' L_Status_Angle
        ' 
        L_Status_Angle.AutoSize = True
        L_Status_Angle.Location = New Point(158, 76)
        L_Status_Angle.Name = "L_Status_Angle"
        L_Status_Angle.Size = New Size(56, 25)
        L_Status_Angle.TabIndex = 8
        L_Status_Angle.Text = "000.0"
        L_Status_Angle.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_Status_Y
        ' 
        L_Status_Y.AutoSize = True
        L_Status_Y.Location = New Point(84, 76)
        L_Status_Y.Name = "L_Status_Y"
        L_Status_Y.Size = New Size(56, 25)
        L_Status_Y.TabIndex = 7
        L_Status_Y.Text = "000.0"
        L_Status_Y.TextAlign = ContentAlignment.TopRight
        ' 
        ' L_Status_X
        ' 
        L_Status_X.AutoSize = True
        L_Status_X.Location = New Point(16, 76)
        L_Status_X.Name = "L_Status_X"
        L_Status_X.Size = New Size(56, 25)
        L_Status_X.TabIndex = 6
        L_Status_X.Text = "000.0"
        L_Status_X.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(158, 42)
        Label10.Name = "Label10"
        Label10.Size = New Size(58, 25)
        Label10.TabIndex = 5
        Label10.Text = "Angle"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(84, 42)
        Label12.Name = "Label12"
        Label12.Size = New Size(22, 25)
        Label12.TabIndex = 4
        Label12.Text = "Y"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(16, 42)
        Label14.Name = "Label14"
        Label14.Size = New Size(23, 25)
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
        GroupBox4.Location = New Point(826, 276)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(390, 134)
        GroupBox4.TabIndex = 5
        GroupBox4.TabStop = False
        GroupBox4.Text = "Control"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(334, 84)
        Label18.Name = "Label18"
        Label18.Size = New Size(58, 25)
        Label18.TabIndex = 13
        Label18.Text = "deg/s"
        ' 
        ' T_Rotate
        ' 
        T_Rotate.Location = New Point(261, 79)
        T_Rotate.Name = "T_Rotate"
        T_Rotate.Size = New Size(71, 31)
        T_Rotate.TabIndex = 12
        T_Rotate.Text = "90.0"
        T_Rotate.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(334, 44)
        Label17.Name = "Label17"
        Label17.Size = New Size(50, 25)
        Label17.TabIndex = 11
        Label17.Text = "pix/s"
        ' 
        ' T_Spd
        ' 
        T_Spd.Location = New Point(261, 39)
        T_Spd.Name = "T_Spd"
        T_Spd.Size = New Size(71, 31)
        T_Spd.TabIndex = 10
        T_Spd.Text = "100.0"
        T_Spd.TextAlign = HorizontalAlignment.Right
        ' 
        ' B_STOP
        ' 
        B_STOP.Location = New Point(134, 79)
        B_STOP.Name = "B_STOP"
        B_STOP.Size = New Size(112, 34)
        B_STOP.TabIndex = 2
        B_STOP.Text = "Stop"
        B_STOP.UseVisualStyleBackColor = True
        ' 
        ' B_GO
        ' 
        B_GO.Location = New Point(16, 79)
        B_GO.Name = "B_GO"
        B_GO.Size = New Size(112, 34)
        B_GO.TabIndex = 1
        B_GO.Text = "Go"
        B_GO.UseVisualStyleBackColor = True
        ' 
        ' B_AUTO
        ' 
        B_AUTO.Location = New Point(16, 39)
        B_AUTO.Name = "B_AUTO"
        B_AUTO.Size = New Size(230, 34)
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
        GroupBox5.Location = New Point(826, 416)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(390, 228)
        GroupBox5.TabIndex = 6
        GroupBox5.TabStop = False
        GroupBox5.Text = "Posioning"
        ' 
        ' B_POS_DEFAULT
        ' 
        B_POS_DEFAULT.Location = New Point(256, 105)
        B_POS_DEFAULT.Name = "B_POS_DEFAULT"
        B_POS_DEFAULT.Size = New Size(112, 34)
        B_POS_DEFAULT.TabIndex = 23
        B_POS_DEFAULT.Text = "Default"
        B_POS_DEFAULT.UseVisualStyleBackColor = True
        ' 
        ' B_POS_SET
        ' 
        B_POS_SET.Location = New Point(256, 66)
        B_POS_SET.Name = "B_POS_SET"
        B_POS_SET.Size = New Size(112, 34)
        B_POS_SET.TabIndex = 22
        B_POS_SET.Text = "Set"
        B_POS_SET.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_7
        ' 
        B_Angle_7.Location = New Point(247, 185)
        B_Angle_7.Name = "B_Angle_7"
        B_Angle_7.Size = New Size(71, 34)
        B_Angle_7.TabIndex = 19
        B_Angle_7.Text = "315°"
        B_Angle_7.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_6
        ' 
        B_Angle_6.Location = New Point(168, 185)
        B_Angle_6.Name = "B_Angle_6"
        B_Angle_6.Size = New Size(71, 34)
        B_Angle_6.TabIndex = 18
        B_Angle_6.Text = "270°"
        B_Angle_6.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_5
        ' 
        B_Angle_5.Location = New Point(93, 185)
        B_Angle_5.Name = "B_Angle_5"
        B_Angle_5.Size = New Size(71, 34)
        B_Angle_5.TabIndex = 17
        B_Angle_5.Text = "225°"
        B_Angle_5.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_4
        ' 
        B_Angle_4.Location = New Point(16, 185)
        B_Angle_4.Name = "B_Angle_4"
        B_Angle_4.Size = New Size(71, 34)
        B_Angle_4.TabIndex = 16
        B_Angle_4.Text = "180°"
        B_Angle_4.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_3
        ' 
        B_Angle_3.Location = New Point(245, 145)
        B_Angle_3.Name = "B_Angle_3"
        B_Angle_3.Size = New Size(71, 34)
        B_Angle_3.TabIndex = 15
        B_Angle_3.Text = "135°"
        B_Angle_3.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_2
        ' 
        B_Angle_2.Location = New Point(168, 145)
        B_Angle_2.Name = "B_Angle_2"
        B_Angle_2.Size = New Size(71, 34)
        B_Angle_2.TabIndex = 14
        B_Angle_2.Text = "90°"
        B_Angle_2.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_1
        ' 
        B_Angle_1.Location = New Point(91, 145)
        B_Angle_1.Name = "B_Angle_1"
        B_Angle_1.Size = New Size(71, 34)
        B_Angle_1.TabIndex = 13
        B_Angle_1.Text = "45°"
        B_Angle_1.UseVisualStyleBackColor = True
        ' 
        ' B_Angle_0
        ' 
        B_Angle_0.Location = New Point(16, 145)
        B_Angle_0.Name = "B_Angle_0"
        B_Angle_0.Size = New Size(71, 34)
        B_Angle_0.TabIndex = 12
        B_Angle_0.Text = "0°"
        B_Angle_0.UseVisualStyleBackColor = True
        ' 
        ' T_Pos_Angle
        ' 
        T_Pos_Angle.Location = New Point(175, 68)
        T_Pos_Angle.Name = "T_Pos_Angle"
        T_Pos_Angle.Size = New Size(71, 31)
        T_Pos_Angle.TabIndex = 11
        T_Pos_Angle.Text = "000.0"
        T_Pos_Angle.TextAlign = HorizontalAlignment.Right
        ' 
        ' T_Pos_Y
        ' 
        T_Pos_Y.Location = New Point(93, 68)
        T_Pos_Y.Name = "T_Pos_Y"
        T_Pos_Y.Size = New Size(71, 31)
        T_Pos_Y.TabIndex = 10
        T_Pos_Y.Text = "000.0"
        T_Pos_Y.TextAlign = HorizontalAlignment.Right
        ' 
        ' T_Pos_X
        ' 
        T_Pos_X.Location = New Point(16, 68)
        T_Pos_X.Name = "T_Pos_X"
        T_Pos_X.Size = New Size(71, 31)
        T_Pos_X.TabIndex = 9
        T_Pos_X.Text = "000.0"
        T_Pos_X.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(175, 40)
        Label13.Name = "Label13"
        Label13.Size = New Size(58, 25)
        Label13.TabIndex = 8
        Label13.Text = "Angle"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(93, 40)
        Label15.Name = "Label15"
        Label15.Size = New Size(22, 25)
        Label15.TabIndex = 7
        Label15.Text = "Y"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(16, 40)
        Label16.Name = "Label16"
        Label16.Size = New Size(23, 25)
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
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1228, 33)
        MenuStrip1.TabIndex = 7
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SelectCourseToolStripMenuItem, SelectCarToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(54, 29)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' SelectCourseToolStripMenuItem
        ' 
        SelectCourseToolStripMenuItem.Name = "SelectCourseToolStripMenuItem"
        SelectCourseToolStripMenuItem.Size = New Size(220, 34)
        SelectCourseToolStripMenuItem.Text = "Select Course"
        ' 
        ' SelectCarToolStripMenuItem
        ' 
        SelectCarToolStripMenuItem.Name = "SelectCarToolStripMenuItem"
        SelectCarToolStripMenuItem.Size = New Size(220, 34)
        SelectCarToolStripMenuItem.Text = "Select Car"
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1228, 656)
        Controls.Add(GroupBox5)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(PB_Car)
        Controls.Add(PB_Course)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
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

End Class
