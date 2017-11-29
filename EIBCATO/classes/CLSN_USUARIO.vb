Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_USUARIO

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Usuario)
        Try

            Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
            Return dao.CarregarDados().ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterUsuarioEmail(c001_Email As String) As Usuario
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO

        Return dao.PesquisarPorEmail(c001_Email)
    End Function

    Friend Function obterUsuarioId(_id As Integer) As Usuario
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO

        Return dao.PesquisarPorId(_id)
    End Function

    Friend Sub atualizarUsuario(usuario As Usuario)
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
        usuario.UsuarioTentativaErro += 1

        dao.InsertOrUpdate(usuario)
    End Sub

    Friend Sub inserirAtualizarUsuario(usuario As Usuario)
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
        dao.InsertOrUpdate(usuario)
    End Sub

    Friend Sub excluirId(_id As Integer)
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
        dao.Delete(_id)
    End Sub

End Class
