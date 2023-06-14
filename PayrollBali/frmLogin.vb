Public Class frmLogin
    Private logger As New DllLogger.ClassLogger

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If txtUsername.Text = "" And txtPassword.Text = "" Then
                MessageBox.Show("Please Input Username And Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim staffid As String = txtUsername.Text
            Dim pass As String = txtPassword.Text
            Dim func As New DllPayrollBali.classLoginPayrollBali
            Dim dt As DataTable

            dt = func.getDataStaffLogin(staffid, pass)

            If dt.Rows.Count > 0 Then
                frmPayroll.staffidPublic = dt.Rows(0).Item("dbstffid").ToString
                Me.Hide()
                frmPayroll.Show()
            Else
                MessageBox.Show("Your Username or Password Is Wrong!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub cbShowpass_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowpass.CheckedChanged
        Try
            If cbShowpass.Checked = True Then
                txtPassword.UseSystemPasswordChar = False
            Else
                txtPassword.UseSystemPasswordChar = True
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
End Class