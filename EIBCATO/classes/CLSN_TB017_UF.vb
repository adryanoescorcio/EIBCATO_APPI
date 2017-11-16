Public Class CLSN_TB017_UF

    Friend Function CarregarUf() As DataTable
        Try
            Dim dao = New PIBICAS.Models.Dao.PerfilDAO
            Return dao.CarregarDados()

        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
