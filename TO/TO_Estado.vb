Public Class TO_Estado
    Property LimiteMinutos As Int16
    Property NombreEstado As String
    Property Indice As Int16

    Sub New()

    End Sub

    Sub New(limi As Int16, nom As String, indi As Int16)
        LimiteMinutos = limi
        NombreEstado = nom
        Indice = indi
    End Sub
End Class
