Public Class BL_Pedido
    Property Fecha As DateTime
    Property Estado As BL_Estado
    Property Cliente As BL_Cliente
    Property DetallePedido As List(Of BL_DetallePedido)
    Property NumeroPedido As Int16



End Class
