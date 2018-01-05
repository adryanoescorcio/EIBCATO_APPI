Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_PLANO_AULA

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid(ByVal idClasse As Integer) As List(Of PIBICAS.Models.Plano)
        Try
            Dim dao = New PIBICAS.Models.Dao.PlanoDAO
            Return dao.CarregarDados(idClasse).ToList
        Catch ex As Exception
            Throw
        End Try
    End Function


    Friend Function F_Leitura_Grid_Emumerable(ByVal idClasse As Integer) As IEnumerable(Of Object)
        Try
            Dim dao = New PIBICAS.Models.Dao.PlanoDAO
            Return dao.CarregarDadosDataSet(idClasse)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As Plano
        Dim dao = New PIBICAS.Models.Dao.PlanoDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As Plano)
        Dim dao = New PIBICAS.Models.Dao.PlanoDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.PlanoDAO
        dao.Delete(_id)
    End Sub

End Class
