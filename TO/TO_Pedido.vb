Public Class TO_Pedido
    Property Fecha As DateTime
    Property Estado As TO_Estado
    Property Cliente As TO_Cliente
    Property DetallePedido As List(Of TO_DetallePedido)
    Property NumeroPedido As Int16

    Public Sub New()
        Me.Cliente = New TO_Cliente()
        Me.Estado = New TO_Estado()
    End Sub
End Class
