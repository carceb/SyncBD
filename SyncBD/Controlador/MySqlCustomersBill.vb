Imports System.Data.OleDb
Public Class MySqlCustomersBill
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlCustomersBill As New CMySqlCustomersBill
    Private objectLibrary As New Library
    Public Sub IngresarCustomersBill(ByVal readerDatos As OleDbDataReader)
        Try
            If readerDatos.HasRows Then
                claseSQL = "INSERT INTO `Customers Bill` " & objetoCMySqlCustomersBill.CustomersBill() & " values(" & readerDatos.Item("CustID") & "," & readerDatos.Item("custno") & ",'" & readerDatos.Item("BillName") & "')"
                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub

    Public Sub ActualizarCustomersBill(ByVal readerDatos As OleDbDataReader)
        Dim BillOpen, LastUpdate As String
        Dim DateAux2 As Date
        Try
            If readerDatos.HasRows Then
                DateAux2 = readerDatos.Item("BillOpen")
                BillOpen = DateAux2.ToString("yyyyMMddhhmmdd")

                DateAux2 = readerDatos.Item("LastUpDate")
                LastUpdate = DateAux2.ToString("yyyyMMddhhmmdd")

                claseSQL = "update `Customers Bill` set " &
                    " CustNO = " & readerDatos.Item("CustNO") & "" &
                    ", BillName = '" & readerDatos.Item("BillName").ToString().Replace("'", "") & "'" &
                    ", BillAddr = '" & readerDatos.Item("BillAddr") & "'" &
                     ", BillCity = '" & readerDatos.Item("BillCity") & "'" &
                    ", BillState = '" & readerDatos.Item("BillState") & "'" &
                    ", BillZip = '" & readerDatos.Item("BillZip") & "'" &
                     ", BillOpen = '" & BillOpen & "'" &
                    ", BillSlsmID = " & readerDatos.Item("BillSlsmID") & "" &
                    ", BillTaxLoc = " & readerDatos.Item("BillTaxLoc") & "" &
                     ", BillShipCode = " & readerDatos.Item("BillShipCode") & "" &
                    ", VendorNo = '" & readerDatos.Item("VendorNo") & "'" &
                    ", ResaleNo = '" & readerDatos.Item("ResaleNo") & "'" &
                    ", TaxCode = " & readerDatos.Item("TaxCode") & "" &
                    ", TermsCode = " & readerDatos.Item("TermsCode") & "" &
                     ", CrLimit = " & IsNulo(readerDatos.Item("CrLimit"), "0").ToString().Replace(",", ".") & "" &
                    ", CrHold = " & readerDatos.Item("CrHold") & "" &
                    ", CrMsg = '" & readerDatos.Item("CrMsg") & "'" &
                     ", PO = " & readerDatos.Item("PO") & "" &
                    ", BO = " & readerDatos.Item("BO") & "" &
                    ", Sig = " & readerDatos.Item("Sig") & "" &
                     ", OpenAcct = " & readerDatos.Item("OpenAcct") & "" &
                    ", MailList = '" & readerDatos.Item("MailList") & "'" &
                    ", MachineID = '" & readerDatos.Item("MachineID") & "'" &
                       ", LastUpDate = '" & LastUpdate & "'" &
                    ", NewRecFlag = " & readerDatos.Item("NewRecFlag") & "" &
                    ", UpLoad = " & readerDatos.Item("UpLoad") & "" &
                     ", DealerFlag = " & readerDatos.Item("DealerFlag") & "" &
                    ", WebAddr = '" & readerDatos.Item("WebAddr") & "'" &
                    ", LocID = " & readerDatos.Item("LocID") & "" &
                " where CustID = " & readerDatos.Item("CustID")


                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
