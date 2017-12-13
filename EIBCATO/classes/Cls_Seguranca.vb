Imports PIBICAS.Models

Public Class Cls_Seguranca

    Public Tempo As Date
    Public TipoOperacao As String
    Public Rastro As String
    Public C005_Id As Integer

    Public F_Parametro As String

    ' Variáveis de sessão para upload de arquivos
    Public AFUp_Documento_Ext As String
    Public AFUp_Documento_Bit As Object
    Public AFUp_Documento_Nome As String

    Public MensagemGeral As String

    Public C010_PrincipalNome As String

    'Public ObjL_Paramentro As List(Of CLST_ParametrosRelatorio)

    'Public ObjL_UsuarioSetor As List(Of CLST_UsuarioSetor)

    Public Relatorio As String
    Public Sql As String
    Public Obj_DataTable As DataTable
    Public idIgreja As Nullable(Of Integer)
    Public idClasse As Nullable(Of Integer)
    'Public C004_ID As Nullable(Of Integer)
    Public _usuario As Usuario

    Public Shared Function F_Mascara_CPF(ByVal pm_CPF As String) As String

        Try
            Dim _CPF As String = Right("00000000000" + pm_CPF, 11)

            Return _CPF.Substring(0, 3) & "." & _CPF.Substring(3, 3) & "." & _CPF.Substring(6, 3) & "-" & _CPF.Substring(9, 2)

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function F_Registra_Entrada_Usuario() As Boolean

        Try
            Dim _negocioAcesso As CLSN_ACESSO = New CLSN_ACESSO()

            _negocioAcesso.inserirAcessoEntrada(CDate(Now()).GetDateTimeFormats.GetValue(47), Me._usuario.UsuarioId)

            Return True

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function F_Registra_Saida_Usuario() As Boolean

        Try
            ' Dim _negocioAcesso As CLSN_ACESSO = New CLSN_ACESSO()
            '_negocioAcesso.alterarAcessoSaida(Me._usuario.UsuarioId, CDate(Now()).GetDateTimeFormats.GetValue(47))

            Return True

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function F_Recupera_Usuario(ByVal pm_C001_Email As String) As Boolean

        Try

            Dim _negocioUsuario As CLSN_USUARIO = New CLSN_USUARIO()
            Me._usuario = _negocioUsuario.obterUsuarioEmail(pm_C001_Email)

            Return True

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Sub atualizarSenhaUsuario(ByVal pm_C001_Senha As String)

        Try

            Dim _negocioUsuario As CLSN_USUARIO = New CLSN_USUARIO()
            Me._usuario.UsuarioSenha = pm_C001_Senha

            _negocioUsuario.atualizarUsuario(Me._usuario)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function F_CriptografarMD5(ByVal wp_chave As String) As String
        Try
            '' Cria uma nova intância do objeto que implementa o algoritmo para criptografia MD5

            Dim md5Hasher As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()

            '' Criptografa a chave passada

            Dim _chaveCriptografado As Byte() = md5Hasher.ComputeHash(Text.Encoding.Default.GetBytes(wp_chave))

            '' Cria um StringBuilder para passarmos os bytes gerados para ele

            Dim strBuilder As New Text.StringBuilder()

            '' Converte cada byte em um valor hexadecimal e adiciona ao string builder e formata cada um como um hexadecimal string.

            For i As Integer = 0 To _chaveCriptografado.Length - 1 Step 1
                strBuilder.Append(_chaveCriptografado(i).ToString("x2").ToUpper)
            Next

            '' retorna a chave criptografado como string

            Return strBuilder.ToString()

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function F_CPF_Valido(ByVal wNumeroCPF As String) As Boolean

        Dim _CPF As String
        Dim _Valor As Integer
        Dim _I As Integer
        Dim _Tam As Integer
        Dim _Resto As Integer
        Dim _Divisao As Double
        Dim _Digito_1 As Integer
        Dim _Digito_2 As Integer
        Dim _Digito As String


        _CPF = wNumeroCPF
        _CPF = _CPF.Replace(".", "")
        _CPF = _CPF.Replace(",", "")
        _CPF = _CPF.Replace("/", "")
        _CPF = _CPF.Replace("-", "")
        _CPF = _CPF.Replace(" ", "")

        wNumeroCPF = _CPF

        _CPF = Left(wNumeroCPF, 9)
        _Tam = wNumeroCPF.Length
        If _Tam < 9 Then
            _Tam = 9 - _Tam
            While _Tam <> 0
                _CPF = "0" & _CPF
                _Tam = _Tam - 1
            End While
        End If

        _Tam = 10
        _I = 0
        _Valor = 0

        While _I < 9
            _Valor = _Valor + _CPF.Substring(_I, 1) * _Tam
            _I = _I + 1
            _Tam = _Tam - 1
        End While

        _Divisao = _Valor / 11
        _Resto = _Valor - (Int(_Divisao) * 11)

        If _Resto < 2 Then
            _Digito_1 = 0
        Else
            _Digito_1 = 11 - _Resto
        End If

        _CPF = _CPF & _Digito_1

        _Tam = 11
        _I = 0
        _Valor = 0

        While _I < 10
            _Valor = _Valor + _CPF.Substring(_I, 1) * _Tam
            _I = _I + 1
            _Tam = _Tam - 1
        End While

        _Divisao = _Valor / 11
        _Resto = _Valor - (Int(_Divisao) * 11)

        If _Resto < 2 Then
            _Digito_2 = 0
        Else
            _Digito_2 = 11 - _Resto
        End If

        _Digito = _Digito_1 & _Digito_2
        If _Digito <> Right(wNumeroCPF, 2) Then
            Return False
        Else
            Return True
        End If

    End Function

    Friend Function ValidarCPF(_cpf As String) As Boolean
        Return F_CPF_Valido(_cpf)
    End Function
End Class
