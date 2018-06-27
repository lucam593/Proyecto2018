Public Class TO_Plato
    Property CodigoPlato As Int16
    Property Nombre As String
    Property Descripcion As String
    Property Precio As Double
    Property Fotografia As String
    Property Habilitado As Boolean

    Sub New()

    End Sub

    Sub New(codigoPlato As Int16, nombre As String, desc As String, precio As Double, foto As String, hab As Boolean)
        Me.CodigoPlato = codigoPlato
        Me.Nombre = nombre
        Me.Descripcion = desc
        Me.Precio = precio
        Me.Fotografia = foto
        Me.Habilitado = hab
    End Sub
End Class
