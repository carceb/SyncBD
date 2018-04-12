Module SyncBDModuloPrincipal
    Public Function IsNulo(ByVal Var As Object, ByVal tipo As String) As String
        Dim resultado As String
        If IsDBNull(Var) Or Var.ToString = "" Then
            resultado = tipo
        Else
            resultado = Var
            resultado = resultado.Replace("RECT", "`RECT`")
            resultado = resultado.Replace("'", "")
            resultado = resultado.Replace(".", "")
            resultado = resultado.Replace("/", "//")
            resultado = "'" & resultado & "'"
        End If
        Return resultado
    End Function
    Public Function IsNuloNum(ByVal Var As Object, ByVal tipo As String) As String
        Dim resultado As String
        If IsDBNull(Var) Or Var.ToString = "" Then
            resultado = tipo
        Else
            ' If Var < 0 Then
            'resultado = "(" & Var & ")"
            'Else
            resultado = Var
            ' End If

        End If
        Return resultado
    End Function
    Public Function IsNuloDate(ByVal Var As Object, ByVal tipo As String, ByVal db As String) As String
        Dim resultado As String
        Dim Fecha As Date

        If IsDBNull(Var) Or Var.ToString = "" Then
            resultado = tipo
        Else
            If db = "mysql" Then
                Fecha = Var
                resultado = "'" & Fecha.ToString("yyyyMMddhhmmss") & "'"
                'resultado = "'" & Var.ToString("yyyy-mm-dd hh:mm:ss") & "'"
            Else
                resultado = "'" & Var & "'"
            End If

        End If
        Return resultado
    End Function
    Public Function TiempoEjecucionSincronizador(valorConfiguracionXML As String) As Double
        Dim resultado As Double = 0
        Dim objectLibrary As New Library
        Try
            Select Case valorConfiguracionXML
                Case "30 Segundos"
                    resultado = 30000
                Case "40 Segundos"
                    resultado = 40000
                Case "50 Segundos"
                    resultado = 50000
                Case "1 Minuto"
                    resultado = 60000
                Case "5 Minutos"
                    resultado = 300000
                Case "10 Minutos"
                    resultado = 600000
                Case "15 Minutos"
                    resultado = 900000
                Case "20 Minutos"
                    resultado = 1200000
                Case "30 Minutos"
                    resultado = 1800000
            End Select
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        TiempoEjecucionSincronizador = resultado
    End Function
End Module
