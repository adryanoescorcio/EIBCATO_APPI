Public Class CLSN_TB005_PERFIL

    Friend Function F_Leitura_Grid() As List(Of PIBICAS.Models.Perfil)
        Try
            Dim dao = New PIBICAS.Models.Dao.PerfilDAO

            Return dao.CarregarDados().ToList

        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
