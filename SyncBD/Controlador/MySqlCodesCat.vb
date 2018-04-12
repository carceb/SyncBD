Imports System.Data.OleDb
Public Class MySqlCodesCat
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlCustomersBill As New CMySqlCustomersBill
    Private objectLibrary As New Library
    Public Sub IngresarCodesCat(ByVal readerDatos As OleDbDataReader)
        Try
            If readerDatos.HasRows Then
                'TO DO

                'claseSQL = "INSERT INTO `Customers Bill` " & objetoCMySqlCustomersBill.CustomersBill() & " values(" & readerDatos.Item("CustID") & "," & readerDatos.Item("custno") & ",'" & readerDatos.Item("BillName") & "')"
                'objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                'objetoMysqlHelper.strcon.Close()
                'objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Sub ActualizarCodesCat(ByVal readerDatos As OleDbDataReader)
        Dim BillOpen, LastUpdate As String
        Dim DateAux2 As Date
        Dim CatCodeAux, IDMstrCatAux, CatFlagAux As Integer
        Dim CatFilterAux, CatShortDescAux, CatLongDescAux, CatContentAux, MetaTitleAux, MetaDescAux, MetaKeywordsAux As String
        Try
            If readerDatos.HasRows Then
                DateAux2 = readerDatos.Item("BillOpen")
                BillOpen = DateAux2.ToString("yyyyMMddhhmmdd")

                DateAux2 = readerDatos.Item("LastUpDate")
                LastUpdate = DateAux2.ToString("yyyyMMddhhmmdd")

                If IsDBNull(readerDatos.Item("CatCode")) Then
                    CatCodeAux = "Null"
                Else
                    CatCodeAux = readerDatos.Item("CatCode")
                End If

                If IsDBNull(readerDatos.Item("IDMstrCat")) Then
                    IDMstrCatAux = Nothing
                Else
                    IDMstrCatAux = readerDatos.Item("IDMstrCat")
                End If


                If readerDatos.Item("CatFlag") = True Then
                    CatFlagAux = 1
                Else
                    CatFlagAux = 0
                End If


                If IsDBNull(readerDatos.Item("CatFilter")) Then
                    CatFilterAux = "Null"
                Else
                    CatFilterAux = "'" & readerDatos.Item("CatFilter") & "'"
                End If

                If IsDBNull(readerDatos.Item("CatShortDesc")) Then
                    CatShortDescAux = "Null"
                Else
                    CatShortDescAux = "'" & readerDatos.Item("CatShortDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("CatLongDesc")) Then
                    CatLongDescAux = "Null"
                Else
                    CatLongDescAux = "'" & readerDatos.Item("CatLongDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("CatContent")) Then
                    CatContentAux = "Null"
                Else
                    CatContentAux = "'" & readerDatos.Item("CatContent") & "'"
                End If

                If IsDBNull(readerDatos.Item("MetaTitle")) Then
                    MetaTitleAux = "Null"
                Else
                    MetaTitleAux = "'" & readerDatos.Item("MetaTitle") & "'"
                End If

                If IsDBNull(readerDatos.Item("MetaDesc")) Then
                    MetaDescAux = "Null"
                Else
                    MetaDescAux = "'" & readerDatos.Item("MetaDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("MetaKeywords")) Then
                    MetaKeywordsAux = "Null"
                Else
                    MetaKeywordsAux = "'" & readerDatos.Item("MetaKeywords") & "'"
                    MetaKeywordsAux = Replace(MetaKeywordsAux, "'", " ", 1, -1, vbTextCompare)
                    MetaKeywordsAux = "'" & MetaKeywordsAux & "'"
                End If

                claseSQL = "insert into `Codes Cat`(CatCode,IDMstrCat,CatDesc,CatFlag,CatFilter,CatShortDesc," _
                    & " CatLongDesc,CatContent,MetaTitle,MetaDesc,MetaKeywords)values(" & CatCodeAux & "," & IDMstrCatAux & "," _

                ' & CatDescAux & "," & CatFlagAux & "," & CatFilterAux & "," & CatShortDescAux & "," & CatLongDescAux & "," _
                '& CatContentAux & "," & MetaTitleAux & "," & MetaDescAux & "," & MetaKeywordsAux & ")"


                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
