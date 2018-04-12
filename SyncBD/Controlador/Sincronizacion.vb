
Public Class Sincronizacion 'Controla todos los objetos encargados de la sincronizacion en la base de datos
    Public Sub IniciarProcesoSincronizacion()
        Dim objetoInventory As New Inventory
        Dim objetoInventoryPricing As New InventoryPricing
        Dim objetoInventoryItemXRef As New InventoryItemXRef
        Dim objetoOrders As New Orders
        Dim objetoOrdersDetail As New OrdersDetail
        Dim objetoInventoryDTS As New InventoryDTS
        Dim objetoCustomersBill As New CustomersBill
        Dim objetoCustomersBillPrsn As New CustomersBillPrsn
        Dim objetoCodesCatSub As New CodesCatSub
        Dim objetoCustomersBillProCol As New CustomersBillPrCol
        Dim objectLibrary As New Library

        objetoInventory.SincronizarInventory()
        objetoInventoryPricing.SincronizarInventoryPricing()
        objetoInventoryItemXRef.SincronizarInventoryItemXRef()
        objetoOrders.SincronizarOrders()
        objetoOrdersDetail.SincronizarOrdersDatail()

        '*******************************************************
        'Se debe revisar como hacer este proceso
        'objetoInventoryDTS.SincronizarInventoryDTS()
        '*******************************************************

        objetoCustomersBill.SincronizarCustomersBill()
        objetoCustomersBillPrsn.SincronizarCustomersBillPrsn()
        objetoCodesCatSub.SincronizarCodesCatSub()
        objetoCustomersBillProCol.SincronizarCustomersBillPrCol()
    End Sub
End Class

