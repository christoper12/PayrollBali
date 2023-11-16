Public Class frmStaff
    Private logger As New ClassLoggerPayrollBali

    Sub firstLoad()
        Try
            Dim func As New DllPayrollBaliNew.classPayrollBali
            Dim dt As DataTable
            dt = func.getDataStaffPayrollBali()
            dgStaff.DataSource = dt
            dgStaff.ClearSelection()

            dgStaff.Columns("id").Visible = False
            dgStaff.Columns("fullName").HeaderCell.Value = "Full Name"
            dgStaff.Columns("firstName").HeaderCell.Value = "First Name"
            dgStaff.Columns("lastName").HeaderCell.Value = "Last Name"
            dgStaff.Columns("cardId").HeaderCell.Value = "Card ID"
            dgStaff.Columns("empRecordId").HeaderCell.Value = "Emp Record ID"
            dgStaff.Columns("status").Visible = False

            txtFullName.Enabled = False
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtCardId.Enabled = False
            txtEmpRecordId.Enabled = False

            btnSave.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            firstLoad()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub clearData()
        Try
            If status = "add" Then
                txtFullName.Text = ""
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtCardId.Text = ""
                txtEmpRecordId.Text = ""
            Else
                txtFullName.Text = ""
                txtFirstName.Text = ""
                txtLastName.Text = ""
                txtCardId.Text = ""
                txtEmpRecordId.Text = ""

                txtFullName.Enabled = False
                txtFirstName.Enabled = False
                txtLastName.Enabled = False
                txtCardId.Enabled = False
                txtEmpRecordId.Enabled = False

                idStaff = String.Empty
                fullname = String.Empty
                firstname = String.Empty
                lastname = String.Empty
                cardid = String.Empty
                emprecordid = String.Empty
            End If

            dgStaff.ClearSelection()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Dim idStaff As String = String.Empty
    Dim fullname As String = String.Empty
    Dim firstname As String = String.Empty
    Dim lastname As String = String.Empty
    Dim cardid As String = String.Empty
    Dim emprecordid As String = String.Empty

    Private Sub dgStaff_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStaff.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                txtFullName.Enabled = True
                txtFirstName.Enabled = True
                txtLastName.Enabled = True
                txtCardId.Enabled = True
                txtEmpRecordId.Enabled = True

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("id").Value.ToString())) Then
                    idStaff = ""
                Else
                    idStaff = dgStaff.Rows(e.RowIndex).Cells("id").Value
                End If

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("fullName").Value.ToString())) Then
                    fullname = ""
                Else
                    fullname = dgStaff.Rows(e.RowIndex).Cells("fullName").Value
                End If

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("firstName").Value.ToString())) Then
                    firstname = ""
                Else
                    firstname = dgStaff.Rows(e.RowIndex).Cells("firstName").Value
                End If

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("lastName").Value.ToString())) Then
                    lastname = ""
                Else
                    lastname = dgStaff.Rows(e.RowIndex).Cells("lastName").Value
                End If

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("cardId").Value.ToString())) Then
                    cardid = ""
                Else
                    cardid = dgStaff.Rows(e.RowIndex).Cells("cardId").Value
                End If

                If (String.IsNullOrWhiteSpace(dgStaff.Rows(e.RowIndex).Cells("empRecordId").Value.ToString())) Then
                    emprecordid = ""
                Else
                    emprecordid = dgStaff.Rows(e.RowIndex).Cells("empRecordId").Value
                End If

                txtFullName.Text = fullname
                txtFirstName.Text = firstname
                txtLastName.Text = lastname
                txtCardId.Text = cardid
                txtEmpRecordId.Text = emprecordid

                status = "update"
                btnAdd.Enabled = False
                btnSave.Enabled = True
                btnDelete.Enabled = True
                btnCancel.Enabled = True

                lblStatus.Visible = True
                lblStatus.Text = "Update / Delete Staff"
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If idStaff = "" Then
                MessageBox.Show("Please Select Data To Delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim result As DialogResult = MessageBox.Show("Are You Sure To Delete This Data?", "Warning", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    clearData()
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Dim func As New DllPayrollBaliNew.classPayrollBali
                    If func.deletePayrollBaliStaff(idStaff) = True Then
                        clearData()
                        firstLoad()
                        status = String.Empty
                        btnCancel.Enabled = False
                        btnAdd.Enabled = True
                        btnSave.Enabled = False
                        btnDelete.Enabled = True

                        lblStatus.Visible = False
                        lblStatus.Text = ""
                    Else
                        clearData()
                        status = String.Empty
                        btnCancel.Enabled = False
                        btnAdd.Enabled = True
                        btnSave.Enabled = False
                        btnDelete.Enabled = True

                        lblStatus.Visible = False
                        lblStatus.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Dim status As String = ""
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            lblStatus.Visible = True
            lblStatus.Text = "Add Staff"
            txtFullName.Enabled = True
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtCardId.Enabled = True
            txtEmpRecordId.Enabled = True
            txtFullName.Focus()

            status = "add"

            clearData()

            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnCancel.Enabled = True
            btnSave.Enabled = True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If status = "add" Then
                addStaff()
                clear()
            ElseIf status = "update" Then
                updateStaff()
                clear()
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub addStaff()
        Try
            Dim fullNameAdd As String = String.Empty
            Dim firstNameAdd As String = String.Empty
            Dim lastNameAdd As String = String.Empty
            Dim cardIdAdd As String = String.Empty
            Dim empRecordIdAdd As String = String.Empty

            If txtFullName.Text <> "" Then
                fullNameAdd = txtFullName.Text
            Else
                fullNameAdd = ""
            End If

            If txtFirstName.Text <> "" Then
                firstNameAdd = txtFirstName.Text
            Else
                firstNameAdd = ""
            End If

            If txtLastName.Text <> "" Then
                lastNameAdd = txtLastName.Text
            Else
                lastNameAdd = ""
            End If

            If txtCardId.Text <> "" Then
                cardIdAdd = txtCardId.Text
            Else
                cardIdAdd = ""
            End If

            If txtEmpRecordId.Text <> "" Then
                empRecordIdAdd = txtEmpRecordId.Text
            Else
                empRecordIdAdd = ""
            End If

            If fullNameAdd = "" Then
                MsgBox("Full Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If firstNameAdd = "" Then
                MsgBox("First Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If lastNameAdd = "" Then
                MsgBox("Last Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If cardIdAdd = "" Then
                MsgBox("Card ID Must be Fill!")
                clearData()
                Exit Sub
            End If

            Dim func As New DllPayrollBaliNew.classPayrollBali
            If func.insertPayrollBaliStaff(fullNameAdd, firstNameAdd, lastNameAdd, cardIdAdd, empRecordIdAdd) = True Then
                clearData()
                firstLoad()
            Else
                clearData()
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub updateStaff()
        Try
            Dim fullNameAdd As String = String.Empty
            Dim firstNameAdd As String = String.Empty
            Dim lastNameAdd As String = String.Empty
            Dim cardIdAdd As String = String.Empty
            Dim empRecordIdAdd As String = String.Empty

            If txtFullName.Text <> "" Then
                fullNameAdd = txtFullName.Text
            Else
                fullNameAdd = ""
            End If

            If txtFirstName.Text <> "" Then
                firstNameAdd = txtFirstName.Text
            Else
                firstNameAdd = ""
            End If

            If txtLastName.Text <> "" Then
                lastNameAdd = txtLastName.Text
            Else
                lastNameAdd = ""
            End If

            If txtCardId.Text <> "" Then
                cardIdAdd = txtCardId.Text
            Else
                cardIdAdd = ""
            End If

            If txtEmpRecordId.Text <> "" Then
                empRecordIdAdd = txtEmpRecordId.Text
            Else
                empRecordIdAdd = ""
            End If

            If fullNameAdd = "" Then
                MsgBox("Full Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If firstNameAdd = "" Then
                MsgBox("First Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If lastNameAdd = "" Then
                MsgBox("Last Name Must be Fill!")
                clearData()
                Exit Sub
            End If

            If cardIdAdd = "" Then
                MsgBox("Card ID Must be Fill!")
                clearData()
                Exit Sub
            End If

            Dim func As New DllPayrollBaliNew.classPayrollBali
            If func.updatePayrollBaliStaff(fullNameAdd, firstNameAdd, lastNameAdd, cardIdAdd, empRecordIdAdd, idStaff) = True Then
                clearData()
                firstLoad()
                status = String.Empty
                btnCancel.Enabled = False
                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True

                lblStatus.Visible = False
                lblStatus.Text = ""
            Else
                clearData()
                status = String.Empty
                btnCancel.Enabled = False
                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True

                lblStatus.Visible = False
                lblStatus.Text = ""
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            clear()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub clear()
        Try
            status = String.Empty
            clearData()
            btnCancel.Enabled = False
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnDelete.Enabled = True

            lblStatus.Visible = False
            lblStatus.Text = ""
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class