Imports System.Timers
Public Class ServiceSyncBD
    Private objetoXML As New ManejoXML
    Private objectLibrary As New Library
    Private timer1 As New Timer
    Private intervaloTimer As Double
    Protected Overrides Sub OnStart(ByVal args() As String)
        intervaloTimer = TiempoEjecucionSincronizador(objetoXML.ObtenerValorXML("TiempoEjecucionServicioSincronizacion", "Configuracion.xml"))
        timer1.Interval = intervaloTimer
        AddHandler timer1.Elapsed, AddressOf timer1_Tick
        timer1.Enabled = True
        objectLibrary.WriteErrorLog("Servicio de sincronización BETA 1 Inicio del Servicio sincronizando cada: " & intervaloTimer & " milisegundos")
    End Sub

    Protected Overrides Sub OnStop()
        timer1.Enabled = False
        objectLibrary.WriteErrorLog("Servicio de sincronización BETA 1 detenido, gracias por probar.")
    End Sub
    Private Sub timer1_Tick(sender As Object, e As ElapsedEventArgs)
        Dim objetoSincronizacion As New Sincronizacion
        intervaloTimer = TiempoEjecucionSincronizador(objetoXML.ObtenerValorXML("TiempoEjecucionServicioSincronizacion", "Configuracion.xml"))
        timer1.Interval = intervaloTimer
        objectLibrary.WriteErrorLog("Sincronizando cada: " & intervaloTimer & " milisegundos")
        objetoSincronizacion.IniciarProcesoSincronizacion()
    End Sub
End Class
