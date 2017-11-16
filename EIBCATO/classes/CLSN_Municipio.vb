Public Class CLSN_Municipio

    Private Obj_Seguranca As Cls_Seguranca

    Public Obj_DataTable As DataTable

    Friend Function CarregarMunicipio(ByRef _idUf) As DataTable
        Try
            Dim dao = New PIBICAS.Models.Dao.MunicipioDAO
            Return dao.CarregarMunicipios(_idUf)

        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
