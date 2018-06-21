Public Class BL_Plato
    Property Nombre As String
    Property Descripcion As String
    Property Precio As Double
    Property Fotografia As String
    Property Habilitado As Boolean

    Sub New()
    End Sub
    Sub New(nom As String, desc As String, pre As Double, foto As String, hab As Boolean)
        Nombre = nom
        Descripcion = desc
        Precio = pre
        Fotografia = foto
        Habilitado = hab
    End Sub


End Class
