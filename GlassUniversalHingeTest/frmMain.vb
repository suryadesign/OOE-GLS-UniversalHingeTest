Public Class frmMain
    Public Const CWUnidirectional As Integer = 0
    Public Const CCWUnidirectional As Integer = 1
    Public Const Bidirectional As Integer = 2
    Public Const CrystalHinge As Integer = 0
    Public Const TempleHinge As Integer = 1
    Public Const DAQNever As Integer = 0
    Public Const DAQEvery1 As Integer = 1
    Public Const DAQEvery10 As Integer = 2
    Public Const DAQEvery100 As Integer = 3
    Public Const DAQEvery1000 As Integer = 4
    Public Const DAQProgInt As Integer = 5
    Public Const GraphDisplacement As Integer = 0
    Public Const GraphDistance As Integer = 1


    Public DeviceID, TestOperator, DataFilePath, StartTime As String
    Public DwellTime, NumCycles, ConsecFailLimit, TotalFailLimit, FixtureFailureLimit, DAQFrequency, GraphDisplay, DeviceType, MotionMode As Integer
    ' graphdisplay indicates whether graphing vs displacement or distance
    Public RelPos, TorqueLimit As Single
    Public EndOnCycles, EndOnFixtureFailLimit, TimedOut, ZeroPositionBeforeTest, LimitTorque As Boolean

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
        txtThetaPos.Text = My.Settings.LastThetaPos
        If ConnectACS(ErrMsg) Then          ' if successful connection to motion controller
            If SendMotionConfig("X", My.Settings.VelTheta, My.Settings.AccTheta, My.Settings.DecTheta, My.Settings.JerkTheta, My.Settings.KDecTheta, My.Settings.HomeVelTheta, ErrMsg) Then  'if motion params set ok
                If SetTorqueLimit(0, MaxTorque, ErrMsg) Then      'if force limit (max) set ok
                    ACSErrorFlag = False
                    timUpdateUI.Enabled = True
                    pgSettings.SelectedObject = My.Settings
                    'format chart
                    chtTorqueVsDisp.ChartAreas(0).AxisX.Title = "Displacement [degrees]"
                    chtTorqueVsDisp.ChartAreas(0).AxisX.LabelStyle.Format = "##.###"
                    chtTorqueVsDisp.ChartAreas(0).AxisY.Title = "Torque [kgf-cm]"
                    chtTorqueVsDisp.ChartAreas(0).AxisY.LabelStyle.Format = "##.###"
                    stpStatusStrip.Text = "Idle."
                    pbrTorque.Minimum = 0
                    pbrTorque.Maximum = MaxTorque * 1000
                Else
                    MsgBox("Invalid torque limit!  Check configuration file and restart." & vbLf & ErrMsg)
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
                My.Settings.LastThetaPos = txtThetaPos.Text
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
                cmdEnableAxis.Enabled = False
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = False
                cmdStop.Enabled = False
                cmdZeroThetaPos.Enabled = False
                gbxManualControl.Enabled = False
            Case "IDLE"                             'controller connected, drive enabled, test idle
                tabConfig.Enabled = True
                cmdEnableAxis.Enabled = True
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = True
                cmdStop.Enabled = False
                cmdZeroThetaPos.Enabled = True
                gbxManualControl.Enabled = True
            Case "RUNNING"                           'controller connected, drive enabled, test running
                tabConfig.Enabled = False
                cmdEnableAxis.Enabled = False
                cmdPauseResume.Enabled = True
                cmdStart.Enabled = False
                cmdStop.Enabled = True
                cmdZeroThetaPos.Enabled = False
                gbxManualControl.Enabled = False
            Case "PAUSED"                            'controller connected, drive enabled, test paused
                tabConfig.Enabled = False
                cmdEnableAxis.Enabled = False
                cmdPauseResume.Enabled = True
                cmdStart.Enabled = False
                cmdStop.Enabled = True
                cmdZeroThetaPos.Enabled = False
                gbxManualControl.Enabled = False
            Case "MOVING"                             'controller connected, drive enabled, test idle, actuator moving
                tabConfig.Enabled = False
                cmdEnableAxis.Enabled = False
                cmdPauseResume.Enabled = False
                cmdStart.Enabled = False
                cmdStop.Enabled = False
                cmdZeroThetaPos.Enabled = False
                gbxManualControl.Enabled = False
        End Select
    End Sub
    Private Sub timUpdateUI_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timUpdateUI.Elapsed
        'updates UI on frequent interval
        Dim ErrMsg As String = ""
        picDriveEnabled.BackColor = IIf(GetAxisStatus(0, ErrMsg), Color.Lime, Color.DarkGreen)
        Dim AxisStatus As Byte
        AxisStatus = GetAxisStatus(0, ErrMsg)
        If AxisStatus = ErrByte Then
            MsgBox(ErrMsg)
        Else
            If AxisStatus Then
                cmdEnableAxis.Text = "Disable"
            Else
                cmdEnableAxis.Text = "Enable"
            End If
        End If
        picLidStatus.BackColor = IIf(GetLidStatus(ErrMsg), Color.Lime, Color.DarkGreen)
        Dim ThetaPos As Single
        ThetaPos = GetPos(0, ErrMsg)
        If ThetaPos = ErrSingle Then
            lblThetaPos.Text = "ERROR:" & ErrMsg
            ErrMsg = ""
        Else
            lblThetaPos.Text = ThetaPos.ToString("0.0")
        End If
        Dim Torque As Single
        Torque = GetTorque(ErrMsg)
        If Torque = ErrSingle Then
            lblTorque.Text = "ERROR:" & ErrMsg
            ErrMsg = ""
        Else
            lblTorque.Text = Torque.ToString("0.00")
            Torque = Math.Abs(Torque) * 1000
            If Torque < 0 Then
                pbrTorque.Value = 0
            ElseIf Torque > MaxTorque * 1000 Then
                pbrTorque.Value = MaxTorque
            Else
                pbrTorque.Value = Torque
            End If
        End If
    End Sub
    Private Sub cmdZeroThetaPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZeroThetaPos.Click
        'zeros the DRO for the actuator
        Dim ErrMsg As String = ""
        If ZeroPos(0, ErrMsg) Then
            stpStatusStrip.Text = "Zeroed...Idle."
        Else
            MsgBox(ErrMsg)
        End If
    End Sub
    Private Sub cmdEnableAxis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnableAxis.Click
        'enables/disables (toggles) axis 
        Dim ErrMsg As String = ""
        Dim AxisStatus As Byte
        AxisStatus = GetAxisStatus(0, ErrMsg)
        If AxisStatus = ErrByte Then
            MsgBox(ErrMsg)
        Else
            If AxisStatus Then
                If DisableAxis(0, ErrMsg) Then
                    cmdEnableAxis.Text = "Disable"
                Else
                    MsgBox(ErrMsg)
                End If
            Else
                If EnableAxis(0, ErrMsg) Then
                    cmdEnableAxis.Text = "Enable"
                Else
                    MsgBox(ErrMsg)
                End If
            End If
        End If

    End Sub
    Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click
        'homes actuator - almost even with bottom of actuator
        Dim ErrMsg As String = ""
        Do While GetLidStatus(ErrMsg) = 0
            If MsgBox("Lid must be up.  Ensure that lid is up and click OK to continue.  Click Cancel to abort move.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                stpStatusStrip.Text = "Home aborted by user...Idle."
                Exit Sub
            End If
        Loop
        ErrMsg = ""
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
        X = txtThetaPos.Text
        X = Math.Round(X, 2)
        If MoveActuator("X", X, True, ErrMsg) Then
            stpStatusStrip.Text = "Moved to " & X & "°...Idle."
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
        X = txtThetaPos.Text
        X = Math.Round(X, 2)
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub txtThetaPos_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThetaPos.Validated
        If Not IsNumeric(txtThetaPos.Text) Then
            MessageBox.Show("Distance must be numeric")
            txtThetaPos.Text = My.Settings.LastThetaPos
        End If
    End Sub
    Private Sub cmdMoveTenthCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveTenthCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 0.1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveOneCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveOneCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveTenCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveTenCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = 10
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveTenthCCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveTenthCCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -0.1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveOneCCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveOneCCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -1
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdMoveTenCCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveTenCCW.Click
        Dim ErrMsg As String = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = -10
        If MoveActuator("X", X, False, ErrMsg) Then
            stpStatusStrip.Text = "Moved " & X & "°...Idle."
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
        Dim ErrMsg As String = ""
        Dim T0 As Date = Now
        Dim TorqueMax, InitLoc As Single 'max force attained and initial position of actuator
        Dim MainDataFileFullPath As String = DataFilePath & "\" & DeviceID & " " & T0.ToString("yyyy-MM-dd HH-mm-ss.ff") & "-MAIN.txt"
        Dim TorqueDataFileFullPath As String = DataFilePath & "\" & DeviceID & " " & T0.ToString("yyyy-MM-dd HH-mm-ss.ff") & "-TORQUE.txt"
        'update UI
        UpdateUI("RUNNING")
        PauseFlag = False
        StopFlag = False
        cmdPauseResume.Text = "&Pause"
        lblTargetCycles.Text = IIf(EndOnCycles, NumCycles.ToString("n0"), "n/a")
        lblErrorCycles.Text = FixtureErrorCycles.ToString("n0")
        lblSuccessfulCycles.Text = SuccessfulCycles.ToString("n0")
        lblStartTime.Text = T0.ToString("yyyy-MM-dd HH-mm-ss.ff")
        chtTorqueVsDisp.Series.Clear()
        If GraphDisplay = 0 Then
            chtTorqueVsDisp.ChartAreas(0).AxisX.Title = "Displacement [degrees]"
        Else
            chtTorqueVsDisp.ChartAreas(0).AxisX.Title = "Distance [degrees]"
        End If
        Try
            Dim MainDataFile As New System.IO.StreamWriter(MainDataFileFullPath)
            MainDataFile.WriteLine("Device ID:" & ControlChars.Tab & DeviceID)
            MainDataFile.WriteLine("Start Time:" & ControlChars.Tab & T0.ToString("yyyy-MM-dd HH-mm-ss.ff"))
            MainDataFile.WriteLine("Operator:" & ControlChars.Tab & TestOperator)
            MainDataFile.WriteLine("Fixture ID:" & ControlChars.Tab & My.Settings.ACSIP)
            MainDataFile.WriteLine("Dwell Time [msec]:" & ControlChars.Tab & DwellTime)
            MainDataFile.WriteLine("Torque Limit [kgf-cm]:" & ControlChars.Tab & IIf(LimitTorque, TorqueLimit.ToString("n1"), MaxTorque.ToString("n1")))
            MainDataFile.WriteLine("Zero Position Before Test:" & ControlChars.Tab & IIf(ZeroPositionBeforeTest, "Yes", "No"))
            MainDataFile.WriteLine("Travel End Position:" & ControlChars.Tab & "Relative Postion (" & RelPos.ToString("n3") & " °)")
            MainDataFile.WriteLine("Test End Conditions:")
            MainDataFile.WriteLine(ControlChars.Tab & "Number of Cycles:" & ControlChars.Tab & IIf(EndOnCycles, NumCycles, "n/a"))
            MainDataFile.WriteLine(ControlChars.Tab & "Fixture Failures:" & ControlChars.Tab & IIf(EndOnFixtureFailLimit, FixtureFailureLimit, "n/a"))
            MainDataFile.WriteLine("Motion Parameters:")
            MainDataFile.WriteLine(ControlChars.Tab & "Velocity [°/s]:" & ControlChars.Tab & My.Settings.VelTheta.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Accel [°/s^2]:" & ControlChars.Tab & My.Settings.AccTheta.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Decel [°/s^2]:" & ControlChars.Tab & My.Settings.DecTheta.ToString("n1"))
            MainDataFile.WriteLine(ControlChars.Tab & "Jerk [°/s^3]: " & ControlChars.Tab & My.Settings.JerkTheta.ToString("n0"))
            MainDataFile.WriteLine(ControlChars.Tab & "Kill Decel [°/s^2]:" & ControlChars.Tab & My.Settings.KDecTheta.ToString("n0"))
            MainDataFile.WriteLine("")
            MainDataFile.WriteLine("Time/Date" & ControlChars.Tab & "Cycle Number" & ControlChars.Tab & "Max Torque (kgf-cm)" & ControlChars.Tab & "Status")
            MainDataFile.Flush()
            MainDataFile.Close()
            MainDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim TorqueDataFile As New System.IO.StreamWriter(TorqueDataFileFullPath)
            TorqueDataFile.WriteLine("Device ID:" & ControlChars.Tab & DeviceID)
            TorqueDataFile.WriteLine("Start Time:" & ControlChars.Tab & T0.ToString("yyyy-MM-dd HH-mm-ss.ff"))
            TorqueDataFile.WriteLine("")
            TorqueDataFile.Flush()
            TorqueDataFile.Close()
            TorqueDataFile.Dispose()
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

        
        Dim i As Integer = 1
        Dim TorqueArray
        If LimitTorque Then
            If SetTorqueLimit(0, TorqueLimit, ErrMsg) Then
            Else
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
            End If
        Else
            If SetTorqueLimit(0, MaxTorque, ErrMsg) Then
            Else
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
            End If
        End If

        Dim OffsetTheta As Single           'this is the angular spacing between the manipulators and DUT when the DUT is centered between the manipulators
        If DeviceType = CrystalHinge Then
            OffsetTheta = My.Settings.CrystalGapTheta
        ElseIf DeviceType = TempleHinge Then
            OffsetTheta = My.Settings.TempleGapTheta
        Else
            OffsetTheta = 0
        End If

        'each move will begin with the manipulator against the DUT.  so, we must move the DUT all the way one way, then move the manipulator against the DUT
        'in the case of the bidirectional test, we must first move the DUT all the way to one end of the motion (so that testing is not +/- theta, but + 2 * theta
        If MotionMode = CWUnidirectional Then   '
            If MoveActuator("X", -OffsetTheta, False, ErrMsg) Then
                stpStatusStrip.Text = "Moved to initial position...Idle."
            Else
                stpStatusStrip.Text = "Move error...Idle." & ErrMsg
                ErrMsg = ""
            End If
        ElseIf MotionMode = CCWUnidirectional Then
            If MoveActuator("X", OffsetTheta, False, ErrMsg) Then
                stpStatusStrip.Text = "Moved to initial position...Idle."
            Else
                stpStatusStrip.Text = "Move error...Idle." & ErrMsg
                ErrMsg = ""
            End If
        ElseIf MotionMode = Bidirectional Then 'if bidirectional move, move to one end of position
            If MoveActuator("X", -OffsetTheta - RelPos, False, ErrMsg) Then
                stpStatusStrip.Text = "Moved to initial position...Idle."
            Else
                stpStatusStrip.Text = "Move error...Idle." & ErrMsg
                ErrMsg = ""
            End If
        End If
        InitLoc = GetPos(0, ErrMsg)
        If InitLoc = ErrSingle Then
            MsgBox("ERROR:" & ErrMsg)
            ErrMsg = ""
        End If
        Do
            lblCurrentCycle.Text = i.ToString("n0")
            'run a cycle depending on the end travel condition
            If MotionMode = CWUnidirectional Then
                TorqueArray = TwistToPosition(InitLoc, DwellTime, OffsetTheta + RelPos, ErrMsg)
            ElseIf MotionMode = CCWUnidirectional Then
                TorqueArray = TwistToPosition(InitLoc, DwellTime, -OffsetTheta - RelPos, ErrMsg)
            ElseIf MotionMode = Bidirectional Then
                TorqueArray = TwistToPosition(InitLoc, DwellTime, OffsetTheta + 2 * RelPos, ErrMsg)
            End If

            If IsNumeric(TorqueArray) Then
                stpStatusStrip.Text = ErrMsg
                ErrMsg = ""
                FixtureErrorCycles = FixtureErrorCycles + 1
                GoTo CycleEnd
            End If
            If (i > 2) And (chtTorqueVsDisp.Series.Count > 1) Then          'remove all but the first force plot
                chtTorqueVsDisp.Series.RemoveAt(1)
            Else
                chtTorqueVsDisp.ChartAreas(0).Axes(1).IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount
            End If
            'add a new plot
            ProcessAndPlotTorqueData(TorqueArray, i, TorqueMax)
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
            'write line of data
            Try
                Dim MainDataFile As New System.IO.StreamWriter(MainDataFileFullPath, True)
                MainDataFile.WriteLine(Now.ToString("yyyy-MM-dd HH-mm-ss.ff") & ControlChars.Tab & i & ControlChars.Tab & IIf(IsNumeric(TorqueArray), "n/a", TorqueMax.ToString("n1")) & ControlChars.Tab & stpStatusStrip.Text)
                MainDataFile.Flush()
                MainDataFile.Close()
                MainDataFile.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Select Case DAQFrequency
                Case 0  'never
                Case 1  'every 1
                    RecordTorqueData(TorqueArray, i, TorqueMax, TorqueDataFileFullPath)
                Case 2  'every 10
                    If ((i - 1) Mod 10) = 0 Then
                        RecordTorqueData(TorqueArray, i, TorqueMax, TorqueDataFileFullPath)
                    End If
                Case 3  'every 100
                    If ((i - 1) Mod 100) = 0 Then
                        RecordTorqueData(TorqueArray, i, TorqueMax, TorqueDataFileFullPath)
                    End If
                Case 4  'every 1000
                    If ((i - 1) Mod 1000) = 0 Then
                        RecordTorqueData(TorqueArray, i, TorqueMax, TorqueDataFileFullPath)
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
                        RecordTorqueData(TorqueArray, i, TorqueMax, TorqueDataFileFullPath)
                    End If
            End Select
            'check for excessive failures
            If EndOnFixtureFailLimit And (FixtureErrorCycles >= FixtureFailureLimit) Then
                stpStatusStrip.Text = "Fixture failure limit exceeded."
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

        'move actuator back to original position
        MoveActuator("X", 0, True, ErrMsg)


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
            MainDataFile.Flush()
            MainDataFile.Close()
            MainDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        UpdateUI("IDLE")

    End Sub
    Sub ProcessAndPlotTorqueData(ByVal TorqueArray As Object, ByVal i As Integer, ByRef Torquemax As Single)
        Torquemax = Single.MinValue
        Dim ThetaMax = Single.MinValue
        Dim Torque As Single
        Dim Dist As Single = 0
        chtTorqueVsDisp.Series.Add("Cycle")
        chtTorqueVsDisp.Series("Cycle").ChartType = DataVisualization.Charting.SeriesChartType.Line
        chtTorqueVsDisp.Series("Cycle").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        chtTorqueVsDisp.Series("Cycle").MarkerStyle = DataVisualization.Charting.MarkerStyle.None
        'add the data to the series
        If GraphDisplay = 0 Then            'if plotting vs displacement
            For j = 0 To TorqueDataPoints - 1
                Torque = -TorqueArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleTorque * OzIn2KgfCm
                chtTorqueVsDisp.Series("Cycle").Points.AddXY(TorqueArray(j, 0), Torque)
                If Torque > Torquemax Then Torquemax = Torque
                If TorqueArray(j, 0) > Torquemax Then Torquemax = TorqueArray(j, 0)
            Next
        Else                                'else plotting vs distance
            For j = 0 To TorqueDataPoints - 1
                Torque = -TorqueArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleTorque * OzIn2KgfCm
                If j = 0 Then
                    Dist = TorqueArray(j, 0)
                Else
                    Dist = Dist + Math.Abs(TorqueArray(j, 0) - TorqueArray(j - 1, 0))
                End If
                chtTorqueVsDisp.Series("Cycle").Points.AddXY(Dist, Torque)
                If Torque > Torquemax Then Torquemax = Torque
                If Dist > ThetaMax Then ThetaMax = Dist
            Next
        End If
        If chtTorqueVsDisp.Series.Count = 1 Then
            chtTorqueVsDisp.Series(0).Color = Color.Red       'initial plot in red
            chtTorqueVsDisp.Series(0).Name = "First Cycle"
            'Select Case Torquemax
            '    Case Single.MinValue To 200
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Minimum = -25
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Interval = 25
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 25
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 5
            '    Case 200 To 400
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Minimum = -50
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Interval = 50
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 50
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 10
            '    Case 400 To 600
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Minimum = -50
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Interval = 100
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 100
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 25
            '    Case 600 To Single.MaxValue
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Minimum = -50
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.Interval = 100
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MajorGrid.Interval = 100
            '        chtTorqueVsDisp.ChartAreas(0).AxisY.MinorGrid.Interval = 50
            'End Select
            'Select Case ThetaMax
            '    Case Single.MinValue To 0.1
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 0.02
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.02
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.005
            '    Case 0.1 To 0.2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 0.04
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.04
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.01
            '    Case 0.2 To 0.5
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 0.1
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.1
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.02
            '    Case 0.5 To 1.0
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 0.2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.05
            '    Case 1 To 2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 0.4
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 0.4
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.1
            '    Case 2 To 5
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 1
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 1
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.2
            '    Case 5 To 10
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.Interval = 2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MajorGrid.Interval = 2
            '        chtTorqueVsDisp.ChartAreas(0).AxisX.MinorGrid.Interval = 0.5
            'End Select
        ElseIf chtTorqueVsDisp.Series.Count > 1 Then
            chtTorqueVsDisp.Series(1).Color = Color.Blue      'all other plots in blue
            chtTorqueVsDisp.Series(1).Name = "Previous Cycle"
        End If

    End Sub
    Sub RecordTorqueData(ByVal TorqueArray As Object, ByVal i As Integer, ByRef Torquemax As Single, ByVal TorqueDataFileFullPath As String)
        Dim Tmp As Single
        Try

            Dim TorqueDataFile As New System.IO.StreamWriter(TorqueDataFileFullPath, True)
            TorqueDataFile.Write("Cycle " & i & " Z" & ControlChars.Tab)
            If IsNumeric(TorqueArray) Then
                TorqueDataFile.WriteLine("n/a")
            Else
                For j = 0 To TorqueDataPoints - 1
                    Tmp = TorqueArray(j, 0)
                    TorqueDataFile.Write(Tmp.ToString("n1") & ControlChars.Tab)
                Next
                TorqueDataFile.WriteLine("")
            End If
            TorqueDataFile.Write("Cycle " & i & " Torque" & ControlChars.Tab)
            If IsNumeric(TorqueArray) Then
                TorqueDataFile.WriteLine("n/a")
            Else
                For j = 0 To TorqueDataPoints - 1
                    Tmp = -TorqueArray(j, 1) / My.Settings.AIRes * My.Settings.FullScaleTorque * OzIn2KgfCm
                    TorqueDataFile.Write(Tmp.ToString("n3") & ControlChars.Tab)
                Next
                TorqueDataFile.WriteLine("")
            End If
            TorqueDataFile.Flush()
            TorqueDataFile.Close()
            TorqueDataFile.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdSendConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendConfig.Click
        Dim ErrMsg As String = ""
        If SendMotionConfig("X", My.Settings.VelTheta, My.Settings.AccTheta, My.Settings.DecTheta, My.Settings.JerkTheta, My.Settings.KDecTheta, My.Settings.HomeVelTheta, ErrMsg) Then
            If SetTorqueLimit(0, MaxTorque, ErrMsg) Then
                UpdateUI("IDLE")
            Else
                UpdateUI("DISABLED")
                MsgBox("Invalid Torque limit!  Check configuration and retry." & Chr(10) & ErrMsg)
            End If
        Else
            UpdateUI("DISABLED")
            MsgBox("Invalid motion parameters!  Check configuration and retry." & Chr(10) & ErrMsg)
        End If
    End Sub
    Private Sub cmdCrystalHingeNeutral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrystalHingeNeutral.Click
        Dim ErrMsg As String = ""
        Do While GetLidStatus(ErrMsg) = 0
            If MsgBox("Lid must be up.  Ensure that lid is up and click OK to continue.  Click Cancel to abort move.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                stpStatusStrip.Text = "Move aborted by user...Idle."
                Exit Sub
            End If
        Loop
        ErrMsg = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Homing..."
        If Home("X", ErrMsg) Then
            stpStatusStrip.Text = "Homed...Idle."
        Else
            stpStatusStrip.Text = "Homing error...Idle." & ErrMsg
        End If
        ErrMsg = ""
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = My.Settings.CrystalNeutralTheta
        If MoveActuator("X", X, True, ErrMsg) Then
            stpStatusStrip.Text = "Moved to neutral position for crystal hinge...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub CmdTempleHingeNeutral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTempleHingeNeutral.Click
        Dim ErrMsg As String = ""
        Do While GetLidStatus(ErrMsg) = 0
            If MsgBox("Lid must be up.  Ensure that lid is up and click OK to continue.  Click Cancel to abort move.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                stpStatusStrip.Text = "Move aborted by user...Idle."
                Exit Sub
            End If
        Loop
        ErrMsg = ""
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        UpdateUI("MOVING")
        stpStatusStrip.Text = "Homing..."
        If Home("X", ErrMsg) Then
            stpStatusStrip.Text = "Homed...Idle."
        Else
            stpStatusStrip.Text = "Homing error...Idle." & ErrMsg
        End If
        ErrMsg = ""
        stpStatusStrip.Text = "Moving..."
        Dim X As Single = My.Settings.TempleNeutralTheta
        If MoveActuator("X", X, True, ErrMsg) Then
            stpStatusStrip.Text = "Moved to neutral position for temple hinge...Idle."
        Else
            stpStatusStrip.Text = "Move error...Idle." & ErrMsg
        End If
        UpdateUI("IDLE")
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdResetToDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetToDefaults.Click
        Dim ErrMsg As String = ""
        My.Settings.VelTheta = My.Settings.DefaultVelTheta
        My.Settings.AccTheta = My.Settings.DefaultAccTheta
        My.Settings.DecTheta = My.Settings.DefaultDecTheta
        My.Settings.JerkTheta = My.Settings.DefaultJerkTheta
        My.Settings.KDecTheta = My.Settings.DefaultKDecTheta
        My.Settings.CrystalNeutralTheta = My.Settings.DefaultCrystalNeutralTheta
        My.Settings.TempleNeutralTheta = My.Settings.DefaultTempleNeutralTheta
        My.Settings.CrystalGapTheta = My.Settings.DefaultCrystalGapTheta
        My.Settings.TempleGapTheta = My.Settings.DefaultTempleGapTheta
        If SendMotionConfig("X", My.Settings.VelTheta, My.Settings.AccTheta, My.Settings.DecTheta, My.Settings.JerkTheta, My.Settings.KDecTheta, My.Settings.HomeVelTheta, ErrMsg) Then
            If SetTorqueLimit(0, MaxTorque, ErrMsg) Then
                UpdateUI("IDLE")
            Else
                UpdateUI("DISABLED")
                MsgBox("Invalid Torque limit!  Check configuration and retry." & Chr(10) & ErrMsg)
            End If
        Else
            UpdateUI("DISABLED")
            MsgBox("Invalid motion parameters!  Check configuration and retry." & Chr(10) & ErrMsg)
        End If
    End Sub
End Class
