Public Class TO_DetallePedido
    Property NumeroPedido As Int16
    Property Plato As TO_Plato
    Property Cantidad As Int16

    Public Sub New()
        Me.Plato = New TO_Plato()
    End Sub

End Class

