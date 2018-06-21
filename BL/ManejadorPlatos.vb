Imports [TO]
Imports DAO
Public Class ManejadorPlatos

    Function cargarPlatos() As List(Of BL_Plato)

        Dim daoplatos As New DAOPlato()
        Dim platos As New List(Of BL_Plato)
        For Each x In daoplatos.cargarPlatos()
            platos.Add(New BL_Plato(x.Nombre, x.Descripcion, x.Precio, x.Fotografia, x.Habilitado))
        Next
        Return platos
    End Function
End Class
