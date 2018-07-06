Imports [TO]
Imports DAO
Public Class BL_Pedido
    Property Fecha As DateTime
    Property Estado As BL_Estado
    Property Cliente As BL_Cliente
    Property DetallePedido As List(Of BL_DetallePedido)
    Property NumeroPedido As Int16

    Public Sub New()
        Me.Estado = New BL_Estado()
        Me.Cliente = New BL_Cliente()
    End Sub

    Public Sub entregarPedido(numPedido As Int16)
        Dim daoPedido As New DAO_Pedido
        daoPedido.alterarEstadoPedido(numPedido, "Entregado")
    End Sub

    Public Sub revertirEntrega(numPedido As Int16, estadoAnterior As String)
        Dim daoPedido As New DAO_Pedido
        daoPedido.alterarEstadoPedido(numPedido, estadoAnterior)
    End Sub

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
        toPedido = Me.Crear_TO_Pedido()
        Dim daoPedido As New DAO_Pedido()
        daoPedido.insertarPedido(toPedido)
    End Sub

    Public Sub actualizarEstado()

        If Me.Estado.NombreEstado <> "Demorado" Then
            If DateTime.Now = Me.Fecha.AddMinutes(Me.Estado.LimiteMinutos) Then

                Dim toPedido As New TO_Pedido
                toPedido = Me.Crear_TO_Pedido()

                Dim daoPedido As New DAO_Pedido()
                daoPedido.cambiarSiguienteEstado(toPedido)

                Me.Estado.AsignarDesdeTOEstado(toPedido.Estado)
            End If
        End If
    End Sub

    Public Sub entregarPlato()
        Dim toPedido As New TO_Pedido
        toPedido = Me.Crear_TO_Pedido()

        toPedido.Estado.Indice = 3

        Dim daoPedido As New DAO_Pedido()
        daoPedido.cambiarSiguienteEstado(toPedido)

        Me.Estado.AsignarDesdeTOEstado(toPedido.Estado)
    End Sub

    Public Sub anularPlato()
        Dim toPedido As New TO_Pedido
        toPedido = Me.Crear_TO_Pedido()

        toPedido.Estado.Indice = 4

        Dim daoPedido As New DAO_Pedido()
        daoPedido.cambiarSiguienteEstado(toPedido)

        Me.Estado.AsignarDesdeTOEstado(toPedido.Estado)
    End Sub

    Public Sub IgualarDesdeTO_Pedido(toPedido As TO_Pedido)
        Me.NumeroPedido = toPedido.NumeroPedido

        Me.Fecha = toPedido.Fecha

        Dim estado As New BL_Estado()
        estado.AsignarDesdeTOEstado(toPedido.Estado)
        Me.Estado = estado

        Dim cliente As New BL_Cliente()
        cliente.AsignarDesdeTOCliente(toPedido.Cliente)
        Me.Cliente = cliente

        If toPedido.DetallePedido IsNot Nothing Then
            Me.DetallePedido = New List(Of BL_DetallePedido)
            For Each toDetalle As TO_DetallePedido In toPedido.DetallePedido
                Dim blDetalle As New BL_DetallePedido()
                blDetalle.AsignarDesdeTODetallePedido(toDetalle)
                Me.DetallePedido.Add(blDetalle)
            Next
        End If
    End Sub

    Public Function Crear_TO_Pedido() As TO_Pedido
        Dim toPedido As New TO_Pedido()

        toPedido.NumeroPedido = Me.NumeroPedido

        toPedido.Fecha = Me.Fecha

        Dim estado As New TO_Estado()
        estado = Me.Estado.Crear_To_Estado()
        toPedido.Estado = estado

        Dim cliente As New TO_Cliente()
        cliente = Me.Cliente.Crear_To_Cliente()
        toPedido.Cliente = cliente

        If Me.DetallePedido IsNot Nothing Then
            toPedido.DetallePedido = New List(Of TO_DetallePedido)
            For Each detallePedido As BL_DetallePedido In Me.DetallePedido
                Dim toDetalle As New TO_DetallePedido()
                toDetalle = detallePedido.Crear_To_DetallePedido()
                toPedido.DetallePedido.Add(toDetalle)
            Next
        End If

        Return toPedido
    End Function
End Class
