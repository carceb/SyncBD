Public Class InventoryItemXRef 'Administra el proceso de sincronizacion de la tabla InventoryItemXRef en MySQL
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoMySqlHekper As New MySqlHelper

    Private objetoMySqlInventoryItemsXRef As New MySqlInventoryItemsXRef
    Private objectLibrary As New Library
    Private objetoXML As New ManejoXML
    Public Sub New()
    End Sub
    Public Sub SincronizarInventoryItemXRef()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim readerInventoryItemsXRefAccess As OleDb.OleDbDataReader
        Dim objetoInventory As New Inventory
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0
        Dim diasHaciaAtras As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = InventoryItemsXRef ")
        objectLibrary.WriteProcessLog("Sincronizando tabla = InventoryItemsXRef", "InventoryItemsXRef.txt")
        objectLibrary.WriteProcessLog("Dias hacia atras " & Convert.ToInt32(objetoXML.ObtenerValorXML("CantidadDiasRestaDiaActual", "Configuracion.xml")), "InventoryPricing.txt")

        'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
        readerDatos = objetoInventory.ObtenerLastUpdate("Inventory")
        '************************************************************
        Try
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    objetoMySqlInventoryItemsXRef.EliminaSkunoInventoryItemsXRefMySQL(readerDatos.Item("skuno"))
                    readerInventoryItemsXRefAccess = ObtenerAccessInventoryItemsXRef(readerDatos.Item("skuno"))
                    objetoMySqlInventoryItemsXRef.IngresarNuevoInventoryItemXRef(readerInventoryItemsXRefAccess)
                    totalRegistrosNuevos = totalRegistrosNuevos + 1
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("InventoryItemsXRef: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "InventoryItemsXRef.txt")
                objectLibrary.WriteErrorLog("InventoryItemsXRef: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("InventoryItemsXRef: No se encontraron registros para sincronizar", "InventoryItemsXRef.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Function ObtenerAccessInventoryItemsXRef(skuno As String) As OleDb.OleDbDataReader
        Dim otroAccessHelper As New AccessSqlHelper
        'Obtiene los registros filtrados por la cantidad de dias hacia adelante segun el parametro del campo LastUpDate 
        claseSQL = "Select * from [inventory items xref] where skuno = " & skuno
        ObtenerAccessInventoryItemsXRef = otroAccessHelper.OLDBReader(claseSQL)
    End Function
End Class
