Imports System.Data.OleDb
Public Class MySqlOrdersDetail
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlOrdersDetail As New CMySqlOrdersDetail
    Private objectLibrary As New Library

    Public Sub New()
    End Sub
    Public Sub ProcesoOrdersDetail(ByVal readerOrdersDetailAccess As OleDbDataReader)
        Dim resultado As String
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0
        Try
            If readerOrdersDetailAccess.HasRows Then
                Do While readerOrdersDetailAccess.Read
                    If IsDBNull(readerOrdersDetailAccess.Item("SkuNo")) = False Then
                        'resultado = ItemAuxiliar("select * from `Orders Detail` where OrdID = " & readerOrdersDetailAccess.Item("OrdID") & " and SkuNo = " & readerOrdersDetailAccess.Item("SkuNo") & " and LineID = " & readerOrdersDetailAccess.Item("LineID"), "LineID")
                        resultado = ItemAuxiliar("select * from `Orders Detail` where OrdID = " & readerOrdersDetailAccess.Item("OrdID") & " and SkuNo = " & readerOrdersDetailAccess.Item("SkuNo"), "LineID")
                    Else
                        resultado = ItemAuxiliar("select * from `Orders Detail` where OrdID = " & readerOrdersDetailAccess.Item("OrdID") & " and LineID = " & readerOrdersDetailAccess.Item("LineID"), "LineID")
                    End If
                    If resultado = "0" Then
                        claseSQL = "INSERT INTO `orders detail` " & objetoCMySqlOrdersDetail.OrdersDetail() & " VALUES(" & IsNuloNum(readerOrdersDetailAccess("LineID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("OrdID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("OrgID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("SkuNo"), "Null") & "," & IsNulo(readerOrdersDetailAccess("MfgCode"), "Null") & "," &
                             IsNulo(readerOrdersDetailAccess("PartNo"), "Null") & "," & IsNulo(readerOrdersDetailAccess("UPC"), "Null") & "," & IsNulo(readerOrdersDetailAccess("Desc"), "Null") & "," & IsNulo(readerOrdersDetailAccess("Unit"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("CatCode"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("PrdCode"), "Null") & "," &
                             IsNulo(readerOrdersDetailAccess("BinLoc"), "Null") & "," & IsNulo(readerOrdersDetailAccess("CustPartNo"), "Null") & "," & IsNulo(readerOrdersDetailAccess("CustDesc"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("AutoYear"), "Null") & "," & IsNulo(readerOrdersDetailAccess("AutoMake"), "Null") & "," &
                             IsNuloNum(readerOrdersDetailAccess("AutoModel"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("TechID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("VndrID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("GLID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("GLType"), "Null") & "," & IsNulo(readerOrdersDetailAccess("GLCode"), "Null") & "," &
                             IsNulo(readerOrdersDetailAccess("GLAcctInv"), "Null") & "," & IsNulo(readerOrdersDetailAccess("GLAcctCost"), "Null") & "," & IsNulo(readerOrdersDetailAccess("GLAcctSales"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("Taxable"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("TaxCode"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("TranCode"), "Null") & "," &
                             IsNuloNum(readerOrdersDetailAccess("PriceSheet"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("PriceColumn"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("InvCode"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("Build"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("Stock"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("Ord"), "Null") & "," &
                             IsNuloNum(readerOrdersDetailAccess("Shp"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("BkOrd"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("Rtn"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("RtnShp"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("RtnBal"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("RtnOrdID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("RtnOrgID"), "Null") & "," &
                             IsNuloNum(readerOrdersDetailAccess("RtnOrdNo"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("RtnInvNo"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("UnitCom"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("UnitCost"), "Null").ToString().Replace(",", ".") & "," & IsNuloNum(readerOrdersDetailAccess("UnitPrice"), "Null").ToString().Replace(",", ".") & "," & IsNuloNum(readerOrdersDetailAccess("UnitMargin"), "Null").ToString().Replace(",", ".") & "," &
                             IsNuloNum(readerOrdersDetailAccess("Cost"), "Null").ToString().Replace(",", ".") & "," & IsNuloNum(readerOrdersDetailAccess("Total"), "Null").ToString().Replace(",", ".") & "," & IsNuloNum(readerOrdersDetailAccess("TmpLineID"), "Null") & "," & IsNuloNum(readerOrdersDetailAccess("UnitList"), "Null").ToString().Replace(",", ".") & ")"

                        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    Else
                        claseSQL = " UPDATE `orders detail` SET " &
                                "OrgID = " & IsNuloNum(readerOrdersDetailAccess.Item("OrgID"), "Null") & "," &
                                "MfgCode = " & IsNulo(readerOrdersDetailAccess.Item("MfgCode"), "Null") & "," &
                                 "PartNo = " & IsNulo(readerOrdersDetailAccess.Item("PartNo"), "Null") & "," &
                                 "UPC = " & IsNulo(readerOrdersDetailAccess.Item("UPC"), "Null") & "," &
                                 "`Desc` = " & IsNulo(readerOrdersDetailAccess.Item("Desc"), "Null") & "," &
                                 "Unit = " & IsNulo(readerOrdersDetailAccess.Item("Unit"), "Null") & "," &
                                 "CatCode = " & IsNuloNum(readerOrdersDetailAccess.Item("CatCode"), "Null") & "," &
                                 "PrdCode = " & IsNuloNum(readerOrdersDetailAccess.Item("PrdCode"), "Null") & "," &
                                 "BinLoc = " & IsNulo(readerOrdersDetailAccess.Item("BinLoc"), "Null") & "," &
                                 "CustPartNo = " & IsNulo(readerOrdersDetailAccess.Item("CustPartNo"), "Null") & "," &
                                 "CustDesc = " & IsNulo(readerOrdersDetailAccess.Item("CustDesc"), "Null") & "," &
                                 "AutoYear = " & IsNuloNum(readerOrdersDetailAccess.Item("AutoYear"), "Null") & "," &
                                 "AutoMake = " & IsNulo(readerOrdersDetailAccess.Item("AutoMake"), "Null") & "," &
                                 "AutoModel = " & IsNulo(readerOrdersDetailAccess.Item("AutoModel"), "Null") & "," &
                                 "TechID = " & IsNuloNum(readerOrdersDetailAccess.Item("TechID"), "Null") & "," &
                                 "VndrID = " & IsNuloNum(readerOrdersDetailAccess.Item("VndrID"), "Null") & "," &
                                 "GLID = " & IsNuloNum(readerOrdersDetailAccess.Item("GLID"), "Null") & "," &
                                 "GLType = " & IsNuloNum(readerOrdersDetailAccess.Item("GLType"), "Null") & "," &
                                 "GLCode = " & IsNulo(readerOrdersDetailAccess.Item("GLCode"), "Null") & "," &
                                 "GLAcctInv = " & IsNulo(readerOrdersDetailAccess.Item("GLAcctInv"), "Null") & "," &
                                 "GLAcctCost = " & IsNulo(readerOrdersDetailAccess.Item("GLAcctCost"), "Null") & "," &
                                 "GLAcctSales = " & IsNulo(readerOrdersDetailAccess.Item("GLAcctSales"), "Null") & "," &
                                 "Taxable = " & IsNuloNum(readerOrdersDetailAccess.Item("Taxable"), "Null") & "," &
                                 "TaxCode = " & IsNuloNum(readerOrdersDetailAccess.Item("TaxCode"), "Null") & "," &
                                 "TranCode = " & IsNuloNum(readerOrdersDetailAccess.Item("TranCode"), "Null") & "," &
                                 "PriceSheet = " & IsNuloNum(readerOrdersDetailAccess.Item("PriceSheet"), "Null") & "," &
                                 "PriceColumn = " & IsNuloNum(readerOrdersDetailAccess.Item("PriceColumn"), "Null") & "," &
                                 "InvCode = " & IsNuloNum(readerOrdersDetailAccess.Item("InvCode"), "Null") & "," &
                                 "Build = " & IsNuloNum(readerOrdersDetailAccess.Item("Build"), "Null") & "," &
                                 "Stock = " & IsNuloNum(readerOrdersDetailAccess.Item("Stock"), "Null") & "," &
                                 "Ord = " & IsNuloNum(readerOrdersDetailAccess.Item("Ord"), "Null") & "," &
                                 "Shp = " & IsNuloNum(readerOrdersDetailAccess.Item("Shp"), "Null") & "," &
                                 "BkOrd = " & IsNuloNum(readerOrdersDetailAccess.Item("BkOrd"), "Null") & "," &
                                 "Rtn = " & IsNuloNum(readerOrdersDetailAccess.Item("Rtn"), "Null") & "," &
                                 "RtnShp = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnShp"), "Null") & "," &
                                 "RtnBal = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnBal"), "Null") & "," &
                                 "RtnOrdID = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnOrdID"), "Null") & "," &
                                 "RtnOrgID = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnOrgID"), "Null") & "," &
                                 "RtnOrdNo = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnOrdNo"), "Null") & "," &
                                 "RtnInvNo = " & IsNuloNum(readerOrdersDetailAccess.Item("RtnInvNo"), "Null") & "," &
                                 "UnitCom = " & IsNuloNum(readerOrdersDetailAccess.Item("UnitCom"), "Null") & "," &
                                 "UnitCost = " & IsNuloNum(readerOrdersDetailAccess.Item("UnitCost"), "Null").ToString().Replace(",", ".") & "," &
                                 "UnitPrice = " & IsNuloNum(readerOrdersDetailAccess.Item("UnitPrice"), "Null").ToString().Replace(",", ".") & "," &
                                 "UnitMargin = " & IsNuloNum(readerOrdersDetailAccess.Item("UnitMargin"), "Null").ToString().Replace(",", ".") & "," &
                                 "Cost = " & IsNuloNum(readerOrdersDetailAccess.Item("Cost"), "Null").ToString().Replace(",", ".") & "," &
                                 "Total = " & IsNuloNum(readerOrdersDetailAccess.Item("Total"), "Null").ToString().Replace(",", ".") & "," &
                                 "TmpLineID = " & IsNuloNum(readerOrdersDetailAccess.Item("TmpLineID"), "Null") & "," &
                                 "UnitList = " & IsNuloNum(readerOrdersDetailAccess.Item("UnitList"), "Null").ToString().Replace(",", ".")

                        If IsDBNull(readerOrdersDetailAccess.Item("SkuNo")) = False Then
                            claseSQL = claseSQL & "  WHERE OrdID = " & readerOrdersDetailAccess.Item("OrdID") & " and SkuNo = " & readerOrdersDetailAccess.Item("SkuNo") & " and LineID = " & readerOrdersDetailAccess.Item("LineID")
                        Else
                            claseSQL = claseSQL & "  WHERE OrdID = " & readerOrdersDetailAccess.Item("OrdID") & " and LineID = " & readerOrdersDetailAccess.Item("LineID")
                        End If
                        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    End If
                Loop
            End If
            objectLibrary.WriteProcessLog("OrdersDetail: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "OrdersDetail.txt")
            objectLibrary.WriteProcessLog("OrdersDetail: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "OrdersDetail.txt")
            readerOrdersDetailAccess.Close()
            objetoMysqlHelper.strcon.Close()
            objetoMysqlHelper.cmd.Dispose()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
            readerOrdersDetailAccess.Close()
        End Try
    End Sub
    Public Function ItemAuxiliar(ByVal consulta As String, ByVal nombreCampo As String) As String
        Dim resultado As String = ""
        Dim readerAuxiliar As MySql.Data.MySqlClient.MySqlDataReader
        Try
            readerAuxiliar = objetoMysqlHelper.MySqlHelperExecuteReader(consulta)
            If readerAuxiliar.Read Then
                If IsDBNull(readerAuxiliar.Item(nombreCampo)) Then
                    resultado = 0
                Else
                    resultado = readerAuxiliar.Item(nombreCampo)
                End If
            Else
                resultado = 0
            End If
            objetoMysqlHelper.strcon.Close()
            objetoMysqlHelper.cmd.Dispose()
            readerAuxiliar.Close()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        ItemAuxiliar = resultado
    End Function
End Class
