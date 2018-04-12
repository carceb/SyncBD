Public Class CMySqlOrdersDetail
    Public Sub New()
    End Sub
    Public Function OrdersDetail() As String
        OrdersDetail = "(`LineID`,`OrdID`,`OrgID`,`SkuNo`,`MfgCode`,`PartNo`,`UPC`,`Desc`,`Unit`,`CatCode`,`PrdCode`,`BinLoc`,`CustPartNo`," &
                                "`CustDesc`,`AutoYear`,`AutoMake`,`AutoModel`,`TechID`,`VndrID`,`GLID`,`GLType`,`GLCode`,`GLAcctInv`,`GLAcctCost`,`GLAcctSales`,`Taxable`,`TaxCode`,`TranCode`," &
                                "`PriceSheet`,`PriceColumn`,`InvCode`,`Build`,`Stock`,`Ord`,`Shp`,`BkOrd`,`Rtn`,`RtnShp`,`RtnBal`,`RtnOrdID`,`RtnOrgID`,`RtnOrdNo`,`RtnInvNo`,`UnitCom`,`UnitCost`," &
                                "`UnitPrice`,`UnitMargin`,`Cost`,`Total`,`TmpLineID`,`UnitList`) "
    End Function
End Class
