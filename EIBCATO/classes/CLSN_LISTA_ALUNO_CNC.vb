Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_LISTA_ALUNO_CNC

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid(ByVal idClasse As Integer) As List(Of PIBICAS.Models.Aluno)
        Try
            Dim dao = New PIBICAS.Models.Dao.AlunoDAO
            Return dao.CarregarDados(idClasse).ToList
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As Aluno
        Dim dao = New PIBICAS.Models.Dao.AlunoDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As Aluno)
        Dim dao = New PIBICAS.Models.Dao.AlunoDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Try
            Dim dao = New PIBICAS.Models.Dao.AlunoDAO
            dao.Delete(_id)
        Catch ex As Exception
            Throw New Exception("Não é possivel excluir este aluno.")
        End Try

    End Sub
End Class
