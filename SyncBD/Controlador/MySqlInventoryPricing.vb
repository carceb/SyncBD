Imports System.Data.OleDb
Public Class MySqlInventoryPricing
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlInventoryPrincing As New CMySqlInventoryPricing
    Private objectLibrary As New Library

    Dim CurPrice As String
    Dim CurCom As String
    Dim CurMargin As String
    Dim LastPrice As String
    Dim LastCom As String
    Dim LastMargin As String
    Dim NewPrice As String
    Dim NewCom As String
    Dim NewMargin As String
    Public Sub New()
    End Sub
    Public Sub EliminaSkunoInventoryPricingMySQL(skuno As String)
        claseSQL = "Delete from `Inventory Pricing` where skuno = " & skuno
        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
    End Sub

    Public Sub IngresarNuevoInventoryPricing(ByVal readerInventoryPrincingAccess As OleDbDataReader)

        Try
            If readerInventoryPrincingAccess.HasRows Then
                Do While readerInventoryPrincingAccess.Read
                    'Se debe eliminar mediante la funcion REPLACE el separador de miles en coma por punto para hacerlo mas universal
                    CurPrice = readerInventoryPrincingAccess.Item("CurPrice").ToString.Replace(",", ".")
                    CurCom = readerInventoryPrincingAccess.Item("CurCom").ToString.Replace(",", ".")
                    CurMargin = readerInventoryPrincingAccess.Item("CurMargin").ToString.Replace(",", ".")
                    LastPrice = readerInventoryPrincingAccess.Item("LastPrice").ToString.Replace(",", ".")
                    LastCom = readerInventoryPrincingAccess.Item("LastCom").ToString.Replace(",", ".")
                    LastMargin = readerInventoryPrincingAccess.Item("LastMargin").ToString.Replace(",", ".")
                    NewPrice = readerInventoryPrincingAccess.Item("NewPrice").ToString.Replace(",", ".")
                    NewCom = readerInventoryPrincingAccess.Item("NewPrice").ToString.Replace(",", ".")
                    NewMargin = readerInventoryPrincingAccess.Item("NewMargin").ToString.Replace(",", ".")
                    '*************************************************************************************


                    claseSQL = "INSERT INTO `inventory pricing` " & objetoCMySqlInventoryPrincing.InventoryPricing() & "VALUES " & "(" & readerInventoryPrincingAccess.Item("SkuNo") & "," & readerInventoryPrincingAccess.Item("PriceColumn") & "," & readerInventoryPrincingAccess.Item("PriceQty") & "," &
                                    CurPrice & "," & CurCom & "," & CurMargin & "," &
                                    LastPrice & "," & LastCom & "," & LastMargin & "," &
                                    NewPrice & "," & NewCom & "," & NewMargin & ")"
                    objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                Loop
            End If
            readerInventoryPrincingAccess.Close()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
            readerInventoryPrincingAccess.Close()
        End Try
    End Sub
End Class
