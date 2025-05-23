﻿Imports System.IO
Imports System.IO.File

Public Class ClassLoggerPayrollBali
    Public appPath As String = "\\persvr01\FastTrack\Industrial\Freelancer Projects\TrackIT\Settings"

    Function GetUserName() As String
        Try
            If TypeOf My.User.CurrentPrincipal Is
  Security.Principal.WindowsPrincipal Then
                ' The application is using Windows authentication.
                ' The name format is DOMAIN\USERNAME.
                Dim parts() As String = Split(My.User.Name, "\")
                Dim username As String = parts(1)
                Return username
            Else
                ' The application is using custom authentication.
                Return My.User.Name
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub writeLog(errState As String, errMesg As String)
        Dim logDir As String = appPath & "\errorLogPayrollBali\logs_" & GetUserName()

        Dim logFile As String = logDir & "\log_" & Now().ToString("yyyy-MM-dd") & ".log"

        Dim sw As StreamWriter
        sw = Nothing
        Try

            If Not Directory.Exists(logDir) Then
                Directory.CreateDirectory(logDir)
            End If

            sw = AppendText(logFile)


            sw.WriteLine(Now() & vbTab & errState & vbTab & errMesg)

        Catch ex As Exception
        Finally

            GC.Collect()
            GC.WaitForPendingFinalizers()

            If Not sw Is Nothing Then
                sw.Close()
            End If

            sw = Nothing

            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub
End Class
