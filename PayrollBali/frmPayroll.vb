Imports System.Globalization
Imports System.IO
Imports Mysqlx.XDevAPI.Relational
Imports tesExcel = Microsoft.Office.Interop.Excel

Public Class frmPayroll
    Private logger As New DllLogger.ClassLogger
    Dim filename As String = String.Empty
    Dim copyOriginalFileTarget As String = String.Empty
    Dim originalFile As String = String.Empty
    Dim dt, dt2 As New DataTable
    Dim dtTimeSheet, dtGetStaffID As New DataTable
    Dim startDate As DateTime = Nothing
    Dim endDate As DateTime = Nothing
    Dim startDateFixed As String = String.Empty
    Dim endDateFixed As String = String.Empty
    Public staffidPublic As String = String.Empty
    Dim empName As String = String.Empty

    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpStartDate.Value = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday))
            dtpEndDate.Value = dtpStartDate.Value.AddDays(6)

            startDate = DateTime.Parse(dtpStartDate.Text)
            endDate = DateTime.Parse(dtpEndDate.Text)

            startDateFixed = startDate.ToString("yyyy-MM-dd HH:mm:ss")
            endDateFixed = endDate.ToString("yyyy-MM-dd HH:mm:ss")

            'DateTime Date = DateTime.ParseExact(Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            'String reformatted = Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)

            loadDataDatagridTimeSheet()
            loadDataDatagridSummary()

            lblFileExcelImport.Text = "-"
            lblproses.Visible = False
            lblproses.Text = "-"
            filename = ""
            copyOriginalFileTarget = ""
            originalFile = ""
            btnDeleteRowTimesheet.Enabled = False
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub loadDataDatagridTimeSheet()
        Try
            Dim func As New DllPayrollBali.classPayrollBali

            '----- Untuk Ambil Data Time Sheet Dari Tabel timesheetbali -----
            If dt Is Nothing Then
                dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            Else
                dt = Nothing

                dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            End If

            dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)

            If dgTimeSheet.Rows.Count >= 0 Then
                dgTimeSheet.DataSource = Nothing
            End If

            dgTimeSheet.DataSource = dt
            lblCount.Text = dgTimeSheet.Rows.Count
            prepareDatagridTimeSheet()
            btnDeleteRowTimesheet.Enabled = False
            '----- Untuk Ambil Data Time Sheet Dari Tabel timesheetbali -----
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub loadDataDatagridSummary()
        Try
            Dim func As New DllPayrollBali.classPayrollBali

            '----- Untuk Ambil Data Summary Dari Tabel timesheetbali dan di jumlahkan sesuai dengan tanggal yang di cari -----
            If dt2 Is Nothing Then
                dt2 = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            Else
                dt2 = Nothing

                dt2 = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            End If

            dt2 = func.getDataSummaryTimeSheet(startDateFixed, endDateFixed, empName)

            If dgSummary.Rows.Count >= 0 Then
                dgSummary.DataSource = Nothing
            End If

            dgSummary.DataSource = dt2
            lblCountSum.Text = dgSummary.Rows.Count
            prepareDatagridSummary()
            '----- Untuk Ambil Data Summary Dari Tabel timesheetbali dan di jumlahkan sesuai dengan tanggal yang di cari -----
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub prepareDatagridTimeSheet()
        Try
            dgTimeSheet.ClearSelection()

            ' Make a color style the header.
            dgTimeSheet.EnableHeadersVisualStyles = False
            Dim header_style As New DataGridViewCellStyle
            header_style.BackColor = Color.LightCyan
            ' Make a color style the header.

            dgTimeSheet.Columns("id").Visible = False

            dgTimeSheet.Columns("idImport").Visible = False

            dgTimeSheet.Columns("lastName").HeaderCell.Value = "Last Name"
            'dgTimeSheet.Columns("lastName").ReadOnly = True
            dgTimeSheet.Columns("lastName").Frozen = True

            dgTimeSheet.Columns("firstName").HeaderCell.Value = "First Name"
            'dgTimeSheet.Columns("firstName").ReadOnly = True
            dgTimeSheet.Columns("firstName").Frozen = True

            dgTimeSheet.Columns("dateTimeSheet").HeaderCell.Value = "Date"
            'dgTimeSheet.Columns("dateTimeSheet").ReadOnly = True
            dgTimeSheet.Columns("dateTimeSheet").Frozen = True
            dgTimeSheet.Columns("dateTimeSheet").DefaultCellStyle.Format = "dd/MM/yyyy"

            dgTimeSheet.Columns("clockOn").HeaderCell.Value = "Clock On"
            'dgTimeSheet.Columns("clockOn").ReadOnly = True
            dgTimeSheet.Columns("clockOn").Frozen = True

            dgTimeSheet.Columns("clockOff").HeaderCell.Value = "Clock Off"
            'dgTimeSheet.Columns("clockOff").ReadOnly = True
            dgTimeSheet.Columns("clockOff").Frozen = True

            dgTimeSheet.Columns("breaks").HeaderCell.Value = "Breaks"
            'dgTimeSheet.Columns("breaks").ReadOnly = True
            dgTimeSheet.Columns("breaks").Frozen = True

            dgTimeSheet.Columns("actualHours").HeaderCell.Value = "Actual Hours"
            'dgTimeSheet.Columns("actualHours").ReadOnly = True
            dgTimeSheet.Columns("actualHours").Frozen = True

            dgTimeSheet.Columns("toBePaidHours").HeaderCell.Value = "To Be Paid Hours"
            'dgTimeSheet.Columns("toBePaidHours").ReadOnly = True
            dgTimeSheet.Columns("toBePaidHours").Frozen = True

            dgTimeSheet.Columns("baliBaseHourly").HeaderCell.Value = "01 Bali Base Hourly"
            dgTimeSheet.Columns("baliBaseHourly").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliBaseHourly").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliOvertime").HeaderCell.Value = "01 Bali Overtime (Flat Rate)"
            dgTimeSheet.Columns("baliOvertime").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliOvertime").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliHolidayPay").HeaderCell.Value = "01 Bali Holiday Pay"
            dgTimeSheet.Columns("baliHolidayPay").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliHolidayPay").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliSickPay").HeaderCell.Value = "01 Bali Sick Pay"
            dgTimeSheet.Columns("baliSickPay").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliSickPay").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliFlexiTimeEarned").HeaderCell.Value = "01 Bali Flexi Time - Earned"
            dgTimeSheet.Columns("baliFlexiTimeEarned").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliFlexiTimeEarned").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliFlexiTimeTaken").HeaderCell.Value = "01 Bali Flext Time - Taken"
            dgTimeSheet.Columns("baliFlexiTimeTaken").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliFlexiTimeTaken").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("baliOvertime15x").HeaderCell.Value = "01 Bali Overtime (1.5x)"
            dgTimeSheet.Columns("baliOvertime15x").HeaderCell.Style = header_style
            dgTimeSheet.Columns("baliOvertime15x").DefaultCellStyle.BackColor = Color.LightYellow

            dgTimeSheet.Columns("created_at").Visible = False
            dgTimeSheet.Columns("staff_add").Visible = False
            dgTimeSheet.Columns("update_at").Visible = False
            dgTimeSheet.Columns("staff_update").Visible = False
            dgTimeSheet.Columns("cardId").Visible = False
            'dateTimePicker1.Visible = False
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub prepareDatagridSummary()
        Try
            dgSummary.ClearSelection()

            ' Make a color style the header.
            dgSummary.EnableHeadersVisualStyles = False
            Dim header_styledgSummary As New DataGridViewCellStyle
            header_styledgSummary.BackColor = Color.LightCyan
            ' Make a color style the header.

            dgSummary.Columns("firstName").HeaderCell.Value = "First Name"
            dgSummary.Columns("firstName").ReadOnly = True
            dgSummary.Columns("firstName").Frozen = True

            dgSummary.Columns("lastName").HeaderCell.Value = "Last Name"
            dgSummary.Columns("lastName").ReadOnly = True
            dgSummary.Columns("lastName").Frozen = True

            dgSummary.Columns("actualHours").HeaderCell.Value = "Actual Hours"
            dgSummary.Columns("actualHours").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("actualHours").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("actualHours").ReadOnly = True

            dgSummary.Columns("toBePaidHours").HeaderCell.Value = "To Be Paid Hours"
            dgSummary.Columns("toBePaidHours").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("toBePaidHours").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("toBePaidHours").ReadOnly = True

            dgSummary.Columns("baliBaseHourly").HeaderCell.Value = "01 Bali Base Hourly"
            dgSummary.Columns("baliBaseHourly").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliBaseHourly").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliBaseHourly").ReadOnly = True

            dgSummary.Columns("baliOvertime").HeaderCell.Value = "01 Bali Overtime (Flat Rate)"
            dgSummary.Columns("baliOvertime").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliOvertime").ReadOnly = True
            dgSummary.Columns("baliOvertime").HeaderCell.Style = header_styledgSummary

            dgSummary.Columns("baliHolidayPay").HeaderCell.Value = "01 Bali Holiday Pay"
            dgSummary.Columns("baliHolidayPay").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliHolidayPay").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliHolidayPay").ReadOnly = True

            dgSummary.Columns("baliSickPay").HeaderCell.Value = "01 Bali Sick Pay"
            dgSummary.Columns("baliSickPay").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliSickPay").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliSickPay").ReadOnly = True

            dgSummary.Columns("baliFlexiTimeEarned").HeaderCell.Value = "01 Bali Flexi Time - Earned"
            dgSummary.Columns("baliFlexiTimeEarned").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliFlexiTimeEarned").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliFlexiTimeEarned").ReadOnly = True

            dgSummary.Columns("baliFlexiTimeTaken").HeaderCell.Value = "01 Bali Flext Time - Taken"
            dgSummary.Columns("baliFlexiTimeTaken").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliFlexiTimeTaken").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliFlexiTimeTaken").ReadOnly = True

            dgSummary.Columns("baliOvertime15x").HeaderCell.Value = "01 Bali Overtime (1.5x)"
            dgSummary.Columns("baliOvertime15x").HeaderCell.Style = header_styledgSummary
            dgSummary.Columns("baliOvertime15x").DefaultCellStyle.BackColor = Color.LightYellow
            dgSummary.Columns("baliOvertime15x").ReadOnly = True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnStaff_Click(sender As Object, e As EventArgs) Handles btnStaff.Click
        Try
            frmStaff.ShowDialog(Me)
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        Try
            'Dim a As Date
            'a = dtpEndDate.Value
            'dtpStartDate.Value = a.AddDays(-6)

            ''Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)

            'Dim seldate As DateTime = dtpEndDate.Value
            'If seldate.DayOfWeek <> DayOfWeek.Sunday Then
            '    Dim offset As Integer = DayOfWeek.Sunday - seldate.DayOfWeek
            '    Dim sunday As DateTime = seldate + TimeSpan.FromDays(offset)
            '    'MsgBox("Can only select a Sunday!", vbCritical, "Oops!")
            '    dtpEndDate.Value = sunday
            'End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        Try
            'Dim a As Date
            'a = dtpStartDate.Value
            'dtpEndDate.Value = a.AddDays(+6)

            ''Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)

            'Dim seldate As DateTime = dtpStartDate.Value
            'If seldate.DayOfWeek <> DayOfWeek.Monday Then
            '    Dim offset As Integer = DayOfWeek.Monday - seldate.DayOfWeek
            '    Dim monday As DateTime = seldate + TimeSpan.FromDays(offset)
            '    'MsgBox("Can only select a Monday!", vbCritical, "Oops!")
            '    dtpStartDate.Value = monday
            'End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            OpenFileDialog1.Filter = "Excel|*.xls;*xlsx"

            If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                Dim appPath As String = My.Application.Info.DirectoryPath
                originalFile = OpenFileDialog1.FileName

                filename = originalFile
                lblFileExcelImport.Text = OpenFileDialog1.FileName
            Else
                filename = String.Empty
                lblFileExcelImport.Text = "-"
                lblproses.Visible = False
                lblproses.Text = "-"
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            lblproses.ForeColor = Color.Red
            lblproses.Text = "Failed Proccess . . . "
        End Try
    End Sub

    Private Sub btnProccess_Click(sender As Object, e As EventArgs) Handles btnProccess.Click
        Try
            If lblFileExcelImport.Text = "-" Then
                MessageBox.Show("Please Import File Timesheet First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                lblproses.Visible = True
                lblproses.ForeColor = Color.Gold
                lblproses.Text = "Waiting Proccess . . . "

                importPayrollBali()

                filename = String.Empty
                originalFile = ""
                copyOriginalFileTarget = ""

                lblproses.ForeColor = Color.ForestGreen
                lblproses.Text = "Finish Proccess . . . "

                Dim func As New DllPayrollBali.classPayrollBali

                'Get Data dari Database fungsi getDataTimeSheetPayrollBali
                If dt Is Nothing Then
                    dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
                Else
                    dt = Nothing

                    dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
                End If

                dgTimeSheet.DataSource = Nothing
                dgTimeSheet.DataSource = dt

                lblCount.Text = dgTimeSheet.Rows.Count

                dtpStartDate.Value = startDate
                dtpEndDate.Value = endDate
                prepareDatagridTimeSheet()
                'Get Data dari Database fungsi getDataTimeSheetPayrollBali

                lblFileExcelImport.Text = "-"
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
            lblproses.ForeColor = Color.Red
            lblproses.Text = "Failed Proccess . . . "
        End Try
    End Sub

    Sub importPayrollBali()
        Try
            Dim row As String = ""
            Dim sheetNameForUpdateExcell As String = ""


            Me.Cursor = Cursors.WaitCursor
            ' Create new Application.
            Dim excel As tesExcel.Application = New tesExcel.Application
            ' Open Excel spreadsheet.
            Dim w As tesExcel.Workbook = excel.Workbooks.Open(filename)

            ' Loop over all sheets.
            For i As Integer = 1 To w.Sheets.Count
                ' Get sheet.
                Dim sheet As tesExcel.Worksheet = w.Sheets(i)

                'Get Sheet Name
                Dim sheetName As String = sheet.Name
                If sheetNameForUpdateExcell = "" Then
                    sheetNameForUpdateExcell = sheet.Name
                Else
                    sheetNameForUpdateExcell = sheetNameForUpdateExcell & "," & sheet.Name
                End If


                If sheetName.Contains("Timesheet").ToString Then

                    ' Get range.
                    Dim r As tesExcel.Range = sheet.UsedRange

                    ' Load all cells into 2d array.
                    Dim array(,) As Object = r.Value(tesExcel.XlRangeValueDataType.xlRangeValueDefault)

                    ' Scan the cells.
                    If array IsNot Nothing Then
                        'Console.WriteLine("Length: {0}", array.Length)

                        ' Get bounds of the array.
                        Dim bound0 As Integer = array.GetUpperBound(0)
                        Dim bound1 As Integer = array.GetUpperBound(1)

                        'Console.WriteLine("Dimension 0: {0}", bound0)
                        'Console.WriteLine("Dimension 1: {0}", bound1)

                        'Dim subject As String()
                        Dim mylist As List(Of String) = New List(Of String)

                        Dim idImport As String = String.Empty
                        Dim employeeName As String = String.Empty
                        Dim firtsName As String = String.Empty
                        Dim lastName As String = String.Empty
                        Dim dates As DateTime
                        Dim datesStart As DateTime
                        Dim datesEnd As DateTime
                        Dim datesFixed As String = String.Empty
                        Dim clockOn As String = String.Empty
                        Dim clockOff As String = String.Empty
                        Dim breaks As String = String.Empty
                        Dim actualHours As String = String.Empty
                        Dim dateImportCreate As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
                        Dim staffLogin As String = String.Empty

                        ' Loop over all elements.
                        For j As Integer = 1 To bound0
                            For x As Integer = 1 To bound1
                                Dim s1 As String = array(j, x)

                                If s1 <> Nothing Then
                                    If s1.ToString = "ID" Then
                                        Exit For
                                    Else
                                        If array(j, 2).ToString = "" Then
                                            Exit For
                                        End If

                                        If array(j, 4).ToString = "SICK LEAVE" Then
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = "SICK LEAVE"
                                            clockOff = "SICK LEAVE"
                                            breaks = "SICK LEAVE"
                                            actualHours = "SICK LEAVE"
                                        ElseIf array(j, 4).ToString = "SICK LEAVE - FORM ATTACHED" Then
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = "SICK LEAVE - FORM ATTACHED"
                                            clockOff = "SICK LEAVE - FORM ATTACHED"
                                            breaks = "SICK LEAVE - FORM ATTACHED"
                                            actualHours = "SICK LEAVE - FORM ATTACHED"
                                        ElseIf array(j, 4).ToString = "ANNUAL LEAVE" Then
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = "ANNUAL LEAVE"
                                            clockOff = "ANNUAL LEAVE"
                                            breaks = "ANNUAL LEAVE"
                                            actualHours = "ANNUAL LEAVE"
                                        ElseIf array(j, 4).ToString = "ANNUAL LEAVE - FORM ATTACHED" Then
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = "ANNUAL LEAVE - FORM ATTACHED"
                                            clockOff = "ANNUAL LEAVE - FORM ATTACHED"
                                            breaks = "ANNUAL LEAVE - FORM ATTACHED"
                                            actualHours = "ANNUAL LEAVE - FORM ATTACHED"
                                        ElseIf array(j, 4).ToString = "PUBHOL" Then
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = "PUBHOL"
                                            clockOff = "PUBHOL"
                                            breaks = "PUBHOL"
                                            actualHours = "PUBHOL"
                                        Else
                                            idImport = array(j, 1)
                                            employeeName = array(j, 2)
                                            dates = DateTime.ParseExact(array(j, 3), "d", CultureInfo.CurrentCulture)
                                            datesFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                            clockOn = (New DateTime()).AddDays(array(j, 4))
                                            clockOff = (New DateTime()).AddDays(array(j, 5))
                                            breaks = array(j, 8)
                                            actualHours = array(j, 9)
                                        End If
                                    End If

                                    If datesStart = Nothing Then
                                        datesStart = dates
                                        startDate = dates
                                        startDateFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                    End If

                                    If datesStart < dates Then
                                        datesEnd = dates
                                        endDate = dates
                                        endDateFixed = dates.ToString("yyyy-MM-dd HH:mm:ss")
                                    End If

                                    Dim func As New DllPayrollBali.classPayrollBali

                                    dt2 = func.getDataPayrollBaliTimeSheetForUpdate(idImport, employeeName, datesFixed)
                                    If dt2.Rows.Count > 0 Then
                                        dt = func.getDataStaffPayrollBaliChekingName(employeeName)

                                        If dt.Rows.Count > 0 Then
                                            firtsName = dt.Rows(0).Item("firstName").ToString()
                                            lastName = dt.Rows(0).Item("lastName").ToString()
                                            staffLogin = staffidPublic

                                            Dim employeeNameCheck As String = firtsName & " " & lastName

                                            func.updatePayrollBaliTimeSheet(idImport, employeeNameCheck, datesFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate, staffLogin)
                                        End If
                                    Else
                                        dt = func.getDataStaffPayrollBaliChekingName(employeeName)

                                        If dt.Rows.Count > 0 Then
                                            firtsName = dt.Rows(0).Item("firstName").ToString()
                                            lastName = dt.Rows(0).Item("lastName").ToString()
                                            staffLogin = staffidPublic

                                            func.insertPayrollBaliTimeSheet(idImport, lastName, firtsName, datesFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate, staffLogin)
                                        End If
                                    End If


                                    employeeName = String.Empty
                                    dates = Nothing
                                    datesFixed = String.Empty
                                    clockOn = String.Empty
                                    clockOff = String.Empty
                                    breaks = String.Empty
                                    actualHours = String.Empty
                                    GoTo ExitNet1
                                Else
                                    GoTo ExitNet1
                                End If
                            Next
ExitNet1:
                        Next
                    End If
                End If
            Next
ExitAllFor:
            w.Close()

        Catch ex As Exception
            MessageBox.Show("Error has encountered " & ex.Message, "Bug Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            lblproses.ForeColor = Color.Red
            lblproses.Text = "Failed Proccess . . . "
        End Try
    End Sub

    Private Sub btnClearFile_Click(sender As Object, e As EventArgs) Handles btnClearFile.Click
        Try
            lblFileExcelImport.Text = "-"
            lblproses.Visible = False
            lblproses.Text = "-"
            filename = String.Empty
            copyOriginalFileTarget = ""
            originalFile = ""
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Check Datagrid Timesheet isi data atau tidak
            If dgTimeSheet.Rows.Count <= 0 Then
                MessageBox.Show("Please search data TimsSheet Frist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Check Datagrid Timesheet isi data atau tidak

            Dim datechoosestartdate As String = Format(dtpStartDate.Value, "dd MM yyyy")
            Dim datechooseenddate As String = Format(dtpEndDate.Value, "dd MM yyyy")
            Dim filenameexport As String = "Export Timesheet To CSV " & datechoosestartdate & " - " & datechooseenddate

            Dim saveDialogs As New SaveFileDialog()
            saveDialogs.FileName = filenameexport
            saveDialogs.Filter = "TXT files (.txt)|*.txt"
            saveDialogs.FilterIndex = 2

            If saveDialogs.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                lblproses.Visible = True
                lblproses.ForeColor = Color.Gold
                lblproses.Text = "Proccessing Export File CSV"

                Dim sFile As String = saveDialogs.FileName

                Dim fileNameOnly As String = Path.GetFileNameWithoutExtension(sFile)
                Dim extension As String = Path.GetExtension(sFile)
                Dim path__1 As String = Path.GetDirectoryName(sFile)
                Dim newFullPath As String = sFile

                'Build the CSV file data as a Comma separated string.
                Dim csv As String = String.Empty

                'Buat Header row untuk CSV file.
                csv += "Emp. Co./Last Name" & ","c
                csv += "Emp. First Name" & ","c
                csv += "Payroll Category" & ","c
                csv += "Job" & ","c
                csv += "Cust. Co./Last Name" & ","c
                csv += "Cust. First Name" & ","c
                csv += "Notes" & ","c
                csv += "Date" & ","c
                csv += "Units" & ","c
                csv += "Emp. Card ID" & ","c
                csv += "Emp. Record ID" & ","c
                csv += "Start/Stop Time" & ","c
                csv += "Customer Card ID" & ","c
                csv += "Customer Record ID"
                'Buat Header row untuk CSV file.

                csv += vbCr & vbLf 'Add new line.

                'Reset Datatable kalau isi refresh ulang
                If dtTimeSheet Is Nothing Then
                Else
                    If dtTimeSheet.Rows.Count > 0 Then
                        dtTimeSheet = Nothing
                    End If
                End If


                'Reset Datatable kalau isi refresh ulang

                'Get Data dari database fungsi getDataTimeSheetPayrollBali
                Dim func As New DllPayrollBali.classPayrollBali
                dtTimeSheet = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
                'Get Data dari database fungsi getDataTimeSheetPayrollBali

                'Adding the Rows
                For Each column As DataColumn In dtTimeSheet.Columns

                    If column.ColumnName.ToString() = "baliBaseHourly" Then
                        For i = 0 To dtTimeSheet.Rows.Count - 1

                            Dim dateTimeSheet As DateTime = dtTimeSheet.Rows(i).Item("dateTimeSheet").ToString().Replace(",", ";") & ","c
                            Dim format As String = "dd/MM/yyyy"
                            Dim baliBaseHourly As String = dtTimeSheet.Rows(i).Item("baliBaseHourly").ToString
                            Dim baliOvertime As String = dtTimeSheet.Rows(i).Item("baliOvertime").ToString
                            Dim baliHolidayPay As String = dtTimeSheet.Rows(i).Item("baliHolidayPay").ToString
                            Dim baliSickPay As String = dtTimeSheet.Rows(i).Item("baliSickPay").ToString
                            Dim baliFlexiTimeEarned As String = dtTimeSheet.Rows(i).Item("baliFlexiTimeEarned").ToString
                            Dim baliFlexiTimeTaken As String = dtTimeSheet.Rows(i).Item("baliFlexiTimeTaken").ToString
                            Dim baliOvertime15x As String = dtTimeSheet.Rows(i).Item("baliOvertime15x").ToString
                            Dim cardId As String = ""

                            'Get card ID dari database table join staffpayrollbali dan timesheetbali
                            If cardId = "" Then
                                cardId = dtTimeSheet.Rows(i).Item("cardId").ToString()
                            End If

                            dtGetStaffID = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
                            'Get card ID dari database table join staffpayrollbali dan timesheetbali


                            If baliBaseHourly = "0" Or baliBaseHourly = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Base Hourly" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliBaseHourly").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliOvertime = "0" Or baliOvertime = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Overtime (Flat Rate)" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliOvertime").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliHolidayPay = "0" Or baliHolidayPay = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Holiday Pay" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliHolidayPay").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliSickPay = "0" Or baliSickPay = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Sick Pay" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliSickPay").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliFlexiTimeEarned = "0" Or baliFlexiTimeEarned = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Flexi Time - Earned" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliFlexiTimeEarned").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliFlexiTimeTaken = "0" Or baliFlexiTimeTaken = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Flext Time - Taken" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliFlexiTimeTaken").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                            If baliOvertime15x = "0" Or baliOvertime15x = "" Then
                            Else
                                csv += dtTimeSheet.Rows(i).Item("lastName").ToString().Replace(",", ";") & ","c 'Emp. Co./Last Name
                                csv += dtTimeSheet.Rows(i).Item("firstName").ToString().Replace(",", ";") & ","c 'Emp. First Name
                                csv += "01 Bali Overtime (1.5x)" & ","c 'Payroll Category
                                csv += "" & ","c 'Job
                                csv += "" & ","c 'Cust. Co./Last Name
                                csv += "" & ","c 'Cust. First Name
                                csv += "" & ","c 'Notes
                                csv += dateTimeSheet.ToString(format) & ","c 'Date
                                csv += dtTimeSheet.Rows(i).Item("baliOvertime15x").ToString().Replace(",", ";") & ","c 'Units
                                If cardId = "" Then
                                    csv += "*None" & ","c 'Emp. Card ID
                                Else
                                    csv += cardId & ","c 'Emp. Card ID
                                End If
                                csv += "" & ","c 'Emp. Record ID
                                csv += "" & ","c 'Start/Stop Time
                                csv += "" & ","c 'Customer Card ID
                                csv += "0" 'Customer Record ID
                                csv += vbCr & vbLf 'Add new line.
                            End If

                        Next
                    End If
                Next

                'Exporting to CSV File
                'Dim folderPath As String = "C:\CSV\"
                File.WriteAllText(newFullPath, csv)
                MessageBox.Show("Export CSV Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Exporting to CSV File
            End If

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            lblproses.ForeColor = Color.Red
            lblproses.Text = "Failed Proccess . . . "
            Me.Cursor = Cursors.Default
        Finally
            lblproses.ForeColor = Color.ForestGreen
            lblproses.Text = "Finish Export CSV . . . "
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            startDate = DateTime.Parse(dtpStartDate.Text)
            endDate = DateTime.Parse(dtpEndDate.Text)

            startDateFixed = startDate.ToString("yyyy-MM-dd HH:mm:ss")
            endDateFixed = endDate.ToString("yyyy-MM-dd HH:mm:ss")

            If txtEmp.Text <> "" Then
                empName = txtEmp.Text
            Else
                empName = ""
            End If

            Dim func As New DllPayrollBali.classPayrollBali

            '----- Untuk Ambil Data Time Sheet Dari Tabel timesheetbali -----
            If dt Is Nothing Then
                dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            Else
                dt = Nothing

                dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed, empName)
            End If

            'dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed)

            If dgTimeSheet.Rows.Count >= 0 Then
                dgTimeSheet.DataSource = Nothing
            End If

            dgTimeSheet.DataSource = dt
            lblCount.Text = dgTimeSheet.Rows.Count
            prepareDatagridTimeSheet()
            btnDeleteRowTimesheet.Enabled = False
            '----- Untuk Ambil Data Time Sheet Dari Tabel timesheetbali -----

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRefreshSum_Click(sender As Object, e As EventArgs) Handles btnRefreshSum.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            startDate = DateTime.Parse(dtpStartDate.Text)
            endDate = DateTime.Parse(dtpEndDate.Text)

            startDateFixed = startDate.ToString("yyyy-MM-dd HH:mm:ss")
            endDateFixed = endDate.ToString("yyyy-MM-dd HH:mm:ss")

            Dim func As New DllPayrollBali.classPayrollBali

            '----- Untuk Ambil Data Summary Dari Tabel timesheetbali dan di jumlahkan sesuai dengan tanggal yang di cari -----
            If dt2 Is Nothing Then
                dt2 = func.getDataSummaryTimeSheet(startDateFixed, endDateFixed, empName)
            Else
                dt2 = Nothing

                dt2 = func.getDataSummaryTimeSheet(startDateFixed, endDateFixed, empName)
            End If

            'dt2 = func.getDataSummaryTimeSheet(startDateFixed, endDateFixed, empName)

            If dgSummary.Rows.Count >= 0 Then
                dgSummary.DataSource = Nothing
            End If

            dgSummary.DataSource = dt2
            lblCountSum.Text = dgSummary.Rows.Count
            prepareDatagridSummary()
            '----- Untuk Ambil Data Summary Dari Tabel timesheetbali dan di jumlahkan sesuai dengan tanggal yang di cari -----

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgTimeSheet_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgTimeSheet.CellEndEdit
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim toBePaidHours As String = String.Empty
            Dim toBePaidHoursDec As Decimal = Nothing

            Dim baliBaseHourly As String = String.Empty
            Dim baliBaseHourlyDec As Decimal = Nothing

            Dim baliOvertime As String = String.Empty
            Dim baliOvertimeDec As Decimal = Nothing

            Dim baliHolidayPay As String = String.Empty
            Dim baliHolidayPayDec As Decimal = Nothing

            Dim baliSickPay As String = String.Empty
            Dim baliSickPayDec As Decimal = Nothing

            Dim baliFlexiTimeEarned As String = String.Empty
            Dim baliFlexiTimeEarnedDec As Decimal = Nothing

            Dim baliFlexiTimeTaken As String = String.Empty
            Dim baliFlexiTimeTakenDec As Decimal = Nothing

            Dim baliOvertime15x As String = String.Empty
            Dim baliOvertime15xDec As Decimal = Nothing

            Dim id As String = String.Empty
            Dim func As New DllPayrollBali.classPayrollBali

            Dim idImpor As String = String.Empty
            Dim lastName As String = String.Empty
            Dim firstName As String = String.Empty
            Dim dateTimeSheet As DateTime = Nothing
            Dim dateTimeSheetFixed As String = String.Empty
            Dim clockOn As String = String.Empty
            Dim clockOff As String = String.Empty
            Dim breaks As String = String.Empty
            Dim actualHours As String = String.Empty
            Dim dateImportCreate As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim staffLogin As String = staffidPublic

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("id").Value.ToString())) Then
            Else
                id = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("lastName").Value.ToString())) Then
            Else
                lastName = dgTimeSheet.Rows(e.RowIndex).Cells("lastName").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("firstName").Value.ToString())) Then
            Else
                firstName = dgTimeSheet.Rows(e.RowIndex).Cells("firstName").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("dateTimeSheet").Value.ToString())) Then
            Else
                dateTimeSheet = dgTimeSheet.Rows(e.RowIndex).Cells("dateTimeSheet").Value
                dateTimeSheetFixed = dateTimeSheet.ToString("yyyy-MM-dd HH:mm:ss")
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOn").Value.ToString())) Then
            Else
                clockOn = dgTimeSheet.Rows(e.RowIndex).Cells("clockOn").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOff").Value.ToString())) Then
            Else
                clockOff = dgTimeSheet.Rows(e.RowIndex).Cells("clockOff").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("breaks").Value.ToString())) Then
            Else
                breaks = dgTimeSheet.Rows(e.RowIndex).Cells("breaks").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("actualHours").Value.ToString())) Then
            Else
                actualHours = dgTimeSheet.Rows(e.RowIndex).Cells("actualHours").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value.ToString())) Then
            Else
                baliBaseHourly = dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value
                baliBaseHourlyDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value.ToString())) Then
            Else
                baliOvertime = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value
                baliOvertimeDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value.ToString())) Then
            Else
                baliHolidayPay = dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value
                baliHolidayPayDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value.ToString())) Then
            Else
                baliSickPay = dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value
                baliSickPayDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value.ToString())) Then
            Else
                baliFlexiTimeEarned = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value
                baliFlexiTimeEarnedDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value.ToString())) Then
            Else
                baliFlexiTimeTaken = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value
                baliFlexiTimeTakenDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value
            End If

            If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value.ToString())) Then
            Else
                'dt = func.getDataPayrollBalibaliOvertime15x(id)
                'If dt.Rows.Count > 0 Then
                'If dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = dt.Rows(0).Item("baliOvertime15x").ToString() Then
                baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
                'Else
                '    baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                '    baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                '    dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x * 1.5
                'End If
                'End If
            End If

            'Untuk hitung hasil penjumlahan dari yang diinputkan
            toBePaidHoursDec = baliBaseHourlyDec + baliOvertimeDec + baliHolidayPayDec + baliSickPayDec + baliFlexiTimeEarnedDec + (baliOvertime15xDec * 1.5)
            toBePaidHours = toBePaidHoursDec
            dgTimeSheet.Rows(e.RowIndex).Cells("toBePaidHours").Value = Format(toBePaidHoursDec, "0.00")
            'Untuk hitung hasil penjumlahan dari yang diinputkan

            If id = "" Then
                If lastName <> "" And firstName <> "" And dateTimeSheetFixed <> "" And clockOn <> "" And clockOff <> "" And breaks <> "" And actualHours <> "" Then
                    func.insertPayrollBaliTimeSheetManual(idImpor, lastName, firstName, dateTimeSheetFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate, staffLogin)
                    getIdTimesheet = ""
                    loadDataDatagridTimeSheet()
                End If
            Else
                func.updatePayrollBaliTimeSheetDataStaff(idImpor, lastName, firstName, dateTimeSheetFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate, id, staffLogin)
                getIdTimesheet = ""
            End If

            'Untuk Simpan Ke Database Table timesheetbali jika ada data yang berubah / diketik dari datagrid view
            If dgTimeSheet.Rows.Count > 0 Then
                func.updatePayrollBaliCountDataTimeSheet(toBePaidHours, baliBaseHourly, baliOvertime, baliHolidayPay, baliSickPay, baliFlexiTimeEarned, baliFlexiTimeTaken, baliOvertime15x, id, staffidPublic)
            End If
            'Untuk Simpan Ke Database Table timesheetbali jika ada data yang berubah / diketik dari datagrid view

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Dim getIdTimesheet As String = String.Empty
    Private dateTimePicker1 As DateTimePicker
    Dim colum As String = ""
    Dim oldColum As String = ""
    Dim row As String = ""
    Private Sub dgTimeSheet_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTimeSheet.CellClick
        Try
            'If Not e.RowIndex = -1 Then
            '    If e.ColumnIndex = 4 Then
            '        colum = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value

            '        If colum <> oldColum Then
            '            dateTimePicker1 = New DateTimePicker()
            '        ElseIf colum = oldColum Then
            '            dateTimePicker1.Visible = False
            '            dateTimePicker1 = New DateTimePicker()
            '        End If
            '        'Dim dt = New DataTable()
            '        'dt.Columns.Add("Date", GetType(DateTime))
            '        'dt.Rows.Add(DateTime.Now)
            '        'dt.Rows.Add(DateTime.Now)
            '        'Dim column = New CalendarColumn()
            '        'column.DataPropertyName = "dateTimeSheet"

            '        dgTimeSheet.Controls.Add(dateTimePicker1)
            '        'Me.dgTimeSheet.Columns.Add(column)
            '        'Me.dgTimeSheet.DataSource = dt

            '        dateTimePicker1.Format = DateTimePickerFormat.Short
            '        ' Create retangular area that represents the display area for a cell.
            '        Dim oRectangle As Rectangle = dgTimeSheet.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            '        ' Setting area for dateTimePicker1.
            '        dateTimePicker1.Size = New Size(oRectangle.Width, oRectangle.Height)
            '        ' Setting location for dateTimePicker1.
            '        dateTimePicker1.Location = New Point(oRectangle.X, oRectangle.Y)
            '        ' An event attached to dateTimePicker1 which is fired when any date is selected.
            '        AddHandler dateTimePicker1.TextChanged, AddressOf DateTimePickerChange
            '        ' An event attached to dateTimePicker1 which is fired when DateTimeControl is closed.
            '        AddHandler dateTimePicker1.CloseUp, AddressOf DateTimePickerClose
            '        oldColum = colum
            '        colum = ""
            '    Else
            '        'AddHandler dateTimePicker1.CloseUp, AddressOf DateTimePickerClose
            '        'dateTimePicker1.Visible = False
            '    End If
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("lastName").Value.ToString())) Then
            '    dgTimeSheet.Columns("lastName").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("lastName").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("firstName").Value.ToString())) Then
            '    dgTimeSheet.Columns("firstName").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("firstName").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("dateTimeSheet").Value.ToString())) Then
            '    dgTimeSheet.Columns("dateTimeSheet").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("dateTimeSheet").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOn").Value.ToString())) Then
            '    dgTimeSheet.Columns("clockOn").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("clockOn").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOff").Value.ToString())) Then
            '    dgTimeSheet.Columns("clockOff").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("clockOff").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("breaks").Value.ToString())) Then
            '    dgTimeSheet.Columns("breaks").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("breaks").ReadOnly = True
            'End If

            'If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("actualHours").Value.ToString())) Then
            '    dgTimeSheet.Columns("actualHours").ReadOnly = False
            'Else
            '    dgTimeSheet.Columns("actualHours").ReadOnly = True
            'End If


            getIdTimesheet = ""
            If dgTimeSheet.SelectedRows.Count > 0 Then
                For Each selectedItem As DataGridViewRow In dgTimeSheet.SelectedRows
                    'show ids of multiple selected rows
                    If getIdTimesheet = "" Then
                        getIdTimesheet = selectedItem.Cells("id").Value
                    Else
                        getIdTimesheet = getIdTimesheet & "," & selectedItem.Cells("id").Value
                    End If
                Next selectedItem

                'getIdTimesheet = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value.ToString()
                btnDeleteRowTimesheet.Enabled = True
            Else
                getIdTimesheet = ""
                btnDeleteRowTimesheet.Enabled = False
            End If
            'End If

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub DateTimePickerChange(ByVal sender As Object, ByVal e As EventArgs)
        dgTimeSheet.CurrentCell.Value = dateTimePicker1.Text.ToString()
        MessageBox.Show(String.Format("Date changed to {0}", dateTimePicker1.Text.ToString()))
        AddHandler dateTimePicker1.CloseUp, AddressOf DateTimePickerClose
    End Sub

    Private Sub DateTimePickerClose(ByVal sender As Object, ByVal e As EventArgs)
        dateTimePicker1.Visible = False
    End Sub

    Private Sub CopyCells()
        Try
            Clipboard.SetDataObject(dgTimeSheet.GetClipboardContent)
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub PasteCells()
        Try
            Dim s = Clipboard.GetText
            Dim ci = dgTimeSheet.CurrentCell.ColumnIndex
            Dim ri = dgTimeSheet.CurrentCell.RowIndex
            Dim colCount = dgTimeSheet.Columns.Count
            Dim rowCount = dgTimeSheet.Rows.Count
            dgTimeSheet.BeginEdit(True)

            For Each r In s.Split({ControlChars.CrLf}, StringSplitOptions.None)
                Dim Cell = ci
                For Each c In r.Split({ControlChars.Tab}, StringSplitOptions.None)
                    If Cell >= colCount Then Exit For
                    dgTimeSheet(Cell, ri).Value = c
                    Cell += 1
                Next
                ri += 1
                If ri >= rowCount Then Exit For
            Next

            dgTimeSheet.EndEdit()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dgTimeSheet_KeyDown(sender As Object, e As KeyEventArgs) Handles dgTimeSheet.KeyDown
        Try
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.C
                        CopyCells()
                        e.Handled = True
                    Case Keys.V
                        PasteCells()
                        e.Handled = True
                End Select
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dgTimeSheet_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgTimeSheet.CellLeave
        'Try
        '    Dim func As New DllPayrollBali.classPayrollBali

        '    Dim idImpor As String = String.Empty
        '    Dim lastName As String = String.Empty
        '    Dim firstName As String = String.Empty
        '    Dim dateTimeSheet As DateTime = Nothing
        '    Dim dateTimeSheetFixed As String = String.Empty
        '    Dim clockOn As String = String.Empty
        '    Dim clockOff As String = String.Empty
        '    Dim breaks As String = String.Empty
        '    Dim actualHours As String = String.Empty
        '    Dim dateImportCreate As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        '    Dim staffLogin As String = staffidPublic
        '    Dim id As String = String.Empty

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("id").Value.ToString())) Then
        '    Else
        '        id = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("lastName").Value.ToString())) Then
        '    Else
        '        lastName = dgTimeSheet.Rows(e.RowIndex).Cells("lastName").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("firstName").Value.ToString())) Then
        '    Else
        '        firstName = dgTimeSheet.Rows(e.RowIndex).Cells("firstName").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("dateTimeSheet").Value.ToString())) Then
        '    Else
        '        dateTimeSheet = dgTimeSheet.Rows(e.RowIndex).Cells("dateTimeSheet").Value
        '        dateTimeSheetFixed = dateTimeSheet.ToString("yyyy-MM-dd HH:mm:ss")
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOn").Value.ToString())) Then
        '    Else
        '        clockOn = dgTimeSheet.Rows(e.RowIndex).Cells("clockOn").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("clockOff").Value.ToString())) Then
        '    Else
        '        clockOff = dgTimeSheet.Rows(e.RowIndex).Cells("clockOff").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("breaks").Value.ToString())) Then
        '    Else
        '        breaks = dgTimeSheet.Rows(e.RowIndex).Cells("breaks").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("actualHours").Value.ToString())) Then
        '    Else
        '        actualHours = dgTimeSheet.Rows(e.RowIndex).Cells("actualHours").Value
        '    End If

        '    If id = "" Then
        '        If lastName <> "" And firstName <> "" And dateTimeSheetFixed <> "" And clockOn <> "" And clockOff <> "" And breaks <> "" And actualHours <> "" Then
        '            func.insertPayrollBaliTimeSheetManual(idImpor, lastName, firstName, dateTimeSheetFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate, staffLogin)
        '            idImpor = ""
        '            lastName = ""
        '            firstName = ""
        '            dateTimeSheet = Nothing
        '            dateTimeSheetFixed = ""
        '            clockOn = ""
        '            clockOff = ""
        '            breaks = ""
        '            actualHours = ""
        '            dateImportCreate = ""
        '            staffLogin = ""
        '            getIdTimesheet = ""
        '            id = ""
        '            'loadDataDatagridTimeSheet()
        '            Exit Sub
        '        End If
        '    Else
        '        'func.updatePayrollBaliTimeSheetDataStaff(idImpor, lastName, firstName, dateTimeSheet, clockOn, clockOff, breaks, actualHours, dateImportCreate, id, staffLogin)
        '        'getIdTimesheet = ""
        '    End If
        'Catch ex As Exception
        '    logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        'End Try



        'Try
        '    Dim toBePaidHours As String = String.Empty
        '    Dim toBePaidHoursDec As Decimal = Nothing

        '    Dim baliBaseHourly As String = String.Empty
        '    Dim baliBaseHourlyDec As Decimal = Nothing

        '    Dim baliOvertime As String = String.Empty
        '    Dim baliOvertimeDec As Decimal = Nothing

        '    Dim baliHolidayPay As String = String.Empty
        '    Dim baliHolidayPayDec As Decimal = Nothing

        '    Dim baliSickPay As String = String.Empty
        '    Dim baliSickPayDec As Decimal = Nothing

        '    Dim baliFlexiTimeEarned As String = String.Empty
        '    Dim baliFlexiTimeEarnedDec As Decimal = Nothing

        '    Dim baliFlexiTimeTaken As String = String.Empty
        '    Dim baliFlexiTimeTakenDec As Decimal = Nothing

        '    Dim baliOvertime15x As String = String.Empty
        '    Dim baliOvertime15xDec As Decimal = Nothing

        '    Dim id As String = String.Empty
        '    Dim func As New DllPayrollBali.classPayrollBali


        '    id = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value.ToString())) Then
        '    Else
        '        baliBaseHourly = dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value
        '        baliBaseHourlyDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliBaseHourly").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value.ToString())) Then
        '    Else
        '        baliOvertime = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value
        '        baliOvertimeDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value.ToString())) Then
        '    Else
        '        baliHolidayPay = dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value
        '        baliHolidayPayDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliHolidayPay").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value.ToString())) Then
        '    Else
        '        baliSickPay = dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value
        '        baliSickPayDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliSickPay").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value.ToString())) Then
        '    Else
        '        baliFlexiTimeEarned = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value
        '        baliFlexiTimeEarnedDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeEarned").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value.ToString())) Then
        '    Else
        '        baliFlexiTimeTaken = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value
        '        baliFlexiTimeTakenDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliFlexiTimeTaken").Value
        '    End If

        '    If (String.IsNullOrWhiteSpace(dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value.ToString())) Then
        '    Else
        '        dt = func.getDataPayrollBalibaliOvertime15x(id)
        '        If dt.Rows.Count > 0 Then
        '            If dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = dt.Rows(0).Item("baliOvertime15x").ToString() Then
        '                baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
        '                baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
        '                dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
        '            Else
        '                baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
        '                baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
        '                dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
        '            End If
        '        End If
        '    End If

        '    'Untuk hitung hasil penjumlahan dari yang diinputkan
        '    toBePaidHoursDec = baliBaseHourlyDec + baliOvertimeDec + baliHolidayPayDec + baliSickPayDec + baliFlexiTimeEarnedDec + baliOvertime15xDec
        '    toBePaidHours = toBePaidHoursDec
        '    dgTimeSheet.Rows(e.RowIndex).Cells("toBePaidHours").Value = toBePaidHoursDec
        '    'Untuk hitung hasil penjumlahan dari yang diinputkan

        '    'Untuk Simpan Ke Database Table timesheetbali jika ada data yang berubah / diketik dari datagrid view
        '    If dgTimeSheet.Rows.Count > 0 Then
        '        func.updatePayrollBaliCountDataTimeSheet(toBePaidHours, baliBaseHourly, baliOvertime, baliHolidayPay, baliSickPay, baliFlexiTimeEarned, baliFlexiTimeTaken, baliOvertime15x, id, staffidPublic)
        '    End If
        '    'Untuk Simpan Ke Database Table timesheetbali jika ada data yang berubah / diketik dari datagrid view

        'Catch ex As Exception
        '    logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        'End Try
    End Sub

    Private Sub btnClearSerach_Click(sender As Object, e As EventArgs) Handles btnClearSerach.Click
        Try
            'Untuk Clear hasil search data
            dgTimeSheet.DataSource = Nothing
            dgSummary.DataSource = Nothing
            dt = Nothing
            dt2 = Nothing
            dtTimeSheet = Nothing
            dtGetStaffID = Nothing
            btnDeleteRowTimesheet.Enabled = False
            txtEmp.Text = ""
            empName = String.Empty
            'Untuk Clear hasil search data
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            Me.Close()
            frmLogin.Close()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDeleteRowTimesheet_Click(sender As Object, e As EventArgs) Handles btnDeleteRowTimesheet.Click
        Try
            'MsgBox(getIdTimesheet)
            'getIdTimesheet = ""
            If getIdTimesheet <> "" Then
                Dim result As DialogResult = MessageBox.Show("Are You Sure Delete This Timesheet", "Delete Timesheet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    btnDeleteRowTimesheet.Enabled = False
                    getIdTimesheet = ""
                ElseIf result = DialogResult.Yes Then
                    Dim func As New DllPayrollBali.classPayrollBali

                    ' Split string based on comma
                    Dim getIdTimesheetSplit As String() = getIdTimesheet.Split(New Char() {","c})

                    ' Use For Each loop over words and display them
                    Dim getIdTimesheetSplitFix As String
                    For Each getIdTimesheetSplitFix In getIdTimesheetSplit
                        func.deletePayrollBaliTimeSheet(getIdTimesheetSplitFix)
                    Next

                    btnDeleteRowTimesheet.Enabled = False
                    getIdTimesheet = ""
                    loadDataDatagridTimeSheet()
                    loadDataDatagridSummary()
                End If
            Else
                btnDeleteRowTimesheet.Enabled = False
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dgTimeSheet_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgTimeSheet.DataError
    End Sub

    Dim sumCellSelected As Decimal = 0
    Private Sub dgTimeSheet_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgTimeSheet.CellMouseUp
        Try
            If dgTimeSheet.SelectedCells.Count > 0 Then
                sumCellSelected = 0
                For Each selectedItem As DataGridViewCell In dgTimeSheet.SelectedCells
                    If sumCellSelected = 0 Then
                        If (String.IsNullOrWhiteSpace(selectedItem.Value.ToString())) Then
                            'sumCellSelected = 0
                            'lblCountAutoSum.Text = ""
                        Else
                            If IsNumeric(selectedItem.Value.ToString()) Then
                                ' childAge successfully parsed as Integer
                                sumCellSelected = selectedItem.Value
                                lblCountAutoSum.Text = sumCellSelected
                            End If
                        End If
                    Else
                        If (String.IsNullOrWhiteSpace(selectedItem.Value.ToString())) Then
                            'sumCellSelected = 0
                            'lblCountAutoSum.Text = ""
                        Else
                            If IsNumeric(selectedItem.Value.ToString()) Then
                                ' childAge successfully parsed as Integer
                                sumCellSelected = sumCellSelected + selectedItem.Value
                                lblCountAutoSum.Text = sumCellSelected
                            End If
                        End If
                    End If
                Next

                If sumCellSelected = 0 Then
                    sumCellSelected = 0
                    lblCountAutoSum.Text = ""
                End If
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
End Class