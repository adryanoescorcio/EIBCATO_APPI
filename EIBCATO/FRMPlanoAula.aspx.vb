Imports PIBICAS.Models

Public Class FRMPlanoAula
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If (Me.Obj_Seguranca.StatusClasse = "Encerrado") Then
            Me.bloquearTudo()
        End If

        If Not IsPostBack Then

            Me.F_Inicializar()

            'Carregar a grid
            Me.S_Carrega_GridPesquisa()
        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

    Private Sub bloquearTudo()
        Me.BTN_Gravar.Visible = False
        Me.BTN_Excluir.Visible = False
        Me.CAMPO_MENSAGEM.Visible = True
        Me.LBL_Mensagem.Text = "Não é possivel alterar os dados abaixo."
    End Sub

    Private Sub S_Carrega_GridPesquisa()
        Try

            Dim _Obj As New CLSN_PLANO_AULA()

            Me.GridPesquisa_01.DataSource = _Obj.F_Leitura_Grid(Me.Obj_Seguranca.idClasse)
            Me.GridPesquisa_01.DataBind()

            Me.LBL_CH_RESTANTE.Text = _Obj.F_Leitura_Grid(Me.Obj_Seguranca.idClasse).Sum(Function(x) x.PlanoHoraAula)

        Catch msg As Exception
            Throw
        End Try
    End Sub

    Private Sub F_Inicializar()

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
            Response.Redirect(formulario, False)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub BTN_Limpar_Click(sender As Object, e As EventArgs) Handles BTN_Limpar.Click
        Me.S_Limpa_Tela_TP_Cadastro()
    End Sub

    Private Sub S_Limpa_Tela_TP_Cadastro()
        Me.TXT_DATA_PREVISTO.Text = ""
        Me.TXT_Descricao.Text = ""
        Me.TXT_Hora_Aula.Text = ""
        Me.TXT_Observacao.Text = ""
        Me.TXT_Professor.Text = ""

        Me.LBL_C001_ID.Text = ""
        Me.LBL_Membresia_ID.Text = ""

        Me.BTN_Gravar.Visible = True
        Me.BTN_Excluir.Visible = True

        Me.LBL_Mensagem.Text = ""
        Me.CAMPO_MENSAGEM.Visible = False

    End Sub

    Private Sub GridPesquisa_01_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridPesquisa_01.ItemCommand
        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Dim _KeyFieldName As Integer = e.CommandArgument
            Me.S_Limpa_Tela_TP_Cadastro()
            Dim _Obj As New PIBICAS.Models.Plano
            Me.S_Recupera_ID_Cadastro(_KeyFieldName, _Obj)
            Me.setBancoTela(_Obj)

            If (Me.Obj_Seguranca.StatusClasse = "Encerrado") Then
                Me.bloquearTudo()
            End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
        End Try

        If LBL_Mensagem.Text <> "" Then
            Me.CAMPO_MENSAGEM.Visible = True
        End If
    End Sub

    Private Sub setBancoTela(_obj As PIBICAS.Models.Plano)

        If Not (_obj.PlanoId = 0) Then
            Me.LBL_C001_ID.Text = _obj.PlanoId
        End If

        If Not (_obj.PlanoDescricao Is Nothing) Then
            Me.TXT_Descricao.Text = _obj.PlanoDescricao
        End If

        If Not (_obj.PlanoHoraAula = 0) Then
            Me.TXT_Hora_Aula.Text = _obj.PlanoHoraAula
        End If

        If Not (_obj.PlanoDataPrevista.ToString = "") Then
            Me.TXT_DATA_PREVISTO.Text = _obj.PlanoDataPrevista
        End If

        If Not (_obj.PlanoObservacao Is Nothing) Then
            Me.TXT_Observacao.Text = _obj.PlanoObservacao
        End If

        If Not (_obj.PlanoProfessor Is Nothing) Then
            Me.TXT_Professor.Text = _obj.PlanoProfessor
        End If

    End Sub

    Private Sub S_Recupera_ID_Cadastro(keyFieldName As Integer, ByRef _obj As Plano)
        Try
            Dim negocio As CLSN_PLANO_AULA = New CLSN_PLANO_AULA
            _obj = negocio.obterPorId(keyFieldName)

            If _obj Is Nothing Then
                Throw New Exception("Consulta inválida.")
            End If

        Catch ex As Exception
            Throw
        End Try
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
            Dim _obj As PIBICAS.Models.Plano = New PIBICAS.Models.Plano
            Dim _negocio As CLSN_PLANO_AULA = New CLSN_PLANO_AULA
            Me.setTelaBanco(_obj)
            _negocio.inserirAtualizarObjeto(_obj)

            If (_obj.PlanoTipoOperacao = "Inclusão") Then
                Dim _obj_classe As PIBICAS.Models.ClassePlanoAula = New PIBICAS.Models.ClassePlanoAula
                _obj_classe.PlanoAulaId = _obj.PlanoId
                _obj_classe.ClassePlanoAulaId = 0
                _obj_classe.ClasseId = Me.Obj_Seguranca.idClasse

                Dim _negocio_classe As CLSN_CLASSE_PLANOAULA = New CLSN_CLASSE_PLANOAULA
                _negocio_classe.inserirAtualizarObjeto(_obj_classe)

            End If

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Private Sub setTelaBanco(obj As Plano)
        obj.PlanoObservacao = Me.TXT_Observacao.Text
        obj.PlanoDescricao = Me.TXT_Descricao.Text
        obj.PlanoDataPrevista = CDate(Me.TXT_DATA_PREVISTO.Text).GetDateTimeFormats.GetValue(47)
        obj.PlanoHoraAula = Me.TXT_Hora_Aula.Text
        obj.PlanoProfessor = Me.TXT_Professor.Text

        obj.PlanoId = IIf(Val(LBL_C001_ID.Text) = 0, 0, Val(LBL_C001_ID.Text))
        obj.PlanoClasseId = Me.Obj_Seguranca.idClasse

        obj.PlanoUsuario = Me.Obj_Seguranca._usuario.UsuarioNome
        obj.PlanoRastro = Me.Obj_Seguranca.Rastro
        obj.PlanoTempo = CDate(Now()).GetDateTimeFormats.GetValue(47)
        obj.PlanoTipoOperacao = IIf(LBL_C001_ID.Text = "", "Inclusão", "Alteração")
    End Sub

    Private Function F_Critica_Dados() As Boolean
        If (Me.TXT_DATA_PREVISTO.Text Is Nothing) Then
            Throw New Exception("O campo Data prevista é obrigatório.")
        End If

        If (Me.TXT_Descricao.Text Is Nothing) Then
            Throw New Exception("O campo Descrição é obrigatório.")
        End If

        If (Me.TXT_Hora_Aula.Text Is Nothing) Then
            Throw New Exception("O campo hora aula é obrigatório.")
        End If

        If (Me.TXT_Observacao.Text Is Nothing) Then
            Throw New Exception("O campo observação é obrigatório.")
        End If

        If (Me.TXT_Professor.Text Is Nothing) Then
            Throw New Exception("O campo Professor é obrigatório.")
        End If

        Return True
    End Function

    Private Sub S_Tira_Malicia()
        Me.TXT_Professor.Text = Me.TXT_Professor.Text.Replace("'", "´")
        Me.TXT_Descricao.Text = Me.TXT_Descricao.Text.Replace("'", "´")
        Me.TXT_Hora_Aula.Text = Me.TXT_Hora_Aula.Text.Replace("'", "´")
        Me.TXT_Observacao.Text = Me.TXT_Observacao.Text.Replace("'", "´")
        Me.TXT_Professor.Text = Me.TXT_Professor.Text.Replace("'", "´")
    End Sub

    Private Sub BTN_Excluir_Click(sender As Object, e As EventArgs) Handles BTN_Excluir.Click
        Try
            If Not (Me.LBL_C001_ID.Text = "") AndAlso Not (Val(Me.LBL_C001_ID.Text) = 0) Then

                Dim _negocio_classe_plano As CLSN_CLASSE_PLANOAULA = New CLSN_CLASSE_PLANOAULA
                _negocio_classe_plano.excluirClassePlano(LBL_C001_ID.Text, Me.Obj_Seguranca.idClasse)

                Dim _negocio As CLSN_PLANO_AULA = New CLSN_PLANO_AULA
                _negocio.excluirId(LBL_C001_ID.Text)

                Me.S_Limpa_Tela_TP_Cadastro()
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

    Private Sub BTN_Imprimir_Click(sender As Object, e As EventArgs) Handles BTN_Imprimir.Click

        Dim javaScript As String = "window.open('relatorios/ReportPlanoClasse.aspx');"

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Relatório", javaScript, True)

    End Sub
End Class