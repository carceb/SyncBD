Imports System.Data.OleDb
Public Class MySqlOrders
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlOrders As New CMySqlOrders
    Private objectLibrary As New Library
    Private ShipName As String
    Public Sub IngresarOrders(ByVal readerDatos As OleDbDataReader)

        Try
            If readerDatos.HasRows Then

                claseSQL = "INSERT INTO `orders` " & objetoCMySqlOrders.Orders() & " VALUES(" & readerDatos.Item("OrdID") & "," & readerDatos.Item("OrdNo") & "," &
                IsNuloNum(readerDatos.Item("InvNo"), "Null") & "," & IsNulo(readerDatos.Item("QuoteID"), "Null") & "," & IsNulo(readerDatos.Item("BkOrdID"), "Null") & "," & readerDatos.Item("CustID") & "," & IsNulo(readerDatos.Item("ShipID"), "Null") & "," & IsNulo(ShipName, "Null") & "," &
                IsNulo(readerDatos.Item("ShipAddr"), "Null") & "," & IsNulo(readerDatos.Item("ShipCity"), "Null") & "," & IsNulo(readerDatos.Item("ShipState"), "Null") & ",'" & readerDatos.Item("ShipZip") & "'," & IsNulo(readerDatos.Item("ContName"), "Null") & "," & IsNulo(readerDatos.Item("ContHomePh"), "Null") & "," &
                IsNulo(readerDatos.Item("ContWorkPh"), "Null") & "," & IsNulo(readerDatos.Item("ContFax"), "Null") & "," & IsNulo(readerDatos.Item("ContEmail"), "Null") & "," & IsNulo(readerDatos.Item("AutoID"), "Null") & "," & IsNulo(readerDatos.Item("AutoLic"), "Null") & "," & IsNuloNum(readerDatos.Item("AutoOdm"), "Null") & "," & IsNulo(readerDatos.Item("AutoVin"), "Null") & "," &
                IsNulo(readerDatos.Item("AutoDate"), "Null") & "," & IsNuloNum(readerDatos.Item("AutoYear"), "Null") & "," & IsNulo(readerDatos.Item("AutoMake"), "Null") & "," & IsNulo(readerDatos.Item("AutoModel"), "Null") & "," & readerDatos.Item("RepID") & "," & IsNuloNum(readerDatos.Item("Cashier"), "Null") & "," & IsNulo(readerDatos.Item("PoNo"), "Null") & "," &
                IsNulo(readerDatos.Item("RelNo"), "Null") & "," & IsNulo(readerDatos.Item("DepNo"), "Null") & "," & readerDatos.Item("TotCrtns") & "," & readerDatos.Item("TotWt") & "," & IsNulo(readerDatos.Item("BLNo"), "Null") & "," & IsNulo(readerDatos.Item("VendorNo"), "Null") & "," & IsNulo(readerDatos.Item("ResaleNo"), "Null") & "," &
                IsNuloDate(readerDatos.Item("OrdDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("InvDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("PrmDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("DueDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("DiscDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("DateSysEnt"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("DateSysCmp"), "Null", "mysql") & "," &
                IsNulo(readerDatos.Item("AuthSignature"), "Null") & "," & IsNulo(readerDatos.Item("OrdType"), "Null") & "," & IsNulo(readerDatos.Item("OrdCol"), "Null") & "," & IsNulo(readerDatos.Item("OrdOrg"), "Null") & "," & IsNuloDate(readerDatos.Item("JrnPrd"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("JrnDate"), "Null", "mysql") & "," & IsNuloDate(readerDatos.Item("JrnTime"), "Null", "mysql") & "," &
                readerDatos.Item("JrnCode") & "," & readerDatos.Item("TranCode") & "," & readerDatos.Item("StatusCode") & "," & readerDatos.Item("ShipCode") & "," & readerDatos.Item("TermsCode") & "," & readerDatos.Item("TaxCode") & "," & readerDatos.Item("TaxLoc") & "," &
                readerDatos.Item("TaxRate").ToString().Replace(",", ".") & "," & readerDatos.Item("DiscountRate").ToString().Replace(",", ".") & "," & readerDatos.Item("HandlingRate").ToString().Replace(",", ".") & "," & readerDatos.Item("LocID") & "," & IsNulo(readerDatos.Item("MgrCode"), "Null") & "," & readerDatos.Item("Com").ToString().Replace(",", ".") & "," & readerDatos.Item("Cost").ToString().Replace(",", ".") & "," &
                readerDatos.Item("DiscAmt").ToString().Replace(",", ".") & "," & readerDatos.Item("InvAmt").ToString().Replace(",", ".") & "," & readerDatos.Item("NonTaxAmt").ToString().Replace(",", ".") & "," & readerDatos.Item("TaxableAmt").ToString().Replace(",", ".") & "," & readerDatos.Item("Tax").ToString().Replace(",", ".") & "," & readerDatos.Item("Discount").ToString().Replace(",", ".") & "," & readerDatos.Item("Handling").ToString().Replace(",", ".") & "," &
                readerDatos.Item("Freight").ToString().Replace(",", ".") & "," & readerDatos.Item("Restocking").ToString().Replace(",", ".") & "," & readerDatos.Item("GL").ToString().Replace(",", ".") & "," & readerDatos.Item("Parts").ToString().Replace(",", ".") & "," & readerDatos.Item("Labor").ToString().Replace(",", ".") & "," & readerDatos.Item("SubLet").ToString().Replace(",", ".") & "," & IsNuloDate(readerDatos.Item("ExpDate"), "Null", "mysql") & "," &
               IsNulo(readerDatos.Item("MachineID"), "Null") & "," & IsNuloDate(readerDatos.Item("LastUpDate"), "Null", "mysql") & "," & readerDatos.Item("NewRecFlag") & "," & readerDatos.Item("PrintQue") & "," & readerDatos.Item("PrintFlag") & "," & IsNulo(readerDatos.Item("StateCode"), "Null") & "," & IsNulo(readerDatos.Item("CntryName"), "Null") & "," &
                IsNulo(readerDatos.Item("CntryProvince"), "Null") & "," & IsNulo(readerDatos.Item("ShipNotes"), "Null") & "," & readerDatos.Item("WebID") & "," & readerDatos.Item("WebBatchID") & ")"

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)

            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Sub ActualizaOrders(ByVal readerDatos As OleDbDataReader)
        Try
            ShipName = readerDatos.Item("ShipName")
            ShipName = ShipName.Replace("'", "")

            claseSQL = " UPDATE orders SET" &
            " OrdNo = " & readerDatos.Item("OrdNo") & "," &
            " InvNo = " & IsNuloNum(readerDatos.Item("InvNo"), "Null") & "," &
            " QuoteID = " & IsNulo(readerDatos.Item("QuoteID"), "Null") & "," &
            " BkOrdID = " & IsNulo(readerDatos.Item("BkOrdID"), "Null") & "," &
            " CustID = " & readerDatos.Item("CustID") & "," &
            " ShipID = " & IsNulo(readerDatos.Item("ShipID"), "Null") & "," &
            " ShipName = " & IsNulo(ShipName, "Null") & "," &
            " ShipAddr = " & IsNulo(readerDatos.Item("ShipAddr"), "Null") & "," &
            " ShipCity = " & IsNulo(readerDatos.Item("ShipCity"), "Null") & "," &
            " ShipState = " & IsNulo(readerDatos.Item("ShipState"), "Null") & "," &
            " ShipZip = " & IsNulo(readerDatos.Item("ShipZip"), "Null") & "," &
            " ContName = " & IsNulo(readerDatos.Item("ContName"), "Null") & "," &
            " ContHomePh = " & IsNulo(readerDatos.Item("ContHomePh"), "Null") & "," &
            " ContWorkPh = " & IsNulo(readerDatos.Item("ContWorkPh"), "Null") & "," &
            " ContFax = " & IsNulo(readerDatos.Item("ContFax"), "Null") & "," &
            " ContEmail = " & IsNulo(readerDatos.Item("ContEmail"), "Null") & "," &
            " AutoID = " & IsNulo(readerDatos.Item("AutoID"), "Null") & "," &
            " AutoLic = " & IsNulo(readerDatos.Item("AutoLic"), "Null") & "," &
            " AutoOdm = " & IsNuloNum(readerDatos.Item("AutoOdm"), "Null") & "," &
            " AutoVin = " & IsNulo(readerDatos.Item("AutoVin"), "Null") & "," &
            " AutoDate = " & IsNuloDate(readerDatos.Item("AutoDate"), "Null", "mysql") & "," &
            " AutoYear = " & IsNuloNum(readerDatos.Item("AutoYear"), "Null") & "," &
            " AutoMake = " & IsNulo(readerDatos.Item("AutoMake"), "Null") & "," &
            " AutoModel = " & IsNulo(readerDatos.Item("AutoModel"), "Null") & "," &
            " RepID = " & readerDatos.Item("RepID") & "," &
            " Cashier = " & IsNuloNum(readerDatos.Item("Cashier"), "Null") & "," &
            " PoNo = " & IsNulo(readerDatos.Item("PoNo"), "Null") & "," &
            " RelNo = " & IsNulo(readerDatos.Item("RelNo"), "Null") & "," &
            " DepNo = " & IsNulo(readerDatos.Item("DepNo"), "Null") & "," &
            " TotCrtns = " & IsNuloNum(readerDatos.Item("TotCrtns"), "Null") & "," &
            " TotWt = " & IsNuloNum(readerDatos.Item("TotWt"), "Null") & "," &
            " BLNo = " & IsNulo(readerDatos.Item("BLNo"), "Null") & "," &
            " VendorNo = " & IsNulo(readerDatos.Item("VendorNo"), "Null") & "," &
            " ResaleNo = " & IsNulo(readerDatos.Item("ResaleNo"), "Null") & "," &
            " OrdDate = " & IsNuloDate(readerDatos.Item("OrdDate"), "Null", "mysql") & "," &
            " InvDate = " & IsNuloDate(readerDatos.Item("InvDate"), "Null", "mysql") & "," &
            " PrmDate = " & IsNuloDate(readerDatos.Item("PrmDate"), "Null", "mysql") & "," &
            " DueDate = " & IsNuloDate(readerDatos.Item("DueDate"), "Null", "mysql") & "," &
            " DiscDate = " & IsNuloDate(readerDatos.Item("DiscDate"), "Null", "mysql") & "," &
            " DateSysEnt = " & IsNuloDate(readerDatos.Item("DateSysEnt"), "Null", "mysql") & "," &
            " DateSysCmp = " & IsNuloDate(readerDatos.Item("DateSysCmp"), "Null", "mysql") & "," &
            " AuthSignature = " & IsNulo(readerDatos.Item("AuthSignature"), "Null") & "," &
            " OrdType = " & IsNulo(readerDatos.Item("OrdType"), "Null") & "," &
            " OrdCol = " & IsNulo(readerDatos.Item("OrdCol"), "Null") & "," &
            " OrdOrg = " & IsNulo(readerDatos.Item("OrdOrg"), "Null") & "," &
            " JrnPrd = " & IsNuloDate(readerDatos.Item("JrnPrd"), "Null", "mysql") & "," &
            " JrnDate = " & IsNuloDate(readerDatos.Item("JrnDate"), "Null", "mysql") & "," &
            " JrnTime = " & IsNuloDate(readerDatos.Item("JrnTime"), "Null", "mysql") & "," &
            " JrnCode = " & IsNuloNum(readerDatos.Item("JrnCode"), "Null") & "," &
            " TranCode = " & IsNuloNum(readerDatos.Item("TranCode"), "Null") & "," &
            " StatusCode = " & IsNuloNum(readerDatos.Item("StatusCode"), "Null") & "," &
            " ShipCode = " & IsNuloNum(readerDatos.Item("ShipCode"), "Null") & "," &
            " TermsCode = " & IsNuloNum(readerDatos.Item("TermsCode"), "Null") & "," &
            " TaxCode = " & IsNuloNum(readerDatos.Item("TaxCode"), "Null") & "," &
            " TaxLoc = " & IsNuloNum(readerDatos.Item("TaxLoc"), "Null") & "," &
            " TaxRate = " & IsNuloNum(readerDatos.Item("TaxRate"), "Null").ToString().Replace(",", ".") & "," &
            " DiscountRate = " & IsNuloNum(readerDatos.Item("DiscountRate"), "Null").ToString().Replace(",", ".") & "," &
            " HandlingRate = " & IsNuloNum(readerDatos.Item("HandlingRate"), "Null").ToString().Replace(",", ".") & "," &
            " LocID = " & IsNuloNum(readerDatos.Item("LocID"), "Null") & "," &
            " MgrCode = " & IsNulo(readerDatos.Item("MgrCode"), "Null") & "," &
            " Com = " & IsNuloNum(readerDatos.Item("Com"), "Null").ToString().Replace(",", ".") & "," &
            " Cost = " & IsNuloNum(readerDatos.Item("Cost"), "Null").ToString().Replace(",", ".") & "," &
            " DiscAmt = " & IsNuloNum(readerDatos.Item("DiscAmt"), "Null").ToString().Replace(",", ".") & "," &
            " InvAmt = " & IsNuloNum(readerDatos.Item("InvAmt"), "Null").ToString().Replace(",", ".") & "," &
            " NonTaxAmt = " & IsNuloNum(readerDatos.Item("NonTaxAmt"), "Null").ToString().Replace(",", ".") & "," &
            " TaxableAmt = " & IsNuloNum(readerDatos.Item("TaxableAmt"), "Null").ToString().Replace(",", ".") & "," &
            " Tax = " & IsNuloNum(readerDatos.Item("Tax"), "Null").ToString().Replace(",", ".") & "," &
            " Discount = " & IsNuloNum(readerDatos.Item("Discount"), "Null").ToString().Replace(",", ".") & "," &
            " Handling = " & IsNuloNum(readerDatos.Item("Handling"), "Null").ToString().Replace(",", ".") & "," &
            " Freight = " & IsNuloNum(readerDatos.Item("Freight"), "Null").ToString().Replace(",", ".") & "," &
            " Restocking = " & IsNuloNum(readerDatos.Item("Restocking"), "Null").ToString().Replace(",", ".") & "," &
            " GL = " & IsNuloNum(readerDatos.Item("GL"), "Null").ToString().Replace(",", ".") & "," &
            " Parts = " & IsNuloNum(readerDatos.Item("Parts"), "Null").ToString().Replace(",", ".") & "," &
            " Labor = " & IsNuloNum(readerDatos.Item("Labor"), "Null").ToString().Replace(",", ".") & "," &
            " SubLet = " & IsNuloNum(readerDatos.Item("SubLet"), "Null").ToString().Replace(",", ".") & "," &
            " ExpDate = " & IsNuloDate(readerDatos.Item("ExpDate"), "Null", "mysql") & "," &
            " MachineID = '" & readerDatos.Item("MachineID") & "'," &
            " LastUpDate = " & IsNuloDate(readerDatos.Item("LastUpDate"), "Null", "mysql") & "," &
            " NewRecFlag = " & IsNuloNum(readerDatos.Item("NewRecFlag"), "Null") & "," &
            " PrintQue = " & IsNuloNum(readerDatos.Item("PrintQue"), "Null") & "," &
            " PrintFlag = " & IsNuloNum(readerDatos.Item("PrintFlag"), "Null") & "," &
            " StateCode = " & IsNulo(readerDatos.Item("StateCode"), "Null") & "," &
            " CntryName = " & IsNulo(readerDatos.Item("CntryName"), "Null") & "," &
            " CntryProvince = " & IsNulo(readerDatos.Item("CntryProvince"), "Null") & "," &
            " ShipNotes = " & IsNulo(readerDatos.Item("ShipNotes"), "Null") & "," &
            " WebID = " & IsNuloNum(readerDatos.Item("WebID"), "Null") & "," &
            " WebBatchID = " & IsNuloNum(readerDatos.Item("WebBatchID"), "Null") &
            " Where OrdID = " & readerDatos.Item("OrdId")

            objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)

        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
