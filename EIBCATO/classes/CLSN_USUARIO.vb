Imports System.Data.Entity.Core.Objects
Imports PIBICAS.Models

Public Class CLSN_USUARIO

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function F_Leitura_Grid() As DataTable
        Try

            Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
            Return dao.CarregarDados

        Catch ex As Exception
            Throw
        End Try
    End Function

    Friend Function obterUsuarioEmail(c001_Email As String) As Usuario
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO

        Return dao.PesquisarPorEmail(c001_Email)
    End Function

    Friend Sub atualizarUsuario(usuario As Usuario)
        Dim dao = New PIBICAS.Models.Dao.UsuarioDAO
        usuario.UsuarioTentativaErro += 1

        dao.InsertOrUpdate(usuario)
    End Sub
End Class
