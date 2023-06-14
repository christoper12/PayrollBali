Imports System.Data
Imports System.Net.Mime.MediaTypeNames
Imports MySql.Data.MySqlClient

Public Class classLoginPayrollBali
    Dim cmdmysql As New MySqlCommand
    Public cnnMysql As New MySqlConnection
    Private logger As New DllLogger.ClassLogger
    Public dbConn As New DllConnection.connection

    Public Function disconnectedMysql()
        Try
            ''if the connection is open then we close it
            If cnnMysql.State = ConnectionState.Open Then
                cnnMysql.Close()
                cnnMysql.Dispose()
                Return True
            Else
                'otherwise it is closed then we do nothing
                Return False
            End If
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function connectedMySQLTrackitLive()
        Try
            disconnectedMysql()
            Dim DatabaseName As String = "trackitlive"
            Dim server As String = "192.168.18.22"
            Dim userName As String = "root"
            Dim password As String = ""
            Dim port As String = "3306"

            'If Not cnnMysql Is Nothing Then cnnMysql.Dispose()

            If Not (cnnMysql.State = ConnectionState.Open) Then
                Try
                    cnnMysql.ConnectionString = "datasource=" & server & ";port=" & port & ";username=" & userName & ";password=" & password & ";Database=" & DatabaseName & "; SslMode=None; Convert Zero Datetime=True;Allow User Variables=True;Respect Binary flags=false;Connect Timeout=60"
                    cnnMysql.Open()
                    Return True
                Catch ex As Exception
                    logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
                    Return False
                End Try
            Else
                Return False
            End If

        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function getDataStaffLogin(ByRef staffid As String, ByRef pass As String) As DataTable
        Dim ds As New DataTable

        Try
            Dim da As New MySqlDataAdapter(cmdmysql)
            connectedMySQLTrackitLive()
            cmdmysql.Connection = cnnMysql
            cmdmysql.CommandType = CommandType.Text
            cmdmysql.CommandText = "SELECT dbstffid, dbstffpswd FROM ftstaff WHERE dbstffid = '" & staffid & "' AND BINARY dbstffpswd = '" & pass & "' AND dbdeactivate = '0'"
            da.SelectCommand = cmdmysql
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            logger.writeLog(Me.GetType().Name, ex.Message & vbCrLf & ex.StackTrace)
            Return Nothing
        Finally
            disconnectedMysql()
        End Try
    End Function
End Class
