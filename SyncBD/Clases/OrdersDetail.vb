
Public Class OrdersDetail
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoMySqlHelper As New MySqlHelper

    Private objetoMySqlOrdersDetail As New MySqlOrdersDetail
    Private objectLibrary As New Library
    Private objetoXML As New ManejoXML
    Public Sub New()
    End Sub
    Public Sub SincronizarOrdersDatail()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim readerOrdersDetailAccess As OleDb.OleDbDataReader
        Dim objetoInventory As New Inventory

        Dim diasHaciaAtras As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = Orders Detail")
        objectLibrary.WriteProcessLog("Sincronizando tabla = Orders Detail", "OrdersDetail.txt")
        objectLibrary.WriteProcessLog("Dias hacia atras " & Convert.ToInt32(objetoXML.ObtenerValorXML("CantidadDiasRestaDiaActual", "Configuracion.xml")), "OrdersDetail.txt")

        'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
        readerDatos = objetoInventory.ObtenerLastUpdate("Orders")
        '************************************************************
        Try
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    readerOrdersDetailAccess = ObtenerOrdersDatailAccess(readerDatos.Item("OrdID"))
                    objetoMySqlOrdersDetail.ProcesoOrdersDetail(readerOrdersDetailAccess)
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()

                objectLibrary.WriteErrorLog("OrdersDetail: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("OrdersDetail: No se encontraron registros para sincronizar", "OrdersDetail.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Function ObtenerOrdersDatailAccess(orderID As String) As OleDb.OleDbDataReader
        Dim otroAccessHelper As New AccessSqlHelper
        claseSQL = "SELECT * from [Orders Detail] where OrdID = " & orderID
        ObtenerOrdersDatailAccess = otroAccessHelper.OLDBReader(claseSQL)
    End Function
End Class
