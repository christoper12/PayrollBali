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
        lblproses = New Label()
        btnClearFile = New Button()
        btnSearch = New Button()
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 123)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 0
        Label1.Text = "Start Date"' 
        ' dtpStartDate
        ' 
        dtpStartDate.Format = DateTimePickerFormat.Short
        dtpStartDate.Location = New Point(119, 120)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(123, 27)
        dtpStartDate.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(276, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 20)
        Label2.TabIndex = 2
        Label2.Text = "End Date"' 
        ' dtpEndDate
        ' 
        dtpEndDate.Format = DateTimePickerFormat.Short
        dtpEndDate.Location = New Point(363, 120)
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
        btnImport.Text = "Import"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(299, 18)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(156, 28)
        btnExport.TabIndex = 5
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' dgTimeSheet
        ' 
        dgTimeSheet.AllowUserToAddRows = False
        dgTimeSheet.AllowUserToDeleteRows = False
        dgTimeSheet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgTimeSheet.Location = New Point(12, 153)
        dgTimeSheet.MultiSelect = False
        dgTimeSheet.Name = "dgTimeSheet"
        dgTimeSheet.RowHeadersWidth = 51
        dgTimeSheet.RowTemplate.Height = 29
        dgTimeSheet.Size = New Size(1545, 559)
        dgTimeSheet.TabIndex = 6
        ' 
        ' btnStaff
        ' 
        btnStaff.Location = New Point(1383, 11)
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
        GroupBox1.Controls.Add(lblproses)
        GroupBox1.Controls.Add(btnClearFile)
        GroupBox1.Controls.Add(btnImport)
        GroupBox1.Controls.Add(btnExport)
        GroupBox1.Controls.Add(lblFileExcelImport)
        GroupBox1.Location = New Point(14, -1)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1083, 115)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
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
        btnSearch.Location = New Point(529, 120)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(118, 29)
        btnSearch.TabIndex = 10
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' frmPayroll
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1569, 791)
        Controls.Add(btnSearch)
        Controls.Add(GroupBox1)
        Controls.Add(btnStaff)
        Controls.Add(dgTimeSheet)
        Controls.Add(dtpEndDate)
        Controls.Add(Label2)
        Controls.Add(dtpStartDate)
        Controls.Add(Label1)
        Name = "frmPayroll"
        Text = "Payroll Bali"
        CType(dgTimeSheet, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
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
End Class
