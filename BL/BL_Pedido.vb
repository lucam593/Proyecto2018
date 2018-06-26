Imports [TO]
Imports DAO
Public Class BL_Pedido
    Property Fecha As DateTime
    Property Estado As BL_Estado
    Property Cliente As BL_Cliente
    Property DetallePedido As List(Of BL_DetallePedido)
    Property NumeroPedido As Int16

    Public Sub agregarPlato(blPlato As BL_Plato)
        If Me.DetallePedido Is Nothing Then
            Me.DetallePedido = New List(Of BL_DetallePedido)
        End If

        Dim detallePedido As New BL_DetallePedido()
        detallePedido.Plato = blPlato
        detallePedido.NumeroPedido = detallePedido.NumeroPedido

        Me.DetallePedido.Add(detallePedido)
    End Sub

    Public Sub ingresarPedido()
        Dim toPedido As New TO_Pedido()

    End Sub

    Public Sub igualarToPedidoAPedido() 'As TO_Pedido
        Dim toPedido As New TO_Pedido()

        toPedido.NumeroPedido = Me.NumeroPedido

        toPedido.Fecha = Me.Fecha

        Dim estado As New TO_Estado()
        estado = Me.Estado.Crear_To_Estado()
        toPedido.Estado = estado

        Dim cliente As New TO_Cliente()
        cliente = Me.Cliente.Crear_To_Cliente()

        'For Each

    End Sub 'Function
End Class
