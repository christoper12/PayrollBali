<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayroll
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        dtpStartDate = New DateTimePicker()
        Label2 = New Label()
        dtpEndDate = New DateTimePicker()
        btnImport = New Button()
        btnExport = New Button()
        dgTimeSheet = New DataGridView()
        btnStaff = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        lblFileExcelImport = New Label()
        GroupBox1 = New GroupBox()
        btnExit = New Button()
        btnProccess = New Button()
        lblproses = New Label()
        btnClearFile = New Button()
        btnSearch = New Button()
        dgSummary = New DataGridView()
        Label3 = New Label()
        btnRefreshSum = New Button()
        lblCounttext = New Label()
        lblCount = New Label()
        lblCountSum = New Label()
        Label5 = New Label()
        btnClearSerach = New Button()
        btnDeleteRowTimesheet = New Button()
        txtEmp = New TextBox()
        Label4 = New Label()
        Label6 = New Label()
        lblCountAutoSum = New Label()
        GroupBox2 = New GroupBox()
        GroupBox3 = New GroupBox()
        btnCancel = New Button()
        btnOk = New Button()
        txtActualHrs = New TextBox()
        Label13 = New Label()
        txtBreaks = New TextBox()
        Label12 = New Label()
        txtClokOff = New TextBox()
        Label11 = New Label()
        txtClockOn = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        dtpDateAdd = New DateTimePicker()
        txtFirstName = New TextBox()
        Label8 = New Label()
        txtLastName = New TextBox()
        Label7 = New Label()
        Panel1 = New Panel()
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(dgSummary, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 0
        Label1.Text = "Start Date" ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Format = DateTimePickerFormat.Short
        dtpStartDate.Location = New Point(88, 25)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(123, 27)
        dtpStartDate.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(229, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 20)
        Label2.TabIndex = 2
        Label2.Text = "End Date" ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Format = DateTimePickerFormat.Short
        dtpEndDate.Location = New Point(305, 25)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(123, 27)
        dtpEndDate.TabIndex = 3
        ' 
        ' btnImport
        ' 
        btnImport.Location = New Point(137, 18)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(156, 28)
        btnImport.TabIndex = 4
        btnImport.Text = "Import Timesheet"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(479, 18)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(264, 28)
        btnExport.TabIndex = 5
        btnExport.Text = "Export Timesheet To CSV FIle"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' dgTimeSheet
        ' 
        dgTimeSheet.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgTimeSheet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgTimeSheet.Location = New Point(8, 75)
        dgTimeSheet.Name = "dgTimeSheet"
        dgTimeSheet.RowHeadersWidth = 51
        dgTimeSheet.RowTemplate.Height = 29
        dgTimeSheet.Size = New Size(1709, 558)
        dgTimeSheet.TabIndex = 6
        ' 
        ' btnStaff
        ' 
        btnStaff.Location = New Point(1132, 18)
        btnStaff.Name = "btnStaff"
        btnStaff.Size = New Size(124, 29)
        btnStaff.TabIndex = 7
        btnStaff.Text = "Data Staff"
        btnStaff.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1" ' 
        ' lblFileExcelImport
        ' 
        lblFileExcelImport.AutoSize = True
        lblFileExcelImport.Location = New Point(6, 55)
        lblFileExcelImport.Name = "lblFileExcelImport"
        lblFileExcelImport.Size = New Size(15, 20)
        lblFileExcelImport.TabIndex = 8
        lblFileExcelImport.Text = "-" ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnExit)
        GroupBox1.Controls.Add(btnProccess)
        GroupBox1.Controls.Add(lblproses)
        GroupBox1.Controls.Add(btnClearFile)
        GroupBox1.Controls.Add(btnImport)
        GroupBox1.Controls.Add(btnExport)
        GroupBox1.Controls.Add(lblFileExcelImport)
        GroupBox1.Controls.Add(btnStaff)
        GroupBox1.Location = New Point(14, -1)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1262, 125)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(1132, 88)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(124, 29)
        btnExit.TabIndex = 12
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnProccess
        ' 
        btnProccess.Location = New Point(299, 18)
        btnProccess.Name = "btnProccess"
        btnProccess.Size = New Size(156, 28)
        btnProccess.TabIndex = 11
        btnProccess.Text = "Proccess"
        btnProccess.UseVisualStyleBackColor = True
        ' 
        ' lblproses
        ' 
        lblproses.AutoSize = True
        lblproses.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        lblproses.Location = New Point(6, 83)
        lblproses.Name = "lblproses"
        lblproses.Size = New Size(17, 23)
        lblproses.TabIndex = 10
        lblproses.Text = "-" ' 
        ' btnClearFile
        ' 
        btnClearFile.Location = New Point(6, 19)
        btnClearFile.Name = "btnClearFile"
        btnClearFile.Size = New Size(125, 28)
        btnClearFile.TabIndex = 9
        btnClearFile.Text = "Clear File"
        btnClearFile.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(938, 24)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(118, 29)
        btnSearch.TabIndex = 10
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dgSummary
        ' 
        dgSummary.AllowUserToAddRows = False
        dgSummary.AllowUserToDeleteRows = False
        dgSummary.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgSummary.Location = New Point(13, 800)
        dgSummary.Name = "dgSummary"
        dgSummary.RowHeadersWidth = 51
        dgSummary.RowTemplate.Height = 29
        dgSummary.Size = New Size(1708, 285)
        dgSummary.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(13, 756)
        Label3.Name = "Label3"
        Label3.Size = New Size(152, 41)
        Label3.TabIndex = 12
        Label3.Text = "Summary" ' 
        ' btnRefreshSum
        ' 
        btnRefreshSum.Location = New Point(171, 765)
        btnRefreshSum.Name = "btnRefreshSum"
        btnRefreshSum.Size = New Size(143, 29)
        btnRefreshSum.TabIndex = 13
        btnRefreshSum.Text = "Refresh Summary"
        btnRefreshSum.UseVisualStyleBackColor = True
        ' 
        ' lblCounttext
        ' 
        lblCounttext.AutoSize = True
        lblCounttext.Location = New Point(211, 640)
        lblCounttext.Name = "lblCounttext"
        lblCounttext.Size = New Size(55, 20)
        lblCounttext.TabIndex = 14
        lblCounttext.Text = "Count :" ' 
        ' lblCount
        ' 
        lblCount.AutoSize = True
        lblCount.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblCount.Location = New Point(272, 641)
        lblCount.Name = "lblCount"
        lblCount.Size = New Size(18, 20)
        lblCount.TabIndex = 15
        lblCount.Text = "0" ' 
        ' lblCountSum
        ' 
        lblCountSum.AutoSize = True
        lblCountSum.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblCountSum.Location = New Point(74, 1089)
        lblCountSum.Name = "lblCountSum"
        lblCountSum.Size = New Size(18, 20)
        lblCountSum.TabIndex = 17
        lblCountSum.Text = "0" ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(13, 1088)
        Label5.Name = "Label5"
        Label5.Size = New Size(55, 20)
        Label5.TabIndex = 16
        Label5.Text = "Count :" ' 
        ' btnClearSerach
        ' 
        btnClearSerach.Location = New Point(1074, 24)
        btnClearSerach.Name = "btnClearSerach"
        btnClearSerach.Size = New Size(118, 29)
        btnClearSerach.TabIndex = 18
        btnClearSerach.Text = "Clear Search"
        btnClearSerach.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteRowTimesheet
        ' 
        btnDeleteRowTimesheet.Location = New Point(12, 638)
        btnDeleteRowTimesheet.Name = "btnDeleteRowTimesheet"
        btnDeleteRowTimesheet.Size = New Size(193, 27)
        btnDeleteRowTimesheet.TabIndex = 13
        btnDeleteRowTimesheet.Text = "Delete Timesheet"
        btnDeleteRowTimesheet.UseVisualStyleBackColor = True
        ' 
        ' txtEmp
        ' 
        txtEmp.Location = New Point(559, 25)
        txtEmp.Name = "txtEmp"
        txtEmp.Size = New Size(364, 27)
        txtEmp.TabIndex = 19
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(434, 28)
        Label4.Name = "Label4"
        Label4.Size = New Size(119, 20)
        Label4.TabIndex = 20
        Label4.Text = "Employee Name" ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(461, 640)
        Label6.Name = "Label6"
        Label6.Size = New Size(81, 20)
        Label6.TabIndex = 21
        Label6.Text = "Auto Sum :" ' 
        ' lblCountAutoSum
        ' 
        lblCountAutoSum.AutoSize = True
        lblCountAutoSum.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblCountAutoSum.Location = New Point(543, 640)
        lblCountAutoSum.Name = "lblCountAutoSum"
        lblCountAutoSum.Size = New Size(18, 20)
        lblCountAutoSum.TabIndex = 22
        lblCountAutoSum.Text = "0" ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(dtpStartDate)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(dtpEndDate)
        GroupBox2.Controls.Add(txtEmp)
        GroupBox2.Controls.Add(btnSearch)
        GroupBox2.Controls.Add(btnClearSerach)
        GroupBox2.Location = New Point(8, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(1262, 66)
        GroupBox2.TabIndex = 23
        GroupBox2.TabStop = False
        GroupBox2.Text = "Search" ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(btnCancel)
        GroupBox3.Controls.Add(btnOk)
        GroupBox3.Controls.Add(txtActualHrs)
        GroupBox3.Controls.Add(Label13)
        GroupBox3.Controls.Add(txtBreaks)
        GroupBox3.Controls.Add(Label12)
        GroupBox3.Controls.Add(txtClokOff)
        GroupBox3.Controls.Add(Label11)
        GroupBox3.Controls.Add(txtClockOn)
        GroupBox3.Controls.Add(Label10)
        GroupBox3.Controls.Add(Label9)
        GroupBox3.Controls.Add(dtpDateAdd)
        GroupBox3.Controls.Add(txtFirstName)
        GroupBox3.Controls.Add(Label8)
        GroupBox3.Controls.Add(txtLastName)
        GroupBox3.Controls.Add(Label7)
        GroupBox3.Location = New Point(12, 671)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(1399, 83)
        GroupBox3.TabIndex = 24
        GroupBox3.TabStop = False
        GroupBox3.Text = "Add Data Payroll" ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(1299, 41)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 29)
        btnCancel.TabIndex = 17
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnOk
        ' 
        btnOk.Location = New Point(1199, 41)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(94, 29)
        btnOk.TabIndex = 16
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' txtActualHrs
        ' 
        txtActualHrs.Location = New Point(1033, 43)
        txtActualHrs.Name = "txtActualHrs"
        txtActualHrs.Size = New Size(160, 27)
        txtActualHrs.TabIndex = 13
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(1033, 20)
        Label13.Name = "Label13"
        Label13.Size = New Size(94, 20)
        Label13.TabIndex = 12
        Label13.Text = "Actual Hours" ' 
        ' txtBreaks
        ' 
        txtBreaks.Location = New Point(857, 43)
        txtBreaks.Name = "txtBreaks"
        txtBreaks.Size = New Size(160, 27)
        txtBreaks.TabIndex = 11
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(857, 20)
        Label12.Name = "Label12"
        Label12.Size = New Size(52, 20)
        Label12.TabIndex = 10
        Label12.Text = "Breaks" ' 
        ' txtClokOff
        ' 
        txtClokOff.Location = New Point(682, 43)
        txtClokOff.Name = "txtClokOff"
        txtClokOff.Size = New Size(160, 27)
        txtClokOff.TabIndex = 9
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(682, 20)
        Label11.Name = "Label11"
        Label11.Size = New Size(70, 20)
        Label11.TabIndex = 8
        Label11.Text = "Clock Off" ' 
        ' txtClockOn
        ' 
        txtClockOn.Location = New Point(504, 43)
        txtClockOn.Name = "txtClockOn"
        txtClockOn.Size = New Size(160, 27)
        txtClockOn.TabIndex = 7
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(504, 20)
        Label10.Name = "Label10"
        Label10.Size = New Size(68, 20)
        Label10.TabIndex = 6
        Label10.Text = "Clock On" ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(360, 20)
        Label9.Name = "Label9"
        Label9.Size = New Size(41, 20)
        Label9.TabIndex = 5
        Label9.Text = "Date" ' 
        ' dtpDateAdd
        ' 
        dtpDateAdd.Format = DateTimePickerFormat.Short
        dtpDateAdd.Location = New Point(360, 43)
        dtpDateAdd.Name = "dtpDateAdd"
        dtpDateAdd.Size = New Size(123, 27)
        dtpDateAdd.TabIndex = 4
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(186, 45)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(160, 27)
        txtFirstName.TabIndex = 3
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(186, 22)
        Label8.Name = "Label8"
        Label8.Size = New Size(80, 20)
        Label8.TabIndex = 2
        Label8.Text = "First Name" ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(12, 45)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(160, 27)
        txtLastName.TabIndex = 1
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 22)
        Label7.Name = "Label7"
        Label7.Size = New Size(79, 20)
        Label7.TabIndex = 0
        Label7.Text = "Last Name" ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.AutoScroll = True
        Panel1.Controls.Add(GroupBox2)
        Panel1.Controls.Add(lblCountSum)
        Panel1.Controls.Add(GroupBox3)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(dgTimeSheet)
        Panel1.Controls.Add(lblCountAutoSum)
        Panel1.Controls.Add(btnRefreshSum)
        Panel1.Controls.Add(btnDeleteRowTimesheet)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(dgSummary)
        Panel1.Controls.Add(lblCounttext)
        Panel1.Controls.Add(lblCount)
        Panel1.Location = New Point(12, 130)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1755, 768)
        Panel1.TabIndex = 25
        ' 
        ' frmPayroll
        ' 
        AcceptButton = btnSearch
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1779, 910)
        Controls.Add(Panel1)
        Controls.Add(GroupBox1)
        Name = "frmPayroll"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payroll Bali"
        WindowState = FormWindowState.Maximized
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgSummary, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnImport As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents dgTimeSheet As DataGridView
    Friend WithEvents btnStaff As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents lblFileExcelImport As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClearFile As Button
    Friend WithEvents lblproses As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgSummary As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnRefreshSum As Button
    Friend WithEvents btnProccess As Button
    Friend WithEvents lblCounttext As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents lblCountSum As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnClearSerach As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDeleteRowTimesheet As Button
    Friend WithEvents txtEmp As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCountAutoSum As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents txtActualHrs As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtBreaks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtClokOff As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtClockOn As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpDateAdd As DateTimePicker
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
End Class
