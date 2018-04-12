﻿<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ServiceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller()
        Me.SyncBDService = New System.ServiceProcess.ServiceInstaller()
        '
        'ServiceProcessInstaller1
        '
        Me.ServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ServiceProcessInstaller1.Password = Nothing
        Me.ServiceProcessInstaller1.Username = Nothing
        '
        'SyncBDService
        '
        Me.SyncBDService.Description = "SyncBD Sistema de Sincronización Base de Datos"
        Me.SyncBDService.DisplayName = "SyncBD Sistema de Sincronización Base de Datos"
        Me.SyncBDService.ServiceName = "SyncBD"
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceProcessInstaller1, Me.SyncBDService})

    End Sub

    Friend WithEvents ServiceProcessInstaller1 As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents SyncBDService As ServiceProcess.ServiceInstaller
End Class