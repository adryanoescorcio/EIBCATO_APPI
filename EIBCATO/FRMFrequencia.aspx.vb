Imports PIBICAS.Models

Public Class FRMFrequencia
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
            Me.S_Carrega_GridPesquisa_Diario()
            Me.VerificarAlunos()
        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

    Private Sub bloquearTudo()
        Me.BTN_Gravar.Visible = False
        Me.CAMPO_MENSAGEM.Visible = True
        Me.LBL_Mensagem.Text = "Não é possivel alterar os dados abaixo."
    End Sub

    Private Sub S_Carrega_GridPesquisa_Diario()
        Try

            Dim _Obj As New CLSN_FREQUENCIA()
            Me.GridPesquisa_01.DataSource = _Obj.F_Leitura_Grid(Me.Obj_Seguranca.idClasse)
            Me.GridPesquisa_01.DataBind()

        Catch msg As Exception
            Throw
        End Try
    End Sub

    Private Sub GridPesquisa_01_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles GridPesquisa_01.ItemCommand
        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Dim _KeyFieldName As String = e.CommandArgument
            Me.S_Limpa_Tela_TP_Cadastro()
            Dim _Obj As New PIBICAS.Models.Frequencia
            Me.S_Recupera_ID_Cadastro(_KeyFieldName, _Obj)
            Me.setBancoTela(_Obj)
            Me.S_Carrega_GridPesquisa()
            Me.VerificarAlunos()

            Me.LBL_ALTERACAO.InnerText = "Alteração de Frequência!"
            Me.LBL_ALTERACAO.Visible = True

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

    Private Sub setBancoTela(_obj As PIBICAS.Models.Frequencia)

        If Not (_obj.PlanoId = 0) Then
            Me.LBL_C001_ID.Text = _obj.PlanoId
            Me.LBL_FrequenciaUnique.Text = _obj.FrequenciaUnique
        End If

        If Not (_obj.PlanoId = 0) Then
            Me.DDL_PLANO.SelectedValue = _obj.Plano.PlanoId
            Me.DDL_PLANO.DataBind()
        End If

        If Not (_obj.FrequenciaData.ToString = "") Then
            Me.TXT_DATA.Text = _obj.FrequenciaData
        End If

    End Sub

    Private Sub S_Recupera_ID_Cadastro(keyFieldName As String, ByRef _obj As Frequencia)
        Try
            Dim negocio As CLSN_FREQUENCIA = New CLSN_FREQUENCIA
            _obj = negocio.obterPorIdUnique(keyFieldName)

            If _obj Is Nothing Then
                Throw New Exception("Consulta inválida.")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub VerificarAlunos()
        Dim total_alunos = GridPesquisa_LST_ALUNO.Items.Count - 1

        While total_alunos >= 0

            'Pegar o último item
            Dim item As RepeaterItem = GridPesquisa_LST_ALUNO.Items.Item(total_alunos)
            Dim itemCheck As CheckBox = item.FindControl("CheckBox1") 'Passa para uma variavel label local
            Dim itemSituacao As HtmlTableCell = item.FindControl("TB_AlunoSituacao") 'Passa para uma variavel label local
            Dim itemFrequencia As HtmlTableCell = item.FindControl("TB_FrequenciaSituacao") 'Passa para uma variavel label local

            'Se for a imagem for de item desativado, então passar p proximo item.
            If Not (itemSituacao.InnerText.Trim = "Cursando") Then
                itemCheck.Enabled = False
            End If

            If (itemFrequencia.InnerText.Trim = "1") Then
                itemCheck.Checked = True
            Else
                itemCheck.Checked = False
            End If

            total_alunos -= 1
        End While
    End Sub

    Private Sub F_Inicializar()
        S_Carrega_DDL_Plano()
    End Sub

    Private Sub S_Carrega_DDL_Plano()
        Me.DDL_PLANO.Items.Clear()

        Dim _negocio As CLSN_PLANO_AULA = New CLSN_PLANO_AULA
        Me.DDL_PLANO.DataSource = _negocio.F_Leitura_Grid(Me.Obj_Seguranca.idClasse)
        Me.DDL_PLANO.DataTextField = "PlanoDescricao"
        Me.DDL_PLANO.DataValueField = "PlanoId"
        Me.DDL_PLANO.DataBind()

        Me.DDL_PLANO.SelectedIndex() = -1

        If Me.DDL_PLANO.Items.Count > 0 Then
            Me.DDL_PLANO.Items.Insert(0, "")
        End If

    End Sub

    Private Sub S_Carrega_GridPesquisa()

        Try

            Dim _Obj As New CLSN_LISTA_ALUNO_CNC()
            If (LBL_FrequenciaUnique.Text = "") Then
                Me.GridPesquisa_LST_ALUNO.DataSource = _Obj.F_Leitura_Grid(Me.Obj_Seguranca.idClasse)
            Else
                Me.GridPesquisa_LST_ALUNO.DataSource = _Obj.F_Leitura_Grid_Diario(Me.Obj_Seguranca.idClasse, LBL_FrequenciaUnique.Text)
            End If
            Me.GridPesquisa_LST_ALUNO.DataBind()

        Catch msg As Exception
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

            Me.S_Limpa_Tela_TP_Cadastro()
            S_Carrega_GridPesquisa_Diario()
            S_Carrega_GridPesquisa()


            Me.LBL_Mensagem.Text = "Operação realizada com sucesso"
            Me.CAMPO_MENSAGEM.Visible = True

        Catch ex As Exception
            Me.CAMPO_MENSAGEM.Visible = True
            Me.LBL_Mensagem.Text = ex.Message
        Finally
        End Try
    End Sub

    Private Sub Salvar_Dados()

        Try
            Dim _obj As PIBICAS.Models.Frequencia = New PIBICAS.Models.Frequencia
            Dim _negocio As CLSN_FREQUENCIA = New CLSN_FREQUENCIA
            Me.setTelaBanco(_obj)

            Dim total_alunos = GridPesquisa_LST_ALUNO.Items.Count - 1

            While total_alunos >= 0

                'Pegar o último item
                Dim item As RepeaterItem = GridPesquisa_LST_ALUNO.Items.Item(total_alunos)
                Dim itemCheck As CheckBox = item.FindControl("CheckBox1") 'Passa para uma variavel label local
                Dim listaId As HtmlTableCell = item.FindControl("TB_ListaId")
                Dim frequenciaId As HtmlTableCell = item.FindControl("TB_FrequenciaID")

                _obj.FrequenciaId = IIf(LBL_FrequenciaUnique.Text <> "", frequenciaId.InnerText.Trim, 0)
                _obj.ListaId = listaId.InnerText.Trim

                If (itemCheck.Checked) Then
                    _obj.FrequenciaSituacao = 1
                Else
                    _obj.FrequenciaSituacao = 0
                End If

                _negocio.inserirAtualizarObjeto(_obj)

                'prox aluno
                total_alunos -= 1
            End While
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub setTelaBanco(ByRef obj As Frequencia)
        obj.FrequenciaData = CDate(Me.TXT_DATA.Text).GetDateTimeFormats.GetValue(47)

        obj.ClasseId = Me.Obj_Seguranca.idClasse
        obj.PlanoId = Me.DDL_PLANO.SelectedItem.Value
        obj.FrequenciaUnique = CDate(Now()).GetDateTimeFormats.GetValue(34).ToString.Replace("/", "").Replace(" ", "").Replace(":", "") &
            obj.ClasseId & obj.PlanoId & Now().GetHashCode().ToString.Replace("-", "").Substring(0, 5)

        obj.FrequenciaUsuario = Me.Obj_Seguranca._usuario.UsuarioNome
        obj.FrequenciaRastro = Me.Obj_Seguranca.Rastro
        obj.FrequenciaTempo = CDate(Now()).GetDateTimeFormats.GetValue(47)
        obj.FrequenciaTipoOperacao = IIf(LBL_C001_ID.Text = "", "Inclusão", "Alteração")

    End Sub

    Private Sub S_Limpa_Tela_TP_Cadastro()
        Me.LBL_C001_ID.Text = ""
        Me.TXT_DATA.Text = ""
        Me.DDL_PLANO.SelectedIndex = -1
        LBL_FrequenciaUnique.Text = ""
        Me.LBL_ALTERACAO.InnerText = ""
        Me.LBL_ALTERACAO.Visible = False

        Me.BTN_Gravar.Visible = True

        Me.LBL_Mensagem.Text = ""
        Me.CAMPO_MENSAGEM.Visible = False
    End Sub

    Private Function F_Critica_Dados() As Boolean
        If (Me.TXT_DATA.Text Is Nothing) Then
            Throw New Exception("O campo Data é obrigatório.")
        End If

        If (Me.DDL_PLANO.SelectedValue = "") Then
            Throw New Exception("O campo Plano é obrigatório.")
        End If

        Return True
    End Function

    Private Sub S_Tira_Malicia()
        Me.TXT_DATA.Text = Me.TXT_DATA.Text.Replace("'", "´")
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
End Class