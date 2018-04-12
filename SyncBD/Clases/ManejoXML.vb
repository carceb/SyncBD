Imports System.Xml
Public Class ManejoXML
    Public Sub New()
    End Sub
    Public Function ObtenerValorXML(nombreNodo As String, nombreArchivoXML As String) As String
        Dim objectLibrary As New Library
        Dim resultadoValorNodo As String = ""
        Dim confFilePath As String
        Try
            confFilePath = My.Application.Info.DirectoryPath & "\" & nombreArchivoXML
            If (IO.File.Exists(confFilePath)) Then
                Dim document As XmlReader = New XmlTextReader(confFilePath)
                While (document.Read())
                    Dim type = document.NodeType
                    If (type = XmlNodeType.Element) Then
                        If (document.Name = nombreNodo) Then
                            resultadoValorNodo = document.ReadInnerXml.ToString()
                        End If
                    End If
                End While
                document.Close()
            End If
            ObtenerValorXML = resultadoValorNodo
        Catch ex As Exception
            objectLibrary.WriteErrorLog(ex.Message)
            ObtenerValorXML = ""
        End Try
    End Function

    '**************************************************************************************
    'SOLO PARA CONTROL DEL VERSIONES
    '**************************************************************************************
    Public Function ActualizarSBDPXML() As Boolean
        Dim resultado As Boolean = False
        Dim objectLibrary As New Library
        Dim objetoLectorXML As New ManejoXML
        Dim numeroCompilacion As Integer
        Try
            numeroCompilacion = Convert.ToInt32(objetoLectorXML.ObtenerValorXML("Compilaciones", "SBDP.xml"))
            Dim settings As New XmlWriterSettings()
            settings.Indent = True
            Dim XmlWrt As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\SBDP.xml", settings)
            With XmlWrt
                .WriteStartDocument()
                .WriteComment("XML Database.")
                .WriteStartElement("Data")
                .WriteStartElement("Configuracion")
                numeroCompilacion = numeroCompilacion + 1
                .WriteStartElement("Compilaciones")
                .WriteString(numeroCompilacion)

                .WriteEndElement()
                .WriteEndDocument()
                .Close()
                resultado = True
            End With
        Catch ex As Exception
            resultado = False
            objectLibrary.WriteErrorLog(ex.Message)
        End Try
        ActualizarSBDPXML = resultado
    End Function
    '**************************************************************************************
End Class
