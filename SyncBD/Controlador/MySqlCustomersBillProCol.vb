Imports System.Data.OleDb
Public Class MySqlCustomersBillProCol
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlCustomersBill As New CMySqlCustomersBill
    Private objectLibrary As New Library
    Public Sub ActualizarCustomersBillProCol(ByVal readerDatos As OleDbDataReader)
        Try
            If readerDatos.HasRows Then
                claseSQL = "insert into `Customers BillPrCol` (CustID,PrID,PriceSheet,PriceColumn,PriceFact) " &
                "values(" & readerDatos.Item("CustID") &
                "," & readerDatos.Item("PrID") &
                "," & readerDatos.Item("PriceSheet") &
                "," & readerDatos.Item("PriceColumn") &
                "," & readerDatos.Item("PriceFact") & ")"

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub

End Class
