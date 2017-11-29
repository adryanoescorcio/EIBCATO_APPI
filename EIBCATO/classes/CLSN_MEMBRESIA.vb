Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_MEMBRESIA

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Membresia)
        Try

            Dim dao = New PIBICAS.Models.Dao.MembresiaDAO
            Return dao.CarregarDados.ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Sub inserirAtualizarObjeto(_obj As Membresia)
        Dim dao = New PIBICAS.Models.Dao.MembresiaDAO
        dao.InsertOrUpdate(_obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.MembresiaDAO
        dao.Delete(_id)
    End Sub

    Friend Function pesquisarUsuarioId(usuarioId As Integer) As Membresia
        Dim dao = New PIBICAS.Models.Dao.MembresiaDAO
        Return dao.PesquisarPorUsuarioId(usuarioId)
    End Function
End Class
