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

    Sub New()

    End Sub
    Sub New(nomUser As String, nom As String, cor As String, dir As String, hab As Boolean)
        Me.NombreDeUsuario = nomUser
        Me.NombreCompleto = nom
        Me.Correo = cor
        Me.Direccion = dir
        Me.Habilitado = hab
    End Sub


    Public Function cargarClientes() As List(Of BL_Cliente)
        Dim daoclientes As New DAOCliente
        Dim clientes As New List(Of BL_Cliente)

        For Each x In daoclientes.cargarClientes()


            clientes.Add(New BL_Cliente(x.NombreDeUsuario, x.NombreCompleto, x.Correo, x.Direccion, x.Habilitado))

        Next
        Return clientes
    End Function

    Public Sub modificarEstado(nombre As String, checked As Boolean)
        Dim clienteestado = New DAOCliente

        clienteestado.modificarEstado(nombre, checked)
    End Sub
End Class
