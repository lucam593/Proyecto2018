Imports DAO
Imports [TO]
Public Class BL_Usuario
    Property NombreDeUsuario As String
    Property Contrasena As String
    Property Rol As String

    Sub getUser(usuario As String, validador As String, rol As String)
        Try
            NombreDeUsuario = usuario
            Contrasena = validador
            Dim daoUser As New DAO_Usuario
            Dim toUser As TO_Usuarios = daoUser.cargarUsuario(usuario)
            If Contrasena IsNot toUser.Contrasena Then
                Throw New Exception("Contrasena o usuario invalido")
            End If
            If rol IsNot toUser.Rol Then
                Throw New Exception("Su tipo de cuenta no puede acceder este modulo")
            End If
        Catch ex As Exception
            Me.Contrasena = Nothing
            Me.NombreDeUsuario = Nothing
            Me.Rol = Nothing
        End Try


    End Sub
End Class
