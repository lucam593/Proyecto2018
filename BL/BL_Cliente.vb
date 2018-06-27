Imports [TO]
Imports DAO

Public Class BL_Cliente
    Inherits BL_Usuario
    Property Direccion As String
    Property NombreCompleto As String
    Property Correo As String
    Property Habilitado As Boolean

    Public Sub AsignarDesdeTOCliente(toCliente As TO_Cliente)
        Me.NombreDeUsuario = toCliente.NombreDeUsuario
        Me.NombreCompleto = toCliente.NombreCompleto
        Me.Correo = toCliente.Correo
        Me.Habilitado = toCliente.Habilitado
        Me.Direccion = toCliente.Direccion
    End Sub

    Public Function Crear_To_Cliente() As TO_Cliente
        Dim toCliente As New TO_Cliente()
        toCliente.NombreDeUsuario = Me.NombreDeUsuario
        toCliente.NombreCompleto = Me.NombreCompleto
        toCliente.Correo = Me.Correo
        toCliente.Habilitado = Me.Habilitado
        toCliente.Direccion = Me.Direccion
        Return toCliente
    End Function
End Class
