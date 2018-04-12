Imports System.IO

Public Class Library
    Public Sub WriteErrorLog(ex As Exception)
        Dim sw As StreamWriter
        Try
            sw = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ServicioSincronizacion.txt", True)
            sw.WriteLine(DateTime.Now.ToString() + " | " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim())
            sw.Flush()
            sw.Close()
        Catch

        End Try
    End Sub
    Public Sub WriteErrorLog(Message As String)
        Dim sw As StreamWriter
        Try
            sw = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ServicioSincronizacion.txt", True)
            sw.WriteLine(DateTime.Now.ToString() + " | " + Message)
            sw.Flush()
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub WriteProcessLog(Message As String, fileName As String)
        Dim sw As StreamWriter
        Try
            sw = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\" & fileName, True)
            sw.WriteLine(DateTime.Now.ToString() + " | " + Message)
            sw.Flush()
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
