
Imports SPIIPLUSCOM660Lib
Module ACSInterface
    Private Ch As SPIIPLUSCOM660Lib.Channel
    Public Const ErrSingle As Single = -9999        'err value for functions that return single values
    Public Const ErrByte As Byte = 2                'err value for functions that return byte values
    Public Const Lbs2Grams As Single = 453.592      'conversion from lbs to grams
    Public Const MaxForce As Single = 3 * Lbs2Grams 'max force of force transducer (must match upper calibration value for FUTEK)
    Public Const ForceDataPoints As Integer = 1000   'must match ACS script NRawSamples/Discard rate (5000/5)
    Public ForceConversionFactor As Single = -1 / My.Settings.FullScaleVoltage / My.Settings.AIScale * My.Settings.FullScaleForce * Lbs2Grams
    Public Const m As Single = 111.37               'XCURV vs force - check excel spreadsheet for this value
    Public Const b As Single = 208.47               'XCURV vs force - check excel spreadsheet for this value
    Public Const NominalMinForce As Single = 420    'minimum force corresponding to XCURV that permits motion
    Public Const NominalMaxForce As Single = 1350   'round number near 3lbs
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
    Public Function Home(ByVal Axis As String, ByRef ErrMsg As String) As Boolean
        'Homes actuator
        Dim T0 As Long = Date.Now.Ticks
        Dim BufNum As Integer = 0
        Select Case Axis
            Case "X"
                Ch.WriteVariable(0, "AXIS", Ch.ACSC_NONE)
            Case "Y"
                Ch.WriteVariable(1, "AXIS", Ch.ACSC_NONE)
            Case "Z"
                Ch.WriteVariable(2, "AXIS", Ch.ACSC_NONE)
        End Select
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
    Public Function SetForceLimit(ByVal Axis As Byte, ByVal ForceLimit As Single, ByRef ErrMsg As String) As Boolean
        'limits the force the actuator can apply.  this is not a hard limit--there is some tolerance on this value
        Try
            If ForceLimit > MaxForce Then
                ForceLimit = MaxForce
            End If
            Ch.Transaction("XCURV" & Axis & " = " & (ForceLimit - b) / m)
            Ch.Transaction("XCURI" & Axis & " = " & (ForceLimit - b) / m)
        Catch ex As Exception
            ErrMsg = ex.Message
            SetForceLimit = False
            Exit Function
        End Try
        SetForceLimit = True
    End Function
    Public Function SendMotionConfig(ByVal Axis As String, ByVal Vel As Single, ByVal Acc As Single, ByVal Dec As Single, ByVal Jerk As Single, _
                        ByVal KDec As Single, ByRef ErrMsg As String) As Boolean
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
        Catch ex As Exception
            ErrMsg = ex.Message
            SendMotionConfig = False
            Exit Function
        End Try
        SendMotionConfig = True
    End Function
    Public Function GetForce(ByRef ErrMsg As String) As Single
        'gets the force from the force transducer
        Dim Force As Single
        Try
            Force = Ch.Transaction("?AIN0")
        Catch ex As Exception
            ErrMsg = ex.Message
            GetForce = ErrSingle
            Exit Function
        End Try
        GetForce = Force * ForceConversionFactor
    End Function
    Public Function GetButtonStatus(ByRef ErrMsg As String) As Byte
        'checks whether the button is closed or not
        Dim ButtonStatus As Byte
        Try
            ButtonStatus = Ch.Transaction("?IN0.0")
        Catch ex As Exception
            ErrMsg = ex.Message
            GetButtonStatus = ErrByte
            Exit Function
        End Try
        GetButtonStatus = ButtonStatus
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
    Public Function PressToFTarget(ByVal InitLoc As Single, ByVal FTarget As Single, ByVal DwellTime As Integer, ByRef ZFTarget As Single, _
                                   ByRef ButtonClosed As Boolean, ByRef ButtonOpen As Boolean, ByRef ErrMsg As String) As Object
        'presses the DUT until a force is met (as measured by force transducer)
        Dim BufNum As Integer = 1
        Dim RunStatus As Integer
        Ch.WriteVariable(InitLoc, "INITLOC", Ch.ACSC_NONE)
        Ch.WriteVariable(FTarget / Lbs2Grams / My.Settings.FullScaleForce * My.Settings.FullScaleVoltage * My.Settings.AIScale, "FTARGET", Ch.ACSC_NONE)
        Ch.WriteVariable(DwellTime, "DWELLTIME", Ch.ACSC_NONE)
        Ch.WriteVariable(My.Settings.ShortTimeOut / Ticks2ms, "TIMEOUT", Ch.ACSC_NONE)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
            RunStatus = Ch.ReadVariable("RunStatus", BufNum)
        Loop Until (RunStatus <> -1)
        If RunStatus = 0 Then
            ZFTarget = Ch.ReadVariable("ZFTARGET", Ch.ACSC_NONE)
            ButtonClosed = Ch.ReadVariable("BUTTONCLOSED", Ch.ACSC_NONE)
            ButtonOpen = Ch.ReadVariable("BUTTONOPEN", Ch.ACSC_NONE)
            PressToFTarget = Ch.ReadVariableAsMatrix("FORCEDATACOLUMN", BufNum)
        ElseIf RunStatus = -2 Then
            ErrMsg = "Actuation error: Down travel end condition not met!"
            PressToFTarget = False
        ElseIf RunStatus = -1 Then
            ErrMsg = "Actuation error: Timed out!"
            PressToFTarget = False
        Else
            ErrMsg = "Actuation error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            PressToFTarget = False
        End If
    End Function
    Public Function PressToPosition(ByVal InitLoc As Single, ByVal DwellTime As Integer, ByVal ZPos As Single, ByRef ButtonClosed As Boolean, _
                                    ByRef ButtonOpen As Boolean, ByRef ErrMsg As String) As Object
        'presses the DUT until a position is met 
        Dim BufNum As Integer = 4
        Dim RunStatus As Integer
        Ch.WriteVariable(InitLoc, "INITLOC", Ch.ACSC_NONE)
        Ch.WriteVariable(DwellTime, "DWELLTIME", Ch.ACSC_NONE)
        Ch.WriteVariable(My.Settings.ShortTimeOut / Ticks2ms, "TIMEOUT", Ch.ACSC_NONE)
        Ch.WriteVariable(ZPos, "ZPOS", Ch.ACSC_NONE)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
            RunStatus = Ch.ReadVariable("RunStatus", BufNum)
        Loop Until (RunStatus <> -1)
        If RunStatus = 0 Then
            ButtonClosed = Ch.ReadVariable("BUTTONCLOSED", Ch.ACSC_NONE)
            ButtonOpen = Ch.ReadVariable("BUTTONOPEN", Ch.ACSC_NONE)
            PressToPosition = Ch.ReadVariableAsMatrix("FORCEDATACOLUMN", BufNum)
        ElseIf RunStatus = -2 Then
            ErrMsg = "Actuation error: Down travel end condition not met!"
            PressToPosition = False
        ElseIf RunStatus = -1 Then
            ErrMsg = "Actuation error: Timed out!"
            PressToPosition = False
        Else
            ErrMsg = "Actuation error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            PressToPosition = False
        End If
    End Function
    Public Function PressToClosure(ByVal InitLoc As Single, ByVal DwellTime As Integer, ByRef ButtonClosed As Boolean, _
                                   ByRef ButtonOpen As Boolean, ByRef ErrMsg As String) As Object
        'presses the DUT until switch is closed
        Dim BufNum As Integer = 5
        Dim RunStatus As Integer
        Ch.WriteVariable(InitLoc, "INITLOC", Ch.ACSC_NONE)
        Ch.WriteVariable(DwellTime, "DWELLTIME", Ch.ACSC_NONE)
        Ch.WriteVariable(My.Settings.ShortTimeOut / Ticks2ms, "TIMEOUT", Ch.ACSC_NONE)
        Ch.RunBuffer(BufNum)
        Do
            Application.DoEvents()
            RunStatus = Ch.ReadVariable("RunStatus", BufNum)
        Loop Until (RunStatus <> -1)
        If RunStatus = 0 Then
            ButtonClosed = Ch.ReadVariable("BUTTONCLOSED", Ch.ACSC_NONE)
            ButtonOpen = Ch.ReadVariable("BUTTONOPEN", Ch.ACSC_NONE)
            PressToClosure = Ch.ReadVariableAsMatrix("FORCEDATACOLUMN", BufNum)
        ElseIf RunStatus = -2 Then
            ErrMsg = "Actuation error: Down travel end condition not met!"
            PressToClosure = False
        ElseIf RunStatus = -1 Then
            ErrMsg = "Actuation error: Timed out!"
            PressToClosure = False
        Else
            ErrMsg = "Actuation error: " & Ch.GetErrorString(Ch.ReadVariable("RunStatus", BufNum))
            PressToClosure = False
        End If
    End Function

End Module
