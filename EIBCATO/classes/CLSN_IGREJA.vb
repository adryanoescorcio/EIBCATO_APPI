Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_Igreja

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Igreja)
        Try

            Dim dao = New PIBICAS.Models.Dao.IgrejaDAO
            Return dao.CarregarDados.ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub inserirAtualizarObjeto(_obj As Igreja)
        Dim dao = New PIBICAS.Models.Dao.IgrejaDAO
        dao.InsertOrUpdate(_obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.IgrejaDAO
        dao.Delete(_id)
    End Sub
End Class
