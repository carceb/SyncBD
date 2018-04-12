Public Class CMySqlOrders
    Public Sub New()
    End Sub
    Public Function Orders() As String
        Orders = "(`OrdID`,`OrdNo`,`InvNo`,`QuoteID`,`BkOrdID`,`CustID`,`ShipID`,`ShipName`,`ShipAddr`,`ShipCity`,`ShipState`,`ShipZip`,`ContName`,`ContHomePh`,`ContWorkPh`,`ContFax`," &
                            "`ContEmail`,`AutoID`,`AutoLic`,`AutoOdm`,`AutoVin`,`AutoDate`,`AutoYear`,`AutoMake`,`AutoModel`,`RepID`,`Cashier`,`PoNo`,`RelNo`,`DepNo`,`TotCrtns`,`TotWt`,`BLNo`, " &
                            "`VendorNo`,`ResaleNo`,`OrdDate`,`InvDate`,`PrmDate`,`DueDate`,`DiscDate`,`DateSysEnt`,`DateSysCmp`,`AuthSignature`,`OrdType`,`OrdCol`,`OrdOrg`,`JrnPrd`,`JrnDate`, " &
                            "`JrnTime`,`JrnCode`,`TranCode`,`StatusCode`,`ShipCode`,`TermsCode`,`TaxCode`,`TaxLoc`,`TaxRate`,`DiscountRate`,`HandlingRate`,`LocID`,`MgrCode`,`Com`,`Cost`,`DiscAmt`, " &
                            "`InvAmt`,`NonTaxAmt`,`TaxableAmt`,`Tax`,`Discount`,`Handling`,`Freight`,`Restocking`,`GL`,`Parts`,`Labor`,`SubLet`,`ExpDate`,`MachineID`,`LastUpDate`,`NewRecFlag`, " &
                            "`PrintQue`,`PrintFlag`,`StateCode`,`CntryName`,`CntryProvince`,`ShipNotes`,`WebID`,`WebBatchID`) "
    End Function
End Class
