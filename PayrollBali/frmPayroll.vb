Imports System.Drawing.Drawing2D
Imports System.IO
Imports Microsoft.Office.Interop
Imports tesExcel = Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Asn1.X509
Imports System.Globalization
Imports Org.BouncyCastle.Utilities


Public Class frmPayroll
    Private logger As New DllLogger.ClassLogger
    Dim filename As String = String.Empty
    Dim copyOriginalFileTarget As String = String.Empty
    Dim originalFile As String = String.Empty
    Dim dt, dt2 As New DataTable
    Dim startDate As DateTime = Nothing
    Dim endDate As DateTime = Nothing
    Dim startDateFixed As String = String.Empty
    Dim endDateFixed As String = String.Empty

    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpStartDate.Value = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday))
            dtpEndDate.Value = dtpStartDate.Value.AddDays(6)

            startDate = DateTime.Parse(dtpStartDate.Text)
            endDate = DateTime.Parse(dtpEndDate.Text)

            startDateFixed = startDate.ToString("yyyy-MM-dd HH:mm:ss")
            endDateFixed = endDate.ToString("yyyy-MM-dd HH:mm:ss")


            '            DateTime Date = DateTime.ParseExact(Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            'String reformatted = Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)



            lblFileExcelImport.Text = "-"
            lblproses.Visible = False
            lblproses.Text = "-"
            filename = ""
            copyOriginalFileTarget = ""
            originalFile = ""
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub prepareDatagridTimeSheet()
        Try
            dgTimeSheet.ClearSelection()
            dgTimeSheet.Columns("id").Visible = False

            dgTimeSheet.Columns("idImport").Visible = False

            dgTimeSheet.Columns("lastName").HeaderCell.Value = "Last Name"
            dgTimeSheet.Columns("lastName").ReadOnly = True
            dgTimeSheet.Columns("lastName").Frozen = True

            dgTimeSheet.Columns("firstName").HeaderCell.Value = "First Name"
            dgTimeSheet.Columns("firstName").ReadOnly = True
            dgTimeSheet.Columns("firstName").Frozen = True

            dgTimeSheet.Columns("dateTimeSheet").HeaderCell.Value = "Date"
            dgTimeSheet.Columns("dateTimeSheet").ReadOnly = True
            dgTimeSheet.Columns("dateTimeSheet").Frozen = True

            dgTimeSheet.Columns("clockOn").HeaderCell.Value = "Clock On"
            dgTimeSheet.Columns("clockOn").ReadOnly = True
            dgTimeSheet.Columns("clockOn").Frozen = True

            dgTimeSheet.Columns("clockOff").HeaderCell.Value = "Clock Off"
            dgTimeSheet.Columns("clockOff").ReadOnly = True
            dgTimeSheet.Columns("clockOff").Frozen = True

            dgTimeSheet.Columns("breaks").HeaderCell.Value = "Breaks"
            dgTimeSheet.Columns("breaks").ReadOnly = True
            dgTimeSheet.Columns("breaks").Frozen = True

            dgTimeSheet.Columns("actualHours").HeaderCell.Value = "Actual Hours"
            dgTimeSheet.Columns("actualHours").ReadOnly = True
            dgTimeSheet.Columns("actualHours").Frozen = True

            dgTimeSheet.Columns("toBePaidHours").HeaderCell.Value = "To Be Paid Hours"

            dgTimeSheet.Columns("baliBaseHourly").HeaderCell.Value = "01 Bali Base Hourly"

            dgTimeSheet.Columns("baliOvertime").HeaderCell.Value = "01 Bali Overtime (Flat Rate)"

            dgTimeSheet.Columns("baliHolidayPay").HeaderCell.Value = "01 Bali Holiday Pay"

            dgTimeSheet.Columns("baliSickPay").HeaderCell.Value = "01 Bali Sick Pay"

            dgTimeSheet.Columns("baliFlexiTimeEarned").HeaderCell.Value = "01 Bali Flexi Time - Earned"

            dgTimeSheet.Columns("baliFlexiTimeTaken").HeaderCell.Value = "01 Bali Flext Time - Taken"

            dgTimeSheet.Columns("baliOvertime15x").HeaderCell.Value = "01 Bali Overtime (1.5x)"

            dgTimeSheet.Columns("created_at").Visible = False
            dgTimeSheet.Columns("staff_add").Visible = False
            dgTimeSheet.Columns("update_at").Visible = False
            dgTimeSheet.Columns("staff_update").Visible = False

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
            Dim a As Date
            a = dtpEndDate.Value
            dtpStartDate.Value = a.AddDays(-6)

            'Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)

            Dim seldate As DateTime = dtpEndDate.Value
            If seldate.DayOfWeek <> DayOfWeek.Sunday Then
                Dim offset As Integer = DayOfWeek.Sunday - seldate.DayOfWeek
                Dim sunday As DateTime = seldate + TimeSpan.FromDays(offset)
                'MsgBox("Can only select a Sunday!", vbCritical, "Oops!")
                dtpEndDate.Value = sunday
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        Try
            Dim a As Date
            a = dtpStartDate.Value
            dtpEndDate.Value = a.AddDays(+6)

            'Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)

            Dim seldate As DateTime = dtpStartDate.Value
            If seldate.DayOfWeek <> DayOfWeek.Monday Then
                Dim offset As Integer = DayOfWeek.Monday - seldate.DayOfWeek
                Dim monday As DateTime = seldate + TimeSpan.FromDays(offset)
                'MsgBox("Can only select a Monday!", vbCritical, "Oops!")
                dtpStartDate.Value = monday
            End If
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
                copyOriginalFileTarget = appPath & "\Payroll Bali Excell Import\" & System.IO.Path.GetFileName(originalFile)

                'File.Copy(originalFile, copyOriginalFileTarget, True)

                'filename = copyOriginalFileTarget
                filename = originalFile
                lblFileExcelImport.Text = OpenFileDialog1.FileName


                If lblFileExcelImport.Text = "-" Then
                    MsgBox("Please Import File Debtors Report First!")
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
                    dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed)

                    If dgTimeSheet.Rows.Count > 0 Then
                        dgTimeSheet.DataSource = Nothing
                    End If
                    dgTimeSheet.DataSource = dt

                    dtpStartDate.Value = startDate
                    'dtpEndDate.Value = endDate
                    prepareDatagridTimeSheet()

                    Me.Cursor = Cursors.Default
                End If

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

                                            Dim employeeNameCheck As String = firtsName & " " & lastName

                                            func.updatePayrollBaliTimeSheet(idImport, employeeNameCheck, datesFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate)
                                        End If
                                    Else
                                        dt = func.getDataStaffPayrollBaliChekingName(employeeName)

                                        If dt.Rows.Count > 0 Then
                                            firtsName = dt.Rows(0).Item("firstName").ToString()
                                            lastName = dt.Rows(0).Item("lastName").ToString()

                                            func.insertPayrollBaliTimeSheet(idImport, lastName, firtsName, datesFixed, clockOn, clockOff, breaks, actualHours, dateImportCreate)
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

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            startDate = DateTime.Parse(dtpStartDate.Text)
            endDate = DateTime.Parse(dtpEndDate.Text)

            startDateFixed = startDate.ToString("yyyy-MM-dd HH:mm:ss")
            endDateFixed = endDate.ToString("yyyy-MM-dd HH:mm:ss")

            Dim func As New DllPayrollBali.classPayrollBali
            dt = func.getDataTimeSheetPayrollBali(startDateFixed, endDateFixed)

            dgTimeSheet.DataSource = dt
            prepareDatagridTimeSheet()
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub dgTimeSheet_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgTimeSheet.CellEndEdit
        Try
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


            id = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value

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
                dt = func.getDataPayrollBalibaliOvertime15x(id)
                If dt.Rows.Count > 0 Then
                    If dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = dt.Rows(0).Item("baliOvertime15x").ToString() Then
                        baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                        baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                        dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
                    Else
                        baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                        baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                        dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
                    End If
                End If
            End If

            toBePaidHoursDec = baliBaseHourlyDec + baliOvertimeDec + baliHolidayPayDec + baliSickPayDec + baliFlexiTimeEarnedDec + baliFlexiTimeTakenDec + baliOvertime15xDec
            toBePaidHours = toBePaidHoursDec
            dgTimeSheet.Rows(e.RowIndex).Cells("toBePaidHours").Value = toBePaidHoursDec

            func.updatePayrollBaliCountDataTimeSheet(toBePaidHours, baliBaseHourly, baliOvertime, baliHolidayPay, baliSickPay, baliFlexiTimeEarned, baliFlexiTimeTaken, baliOvertime15x, id)

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub CopyCells()
        Clipboard.SetDataObject(dgTimeSheet.GetClipboardContent)
    End Sub

    Private Sub PasteCells()
        Dim s = Clipboard.GetText
        Dim ci = dgTimeSheet.CurrentCell.ColumnIndex
        Dim ri = dgTimeSheet.CurrentCell.RowIndex
        Dim colCount = dgTimeSheet.Columns.Count
        Dim rowCount = dgTimeSheet.Rows.Count

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
    End Sub

    Private Sub dgTimeSheet_KeyDown(sender As Object, e As KeyEventArgs) Handles dgTimeSheet.KeyDown
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
    End Sub

    Private Sub dgTimeSheet_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgTimeSheet.CellLeave
        Try
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


            id = dgTimeSheet.Rows(e.RowIndex).Cells("id").Value

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
                dt = func.getDataPayrollBalibaliOvertime15x(id)
                If dt.Rows.Count > 0 Then
                    If dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = dt.Rows(0).Item("baliOvertime15x").ToString() Then
                        baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                        baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value
                        dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
                    Else
                        baliOvertime15x = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                        baliOvertime15xDec = dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value * 1.5
                        dgTimeSheet.Rows(e.RowIndex).Cells("baliOvertime15x").Value = baliOvertime15x
                    End If
                End If
            End If

            toBePaidHoursDec = baliBaseHourlyDec + baliOvertimeDec + baliHolidayPayDec + baliSickPayDec + baliFlexiTimeEarnedDec + baliFlexiTimeTakenDec + baliOvertime15xDec
            toBePaidHours = toBePaidHoursDec
            dgTimeSheet.Rows(e.RowIndex).Cells("toBePaidHours").Value = toBePaidHoursDec

            func.updatePayrollBaliCountDataTimeSheet(toBePaidHours, baliBaseHourly, baliOvertime, baliHolidayPay, baliSickPay, baliFlexiTimeEarned, baliFlexiTimeTaken, baliOvertime15x, id)

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
End Class
