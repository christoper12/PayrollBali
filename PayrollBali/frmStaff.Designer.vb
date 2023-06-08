<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaff
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        GroupBox1 = New GroupBox()
        lblStatus = New Label()
        btnCancel = New Button()
        btnAdd = New Button()
        btnDelete = New Button()
        btnClose = New Button()
        btnSave = New Button()
        txtEmpRecordId = New TextBox()
        txtCardId = New TextBox()
        txtLastName = New TextBox()
        txtFirstName = New TextBox()
        txtFullName = New TextBox()
        dgStaff = New DataGridView()
        Label6 = New Label()
        GroupBox1.SuspendLayout()
        CType(dgStaff, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(47, 47)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 0
        Label1.Text = "Full Name"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(43, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 20)
        Label2.TabIndex = 1
        Label2.Text = "First Name"' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(44, 115)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 20)
        Label3.TabIndex = 2
        Label3.Text = "Last Name"' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(64, 149)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 20)
        Label4.TabIndex = 3
        Label4.Text = "Card ID"' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(14, 183)
        Label5.Name = "Label5"
        Label5.Size = New Size(109, 20)
        Label5.TabIndex = 4
        Label5.Text = "Emp Record ID"' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblStatus)
        GroupBox1.Controls.Add(btnCancel)
        GroupBox1.Controls.Add(btnAdd)
        GroupBox1.Controls.Add(btnDelete)
        GroupBox1.Controls.Add(btnClose)
        GroupBox1.Controls.Add(btnSave)
        GroupBox1.Controls.Add(txtEmpRecordId)
        GroupBox1.Controls.Add(txtCardId)
        GroupBox1.Controls.Add(txtLastName)
        GroupBox1.Controls.Add(txtFirstName)
        GroupBox1.Controls.Add(txtFullName)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(968, 259)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point)
        lblStatus.ForeColor = Color.DodgerBlue
        lblStatus.Location = New Point(47, 14)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(50, 20)
        lblStatus.TabIndex = 16
        lblStatus.Text = "Status"
        lblStatus.Visible = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(446, 216)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(96, 32)
        btnCancel.TabIndex = 15
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(144, 216)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(96, 32)
        btnAdd.TabIndex = 14
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(344, 216)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(96, 32)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(830, 221)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(132, 32)
        btnClose.TabIndex = 12
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(244, 216)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(96, 32)
        btnSave.TabIndex = 10
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtEmpRecordId
        ' 
        txtEmpRecordId.Location = New Point(144, 180)
        txtEmpRecordId.Name = "txtEmpRecordId"
        txtEmpRecordId.Size = New Size(142, 27)
        txtEmpRecordId.TabIndex = 9
        ' 
        ' txtCardId
        ' 
        txtCardId.Location = New Point(144, 146)
        txtCardId.Name = "txtCardId"
        txtCardId.Size = New Size(142, 27)
        txtCardId.TabIndex = 8
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(144, 112)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(539, 27)
        txtLastName.TabIndex = 7
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(144, 78)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(539, 27)
        txtFirstName.TabIndex = 6
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(144, 44)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(539, 27)
        txtFullName.TabIndex = 5
        ' 
        ' dgStaff
        ' 
        dgStaff.AllowUserToAddRows = False
        dgStaff.AllowUserToDeleteRows = False
        dgStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgStaff.Location = New Point(12, 277)
        dgStaff.Name = "dgStaff"
        dgStaff.ReadOnly = True
        dgStaff.RowHeadersWidth = 51
        dgStaff.RowTemplate.Height = 29
        dgStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgStaff.Size = New Size(968, 385)
        dgStaff.TabIndex = 6
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label6.ForeColor = Color.Red
        Label6.Location = New Point(12, 665)
        Label6.Name = "Label6"
        Label6.Size = New Size(402, 20)
        Label6.TabIndex = 15
        Label6.Text = "*Please Double Clik Data In Table For Update or Delete"' 
        ' frmStaff
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(992, 699)
        Controls.Add(Label6)
        Controls.Add(dgStaff)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "frmStaff"
        Text = "Form Staff"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgStaff, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtEmpRecordId As TextBox
    Friend WithEvents txtCardId As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents dgStaff As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblStatus As Label
End Class
