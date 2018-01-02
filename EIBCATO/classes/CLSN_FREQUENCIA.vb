Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_FREQUENCIA

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid(ByVal idClasse As Integer) As List(Of Object)
        Try

            Dim dao = New PIBICAS.Models.Dao.FrequenciaDAO
            Return dao.CarregarDados(idClasse).ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As Frequencia
        Dim dao = New PIBICAS.Models.Dao.FrequenciaDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Function obterPorIdUnique(_id As String) As Frequencia
        Dim dao = New PIBICAS.Models.Dao.FrequenciaDAO

        Return dao.PesquisarPorIdUnique(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As Frequencia)
        Dim dao = New PIBICAS.Models.Dao.FrequenciaDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.FrequenciaDAO
        dao.Delete(_id)
    End Sub

End Class
