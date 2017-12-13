Public Class ListaAlunoCNC
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

            Dim _Obj As New CLSN_LISTA_ALUNO_CNC()
            Me.GridPesquisa_01.DataSource = _Obj.F_Leitura_Grid(Me.Obj_Seguranca.idClasse)
            Me.GridPesquisa_01.DataBind()

        Catch msg As Exception
            Throw
        End Try
    End Sub

    Private Sub F_Inicializar()
        Me.S_Carrega_DDL_Escolaridade()
        Me.S_Carrega_DDL_Situacao()
    End Sub

    Private Sub ASP_MENU_ITEM_PLANO_AULA_Click(sender As Object, e As EventArgs) Handles ASP_MENU_ITEM_PLANO_AULA.Click
        Me.F_EventoItemMenu("PlanoAula")
    End Sub

    Private Sub ASP_MENU_ITEM_CLASSE_Click(sender As Object, e As EventArgs) Handles ASP_MENU_ITEM_CLASSE.Click
        Me.F_EventoItemMenu("Classe")
    End Sub

    Private Sub F_EventoItemMenu(ByVal _menu_item As String)

        Try
            LBL_Mensagem.Text = ""
            CAMPO_MENSAGEM.Visible = False

            If _menu_item = "PlanoAula" Then
                Me.S_Redireciona("FRMPlanoAula.aspx")
            ElseIf _menu_item = "Classe" Then
                Me.S_Redireciona("FRMClasse.aspx")
            ElseIf _menu_item = "Lista" Then
                Me.S_Redireciona("ListaAlunoCNC.aspx")
            End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
        End Try

        If Me.LBL_Mensagem.Text <> "" Then
            Me.CAMPO_MENSAGEM.Visible = True
        End If

    End Sub

    Private Sub S_Redireciona(ByVal formulario As String)

        Try
            Response.Redirect(formulario, False)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub S_Carrega_DDL_Escolaridade()
        Me.DDL_Escolaridade.Items.Clear()

        Me.DDL_Escolaridade.Items.Add("Ens. Fundamental Incompleto")
        Me.DDL_Escolaridade.Items.Add("Ens. Fundamental")

        Me.DDL_Escolaridade.Items.Add("Ens. Médio Incompleto")
        Me.DDL_Escolaridade.Items.Add("Ens. Médio")

        Me.DDL_Escolaridade.Items.Add("Ens. Superior Incompleto")
        Me.DDL_Escolaridade.Items.Add("Ens. Superior")

        If Me.DDL_Escolaridade.Items.Count > 0 Then
            Me.DDL_Escolaridade.Items.Insert(0, "")
        End If
        Me.DDL_Escolaridade.SelectedIndex() = -1

    End Sub

    Private Sub S_Carrega_DDL_Situacao()
        Me.DDL_SITUACAO.Items.Clear()

        Me.DDL_SITUACAO.Items.Add("Cursando")
        Me.DDL_SITUACAO.Items.Add("Evadido")
        Me.DDL_SITUACAO.Items.Add("Reprovado")

    End Sub

    Private Sub S_Limpa_Tela_TP_Cadastro()
        Me.TXT_Batismo.Text = ""
        Me.TXT_Celula.Text = ""
        Me.TXT_Celular.Text = ""
        Me.TXT_CPF.Text = ""
        Me.TXT_DATA_NASC.Text = ""
        Me.TXT_Dicipulador.Text = ""
        Me.TXT_Equipe.Text = ""
        Me.TXT_NOME.Text = ""
        Me.DDL_Escolaridade.SelectedIndex = -1

        Me.LBL_C001_ID.Text = ""
        Me.LBL_Membresia_ID.Text = ""
        Me.LBL_Mensagem.Text = ""
        Me.CAMPO_MENSAGEM.Visible = False

    End Sub

    Private Sub GridPesquisa_01_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridPesquisa_01.ItemCommand
        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Dim _KeyFieldName As Integer = e.CommandArgument
            Me.S_Limpa_Tela_TP_Cadastro()
            Dim _Obj As New PIBICAS.Models.Aluno
            Me.S_Recupera_ID_Cadastro(_KeyFieldName, _Obj)
            Me.setBancoTela(_Obj)

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
        End Try

        If LBL_Mensagem.Text <> "" Then
            Me.CAMPO_MENSAGEM.Visible = True
        End If
    End Sub

    Private Sub setBancoTela(_obj As PIBICAS.Models.Aluno)

        If Not (_obj.AlunoId = 0) Then
            Me.LBL_C001_ID.Text = _obj.AlunoId
        End If

        If Not (_obj.AlunoBatismo Is Nothing) Then
            Me.TXT_Batismo.Text = _obj.AlunoBatismo
        End If

        If Not (_obj.AlunoCelula = "") Then
            Me.TXT_Celula.Text = _obj.AlunoCelula
        End If

        If Not (_obj.AlunoDataNascimento.ToString = "") Then
            Me.TXT_DATA_NASC.Text = _obj.AlunoDataNascimento
        End If

        If Not (_obj.AlunoCelular1 Is Nothing) Then
            Me.TXT_Celular.Text = _obj.AlunoCelular1
        End If

        If Not (_obj.AlunoCPF Is Nothing) Then
            Me.TXT_CPF.Text = _obj.AlunoCPF
        End If

        If Not (_obj.AlunoDiscipulador Is Nothing) Then
            Me.TXT_Dicipulador.Text = _obj.AlunoDiscipulador
        End If

        If Not (_obj.AlunoEquipe Is Nothing) Then
            Me.TXT_Equipe.Text = _obj.AlunoEquipe
        End If

        If Not (_obj.AlunoNome Is Nothing) Then
            Me.TXT_NOME.Text = _obj.AlunoNome
        End If

        If Not (_obj.AlunoEscolaridade Is Nothing) Then
            Me.DDL_Escolaridade.SelectedValue = _obj.AlunoEscolaridade
        End If

        If Not (_obj.AlunoSituacao Is Nothing) Then
            Me.DDL_SITUACAO.SelectedValue = _obj.AlunoSituacao
        End If

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

    Private Function Salvar_Dados()
        Try
            Dim _obj As PIBICAS.Models.Aluno = New PIBICAS.Models.Aluno
            Dim _negocio As CLSN_LISTA_ALUNO_CNC = New CLSN_LISTA_ALUNO_CNC
            Me.setTelaBanco(_obj)
            _negocio.inserirAtualizarObjeto(_obj)

            If (_obj.AlunoTipoOperacao = "Inclusão") Then
                Dim _obj_Lista As PIBICAS.Models.Lista = New PIBICAS.Models.Lista
                _obj_Lista.ListaAlunoId = _obj.AlunoId
                _obj_Lista.ListaId = 0
                _obj_Lista.ListaClasseId = Me.Obj_Seguranca.idClasse

                Dim _negocio_classe As CLSN_LISTA_ALUNO_CLASSE = New CLSN_LISTA_ALUNO_CLASSE
                _negocio_classe.inserirAtualizarObjeto(_obj_Lista)

            End If

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Private Sub setTelaBanco(obj As PIBICAS.Models.Aluno)

        If Not (Me.TXT_Batismo.Text = "") Then
            obj.AlunoBatismo = CDate(Me.TXT_Batismo.Text).GetDateTimeFormats.GetValue(47).ToString
        Else
            obj.AlunoBatismo = Nothing
        End If

        obj.AlunoCelula = Me.TXT_Celula.Text
        obj.AlunoDataNascimento = CDate(Me.TXT_DATA_NASC.Text).GetDateTimeFormats.GetValue(47)
        obj.AlunoCelular1 = Me.TXT_Celular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
        obj.AlunoCPF = Me.TXT_CPF.Text
        obj.AlunoEquipe = Me.TXT_Equipe.Text
        obj.AlunoEscolaridade = DDL_Escolaridade.SelectedValue
        obj.AlunoNome = Me.TXT_NOME.Text
        obj.AlunoSituacao = Me.DDL_SITUACAO.SelectedValue
        obj.AlunoId = IIf(Val(LBL_C001_ID.Text) = 0, 0, Val(LBL_C001_ID.Text))
        obj.AlunoDiscipulador = Me.TXT_Dicipulador.Text

        obj.AlunoRepetir = "Não"

        obj.AlunoUsuario = Me.Obj_Seguranca._usuario.UsuarioNome
        obj.AlunoRastro = Me.Obj_Seguranca.Rastro
        obj.AlunoTempo = CDate(Now()).GetDateTimeFormats.GetValue(47)
        obj.AlunoTipoOperacao = IIf(LBL_C001_ID.Text = "", "Inclusão", "Alteração")
    End Sub

    Private Function F_Critica_Dados() As Boolean
        If (Me.TXT_NOME.Text Is Nothing) Then
            Throw New Exception("O campo Nome é obrigatório.")
        End If

        If (Me.TXT_DATA_NASC.Text Is Nothing) Then
            Throw New Exception("O campo Data nascimento é obrigatório.")
        End If

        If (Me.TXT_CPF.Text Is Nothing) Then
            Throw New Exception("O campo cpf é obrigatório.")
        End If

        If (Me.Obj_Seguranca.ValidarCPF(Me.TXT_CPF.Text.Substring(0, 9))) Then
            Throw New Exception("O campo CPF é inválido.")
        End If

        If (Me.DDL_SITUACAO.SelectedValue Is Nothing) Then
            Throw New Exception("O campo situacao é obrigatório.")
        End If

        If (Me.TXT_Celular.Text Is Nothing) Then
            Throw New Exception("O campo celular é obrigatório.")
        End If

        Return True
    End Function

    Private Sub S_Tira_Malicia()
        Me.TXT_Batismo.Text = Me.TXT_Batismo.Text.Replace("'", "´")
        Me.TXT_Celula.Text = Me.TXT_Celula.Text.Replace("'", "´")
        Me.TXT_Celular.Text = Me.TXT_Celular.Text.Replace("'", "´")
        Me.TXT_CPF.Text = Me.TXT_CPF.Text.Replace("'", "´")
        Me.TXT_Dicipulador.Text = Me.TXT_Dicipulador.Text.Replace("'", "´")
        Me.TXT_Equipe.Text = Me.TXT_Equipe.Text.Replace("'", "´")
        Me.TXT_NOME.Text = Me.TXT_NOME.Text.Replace("'", "´")
    End Sub


    Private Sub S_Recupera_ID_Cadastro(keyFieldName As Integer, ByRef _obj As PIBICAS.Models.Aluno)
        Try
            Dim negocio As CLSN_LISTA_ALUNO_CNC = New CLSN_LISTA_ALUNO_CNC
            _obj = negocio.obterPorId(keyFieldName)

            If _obj Is Nothing Then
                Throw New Exception("Consulta inválida.")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub BTN_Limpar_Click(sender As Object, e As EventArgs) Handles BTN_Limpar.Click
        Me.S_Limpa_Tela_TP_Cadastro()
    End Sub

    Private Sub BTN_Excluir_Click(sender As Object, e As EventArgs) Handles BTN_Excluir.Click

        Me.CAMPO_MENSAGEM.Visible = False
        Me.LBL_Mensagem.Text = ""

        Try
            If Not (Me.LBL_C001_ID.Text = "") AndAlso Not (Val(Me.LBL_C001_ID.Text) = 0) Then

                Dim _negocio_aluno_classe As CLSN_LISTA_ALUNO_CLASSE = New CLSN_LISTA_ALUNO_CLASSE
                _negocio_aluno_classe.excluirAlunoClasse(LBL_C001_ID.Text, Me.Obj_Seguranca.idClasse)

                Dim _negocio As CLSN_LISTA_ALUNO_CNC = New CLSN_LISTA_ALUNO_CNC
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