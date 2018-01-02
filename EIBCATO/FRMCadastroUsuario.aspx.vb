Imports PIBICAS.Models

Public Class FRMCadastroUsuario
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If Not IsPostBack Then

            Me.F_Inicializar()

            'Carregar a grid
            Me.S_Carrega_GridPesquisa()
        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

    Private Sub S_Carrega_GridPesquisa()
        Try

            Dim _Obj_TB001_USUARIO As New CLSN_USUARIO()

            Me.GridPesquisa_01.DataSource = _Obj_TB001_USUARIO.F_Leitura_Grid()
            Me.GridPesquisa_01.DataBind()

        Catch msg As Exception
            Throw
        End Try

    End Sub

    Private Sub F_Inicializar()
        Me.S_Carrega_DDL_C001_STATUS()
        Me.S_Carrega_DDL_C001_Sexo()
        Me.S_Carrega_DDL_C001_TrocarSenha()
    End Sub

    Private Sub S_Carrega_DDL_C001_Sexo()
        Me.DDL_C001_Sexo.Items.Clear()
        Me.DDL_C001_Sexo.SelectedIndex() = -1
        Me.DDL_C001_Sexo.Items.Add("Masculino")
        Me.DDL_C001_Sexo.Items.Add("Feminino")
    End Sub

    Private Sub S_Carrega_DDL_C001_TrocarSenha()
        Me.DDL_C001_TrocarSenha.Items.Clear()

        Me.DDL_C001_TrocarSenha.SelectedIndex() = -1
        Me.DDL_C001_TrocarSenha.Items.Add("Não")
        Me.DDL_C001_TrocarSenha.Items.Add("Sim")
    End Sub

    Private Sub S_Carrega_DDL_Igreja()
        Me.DDL_C003_Igreja.Items.Clear()

        Dim _negocio As CLSN_Igreja = New CLSN_Igreja
        Me.DDL_C003_Igreja.DataSource = _negocio.F_Leitura_Grid()
        Me.DDL_C003_Igreja.DataTextField = "IgrejaNome"
        Me.DDL_C003_Igreja.DataValueField = "IgrejaId"
        Me.DDL_C003_Igreja.DataBind()

        Me.DDL_C003_Igreja.SelectedIndex() = -1

        If Me.DDL_C003_Igreja.Items.Count > 0 Then
            Me.DDL_C003_Igreja.Items.Insert(0, "")
        End If

    End Sub

    Private Sub S_Carrega_DDL_Perfil()
        Me.DDL_C005_Perfil.Items.Clear()

        Dim _negocio As CLSN_TB005_PERFIL = New CLSN_TB005_PERFIL
        Me.DDL_C005_Perfil.Items.Add(" ")
        Me.DDL_C005_Perfil.DataSource = _negocio.F_Leitura_Grid()
        Me.DDL_C005_Perfil.DataTextField = "PerfilNome"
        Me.DDL_C005_Perfil.DataValueField = "PerfilId"
        Me.DDL_C005_Perfil.DataBind()

        Me.DDL_C005_Perfil.SelectedIndex() = -1

        If Me.DDL_C005_Perfil.Items.Count > 0 Then
            Me.DDL_C005_Perfil.Items.Insert(0, "")
        End If

    End Sub

    Private Sub S_Carrega_DDL_C001_STATUS()

        Me.DDL_C001_Status.Items.Clear()

        Me.DDL_C001_Status.SelectedIndex() = -1
        Me.DDL_C001_Status.Items.Add("Ativo")
        Me.DDL_C001_Status.Items.Add("Inativo")

    End Sub

    Private Sub GridPesquisa_01_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridPesquisa_01.ItemCommand
        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Dim _KeyFieldName As Integer = e.CommandArgument
            Me.S_Limpa_Tela_TP_Cadastro()
            Dim _Obj As New PIBICAS.Models.Usuario
            Me.S_Recupera_ID_Cadastro(_KeyFieldName, _Obj)
            Me.setBancoTela(_Obj)
            Me.setMembresia()
            Me.setBancoTelaMembresia(_Obj)

            'If Not (IsNothing(Me.LBL_C003_ID.Text) Or Me.LBL_C003_ID.Text = "") Then
            '    'Me.S_Carrega_GridPesquisa_Efetivo()
            'End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
        End Try

        If LBL_Mensagem.Text <> "" Then
            Me.CAMPO_MENSAGEM.Visible = True
        End If
    End Sub

    Private Sub setBancoTelaMembresia(obj As Usuario)
        Dim _negocio As CLSN_MEMBRESIA = New CLSN_MEMBRESIA()
        Dim _mem As Membresia = _negocio.pesquisarUsuarioId(Me.LBL_C001_ID.Text)

        If Not (_mem Is Nothing) Then
            Me.TXT_Matricula.Text = _mem.MembresiaMatricula
            Me.LBL_Membresia_ID.Text = _mem.MembresiaId
            Me.DDL_C003_Igreja.SelectedValue = _mem.MembresiaIgrejaID
            Me.DDL_C005_Perfil.SelectedValue = _mem.MembresiaPerfilID
        End If

    End Sub

    Private Sub setMembresia()
        If Not (Val(Me.LBL_C001_ID.Text) = 0) Then
            Me.CAMPO_MEMBRESIA.Visible = True
            Me.TXT_Matricula.Text = Me.TXT_C001_Cpf.Text

            Me.S_Carrega_DDL_Igreja()
            Me.S_Carrega_DDL_Perfil()

        Else
            Me.CAMPO_MEMBRESIA.Visible = False
        End If
    End Sub

    Private Sub setBancoTela(_obj As PIBICAS.Models.Usuario)

        If Not (_obj.UsuarioId = 0) Then
            Me.LBL_C001_ID.Text = _obj.UsuarioId
        End If

        If Not (_obj.UsuarioNome Is Nothing) Then
            Me.TXT_C001_Nome.Text = _obj.UsuarioNome
        End If

        If Not (_obj.UsuarioCPF Is Nothing) Then
            Me.TXT_C001_Cpf.Text = _obj.UsuarioCPF
        End If

        If Not (_obj.UsuarioNome Is Nothing) Then
            Me.TXT_C001_SobreNome.Text = _obj.UsuarioSobrenome
        End If

        If Not (_obj.UsuarioDetalhes Is Nothing) Then
            Me.TXT_C001_Detalhe.Text = _obj.UsuarioDetalhes
        End If

        If Not (_obj.UsuarioEmail Is Nothing) Then
            Me.TXT_C001_Email.Text = _obj.UsuarioEmail
        End If

        If Not (_obj.UsuarioSexo Is Nothing) Then
            Me.DDL_C001_Sexo.SelectedValue = IIf(_obj.UsuarioSexo = "M", "Masculino", "Feminino")
        End If

        If Not (_obj.UsuarioTrocarSenha Is Nothing) Then
            Me.DDL_C001_TrocarSenha.SelectedValue = _obj.UsuarioTrocarSenha
        End If

        If Not (_obj.UsuarioStatus Is Nothing) Then
            Me.DDL_C001_Status.SelectedValue = _obj.UsuarioStatus
        End If

        Me.TXT_C001_Tentativa.Text = _obj.UsuarioTentativaErro

    End Sub

    Private Sub S_Recupera_ID_Cadastro(keyFieldName As Integer, ByRef _obj As PIBICAS.Models.Usuario)
        Try
            Dim negocio As CLSN_USUARIO = New CLSN_USUARIO
            _obj = negocio.obterUsuarioId(keyFieldName)

            If _obj Is Nothing Then
                Throw New Exception("Consulta inválida.")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub S_Limpa_Tela_TP_Cadastro()
        Me.LBL_C001_ID.Text = Nothing
        Me.LBL_C001_ID.Text = Nothing
        Me.TXT_C001_Nome.Text = ""
        Me.TXT_C001_Cpf.Text = ""
        Me.TXT_C001_SobreNome.Text = ""
        Me.TXT_C001_Detalhe.Text = ""
        Me.TXT_C001_Email.Text = ""
        Me.DDL_C001_Sexo.SelectedIndex = -1
        Me.DDL_C001_TrocarSenha.SelectedIndex = -1
        Me.DDL_C001_Status.SelectedIndex = -1

        Me.TXT_C001_Tentativa.Text = Nothing

        'membresia
        Me.CAMPO_MEMBRESIA.Visible = False
        Me.DDL_C003_Igreja.SelectedIndex = -1
        Me.DDL_C005_Perfil.SelectedIndex = -1
        Me.TXT_Matricula.Text = ""
    End Sub

    Private Sub BTN_Gravar_Click(sender As Object, e As EventArgs) Handles BTN_Gravar.Click
        Try

            Me.CAMPO_MENSAGEM.Visible = False
            Me.LBL_Mensagem.Text = ""

            Me.S_Tira_Malicia()

            If Not Me.F_Critica_Dados() Then
                Me.CAMPO_MENSAGEM.Visible = True
                Exit Sub
            End If

            Me.Salvar_Dados()

            If (Me.CAMPO_MEMBRESIA.Visible) Then
                Me.Salvar_Dados_membresia()
            End If

            S_Carrega_GridPesquisa()

            If Not (Me.LBL_C001_ID.Text = "" Or Me.LBL_C001_ID.Text = Nothing) Then
                Me.S_Limpa_Tela_TP_Cadastro()
            End If

            Me.LBL_Mensagem.Text = "Operação realizada com sucesso"
            Me.CAMPO_MENSAGEM.Visible = True

        Catch ex As Exception
            Me.CAMPO_MENSAGEM.Visible = True
            Me.LBL_Mensagem.Text = ex.Message
        End Try

    End Sub

    Private Function Salvar_Dados_membresia() As Boolean
        Try
            Dim _obj As PIBICAS.Models.Membresia = New PIBICAS.Models.Membresia
            Dim _negocio As CLSN_MEMBRESIA = New CLSN_MEMBRESIA
            Me.setTelaBancoMembresia(_obj)
            _negocio.inserirAtualizarObjeto(_obj)
        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Private Function Salvar_Dados() As Boolean

        Try
            Dim _obj As PIBICAS.Models.Usuario = New PIBICAS.Models.Usuario
            Dim _negocio As CLSN_USUARIO = New CLSN_USUARIO
            Me.setTelaBanco(_obj)
            _negocio.inserirAtualizarUsuario(_obj)

        Catch ex As Exception
            Throw
        End Try

        Return True

    End Function

    Private Sub setTelaBanco(ByRef obj As Usuario)
        obj.UsuarioCPF = Me.TXT_C001_Cpf.Text
        obj.UsuarioDataValidade = CDate("09/09/9999").GetDateTimeFormats.GetValue(47)
        obj.UsuarioDetalhes = Me.TXT_C001_Detalhe.Text
        obj.UsuarioEmail = Me.TXT_C001_Email.Text
        obj.UsuarioNome = Me.TXT_C001_Nome.Text

        If Not (TXT_C001_Senha.Text = "" Or TXT_C001_Senha.Text = Nothing) Then
            obj.UsuarioSenha = Me.Obj_Seguranca.F_CriptografarMD5(Me.TXT_C001_Email.Text & Me.TXT_C001_Senha.Text)
        Else
            Dim temp As Usuario = New Usuario()
            Me.S_Recupera_ID_Cadastro(Me.LBL_C001_ID.Text, temp)
            obj.UsuarioSenha = temp.UsuarioSenha
        End If

        obj.UsuarioSobrenome = Me.TXT_C001_SobreNome.Text
        obj.UsuarioTentativaErro = Me.TXT_C001_Tentativa.Text
        obj.UsuarioId = IIf(Val(LBL_C001_ID.Text) = 0, 0, Val(LBL_C001_ID.Text))
        obj.UsuarioStatus = DDL_C001_Status.SelectedValue
        obj.UsuarioTrocarSenha = DDL_C001_TrocarSenha.SelectedValue
        obj.UsuarioSexo = IIf(DDL_C001_Sexo.SelectedValue = "Masculino", "M", "F")

        obj.UsuarioUsuario = Me.Obj_Seguranca._usuario.UsuarioNome
        obj.UsuarioRastro = Me.Obj_Seguranca.Rastro
        obj.UsuarioTempo = CDate(Now()).GetDateTimeFormats.GetValue(47)
        obj.UsuarioTipoOperacao = IIf(LBL_C001_ID.Text = "", "Inclusão", "Alteração")
    End Sub

    Private Sub setTelaBancoMembresia(ByRef obj As Membresia)

        obj.MembresiaId = IIf(Me.LBL_Membresia_ID.Text = "" Or Me.LBL_Membresia_ID.Text Is Nothing, 0, Me.LBL_Membresia_ID.Text)

        If Not (Me.DDL_C003_Igreja.SelectedValue = "") Then
            obj.MembresiaIgrejaID = Me.DDL_C003_Igreja.SelectedItem.Value
        Else
            Throw New Exception("O campo Igreja é obrigatório.")
        End If

        If Not (Me.DDL_C005_Perfil.SelectedValue = "") Then
            obj.MembresiaPerfilID = Me.DDL_C005_Perfil.SelectedItem.Value
        Else
            Throw New Exception("O campo Perfil é obrigatório.")
        End If

        obj.MembresiaMatricula = Me.TXT_Matricula.Text
        obj.MembresiaStatus = "Ativo"
        obj.MembresiaUsuarioId = Me.Obj_Seguranca._usuario.UsuarioId

    End Sub

    Private Sub S_Tira_Malicia()
        Me.TXT_C001_Cpf.Text = Me.TXT_C001_Cpf.Text.Replace("'", "´")
        Me.TXT_C001_Date.Text = Me.TXT_C001_Date.Text.Replace("'", "´")
        Me.TXT_C001_Detalhe.Text = Me.TXT_C001_Detalhe.Text.Replace("'", "´")
        Me.TXT_C001_Email.Text = Me.TXT_C001_Email.Text.Replace("'", "´")
        Me.TXT_C001_Nome.Text = Me.TXT_C001_Nome.Text.Replace("'", "´")
        Me.TXT_C001_Senha.Text = Me.TXT_C001_Senha.Text.Replace("'", "´")
        Me.TXT_C001_Senha_Repetir.Text = Me.TXT_C001_Senha_Repetir.Text.Replace("'", "´")
        Me.TXT_C001_SobreNome.Text = Me.TXT_C001_SobreNome.Text.Replace("'", "´")
        Me.TXT_C001_Tentativa.Text = Me.TXT_C001_Tentativa.Text.Replace("'", "´")
    End Sub

    Private Function F_Critica_Dados() As Boolean
        If (Me.TXT_C001_Cpf.Text Is Nothing) Then
            Throw New Exception("O campo CPF é obrigatório.")
        End If

        If (Me.Obj_Seguranca.ValidarCPF(Me.TXT_C001_Cpf.Text.Substring(0, 9))) Then
            Throw New Exception("O campo CPF é inválido.")
        End If

        If (Me.TXT_C001_Nome.Text Is Nothing) Then
            Throw New Exception("O campo Nome é obrigatório.")
        End If

        If (Me.TXT_C001_SobreNome.Text Is Nothing) Then
            Throw New Exception("O campo SobreNome é obrigatório.")
        End If

        If Not (Me.TXT_C001_Senha.Text Is Nothing) Then
            If (Me.TXT_C001_Senha_Repetir.Text Is Nothing) Then
                Throw New Exception("O campo Repetir Senha é obrigatório.")
            End If
        End If

        If Not (Me.TXT_C001_Senha_Repetir.Text Is Nothing) Then
            If (Me.TXT_C001_Senha.Text Is Nothing) Then
                Throw New Exception("O campo Senha é obrigatório.")
            End If
        End If

        If Not (Me.TXT_C001_Senha.Text Is Nothing) Then
            If Not (Me.TXT_C001_Senha_Repetir.Text Is Nothing) Then
                If Not (Me.TXT_C001_Senha.Text = Me.TXT_C001_Senha_Repetir.Text) Then
                    Throw New Exception("Os campos de Senha não são iguais.")
                End If
            End If
        End If

        If (Me.TXT_C001_Tentativa.Text Is Nothing) Then
            Throw New Exception("O campo Tentativa é obrigatório.")
        End If

        Return True

    End Function

    Private Sub BTN_Limpar_Click(sender As Object, e As EventArgs) Handles BTN_Limpar.Click
        Me.S_Limpa_Tela_TP_Cadastro()
    End Sub

    Private Sub BTN_Excluir_Click(sender As Object, e As EventArgs) Handles BTN_Excluir.Click
        Try
            If Not (Me.LBL_C001_ID.Text = "") AndAlso Not (Val(Me.LBL_C001_ID.Text) = 0) Then
                Dim _negocio As CLSN_USUARIO = New CLSN_USUARIO
                _negocio.excluirId(LBL_C001_ID.Text)

                Me.S_Limpa_Tela_TP_Cadastro()
                Me.S_Carrega_GridPesquisa()
            Else
                Throw New Exception("Selecione um registro")
            End If

        Catch ex As Exception
            Me.CAMPO_MENSAGEM.Visible = True
            Me.LBL_Mensagem.Text = ex.Message
        End Try
    End Sub
End Class