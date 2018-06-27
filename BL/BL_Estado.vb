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

    Public Function Crear_To_Estado() As TO_Estado
        Dim toEstado As New TO_Estado()
        toEstado.NombreEstado = Me.NombreEstado
        toEstado.LimiteMinutos = Me.LimiteMinutos
        toEstado.Indice = Me.Indice

        Return toEstado
    End Function
End Class
