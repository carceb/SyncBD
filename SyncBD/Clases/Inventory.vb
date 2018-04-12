Imports MySql.Data.MySqlClient
Public Class Inventory 'Administra el proceso de sincronizacion de la tabla Inventory en MySQL
    Private claseSQL As String
    Private objetoAccessHelper As New AccessSqlHelper
    Private objetoMySqlHekper As New MySqlHelper

    Private objetoMySqlInventory As New MySqlInventory
    Private fechaLastUpDate As DateTime
    Private fechaCortaLastUpDate As String
    Private diasHaciaAtras As Integer = 0
    Private objectLibrary As New Library
    Private objetoXML As New ManejoXML
    Public Sub New()
    End Sub
    Public Sub SincronizarInventory()
        Dim readerDatos As OleDb.OleDbDataReader
        Dim totalRegistrosActualizados As Integer = 0
        Dim totalRegistrosNuevos As Integer = 0

        objectLibrary.WriteErrorLog("Servicio de sincronización: Sincronizando tabla = Inventory")
        objectLibrary.WriteProcessLog("Sincronizando tabla = Inventory", "Inventory.txt")
        objectLibrary.WriteProcessLog("Dias hacia atras " & Convert.ToInt32(objetoXML.ObtenerValorXML("CantidadDiasRestaDiaActual", "Configuracion.xml")), "Inventory.txt")

        'Carga el readerDatos con los registros a sincronizar (ingresar o actualizar) en MySQL
        readerDatos = ObtenerLastUpdate("Inventory")
        '************************************************************
        Try
            If readerDatos.HasRows Then
                Do While readerDatos.Read
                    If EsRegistroExistente(readerDatos.Item("skuno")) Then
                        objetoMySqlInventory.ActualizarInventory(readerDatos)
                        totalRegistrosActualizados = totalRegistrosActualizados + 1
                    Else
                        objetoMySqlInventory.IngresarNuevoInventory(readerDatos)
                        totalRegistrosNuevos = totalRegistrosNuevos + 1
                    End If
                Loop
                readerDatos.Close()
                objetoAccessHelper.cnnOLEDB.Close()
                objectLibrary.WriteProcessLog("Inventory: Registros EXISTENTES sincronizados para actualización = " & totalRegistrosActualizados, "Inventory.txt")
                objectLibrary.WriteProcessLog("Inventory: Registros NUEVOS sincronizados para actualización = " & totalRegistrosNuevos, "Inventory.txt")
                objectLibrary.WriteErrorLog("Inventory: Finalizó correctamente evento de sincronización")
            Else
                objectLibrary.WriteProcessLog("Inventory: No se encontraron registros para sincronizar en la fecha = " & fechaCortaLastUpDate, "Inventory.txt")
            End If
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
    End Sub
    Public Function ObtenerLastUpdate(nombreTabla As String) As OleDb.OleDbDataReader
        'Obtiene el numero de dias hacia atras para colocarlo como parametro del campo LastUpDate, tala Inventory de Access
        diasHaciaAtras = Convert.ToInt32(objetoXML.ObtenerValorXML("CantidadDiasRestaDiaActual", "Configuracion.xml"))
        fechaLastUpDate = Date.Now.AddDays(-diasHaciaAtras)
        fechaLastUpDate = fechaLastUpDate.ToShortDateString
        fechaCortaLastUpDate = fechaLastUpDate.ToString("M/d/yyyy")
        '*************************************************************

        'Obtiene los registros filtrados por la cantidad de dias hacia adelante segun el parametro del campo LastUpDate 
        claseSQL = "SELECT * FROM " & nombreTabla & " Where LastUpdate   > #" & fechaCortaLastUpDate & "#"
        ObtenerLastUpdate = objetoAccessHelper.OLDBReader(claseSQL)
    End Function
    Public Function EsRegistroExistente(skuno As String) As Boolean
        Dim readerRegistro As MySqlDataReader
        claseSQL = "SELECT * from Inventory where skuno = " & skuno
        readerRegistro = objetoMySqlHekper.MySqlHelperExecuteReader(claseSQL)
        If readerRegistro.HasRows Then
            EsRegistroExistente = True
        Else
            EsRegistroExistente = False
        End If
        objetoMySqlHekper.strcon.Close()
        objetoMySqlHekper.cmd.Dispose()
    End Function
End Class
