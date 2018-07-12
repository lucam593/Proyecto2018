Imports DAO
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

    Function cargarUsuarios() As List(Of BL_Usuario)

        Dim daoUsuarios As New DAO_Usuario()
        Dim usuarios As New List(Of BL_Usuario)

        For Each x In daoUsuarios.cargarUsuarios()
            Dim usuario As New BL_Usuario
            usuario.NombreDeUsuario = x.NombreDeUsuario
            usuario.Rol = x.Rol
            usuario.Contrasena = x.Contrasena
            usuarios.Add(usuario)
        Next
        Return usuarios
    End Function

    Public Sub registrarUsuario(usuario As String, cont As String, rol As String)
        Dim daoUser As New DAO_Usuario

        daoUser.insertarUsuario(usuario, cont, rol)
    End Sub

    Public Sub modificarUsuario(usuario As String, cont As String, rol As String)
        Dim daoUser As New DAO_Usuario

        daoUser.modificarUsuarioAd(usuario, cont, rol)
    End Sub

    Public Sub eliminarUsuario(usuario As String)
        Dim daoUser As New DAO_Usuario

        daoUser.eliminarUsuario(usuario)
    End Sub
End Class
