Imports MySql.Data.MySqlClient
Public Class MySqlInventoryDTS
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objectLibrary As New Library
    Public Sub ActualizarInventoryDTS(readerInventoryDTS As MySqlDataReader)
        Try
            claseSQL = "update `inventory dts` set `Partno_tex` = '" & readerInventoryDTS.Item("PartNo_tex") & "'," &
                                    "`Partno_dts` = '" & readerInventoryDTS.Item("Partno_dts") & "', `Descrip` = '" & readerInventoryDTS.Item("art_des") & "'," &
                                    "`Qty` = " & readerInventoryDTS.Item("stock_act") & ", `Last Update` = " & Date.Today & "," &
                                    "`Last Price` = " & readerInventoryDTS.Item("prec_vta2") & "`BinLoc` = '" & readerInventoryDTS.Item("BinLoc") & "' where skuno = " & readerInventoryDTS.Item("skuno")

            objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
            objetoMysqlHelper.strstrconnection.Close()
            objetoMysqlHelper.cmd.Dispose()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
