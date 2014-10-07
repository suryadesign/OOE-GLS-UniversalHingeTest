Public Class frmTestInput
    Private Sub cmdShowFolderDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fbdDataFilePath.ShowDialog()
        txtDataFilePath.Text = fbdDataFilePath.SelectedPath
    End Sub
    Private Sub frmTestInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Settings.ACSIP & " - " & My.Settings.DUTType & " Hinge" & " Test Information..."
        'Load previous values from settings
        txtDevID.Text = My.Settings.LastDeviceID
        txtOperator.Text = My.Settings.LastOperator
        numDwellTime.Value = My.Settings.LastDwellTime
        chkLimitTorque.Checked = My.Settings.LastLimitTorque
        txtTorqueLimit.Text = My.Settings.LastTorqueLimit
        Select Case My.Settings.LastDeviceType
            Case frmMain.CrystalHinge
                rdoCrystalHinge.Checked = True
            Case frmMain.FrameHinge
                rdoFrameHinge.Checked = True
        End Select
        Select Case My.Settings.LastDAQFrequency
            Case frmMain.DAQNever
                rdoDAQNever.Checked = True
            Case frmMain.DAQEvery1
                rdoDAQEvery1.Checked = True
            Case frmMain.DAQEvery10
                rdoDAQEvery10.Checked = True
            Case frmMain.DAQEvery100
                rdoDAQEvery100.Checked = True
            Case frmMain.DAQEvery1000
                rdoDAQEvery1000.Checked = True
            Case frmMain.DAQProgInt
                rdoDAQProgInt.Checked = True
        End Select
        txtDataFilePath.Text = My.Settings.LastDataFilePath

        Select Case My.Settings.LastTravelEndCondition
            Case frmMain.EndTravelRelPos
                rdoEndTravelRelPos.Checked = True
            Case frmMain.EndTravelTargetTorque
                rdoEndTravelTargetTorque.Checked = True
        End Select
        txtRelPos.Text = My.Settings.LastRelPos
        txtTargetTorque.Text = My.Settings.LastTargetTorque

        Select Case My.Settings.LastMotionMode
            Case frmMain.CWUnidirectional
                rdoUnidirectionalCW.Checked = True
            Case frmMain.CCWUnidirectional
                rdoUnidirectionalCCW.Checked = True
            Case frmMain.Bidirectional
                rdoBidirectional.Checked = True
        End Select
        chkEndOnCycles.Checked = My.Settings.LastEndOnCycles
        chkFixtureErrorCyles.Checked = My.Settings.LastEndOnFixtureErrorCycles
        txtNumCycles.Value = My.Settings.LastNumCycles
        txtFixtureErrorCyles.Value = My.Settings.LastFixtureErrorCyles
        Select Case My.Settings.LastGraphDisplay
            Case frmMain.GraphDisplacement
                rdoDisplacement.Checked = True
            Case frmMain.GraphDistance
                rdoDistance.Checked = True
        End Select

    End Sub
    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        'save current options to settings
        My.Settings.LastDeviceID = txtDevID.Text
        My.Settings.LastOperator = txtOperator.Text
        My.Settings.LastDwellTime = numDwellTime.Value
        My.Settings.LastLimitTorque = chkLimitTorque.Checked
        My.Settings.LastTorqueLimit = txtTorqueLimit.Text
        If rdoCrystalHinge.Checked Then My.Settings.LastDeviceType = frmMain.CrystalHinge
        If rdoFrameHinge.Checked Then My.Settings.LastDeviceType = frmMain.FrameHinge
        If rdoDAQNever.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQNever
        If rdoDAQEvery1.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery1
        If rdoDAQEvery10.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery10
        If rdoDAQEvery100.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery100
        If rdoDAQEvery1000.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery1000
        If rdoDAQProgInt.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQProgInt
        My.Settings.LastDataFilePath = txtDataFilePath.Text
        If rdoEndTravelRelPos.Checked Then My.Settings.LastTravelEndCondition = frmMain.EndTravelRelPos
        If rdoEndTravelTargetTorque.Checked Then My.Settings.LastTravelEndCondition = frmMain.EndTravelTargetTorque
        My.Settings.LastRelPos = txtRelPos.Text
        My.Settings.LastTargetTorque = txtTargetTorque.Text
        If rdoUnidirectionalCW.Checked Then My.Settings.LastMotionMode = frmMain.CWUnidirectional
        If rdoUnidirectionalCCW.Checked Then My.Settings.LastMotionMode = frmMain.CCWUnidirectional
        If rdoBidirectional.Checked Then My.Settings.LastMotionMode = frmMain.Bidirectional
        My.Settings.LastEndOnCycles = chkEndOnCycles.Checked
        My.Settings.LastEndOnFixtureErrorCycles = chkFixtureErrorCyles.Checked
        My.Settings.LastNumCycles = txtNumCycles.Value
        My.Settings.LastFixtureErrorCyles = txtFixtureErrorCyles.Value
        If rdoDisplacement.Checked Then My.Settings.LastGraphDisplay = frmMain.GraphDisplacement
        If rdoDistance.Checked Then My.Settings.LastGraphDisplay = frmMain.GraphDistance
        My.Settings.Save()

        'pass options to main program
        frmMain.DeviceID = txtDevID.Text
        frmMain.TestOperator = txtOperator.Text
        frmMain.DwellTime = numDwellTime.Value
        frmMain.LimitTorque = chkLimitTorque.Checked
        frmMain.TorqueLimit = txtTorqueLimit.Text
        If rdoCrystalHinge.Checked Then frmMain.DeviceType = frmMain.CrystalHinge
        If rdoFrameHinge.Checked Then frmMain.DeviceType = frmMain.FrameHinge
        If rdoDAQNever.Checked Then frmMain.DAQFrequency = frmMain.DAQNever
        If rdoDAQEvery1.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery1
        If rdoDAQEvery10.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery10
        If rdoDAQEvery100.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery100
        If rdoDAQEvery1000.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery1000
        If rdoDAQProgInt.Checked Then frmMain.DAQFrequency = frmMain.DAQProgInt
        frmMain.DataFilePath = txtDataFilePath.Text
        If rdoEndTravelRelPos.Checked Then frmMain.TravelEndCondition = frmMain.EndTravelRelPos
        If rdoEndTravelTargetTorque.Checked Then frmMain.TravelEndCondition = frmMain.EndTravelTargetTorque
        frmMain.RelPos = txtRelPos.Text
        frmMain.TargetTorque = txtTargetTorque.Text
        If rdoUnidirectionalCW.Checked Then frmMain.MotionMode = frmMain.CWUnidirectional
        If rdoUnidirectionalCCW.Checked Then frmMain.MotionMode = frmMain.CCWUnidirectional
        If rdoBidirectional.Checked Then frmMain.MotionMode = frmMain.Bidirectional
        frmMain.EndOnCycles = chkEndOnCycles.Checked
        frmMain.EndOnFixtureFailLimit = chkFixtureErrorCyles.Checked
        frmMain.NumCycles = txtNumCycles.Value
        frmMain.FixtureFailureLimit = txtFixtureErrorCyles.Value
        If rdoDisplacement.Checked Then frmMain.GraphDisplay = frmMain.GraphDisplacement
        If rdoDistance.Checked Then frmMain.GraphDisplay = frmMain.GraphDistance
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub numDwellTime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDwellTime.Validated
        If numDwellTime.Value <= 0 Then
            MessageBox.Show("Dwell time must be greater than zero.")
            numDwellTime.Value = 1
        End If
    End Sub
    Private Sub txtRelPos_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRelPos.Validated
        If Not IsNumeric(txtRelPos.Text) Then
            MessageBox.Show("Relative position must be numeric.")
            txtRelPos.Text = My.Settings.LastRelPos
        Else
            If txtRelPos.Text <= 0 Then
                MessageBox.Show("Relative position must be greater than zero.")
                txtRelPos.Text = 0.01
            End If
        End If
    End Sub
    Private Sub txtNumCycles_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumCycles.Validated
        If txtNumCycles.Value <= 0 Then
            MessageBox.Show("Number of cycles must be greater than zero.")
            txtNumCycles.Value = 1
        End If
    End Sub
    Private Sub txtFixtureErrorCyles_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFixtureErrorCyles.Validated
        If txtFixtureErrorCyles.Value <= 0 Then
            MessageBox.Show("Number of cycles must be greater than zero.")
            txtFixtureErrorCyles.Value = 1
        End If
    End Sub
    Private Sub cmdShowFolderDialog_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fbdDataFilePath.ShowDialog()
        txtDataFilePath.Text = fbdDataFilePath.SelectedPath
    End Sub
    Private Sub txtTorqueLimit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTorqueLimit.Validated
        If Not IsNumeric(txtTorqueLimit.Text) Then
            MessageBox.Show("Torque limit must be numeric.")
            txtTorqueLimit.Text = My.Settings.LastTorqueLimit
        Else
            If txtTorqueLimit.Text < NominalMinTorque Then
                MessageBox.Show("Torque limit must be greater than " & NominalMinTorque.ToString("n2") & " kgf-cm.")
                txtTorqueLimit.Text = NominalMinTorque
            End If
            If txtTorqueLimit.Text > NominalMaxTorque Then
                MessageBox.Show("Torque limit must be less than " & NominalMaxTorque.ToString("n2") & " kgf-cm.")
                txtTorqueLimit.Text = NominalMaxTorque
            End If
        End If
    End Sub
    Private Sub cmdLoadCrystalDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCrystalDefaults.Click
        rdoCrystalHinge.Checked = True
        rdoBidirectional.Checked = True
        txtRelPos.Text = My.Settings.DefaultCrystalRelPos
    End Sub
    Private Sub cmdLoadFrameDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadFrameDefaults.Click
        rdoFrameHinge.Checked = True
        rdoUnidirectionalCW.Checked = True
        txtRelPos.Text = My.Settings.DefaultFrameRelPos
    End Sub

    Private Sub txtTargetTorque_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTargetTorque.Validated
        If Not IsNumeric(txtTargetTorque.Text) Then
            MessageBox.Show("Torque limit must be numeric.")
            txtTargetTorque.Text = My.Settings.LastTorqueLimit
        Else
            If txtTargetTorque.Text < NominalMinTorque Then
                MessageBox.Show("Torque limit must be greater than " & NominalMinTorque.ToString("n2") & " kgf-cm.")
                txtTargetTorque.Text = NominalMinTorque
            End If
            If txtTargetTorque.Text > NominalMaxTorque Then
                MessageBox.Show("Torque limit must be less than " & NominalMaxTorque.ToString("n2") & " kgf-cm.")
                txtTargetTorque.Text = NominalMaxTorque
            End If
        End If
    End Sub
End Class