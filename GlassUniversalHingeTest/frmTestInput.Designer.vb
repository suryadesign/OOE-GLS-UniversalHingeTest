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
        Me.txtTotalFailLimit = New System.Windows.Forms.NumericUpDown()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFixtureErrorCyles = New System.Windows.Forms.CheckBox()
        Me.txtFixtureErrorCyles = New System.Windows.Forms.NumericUpDown()
        Me.chkEndOnConsecButtonFailures = New System.Windows.Forms.CheckBox()
        Me.chkEndOnTotalButtonFailures = New System.Windows.Forms.CheckBox()
        Me.txtConsecFailLimit = New System.Windows.Forms.NumericUpDown()
        Me.chkEndOnCycles = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtZTargetForce = New System.Windows.Forms.TextBox()
        Me.txtTargetForce = New System.Windows.Forms.TextBox()
        Me.txtRelPos = New System.Windows.Forms.TextBox()
        Me.rdoTravelEndButtonClose = New System.Windows.Forms.RadioButton()
        Me.rdoTravelEndZTargetForce = New System.Windows.Forms.RadioButton()
        Me.rdoTravelEndTargetForce = New System.Windows.Forms.RadioButton()
        Me.rdoTravelEndRelPos = New System.Windows.Forms.RadioButton()
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdoDistance = New System.Windows.Forms.RadioButton()
        Me.rdoDisplacement = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtForceLimit = New System.Windows.Forms.TextBox()
        Me.chkLimitForce = New System.Windows.Forms.CheckBox()
        Me.chkZeroPosition = New System.Windows.Forms.CheckBox()
        Me.numDwellTime = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkIgnoreButtonStatus = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOperator = New System.Windows.Forms.TextBox()
        Me.txtDevID = New System.Windows.Forms.TextBox()
        CType(Me.txtNumCycles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFailLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtFixtureErrorCyles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsecFailLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.numDwellTime, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtTotalFailLimit
        '
        Me.txtTotalFailLimit.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtTotalFailLimit.Location = New System.Drawing.Point(168, 44)
        Me.txtTotalFailLimit.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtTotalFailLimit.Name = "txtTotalFailLimit"
        Me.txtTotalFailLimit.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalFailLimit.TabIndex = 3
        Me.txtTotalFailLimit.ThousandsSeparator = True
        Me.ToolTip1.SetToolTip(Me.txtTotalFailLimit, "Note that open and closed button failures are tracked separately.")
        Me.txtTotalFailLimit.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(296, 336)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(144, 24)
        Me.cmdStart.TabIndex = 5
        Me.cmdStart.Text = "&Start Test"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(448, 336)
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
        Me.GroupBox1.Controls.Add(Me.chkEndOnConsecButtonFailures)
        Me.GroupBox1.Controls.Add(Me.chkEndOnTotalButtonFailures)
        Me.GroupBox1.Controls.Add(Me.txtConsecFailLimit)
        Me.GroupBox1.Controls.Add(Me.txtTotalFailLimit)
        Me.GroupBox1.Controls.Add(Me.chkEndOnCycles)
        Me.GroupBox1.Controls.Add(Me.txtNumCycles)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 120)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test End Conditions"
        '
        'chkFixtureErrorCyles
        '
        Me.chkFixtureErrorCyles.AutoSize = True
        Me.chkFixtureErrorCyles.Location = New System.Drawing.Point(8, 96)
        Me.chkFixtureErrorCyles.Name = "chkFixtureErrorCyles"
        Me.chkFixtureErrorCyles.Size = New System.Drawing.Size(116, 17)
        Me.chkFixtureErrorCyles.TabIndex = 6
        Me.chkFixtureErrorCyles.Text = "Fixture Error Cycles"
        Me.chkFixtureErrorCyles.UseVisualStyleBackColor = True
        '
        'txtFixtureErrorCyles
        '
        Me.txtFixtureErrorCyles.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtFixtureErrorCyles.Location = New System.Drawing.Point(168, 92)
        Me.txtFixtureErrorCyles.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtFixtureErrorCyles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtFixtureErrorCyles.Name = "txtFixtureErrorCyles"
        Me.txtFixtureErrorCyles.Size = New System.Drawing.Size(120, 20)
        Me.txtFixtureErrorCyles.TabIndex = 7
        Me.txtFixtureErrorCyles.ThousandsSeparator = True
        Me.txtFixtureErrorCyles.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
        '
        'chkEndOnConsecButtonFailures
        '
        Me.chkEndOnConsecButtonFailures.AutoSize = True
        Me.chkEndOnConsecButtonFailures.Location = New System.Drawing.Point(8, 72)
        Me.chkEndOnConsecButtonFailures.Name = "chkEndOnConsecButtonFailures"
        Me.chkEndOnConsecButtonFailures.Size = New System.Drawing.Size(158, 17)
        Me.chkEndOnConsecButtonFailures.TabIndex = 4
        Me.chkEndOnConsecButtonFailures.Text = "Consecutive Button Failures"
        Me.chkEndOnConsecButtonFailures.UseVisualStyleBackColor = True
        '
        'chkEndOnTotalButtonFailures
        '
        Me.chkEndOnTotalButtonFailures.AutoSize = True
        Me.chkEndOnTotalButtonFailures.Location = New System.Drawing.Point(8, 48)
        Me.chkEndOnTotalButtonFailures.Name = "chkEndOnTotalButtonFailures"
        Me.chkEndOnTotalButtonFailures.Size = New System.Drawing.Size(123, 17)
        Me.chkEndOnTotalButtonFailures.TabIndex = 2
        Me.chkEndOnTotalButtonFailures.Text = "Total Button Failures"
        Me.chkEndOnTotalButtonFailures.UseVisualStyleBackColor = True
        '
        'txtConsecFailLimit
        '
        Me.txtConsecFailLimit.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtConsecFailLimit.Location = New System.Drawing.Point(168, 68)
        Me.txtConsecFailLimit.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.txtConsecFailLimit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtConsecFailLimit.Name = "txtConsecFailLimit"
        Me.txtConsecFailLimit.Size = New System.Drawing.Size(120, 20)
        Me.txtConsecFailLimit.TabIndex = 5
        Me.txtConsecFailLimit.ThousandsSeparator = True
        Me.ToolTip1.SetToolTip(Me.txtConsecFailLimit, "Note that open and closed button failures are tracked separately.")
        Me.txtConsecFailLimit.Value = New Decimal(New Integer() {9999999, 0, 0, 0})
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
        Me.GroupBox2.Controls.Add(Me.txtZTargetForce)
        Me.GroupBox2.Controls.Add(Me.txtTargetForce)
        Me.GroupBox2.Controls.Add(Me.txtRelPos)
        Me.GroupBox2.Controls.Add(Me.rdoTravelEndButtonClose)
        Me.GroupBox2.Controls.Add(Me.rdoTravelEndZTargetForce)
        Me.GroupBox2.Controls.Add(Me.rdoTravelEndTargetForce)
        Me.GroupBox2.Controls.Add(Me.rdoTravelEndRelPos)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 120)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Down Travel End Condition"
        '
        'txtZTargetForce
        '
        Me.txtZTargetForce.Location = New System.Drawing.Point(144, 68)
        Me.txtZTargetForce.Name = "txtZTargetForce"
        Me.txtZTargetForce.Size = New System.Drawing.Size(64, 20)
        Me.txtZTargetForce.TabIndex = 5
        Me.txtZTargetForce.Text = "0.005"
        '
        'txtTargetForce
        '
        Me.txtTargetForce.Location = New System.Drawing.Point(144, 44)
        Me.txtTargetForce.Name = "txtTargetForce"
        Me.txtTargetForce.Size = New System.Drawing.Size(64, 20)
        Me.txtTargetForce.TabIndex = 3
        Me.txtTargetForce.Text = "0.005"
        '
        'txtRelPos
        '
        Me.txtRelPos.Location = New System.Drawing.Point(144, 20)
        Me.txtRelPos.Name = "txtRelPos"
        Me.txtRelPos.Size = New System.Drawing.Size(64, 20)
        Me.txtRelPos.TabIndex = 1
        Me.txtRelPos.Text = "0.005"
        '
        'rdoTravelEndButtonClose
        '
        Me.rdoTravelEndButtonClose.AutoSize = True
        Me.rdoTravelEndButtonClose.Location = New System.Drawing.Point(16, 96)
        Me.rdoTravelEndButtonClose.Name = "rdoTravelEndButtonClose"
        Me.rdoTravelEndButtonClose.Size = New System.Drawing.Size(94, 17)
        Me.rdoTravelEndButtonClose.TabIndex = 6
        Me.rdoTravelEndButtonClose.Text = "Button Closure"
        Me.rdoTravelEndButtonClose.UseVisualStyleBackColor = True
        '
        'rdoTravelEndZTargetForce
        '
        Me.rdoTravelEndZTargetForce.AutoSize = True
        Me.rdoTravelEndZTargetForce.Location = New System.Drawing.Point(16, 72)
        Me.rdoTravelEndZTargetForce.Name = "rdoTravelEndZTargetForce"
        Me.rdoTravelEndZTargetForce.Size = New System.Drawing.Size(120, 17)
        Me.rdoTravelEndZTargetForce.TabIndex = 4
        Me.rdoTravelEndZTargetForce.Text = "Z (Target Force) [gf]"
        Me.rdoTravelEndZTargetForce.UseVisualStyleBackColor = True
        '
        'rdoTravelEndTargetForce
        '
        Me.rdoTravelEndTargetForce.AutoSize = True
        Me.rdoTravelEndTargetForce.Location = New System.Drawing.Point(16, 48)
        Me.rdoTravelEndTargetForce.Name = "rdoTravelEndTargetForce"
        Me.rdoTravelEndTargetForce.Size = New System.Drawing.Size(104, 17)
        Me.rdoTravelEndTargetForce.TabIndex = 2
        Me.rdoTravelEndTargetForce.Text = "Target Force [gf]"
        Me.rdoTravelEndTargetForce.UseVisualStyleBackColor = True
        '
        'rdoTravelEndRelPos
        '
        Me.rdoTravelEndRelPos.AutoSize = True
        Me.rdoTravelEndRelPos.Location = New System.Drawing.Point(16, 24)
        Me.rdoTravelEndRelPos.Name = "rdoTravelEndRelPos"
        Me.rdoTravelEndRelPos.Size = New System.Drawing.Size(129, 17)
        Me.rdoTravelEndRelPos.TabIndex = 0
        Me.rdoTravelEndRelPos.Text = "Relative Position [mm]"
        Me.rdoTravelEndRelPos.UseVisualStyleBackColor = True
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
        Me.GroupBox3.Location = New System.Drawing.Point(8, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 176)
        Me.GroupBox3.TabIndex = 1
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
        Me.Label3.Size = New System.Drawing.Size(185, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Record full force/displacement data..."
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
        Me.cmdShowFolderDialog.Location = New System.Drawing.Point(240, 144)
        Me.cmdShowFolderDialog.Name = "cmdShowFolderDialog"
        Me.cmdShowFolderDialog.Size = New System.Drawing.Size(24, 24)
        Me.cmdShowFolderDialog.TabIndex = 7
        Me.cmdShowFolderDialog.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Data File Path"
        '
        'txtDataFilePath
        '
        Me.txtDataFilePath.Location = New System.Drawing.Point(8, 144)
        Me.txtDataFilePath.Name = "txtDataFilePath"
        Me.txtDataFilePath.Size = New System.Drawing.Size(232, 20)
        Me.txtDataFilePath.TabIndex = 6
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.rdoDistance)
        Me.GroupBox4.Controls.Add(Me.rdoDisplacement)
        Me.GroupBox4.Location = New System.Drawing.Point(296, 264)
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
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Display force as function of..."
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
        Me.GroupBox5.Controls.Add(Me.txtForceLimit)
        Me.GroupBox5.Controls.Add(Me.chkLimitForce)
        Me.GroupBox5.Controls.Add(Me.chkZeroPosition)
        Me.GroupBox5.Controls.Add(Me.numDwellTime)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.chkIgnoreButtonStatus)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtOperator)
        Me.GroupBox5.Controls.Add(Me.txtDevID)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(280, 168)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "General Test Info/Options"
        '
        'txtForceLimit
        '
        Me.txtForceLimit.Location = New System.Drawing.Point(160, 92)
        Me.txtForceLimit.Name = "txtForceLimit"
        Me.txtForceLimit.Size = New System.Drawing.Size(64, 20)
        Me.txtForceLimit.TabIndex = 4
        Me.txtForceLimit.Text = "0.005"
        '
        'chkLimitForce
        '
        Me.chkLimitForce.AutoSize = True
        Me.chkLimitForce.Location = New System.Drawing.Point(8, 96)
        Me.chkLimitForce.Name = "chkLimitForce"
        Me.chkLimitForce.Size = New System.Drawing.Size(92, 17)
        Me.chkLimitForce.TabIndex = 3
        Me.chkLimitForce.Text = "Limit force [gf]"
        Me.chkLimitForce.UseVisualStyleBackColor = True
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
        'chkIgnoreButtonStatus
        '
        Me.chkIgnoreButtonStatus.AutoSize = True
        Me.chkIgnoreButtonStatus.Location = New System.Drawing.Point(8, 144)
        Me.chkIgnoreButtonStatus.Name = "chkIgnoreButtonStatus"
        Me.chkIgnoreButtonStatus.Size = New System.Drawing.Size(120, 17)
        Me.chkIgnoreButtonStatus.TabIndex = 6
        Me.chkIgnoreButtonStatus.Text = "Ignore button status"
        Me.chkIgnoreButtonStatus.UseVisualStyleBackColor = True
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
        'frmTestInput
        '
        Me.AcceptButton = Me.cmdStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(599, 366)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
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
        CType(Me.txtTotalFailLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtFixtureErrorCyles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsecFailLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.numDwellTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNumCycles As System.Windows.Forms.NumericUpDown
    Friend WithEvents fbdDataFilePath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtTotalFailLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEndOnConsecButtonFailures As System.Windows.Forms.CheckBox
    Friend WithEvents chkEndOnTotalButtonFailures As System.Windows.Forms.CheckBox
    Friend WithEvents txtConsecFailLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkEndOnCycles As System.Windows.Forms.CheckBox
    Friend WithEvents chkFixtureErrorCyles As System.Windows.Forms.CheckBox
    Friend WithEvents txtFixtureErrorCyles As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtZTargetForce As System.Windows.Forms.TextBox
    Friend WithEvents txtTargetForce As System.Windows.Forms.TextBox
    Friend WithEvents txtRelPos As System.Windows.Forms.TextBox
    Friend WithEvents rdoTravelEndButtonClose As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTravelEndZTargetForce As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTravelEndTargetForce As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTravelEndRelPos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoDAQProgInt As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery1000 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery100 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery10 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQEvery1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShowFolderDialog As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rdoDistance As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDisplacement As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDAQNever As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtForceLimit As System.Windows.Forms.TextBox
    Friend WithEvents chkLimitForce As System.Windows.Forms.CheckBox
    Friend WithEvents chkZeroPosition As System.Windows.Forms.CheckBox
    Friend WithEvents numDwellTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkIgnoreButtonStatus As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents txtDevID As System.Windows.Forms.TextBox
End Class
