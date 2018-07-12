Imports DAO
Imports [TO]
Public Class BL_Plato
    Property Codigo As Int16
    Property Nombre As String
    Property Descripcion As String
    Property Precio As Double
    Property Fotografia As String
    Property Habilitado As Boolean

    Sub New()
    End Sub
    Sub New(cod As Int16, nom As String, desc As String, pre As Double, foto As String, hab As Boolean)
        Codigo = cod
        Nombre = nom
        Descripcion = desc
        Precio = pre
        Fotografia = foto
        Habilitado = hab
    End Sub

    Sub cargarPlato(cod As Int16)
        Dim daoPlato As New DAOPlato
        Dim toPlato As New TO_Plato
        toPlato = daoPlato.cargarPlato(cod)
        asignarDesdeTOPlato(toPlato)
    End Sub

    Sub asignarDesdeTOPlato(toPlato As TO_Plato)
        Me.Codigo = toPlato.CodigoPlato
        Me.Descripcion = toPlato.Descripcion
        Me.Fotografia = toPlato.Fotografia
        Me.Nombre = toPlato.Nombre
        Me.Precio = toPlato.Precio
        Me.Habilitado = toPlato.Habilitado
    End Sub

    Function asignarAToPlato() As TO_Plato
        Dim toPlato As New TO_Plato()
        toPlato.CodigoPlato = Me.Codigo
        toPlato.Descripcion = Me.Descripcion
        toPlato.Fotografia = Me.Fotografia
        toPlato.Nombre = Me.Nombre
        toPlato.Precio = Me.Precio
        toPlato.Habilitado = Me.Habilitado
        Return toPlato
    End Function

    Public Sub guardarPlato(nombre As String, desc As String, precio As Double, foto As String, checked As Boolean)
        Dim daoPlatos = New DAOPlato
        daoPlatos.guardarPlato(nombre, desc, precio, foto, checked)
    End Sub

    Public Sub modificarUsuario(cod As Int16, nombre As String, desc As String, precio As Double, foto As String, checked As Boolean)
        Dim daoPlatos = New DAOPlato
        daoPlatos.modificarPlato(cod, nombre, desc, precio, foto, checked)
    End Sub

    Public Sub eliminarPlato(cod As Short)
        Dim daoPlatos = New DAOPlato
        daoPlatos.eliminarPlato(cod)
    End Sub
End Class
