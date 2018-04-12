Imports System.Data.OleDb
Public Class MySqlCustomersBillPrsn
    Private claseSQL As String
    Private objetoCMySqlCustomersBillPrsn As New CMySqlCustomersBillPrsn
    Private objectLibrary As New Library
    Public Sub IngresarCustomersBillPrsn(ByVal readerDatos As OleDbDataReader)
        Dim DateCreate, DateMod As String
        Dim DateAux As Date
        Dim objetoMysqlHelper As New MySqlHelper
        Try
            If readerDatos.HasRows Then
                DateAux = readerDatos.Item("DateCreated")
                DateCreate = DateAux.ToString("yyyyMMddhhmmdd")

                DateAux = readerDatos.Item("DateModified")
                DateMod = DateAux.ToString("yyyyMMddhhmmdd")

                claseSQL = "INSERT INTO `Customers BillPrsn` " & objetoCMySqlCustomersBillPrsn.CustomersBillPrsn() & " values(" & readerDatos.Item("CustID") & " , " & readerDatos.Item("PrsnID") & " , '" & readerDatos.Item("PrsnName") & "' , " & readerDatos.Item("PrsnCode") &
                ", '" & readerDatos.Item("PhNo") & "' , " & readerDatos.Item("PhCode") & " , " & readerDatos.Item("AuthBuyer") & ", '" & readerDatos.Item("email") & "' , '" & DateCreate & "'" &
                ", '" & DateMod & "' , " & readerDatos.Item("UpLoad") & " , '" & readerDatos.Item("UserName") & "', '" & readerDatos.Item("Password") & "' )"

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
                objetoMysqlHelper = Nothing
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Sub ActualizarCustomersBillPrsn(ByVal readerDatos As OleDbDataReader)
        Dim DateCreate, DateMod As String
        Dim DateAux As Date
        Dim objetoMysqlHelper As New MySqlHelper
        Try
            If readerDatos.HasRows Then
                DateAux = readerDatos.Item("DateCreated")
                DateCreate = DateAux.ToString("yyyyMMddhhmmdd")

                DateAux = readerDatos.Item("DateModified")
                DateMod = DateAux.ToString("yyyyMMddhhmmdd")

                claseSQL = "update `Customers BillPrsn` set CustID = " & readerDatos.Item("CustID") & ", PrsnName = '" & readerDatos.Item("PrsnName") &
                    "', PrsnCode = " & readerDatos.Item("PrsnCode") & ", PhNo = '" & readerDatos.Item("PhNo") & "', PhCode = " & readerDatos.Item("PhCode") &
                    ", AuthBuyer = " & readerDatos.Item("AuthBuyer") & " , email = '" & readerDatos.Item("email") & "', DateCreated = '" & DateCreate &
                    "', DateModified = '" & DateMod & "' , UpLoad = " & readerDatos.Item("UpLoad") & "  , UserName = '" & readerDatos.Item("UserName") &
                    "', Password = '" & readerDatos.Item("Password") & "' where PrsnID = " & readerDatos.Item("PrsnID")

                objetoMysqlHelper.MySqlHelperExecuteNonQuery(claseSQL)
                objetoMysqlHelper.strcon.Close()
                objetoMysqlHelper.cmd.Dispose()
                objetoMysqlHelper = Nothing
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
End Class
