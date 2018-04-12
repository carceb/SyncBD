Public Class CMySqlInventoryItemXRef
    Public Sub New()
    End Sub
    Public Function InventoryItemsXRef() As String
        InventoryItemsXRef = "(`ItemID`,`SkuNo`,`ItemSku`,`MfgCode`,`PartNo`,`Desc`,`Notes`,`Flag`)"
    End Function
End Class
