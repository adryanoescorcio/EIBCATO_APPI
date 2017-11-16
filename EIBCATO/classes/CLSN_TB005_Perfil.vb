Public Class CLSN_TB005_PERFIL

    Friend Function F_Get_NomePerfil() As DataTable
        Try
            Dim dao = New PIBICAS.Models.Dao.PerfilDAO
            Return dao.CarregarDados()

        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
