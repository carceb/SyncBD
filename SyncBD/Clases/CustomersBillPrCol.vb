Imports MySql.Data.MySqlClient
Public Class CustomersBillPrCol
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoCustomersBillProCol As New MySqlCustomersBillProCol
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarCustomersBillPrCol()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = CustomersBillPrCol")
        objectLibrary.WriteProcessLog("Sincronizando tabla = CustomersBillPrCol", "CustomersBillPrCol.txt")

        Try
            'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
            readerDatos = ObtenerCustomersBillPrColAccess()
            '************************************************************
            If readerDatos.HasRows Then
                EliminarCustomersBillPrColMySql()
                Do While readerDatos.Read
                    objetoCustomersBillProCol.ActualizarCustomersBillProCol(readerDatos)
                    totalRegistrosActualizados = totalRegistrosActualizados + 1
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("CustomersBillPrCol: Registros sincronizados para actualización = " & totalRegistrosActualizados, "CustomersBillPrCol.txt")
                objectLibrary.WriteErrorLog("CustomersBillPrCol: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("CustomersBillPrCol: No se encontraron registros para sincronizar", "CustomersBillPrCol.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerCustomersBillPrColAccess() As OleDb.OleDbDataReader
        claseSQL = "Select * from [Customers BillPrCol] order by custid"
        ObtenerCustomersBillPrColAccess = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Private Sub EliminarCustomersBillPrColMySql()
        Dim objetoMysqlHelper As New MySqlHelper
        claseSQL = "Delete from `Customers BillPrCol`"
        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
    End Sub
End Class
