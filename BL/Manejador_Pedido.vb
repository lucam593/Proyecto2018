Imports [TO]
Imports DAO

Public Class Manejador_Pedido
    Property listaPedidos As List(Of BL_Pedido)

    Public Sub cargarPedidosPorCliente(blCliente As BL_Cliente)
        Me.listaPedidos = New List(Of BL_Pedido)

        Dim toListaPedidos As New TO_ListaPedidos()
        Dim toCliente As New TO_Cliente()

        toCliente = blCliente.Crear_To_Cliente()

        Dim daoPedido As New DAO_Pedido()
        daoPedido.caragarPedidosDeCliente(toListaPedidos, toCliente)

        For Each toPedido As TO_Pedido In toListaPedidos.listaPedidos
            Dim blPedido As New BL_Pedido()
            blPedido.IgualarDesdeTO_Pedido(toPedido)
            Me.listaPedidos.Add(blPedido)
        Next
    End Sub

    Public Sub cargarPedidosCocina()
        Me.listaPedidos = New List(Of BL_Pedido)
        Dim toListaPedidos As New TO_ListaPedidos()

        Dim daoPedido As New DAO_Pedido()
        daoPedido.cargarPedidosCocina(toListaPedidos)

        For Each toPedido As TO_Pedido In toListaPedidos.listaPedidos
            Dim blPedido As New BL_Pedido()
            blPedido.IgualarDesdeTO_Pedido(toPedido)
            Me.listaPedidos.Add(blPedido)
        Next
    End Sub
End Class
