Public Class CMySqlInventory 'Contiene el modelo(campos) de la tabla Inventory MySQL
    Public Sub New()
    End Sub
    Public Function Inventory() As String
        Inventory = " (`SkuNo`,`MfgCode`,`PartNo`,`UPC`,`Desc`,`ProdDesc`,`ProdName`,`Unit`,`CatCode`,`PrdCode`,`MinOrd`," &
                    " `BinLoc`,`OStock`,`NMFC`,`NoAirShip`,`Oversized`,`Licensed`,`OrgTooling`,`MstrQty`,`MstrWt`,`MstrLn`,`MstrWd`,`MstrHt`," &
                    " `SubQty`,`SubWt`,`SubLn`,`SubWd`,`SubHt`,`EaWt`,`EaLn`,`EaWd`,`EaHt`,`Cores`,`OnHand`,`InPick`,`BkOrd`,`VndrID`,`MAP`,`MSRP`," &
                    " `AvgCost`,`LastCost`,`CoreChrg`,`CoreAvg`,`CoreLast`,`CostFactor`,`GLAcctInv`,`GLAcctCost`,`GLAcctSales`,`PriceSheet`,`Taxable`," &
                    " `NonTaxable`,`SpcOrd`,`StockItem`,`Discontinued`,`KitMstr`,`KitMstrDtl`,`KitMstrInv`,`UpLoad`,`HomePage`,`Flag01`,`Flag02`,`Flag03`," &
                    " `Flag04`,`Flag05`,`Flag06`,`Flag07`,`Flag08`,`Flag09`,`Flag10`,`DPID`,`LastCount`,`LastDate`,`LastInPick`,`MachineID`,`LastUpDate`," &
                    " `NewRecFlag`,`UniversalApp`,`UpLoadSCE`)"
    End Function

End Class
