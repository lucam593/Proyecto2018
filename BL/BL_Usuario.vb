﻿Imports DAO
Imports [TO]
Public Class BL_Usuario
    Property NombreDeUsuario As String
    Property Contrasena As String
    Property Rol As String

    Sub seleccionarUsuarioCocina()
        Dim daoUser As New DAO_Usuario
        Dim toUser As TO_Usuarios = daoUser.cargarUsuario(NombreDeUsuario)
        If Contrasena <> toUser.Contrasena.Trim() Then
            Throw New Exception("Contrasena o usuario invalido")
        End If
        If Rol <> toUser.Rol.Trim() Then
            Throw New Exception("Su tipo de cuenta no puede acceder este modulo")
        End If
        Me.Contrasena = Nothing
        Me.NombreDeUsuario = Nothing
        Me.Rol = Nothing
    End Sub

    Sub registrarUsuarioCocina()
        Dim daoUser As New DAO_Usuario
        Dim toUser As New TO_Usuarios
        daoUser.insertarUsuario(Me.NombreDeUsuario, Me.Contrasena, Me.Rol)
    End Sub
End Class
