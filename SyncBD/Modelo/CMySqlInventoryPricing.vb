Public Class CMySqlInventoryPricing
    Public Sub New()
    End Sub
    Public Function InventoryPricing() As String
        InventoryPricing = "(`SkuNo`,`PriceColumn`,`PriceQty`,`CurPrice`,`CurCom`,`CurMargin`,`LastPrice`,`LastCom`,`LastMargin`, `NewPrice`,`NewCom`,`NewMargin`)"
    End Function
End Class
