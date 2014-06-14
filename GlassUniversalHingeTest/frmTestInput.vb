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
        Select Case My.Settings.LastDeviceType
            Case frmMain.CrystalHinge
                rdoCrystalHinge.Checked = True
            Case frmMain.FrameHinge
                rdoFrameHinge.Checked = True
        End Select
        Select Case My.Settings.LastMotionMode
            Case frmMain.CWUnidirectional
                rdoUnidirectionalCW.Checked = True
            Case frmMain.CCWUnidirectional
                rdoUnidirectionalCCW.Checked = True
            Case frmMain.Bidirectional
                rdoBidirectional.Checked = True
        End Select
        txtRelPos.Text = My.Settings.LastRelPos
        txtTorqueLimit.Text = My.Settings.LastTorqueLimit
        chkEndOnCycles.Checked = My.Settings.LastEndOnCycles
        chkFixtureErrorCyles.Checked = My.Settings.LastEndOnFixtureErrorCycles
        chkLimitTorque.Checked = My.Settings.LastLimitTorque
        txtNumCycles.Value = My.Settings.LastNumCycles
        txtFixtureErrorCyles.Value = My.Settings.LastFixtureErrorCyles
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
        Select Case My.Settings.LastGraphDisplay
            Case frmMain.GraphDisplacement
                rdoDisplacement.Checked = True
            Case frmMain.GraphDistance
                rdoDistance.Checked = True
        End Select
        txtDataFilePath.Text = My.Settings.LastDataFilePath
    End Sub
    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        'save current options to settings
        My.Settings.LastDeviceID = txtDevID.Text
        My.Settings.LastOperator = txtOperator.Text
        My.Settings.LastDwellTime = numDwellTime.Value
        If rdoCrystalHinge.Checked Then My.Settings.LastDeviceType = frmMain.CrystalHinge
        If rdoFrameHinge.Checked Then My.Settings.LastDeviceType = frmMain.FrameHinge
        If rdoUnidirectionalCW.Checked Then My.Settings.LastMotionMode = frmMain.CWUnidirectional
        If rdoUnidirectionalCCW.Checked Then My.Settings.LastMotionMode = frmMain.CCWUnidirectional
        If rdoBidirectional.Checked Then My.Settings.LastMotionMode = frmMain.Bidirectional
        My.Settings.LastRelPos = txtRelPos.Text
        My.Settings.LastTorqueLimit = txtTorqueLimit.Text
        My.Settings.LastEndOnCycles = chkEndOnCycles.Checked
        My.Settings.LastEndOnFixtureErrorCycles = chkFixtureErrorCyles.Checked
        My.Settings.LastLimitTorque = chkLimitTorque.Checked
        My.Settings.LastNumCycles = txtNumCycles.Value
        My.Settings.LastFixtureErrorCyles = txtFixtureErrorCyles.Value
        If rdoDAQNever.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQNever
        If rdoDAQEvery1.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery1
        If rdoDAQEvery10.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery10
        If rdoDAQEvery100.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery100
        If rdoDAQEvery1000.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQEvery1000
        If rdoDAQProgInt.Checked Then My.Settings.LastDAQFrequency = frmMain.DAQProgInt
        If rdoDisplacement.Checked Then My.Settings.LastGraphDisplay = frmMain.GraphDisplacement
        If rdoDistance.Checked Then My.Settings.LastGraphDisplay = frmMain.GraphDistance
        My.Settings.LastDataFilePath = txtDataFilePath.Text
        My.Settings.Save()

        'pass options to main program
        frmMain.DeviceID = txtDevID.Text
        frmMain.TestOperator = txtOperator.Text
        frmMain.DwellTime = numDwellTime.Value
        If rdoCrystalHinge.Checked Then frmMain.DeviceType = frmMain.CrystalHinge
        If rdoFrameHinge.Checked Then frmMain.DeviceType = frmMain.FrameHinge

        If rdoUnidirectionalCW.Checked Then frmMain.MotionMode = frmMain.CWUnidirectional
        If rdoUnidirectionalCCW.Checked Then frmMain.MotionMode = frmMain.CCWUnidirectional
        If rdoBidirectional.Checked Then frmMain.MotionMode = frmMain.Bidirectional
        frmMain.RelPos = txtRelPos.Text
        frmMain.TorqueLimit = txtTorqueLimit.Text
        frmMain.EndOnCycles = chkEndOnCycles.Checked
        frmMain.EndOnFixtureFailLimit = chkFixtureErrorCyles.Checked
        frmMain.LimitTorque = chkLimitTorque.Checked
        frmMain.NumCycles = txtNumCycles.Value
        frmMain.FixtureFailureLimit = txtFixtureErrorCyles.Value
        If rdoDAQNever.Checked Then frmMain.DAQFrequency = frmMain.DAQNever
        If rdoDAQEvery1.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery1
        If rdoDAQEvery10.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery10
        If rdoDAQEvery100.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery100
        If rdoDAQEvery1000.Checked Then frmMain.DAQFrequency = frmMain.DAQEvery1000
        If rdoDAQProgInt.Checked Then frmMain.DAQFrequency = frmMain.DAQProgInt
        If rdoDisplacement.Checked Then frmMain.GraphDisplay = frmMain.GraphDisplacement
        If rdoDistance.Checked Then frmMain.GraphDisplay = frmMain.GraphDistance
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
            MessageBox.Show("Force limit must be numeric.")
            txtTorqueLimit.Text = My.Settings.LastTorqueLimit
        Else
            If txtTorqueLimit.Text < NominalMinTorque Then
                MessageBox.Show("Force limit must be greater than " & NominalMinTorque.ToString("n0") & " gf.")
                txtTorqueLimit.Text = NominalMinTorque
            End If
            If txtTorqueLimit.Text > NominalMaxTorque Then
                MessageBox.Show("Force limit must be less than " & NominalMaxTorque.ToString("n0") & " gf.")
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
End Class