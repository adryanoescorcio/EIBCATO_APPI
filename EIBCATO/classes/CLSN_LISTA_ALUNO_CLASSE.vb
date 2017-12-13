Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_LISTA_ALUNO_CLASSE

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Lista)
        Try
            Dim dao = New PIBICAS.Models.Dao.ListaDAO
            Return dao.CarregarDados().ToList
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As Lista
        Dim dao = New PIBICAS.Models.Dao.ListaDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As Lista)
        Dim dao = New PIBICAS.Models.Dao.ListaDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.ListaDAO
        dao.Delete(_id)
    End Sub

    Friend Sub excluirAlunoClasse(idAluno As String, idClasse As Integer?)
        Try
            Dim dao = New PIBICAS.Models.Dao.ListaDAO
            dao.Delete(dao.PesquisarPorClasseAluno(idAluno, idClasse))

        Catch ex As Exception
            Throw New Exception("Não é possivel excluir este aluno.")
        End Try
    End Sub
End Class
