Imports MySql.Data.MySqlClient
Public Class CodesCat
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoCodesCat As New MySqlCodesCat
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarCodesCat()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = CodesCat")
        objectLibrary.WriteProcessLog("Sincronizando tabla = CodesCat", "CodesCat.txt")

        Try
            'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
            readerDatos = ObtenerCodesCatAccess()
            '************************************************************
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If EsRegistroExistente(readerDatos.Item("CatCode")) Then
                        ' TO DO
                        'objetoCodesCat.ActualizarCodesCat(readerDatos)

                    Else
                        ' TO DO
                        'objetoCodesCat.IngresarCodesCat(readerDatos)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("CatCode: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "CatCode.txt")
                objectLibrary.WriteProcessLog("CatCode: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "CatCode.txt")
                objectLibrary.WriteErrorLog("CatCode: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("CatCode: No se encontraron registros para sincronizar", "CatCode.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerCodesCatAccess() As OleDb.OleDbDataReader
        claseSQL = "Select * from [Codes Cat]"
        ObtenerCodesCatAccess = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Public Function EsRegistroExistente(CatCode As String) As Boolean
        Dim readerRegistro As MySqlDataReader
        Dim objetoMySqlHelper As New MySqlHelper
        Dim resultado As Boolean = False
        Try
            claseSQL = "SELECT * from `Codes Cat` where CatCode = " & CatCode
            readerRegistro = objetoMySqlHelper.MySqlHelperExecuteReader(claseSQL)
            If readerRegistro.HasRows Then
                resultado = True
            Else
                resultado = False
            End If

            readerRegistro.Close()
            readerRegistro = Nothing
            objetoMySqlHelper.strcon.Close()
            objetoMySqlHelper.cmd.Dispose()

        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        EsRegistroExistente = resultado
    End Function
End Class
