Imports [TO]
Imports DAO

Public Class BL_Estado
    Property LimiteMinutos As Int16
    Property NombreEstado As String
    Property Indice As Int16

    Public Sub AsignarDesdeTOEstado(toEstado As TO_Estado)
        Me.NombreEstado = toEstado.NombreEstado
        Me.LimiteMinutos = toEstado.LimiteMinutos
        Me.Indice = toEstado.Indice
    End Sub

    Sub New(str As String)
        Me.NombreEstado = str
    End Sub

    Sub New()

    End Sub

    Public Function Crear_To_Estado() As TO_Estado
        Dim toEstado As New TO_Estado()
        toEstado.NombreEstado = Me.NombreEstado
        toEstado.LimiteMinutos = Me.LimiteMinutos
        toEstado.Indice = Me.Indice

        Return toEstado
    End Function

    Public Function cargarEstados() As List(Of BL_Estado)
        Dim daoEstados As New DAO_Estado()
        Dim estados As New List(Of BL_Estado)

        For Each x In daoEstados.cargarEstados()
            Dim estado As New BL_Estado
            estado.Indice = x.Indice
            estado.NombreEstado = x.NombreEstado
            estado.LimiteMinutos = x.LimiteMinutos
            estados.Add(estado)
        Next
        Return estados
    End Function

    Public Sub modificarEstado(indice As String, tiempo As Short)
        Dim daoEstados As New DAO_Estado()

        daoEstados.modificarEstado(indice, tiempo)

    End Sub
End Class
