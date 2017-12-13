Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_CLASSE_PLANOAULA

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.ClassePlanoAula)
        Try
            Dim dao = New PIBICAS.Models.Dao.ClassePlanoAulaDAO
            Return dao.CarregarDados().ToList
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As ClassePlanoAula
        Dim dao = New PIBICAS.Models.Dao.ClassePlanoAulaDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As ClassePlanoAula)
        Dim dao = New PIBICAS.Models.Dao.ClassePlanoAulaDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.ClassePlanoAulaDAO
        dao.Delete(_id)
    End Sub

    Friend Sub excluirClassePlano(idPlano As String, idClasse As Integer)
        Dim dao = New PIBICAS.Models.Dao.ClassePlanoAulaDAO
        dao.Delete(dao.PesquisarPorClassePlano(idPlano, idClasse))
    End Sub
End Class
