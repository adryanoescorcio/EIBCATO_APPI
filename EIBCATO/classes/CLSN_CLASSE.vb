Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_CLASSE

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Classe)
        Try

            Dim dao = New PIBICAS.Models.Dao.ClasseDAO
            Return dao.CarregarDados().ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterPorId(_id As Integer) As Classe
        Dim dao = New PIBICAS.Models.Dao.ClasseDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub inserirAtualizarObjeto(obj As Classe)
        Dim dao = New PIBICAS.Models.Dao.ClasseDAO
        dao.InsertOrUpdate(obj)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.ClasseDAO
        dao.Delete(_id)
    End Sub

End Class
