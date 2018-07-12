Public Class TO_Cliente
    Inherits TO_Usuarios
    Property Direccion As String
    Property NombreCompleto As String
    Property Correo As String
    Property Habilitado As Boolean

    Public Sub New(nombreUsuario As String, contrasenha As String, rol As String, direccion As String, nombreCompleto As String, Correo As String, Habilitado As Boolean)
        Me.NombreDeUsuario = nombreUsuario
        Me.Contrasena = contrasenha
        Me.Direccion = direccion
        Me.NombreCompleto = nombreCompleto
        Me.Correo = Correo
        Me.Habilitado = Habilitado
    End Sub

    Public Sub New()

    End Sub
End Class
