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

    Sub New(num As Int16, cli As String, esta As String, fecha As DateTime)
        Me.NumeroPedido = num
        Dim cliente As New TO_Cliente()
        cliente.NombreDeUsuario = cli
        Me.Cliente = cliente

        Dim estado As New TO_Estado()
        estado.NombreEstado = esta
        Me.Estado = estado

        Me.Fecha = fecha
    End Sub
End Class
