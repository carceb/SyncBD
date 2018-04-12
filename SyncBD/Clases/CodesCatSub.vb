Imports MySql.Data.MySqlClient
Public Class CodesCatSub
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoCodesCatSub As New MySqlCodesCatSub
    Private objectLibrary As New Library
    Public Sub New()
    End Sub
    Public Sub SincronizarCodesCatSub()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = CodesCatSub")
        objectLibrary.WriteProcessLog("Sincronizando tabla = CodesCatSub", "CodesCatSub.txt")

        Try
            'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
            readerDatos = ObtenerCodesCatSubAccess()
            '************************************************************
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If EsRegistroExistente(readerDatos.Item("PrdCode")) Then
                        objetoCodesCatSub.ActualizarCodesCatSub(readerDatos)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    Else
                        If readerDatos.Item("PrdCode") <> 0 Then
                            objetoCodesCatSub.IngresarCodesCatSub(readerDatos)
                            totalRegistrosNuevos = totalRegistrosNuevos + 1
                        End If
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("CodesCatSub: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "CodesCatSub.txt")
                objectLibrary.WriteProcessLog("CodesCatSub: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "CodesCatSub.txt")
                objectLibrary.WriteErrorLog("CodesCatSub: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("CodesCatSub: No se encontraron registros para sincronizar", "CodesCatSub.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Private Function ObtenerCodesCatSubAccess() As OleDb.OleDbDataReader
        claseSQL = "Select * from [Codes Catsub]"
        ObtenerCodesCatSubAccess = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Public Function EsRegistroExistente(PrdCode As String) As Boolean
        Dim readerRegistro As MySqlDataReader
        Dim objetoMySqlHelper As New MySqlHelper
        Dim resultado As Boolean = False
        Try
            claseSQL = "SELECT * from `Codes Catsub` where PrdCode = " & PrdCode
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
