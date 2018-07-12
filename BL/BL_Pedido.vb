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

    Public Sub cargarPedido()
        Dim daoPedido As New DAO_Pedido()
        Dim toPedido As New TO_Pedido()
        toPedido.NumeroPedido = Me.NumeroPedido
        daoPedido.cargarPedido(toPedido)
        IgualarDesdeTO_Pedido(toPedido)

    End Sub

    Public Function cargarPedidos() As List(Of BL_Pedido)
        Dim daoPedido As New DAO_Pedido()
        Dim pedidos As New List(Of BL_Pedido)

        For Each x In daoPedido.cargarEstados()
            Dim pedido As New BL_Pedido
            pedido.NumeroPedido = x.NumeroPedido
            pedido.Cliente = New BL_Cliente(x.Cliente.NombreDeUsuario, x.Cliente.NombreCompleto, x.Cliente.Correo, x.Cliente.Direccion, x.Cliente.Habilitado)
            pedido.Estado = New BL_Estado(x.Estado.NombreEstado)
            pedido.Fecha = x.Fecha

            pedidos.Add(pedido)
        Next
        Return pedidos
    End Function

    Public Function getEstado() As String
        Dim daoPedido As New DAO_Pedido()
        Return daoPedido.getEstado(Me.NumeroPedido)
    End Function

    Public Sub entregarPedido(numPedido As Int16)
        Dim daoPedido As New DAO_Pedido
        daoPedido.alterarEstadoPedido(numPedido, "Entregado")
    End Sub

    Public Sub modificarEstado(v1 As Short, v2 As String)
        Dim daoPed As New DAO_Pedido
        daoPed.modificarEstado(v1, v2)
    End Sub

    Public Sub anularPedido(numPedido As Int16)
        Dim daoPedido As New DAO_Pedido
        daoPedido.alterarEstadoPedido(numPedido, "Anulado")
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

        Me.DetallePedido.Add(detallePedido)
    End Sub

    Public Sub ingresarPedido()
        Dim toPedido As New TO_Pedido()
        toPedido = Me.Crear_TO_Pedido()
        Dim daoPedido As New DAO_Pedido()
        daoPedido.insertarPedido(toPedido)
    End Sub

    Public Sub actualizarEstado()

        If Me.Estado.NombreEstado.Trim() <> "Demorado" And
           Me.Estado.NombreEstado.Trim() <> "Entregado" And
           Me.Estado.NombreEstado.Trim() <> "Anulado" Then

            Dim daoPedido As New DAO_Pedido()
            Dim listEstados As New List(Of TO_Estado)
            listEstados = daoPedido.getEstados()

            If DateTime.Now >= Me.Fecha.AddMinutes(listEstados.ElementAt(0).LimiteMinutos) Then

                Dim toPedido As New TO_Pedido
                toPedido = Me.Crear_TO_Pedido()
                daoPedido.cambiarSiguienteEstado(toPedido, "Sobre Tiempo")
                Me.Estado.AsignarDesdeTOEstado(toPedido.Estado)
            End If
            If DateTime.Now >= Me.Fecha.AddMinutes(listEstados.ElementAt(4).LimiteMinutos) Then
                Dim toPedido As New TO_Pedido
                toPedido = Me.Crear_TO_Pedido()
                daoPedido.cambiarSiguienteEstado(toPedido, "Demorado")
                Me.Estado.AsignarDesdeTOEstado(toPedido.Estado)
            End If
        End If
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
