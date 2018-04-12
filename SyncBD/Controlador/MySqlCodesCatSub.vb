Imports System.Data.OleDb
Public Class MySqlCodesCatSub
    Private claseSQL As String
    Private objetoMysqlHelper As New MySqlHelper
    Private objetoCMySqlCustomersBill As New CMySqlCustomersBill
    Private objectLibrary As New Library
    Public Sub IngresarCodesCatSub(ByVal readerDatos As OleDbDataReader)
        Dim PrdCodeAux, CatCodeAux, IDMstrCatAux, IDMstrPrdAux, PrdFlagAux As Integer
        Dim PrdDescAux, PrdFilterAux, PrdShortDescAux, PrdLongDescAux, PrdContentAux, MetaTitleAux, MetaDescAux, MetaKeywordsAux As String

        Try
            If readerDatos.HasRows Then

                If IsDBNull(readerDatos.Item("PrdCode")) Then
                    PrdCodeAux = Nothing
                Else
                    PrdCodeAux = readerDatos.Item("PrdCode")
                End If

                If PrdCodeAux = 0 Then
                    Exit Sub
                End If

                If IsDBNull(readerDatos.Item("CatCode")) Then
                    CatCodeAux = Nothing
                Else
                    CatCodeAux = readerDatos.Item("CatCode")
                End If

                If IsDBNull(readerDatos.Item("IDMstrCat")) Then
                    IDMstrCatAux = Nothing
                Else
                    IDMstrCatAux = readerDatos.Item("IDMstrCat")
                End If

                If IsDBNull(readerDatos.Item("IDMstrPrd")) Then
                    IDMstrPrdAux = Nothing
                Else
                    IDMstrPrdAux = readerDatos.Item("IDMstrPrd")
                End If

                If IsDBNull(readerDatos.Item("PrdDesc")) Then
                    PrdDescAux = "Null"
                Else
                    PrdDescAux = "'" & readerDatos.Item("PrdDesc") & "'"
                End If

                If readerDatos.Item("PrdFlag") = True Then
                    PrdFlagAux = 1
                Else
                    PrdFlagAux = 0
                End If

                If IsDBNull(readerDatos.Item("PrdFilter")) Then
                    PrdFilterAux = "Null"
                Else
                    PrdFilterAux = "'" & readerDatos.Item("PrdFilter") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdShortDesc")) Then
                    PrdShortDescAux = "Null"
                Else
                    PrdShortDescAux = "'" & readerDatos.Item("PrdShortDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdLongDesc")) Then
                    PrdLongDescAux = "Null"
                Else
                    PrdLongDescAux = "'" & readerDatos.Item("PrdLongDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdContent")) Then
                    PrdContentAux = "Null"
                Else
                    PrdContentAux = "'" & readerDatos.Item("PrdContent") & "'"
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
                End If

                claseSQL = "insert into `Codes Catsub` (PrdCode,CatCode ,IDMstrCat ,IDMstrPrd ,PrdDesc,PrdFlag,PrdFilter,PrdShortDesc,PrdLongDesc,PrdContent,MetaTitle,MetaDesc,MetaKeywords)" _
                    & "values(" & PrdCodeAux & "," & CatCodeAux & "," & IDMstrCatAux & "," & IDMstrPrdAux & "," & PrdDescAux & "," & PrdFlagAux & "," & PrdFilterAux & "," & PrdShortDescAux & "," & PrdLongDescAux & "," & PrdContentAux & "," & MetaTitleAux & "," & MetaDescAux & "," & MetaKeywordsAux & ") "

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Sub ActualizarCodesCatSub(ByVal readerDatos As OleDbDataReader)
        Dim PrdCodeAux, CatCodeAux, IDMstrCatAux, IDMstrPrdAux, PrdFlagAux As Integer
        Dim PrdDescAux, PrdFilterAux, PrdShortDescAux, PrdLongDescAux, PrdContentAux, MetaTitleAux, MetaDescAux, MetaKeywordsAux As String

        Try
            If readerDatos.HasRows Then

                If IsDBNull(readerDatos.Item("PrdCode")) Then
                    PrdCodeAux = Nothing
                Else
                    PrdCodeAux = readerDatos.Item("PrdCode")
                End If

                If IsDBNull(readerDatos.Item("CatCode")) Then
                    CatCodeAux = Nothing
                Else
                    CatCodeAux = readerDatos.Item("CatCode")
                End If

                If IsDBNull(readerDatos.Item("IDMstrCat")) Then
                    IDMstrCatAux = Nothing
                Else
                    IDMstrCatAux = readerDatos.Item("IDMstrCat")
                End If

                If IsDBNull(readerDatos.Item("IDMstrPrd")) Then
                    IDMstrPrdAux = Nothing
                Else
                    IDMstrPrdAux = readerDatos.Item("IDMstrPrd")
                End If

                If IsDBNull(readerDatos.Item("PrdDesc")) Then
                    PrdDescAux = "Null"
                Else
                    PrdDescAux = "'" & readerDatos.Item("PrdDesc") & "'"
                End If

                If readerDatos.Item("PrdFlag") = True Then
                    PrdFlagAux = 1
                Else
                    PrdFlagAux = 0
                End If

                If IsDBNull(readerDatos.Item("PrdFilter")) Then
                    PrdFilterAux = "Null"
                Else
                    PrdFilterAux = "'" & readerDatos.Item("PrdFilter") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdShortDesc")) Then
                    PrdShortDescAux = "Null"
                Else
                    PrdShortDescAux = "'" & readerDatos.Item("PrdShortDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdLongDesc")) Then
                    PrdLongDescAux = "Null"
                Else
                    PrdLongDescAux = "'" & readerDatos.Item("PrdLongDesc") & "'"
                End If

                If IsDBNull(readerDatos.Item("PrdContent")) Then
                    PrdContentAux = "Null"
                Else
                    PrdContentAux = "'" & readerDatos.Item("PrdContent") & "'"
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
                End If

                claseSQL = "update `Codes Catsub` set IDMstrCat = " & IDMstrCatAux & " ,IDMstrPrd = " & IDMstrPrdAux & " ,PrdDesc = " & PrdDescAux & " ,PrdFlag = " & PrdFlagAux _
                & ", PrdFilter = " & PrdFilterAux & ",PrdShortDesc = " & PrdShortDescAux & ",PrdLongDesc = " & PrdLongDescAux & ",PrdContent = " & PrdContentAux & ",MetaTitle = " _
                & MetaTitleAux & ",MetaKeywords = " & MetaKeywordsAux & " where PrdCode = " & PrdCodeAux

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
