Imports MySql.Data.MySqlClient
Public Class CustomersBill
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoVCustomersBill As New MySqlCustomersBill
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarCustomersBill()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = CustomersBill")
        objectLibrary.WriteProcessLog("Sincronizando tabla = CustomersBill", "CustomersBill.txt")

        Try
            'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
            readerDatos = ObtenerCustomersBillAccess()
            '************************************************************
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If Not EsCustomersBillIDExistenteMySql(readerDatos.Item("custid")) Then
                        objetoVCustomersBill.IngresarCustomersBill(readerDatos)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    Else
                        objetoVCustomersBill.ActualizarCustomersBill(readerDatos)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("CustomersBill: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "CustomersBill.txt")
                objectLibrary.WriteProcessLog("CustomersBill: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "CustomersBill.txt")
                objectLibrary.WriteErrorLog("CustomersBill: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("CustomersBill: No se encontraron registros para sincronizar", "CustomersBill.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerCustomersBillAccess() As OleDb.OleDbDataReader
        claseSQL = "Select * from [Customers Bill] order by custid"
        ObtenerCustomersBillAccess = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Private Function EsCustomersBillIDExistenteMySql(customerID As String) As Boolean
        Dim resultado As Boolean = False
        Dim otroMySqlsHelper As New MySqlHelper
        Dim reader As MySqlDataReader
        Try
            claseSQL = "SELECT * from `Customers Bill` where custid = " & customerID
            reader = otroMySqlsHelper.MySqlHelperExecuteReader(claseSQL)
            If reader.HasRows Then
                resultado = True
                reader.Close()
                reader = Nothing
                otroMySqlsHelper.strcon.Close()
                otroMySqlsHelper.cmd.Dispose()
            Else
                resultado = True
                reader.Close()
                reader = Nothing
                otroMySqlsHelper.strcon.Close()
                otroMySqlsHelper.cmd.Dispose()
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        EsCustomersBillIDExistenteMySql = resultado
    End Function
End Class
