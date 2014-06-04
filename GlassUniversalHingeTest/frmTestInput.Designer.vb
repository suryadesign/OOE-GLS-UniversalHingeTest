<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestInput))
        Me.txtNumCycles = New System.Windows.Forms.NumericUpDown()
        Me.fbdDataFilePath = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFixtureErrorCyles = New System.Windows.Forms.CheckBox()
        Me.txtFixtureErrorCyles = New System.Windows.Forms.NumericUpDown()
        Me.chkEndOnCycles = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoBidirectional = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdoUnidirectionalCW = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRelPos = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdoDistance = New System.Windows.Forms.RadioButton()
        Me.rdoDisplacement = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtTorqueLimit = New System.Windows.Forms.TextBox()
        Me.chkLimitTorque = New System.Windows.Forms.CheckBox()
        Me.chkZeroPosition = New System.Windows.Forms.CheckBox()
        Me.numDwellTime = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOperator = New System.Windows.Forms.TextBox()
        Me.txtDevID = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoDAQNever = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdoDAQProgInt = New System.Windows.Forms.RadioButton()
        Me.rdoDAQEvery1000 = New System.Windows.Forms.RadioButton()
        Me.rdoDAQEvery100 = New System.Windows.Forms.RadioButton()
        Me.rdoDAQEvery10 = New System.Windows.Forms.RadioButton()
        Me.rdoDAQEvery1 = New System.Windows.Forms.RadioButton()
        Me.cmdShowFolderDialog = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataFilePath = New System.Windows.Forms.TextBox()
        Me.rdoUnidirectionalCCW = New System.Windows.Forms.RadioButton()
        Me.rdoCrystalHinge = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdoTempleHinge = New System.Windows.Forms.RadioButton()
        CType(Me.txtNumCycles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtFixtureErrorCyles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.numDwellTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNumCycles
        '
        Me.txtNumCycles.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtNumCycles.Location = New System.Drawing.Point(168, 20)
        Me.txtNumCycles.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtNumCycles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNumCycles.Name = "txtNumCycles"
        Me.txtNumCycles.Size = New System.Drawing.Size(120, 20)
        Me.txtNumCycles.TabIndex = 1
        Me.txtNumCycles.ThousandsSeparator = True
        Me.txtNumCycles.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(296, 304)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(144, 24)
        Me.cmdStart.TabIndex = 5
        Me.cmdStart.Text = "&Start Test"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(448, 304)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(144, 24)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFixtureErrorCyles)
        Me.GroupBox1.Controls.Add(Me.txtFixtureErrorCyles)
        Me.GroupBox1.Controls.Add(Me.chkEndOnCycles)
        Me.GroupBox1.Controls.Add(Me.txtNumCycles)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 74)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test End Conditions"
        '
        'chkFixtureErrorCyles
        '
        Me.chkFixtureErrorCyles.AutoSize = True
        Me.chkFixtureErrorCyles.Location = New System.Drawing.Point(8, 48)
        Me.chkFixtureErrorCyles.Name = "chkFixtureErrorCyles"
        Me.chkFixtureErrorCyles.Size = New System.Drawing.Size(116, 17)
        Me.chkFixtureErrorCyles.TabIndex = 6
        Me.chkFixtureErrorCyles.Text = "Fixture Error Cycles"
        Me.chkFixtureErrorCyles.UseVisualStyleBackColor = True
        '
        'txtFixtureErrorCyles
        '
        Me.txtFixtureErrorCyles.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtFixtureErrorCyles.Location = New System.Drawing.Point(168, 44)
        Me.txtFixtureErrorCyles.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtFixtureErrorCyles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtFixtureErrorCyles.Name = "txtFixtureErrorCyles"
        Me.txtFixtureErrorCyles.Size = New System.Drawing.Size(120, 20)
        Me.txtFixtureErrorCyles.TabIndex = 7
        Me.txtFixtureErrorCyles.ThousandsSeparator = True
        Me.txtFixtureErrorCyles.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
        '
        'chkEndOnCycles
        '
        Me.chkEndOnCycles.AutoSize = True
        Me.chkEndOnCycles.Location = New System.Drawing.Point(8, 24)
        Me.chkEndOnCycles.Name = "chkEndOnCycles"
        Me.chkEndOnCycles.Size = New System.Drawing.Size(57, 17)
        Me.chkEndOnCycles.TabIndex = 0
        Me.chkEndOnCycles.Text = "Cycles"
        Me.chkEndOnCycles.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoUnidirectionalCCW)
        Me.GroupBox2.Controls.Add(Me.rdoBidirectional)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.rdoUnidirectionalCW)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtRelPos)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 136)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Travel End Condition"
        '
        'rdoBidirectional
        '
        Me.rdoBidirectional.AutoSize = True
        Me.rdoBidirectional.Location = New System.Drawing.Point(16, 112)
        Me.rdoBidirectional.Name = "rdoBidirectional"
        Me.rdoBidirectional.Size = New System.Drawing.Size(195, 17)
        Me.rdoBidirectional.TabIndex = 5
        Me.rdoBidirectional.TabStop = True
        Me.rdoBidirectional.Text = "Bidirectional (± from current position)"
        Me.rdoBidirectional.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Motion Mode"
        '
        'rdoUnidirectionalCW
        '
        Me.rdoUnidirectionalCW.AutoSize = True
        Me.rdoUnidirectionalCW.Location = New System.Drawing.Point(16, 64)
        Me.rdoUnidirectionalCW.Name = "rdoUnidirectionalCW"
        Me.rdoUnidirectionalCW.Size = New System.Drawing.Size(140, 17)
        Me.rdoUnidirectionalCW.TabIndex = 3
        Me.rdoUnidirectionalCW.TabStop = True
        Me.rdoUnidirectionalCW.Text = "Unidirectional Clockwise"
        Me.rdoUnidirectionalCW.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Relative Position [deg]"
        '
        'txtRelPos
        '
        Me.txtRelPos.Location = New System.Drawing.Point(136, 20)
        Me.txtRelPos.Name = "txtRelPos"
        Me.txtRelPos.Size = New System.Drawing.Size(64, 20)
        Me.txtRelPos.TabIndex = 1
        Me.txtRelPos.Text = "0.005"
        Me.ToolTip1.SetToolTip(Me.txtRelPos, "Clockwise: Positive angle" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Counterclockwise: Negative angle")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.rdoDistance)
        Me.GroupBox4.Controls.Add(Me.rdoDisplacement)
        Me.GroupBox4.Location = New System.Drawing.Point(296, 232)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 64)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Graph Options"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Display torque as function of angular..."
        '
        'rdoDistance
        '
        Me.rdoDistance.AutoSize = True
        Me.rdoDistance.Location = New System.Drawing.Point(168, 40)
        Me.rdoDistance.Name = "rdoDistance"
        Me.rdoDistance.Size = New System.Drawing.Size(67, 17)
        Me.rdoDistance.TabIndex = 1
        Me.rdoDistance.TabStop = True
        Me.rdoDistance.Text = "Distance"
        Me.rdoDistance.UseVisualStyleBackColor = True
        '
        'rdoDisplacement
        '
        Me.rdoDisplacement.AutoSize = True
        Me.rdoDisplacement.Location = New System.Drawing.Point(16, 40)
        Me.rdoDisplacement.Name = "rdoDisplacement"
        Me.rdoDisplacement.Size = New System.Drawing.Size(89, 17)
        Me.rdoDisplacement.TabIndex = 0
        Me.rdoDisplacement.TabStop = True
        Me.rdoDisplacement.Text = "Displacement"
        Me.rdoDisplacement.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdoTempleHinge)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.rdoCrystalHinge)
        Me.GroupBox5.Controls.Add(Me.txtTorqueLimit)
        Me.GroupBox5.Controls.Add(Me.chkLimitTorque)
        Me.GroupBox5.Controls.Add(Me.chkZeroPosition)
        Me.GroupBox5.Controls.Add(Me.numDwellTime)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtOperator)
        Me.GroupBox5.Controls.Add(Me.txtDevID)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(280, 184)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "General Test Info/Options"
        '
        'txtTorqueLimit
        '
        Me.txtTorqueLimit.Enabled = False
        Me.txtTorqueLimit.Location = New System.Drawing.Point(160, 92)
        Me.txtTorqueLimit.Name = "txtTorqueLimit"
        Me.txtTorqueLimit.Size = New System.Drawing.Size(64, 20)
        Me.txtTorqueLimit.TabIndex = 4
        Me.txtTorqueLimit.Text = "0.005"
        '
        'chkLimitTorque
        '
        Me.chkLimitTorque.AutoSize = True
        Me.chkLimitTorque.Enabled = False
        Me.chkLimitTorque.Location = New System.Drawing.Point(8, 96)
        Me.chkLimitTorque.Name = "chkLimitTorque"
        Me.chkLimitTorque.Size = New System.Drawing.Size(121, 17)
        Me.chkLimitTorque.TabIndex = 3
        Me.chkLimitTorque.Text = "Limit torque [kgf-cm]"
        Me.chkLimitTorque.UseVisualStyleBackColor = True
        '
        'chkZeroPosition
        '
        Me.chkZeroPosition.AutoSize = True
        Me.chkZeroPosition.Location = New System.Drawing.Point(8, 120)
        Me.chkZeroPosition.Name = "chkZeroPosition"
        Me.chkZeroPosition.Size = New System.Drawing.Size(140, 17)
        Me.chkZeroPosition.TabIndex = 5
        Me.chkZeroPosition.Text = "Zero position before test"
        Me.chkZeroPosition.UseVisualStyleBackColor = True
        '
        'numDwellTime
        '
        Me.numDwellTime.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numDwellTime.Location = New System.Drawing.Point(160, 68)
        Me.numDwellTime.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numDwellTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDwellTime.Name = "numDwellTime"
        Me.numDwellTime.Size = New System.Drawing.Size(104, 20)
        Me.numDwellTime.TabIndex = 2
        Me.numDwellTime.ThousandsSeparator = True
        Me.numDwellTime.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Dwell Time [msec]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Operator"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Device ID"
        '
        'txtOperator
        '
        Me.txtOperator.Location = New System.Drawing.Point(160, 44)
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(100, 20)
        Me.txtOperator.TabIndex = 1
        '
        'txtDevID
        '
        Me.txtDevID.Location = New System.Drawing.Point(160, 20)
        Me.txtDevID.Name = "txtDevID"
        Me.txtDevID.Size = New System.Drawing.Size(100, 20)
        Me.txtDevID.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoDAQNever)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.rdoDAQProgInt)
        Me.GroupBox3.Controls.Add(Me.rdoDAQEvery1000)
        Me.GroupBox3.Controls.Add(Me.rdoDAQEvery100)
        Me.GroupBox3.Controls.Add(Me.rdoDAQEvery10)
        Me.GroupBox3.Controls.Add(Me.rdoDAQEvery1)
        Me.GroupBox3.Controls.Add(Me.cmdShowFolderDialog)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtDataFilePath)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 200)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 168)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Acquisition Options"
        '
        'rdoDAQNever
        '
        Me.rdoDAQNever.AutoSize = True
        Me.rdoDAQNever.Location = New System.Drawing.Point(16, 40)
        Me.rdoDAQNever.Name = "rdoDAQNever"
        Me.rdoDAQNever.Size = New System.Drawing.Size(54, 17)
        Me.rdoDAQNever.TabIndex = 0
        Me.rdoDAQNever.TabStop = True
        Me.rdoDAQNever.Text = "Never"
        Me.rdoDAQNever.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Record full torque data..."
        '
        'rdoDAQProgInt
        '
        Me.rdoDAQProgInt.AutoSize = True
        Me.rdoDAQProgInt.Location = New System.Drawing.Point(128, 88)
        Me.rdoDAQProgInt.Name = "rdoDAQProgInt"
        Me.rdoDAQProgInt.Size = New System.Drawing.Size(135, 17)
        Me.rdoDAQProgInt.TabIndex = 5
        Me.rdoDAQProgInt.TabStop = True
        Me.rdoDAQProgInt.Text = "On Progressive Interval"
        Me.rdoDAQProgInt.UseVisualStyleBackColor = True
        '
        'rdoDAQEvery1000
        '
        Me.rdoDAQEvery1000.AutoSize = True
        Me.rdoDAQEvery1000.Location = New System.Drawing.Point(128, 64)
        Me.rdoDAQEvery1000.Name = "rdoDAQEvery1000"
        Me.rdoDAQEvery1000.Size = New System.Drawing.Size(117, 17)
        Me.rdoDAQEvery1000.TabIndex = 4
        Me.rdoDAQEvery1000.TabStop = True
        Me.rdoDAQEvery1000.Text = "Every 1000th Cycle"
        Me.rdoDAQEvery1000.UseVisualStyleBackColor = True
        '
        'rdoDAQEvery100
        '
        Me.rdoDAQEvery100.AutoSize = True
        Me.rdoDAQEvery100.Location = New System.Drawing.Point(128, 40)
        Me.rdoDAQEvery100.Name = "rdoDAQEvery100"
        Me.rdoDAQEvery100.Size = New System.Drawing.Size(111, 17)
        Me.rdoDAQEvery100.TabIndex = 3
        Me.rdoDAQEvery100.TabStop = True
        Me.rdoDAQEvery100.Text = "Every 100th Cycle"
        Me.rdoDAQEvery100.UseVisualStyleBackColor = True
        '
        'rdoDAQEvery10
        '
        Me.rdoDAQEvery10.AutoSize = True
        Me.rdoDAQEvery10.Location = New System.Drawing.Point(16, 88)
        Me.rdoDAQEvery10.Name = "rdoDAQEvery10"
        Me.rdoDAQEvery10.Size = New System.Drawing.Size(105, 17)
        Me.rdoDAQEvery10.TabIndex = 2
        Me.rdoDAQEvery10.TabStop = True
        Me.rdoDAQEvery10.Text = "Every 10th Cycle"
        Me.rdoDAQEvery10.UseVisualStyleBackColor = True
        '
        'rdoDAQEvery1
        '
        Me.rdoDAQEvery1.AutoSize = True
        Me.rdoDAQEvery1.Location = New System.Drawing.Point(16, 64)
        Me.rdoDAQEvery1.Name = "rdoDAQEvery1"
        Me.rdoDAQEvery1.Size = New System.Drawing.Size(81, 17)
        Me.rdoDAQEvery1.TabIndex = 1
        Me.rdoDAQEvery1.TabStop = True
        Me.rdoDAQEvery1.Text = "Every Cycle"
        Me.rdoDAQEvery1.UseVisualStyleBackColor = True
        '
        'cmdShowFolderDialog
        '
        Me.cmdShowFolderDialog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdShowFolderDialog.Image = CType(resources.GetObject("cmdShowFolderDialog.Image"), System.Drawing.Image)
        Me.cmdShowFolderDialog.Location = New System.Drawing.Point(240, 136)
        Me.cmdShowFolderDialog.Name = "cmdShowFolderDialog"
        Me.cmdShowFolderDialog.Size = New System.Drawing.Size(24, 24)
        Me.cmdShowFolderDialog.TabIndex = 7
        Me.cmdShowFolderDialog.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Data File Path"
        '
        'txtDataFilePath
        '
        Me.txtDataFilePath.Location = New System.Drawing.Point(8, 136)
        Me.txtDataFilePath.Name = "txtDataFilePath"
        Me.txtDataFilePath.Size = New System.Drawing.Size(232, 20)
        Me.txtDataFilePath.TabIndex = 6
        '
        'rdoUnidirectionalCCW
        '
        Me.rdoUnidirectionalCCW.AutoSize = True
        Me.rdoUnidirectionalCCW.Location = New System.Drawing.Point(16, 88)
        Me.rdoUnidirectionalCCW.Name = "rdoUnidirectionalCCW"
        Me.rdoUnidirectionalCCW.Size = New System.Drawing.Size(176, 17)
        Me.rdoUnidirectionalCCW.TabIndex = 6
        Me.rdoUnidirectionalCCW.TabStop = True
        Me.rdoUnidirectionalCCW.Text = "Unidirectional Counterclockwise"
        Me.rdoUnidirectionalCCW.UseVisualStyleBackColor = True
        '
        'rdoCrystalHinge
        '
        Me.rdoCrystalHinge.AutoSize = True
        Me.rdoCrystalHinge.Location = New System.Drawing.Point(16, 160)
        Me.rdoCrystalHinge.Name = "rdoCrystalHinge"
        Me.rdoCrystalHinge.Size = New System.Drawing.Size(87, 17)
        Me.rdoCrystalHinge.TabIndex = 50
        Me.rdoCrystalHinge.TabStop = True
        Me.rdoCrystalHinge.Text = "Crystal Hinge"
        Me.rdoCrystalHinge.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Device Type"
        '
        'rdoTempleHinge
        '
        Me.rdoTempleHinge.AutoSize = True
        Me.rdoTempleHinge.Location = New System.Drawing.Point(128, 160)
        Me.rdoTempleHinge.Name = "rdoTempleHinge"
        Me.rdoTempleHinge.Size = New System.Drawing.Size(91, 17)
        Me.rdoTempleHinge.TabIndex = 52
        Me.rdoTempleHinge.TabStop = True
        Me.rdoTempleHinge.Text = "Temple Hinge"
        Me.rdoTempleHinge.UseVisualStyleBackColor = True
        '
        'frmTestInput
        '
        Me.AcceptButton = Me.cmdStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(599, 399)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTestInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Test Information..."
        CType(Me.txtNumCycles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtFixtureErrorCyles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.numDwellTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNumCycles As System.Windows.Forms.NumericUpDown
    Friend WithEvents fbdDataFilePath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEndOnCycles As System.Windows.Forms.CheckBox
    Friend WithEvents chkFixtureErrorCyles As System.Windows.Forms.CheckBox
    Friend WithEvents txtFixtureErrorCyles As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rdoDistance As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDisplacement As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTorqueLimit As System.Windows.Forms.TextBox
    Friend WithEvents chkLimitTorque As System.Windows.Forms.CheckBox
    Friend WithEvents chkZeroPosition As System.Windows.Forms.CheckBox
    Friend WithEvents numDwellTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents txtDevID As System.Windows.Forms.TextBox
    Friend WithEvents rdoBidirectional As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdoUnidirectionalCW As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRelPos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoDAQNever As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdoDAQProgInt As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery1000 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery100 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery10 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShowFolderDialog As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataFilePath As System.Windows.Forms.TextBox
    Friend WithEvents rdoUnidirectionalCCW As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTempleHinge As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdoCrystalHinge As System.Windows.Forms.RadioButton
End Class
