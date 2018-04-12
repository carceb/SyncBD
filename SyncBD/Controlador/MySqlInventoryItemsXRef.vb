Imports System.Data.OleDb
Public Class MySqlInventoryItemsXRef
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlInventoryItemXRef As New CMySqlInventoryItemXRef
    Private objectLibrary As New Library

    Public Sub New()
    End Sub
    Public Sub EliminaSkunoInventoryItemsXRefMySQL(skuno As String)
        claseSQL = "Delete from `inventory items xref` where skuno = " & skuno
        objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
    End Sub
    Public Sub IngresarNuevoInventoryItemXRef(ByVal readerInventoryItemsXRefAccess As OleDbDataReader)
        Dim ItemSku As String
        Try
            If readerInventoryItemsXRefAccess.HasRows Then
                Do While readerInventoryItemsXRefAccess.Read
                    ItemSku = IsNuloNum(readerInventoryItemsXRefAccess.Item("ItemSku"), "0").Replace(",", ".")
                    claseSQL = "INSERT INTO `inventory items xref` " & objetoCMySqlInventoryItemXRef.InventoryItemsXRef() & "VALUES " & "(" & readerInventoryItemsXRefAccess.Item("ItemID") & "," & readerInventoryItemsXRefAccess.Item("SkuNo") & "," & ItemSku & ",'" & readerInventoryItemsXRefAccess.Item("MfgCode") & "','" &
                        readerInventoryItemsXRefAccess.Item("PartNo") & "','" & readerInventoryItemsXRefAccess.Item("Desc") & "','" & readerInventoryItemsXRefAccess.Item("Notes") & "'," & readerInventoryItemsXRefAccess.Item("Flag") & ")"

                    objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                Loop
            End If
            readerInventoryItemsXRefAccess.Close()
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
            readerInventoryItemsXRefAccess.Close()
        End Try
    End Sub
End Class
