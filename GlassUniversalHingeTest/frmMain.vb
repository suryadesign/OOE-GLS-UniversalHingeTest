Public Class frmMain
    Public DeviceID, TestOperator, DataFilePath, StartTime As String
    Public DwellTime, NumCycles, ConsecFailLimit, TotalFailLimit, FixtureFailureLimit, EndTravelCond, DAQFrequency, GraphDisplay As Integer
    ' graphdisplay indicates whether graphing vs displacement or distance
    Public RelPos, TargetForce, ZTargetForce, ForceLimit As Single
    Public EndOnCycles, EndOnTotalFailLimit, EndOnConsecFailLimit, EndOnFixtureFailLimit, TimedOut, IgnoreButtonStatus, _
        ZeroPositionBeforeTest, ButtonClosed, ButtonOpen, LimitForce As Boolean

    Public PauseFlag As Boolean = False     'flag for if user pauses testing
    Public StopFlag As Boolean = False      'flag for if user aborts testing
    Public SleepFlag As Boolean = False     'flag to handle sleeps/waits
    Public ACSErrorFlag As Boolean = False  'flag for if ACS initialization worked


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ErrMsg As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        timUpdateUI.Enabled = False
        stpStatusStrip.Text = "Initializing..."
        Me.Text = My.Settings.ACSIP     'give the form a name
        timUpdateUI.Interval = 100        'set ui update interval
        txtXPos.Text = My.Settings.LastXPos
        If ConnectACS(ErrMsg) Then          ' if successful connection to motion controller
            If SendMotionConfig("X", My.Settings.VelX, My.Settings.AccX, My.Settings.DecX, My.Settings.JerkX, My.Settings.KDecX, ErrMsg) Then  'if motion params set ok
                If SetForceLimit(0, MaxForce, ErrMsg) Then      'if force limit (max) set ok
                    ACSErrorFlag = False
                    timUpdateUI.Enabled = True
                    pgSettings.SelectedObject = My.Settings
                    'format chart
                    chtForceVsDisp.ChartAreas(0).AxisX.Title = "Displacement [mm]"
                    chtForceVsDisp.ChartAreas(0).AxisX.LabelStyle.Format = "##.###"
                    chtForceVsDisp.ChartAreas(0).AxisY.Title = "Force [gf]"
                    chtForceVsDisp.ChartAreas(0).AxisY.LabelStyle.Format = "##."
                    stpStatusStrip.Text = "Idle."
                    pbrForce.Minimum = 0
                    pbrForce.Maximum = MaxForce
                Else
                    MsgBox("Invalid force limit!  Check configuration file and restart." & vbLf & ErrMsg)
                    ACSErrorFlag = True
                    Application.Exit()
                End If
            Else
                MsgBox("Invalid motion parameters!  Check configuration file and restart." & vbLf & ErrMsg)
                ACSErrorFlag = True
                Application.Exit()
            End If
        Else
            MsgBox("Motion controller not found!  Check connections and restart." & vbLf & ErrMsg)
            ACSErrorFlag = True
            Application.Exit()
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Not ACSErrorFlag Then
            If MsgBox("Exit testing?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim ErrMsg As String = ""
                StopFlag = True
                stpStatusStrip.Text = "Test aborted by user."
                timUpdateUI.Enabled = False       'stop daq reading
                My.Settings.LastXPos = txtXPos.Text
                My.Settings.Save()
                If DisconnectACS(ErrMsg) Then
                Else
                    MsgBox(ErrMsg)
                End If
            Else
                e.Cancel = True
            End If
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub UpdateUI(ByVal AppState As String)
        'updates the UI (what is enabled/disabled) based on the application state
        Select Case AppState
            Case "DISABLED"                         'X Axis drive is disabled
                tabConfig.Enabled = True
                cmdEnableXAx.Enabled = False
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = False
                cmdStop.Enabled = False
                cmdZeroXpos.Enabled = False
                gbxManualControl.Enabled = False
            Case "IDLE"                             'controller connected, drive enabled, test idle
                tabConfig.Enabled = True
                cmdEnableXAx.Enabled = True
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = True
                cmdStop.Enabled = False
                cmdZeroXpos.Enabled = True
                gbxManualControl.Enabled = True
            Case "RUNNING"                           'controller connected, drive enabled, test running
                tabConfig.Enabled = False
                cmdEnableXAx.Enabled = False
                cmdPauseResume.Enabled = True
                cmdStart.Enabled = False
                cmdStop.Enabled = True
                cmdZeroXpos.Enabled = False
                gbxManualControl.Enabled = False
            Case "PAUSED"                            'controller connected, drive enabled, test paused
                tabConfig.Enabled = False
                cmdEnableXAx.Enabled = False
                cmdPauseResume.Enabled = True
                cmdStart.Enabled = False
                cmdStop.Enabled = True
                cmdZeroXpos.Enabled = False
                gbxManualControl.Enabled = False
            Case "MOVING"                             'controller connected, drive enabled, test idle, actuator moving
                tabConfig.Enabled = False
                cmdEnableXAx.Enabled = False
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = False
                cmdStop.Enabled = False
                cmdZeroXpos.Enabled = False
                gbxManualControl.Enabled = False
        End Select
    End Sub
    Private Sub timUpdateUI_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timUpdateUI.Elapsed
        'updates UI on frequent interval
        Dim ErrMsg As String = ""
        ledXAxEnabled.Value = GetAxisStatus(0, ErrMsg)
        Dim AxisStatus As Byte
        AxisStatus = GetAxisStatus(0, ErrMsg)
        If AxisStatus = ErrByte Then
            MsgBox(ErrMsg)
        Else
            If AxisStatus Then
                cmdEnableXAx.Text = "Disable"
            Else
                cmdEnableXAx.Text = "Enable"
            End If
        End If
        ledButtonStatus.Value = GetButtonStatus(ErrMsg)
        Dim XPos As Single
        XPos = GetPos(0, ErrMsg)
        If XPos = ErrSingle Then
            lblXPos.Text = "ERROR:" & ErrMsg
            ErrMsg = ""
        Else
            lblXPos.Text = XPos.ToString("0.000")
        End If
        Dim Force As Single
        Force = GetForce(ErrMsg)
        If Force = ErrSingle Then
            lblForce.Text = "ERROR:" & ErrMsg
            ErrMsg = ""
        Else
            lblForce.Text = Force.ToString("0.0")
            If Force < 0 Then
                pbrForce.Value = 0
            ElseIf Force > MaxForce Then
                pbrForce.Value = MaxForce
            Else
                pbrForce.Value = Force
            End If
        End If
    End Sub
    Private Sub cmdZeroXpos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZeroXpos.Click
        'zeros the DRO for the actuator
        Dim ErrMsg As String = ""
        If ZeroPos(0, ErrMsg) Then
            stpStatusStrip.Text = "Zeroed...Idle."
        Else
            MsgBox(ErrMsg)
        End If
    End Sub
    Private Sub cmdEnableXAx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnableXAx.Click
        'enables/disables (toggles) axis 
        Dim ErrMsg As String = ""
        Dim AxisStatus As Byte
        AxisStatus = GetAxisStatus(0, ErrMsg)
        If AxisStatus = ErrByte Then
            MsgBox(ErrMsg)
        Else
            If AxisStatus Then
                If DisableAxis(0, ErrMsg) Then
                    cmdEnableXAx.Text = "Disable"
                Else
                    MsgBox(ErrMsg)
                End If
            Else
                If EnableAxis(0, ErrMsg) Then
                    cmdEnableXAx.Text = "Enable"
                Else
                    MsgBox(ErrMsg)
                End If
            End If
        End If

    End Sub
    Private Sub cmdHomeX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHomeX.Click
        'homes actuator - almost even with bottom of actuator
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Homing..."
        If Home("X", ErrMsg) Then
            stpStatusStrip.Text = "Homed...Idle."
        Else
            stpStatusStrip.Text = "Homing error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveAbs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveAbs.Click
        'makes an absolute move of actuator
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single
        X = txtXPos.Text
        X = Math.Round(X, 2)
        If MoveActuator("X", X, True, ErrMsg) Then
            stpStatusStrip.Text = "Moved to " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveRel.Click
        'makes a relative move of actuator
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single
        X = txtXPos.Text
        X = Math.Round(X, 2)
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub txtXPos_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXPos.Validated
        If Not IsNumeric(txtXPos.Text) Then
            MessageBox.Show("Distance must be numeric")
            txtXPos.Text = My.Settings.LastXPos
        End If
    End Sub
    Private Sub cmdMoveX10Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX10Up.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -0.01
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveX100Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX100Up.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -0.1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveX1000Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX1000Up.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveX10Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX10Down.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 0.01
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveX100Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX100Down.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 0.1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveX1000Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveX1000Down.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "mm...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        'starts the button testing
        stpStatusStrip.Text = "Waiting for user input..."
        Dim frmDialog As New frmTestInput
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            stpStatusStrip.Text = "Test running..."
            RunButtonTest()
        Else
            stpStatusStrip.Text = "Idle."
            lblCurrentCycle.Text = 0
            lblErrorCycles.Text = ""
            lblSuccessfulCycles.Text = ""
            lblStartTime.Text = ""
            lblTargetCycles.Text = ""
            lblConsecClosureFailures.Text = ""
            lblTotalClosureFailures.Text = ""
            lblConsecOpenFailures.Text = ""
            lblTotalOpenFailures.Text = ""
        End If
        frmDialog.Dispose()
    End Sub
    Private Sub cmdPauseResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPauseResume.Click
        PauseFlag = Not PauseFlag
        If PauseFlag Then
            cmdPauseResume.Text = "&Resume"
            stpStatusStrip.Text = "Test Paused..."
            UpdateUI("PAUSED")
        Else
            cmdPauseResume.Text = "&Pause"
            UpdateUI("RUNNING")
        End If
    End Sub
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        If MsgBox("Abort testing?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            StopFlag = True
            stpStatusStrip.Text = "Test aborted by user...Idle."
        End If
    End Sub
    Private Sub RunButtonTest()
        'general good practice: check to see if any buttons (stop/pause) have been pressed before going into a loop
        'that waits on hardware or a timeout.

        'record initial info
        Dim FixtureErrorCycles As Integer = 0
        Dim SuccessfulCycles As Integer = 0
        Dim TotalClosedFailures As Integer = 0
        Dim ConsecClosedFailures As Integer = 0
        Dim TotalOpenFailures As Integer = 0
        Dim ConsecOpenFailures As Integer = 0
        Dim PreviousClosedFailed As Boolean = False
        Dim PreviousOpenFailed As Boolean = False
        Dim ErrMsg As String = ""
        Dim T0 As Date = Now
        Dim Fmax, InitLoc As Single 'max force attained and initial position of actuator
        Dim MainDataFileFullPath As String = DataFilePath & "\" & DeviceID & " " & T0.ToString("yyyy-MM-dd HH-mm-ss.ff") & "-MAIN.txt"
        Dim ForceDataFileFullPath As String = DataFilePath & "\" & DeviceID & " " & T0.ToString("yyyy-MM-dd HH-mm-ss.ff") & "-FORCE.txt"
        'update UI
        UpdateUI("RUNNING")
        PauseFlag = False
        StopFlag = False
        cmdPauseResume.Text = "&Pause"
        lblTargetCycles.Text = IIf(EndOnCycles, NumCycles.ToString("n0"), "n/a")
        lblErrorCycles.Text = FixtureErrorCycles.ToString("n0")
        lblSuccessfulCycles.Text = SuccessfulCycles.ToString("n0")
        lblTotalClosureFailures.Text = TotalClosedFailures.ToString("n0")
        lblConsecClosureFailures.Text = ConsecClosedFailures.ToString("n0")
        lblTotalOpenFailures.Text = TotalOpenFailures.ToString("n0")
        lblConsecOpenFailures.Text = ConsecOpenFailures.ToString("n0")
        lblStartTime.Text = T0.ToString("yyyy-MM-dd HH-mm-ss.ff")
        chtForceVsDisp.Series.Clear()
        If GraphDisplay = 0 Then
            chtForceVsDisp.ChartAreas(0).AxisX.Title = "Displacement [mm]"
        Else
            chtForceVsDisp.ChartAreas(0).AxisX.Title = "Distance [mm]"
        End If
        Try
            Dim MainDataFile As New System.IO.StreamWriter(MainDataFileFullPath)
            MainDataFile.WriteLine("Device ID:" & ControlChars.Tab & DeviceID)
            MainDataFile.WriteLine("Start Time:" & ControlChars.Tab & T0.ToString("yyyy-MM-dd HH-mm-ss.ff"))
            MainDataFile.WriteLine("Operator:" & ControlChars.Tab & TestOperator)
            MainDataFile.WriteLine("Fixture ID:" & ControlChars.Tab & My.Settings.ACSIP)
            MainDataFile.WriteLine("Dwell Time [msec]:" & ControlChars.Tab & DwellTime)
            MainDataFile.WriteLine("Force Limit [gf]:" & ControlChars.Tab & IIf(LimitForce, ForceLimit.ToString("n1"), MaxForce.ToString("n1")))
            MainDataFile.WriteLine("Zero Position Before Test:" & ControlChars.Tab & IIf(ZeroPositionBeforeTest, "Yes", "No"))
            MainDataFile.WriteLine("Ignore Button Status:" & ControlChars.Tab & IIf(IgnoreButtonStatus, "Yes", "No"))
            Select Case EndTravelCond
                Case 0
                    MainDataFile.WriteLine("Down Travel End Condition:" & ControlChars.Tab & "Relative Postion (" & RelPos.ToString("n3") & " mm)")
                Case 1
                    MainDataFile.WriteLine("Down Travel End Condition:" & ControlChars.Tab & "Target Force (" & TargetForce.ToString("n1") & " gf)")
                Case 2
                    MainDataFile.WriteLine("Down Travel End Condition:" & ControlChars.Tab & "(Z) Target Force (" & ZTargetForce.ToString("n1") & " gf)")
                Case 3
                    MainDataFile.WriteLine("Down Travel End Condition:" & ControlChars.Tab & "Button Closure")
            End Select
            MainDataFile.WriteLine("Test End Conditions:")
            MainDataFile.WriteLine(ControlChars.Tab & "Number of Cycles:" & ControlChars.Tab & IIf(EndOnCycles, NumCycles, "n/a"))
            MainDataFile.WriteLine(ControlChars.Tab & "Fixture Failures:" & ControlChars.Tab & IIf(EndOnFixtureFailLimit, FixtureFailureLimit, "n/a"))
            MainDataFile.WriteLine(ControlChars.Tab & "Total Error Limit:" & ControlChars.Tab & IIf(EndOnTotalFailLimit, TotalFailLimit, "n/a"))
            MainDataFile.WriteLine(ControlChars.Tab & "Consecutive Error Limit:" & ControlChars.Tab & IIf(EndOnConsecFailLimit, ConsecFailLimit, "n/a"))
            MainDataFile.WriteLine("Motion Parameters:")
            MainDataFile.WriteLine(ControlChars.Tab & "Velocity [mm/s]:" & ControlChars.Tab & My.Settings.VelX.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Accel [mm/s^2]:" & ControlChars.Tab & My.Settings.AccX.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Decel [mm/s^2]:" & ControlChars.Tab & My.Settings.DecX.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Jerk [mm/s^3]: " & ControlChars.Tab & My.Settings.JerkX.ToString("n0"))
            MainDataFile.WriteLine(ControlChars.Tab & "Kill Decel [mm/s^2]:" & ControlChars.Tab & My.Settings.KDecX.ToString("n0"))
            MainDataFile.WriteLine("")
            MainDataFile.WriteLine("Time/Date" & ControlChars.Tab & "Cycle Number" & ControlChars.Tab & "Max Force (gf)" & ControlChars.Tab & "Status")
            MainDataFile.Flush()
            MainDataFile.Close()
            MainDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim ForceDataFile As New System.IO.StreamWriter(ForceDataFileFullPath)
            ForceDataFile.WriteLine("Device ID:" & ControlChars.Tab & DeviceID)
            ForceDataFile.WriteLine("Start Time:" & ControlChars.Tab & T0.ToString("yyyy-MM-dd HH-mm-ss.ff"))
            ForceDataFile.WriteLine("")
            ForceDataFile.Flush()
            ForceDataFile.Close()
            ForceDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If ZeroPositionBeforeTest Then
            If ZeroPos(0, ErrMsg) Then
            Else
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
            End If
        End If

        InitLoc = GetPos(0, ErrMsg)
        If InitLoc = ErrSingle Then
            MsgBox("ERROR:" & ErrMsg)
            ErrMsg = ""
        End If

        Dim i As Integer = 1
        Dim ForceArray
        If LimitForce Then
            If SetForceLimit(0, ForceLimit, ErrMsg) Then
            Else
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
            End If
        Else
            If SetForceLimit(0, MaxForce, ErrMsg) Then
            Else
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
            End If
        End If
        Do
            lblCurrentCycle.Text = i.ToString("n0")
            'run a cycle depending on the end travel condition
            Select Case EndTravelCond
                Case 0      'point to point
                    ForceArray = PressToPosition(InitLoc, DwellTime, RelPos, ButtonClosed, ButtonOpen, ErrMsg)
                    If IsNumeric(ForceArray) Then
                        stpStatusStrip.Text = ErrMsg
                        ErrMsg = ""
                        FixtureErrorCycles = FixtureErrorCycles + 1
                        GoTo CycleEnd
                    End If
                Case 1      'press to target force
                    ForceArray = PressToFTarget(InitLoc, TargetForce, DwellTime, ZTargetForce, ButtonClosed, ButtonOpen, ErrMsg)
                    If IsNumeric(ForceArray) Then
                        stpStatusStrip.Text = ErrMsg
                        ErrMsg = ""
                        FixtureErrorCycles = FixtureErrorCycles + 1
                        GoTo CycleEnd
                    End If
                Case 2      'press to target force first, then to that position
                    If i = 1 Then
                        ForceArray = PressToFTarget(InitLoc, ZTargetForce, DwellTime, RelPos, ButtonClosed, ButtonOpen, ErrMsg)
                        If IsNumeric(ForceArray) Then
                            stpStatusStrip.Text = ErrMsg
                            ErrMsg = ""
                            FixtureErrorCycles = FixtureErrorCycles + 1
                            GoTo CycleEnd
                        End If
                    Else
                        ForceArray = PressToPosition(InitLoc, DwellTime, RelPos, ButtonClosed, ButtonOpen, ErrMsg)
                        If IsNumeric(ForceArray) Then
                            stpStatusStrip.Text = ErrMsg
                            ErrMsg = ""
                            FixtureErrorCycles = FixtureErrorCycles + 1
                            GoTo CycleEnd
                        End If
                    End If
                Case 3  'press to button closure
                    ForceArray = PressToClosure(InitLoc, DwellTime, ButtonClosed, ButtonOpen, ErrMsg)
                    If IsNumeric(ForceArray) Then
                        stpStatusStrip.Text = ErrMsg
                        ErrMsg = ""
                        FixtureErrorCycles = FixtureErrorCycles + 1
                        GoTo CycleEnd
                    End If
            End Select
            If Not IgnoreButtonStatus Then
                If Not ButtonClosed Then
                    TotalClosedFailures = TotalClosedFailures + 1
                    If PreviousClosedFailed Or (ConsecClosedFailures = 0) Then
                        ConsecClosedFailures = ConsecClosedFailures + 1
                    End If
                    PreviousClosedFailed = True
                Else
                    PreviousClosedFailed = False
                    ConsecClosedFailures = 0
                End If
                If Not ButtonOpen Then
                    TotalOpenFailures = TotalOpenFailures + 1
                    If PreviousOpenFailed Or (ConsecOpenFailures = 0) Then
                        ConsecOpenFailures = ConsecOpenFailures + 1
                    End If
                    PreviousOpenFailed = True
                Else
                    PreviousOpenFailed = False
                    ConsecOpenFailures = 0
                End If
            End If
            If (i > 2) And (chtForceVsDisp.Series.Count > 1) Then          'remove all but the first force plot
                chtForceVsDisp.Series.RemoveAt(1)
            Else
                chtForceVsDisp.ChartAreas(0).Axes(1).IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount
            End If
            'add a new plot
            ProcessAndPlotForceData(ForceArray, i, Fmax)
            Do While PauseFlag And Not StopFlag
                Application.DoEvents()
            Loop
            SuccessfulCycles = SuccessfulCycles + 1
            stpStatusStrip.Text = "Cycle successfully completed."

CycleEnd:
            If StopFlag Then
                stpStatusStrip.Text = "Test aborted by user...Idle."
            End If
            lblSuccessfulCycles.Text = SuccessfulCycles.ToString("n0")
            lblErrorCycles.Text = FixtureErrorCycles.ToString("n0")
            If IgnoreButtonStatus Then
                lblTotalClosureFailures.Text = "n/a"
                lblConsecClosureFailures.Text = "n/a"
                lblTotalOpenFailures.Text = "n/a"
                lblConsecOpenFailures.Text = "n/a"
            Else
                lblTotalClosureFailures.Text = TotalClosedFailures.ToString("n0")
                lblConsecClosureFailures.Text = ConsecClosedFailures.ToString("n0")
                lblTotalOpenFailures.Text = TotalOpenFailures.ToString("n0")
                lblConsecOpenFailures.Text = ConsecOpenFailures.ToString("n0")

            End If
            'write line of data
            Try
                Dim MainDataFile As New System.IO.StreamWriter(MainDataFileFullPath, True)
                MainDataFile.WriteLine(Now.ToString("yyyy-MM-dd HH-mm-ss.ff") & ControlChars.Tab & i & ControlChars.Tab & IIf(IsNumeric(ForceArray), "n/a", Fmax.ToString("n1")) & ControlChars.Tab & stpStatusStrip.Text)
                MainDataFile.Flush()
                MainDataFile.Close()
                MainDataFile.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Select Case DAQFrequency
                Case 0  'never
                Case 1  'every 1
                    RecordForceData(ForceArray, i, Fmax, ForceDataFileFullPath)
                Case 2  'every 10
                    If ((i - 1) Mod 10) = 0 Then
                        RecordForceData(ForceArray, i, Fmax, ForceDataFileFullPath)
                    End If
                Case 3  'every 100
                    If ((i - 1) Mod 100) = 0 Then
                        RecordForceData(ForceArray, i, Fmax, ForceDataFileFullPath)
                    End If
                Case 4  'every 1000
                    If ((i - 1) Mod 1000) = 0 Then
                        RecordForceData(ForceArray, i, Fmax, ForceDataFileFullPath)
                    End If
                Case 5  'progressive interval
                    If i <= 10 Or _
                        (i <= 100) And (((i - 1) Mod 10) = 0) Or _
                        (i <= 1000) And (((i - 1) Mod 100) = 0) Or _
                        (i <= 10000) And (((i - 1) Mod 1000) = 0) Or _
                        (i <= 100000) And (((i - 1) Mod 10000) = 0) Or _
                        (i <= 1000000) And (((i - 1) Mod 100000) = 0) Or _
                        (i <= 10000000) And (((i - 1) Mod 1000000) = 0) Or _
                        (i <= 100000000) And (((i - 1) Mod 10000000) = 0) Then
                        RecordForceData(ForceArray, i, Fmax, ForceDataFileFullPath)
                    End If
            End Select
            'check for excessive failures
            If EndOnConsecFailLimit And (ConsecClosedFailures >= ConsecFailLimit) Then
                stpStatusStrip.Text = "Consecutive closed button failure limit exceeded."
                Exit Do
            End If
            If EndOnTotalFailLimit And (TotalClosedFailures >= TotalFailLimit) Then
                stpStatusStrip.Text = "Total closed button failure limit exceeded."
                Exit Do
            End If
            If EndOnConsecFailLimit And (ConsecOpenFailures >= ConsecFailLimit) Then
                stpStatusStrip.Text = "Consecutive open button failure limit exceeded."
                Exit Do
            End If
            If EndOnTotalFailLimit And (TotalOpenFailures >= TotalFailLimit) Then
                stpStatusStrip.Text = "Total open button failure limit exceeded."
                Exit Do
            End If
            If EndOnFixtureFailLimit And (FixtureErrorCycles >= FixtureFailureLimit) Then
                stpStatusStrip.Text = "Fixture failure limit exceeded."
                Exit Do
            End If
            If EndOnCycles And (i >= NumCycles) And (TotalClosedFailures > 0 Or TotalOpenFailures > 0 Or FixtureErrorCycles > 0) Then
                stpStatusStrip.Text = "Test completed successfully with errors."
                Exit Do
            End If
            If EndOnCycles And (i >= NumCycles) Then
                stpStatusStrip.Text = "Test completed successfully...Idle."
                Exit Do
            End If
            If StopFlag Then
                Exit Do
            End If
            i = i + 1
        Loop Until False

        'write test summary 
        Try
            Dim MainDataFile As New System.IO.StreamWriter(MainDataFileFullPath, True)
            MainDataFile.WriteLine("")
            If StopFlag Then
                StopFlag = False
                MainDataFile.WriteLine("Test aborted by user.")
            Else
                MainDataFile.WriteLine(stpStatusStrip.Text)
            End If
            MainDataFile.WriteLine("Successful cycles:" & ControlChars.Tab & SuccessfulCycles)
            MainDataFile.WriteLine("Fixture failures:" & ControlChars.Tab & FixtureErrorCycles)
            If IgnoreButtonStatus Then
                MainDataFile.WriteLine("Total button closure failures:" & ControlChars.Tab & "n/a")
                MainDataFile.WriteLine("Consecutive button closure failures:" & ControlChars.Tab & "n/a")
                MainDataFile.WriteLine("Total button open failures:" & ControlChars.Tab & "n/a")
                MainDataFile.WriteLine("Consecutive button open failures:" & ControlChars.Tab & "n/a")
            Else
                MainDataFile.WriteLine("Total button closure failures:" & ControlChars.Tab & TotalClosedFailures)
                MainDataFile.WriteLine("Consecutive button closure failures:" & ControlChars.Tab & ConsecClosedFailures)
                MainDataFile.WriteLine("Total button open failures:" & ControlChars.Tab & TotalOpenFailures)
                MainDataFile.WriteLine("Consecutive button open failures:" & ControlChars.Tab & ConsecOpenFailures)

            End If
            MainDataFile.Flush()
            MainDataFile.Close()
            MainDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        UpdateUI("IDLE")

    End Sub
    Sub ProcessAndPlotForceData(ByVal ForceArray As Object, ByVal i As Integer, ByRef Fmax As Single)
        Fmax = Single.MinValue
        Dim XMax = Single.MinValue
        Dim Force As Single
        Dim Dist As Single = 0
        chtForceVsDisp.Series.Add("Cycle")
        chtForceVsDisp.Series("Cycle").ChartType = DataVisualization.Charting.SeriesChartType.Line
        chtForceVsDisp.Series("Cycle").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        chtForceVsDisp.Series("Cycle").MarkerStyle = DataVisualization.Charting.MarkerStyle.None
        'add the data to the series
        If GraphDisplay = 0 Then            'if plotting vs displacement
            For j = 0 To ForceDataPoints - 1
                Force = -ForceArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleForce * Lbs2Grams
                chtForceVsDisp.Series("Cycle").Points.AddXY(ForceArray(j, 0), Force)
                If Force > Fmax Then Fmax = Force
                If ForceArray(j, 0) > XMax Then XMax = ForceArray(j, 0)
            Next
        Else                                'else plotting vs distance
            For j = 0 To ForceDataPoints - 1
                Force = -ForceArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleForce * Lbs2Grams
                If j = 0 Then
                    Dist = ForceArray(j, 0)
                Else
                    Dist = Dist + Math.Abs(ForceArray(j, 0) - ForceArray(j - 1, 0))
                End If
                chtForceVsDisp.Series("Cycle").Points.AddXY(Dist, Force)
                If Force > Fmax Then Fmax = Force
                If Dist > XMax Then XMax = Dist
            Next
        End If
        If chtForceVsDisp.Series.Count = 1 Then
            chtForceVsDisp.Series(0).Color = Color.Red       'initial plot in red
            chtForceVsDisp.Series(0).Name = "First Cycle"
            Select Case Fmax
                Case Single.MinValue To 200
                    chtForceVsDisp.ChartAreas(0).AxisY.Minimum = -25
                    chtForceVsDisp.ChartAreas(0).AxisY.Interval = 25
                    chtForceVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 25
                    chtForceVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 5
                Case 200 To 400
                    chtForceVsDisp.ChartAreas(0).AxisY.Minimum = -50
                    chtForceVsDisp.ChartAreas(0).AxisY.Interval = 50
                    chtForceVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 50
                    chtForceVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 10
                Case 400 To 600
                    chtForceVsDisp.ChartAreas(0).AxisY.Minimum = -50
                    chtForceVsDisp.ChartAreas(0).AxisY.Interval = 100
                    chtForceVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 100
                    chtForceVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 25
                Case 600 To Single.MaxValue
                    chtForceVsDisp.ChartAreas(0).AxisY.Minimum = -50
                    chtForceVsDisp.ChartAreas(0).AxisY.Interval = 100
                    chtForceVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 100
                    chtForceVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 50
            End Select
            Select Case XMax
                Case Single.MinValue To 0.1
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 0.02
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.02
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.005
                Case 0.1 To 0.2
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 0.04
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.04
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.01
                Case 0.2 To 0.5
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 0.1
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.1
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.02
                Case 0.5 To 1.0
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 0.2
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.2
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.05
                Case 1 To 2
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 0.4
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.4
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.1
                Case 2 To 5
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 1
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 1
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.2
                Case 5 To 10
                    chtForceVsDisp.ChartAreas(0).AxisX.Interval = 2
                    chtForceVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 2
                    chtForceVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.5
            End Select
        ElseIf chtForceVsDisp.Series.Count > 1 Then
            chtForceVsDisp.Series(1).Color = Color.Blue      'all other plots in blue
            chtForceVsDisp.Series(1).Name = "Previous Cycle"
        End If

    End Sub
    Sub RecordForceData(ByVal ForceArray As Object, ByVal i As Integer, ByRef Fmax As Single, ByVal ForceDataFileFullPath As String)
        Dim Tmp As Single
        Try

            Dim ForceDataFile As New System.IO.StreamWriter(ForceDataFileFullPath, True)
            ForceDataFile.Write("Cycle " & i & " Z" & ControlChars.Tab)
            If IsNumeric(ForceArray) Then
                ForceDataFile.WriteLine("n/a")
            Else
                For j = 0 To ForceDataPoints - 1
                    Tmp = ForceArray(j, 0)
                    ForceDataFile.Write(Tmp.ToString("n3") & ControlChars.Tab)
                Next
                ForceDataFile.WriteLine("")
            End If
            ForceDataFile.Write("Cycle " & i & " Force" & ControlChars.Tab)
            If IsNumeric(ForceArray) Then
                ForceDataFile.WriteLine("n/a")
            Else
                For j = 0 To ForceDataPoints - 1
                    Tmp = -ForceArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleForce * Lbs2Grams
                    ForceDataFile.Write(Tmp.ToString("n1") & ControlChars.Tab)
                Next
                ForceDataFile.WriteLine("")
            End If
            ForceDataFile.Flush()
            ForceDataFile.Close()
            ForceDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdSendConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendConfig.Click
        Dim ErrMsg As String = ""
        Me.Text = My.Settings.ACSIP     'give the form a name
        If SendMotionConfig("X", My.Settings.VelX, My.Settings.AccX, My.Settings.DecX, My.Settings.JerkX, My.Settings.KDecX, ErrMsg) Then
            If SetForceLimit(0, MaxForce, ErrMsg) Then
                UpdateUI("IDLE")
            Else
                UpdateUI("DISABLED")
                MsgBox("Invalid force limit!  Check configuration and retry." & Chr(10) & ErrMsg)
            End If
        Else
            UpdateUI("DISABLED")
            MsgBox("Invalid motion parameters!  Check configuration and retry." & Chr(10) & ErrMsg)
        End If
    End Sub
End Class
