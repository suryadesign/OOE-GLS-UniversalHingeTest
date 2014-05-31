Public Class frmTestInput

    Private Sub cmdShowFolderDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fbdDataFilePath.ShowDialog()
        txtDataFilePath.Text = fbdDataFilePath.SelectedPath
    End Sub
    Private Sub frmTestInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Settings.ACSIP & " Test Information..."
        'Load previous values from settings
        txtDevID.Text = My.Settings.LastDeviceID
        txtOperator.Text = My.Settings.LastOperator
        numDwellTime.Value = My.Settings.LastDwellTime
        chkIgnoreButtonStatus.Checked = My.Settings.LastIgnoreSwitchStatus
        chkZeroPosition.Checked = My.Settings.LastZeroPosition
        Select Case My.Settings.LastTravelEndCond
            Case 0
                rdoTravelEndRelPos.Checked = True
            Case 1
                rdoTravelEndTargetForce.Checked = True
            Case 2
                rdoTravelEndZTargetForce.Checked = True
            Case 3
                rdoTravelEndButtonClose.Checked = True
        End Select
        txtRelPos.Text = My.Settings.LastRelPos
        txtTargetForce.Text = My.Settings.LastTargetForce
        txtForceLimit.Text = My.Settings.LastForceLimit
        txtZTargetForce.Text = My.Settings.LastZTargetForce
        chkEndOnConsecButtonFailures.Checked = My.Settings.LastEndOnConsecSwitchFailures
        chkEndOnCycles.Checked = My.Settings.LastEndOnCycles
        chkEndOnTotalButtonFailures.Checked = My.Settings.LastEndOnTotalSwitchFailures
        chkFixtureErrorCyles.Checked = My.Settings.LastEndOnFixtureErrorCycles
        chkLimitForce.Checked = My.Settings.LastLimitForce
        txtNumCycles.Value = My.Settings.LastNumCycles
        txtTotalFailLimit.Value = My.Settings.LastTotalFailLimit
        txtConsecFailLimit.Value = My.Settings.LastConsecFailLimit
        txtFixtureErrorCyles.Value = My.Settings.LastFixtureErrorCyles
        Select Case My.Settings.LastDAQFrequency
            Case 0
                rdoDAQNever.Checked = True
            Case 1
                rdoDAQEvery1.Checked = True
            Case 2
                rdoDAQEvery10.Checked = True
            Case 3
                rdoDAQEvery100.Checked = True
            Case 4
                rdoDAQEvery1000.Checked = True
            Case 5
                rdoDAQProgInt.Checked = True
        End Select
        Select Case My.Settings.LastGraphDisplay
            Case 0
                rdoDisplacement.Checked = True
            Case 1
                rdoDistance.Checked = True
        End Select
        txtDataFilePath.Text = My.Settings.LastDataFilePath
    End Sub
    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        'save current options to settings
        My.Settings.LastDeviceID = txtDevID.Text
        My.Settings.LastOperator = txtOperator.Text
        My.Settings.LastDwellTime = numDwellTime.Value
        My.Settings.LastIgnoreSwitchStatus = chkIgnoreButtonStatus.Checked
        My.Settings.LastZeroPosition = chkZeroPosition.Checked
        If rdoTravelEndRelPos.Checked Then My.Settings.LastTravelEndCond = 0
        If rdoTravelEndTargetForce.Checked Then My.Settings.LastTravelEndCond = 1
        If rdoTravelEndZTargetForce.Checked Then My.Settings.LastTravelEndCond = 2
        If rdoTravelEndButtonClose.Checked Then My.Settings.LastTravelEndCond = 3
        My.Settings.LastRelPos = txtRelPos.Text
        My.Settings.LastTargetForce = txtTargetForce.Text
        My.Settings.LastZTargetForce = txtZTargetForce.Text
        My.Settings.LastForceLimit = txtForceLimit.Text
        My.Settings.LastEndOnCycles = chkEndOnCycles.Checked
        My.Settings.LastEndOnTotalSwitchFailures = chkEndOnTotalButtonFailures.Checked
        My.Settings.LastEndOnConsecSwitchFailures = chkEndOnConsecButtonFailures.Checked
        My.Settings.LastEndOnFixtureErrorCycles = chkFixtureErrorCyles.Checked
        My.Settings.LastLimitForce = chkLimitForce.Checked
        My.Settings.LastNumCycles = txtNumCycles.Value
        My.Settings.LastTotalFailLimit = txtTotalFailLimit.Value
        My.Settings.LastConsecFailLimit = txtConsecFailLimit.Value
        My.Settings.LastFixtureErrorCyles = txtFixtureErrorCyles.Value
        If rdoDAQNever.Checked Then My.Settings.LastDAQFrequency = 0
        If rdoDAQEvery1.Checked Then My.Settings.LastDAQFrequency = 1
        If rdoDAQEvery10.Checked Then My.Settings.LastDAQFrequency = 2
        If rdoDAQEvery100.Checked Then My.Settings.LastDAQFrequency = 3
        If rdoDAQEvery1000.Checked Then My.Settings.LastDAQFrequency = 4
        If rdoDAQProgInt.Checked Then My.Settings.LastDAQFrequency = 5
        If rdoDisplacement.Checked Then My.Settings.LastGraphDisplay = 0
        If rdoDistance.Checked Then My.Settings.LastGraphDisplay = 1
        My.Settings.LastDataFilePath = txtDataFilePath.Text
        My.Settings.Save()

        'pass options to main program
        frmMain.DeviceID = txtDevID.Text
        frmMain.TestOperator = txtOperator.Text
        frmMain.DwellTime = numDwellTime.Value
        frmMain.IgnoreButtonStatus = chkIgnoreButtonStatus.Checked
        frmMain.ZeroPositionBeforeTest = chkZeroPosition.Checked
        If rdoTravelEndRelPos.Checked Then frmMain.EndTravelCond = 0
        If rdoTravelEndTargetForce.Checked Then frmMain.EndTravelCond = 1
        If rdoTravelEndZTargetForce.Checked Then frmMain.EndTravelCond = 2
        If rdoTravelEndButtonClose.Checked Then frmMain.EndTravelCond = 3
        frmMain.RelPos = txtRelPos.Text
        frmMain.TargetForce = txtTargetForce.Text
        frmMain.ZTargetForce = txtZTargetForce.Text
        frmMain.ForceLimit = txtForceLimit.Text
        frmMain.EndOnCycles = chkEndOnCycles.Checked
        frmMain.EndOnTotalFailLimit = chkEndOnTotalButtonFailures.Checked
        frmMain.EndOnConsecFailLimit = chkEndOnConsecButtonFailures.Checked
        frmMain.EndOnFixtureFailLimit = chkFixtureErrorCyles.Checked
        frmMain.LimitForce = chkLimitForce.Checked
        frmMain.NumCycles = txtNumCycles.Value
        frmMain.TotalFailLimit = txtTotalFailLimit.Value
        frmMain.ConsecFailLimit = txtConsecFailLimit.Value
        frmMain.FixtureFailureLimit = txtFixtureErrorCyles.Value
        If rdoDAQNever.Checked Then frmMain.DAQFrequency = 0
        If rdoDAQEvery1.Checked Then frmMain.DAQFrequency = 1
        If rdoDAQEvery10.Checked Then frmMain.DAQFrequency = 2
        If rdoDAQEvery100.Checked Then frmMain.DAQFrequency = 3
        If rdoDAQEvery1000.Checked Then frmMain.DAQFrequency = 4
        If rdoDAQProgInt.Checked Then frmMain.DAQFrequency = 5
        If rdoDisplacement.Checked Then frmMain.GraphDisplay = 0
        If rdoDistance.Checked Then frmMain.GraphDisplay = 1
        frmMain.DataFilePath = txtDataFilePath.Text
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
    Private Sub txtTargetForce_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTargetForce.Validated
        If Not IsNumeric(txtTargetForce.Text) Then
            MessageBox.Show("Target force must be numeric.")
            txtTargetForce.Text = My.Settings.LastTargetForce
        Else
            If txtTargetForce.Text <= 0 Then
                MessageBox.Show("Target force must be greater than zero.")
                txtTargetForce.Text = 1
            End If
            If txtTargetForce.Text > 1350 Then
                MessageBox.Show("Target force must be less than 1350 gf.")
                txtTargetForce.Text = "1350"
            End If
        End If
    End Sub
    Private Sub txtZTargetForce_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZTargetForce.Validated
        If Not IsNumeric(txtZTargetForce.Text) Then
            MessageBox.Show("Target force must be numeric.")
            txtZTargetForce.Text = My.Settings.LastZTargetForce
        Else
            If txtZTargetForce.Text <= 0 Then
                MessageBox.Show("Target force must be greater than zero.")
                txtZTargetForce.Text = 1
            End If
            If txtZTargetForce.Text > 1350 Then
                MessageBox.Show("Target force must be less than 1350 gf.")
                txtZTargetForce.Text = "1350"
            End If
        End If
    End Sub
    Private Sub txtNumCycles_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumCycles.Validated
        If txtNumCycles.Value <= 0 Then
            MessageBox.Show("Number of cycles must be greater than zero.")
            txtNumCycles.Value = 1
        End If
    End Sub
    Private Sub txtTotalFailLimit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalFailLimit.Validated
        If txtTotalFailLimit.Value <= 0 Then
            MessageBox.Show("Number of failures must be greater than zero.")
            txtTotalFailLimit.Value = 1
        End If
    End Sub
    Private Sub txtConsecFailLimit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsecFailLimit.Validated
        If txtConsecFailLimit.Value <= 0 Then
            MessageBox.Show("Number of failures must be greater than zero.")
            txtConsecFailLimit.Value = 1
        End If
    End Sub
    Private Sub txtFixtureErrorCyles_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFixtureErrorCyles.Validated
        If txtFixtureErrorCyles.Value <= 0 Then
            MessageBox.Show("Number of cycles must be greater than zero.")
            txtFixtureErrorCyles.Value = 1
        End If
    End Sub
    Private Sub cmdShowFolderDialog_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowFolderDialog.Click
        fbdDataFilePath.ShowDialog()
        txtDataFilePath.Text = fbdDataFilePath.SelectedPath
    End Sub
    Private Sub txtForceLimit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForceLimit.Validated
        If Not IsNumeric(txtForceLimit.Text) Then
            MessageBox.Show("Force limit must be numeric.")
            txtForceLimit.Text = My.Settings.LastForceLimit
        Else
            If txtForceLimit.Text < NominalMinForce Then
                MessageBox.Show("Force limit must be greater than " & NominalMinForce.ToString("n0") & " gf.")
                txtForceLimit.Text = NominalMinForce
            End If
            If txtForceLimit.Text > NominalMaxForce Then
                MessageBox.Show("Force limit must be less than " & NominalMaxForce.ToString("n0") & " gf.")
                txtForceLimit.Text = NominalMaxForce
            End If
        End If
    End Sub


End Class