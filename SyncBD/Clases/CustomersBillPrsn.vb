Imports MySql.Data.MySqlClient
Public Class CustomersBillPrsn
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoCustomersBillPrsn As New MySqlCustomersBillPrsn
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarCustomersBillPrsn()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = CustomersBillPrsn")
        objectLibrary.WriteProcessLog("Sincronizando tabla = CustomersBillPrsn", "CustomersBillPrsn.txt")

        Try
            'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
            readerDatos = ObtenerCustomersBillPrsnAccess()
            '************************************************************
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If Not EsCustomersBillPrsnIDExistenteMySql(readerDatos.Item("PrsnID")) Then
                        objetoCustomersBillPrsn.IngresarCustomersBillPrsn(readerDatos)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    Else
                        objetoCustomersBillPrsn.ActualizarCustomersBillPrsn(readerDatos)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("CustomersBillPrsn: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "CustomersBillPrsn.txt")
                objectLibrary.WriteProcessLog("CustomersBillPrsn: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "CustomersBillPrsn.txt")
                objectLibrary.WriteErrorLog("CustomersBillPrsn: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("CustomersBillPrsn: No se encontraron registros para sincronizar", "CustomersBillPrsn.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerCustomersBillPrsnAccess() As OleDb.OleDbDataReader
        claseSQL = "Select * from [Customers BillPrsn] order By CustID"
        ObtenerCustomersBillPrsnAccess = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Private Function EsCustomersBillPrsnIDExistenteMySql(prsnID As String) As Boolean
        Dim resultado As Boolean = False
        Dim otroMySqlsHelper As New MySqlHelper
        Dim reader As MySqlDataReader
        Try
            claseSQL = "SELECT * from `Customers BillPrsn` where PrsnID = " & prsnID
            reader = otroMySqlsHelper.MySqlHelperExecuteReader(claseSQL)
            If reader.HasRows Then
                resultado = True
            Else
                resultado = False
            End If
            reader.Close()
            reader = Nothing
            otroMySqlsHelper.strcon.Close()
            otroMySqlsHelper.cmd.Dispose()
            otroMySqlsHelper = Nothing
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        EsCustomersBillPrsnIDExistenteMySql = resultado
    End Function
End Class
