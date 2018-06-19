Public Class TO_Pedido
    Property Fecha As DateTime
    Property Estado As TO_Estado
    Property Cliente As TO_Cliente
    Property DetallePedido As List(Of TO_DetallePedido)
    Property NumeroPedido As Int16
End Class
