<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.tctlMain = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblConsecOpenFailures = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTotalOpenFailures = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblConsecClosureFailures = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalClosureFailures = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblErrorCycles = New System.Windows.Forms.Label()
        Me.lblTargetCycles = New System.Windows.Forms.Label()
        Me.lblSuccessfulCycles = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCurrentCycle = New System.Windows.Forms.Label()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdPauseResume = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.tabConfig = New System.Windows.Forms.TabPage()
        Me.cmdSendConfig = New System.Windows.Forms.Button()
        Me.pgSettings = New System.Windows.Forms.PropertyGrid()
        Me.stpMain = New System.Windows.Forms.StatusStrip()
        Me.stpStatusStrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stpMainStrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pbrForce = New System.Windows.Forms.ProgressBar()
        Me.lblForce = New System.Windows.Forms.Label()
        Me.lblXPos = New System.Windows.Forms.Label()
        Me.cmdZeroXpos = New System.Windows.Forms.Button()
        Me.cmdEnableXAx = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ledXAxEnabled = New NationalInstruments.UI.WindowsForms.Led()
        Me.ledButtonStatus = New NationalInstruments.UI.WindowsForms.Led()
        Me.timUpdateUI = New System.Timers.Timer()
        Me.gbxManualControl = New System.Windows.Forms.GroupBox()
        Me.txtXPos = New System.Windows.Forms.TextBox()
        Me.cmdMoveRel = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdMoveAbs = New System.Windows.Forms.Button()
        Me.cmdMoveX1000Down = New System.Windows.Forms.Button()
        Me.cmdMoveX100Down = New System.Windows.Forms.Button()
        Me.cmdMoveX10Down = New System.Windows.Forms.Button()
        Me.cmdHomeX = New System.Windows.Forms.Button()
        Me.cmdMoveX10Up = New System.Windows.Forms.Button()
        Me.cmdMoveX100Up = New System.Windows.Forms.Button()
        Me.cmdMoveX1000Up = New System.Windows.Forms.Button()
        Me.chtForceVsDisp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tctlMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabConfig.SuspendLayout()
        Me.stpMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ledXAxEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledButtonStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timUpdateUI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxManualControl.SuspendLayout()
        CType(Me.chtForceVsDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tctlMain
        '
        Me.tctlMain.Controls.Add(Me.tabMain)
        Me.tctlMain.Controls.Add(Me.tabConfig)
        Me.tctlMain.Location = New System.Drawing.Point(8, 8)
        Me.tctlMain.Name = "tctlMain"
        Me.tctlMain.SelectedIndex = 0
        Me.tctlMain.Size = New System.Drawing.Size(320, 272)
        Me.tctlMain.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.Label13)
        Me.tabMain.Controls.Add(Me.lblConsecOpenFailures)
        Me.tabMain.Controls.Add(Me.Label17)
        Me.tabMain.Controls.Add(Me.lblTotalOpenFailures)
        Me.tabMain.Controls.Add(Me.Label8)
        Me.tabMain.Controls.Add(Me.lblConsecClosureFailures)
        Me.tabMain.Controls.Add(Me.Label1)
        Me.tabMain.Controls.Add(Me.lblTotalClosureFailures)
        Me.tabMain.Controls.Add(Me.lblStartTime)
        Me.tabMain.Controls.Add(Me.Label21)
        Me.tabMain.Controls.Add(Me.Label20)
        Me.tabMain.Controls.Add(Me.Label19)
        Me.tabMain.Controls.Add(Me.lblErrorCycles)
        Me.tabMain.Controls.Add(Me.lblTargetCycles)
        Me.tabMain.Controls.Add(Me.lblSuccessfulCycles)
        Me.tabMain.Controls.Add(Me.Label15)
        Me.tabMain.Controls.Add(Me.Label14)
        Me.tabMain.Controls.Add(Me.lblCurrentCycle)
        Me.tabMain.Controls.Add(Me.cmdStop)
        Me.tabMain.Controls.Add(Me.cmdPauseResume)
        Me.tabMain.Controls.Add(Me.cmdStart)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(312, 246)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(0, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(184, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Consecutive Switch Open Failures:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConsecOpenFailures
        '
        Me.lblConsecOpenFailures.AutoSize = True
        Me.lblConsecOpenFailures.Location = New System.Drawing.Point(184, 168)
        Me.lblConsecOpenFailures.Name = "lblConsecOpenFailures"
        Me.lblConsecOpenFailures.Size = New System.Drawing.Size(13, 13)
        Me.lblConsecOpenFailures.TabIndex = 19
        Me.lblConsecOpenFailures.Text = "0"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(176, 16)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Total Switch Open Failures:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalOpenFailures
        '
        Me.lblTotalOpenFailures.AutoSize = True
        Me.lblTotalOpenFailures.Location = New System.Drawing.Point(184, 152)
        Me.lblTotalOpenFailures.Name = "lblTotalOpenFailures"
        Me.lblTotalOpenFailures.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalOpenFailures.TabIndex = 17
        Me.lblTotalOpenFailures.Text = "0"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(-16, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 16)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Consecutive Switch Closure Failures:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConsecClosureFailures
        '
        Me.lblConsecClosureFailures.AutoSize = True
        Me.lblConsecClosureFailures.Location = New System.Drawing.Point(184, 136)
        Me.lblConsecClosureFailures.Name = "lblConsecClosureFailures"
        Me.lblConsecClosureFailures.Size = New System.Drawing.Size(13, 13)
        Me.lblConsecClosureFailures.TabIndex = 15
        Me.lblConsecClosureFailures.Text = "0"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Total Switch Closure Failures:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalClosureFailures
        '
        Me.lblTotalClosureFailures.AutoSize = True
        Me.lblTotalClosureFailures.Location = New System.Drawing.Point(184, 120)
        Me.lblTotalClosureFailures.Name = "lblTotalClosureFailures"
        Me.lblTotalClosureFailures.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalClosureFailures.TabIndex = 13
        Me.lblTotalClosureFailures.Text = "0"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(184, 184)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(0, 13)
        Me.lblStartTime.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(80, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 16)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Successful Cycles:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(80, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Fixture Failures:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(80, 184)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 16)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Start Time:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblErrorCycles
        '
        Me.lblErrorCycles.AutoSize = True
        Me.lblErrorCycles.Location = New System.Drawing.Point(184, 104)
        Me.lblErrorCycles.Name = "lblErrorCycles"
        Me.lblErrorCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblErrorCycles.TabIndex = 8
        Me.lblErrorCycles.Text = "0"
        '
        'lblTargetCycles
        '
        Me.lblTargetCycles.AutoSize = True
        Me.lblTargetCycles.Location = New System.Drawing.Point(184, 72)
        Me.lblTargetCycles.Name = "lblTargetCycles"
        Me.lblTargetCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblTargetCycles.TabIndex = 7
        Me.lblTargetCycles.Text = "0"
        '
        'lblSuccessfulCycles
        '
        Me.lblSuccessfulCycles.AutoSize = True
        Me.lblSuccessfulCycles.Location = New System.Drawing.Point(184, 88)
        Me.lblSuccessfulCycles.Name = "lblSuccessfulCycles"
        Me.lblSuccessfulCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblSuccessfulCycles.TabIndex = 6
        Me.lblSuccessfulCycles.Text = "0"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(88, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 16)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Target Cycles:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Current Cycle"
        '
        'lblCurrentCycle
        '
        Me.lblCurrentCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentCycle.Location = New System.Drawing.Point(8, 24)
        Me.lblCurrentCycle.Name = "lblCurrentCycle"
        Me.lblCurrentCycle.Size = New System.Drawing.Size(208, 40)
        Me.lblCurrentCycle.TabIndex = 3
        Me.lblCurrentCycle.Text = "0"
        '
        'cmdStop
        '
        Me.cmdStop.Enabled = False
        Me.cmdStop.Location = New System.Drawing.Point(224, 208)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(72, 24)
        Me.cmdStop.TabIndex = 2
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdPauseResume
        '
        Me.cmdPauseResume.Enabled = False
        Me.cmdPauseResume.Location = New System.Drawing.Point(120, 208)
        Me.cmdPauseResume.Name = "cmdPauseResume"
        Me.cmdPauseResume.Size = New System.Drawing.Size(72, 24)
        Me.cmdPauseResume.TabIndex = 1
        Me.cmdPauseResume.Text = "Pause"
        Me.cmdPauseResume.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(16, 208)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(72, 24)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'tabConfig
        '
        Me.tabConfig.Controls.Add(Me.cmdSendConfig)
        Me.tabConfig.Controls.Add(Me.pgSettings)
        Me.tabConfig.Location = New System.Drawing.Point(4, 22)
        Me.tabConfig.Name = "tabConfig"
        Me.tabConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfig.Size = New System.Drawing.Size(312, 246)
        Me.tabConfig.TabIndex = 1
        Me.tabConfig.Text = "Config"
        Me.tabConfig.UseVisualStyleBackColor = True
        '
        'cmdSendConfig
        '
        Me.cmdSendConfig.Location = New System.Drawing.Point(224, 8)
        Me.cmdSendConfig.Name = "cmdSendConfig"
        Me.cmdSendConfig.Size = New System.Drawing.Size(80, 24)
        Me.cmdSendConfig.TabIndex = 1
        Me.cmdSendConfig.Text = "Send Config"
        Me.cmdSendConfig.UseVisualStyleBackColor = True
        '
        'pgSettings
        '
        Me.pgSettings.HelpVisible = False
        Me.pgSettings.Location = New System.Drawing.Point(8, 8)
        Me.pgSettings.Name = "pgSettings"
        Me.pgSettings.Size = New System.Drawing.Size(208, 192)
        Me.pgSettings.TabIndex = 0
        Me.pgSettings.ToolbarVisible = False
        '
        'stpMain
        '
        Me.stpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stpStatusStrip})
        Me.stpMain.Location = New System.Drawing.Point(0, 423)
        Me.stpMain.Name = "stpMain"
        Me.stpMain.Size = New System.Drawing.Size(983, 22)
        Me.stpMain.TabIndex = 1
        Me.stpMain.Text = "StatusStrip1"
        '
        'stpStatusStrip
        '
        Me.stpStatusStrip.Name = "stpStatusStrip"
        Me.stpStatusStrip.Size = New System.Drawing.Size(121, 17)
        Me.stpStatusStrip.Text = "ToolStripStatusLabel1"
        '
        'stpMainStrip
        '
        Me.stpMainStrip.Name = "stpMainStrip"
        Me.stpMainStrip.Size = New System.Drawing.Size(121, 17)
        Me.stpMainStrip.Text = "ToolStripStatusLabel1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbrForce)
        Me.GroupBox1.Controls.Add(Me.lblForce)
        Me.GroupBox1.Controls.Add(Me.lblXPos)
        Me.GroupBox1.Controls.Add(Me.cmdZeroXpos)
        Me.GroupBox1.Controls.Add(Me.cmdEnableXAx)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ledXAxEnabled)
        Me.GroupBox1.Controls.Add(Me.ledButtonStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 288)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 128)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Status"
        '
        'pbrForce
        '
        Me.pbrForce.Location = New System.Drawing.Point(144, 96)
        Me.pbrForce.Name = "pbrForce"
        Me.pbrForce.Size = New System.Drawing.Size(168, 16)
        Me.pbrForce.TabIndex = 38
        '
        'lblForce
        '
        Me.lblForce.AutoSize = True
        Me.lblForce.Location = New System.Drawing.Point(96, 96)
        Me.lblForce.Name = "lblForce"
        Me.lblForce.Size = New System.Drawing.Size(46, 13)
        Me.lblForce.TabIndex = 37
        Me.lblForce.Text = "0000.00"
        '
        'lblXPos
        '
        Me.lblXPos.AutoSize = True
        Me.lblXPos.Location = New System.Drawing.Point(96, 72)
        Me.lblXPos.Name = "lblXPos"
        Me.lblXPos.Size = New System.Drawing.Size(46, 13)
        Me.lblXPos.TabIndex = 36
        Me.lblXPos.Text = "0000.00"
        '
        'cmdZeroXpos
        '
        Me.cmdZeroXpos.Location = New System.Drawing.Point(144, 68)
        Me.cmdZeroXpos.Name = "cmdZeroXpos"
        Me.cmdZeroXpos.Size = New System.Drawing.Size(56, 20)
        Me.cmdZeroXpos.TabIndex = 1
        Me.cmdZeroXpos.Text = "Zero"
        Me.cmdZeroXpos.UseVisualStyleBackColor = True
        '
        'cmdEnableXAx
        '
        Me.cmdEnableXAx.Location = New System.Drawing.Point(144, 20)
        Me.cmdEnableXAx.Name = "cmdEnableXAx"
        Me.cmdEnableXAx.Size = New System.Drawing.Size(56, 20)
        Me.cmdEnableXAx.TabIndex = 0
        Me.cmdEnableXAx.Text = "Enable"
        Me.cmdEnableXAx.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Force (gf):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Position (mm):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Button Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Drive Status"
        '
        'ledXAxEnabled
        '
        Me.ledXAxEnabled.CaptionPosition = NationalInstruments.UI.CaptionPosition.Right
        Me.ledXAxEnabled.LedStyle = NationalInstruments.UI.LedStyle.Square3D
        Me.ledXAxEnabled.Location = New System.Drawing.Point(96, 16)
        Me.ledXAxEnabled.Name = "ledXAxEnabled"
        Me.ledXAxEnabled.Size = New System.Drawing.Size(48, 29)
        Me.ledXAxEnabled.TabIndex = 11
        '
        'ledButtonStatus
        '
        Me.ledButtonStatus.CaptionPosition = NationalInstruments.UI.CaptionPosition.Right
        Me.ledButtonStatus.LedStyle = NationalInstruments.UI.LedStyle.Square3D
        Me.ledButtonStatus.Location = New System.Drawing.Point(96, 40)
        Me.ledButtonStatus.Name = "ledButtonStatus"
        Me.ledButtonStatus.Size = New System.Drawing.Size(48, 29)
        Me.ledButtonStatus.TabIndex = 12
        '
        'timUpdateUI
        '
        Me.timUpdateUI.Enabled = True
        Me.timUpdateUI.SynchronizingObject = Me
        '
        'gbxManualControl
        '
        Me.gbxManualControl.Controls.Add(Me.txtXPos)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveRel)
        Me.gbxManualControl.Controls.Add(Me.Label22)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveAbs)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX1000Down)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX100Down)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX10Down)
        Me.gbxManualControl.Controls.Add(Me.cmdHomeX)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX10Up)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX100Up)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveX1000Up)
        Me.gbxManualControl.Location = New System.Drawing.Point(856, 20)
        Me.gbxManualControl.Name = "gbxManualControl"
        Me.gbxManualControl.Size = New System.Drawing.Size(120, 396)
        Me.gbxManualControl.TabIndex = 2
        Me.gbxManualControl.TabStop = False
        Me.gbxManualControl.Text = "Manual Control"
        '
        'txtXPos
        '
        Me.txtXPos.Location = New System.Drawing.Point(16, 24)
        Me.txtXPos.Name = "txtXPos"
        Me.txtXPos.Size = New System.Drawing.Size(40, 20)
        Me.txtXPos.TabIndex = 0
        Me.txtXPos.Text = "10.0"
        '
        'cmdMoveRel
        '
        Me.cmdMoveRel.Location = New System.Drawing.Point(16, 72)
        Me.cmdMoveRel.Name = "cmdMoveRel"
        Me.cmdMoveRel.Size = New System.Drawing.Size(88, 24)
        Me.cmdMoveRel.TabIndex = 2
        Me.cmdMoveRel.Text = "Move Relative"
        Me.cmdMoveRel.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(56, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(23, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "mm"
        '
        'cmdMoveAbs
        '
        Me.cmdMoveAbs.Location = New System.Drawing.Point(16, 48)
        Me.cmdMoveAbs.Name = "cmdMoveAbs"
        Me.cmdMoveAbs.Size = New System.Drawing.Size(88, 24)
        Me.cmdMoveAbs.TabIndex = 1
        Me.cmdMoveAbs.Text = "Move Absolute"
        Me.cmdMoveAbs.UseVisualStyleBackColor = True
        '
        'cmdMoveX1000Down
        '
        Me.cmdMoveX1000Down.Image = CType(resources.GetObject("cmdMoveX1000Down.Image"), System.Drawing.Image)
        Me.cmdMoveX1000Down.Location = New System.Drawing.Point(32, 320)
        Me.cmdMoveX1000Down.Name = "cmdMoveX1000Down"
        Me.cmdMoveX1000Down.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX1000Down.TabIndex = 9
        Me.cmdMoveX1000Down.Text = "1"
        Me.cmdMoveX1000Down.UseVisualStyleBackColor = True
        '
        'cmdMoveX100Down
        '
        Me.cmdMoveX100Down.Image = CType(resources.GetObject("cmdMoveX100Down.Image"), System.Drawing.Image)
        Me.cmdMoveX100Down.Location = New System.Drawing.Point(32, 288)
        Me.cmdMoveX100Down.Name = "cmdMoveX100Down"
        Me.cmdMoveX100Down.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX100Down.TabIndex = 8
        Me.cmdMoveX100Down.Text = "0.1"
        Me.cmdMoveX100Down.UseVisualStyleBackColor = True
        '
        'cmdMoveX10Down
        '
        Me.cmdMoveX10Down.Image = CType(resources.GetObject("cmdMoveX10Down.Image"), System.Drawing.Image)
        Me.cmdMoveX10Down.Location = New System.Drawing.Point(32, 256)
        Me.cmdMoveX10Down.Name = "cmdMoveX10Down"
        Me.cmdMoveX10Down.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX10Down.TabIndex = 7
        Me.cmdMoveX10Down.Text = "0.01"
        Me.cmdMoveX10Down.UseVisualStyleBackColor = True
        '
        'cmdHomeX
        '
        Me.cmdHomeX.Image = Global.ForceFeedbackButtonTest.My.Resources.Resources.home
        Me.cmdHomeX.Location = New System.Drawing.Point(32, 200)
        Me.cmdHomeX.Name = "cmdHomeX"
        Me.cmdHomeX.Size = New System.Drawing.Size(56, 56)
        Me.cmdHomeX.TabIndex = 6
        Me.cmdHomeX.UseVisualStyleBackColor = True
        '
        'cmdMoveX10Up
        '
        Me.cmdMoveX10Up.Image = CType(resources.GetObject("cmdMoveX10Up.Image"), System.Drawing.Image)
        Me.cmdMoveX10Up.Location = New System.Drawing.Point(32, 168)
        Me.cmdMoveX10Up.Name = "cmdMoveX10Up"
        Me.cmdMoveX10Up.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX10Up.TabIndex = 5
        Me.cmdMoveX10Up.Text = "0.01"
        Me.cmdMoveX10Up.UseVisualStyleBackColor = True
        '
        'cmdMoveX100Up
        '
        Me.cmdMoveX100Up.Image = CType(resources.GetObject("cmdMoveX100Up.Image"), System.Drawing.Image)
        Me.cmdMoveX100Up.Location = New System.Drawing.Point(32, 136)
        Me.cmdMoveX100Up.Name = "cmdMoveX100Up"
        Me.cmdMoveX100Up.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX100Up.TabIndex = 4
        Me.cmdMoveX100Up.Text = "0.1"
        Me.cmdMoveX100Up.UseVisualStyleBackColor = True
        '
        'cmdMoveX1000Up
        '
        Me.cmdMoveX1000Up.Image = CType(resources.GetObject("cmdMoveX1000Up.Image"), System.Drawing.Image)
        Me.cmdMoveX1000Up.Location = New System.Drawing.Point(32, 104)
        Me.cmdMoveX1000Up.Name = "cmdMoveX1000Up"
        Me.cmdMoveX1000Up.Size = New System.Drawing.Size(56, 32)
        Me.cmdMoveX1000Up.TabIndex = 3
        Me.cmdMoveX1000Up.Text = "1"
        Me.cmdMoveX1000Up.UseVisualStyleBackColor = True
        '
        'chtForceVsDisp
        '
        Me.chtForceVsDisp.BorderlineColor = System.Drawing.Color.Black
        Me.chtForceVsDisp.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.AxisX.Interval = 0.2R
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Interval = 0.0R
        ChartArea1.AxisX.MajorGrid.Interval = 0.1R
        ChartArea1.AxisX.Minimum = 0.0R
        ChartArea1.AxisX.MinorGrid.Enabled = True
        ChartArea1.AxisX.MinorGrid.Interval = 0.05R
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea1.AxisY.Interval = 50.0R
        ChartArea1.AxisY.MajorGrid.Interval = 50.0R
        ChartArea1.AxisY.Minimum = -50.0R
        ChartArea1.AxisY.MinorGrid.Enabled = True
        ChartArea1.AxisY.MinorGrid.Interval = 25.0R
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea1.BackColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.Name = "ChartArea1"
        Me.chtForceVsDisp.ChartAreas.Add(ChartArea1)
        Legend1.BorderColor = System.Drawing.Color.Black
        Legend1.DockedToChartArea = "ChartArea1"
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend1.Name = "Legend1"
        Me.chtForceVsDisp.Legends.Add(Legend1)
        Me.chtForceVsDisp.Location = New System.Drawing.Point(336, 28)
        Me.chtForceVsDisp.Name = "chtForceVsDisp"
        Me.chtForceVsDisp.Size = New System.Drawing.Size(512, 388)
        Me.chtForceVsDisp.TabIndex = 30
        Me.chtForceVsDisp.Text = "Chart1"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Title1.Name = "Title1"
        Title1.Text = "Force Profile"
        Me.chtForceVsDisp.Titles.Add(Title1)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 445)
        Me.Controls.Add(Me.chtForceVsDisp)
        Me.Controls.Add(Me.gbxManualControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stpMain)
        Me.Controls.Add(Me.tctlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.tctlMain.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabConfig.ResumeLayout(False)
        Me.stpMain.ResumeLayout(False)
        Me.stpMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ledXAxEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledButtonStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timUpdateUI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxManualControl.ResumeLayout(False)
        Me.gbxManualControl.PerformLayout()
        CType(Me.chtForceVsDisp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tctlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents tabConfig As System.Windows.Forms.TabPage
    Friend WithEvents stpMain As System.Windows.Forms.StatusStrip
    Friend WithEvents stpMainStrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pgSettings As System.Windows.Forms.PropertyGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ledXAxEnabled As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents ledButtonStatus As NationalInstruments.UI.WindowsForms.Led
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdPauseResume As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblCurrentCycle As System.Windows.Forms.Label
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblErrorCycles As System.Windows.Forms.Label
    Friend WithEvents lblTargetCycles As System.Windows.Forms.Label
    Friend WithEvents lblSuccessfulCycles As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents timUpdateUI As System.Timers.Timer
    Friend WithEvents stpStatusStrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblConsecOpenFailures As System.Windows.Forms.Label
    Friend WithEvents lblTotalOpenFailures As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblConsecClosureFailures As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalClosureFailures As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdZeroXpos As System.Windows.Forms.Button
    Friend WithEvents cmdEnableXAx As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblForce As System.Windows.Forms.Label
    Friend WithEvents lblXPos As System.Windows.Forms.Label
    Friend WithEvents gbxManualControl As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMoveX100Down As System.Windows.Forms.Button
    Friend WithEvents cmdMoveX10Down As System.Windows.Forms.Button
    Friend WithEvents cmdHomeX As System.Windows.Forms.Button
    Friend WithEvents cmdMoveX10Up As System.Windows.Forms.Button
    Friend WithEvents cmdMoveX100Up As System.Windows.Forms.Button
    Friend WithEvents cmdMoveX1000Up As System.Windows.Forms.Button
    Friend WithEvents cmdMoveX1000Down As System.Windows.Forms.Button
    Friend WithEvents cmdMoveRel As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdMoveAbs As System.Windows.Forms.Button
    Friend WithEvents txtXPos As System.Windows.Forms.TextBox
    Friend WithEvents chtForceVsDisp As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pbrForce As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdSendConfig As System.Windows.Forms.Button

End Class
