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


End Class
