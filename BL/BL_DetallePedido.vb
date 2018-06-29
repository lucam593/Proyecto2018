Imports [TO]
Imports DAO

Public Class BL_DetallePedido
    Property NumeroPedido As Int16
    Property Plato As BL_Plato
    Property Cantidad As Int16

    Public Sub AsignarDesdeTODetallePedido(toDetallePedido As TO_DetallePedido)
        Me.NumeroPedido = toDetallePedido.NumeroPedido
        Dim plato As New BL_Plato()
        plato.asignarDesdeTOPlato(toDetallePedido.Plato)
        Me.Plato = plato
        Me.Cantidad = toDetallePedido.Cantidad
    End Sub

    Public Function Crear_To_DetallePedido() As TO_DetallePedido
        Dim toDetallePedido As New TO_DetallePedido()
        toDetallePedido.NumeroPedido = Me.NumeroPedido

        Dim toPlato As New TO_Plato()
        toPlato = Me.Plato.AsignarAToPlato()
        toDetallePedido.Plato = toPlato

        toDetallePedido.Cantidad = Me.Cantidad

        Return toDetallePedido
    End Function

End Class
