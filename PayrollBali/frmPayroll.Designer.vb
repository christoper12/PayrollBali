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
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(dgSummary, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 133)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 0
        Label1.Text = "Start Date"' 
        ' dtpStartDate
        ' 
        dtpStartDate.Format = DateTimePickerFormat.Short
        dtpStartDate.Location = New Point(119, 130)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(123, 27)
        dtpStartDate.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(276, 135)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 20)
        Label2.TabIndex = 2
        Label2.Text = "End Date"' 
        ' dtpEndDate
        ' 
        dtpEndDate.Format = DateTimePickerFormat.Short
        dtpEndDate.Location = New Point(363, 130)
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
        dgTimeSheet.AllowUserToAddRows = False
        dgTimeSheet.AllowUserToDeleteRows = False
        dgTimeSheet.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgTimeSheet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgTimeSheet.Location = New Point(12, 163)
        dgTimeSheet.Name = "dgTimeSheet"
        dgTimeSheet.RowHeadersWidth = 51
        dgTimeSheet.RowTemplate.Height = 29
        dgTimeSheet.Size = New Size(1753, 379)
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
        OpenFileDialog1.FileName = "OpenFileDialog1"' 
        ' lblFileExcelImport
        ' 
        lblFileExcelImport.AutoSize = True
        lblFileExcelImport.Location = New Point(6, 55)
        lblFileExcelImport.Name = "lblFileExcelImport"
        lblFileExcelImport.Size = New Size(15, 20)
        lblFileExcelImport.TabIndex = 8
        lblFileExcelImport.Text = "-"' 
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
        lblproses.Text = "-"' 
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
        btnSearch.Location = New Point(529, 130)
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
        dgSummary.Location = New Point(12, 631)
        dgSummary.Name = "dgSummary"
        dgSummary.RowHeadersWidth = 51
        dgSummary.RowTemplate.Height = 29
        dgSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgSummary.Size = New Size(1753, 449)
        dgSummary.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(12, 579)
        Label3.Name = "Label3"
        Label3.Size = New Size(152, 41)
        Label3.TabIndex = 12
        Label3.Text = "Summary"' 
        ' btnRefreshSum
        ' 
        btnRefreshSum.Location = New Point(190, 585)
        btnRefreshSum.Name = "btnRefreshSum"
        btnRefreshSum.Size = New Size(143, 29)
        btnRefreshSum.TabIndex = 13
        btnRefreshSum.Text = "Refresh Summary"
        btnRefreshSum.UseVisualStyleBackColor = True
        ' 
        ' lblCounttext
        ' 
        lblCounttext.AutoSize = True
        lblCounttext.Location = New Point(12, 544)
        lblCounttext.Name = "lblCounttext"
        lblCounttext.Size = New Size(55, 20)
        lblCounttext.TabIndex = 14
        lblCounttext.Text = "Count :"' 
        ' lblCount
        ' 
        lblCount.AutoSize = True
        lblCount.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        lblCount.Location = New Point(73, 545)
        lblCount.Name = "lblCount"
        lblCount.Size = New Size(18, 20)
        lblCount.TabIndex = 15
        lblCount.Text = "0"' 
        ' lblCountSum
        ' 
        lblCountSum.AutoSize = True
        lblCountSum.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        lblCountSum.Location = New Point(73, 1084)
        lblCountSum.Name = "lblCountSum"
        lblCountSum.Size = New Size(18, 20)
        lblCountSum.TabIndex = 17
        lblCountSum.Text = "0"' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 1083)
        Label5.Name = "Label5"
        Label5.Size = New Size(55, 20)
        Label5.TabIndex = 16
        Label5.Text = "Count :"' 
        ' btnClearSerach
        ' 
        btnClearSerach.Location = New Point(665, 131)
        btnClearSerach.Name = "btnClearSerach"
        btnClearSerach.Size = New Size(118, 29)
        btnClearSerach.TabIndex = 18
        btnClearSerach.Text = "Clear Search"
        btnClearSerach.UseVisualStyleBackColor = True
        ' 
        ' frmPayroll
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1779, 1119)
        Controls.Add(btnClearSerach)
        Controls.Add(lblCountSum)
        Controls.Add(Label5)
        Controls.Add(lblCount)
        Controls.Add(lblCounttext)
        Controls.Add(btnRefreshSum)
        Controls.Add(Label3)
        Controls.Add(dgSummary)
        Controls.Add(btnSearch)
        Controls.Add(GroupBox1)
        Controls.Add(dgTimeSheet)
        Controls.Add(dtpEndDate)
        Controls.Add(Label2)
        Controls.Add(dtpStartDate)
        Controls.Add(Label1)
        Name = "frmPayroll"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payroll Bali"
        WindowState = FormWindowState.Maximized
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgSummary, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
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
End Class
