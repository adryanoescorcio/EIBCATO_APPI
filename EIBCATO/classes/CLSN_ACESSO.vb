Imports PIBICAS.Models.Acesso

Public Class CLSN_ACESSO

    Public Function inserirAcessoEntrada(ByRef _dataEntrada As DateTime,
                                  ByRef _idUsuario As Integer)

        Dim modeloAcesso = New PIBICAS.Models.Acesso
        modeloAcesso.AcessoDataEntrada = _dataEntrada
        modeloAcesso.AcessoDataSaida = Nothing
        modeloAcesso.AcessoId = 0
        modeloAcesso.AcessoUsuarioID = _idUsuario

        Dim dao = New PIBICAS.Models.Dao.AcessoDAO
        dao.InsertOrUpdate(modeloAcesso)

        Return True

    End Function

    Friend Sub alterarAcessoSaida(ByRef c001_Id As Integer, ByRef _dataSaida As DateTime)
        Dim dao = New PIBICAS.Models.Dao.AcessoDAO
        Dim acesso = dao.PesquisarPorIdSaida(c001_Id)

        If (acesso Is Nothing) Then
            acesso = New PIBICAS.Models.Acesso
        End If

        acesso.AcessoDataSaida = _dataSaida
        dao.InsertOrUpdate(acesso)

    End Sub
End Class
