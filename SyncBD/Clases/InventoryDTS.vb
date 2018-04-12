Imports MySql.Data.MySqlClient
Public Class InventoryDTS
    Private claseSQL As String
    Private objetoMySqlsHelper As New MySqlHelper
    Private objetoInventoryDTS As New MySqlInventoryDTS
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarInventoryDTS()
        Dim readerInventoryDTS As MySqlDataReader
        Dim totalRegistrosActualizados As Integer = 0
        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = InventoryDTS ")
        objectLibrary.WriteProcessLog("Sincronizando tabla = InventoryDTS", "InventoryDTS.txt")
        Try
            readerInventoryDTS = ObtenerInventoryDTS()
            If readerInventoryDTS.HasRows Then
                Do While readerInventoryDTS.Read
                    objetoInventoryDTS.ActualizarInventoryDTS(readerInventoryDTS)
                    totalRegistrosActualizados = totalRegistrosActualizados + 1
                Loop
            Else
                objectLibrary.WriteProcessLog("Orders: No se encontraron registros para sincronizar", "Orders.txt")
            End If

            readerInventoryDTS.Close()
            objetoMySqlsHelper.strcon.Close()
            objetoMySqlsHelper.cmd.Dispose()

            objectLibrary.WriteProcessLog("InventoryDTS: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "InventoryDTS.txt")
            objectLibrary.WriteErrorLog("InventoryDTS: Finalizó correctamente evento de sincronización")
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerInventoryDTS() As MySqlDataReader
        claseSQL = "SELECT * FROM `inventory dts`"
        ObtenerInventoryDTS = objetoMySqlsHelper.MySqlHelperExecuteReader(claseSQL)
    End Function
End Class
