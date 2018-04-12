Imports MySql.Data.MySqlClient
Public Class Orders
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoOrders As New MySqlOrders
    Private objectLibrary As New Library
    Private objetoXML As New ManejoXML
    Public Sub New()
    End Sub
    Public Sub SincronizarOrders()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim objetoInventory As New Inventory
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = Orders ")
        objectLibrary.WriteProcessLog("Sincronizando tabla = Orders", "Orders.txt")
        objectLibrary.WriteProcessLog("Dias hacia atras " & Convert.ToInt32(objetoXML.ObtenerValorXML("CantidadDiasRestaDiaActual", "Configuracion.xml")), "Orders.txt")

        'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
        readerDatos = objetoInventory.ObtenerLastUpdate("Orders")
        '************************************************************
        Try
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If Not EsOrderIDExistenteMySql(readerDatos.Item("OrdID")) Then
                        objetoOrders.IngresarOrders(readerDatos)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    Else
                        objetoOrders.ActualizaOrders(readerDatos)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("Orders: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "Orders.txt")
                objectLibrary.WriteProcessLog("Orders: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "Orders.txt")
                objectLibrary.WriteErrorLog("Orders: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("Orders: No se encontraron registros para sincronizar", "Orders.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Function EsOrderIDExistenteMySql(codigoOrder As String) As Boolean
        Dim resultado As Boolean = False
        Dim otroMySqlsHelper As New MySqlHelper
        Dim reader As MySqlDataReader
        Try
            claseSQL = "SELECT * from Orders where OrdID = " & codigoOrder
            reader = otroMySqlsHelper.MySqlHelperExecuteReader(claseSQL)
            If reader.HasRows Then
                resultado = True
            Else
                resultado = False
            End If
            reader.Close()
            reader = Nothing
            otroMySqlsHelper.strcon.Close()
            otroMySqlsHelper.cmd.Dispose()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        EsOrderIDExistenteMySql = resultado
    End Function
End Class
