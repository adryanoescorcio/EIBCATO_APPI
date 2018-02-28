Imports PIBICAS.Models

Public Class FRMClasse
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If Not IsPostBack Then
            Me.F_Inicializar()

            If Not (Me.Obj_Seguranca.idClasse Is Nothing Or
            Me.Obj_Seguranca.idClasse = 0) Then
                Me.exbirObjetoSelecionado(Me.Obj_Seguranca.idClasse)
            End If

            'Carregar a grid
            Me.S_Carrega_GridPesquisa()
        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

    Private Sub S_Carrega_GridPesquisa()
        Try

            Dim _Obj As New CLSN_CLASSE()

            Me.GridPesquisa_01.DataSource = _Obj.F_Leitura_Grid()
            Me.GridPesquisa_01.DataBind()

        Catch msg As Exception
            Throw
        End Try

    End Sub

    Private Sub F_Inicializar()
        Me.S_Carrega_DDL_Professor()
        Me.S_Carrega_DDL_C001_STATUS()
    End Sub

    Private Sub S_Carrega_DDL_Professor()
        Me.DDL_Membresia_Professor.Items.Clear()

        Dim _negocio As CLSN_MEMBRESIA = New CLSN_MEMBRESIA
        Me.DDL_Membresia_Professor.Items.Add(" ")
        Me.DDL_Membresia_Professor.DataSource = _negocio.listaMembrosAtivos(1)
        Me.DDL_Membresia_Professor.DataValueField = "MembresiaId"
        Me.DDL_Membresia_Professor.DataTextField = "UsuarioNomePerfil"
        Me.DDL_Membresia_Professor.DataBind()

        Me.DDL_Membresia_Professor.SelectedIndex() = -1

        If Me.DDL_Membresia_Professor.Items.Count > 0 Then
            Me.DDL_Membresia_Professor.Items.Insert(0, "")
        End If

    End Sub

    Private Sub S_Carrega_DDL_C001_STATUS()

        Me.DDL_Status.Items.Clear()

        Me.DDL_Status.SelectedIndex() = -1
        Me.DDL_Status.Items.Add("Ativo")
        Me.DDL_Status.Items.Add("Encerrado")

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
            Me.CAMPO_MENSAGEM.Attributes.Add("class", "alert alert-success alert-icon alert-dismissible")
            Me.CAMPO_MENSAGEM.Visible = True

        Catch ex As Exception
            Me.CAMPO_MENSAGEM.Visible = True
            Me.CAMPO_MENSAGEM.Attributes.Add("class", "alert alert-danger alert-icon alert-dismissible")
            Me.LBL_Mensagem.Text = ex.Message
        End Try

    End Sub

    Private Function Salvar_Dados()
        Try
            Dim _obj As PIBICAS.Models.Classe = New PIBICAS.Models.Classe
            Dim _negocio As CLSN_CLASSE = New CLSN_CLASSE

            Me.setTelaBanco(_obj)

            If (Me.DDL_Status.SelectedValue = "Encerrado") Then
                Dim _alunos As CLSN_LISTA_ALUNO_CNC = New CLSN_LISTA_ALUNO_CNC
                Dim list As List(Of Object) = _alunos.F_Leitura_Grid(Me.LBL_C001_ID.Text)

                If (list.Count > 0) Then
                    If (list.FindAll(Function(x) x.AlunoSituacao = "Cursando").Count > 0) Then
                        Throw New Exception("Defina a situação dos alunos que ainda estão 'Cursando'.")
                    End If
                Else
                    Throw New Exception("Você não pode encerra uma turma sem alunos.")
                End If
            End If

            _negocio.inserirAtualizarObjeto(_obj)

            If Not (Me.LBL_C001_ID.Text = "") Then

            End If

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Private Sub setTelaBanco(obj As Classe)
        obj.ClasseCargaHoraria = Me.TXT_Carga.Text
        obj.ClasseDataFim = CDate(Me.TXT_PERIODO_FIM.Text).GetDateTimeFormats.GetValue(47)
        obj.ClasseDataInicio = CDate(Me.TXT_PERIODO_INICIO.Text).GetDateTimeFormats.GetValue(47)
        obj.ClasseCodigo = Me.TXT_Codigo.Text
        obj.ClasseObservacao = Me.TXT_Observacao.Text

        obj.ClasseId = IIf(Val(LBL_C001_ID.Text) = 0, 0, Val(LBL_C001_ID.Text))

        obj.ClasseMembresiaId = Me.DDL_Membresia_Professor.SelectedItem.Value
        obj.ClasseStatus = Me.DDL_Status.SelectedValue

        obj.ClasseUsuario = Me.Obj_Seguranca._usuario.UsuarioNome
        obj.ClasseRastro = Me.Obj_Seguranca.Rastro
        obj.ClasseTempo = CDate(Now()).GetDateTimeFormats.GetValue(47)
        obj.ClasseTipoOperacao = IIf(LBL_C001_ID.Text = "", "Inclusão", "Alteração")
    End Sub

    Private Function F_Critica_Dados() As Boolean
        If (Me.TXT_Carga.Text Is Nothing) Then
            Throw New Exception("O campo Carga Horária é obrigatório.")
        End If

        If (Me.TXT_Codigo.Text Is Nothing) Then
            Throw New Exception("O campo Código é obrigatório.")
        End If

        If (Me.TXT_PERIODO_FIM.Text Is Nothing) Then
            Throw New Exception("O campo Data Término é obrigatório.")
        End If

        If (Me.TXT_PERIODO_INICIO.Text Is Nothing) Then
            Throw New Exception("O campo Data Início é obrigatório.")
        End If

        If Not (Me.TXT_PERIODO_INICIO.Text Is Nothing) And Not (Me.TXT_PERIODO_FIM.Text Is Nothing) Then
            If (CDate(Me.TXT_PERIODO_INICIO.Text) > CDate(Me.TXT_PERIODO_FIM.Text)) Then
                Throw New Exception("Verifique se as datas estão corretas.")
            End If
        End If

        If (Me.DDL_Membresia_Professor.Text Is Nothing) Then
            Throw New Exception("O campo Professor é obrigatório.")
        End If

        If (Me.DDL_Status.Text Is Nothing) Then
            Throw New Exception("O campo Situação é obrigatório.")
        End If

        Return True

    End Function

    Private Sub S_Tira_Malicia()
        Me.TXT_Carga.Text = Me.TXT_Carga.Text.Replace("'", "´")
        Me.TXT_Codigo.Text = Me.TXT_Codigo.Text.Replace("'", "´")
        Me.TXT_Observacao.Text = Me.TXT_Observacao.Text.Replace("'", "´")
        Me.TXT_PERIODO_FIM.Text = Me.TXT_PERIODO_FIM.Text.Replace("'", "´")
        Me.TXT_PERIODO_INICIO.Text = Me.TXT_PERIODO_INICIO.Text.Replace("'", "´")
    End Sub

    Private Sub GridPesquisa_01_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridPesquisa_01.ItemCommand
        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Dim _KeyFieldName As Integer = e.CommandArgument
            Me.exbirObjetoSelecionado(_KeyFieldName)

            If (Me.DDL_Status.SelectedValue = "Encerrado") Then
                Me.Obj_Seguranca.StatusClasse = "Encerrado"
                Me.bloquearTudo()
            Else
                Me.Obj_Seguranca.StatusClasse = "Ativo"
            End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
        End Try

        If LBL_Mensagem.Text <> "" Then
            Me.CAMPO_MENSAGEM.Visible = True
        End If
    End Sub

    Private Sub bloquearTudo()
        Me.BTN_Gravar.Visible = False
        Me.BTN_Excluir.Visible = False
        Me.CAMPO_MENSAGEM.Visible = True
        Me.LBL_Mensagem.Text = "Não é possivel alterar os dados abaixo."
    End Sub

    Private Sub exbirObjetoSelecionado(_keyFieldName As Integer)
        Me.S_Limpa_Tela_TP_Cadastro()
        Dim _Obj As New PIBICAS.Models.Classe
        Me.S_Recupera_ID_Cadastro(_keyFieldName, _Obj)
        Me.setBancoTela(_Obj)
    End Sub

    Private Sub setBancoTela(_obj As PIBICAS.Models.Classe)

        If Not (_obj.ClasseId = 0) Then
            Me.LBL_C001_ID.Text = _obj.ClasseId
            Me.Obj_Seguranca.idClasse = _obj.ClasseId
        End If

        If Not (_obj.ClasseCargaHoraria Is Nothing) Then
            Me.TXT_Carga.Text = _obj.ClasseCargaHoraria
        End If

        If Not (_obj.ClasseCodigo Is Nothing) Then
            Me.TXT_Codigo.Text = _obj.ClasseCodigo
        End If

        If Not (_obj.ClasseDataFim.ToString = "") Then
            Me.TXT_PERIODO_FIM.Text = _obj.ClasseDataFim
        End If

        If Not (_obj.ClasseDataInicio.ToString = "") Then
            Me.TXT_PERIODO_INICIO.Text = _obj.ClasseDataInicio
        End If

        If Not (_obj.ClasseObservacao Is Nothing) Then
            Me.TXT_Observacao.Text = _obj.ClasseObservacao
        End If

        If Not (_obj.ClasseStatus Is Nothing) Then
            Me.DDL_Status.SelectedValue = _obj.ClasseStatus
        End If

        If Not (_obj.ClasseMembresiaId = 0) Then
            Me.DDL_Membresia_Professor.SelectedValue = _obj.ClasseMembresiaId
        End If

    End Sub

    Private Sub S_Recupera_ID_Cadastro(keyFieldName As Integer, ByRef _obj As Classe)
        Try
            Dim negocio As CLSN_CLASSE = New CLSN_CLASSE
            _obj = negocio.obterPorId(keyFieldName)

            If _obj Is Nothing Then
                Throw New Exception("Consulta inválida.")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub S_Limpa_Tela_TP_Cadastro()
        Me.TXT_Carga.Text = ""
        Me.TXT_Codigo.Text = ""
        Me.TXT_Observacao.Text = ""
        Me.TXT_PERIODO_FIM.Text = ""
        Me.TXT_PERIODO_INICIO.Text = ""
        Me.LBL_C001_ID.Text = ""

        Me.DDL_Status.SelectedIndex = -1
        Me.DDL_Membresia_Professor.SelectedIndex = -1

        Me.BTN_Excluir.Visible = True
        Me.BTN_Gravar.Visible = True

        Me.LBL_Mensagem.Text = ""
        Me.CAMPO_MENSAGEM.Visible = False

    End Sub

    Private Sub BTN_Limpar_Click(sender As Object, e As EventArgs) Handles BTN_Limpar.Click
        Me.S_Limpa_Tela_TP_Cadastro()
    End Sub

    Private Sub BTN_Excluir_Click(sender As Object, e As EventArgs) Handles BTN_Excluir.Click
        Try
            If Not (Me.LBL_C001_ID.Text = "") AndAlso Not (Val(Me.LBL_C001_ID.Text) = 0) Then
                Dim _negocio As CLSN_CLASSE = New CLSN_CLASSE
                _negocio.excluirId(LBL_C001_ID.Text)

                Me.S_Limpa_Tela_TP_Cadastro()
                Me.Obj_Seguranca.idClasse = 0
                Me.S_Carrega_GridPesquisa()

            Else
                Throw New Exception("Selecione um registro")
            End If

            Me.LBL_Mensagem.Text = "Operação realizada com sucesso"
            Me.CAMPO_MENSAGEM.Attributes.Add("class", "alert alert-success alert-icon alert-dismissible")
            Me.CAMPO_MENSAGEM.Visible = True

        Catch ex As Exception
            Me.CAMPO_MENSAGEM.Visible = True
            Me.CAMPO_MENSAGEM.Attributes.Add("class", "alert alert-danger alert-icon alert-dismissible")
            Me.LBL_Mensagem.Text = ex.Message
        End Try
    End Sub

    Private Sub ASP_MENU_ITEM_PLANO_AULA_Click(sender As Object, e As EventArgs) Handles ASP_MENU_ITEM_PLANO_AULA.Click
        Me.F_EventoItemMenu("PlanoAula")
    End Sub

    Private Sub ASP_MENU_ITEM_FREQUENCIA_Click(sender As Object, e As EventArgs) Handles ASP_MENU_FREQUENCIA.Click
        Me.F_EventoItemMenu("Frequencia")
    End Sub

    Private Sub ASP_MENU_ITEM_ALUNOS_Click(sender As Object, e As EventArgs) Handles ASP_MENU_ITEM_ALUNOS.Click
        Me.F_EventoItemMenu("Lista")
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
            ElseIf _menu_item = "Frequencia" Then
                Me.S_Redireciona("FRMFrequencia.aspx")
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
            If Not (LBL_C001_ID.Text = "" Or LBL_C001_ID.Text Is Nothing) Then
                Response.Redirect(formulario, False)
            ElseIf (formulario = "FRMClasse.aspx") Then
                Response.Redirect(formulario, False)
            Else
                Throw New Exception("Selecione uma classe.")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class