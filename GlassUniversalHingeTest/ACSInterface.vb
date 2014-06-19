Imports SPIIPLUSCOM660Lib
Module ACSInterface
    Private Ch As SPIIPLUSCOM660Lib.Channel
    Public Const ErrSingle As Single = -9999        'err value for functions that return single values
    Public Const ErrByte As Byte = 2                'err value for functions that return byte values
    Public Const OzIn2KgfCm As Single = 0.072007788932      'conversion from Oz-in to Kgf-cm
    Public Const MaxTorque As Single = 50 * OzIn2KgfCm  'max torque of torque transducer (must match upper calibration value for FUTEK)
    Public Const TorqueDataPoints As Integer = 1000   'must match ACS script NRawSamples/Discard rate (5000/5)
    Public TorqueConversionFactor As Single = -1 / My.Settings.FullScaleVoltage / My.Settings.AIScale * My.Settings.FullScaleTorque * OzIn2KgfCm
    Public Const m As Single = 0.1489               'XCURV vs torque - check excel spreadsheet for this value
    Public Const b As Single = 0.225               'XCURV vs torque- check excel spreadsheet for this value
    Public Const NominalMinTorque As Single = 0.5    'minimum torque corresponding to XCURV that permits motion
    Public Const NominalMaxTorque As Single = 3.6   'round number near maxtorque
    Public Const Ticks2ms As Integer = 10000        'number of ticks per ms


    Public Function ConnectACS(ByRef ErrMsg As String) As Boolean
        'initiates communication with ACS controller
        Try
            Ch = New SPIIPLUSCOM660Lib.Channel
            Ch.OpenCommEthernet(My.Settings.ACSIP, Ch.ACSC_SOCKET_DGRAM_PORT)
        Catch ex As Exception
            ErrMsg = ex.Message
            ConnectACS = False
            Exit Function
        End Try
        ConnectACS = True
    End Function
    Public Function DisconnectACS(ByRef ErrMsg As String) As Boolean
        'disconnects ACS controller, kills all terminations except for MMI
        Dim HandlesList, AppNamesList, ProcessIDList As Object
        Dim i, NumCons As Integer
        Try
            Ch.CloseComm()
            NumCons = Ch.GetConnectionsList(HandlesList, AppNamesList, ProcessIDList)
            For i = 0 To NumCons - 1
                If InStr(AppNamesList(i), "ACS.Framework.exe") = 0 Then
                    Ch.TerminateConnection(HandlesList(i), AppNamesList(i))
                End If
            Next
        Catch ex As Exception
            ErrMsg = ex.Message
            DisconnectACS = False
            Exit Function
        End Try
        DisconnectACS = True
    End Function
    Public Function Home(ByVal Axis As String, ByVal IndextoNoon As Single, ByRef ErrMsg As String) As Boolean
        'Homes actuator
        Dim T0 As Long = Date.Now.Ticks
        Dim BufNum As Integer = 1
        Select Case Axis
            Case "X"
                Ch.WriteVariable(0, "AXIS", Ch.ACSC_NONE)
            Case "Y"
                Ch.WriteVariable(1, "AXIS", Ch.ACSC_NONE)
            Case "Z"
                Ch.WriteVariable(2, "AXIS", Ch.ACSC_NONE)
        End Select
        Ch.WriteVariable(IndextoNoon, "INDEXTONOON", Ch.ACSC_NONE)
        Ch.StopBuffer(BufNum)
        Ch.CompileBuffer(BufNum)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
        Loop Until (Date.Now.Ticks - T0 > My.Settings.LongTimeOut) Or (Ch.ReadVariable("RunStatus", BufNum) <> -1)
        If Ch.ReadVariable("RunStatus", BufNum) = 0 Then
            Home = True
        ElseIf Ch.ReadVariable("RunStatus", BufNum) = -1 Then
            ErrMsg = "Home error: Timed out!"
            Home = False
        Else
            ErrMsg = "Home error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            Home = False
        End If
    End Function
    Public Function MoveActuator(ByVal Axis As String, ByVal Distance As Single, ByVal Absolute As Boolean, ByRef ErrMsg As String) As Boolean
        'moves actuator a fixed amount
        Dim BufNum As Integer = 3
        Dim T0 As Long = Date.Now.Ticks
        Debug.Print("to:" & T0)
        Select Case Axis
            Case "X"
                Ch.WriteVariable(0, "AXIS", Ch.ACSC_NONE)
            Case "Y"
                Ch.WriteVariable(1, "AXIS", Ch.ACSC_NONE)
            Case "Z"
                Ch.WriteVariable(2, "AXIS", Ch.ACSC_NONE)
        End Select
        Ch.WriteVariable(Distance, "DIST", Ch.ACSC_NONE)
        If Absolute Then
            Ch.WriteVariable(1, "ABSOLUTE", Ch.ACSC_NONE)
        Else
            Ch.WriteVariable(0, "ABSOLUTE", Ch.ACSC_NONE)
        End If
        Ch.StopBuffer(BufNum)
        Ch.CompileBuffer(BufNum)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
            Debug.Print(Date.Now.Ticks)
        Loop Until (Date.Now.Ticks - T0 > My.Settings.LongTimeOut) Or (Ch.ReadVariable("RunStatus", BufNum) <> -1)
        If Ch.ReadVariable("RunStatus", BufNum) = 0 Then
            MoveActuator = True
        ElseIf Ch.ReadVariable("RunStatus", BufNum) = -1 Then
            ErrMsg = "Move error: Timed out!"
            MoveActuator = False
        Else
            ErrMsg = "Move error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            MoveActuator = False
        End If
    End Function
    Public Function GetPos(ByVal Axis As Byte, ByRef ErrMsg As String) As Single
        'gets actuator's position
        Dim Pos As Single
        Try
            Pos = Ch.GetFPosition(Axis)
        Catch ex As Exception
            ErrMsg = ex.Message
            GetPos = ErrSingle
            Exit Function
        End Try
        GetPos = Pos
    End Function
    Public Function ZeroPos(ByVal Axis As Byte, ByRef ErrMsg As String) As Boolean
        'zeros the actuators position
        Try
            Ch.SetFPosition(Axis, 0)
        Catch ex As Exception
            ErrMsg = ex.Message
            ZeroPos = False
            Exit Function
        End Try
        ZeroPos = True
    End Function
    Public Function SetTorqueLimit(ByVal Axis As Byte, ByVal TorqueLimit As Single, ByRef ErrMsg As String) As Boolean
        '"************THIS NEEDS FIXING, ANALYSIS, CALIBRATION, ETC--ALSO SEE THE CONSTS SECTION!!!

        'limits the force the actuator can apply.  this is not a hard limit--there is some tolerance on this value
        Try
            If TorqueLimit > MaxTorque Then
                TorqueLimit = MaxTorque
            End If
            Ch.Transaction("XCURV" & Axis & " = " & (TorqueLimit - b) / m)
            Ch.Transaction("XCURI" & Axis & " = " & (TorqueLimit - b) / m)
        Catch ex As Exception
            ErrMsg = ex.Message
            SetTorqueLimit = False
            Exit Function
        End Try
        SetTorqueLimit = True
    End Function
    Public Function SendMotionConfig(ByVal Axis As String, ByVal Vel As Single, ByVal Acc As Single, ByVal Dec As Single, ByVal Jerk As Single, _
                        ByVal KDec As Single, ByVal HomeVel As Single, ByRef ErrMsg As String) As Boolean
        'sends motion parameters (velocity, acceleration, etc)
        Try
            Select Case Axis
                Case "X"
                    Ch.WriteVariable(0, "AXIS", Ch.ACSC_NONE)
                Case "Y"
                    Ch.WriteVariable(1, "AXIS", Ch.ACSC_NONE)
                Case "Z"
                    Ch.WriteVariable(2, "AXIS", Ch.ACSC_NONE)
            End Select
            Ch.WriteVariable(Vel, "VELX", Ch.ACSC_NONE)
            Ch.WriteVariable(Acc, "ACCX", Ch.ACSC_NONE)
            Ch.WriteVariable(Dec, "DECX", Ch.ACSC_NONE)
            Ch.WriteVariable(Jerk, "JERKX", Ch.ACSC_NONE)
            Ch.WriteVariable(KDec, "KDECX", Ch.ACSC_NONE)
            Ch.WriteVariable(HomeVel, "HOMEVELX", Ch.ACSC_NONE)
        Catch ex As Exception
            ErrMsg = ex.Message
            SendMotionConfig = False
            Exit Function
        End Try
        SendMotionConfig = True
    End Function
    Public Function GetTorque(ByRef ErrMsg As String) As Single
        'gets the force from the force transducer
        Dim Torque As Single
        Try
            Torque = Ch.Transaction("?AIN0")
        Catch ex As Exception
            ErrMsg = ex.Message
            GetTorque = ErrSingle
            Exit Function
        End Try
        GetTorque = Torque * TorqueConversionFactor
    End Function
    Public Function GetLidStatus(ByRef ErrMsg As String) As Byte
        'checks whether the Lid is closed or not
        Dim ButtonStatus As Byte
        Try
            ButtonStatus = Ch.Transaction("?IN0.0")
        Catch ex As Exception
            ErrMsg = ex.Message
            GetLidStatus = ErrByte
            Exit Function
        End Try
        GetLidStatus = ButtonStatus
    End Function
    Public Function EnableAxis(ByVal Axis As Byte, ByRef ErrMsg As String) As Boolean
        'enables the axis
        Try
            Ch.Enable(Axis)
        Catch ex As Exception
            ErrMsg = ex.Message
            EnableAxis = False
            Exit Function
        End Try
        EnableAxis = True
    End Function
    Public Function DisableAxis(ByVal Axis As Byte, ByRef ErrMsg As String) As Boolean
        'disables the axis
        Try
            Ch.Disable(Axis)
        Catch ex As Exception
            ErrMsg = ex.Message
            DisableAxis = False
            Exit Function
        End Try
        DisableAxis = True
    End Function
    Public Function GetAxisStatus(ByVal Axis As Byte, ByRef ErrMsg As String) As Byte
        'gets the axis state (enabled or disabled?)
        Dim AxisStatus As Byte
        Try
            AxisStatus = Ch.Transaction("?MST0.0")
            'Debug.Print(AxisStatus)
        Catch ex As Exception
            ErrMsg = ex.Message
            GetAxisStatus = ErrByte
            Exit Function
        End Try
        GetAxisStatus = AxisStatus
    End Function
    Public Function TwistToPosition(ByVal InitLoc As Single, ByVal DwellTime As Integer, ByVal ThetaPos As Single, ByRef ErrMsg As String) As Object
        'presses the DUT until a position is met 
        Dim BufNum As Integer = 2
        Dim RunStatus As Integer
        Ch.WriteVariable(InitLoc, "INITLOC", Ch.ACSC_NONE)
        Ch.WriteVariable(DwellTime, "DWELLTIME", Ch.ACSC_NONE)
        Ch.WriteVariable(My.Settings.ShortTimeOut / Ticks2ms, "TIMEOUT", Ch.ACSC_NONE)
        Ch.WriteVariable(ThetaPos, "THETAPOS", Ch.ACSC_NONE)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
            RunStatus = Ch.ReadVariable("RunStatus", BufNum)
        Loop Until (RunStatus <> -1)
        If RunStatus = 0 Then
            TwistToPosition = Ch.ReadVariableAsMatrix("TORQUEDATACOLUMN", BufNum)
        ElseIf RunStatus = -2 Then
            ErrMsg = "Actuation error: Travel end condition not met!"
            TwistToPosition = False
        ElseIf RunStatus = -1 Then
            ErrMsg = "Actuation error: Timed out!"
            TwistToPosition = False
        Else
            ErrMsg = "Actuation error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            TwistToPosition = False
        End If
    End Function
  
End Module
