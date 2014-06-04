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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.tctlMain = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
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
        Me.cmdResetToDefaults = New System.Windows.Forms.Button()
        Me.cmdSendConfig = New System.Windows.Forms.Button()
        Me.pgSettings = New System.Windows.Forms.PropertyGrid()
        Me.stpMain = New System.Windows.Forms.StatusStrip()
        Me.stpStatusStrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stpMainStrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picLidStatus = New System.Windows.Forms.PictureBox()
        Me.picDriveEnabled = New System.Windows.Forms.PictureBox()
        Me.pbrTorque = New System.Windows.Forms.ProgressBar()
        Me.lblTorque = New System.Windows.Forms.Label()
        Me.lblThetaPos = New System.Windows.Forms.Label()
        Me.cmdZeroThetaPos = New System.Windows.Forms.Button()
        Me.cmdEnableAxis = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.timUpdateUI = New System.Timers.Timer()
        Me.gbxManualControl = New System.Windows.Forms.GroupBox()
        Me.CmdTempleHingeNeutral = New System.Windows.Forms.Button()
        Me.cmdCrystalHingeNeutral = New System.Windows.Forms.Button()
        Me.txtThetaPos = New System.Windows.Forms.TextBox()
        Me.cmdMoveRel = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdMoveAbs = New System.Windows.Forms.Button()
        Me.cmdMoveTenCCW = New System.Windows.Forms.Button()
        Me.cmdMoveOneCCW = New System.Windows.Forms.Button()
        Me.cmdMoveTenthCCW = New System.Windows.Forms.Button()
        Me.cmdHome = New System.Windows.Forms.Button()
        Me.cmdMoveTenthCW = New System.Windows.Forms.Button()
        Me.cmdMoveOneCW = New System.Windows.Forms.Button()
        Me.cmdMoveTenCW = New System.Windows.Forms.Button()
        Me.chtTorqueVsDisp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tctlMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabConfig.SuspendLayout()
        Me.stpMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picLidStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDriveEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timUpdateUI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxManualControl.SuspendLayout()
        CType(Me.chtTorqueVsDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tctlMain
        '
        Me.tctlMain.Controls.Add(Me.tabMain)
        Me.tctlMain.Controls.Add(Me.tabConfig)
        Me.tctlMain.Location = New System.Drawing.Point(8, 8)
        Me.tctlMain.Name = "tctlMain"
        Me.tctlMain.SelectedIndex = 0
        Me.tctlMain.Size = New System.Drawing.Size(320, 208)
        Me.tctlMain.TabIndex = 0
        '
        'tabMain
        '
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
        Me.tabMain.Size = New System.Drawing.Size(312, 182)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(120, 120)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(0, 13)
        Me.lblStartTime.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 16)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Successful Cycles:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(16, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Fixture Failures:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(16, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 16)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Start Time:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblErrorCycles
        '
        Me.lblErrorCycles.AutoSize = True
        Me.lblErrorCycles.Location = New System.Drawing.Point(120, 104)
        Me.lblErrorCycles.Name = "lblErrorCycles"
        Me.lblErrorCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblErrorCycles.TabIndex = 8
        Me.lblErrorCycles.Text = "0"
        '
        'lblTargetCycles
        '
        Me.lblTargetCycles.AutoSize = True
        Me.lblTargetCycles.Location = New System.Drawing.Point(120, 72)
        Me.lblTargetCycles.Name = "lblTargetCycles"
        Me.lblTargetCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblTargetCycles.TabIndex = 7
        Me.lblTargetCycles.Text = "0"
        '
        'lblSuccessfulCycles
        '
        Me.lblSuccessfulCycles.AutoSize = True
        Me.lblSuccessfulCycles.Location = New System.Drawing.Point(120, 88)
        Me.lblSuccessfulCycles.Name = "lblSuccessfulCycles"
        Me.lblSuccessfulCycles.Size = New System.Drawing.Size(13, 13)
        Me.lblSuccessfulCycles.TabIndex = 6
        Me.lblSuccessfulCycles.Text = "0"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(24, 72)
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
        Me.cmdStop.Location = New System.Drawing.Point(224, 144)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(72, 24)
        Me.cmdStop.TabIndex = 2
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdPauseResume
        '
        Me.cmdPauseResume.Enabled = False
        Me.cmdPauseResume.Location = New System.Drawing.Point(120, 144)
        Me.cmdPauseResume.Name = "cmdPauseResume"
        Me.cmdPauseResume.Size = New System.Drawing.Size(72, 24)
        Me.cmdPauseResume.TabIndex = 1
        Me.cmdPauseResume.Text = "Pause"
        Me.cmdPauseResume.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(16, 144)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(72, 24)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'tabConfig
        '
        Me.tabConfig.Controls.Add(Me.cmdResetToDefaults)
        Me.tabConfig.Controls.Add(Me.cmdSendConfig)
        Me.tabConfig.Controls.Add(Me.pgSettings)
        Me.tabConfig.Location = New System.Drawing.Point(4, 22)
        Me.tabConfig.Name = "tabConfig"
        Me.tabConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfig.Size = New System.Drawing.Size(312, 182)
        Me.tabConfig.TabIndex = 1
        Me.tabConfig.Text = "Config"
        Me.tabConfig.UseVisualStyleBackColor = True
        '
        'cmdResetToDefaults
        '
        Me.cmdResetToDefaults.Location = New System.Drawing.Point(224, 56)
        Me.cmdResetToDefaults.Name = "cmdResetToDefaults"
        Me.cmdResetToDefaults.Size = New System.Drawing.Size(80, 40)
        Me.cmdResetToDefaults.TabIndex = 2
        Me.cmdResetToDefaults.Text = "Reset to Defaults"
        Me.cmdResetToDefaults.UseVisualStyleBackColor = True
        '
        'cmdSendConfig
        '
        Me.cmdSendConfig.Location = New System.Drawing.Point(224, 8)
        Me.cmdSendConfig.Name = "cmdSendConfig"
        Me.cmdSendConfig.Size = New System.Drawing.Size(80, 40)
        Me.cmdSendConfig.TabIndex = 1
        Me.cmdSendConfig.Text = "Send Config"
        Me.cmdSendConfig.UseVisualStyleBackColor = True
        '
        'pgSettings
        '
        Me.pgSettings.HelpVisible = False
        Me.pgSettings.Location = New System.Drawing.Point(8, 8)
        Me.pgSettings.Name = "pgSettings"
        Me.pgSettings.Size = New System.Drawing.Size(208, 168)
        Me.pgSettings.TabIndex = 0
        Me.pgSettings.ToolbarVisible = False
        '
        'stpMain
        '
        Me.stpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stpStatusStrip})
        Me.stpMain.Location = New System.Drawing.Point(0, 520)
        Me.stpMain.Name = "stpMain"
        Me.stpMain.Size = New System.Drawing.Size(334, 22)
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
        Me.GroupBox1.Controls.Add(Me.picLidStatus)
        Me.GroupBox1.Controls.Add(Me.picDriveEnabled)
        Me.GroupBox1.Controls.Add(Me.pbrTorque)
        Me.GroupBox1.Controls.Add(Me.lblTorque)
        Me.GroupBox1.Controls.Add(Me.lblThetaPos)
        Me.GroupBox1.Controls.Add(Me.cmdZeroThetaPos)
        Me.GroupBox1.Controls.Add(Me.cmdEnableAxis)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 128)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Status"
        '
        'picLidStatus
        '
        Me.picLidStatus.BackColor = System.Drawing.Color.Lime
        Me.picLidStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLidStatus.Location = New System.Drawing.Point(104, 48)
        Me.picLidStatus.Name = "picLidStatus"
        Me.picLidStatus.Size = New System.Drawing.Size(32, 16)
        Me.picLidStatus.TabIndex = 40
        Me.picLidStatus.TabStop = False
        '
        'picDriveEnabled
        '
        Me.picDriveEnabled.BackColor = System.Drawing.Color.DarkGreen
        Me.picDriveEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDriveEnabled.Location = New System.Drawing.Point(104, 24)
        Me.picDriveEnabled.Name = "picDriveEnabled"
        Me.picDriveEnabled.Size = New System.Drawing.Size(32, 16)
        Me.picDriveEnabled.TabIndex = 39
        Me.picDriveEnabled.TabStop = False
        '
        'pbrTorque
        '
        Me.pbrTorque.Location = New System.Drawing.Point(144, 96)
        Me.pbrTorque.Name = "pbrTorque"
        Me.pbrTorque.Size = New System.Drawing.Size(168, 16)
        Me.pbrTorque.Step = 1
        Me.pbrTorque.TabIndex = 38
        '
        'lblTorque
        '
        Me.lblTorque.AutoSize = True
        Me.lblTorque.Location = New System.Drawing.Point(96, 96)
        Me.lblTorque.Name = "lblTorque"
        Me.lblTorque.Size = New System.Drawing.Size(46, 13)
        Me.lblTorque.TabIndex = 37
        Me.lblTorque.Text = "0000.00"
        '
        'lblThetaPos
        '
        Me.lblThetaPos.AutoSize = True
        Me.lblThetaPos.Location = New System.Drawing.Point(96, 72)
        Me.lblThetaPos.Name = "lblThetaPos"
        Me.lblThetaPos.Size = New System.Drawing.Size(40, 13)
        Me.lblThetaPos.TabIndex = 36
        Me.lblThetaPos.Text = "0000.0"
        '
        'cmdZeroThetaPos
        '
        Me.cmdZeroThetaPos.Location = New System.Drawing.Point(144, 68)
        Me.cmdZeroThetaPos.Name = "cmdZeroThetaPos"
        Me.cmdZeroThetaPos.Size = New System.Drawing.Size(56, 20)
        Me.cmdZeroThetaPos.TabIndex = 1
        Me.cmdZeroThetaPos.Text = "Zero"
        Me.cmdZeroThetaPos.UseVisualStyleBackColor = True
        '
        'cmdEnableAxis
        '
        Me.cmdEnableAxis.Location = New System.Drawing.Point(144, 20)
        Me.cmdEnableAxis.Name = "cmdEnableAxis"
        Me.cmdEnableAxis.Size = New System.Drawing.Size(56, 20)
        Me.cmdEnableAxis.TabIndex = 0
        Me.cmdEnableAxis.Text = "Enable"
        Me.cmdEnableAxis.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Torque (kgf-cm):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Position (deg):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Lid Open"
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
        'timUpdateUI
        '
        Me.timUpdateUI.Enabled = True
        Me.timUpdateUI.SynchronizingObject = Me
        '
        'gbxManualControl
        '
        Me.gbxManualControl.Controls.Add(Me.CmdTempleHingeNeutral)
        Me.gbxManualControl.Controls.Add(Me.cmdCrystalHingeNeutral)
        Me.gbxManualControl.Controls.Add(Me.txtThetaPos)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveRel)
        Me.gbxManualControl.Controls.Add(Me.Label22)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveAbs)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveTenCCW)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveOneCCW)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveTenthCCW)
        Me.gbxManualControl.Controls.Add(Me.cmdHome)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveTenthCW)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveOneCW)
        Me.gbxManualControl.Controls.Add(Me.cmdMoveTenCW)
        Me.gbxManualControl.Location = New System.Drawing.Point(8, 360)
        Me.gbxManualControl.Name = "gbxManualControl"
        Me.gbxManualControl.Size = New System.Drawing.Size(320, 152)
        Me.gbxManualControl.TabIndex = 2
        Me.gbxManualControl.TabStop = False
        Me.gbxManualControl.Text = "Manual Control"
        '
        'CmdTempleHingeNeutral
        '
        Me.CmdTempleHingeNeutral.Location = New System.Drawing.Point(184, 120)
        Me.CmdTempleHingeNeutral.Name = "CmdTempleHingeNeutral"
        Me.CmdTempleHingeNeutral.Size = New System.Drawing.Size(128, 24)
        Me.CmdTempleHingeNeutral.TabIndex = 33
        Me.CmdTempleHingeNeutral.Text = "Temple Hinge Neutral"
        Me.CmdTempleHingeNeutral.UseVisualStyleBackColor = True
        '
        'cmdCrystalHingeNeutral
        '
        Me.cmdCrystalHingeNeutral.Location = New System.Drawing.Point(16, 120)
        Me.cmdCrystalHingeNeutral.Name = "cmdCrystalHingeNeutral"
        Me.cmdCrystalHingeNeutral.Size = New System.Drawing.Size(128, 24)
        Me.cmdCrystalHingeNeutral.TabIndex = 32
        Me.cmdCrystalHingeNeutral.Text = "Crystal Hinge Neutral "
        Me.cmdCrystalHingeNeutral.UseVisualStyleBackColor = True
        '
        'txtThetaPos
        '
        Me.txtThetaPos.Location = New System.Drawing.Point(16, 24)
        Me.txtThetaPos.Name = "txtThetaPos"
        Me.txtThetaPos.Size = New System.Drawing.Size(40, 20)
        Me.txtThetaPos.TabIndex = 0
        Me.txtThetaPos.Text = "10.0"
        '
        'cmdMoveRel
        '
        Me.cmdMoveRel.Location = New System.Drawing.Point(208, 24)
        Me.cmdMoveRel.Name = "cmdMoveRel"
        Me.cmdMoveRel.Size = New System.Drawing.Size(104, 24)
        Me.cmdMoveRel.TabIndex = 2
        Me.cmdMoveRel.Text = "Move Relative"
        Me.cmdMoveRel.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(56, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(25, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "deg"
        '
        'cmdMoveAbs
        '
        Me.cmdMoveAbs.Location = New System.Drawing.Point(96, 24)
        Me.cmdMoveAbs.Name = "cmdMoveAbs"
        Me.cmdMoveAbs.Size = New System.Drawing.Size(104, 24)
        Me.cmdMoveAbs.TabIndex = 1
        Me.cmdMoveAbs.Text = "Move Absolute"
        Me.cmdMoveAbs.UseVisualStyleBackColor = True
        '
        'cmdMoveTenCCW
        '
        Me.cmdMoveTenCCW.Image = CType(resources.GetObject("cmdMoveTenCCW.Image"), System.Drawing.Image)
        Me.cmdMoveTenCCW.Location = New System.Drawing.Point(272, 56)
        Me.cmdMoveTenCCW.Name = "cmdMoveTenCCW"
        Me.cmdMoveTenCCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveTenCCW.TabIndex = 9
        Me.cmdMoveTenCCW.Text = "10° CCW"
        Me.cmdMoveTenCCW.UseVisualStyleBackColor = True
        '
        'cmdMoveOneCCW
        '
        Me.cmdMoveOneCCW.Image = CType(resources.GetObject("cmdMoveOneCCW.Image"), System.Drawing.Image)
        Me.cmdMoveOneCCW.Location = New System.Drawing.Point(224, 56)
        Me.cmdMoveOneCCW.Name = "cmdMoveOneCCW"
        Me.cmdMoveOneCCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveOneCCW.TabIndex = 8
        Me.cmdMoveOneCCW.Text = "1° CCW"
        Me.cmdMoveOneCCW.UseVisualStyleBackColor = True
        '
        'cmdMoveTenthCCW
        '
        Me.cmdMoveTenthCCW.Image = CType(resources.GetObject("cmdMoveTenthCCW.Image"), System.Drawing.Image)
        Me.cmdMoveTenthCCW.Location = New System.Drawing.Point(192, 56)
        Me.cmdMoveTenthCCW.Name = "cmdMoveTenthCCW"
        Me.cmdMoveTenthCCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveTenthCCW.TabIndex = 7
        Me.cmdMoveTenthCCW.Text = "0.1° CCW"
        Me.cmdMoveTenthCCW.UseVisualStyleBackColor = True
        '
        'cmdHome
        '
        Me.cmdHome.Image = Global.ForceFeedbackButtonTest.My.Resources.Resources.home
        Me.cmdHome.Location = New System.Drawing.Point(136, 56)
        Me.cmdHome.Name = "cmdHome"
        Me.cmdHome.Size = New System.Drawing.Size(56, 56)
        Me.cmdHome.TabIndex = 6
        Me.cmdHome.UseVisualStyleBackColor = True
        '
        'cmdMoveTenthCW
        '
        Me.cmdMoveTenthCW.Image = CType(resources.GetObject("cmdMoveTenthCW.Image"), System.Drawing.Image)
        Me.cmdMoveTenthCW.Location = New System.Drawing.Point(96, 56)
        Me.cmdMoveTenthCW.Name = "cmdMoveTenthCW"
        Me.cmdMoveTenthCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveTenthCW.TabIndex = 5
        Me.cmdMoveTenthCW.Text = "0.1° CW"
        Me.cmdMoveTenthCW.UseVisualStyleBackColor = True
        '
        'cmdMoveOneCW
        '
        Me.cmdMoveOneCW.Image = CType(resources.GetObject("cmdMoveOneCW.Image"), System.Drawing.Image)
        Me.cmdMoveOneCW.Location = New System.Drawing.Point(56, 56)
        Me.cmdMoveOneCW.Name = "cmdMoveOneCW"
        Me.cmdMoveOneCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveOneCW.TabIndex = 4
        Me.cmdMoveOneCW.Text = "1° CW"
        Me.cmdMoveOneCW.UseVisualStyleBackColor = True
        '
        'cmdMoveTenCW
        '
        Me.cmdMoveTenCW.Image = CType(resources.GetObject("cmdMoveTenCW.Image"), System.Drawing.Image)
        Me.cmdMoveTenCW.Location = New System.Drawing.Point(16, 56)
        Me.cmdMoveTenCW.Name = "cmdMoveTenCW"
        Me.cmdMoveTenCW.Size = New System.Drawing.Size(40, 56)
        Me.cmdMoveTenCW.TabIndex = 3
        Me.cmdMoveTenCW.Text = "10° CW"
        Me.cmdMoveTenCW.UseVisualStyleBackColor = True
        '
        'chtTorqueVsDisp
        '
        Me.chtTorqueVsDisp.BorderlineColor = System.Drawing.Color.Black
        Me.chtTorqueVsDisp.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.AxisX.LabelStyle.Interval = 0.0R
        ChartArea2.AxisX.MinorGrid.Enabled = True
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea2.AxisY.MinorGrid.Enabled = True
        ChartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea2.BackColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.Name = "ChartArea1"
        Me.chtTorqueVsDisp.ChartAreas.Add(ChartArea2)
        Legend2.BorderColor = System.Drawing.Color.Black
        Legend2.DockedToChartArea = "ChartArea1"
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend2.Name = "Legend1"
        Me.chtTorqueVsDisp.Legends.Add(Legend2)
        Me.chtTorqueVsDisp.Location = New System.Drawing.Point(336, 8)
        Me.chtTorqueVsDisp.Name = "chtTorqueVsDisp"
        Me.chtTorqueVsDisp.Size = New System.Drawing.Size(536, 504)
        Me.chtTorqueVsDisp.TabIndex = 30
        Me.chtTorqueVsDisp.Text = "Chart1"
        Title2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Title2.Name = "Title1"
        Title2.Text = "Torque Profile"
        Me.chtTorqueVsDisp.Titles.Add(Title2)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 542)
        Me.Controls.Add(Me.chtTorqueVsDisp)
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
        CType(Me.picLidStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDriveEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timUpdateUI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxManualControl.ResumeLayout(False)
        Me.gbxManualControl.PerformLayout()
        CType(Me.chtTorqueVsDisp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdZeroThetaPos As System.Windows.Forms.Button
    Friend WithEvents cmdEnableAxis As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTorque As System.Windows.Forms.Label
    Friend WithEvents lblThetaPos As System.Windows.Forms.Label
    Friend WithEvents gbxManualControl As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMoveOneCCW As System.Windows.Forms.Button
    Friend WithEvents cmdMoveTenthCCW As System.Windows.Forms.Button
    Friend WithEvents cmdHome As System.Windows.Forms.Button
    Friend WithEvents cmdMoveTenthCW As System.Windows.Forms.Button
    Friend WithEvents cmdMoveOneCW As System.Windows.Forms.Button
    Friend WithEvents cmdMoveTenCW As System.Windows.Forms.Button
    Friend WithEvents cmdMoveTenCCW As System.Windows.Forms.Button
    Friend WithEvents cmdMoveRel As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdMoveAbs As System.Windows.Forms.Button
    Friend WithEvents txtThetaPos As System.Windows.Forms.TextBox
    Friend WithEvents chtTorqueVsDisp As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pbrTorque As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdSendConfig As System.Windows.Forms.Button
    Friend WithEvents CmdTempleHingeNeutral As System.Windows.Forms.Button
    Friend WithEvents cmdCrystalHingeNeutral As System.Windows.Forms.Button
    Friend WithEvents picDriveEnabled As System.Windows.Forms.PictureBox
    Friend WithEvents picLidStatus As System.Windows.Forms.PictureBox
    Friend WithEvents cmdResetToDefaults As System.Windows.Forms.Button

End Class
