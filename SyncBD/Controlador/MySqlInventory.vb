Imports System.Data.OleDb
Public Class MySqlInventory 'Controla todo lo relacionado con CRUD en la tabla Inventory MySQL
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlInventory As New CMySqlInventory
    Private objectLibrary As New Library

    Dim MAP As String
    Dim MSRP As String
    Dim AvgCost As String
    Dim LastCost As String
    Dim CoreChrg As String
    Dim CoreAvg As String
    Dim CoreLast As String
    Dim CostFactor As String

    Public Sub New()
    End Sub
    Public Sub ActualizarInventory(ByVal readerDatos As OleDbDataReader)

        'Se debe eliminar mediante la funcion REPLACE el separador de miles en coma por punto para hacerlo mas universal
        MAP = IsNuloNum(readerDatos.Item("MAP"), "NULL").Replace(",", ".")
        MSRP = IsNuloNum(readerDatos.Item("MSRP"), "NULL").Replace(",", ".")
        AvgCost = readerDatos.Item("AvgCost").ToString().Replace(",", ".")
        AvgCost = readerDatos.Item("AvgCost").ToString().Replace(",", ".")
        LastCost = readerDatos.Item("LastCost").ToString().Replace(",", ".")
        CoreChrg = readerDatos.Item("CoreChrg").ToString().Replace(",", ".")
        CoreAvg = readerDatos.Item("CoreAvg").ToString().Replace(",", ".")
        CoreLast = readerDatos.Item("CoreLast").ToString().Replace(",", ".")
        CostFactor = readerDatos.Item("CostFactor").ToString().Replace(",", ".")
        '*************************************************************************************


        claseSQL = " UPDATE inventory SET" &
                    " SkuNo  = " & readerDatos.Item("SkuNo") & "," &
                    " MfgCode  = '" & readerDatos.Item("MfgCode") & "'," &
                    " PartNo  = '" & readerDatos.Item("PartNo") & "'," &
                    " UPC  = " & IsNulo(readerDatos.Item("UPC"), "Null") & "," &
                    " `Desc`  = '" & readerDatos.Item("Desc") & "'," &
                    " ProdDesc  = '" & readerDatos.Item("ProdDesc") & "'," &
                    " ProdName  = '" & readerDatos.Item("ProdName") & "'," &
                    " Unit  = '" & readerDatos.Item("Unit") & "'," &
                    " CatCode  = " & readerDatos.Item("CatCode") & "," &
                    " PrdCode  = " & readerDatos.Item("PrdCode") & "," &
                    " MinOrd  = " & readerDatos.Item("MinOrd") & "," &
                    " BinLoc  = '" & readerDatos.Item("BinLoc") & "'," &
                    " OStock  = '" & readerDatos.Item("OStock") & "'," &
                    " NMFC  = '" & readerDatos.Item("NMFC") & "'," &
                    " NoAirShip  = " & readerDatos.Item("NoAirShip") & "," &
                    " Oversized  = " & readerDatos.Item("Oversized") & "," &
                    " Licensed  = '" & readerDatos.Item("Licensed") & "'," &
                    " OrgTooling  = '" & readerDatos.Item("OrgTooling") & "'," &
                    " MstrQty  = " & readerDatos.Item("MstrQty") & "," &
                    " MstrWt  = " & readerDatos.Item("MstrWt") & "," &
                    " MstrLn  = " & readerDatos.Item("MstrLn") & "," &
                    " MstrWd  = " & readerDatos.Item("MstrWd") & "," &
                    " MstrHt  = " & readerDatos.Item("MstrHt") & "," &
                    " SubQty  = " & readerDatos.Item("SubQty") & "," &
                    " SubWt  = " & readerDatos.Item("SubWt") & "," &
                    " SubLn  = " & readerDatos.Item("SubLn") & "," &
                    " SubWd  = " & readerDatos.Item("SubWd") & "," &
                    " SubHt  = " & readerDatos.Item("SubHt") & "," &
                    " EaWt  = " & readerDatos.Item("EaWt") & "," &
                    " EaLn  = " & readerDatos.Item("EaLn") & "," &
                    " EaWd  = " & readerDatos.Item("EaWd") & "," &
                    " EaHt  = " & readerDatos.Item("EaHt") & "," &
                    " Cores  = " & readerDatos.Item("Cores") & "," &
                    " OnHand  = " & readerDatos.Item("OnHand") & "," &
                    " InPick  = " & readerDatos.Item("InPick") & "," &
                    " BkOrd  = " & readerDatos.Item("BkOrd") & "," &
                    " VndrID  = " & IsNulo(readerDatos.Item("VndrID"), "Null") & "," &
                    " MAP  = " & MAP & "," &
                    " MSRP  = " & MSRP & "," &
                    " AvgCost  = " & AvgCost & "," &
                    " LastCost  = " & LastCost & "," &
                    " CoreChrg  = " & CoreChrg & "," &
                    " CoreAvg  = " & CoreAvg & "," &
                    " CoreLast  = " & CoreLast & "," &
                    " CostFactor  = " & CostFactor & "," &
                    " GLAcctInv  = '" & readerDatos.Item("GLAcctInv") & "'," &
                    " GLAcctCost  = '" & readerDatos.Item("GLAcctCost") & "'," &
                    " GLAcctSales  = '" & readerDatos.Item("GLAcctSales") & "'," &
                    " PriceSheet  = " & readerDatos.Item("PriceSheet") & "," &
                    " Taxable  = " & readerDatos.Item("Taxable") & "," &
                    " NonTaxable  = " & readerDatos.Item("NonTaxable") & "," &
                    " SpcOrd  = " & readerDatos.Item("SpcOrd") & "," &
                    " StockItem  = " & readerDatos.Item("StockItem") & "," &
                    " Discontinued  = " & readerDatos.Item("Discontinued") & "," &
                    " KitMstr  = " & readerDatos.Item("KitMstr") & "," &
                    " KitMstrDtl  = " & readerDatos.Item("KitMstrDtl") & "," &
                    " KitMstrInv  = " & readerDatos.Item("KitMstrInv") & "," &
                    " UpLoad  = " & readerDatos.Item("UpLoad") & "," &
                    " HomePage  = " & readerDatos.Item("HomePage") & "," &
                    " Flag01  = " & readerDatos.Item("Flag01") & "," &
                    " Flag02  = " & readerDatos.Item("Flag02") & "," &
                    " Flag03  = " & readerDatos.Item("Flag03") & "," &
                    " Flag04  = " & readerDatos.Item("Flag04") & "," &
                    " Flag05  = " & readerDatos.Item("Flag05") & "," &
                    " Flag06  = " & readerDatos.Item("Flag06") & "," &
                    " Flag07  = " & readerDatos.Item("Flag07") & "," &
                    " Flag08  = " & readerDatos.Item("Flag08") & "," &
                    " Flag09  = " & readerDatos.Item("Flag09") & "," &
                    " Flag10  = " & readerDatos.Item("Flag10") & "," &
                    " DPID  = '" & readerDatos.Item("DPID") & "'," &
                    " LastCount  = " & readerDatos.Item("LastCount") & "," &
                    " LastDate  = " & IsNuloDate(readerDatos.Item("LastDate"), "Null", "mysql") & "," &
                    " LastInPick  = " & readerDatos.Item("LastInPick") & "," &
                    " MachineID  = '" & readerDatos.Item("MachineID") & "'," &
                    " LastUpDate  = " & IsNuloDate(readerDatos.Item("LastUpDate"), "Null", "mysql") & "," &
                    " NewRecFlag  = " & readerDatos.Item("NewRecFlag") & "," &
                    " UniversalApp  = " & readerDatos.Item("UniversalApp") & " " &
                    "WHERE  SkuNo  = " & readerDatos.Item("skuno")
        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
    End Sub
    Public Sub IngresarNuevoInventory(ByVal readerDatos As OleDbDataReader)

        'Se debe eliminar mediante la funcion REPLACE el separador de miles en coma por punto para hacerlo mas universal
        MAP = IsNulo(readerDatos.Item("MAP"), "0.0000").Replace(",", ".")
        MSRP = IsNulo(readerDatos.Item("MSRP"), "0.0000").Replace(",", ".")
        AvgCost = readerDatos.Item("AvgCost").ToString().Replace(",", ".")
        AvgCost = readerDatos.Item("AvgCost").ToString().Replace(",", ".")
        LastCost = readerDatos.Item("LastCost").ToString().Replace(",", ".")
        CoreChrg = readerDatos.Item("CoreChrg").ToString().Replace(",", ".")
        CoreAvg = readerDatos.Item("CoreAvg").ToString().Replace(",", ".")
        CoreLast = readerDatos.Item("CoreLast").ToString().Replace(",", ".")
        CostFactor = readerDatos.Item("CostFactor").ToString().Replace(",", ".")
        '*************************************************************************************

        claseSQL = "INSERT INTO inventory " & objetoCMySqlInventory.Inventory() & "VALUES(" & readerDatos.Item("SkuNo") & ",'" & readerDatos.Item("MfgCode") & "','" & readerDatos.Item("PartNo") & "'," & IsNulo(readerDatos.Item("UPC"), "Null") & ",'" &
        readerDatos.Item("Desc") & "','" & readerDatos.Item("ProdDesc") & "','" & readerDatos.Item("ProdName") & "','" & readerDatos.Item("Unit") & "'," &
                                readerDatos.Item("CatCode") & "," & readerDatos.Item("PrdCode") & "," & readerDatos.Item("MinOrd") & ",'" & readerDatos.Item("BinLoc") & "','" &
                                readerDatos.Item("OStock") & "','" & readerDatos.Item("NMFC") & "'," & readerDatos.Item("NoAirShip") & "," & readerDatos.Item("Oversized") & ",'" &
                                readerDatos.Item("Licensed") & "','" & readerDatos.Item("OrgTooling") & "'," & readerDatos.Item("MstrQty") & "," & readerDatos.Item("MstrWt") & "," &
                                readerDatos.Item("MstrLn") & "," & readerDatos.Item("MstrWd") & "," & readerDatos.Item("MstrHt") & "," & readerDatos.Item("SubQty") & "," & readerDatos.Item("SubWt") & "," &
                                readerDatos.Item("SubLn") & "," & readerDatos.Item("SubWd") & "," & readerDatos.Item("SubHt") & "," & readerDatos.Item("EaWt") & "," & readerDatos.Item("EaLn") & "," & readerDatos.Item("EaWd") & "," &
                                readerDatos.Item("EaHt") & "," & readerDatos.Item("Cores") & "," & readerDatos.Item("OnHand") & "," & readerDatos.Item("InPick") & "," & readerDatos.Item("BkOrd") & "," & IsNulo(readerDatos.Item("VndrID"), "Null") & "," & MAP & "," &
                                MSRP & "," & AvgCost & "," & LastCost & "," & CoreChrg & "," & CoreAvg & "," & CoreLast & "," &
                                CostFactor & ",'" & readerDatos.Item("GLAcctInv") & "','" & readerDatos.Item("GLAcctCost") & "','" & readerDatos.Item("GLAcctSales") & "'," & readerDatos.Item("PriceSheet") & "," &
                                readerDatos.Item("Taxable") & "," & readerDatos.Item("NonTaxable") & "," & readerDatos.Item("SpcOrd") & "," & readerDatos.Item("StockItem") & "," & readerDatos.Item("Discontinued") & "," & readerDatos.Item("KitMstr") & "," &
                                readerDatos.Item("KitMstrDtl") & "," & readerDatos.Item("KitMstrInv") & "," & readerDatos.Item("UpLoad") & "," & readerDatos.Item("HomePage") & "," & readerDatos.Item("Flag01") & "," & readerDatos.Item("Flag02") & "," &
                                readerDatos.Item("Flag03") & "," & readerDatos.Item("Flag04") & "," & readerDatos.Item("Flag05") & "," & readerDatos.Item("Flag06") & "," & readerDatos.Item("Flag07") & "," & readerDatos.Item("Flag08") & "," & readerDatos.Item("Flag09") & "," &
                                readerDatos.Item("Flag10") & ",'" & readerDatos.Item("DPID") & "'," & readerDatos.Item("LastCount") & "," & IsNuloDate(readerDatos.Item("LastDate"), "Null", "mysql") & "," & readerDatos.Item("LastInPick") & ",'" & readerDatos.Item("MachineID") & "'," & IsNuloDate(readerDatos.Item("LastUpDate"), "Null", "mysql") & "," &
                                readerDatos.Item("NewRecFlag") & "," & readerDatos.Item("UniversalApp") & ",0)"
        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
    End Sub
End Class
