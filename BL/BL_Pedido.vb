Public Class BL_Pedido
    Property Fecha As DateTime
    Property Estado As BL_Estado
    Property Cliente As BL_Cliente
    Property listaPlatos As List(Of BL_Plato)
End Class
