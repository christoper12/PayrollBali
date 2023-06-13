Imports System.Data
Imports System.Data.OleDb
Imports System.Web
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Utilities

Public Class classPayrollBali
    Dim cmdmysql As New MySqlCommand
    'Dim cmd As New OleDbCommand
    Public dbConn As New DllConnection.connection
    Public Shared dt As New DataTable
    Private logger As New DllLogger.ClassLogger

    Public Function getDataStaffPayrollBali() As DataTable
        Dim ds As New DataTable
        'Dim dateTimeScrape As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Try
            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT * FROM staffPayrollBali WHERE status = 0 ORDER BY firstName ASC"
            da.SelectCommand = cmdmysql
            da.Fill(ds)
            Return ds

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function getDataStaffPayrollBaliChekingName(ByVal fullName As String) As DataTable
        Dim dt As New DataTable
        'Dim dateTimeScrape As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Try
            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT * FROM staffPayrollBali WHERE fullName = @fullName AND status = 0 ORDER BY firstName ASC"

            If Not fullName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@fullName", fullName)
            Else
                cmdmysql.Parameters.AddWithValue("@fullName", DBNull.Value)
            End If

            da.SelectCommand = cmdmysql
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function insertPayrollBaliStaff(ByVal fullNameAdd As String, ByVal firstNameAdd As String, ByVal lastNameAdd As String, ByVal cardIdAdd As String, ByVal empRecordIdAdd As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Dim dateTimeTiday As String = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "INSERT INTO staffPayrollBali(fullName, firstName, lastName, cardId, empRecordId) VALUES(@fullNameAdd, @firstNameAdd, @lastNameAdd, @cardIdAdd, @empRecordIdAdd)"

            If Not fullNameAdd Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@fullNameAdd", fullNameAdd)
            Else
                cmdmysql.Parameters.AddWithValue("@fullNameAdd", DBNull.Value)
            End If

            If Not firstNameAdd Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@firstNameAdd", firstNameAdd)
            Else
                cmdmysql.Parameters.AddWithValue("@firstNameAdd", DBNull.Value)
            End If

            If Not lastNameAdd Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@lastNameAdd", lastNameAdd)
            Else
                cmdmysql.Parameters.AddWithValue("@lastNameAdd", DBNull.Value)
            End If

            If Not cardIdAdd Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@cardIdAdd", cardIdAdd)
            Else
                cmdmysql.Parameters.AddWithValue("@cardIdAdd", DBNull.Value)
            End If

            If Not empRecordIdAdd Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@empRecordIdAdd", empRecordIdAdd)
            Else
                cmdmysql.Parameters.AddWithValue("@empRecordIdAdd", DBNull.Value)
            End If

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function updatePayrollBaliStaff(ByVal fullName As String, ByVal firstName As String, ByVal lastName As String, ByVal cardId As String, ByVal empRecordId As String, ByVal idStaff As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Dim dateTimeTiday As String = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "UPDATE staffPayrollBali SET fullName = @fullName, firstName = @firstName, lastName = @lastName, cardId = @cardId, empRecordId = @empRecordId WHERE id = @idStaff"

            If Not fullName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@fullName", fullName)
            Else
                cmdmysql.Parameters.AddWithValue("@fullName", DBNull.Value)
            End If

            If Not firstName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@firstName", firstName)
            Else
                cmdmysql.Parameters.AddWithValue("@firstName", DBNull.Value)
            End If

            If Not lastName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@lastName", lastName)
            Else
                cmdmysql.Parameters.AddWithValue("@lastName", DBNull.Value)
            End If

            If Not cardId Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@cardId", cardId)
            Else
                cmdmysql.Parameters.AddWithValue("@cardId", DBNull.Value)
            End If

            If Not empRecordId Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@empRecordId", empRecordId)
            Else
                cmdmysql.Parameters.AddWithValue("@empRecordId", DBNull.Value)
            End If

            cmdmysql.Parameters.AddWithValue("@idStaff", idStaff)

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function deletePayrollBaliStaff(ByVal idStaff As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Dim dateTimeTiday As String = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "UPDATE staffPayrollBali SET status = '" & 1 & "' WHERE id = @idStaff"

            cmdmysql.Parameters.AddWithValue("@idStaff", idStaff)

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function insertPayrollBaliTimeSheet(ByVal idImport As String, ByVal lastName As String, ByVal firstName As String, ByVal dateTimeSheet As String, ByVal clockOn As String, ByVal clockOff As String, ByVal breaks As String, ByVal actualHours As String, ByVal dateImportCreate As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Dim dateTimeTiday As String = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "INSERT INTO timesheetbali(idImport, lastName, firstName, dateTimeSheet, clockOn, clockOff, breaks, actualHours, created_at) VALUES(@idImport, @lastName, @firstName, @dateTimeSheet, @clockOn, @clockOff, @breaks, @actualHours, '" & dateImportCreate & "')"

            If Not idImport Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@idImport", idImport)
            Else
                cmdmysql.Parameters.AddWithValue("@idImport", DBNull.Value)
            End If

            If Not lastName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@lastName", lastName)
            Else
                cmdmysql.Parameters.AddWithValue("@lastName", DBNull.Value)
            End If

            If Not firstName Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@firstName", firstName)
            Else
                cmdmysql.Parameters.AddWithValue("@firstName", DBNull.Value)
            End If

            If Not dateTimeSheet Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@dateTimeSheet", dateTimeSheet)
            Else
                cmdmysql.Parameters.AddWithValue("@dateTimeSheet", DBNull.Value)
            End If

            If Not clockOn Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@clockOn", clockOn)
            Else
                cmdmysql.Parameters.AddWithValue("@clockOn", DBNull.Value)
            End If

            If Not clockOff Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@clockOff", clockOff)
            Else
                cmdmysql.Parameters.AddWithValue("@clockOff", DBNull.Value)
            End If

            If Not breaks Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@breaks", breaks)
            Else
                cmdmysql.Parameters.AddWithValue("@breaks", DBNull.Value)
            End If

            If Not actualHours Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@actualHours", actualHours)
            Else
                cmdmysql.Parameters.AddWithValue("@actualHours", DBNull.Value)
            End If

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function updatePayrollBaliTimeSheet(ByVal idImport As String, ByVal employeeName As String, ByVal datesFixed As String, ByVal clockOn As String, ByVal clockOff As String, ByVal breaks As String, ByVal actualHours As String, ByVal dateImportCreate As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Try
            Dim qry As String = String.Empty

            qry = "CONCAT(idImport,firstName,' ',lastName,dateTimeSheet) = '" & idImport & employeeName & datesFixed & "'"

            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "UPDATE timesheetbali SET clockOn=@clockOn, clockOff=@clockOff, breaks=@breaks, actualHours=@actualHours, update_at='" & dateImportCreate & "' WHERE " & qry
            'cmdmysql.CommandText = "DELETE timesheetbali WHERE " & qry

            If Not clockOn Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@clockOn", clockOn)
            Else
                cmdmysql.Parameters.AddWithValue("@clockOn", DBNull.Value)
            End If

            If Not clockOff Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@clockOff", clockOff)
            Else
                cmdmysql.Parameters.AddWithValue("@clockOff", DBNull.Value)
            End If

            If Not breaks Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@breaks", breaks)
            Else
                cmdmysql.Parameters.AddWithValue("@breaks", DBNull.Value)
            End If

            If Not actualHours Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@actualHours", actualHours)
            Else
                cmdmysql.Parameters.AddWithValue("@actualHours", DBNull.Value)
            End If

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function updatePayrollBaliCountDataTimeSheet(ByVal toBePaidHours As String, ByVal baliBaseHourly As String, ByVal baliOvertime As String, ByVal baliHolidayPay As String, ByVal baliSickPay As String, ByVal baliFlexiTimeEarned As String, ByVal baliFlexiTimeTaken As String, ByVal baliOvertime15x As String, ByVal id As String) As Boolean
        Dim da As New MySqlDataAdapter(cmdmysql)
        Dim dateImportCreate As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            Dim qry As String = String.Empty

            If id <> "" Then
                qry = "id = '" & id & "'"
            End If

            dbConn.connectedMySQL()
            cmdmysql.Parameters.Clear()
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "UPDATE timesheetbali SET toBePaidHours=@toBePaidHours, baliBaseHourly=@baliBaseHourly, baliOvertime=@baliOvertime, baliHolidayPay=@baliHolidayPay, baliSickPay=@baliSickPay, baliFlexiTimeEarned=@baliFlexiTimeEarned, baliFlexiTimeTaken=@baliFlexiTimeTaken, baliOvertime15x=@baliOvertime15x, update_at='" & dateImportCreate & "' WHERE " & qry

            If Not toBePaidHours Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@toBePaidHours", toBePaidHours)
            Else
                cmdmysql.Parameters.AddWithValue("@toBePaidHours", DBNull.Value)
            End If

            If Not baliBaseHourly Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliBaseHourly", baliBaseHourly)
            Else
                cmdmysql.Parameters.AddWithValue("@baliBaseHourly", DBNull.Value)
            End If

            If Not baliOvertime Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliOvertime", baliOvertime)
            Else
                cmdmysql.Parameters.AddWithValue("@baliOvertime", DBNull.Value)
            End If

            If Not baliHolidayPay Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliHolidayPay", baliHolidayPay)
            Else
                cmdmysql.Parameters.AddWithValue("@baliHolidayPay", DBNull.Value)
            End If

            If Not baliSickPay Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliSickPay", baliSickPay)
            Else
                cmdmysql.Parameters.AddWithValue("@baliSickPay", DBNull.Value)
            End If

            If Not baliFlexiTimeEarned Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliFlexiTimeEarned", baliFlexiTimeEarned)
            Else
                cmdmysql.Parameters.AddWithValue("@baliFlexiTimeEarned", DBNull.Value)
            End If

            If Not baliFlexiTimeTaken Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliFlexiTimeTaken", baliFlexiTimeTaken)
            Else
                cmdmysql.Parameters.AddWithValue("@baliFlexiTimeTaken", DBNull.Value)
            End If

            If Not baliOvertime15x Is Nothing Then
                cmdmysql.Parameters.AddWithValue("@baliOvertime15x", baliOvertime15x)
            Else
                cmdmysql.Parameters.AddWithValue("@baliOvertime15x", DBNull.Value)
            End If

            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function getDataPayrollBalibaliOvertime15x(ByVal id As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim qry As String = String.Empty

            If id <> "" Then
                qry = "id = '" & id & "'"
            End If

            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT baliOvertime15x FROM timesheetbali WHERE " & qry
            da.SelectCommand = cmdmysql
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function getDataTimeSheetPayrollBali(ByVal startDate As String, ByVal endDate As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim qry As String = String.Empty

            If startDate <> "" Then
                qry = "dateTimeSheet >= '" & startDate & "'"
            End If

            If endDate <> "" Then
                qry = qry & " AND dateTimeSheet <= '" & endDate & "'"
            End If

            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT timesheetbali.*, staffpayrollbali.cardId FROM timesheetbali LEFT JOIN staffpayrollbali ON CONCAT(staffpayrollbali.firstName,staffpayrollbali.lastName) = CONCAT(timesheetbali.firstName,timesheetbali.lastName) WHERE " & qry & " ORDER BY firstName, dateTimeSheet ASC"
            da.SelectCommand = cmdmysql
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function getDataPayrollBaliTimeSheetForUpdate(ByVal idImport As String, ByVal employeeName As String, ByVal datesFixed As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim qry As String = String.Empty

            qry = "CONCAT(idImport,firstName,' ',lastName,dateTimeSheet) = '" & idImport & employeeName & datesFixed & "'"

            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT * FROM timesheetbali WHERE " & qry
            da.SelectCommand = cmdmysql
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function

    Public Function getDataSummaryTimeSheet(ByVal startDate As String, ByVal endDate As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim qry As String = String.Empty

            If startDate <> "" Then
                qry = "dateTimeSheet >= '" & startDate & "'"
            End If

            If endDate <> "" Then
                qry = qry & " AND dateTimeSheet <= '" & endDate & "'"
            End If

            Dim da As New MySqlDataAdapter(cmdmysql)
            dbConn.connectedMySQLPayrollBali()
            cmdmysql.Connection = dbConn.cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT firstName, lastName, TRUNCATE(COALESCE(SUM(actualHours),0),2) AS 'actualHours', TRUNCATE(SUM(toBePaidHours),2) AS 'toBePaidHours', TRUNCATE(SUM(baliBaseHourly),2) AS 'baliBaseHourly', TRUNCATE(SUM(baliOvertime),2) AS 'baliOvertime', TRUNCATE(SUM(baliHolidayPay),2) AS 'baliHolidayPay', TRUNCATE(SUM(baliSickPay),2) AS 'baliSickPay', TRUNCATE(SUM(baliFlexiTimeEarned),2) AS 'baliFlexiTimeEarned', TRUNCATE(SUM(baliFlexiTimeTaken),2) AS 'baliFlexiTimeTaken', TRUNCATE(SUM(baliOvertime15x),2) AS 'baliOvertime15x' FROM timesheetbali WHERE " & qry & " GROUP BY lastName ORDER BY firstName ASC"
            da.SelectCommand = cmdmysql
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            dbConn.disconnectedMysql()
        End Try
    End Function
End Class
