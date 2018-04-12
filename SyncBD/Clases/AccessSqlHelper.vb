Imports System.Data.OleDb

Public Class AccessSqlHelper 'Conexion de acceso a datos para OLEDB Access 2003
    Private objetoXML As New ManejoXML
    Public cnnOLEDB As New OleDbConnection
    Private cmdOLEDB As New OleDbCommand
    Private connectionString = objetoXML.ObtenerValorXML("RutaBDAccess2003", "Configuracion.xml")
    Private objectLibrary As New Library

    Public Function OLDBReader(sqlReader As String) As OleDbDataReader
        Try
            cnnOLEDB.ConnectionString = connectionString
            cnnOLEDB.Open()
            cmdOLEDB.Connection = cnnOLEDB
            cmdOLEDB.CommandText = sqlReader
            OLDBReader = cmdOLEDB.ExecuteReader
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
            OLDBReader = Nothing
            OLDBReader.Close()
        End Try
    End Function
    Public Sub OLDBExecuteNonQuery(sqlNonQuery As String)
        Try
            cnnOLEDB.ConnectionString = connectionString
            cnnOLEDB.Open()
            cmdOLEDB.CommandText = sqlNonQuery
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
