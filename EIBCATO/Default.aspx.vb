Public Class _Default
    Inherits System.Web.UI.Page
    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack Then

                Me.Obj_Seguranca = New Cls_Seguranca

            Else
                If Session("Obj_Seguranca") IsNot Nothing Then

                    Me.Obj_Seguranca = Session("Obj_Seguranca")

                    Me.Obj_Seguranca.F_Registra_Saida_Usuario()

                    If Session("Obj_Seguranca").MensagemGeral <> "" Then
                        Me.LBL_Mensagem.Text = Session("Obj_Seguranca").MensagemGeral
                        Me.CAMPO_MENSAGEM.Visible = True
                    End If

                End If

                Session("Obj_Seguranca") = Nothing
                Me.Obj_Seguranca = Nothing

            End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
            Me.CAMPO_MENSAGEM.Visible = True

        End Try
    End Sub

    Private Sub BTN_Entrar_Click(sender As Object, e As System.EventArgs) Handles BTN_LoginGo.Click

        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Me.TXT_NovaSenha.Text = Me.TXT_NovaSenha.Text.Replace("'", "´")
            Me.TXT_RepitaNovaSenha.Text = Me.TXT_RepitaNovaSenha.Text.Replace("'", "´")
            Me.TXT_Senha.Text = Me.TXT_Senha.Text.Replace("'", "´")
            Me.TXT_Usuario.Text = Me.TXT_Usuario.Text.Replace("'", "´")

            If Me.TXT_Usuario.Text = "" Then
                Throw New Exception("Email obrigatório")
            End If

            If Me.TXT_Senha.Text = "" Then
                Throw New Exception("Senha obrigatório")
            End If

            If Not Me.Obj_Seguranca.F_Recupera_Usuario(Me.TXT_Usuario.Text) Then
                Throw New Exception("usuário/senha não autorizado")
            End If

            Me.Obj_Seguranca.Rastro = Me.F_Recupera_IP & " - " & Me.F_Recupera_Mac

            If Me.Obj_Seguranca._usuario.UsuarioTentativaErro > 4 Then
                Throw New Exception("Limite superado - FALAR COM SUPORTE")
            End If

            Dim _Email = Me.TXT_Usuario.Text.ToLower
            Dim _Senha = Me.Obj_Seguranca.F_CriptografarMD5(_Email & Me.TXT_Senha.Text)

            If Me.Obj_Seguranca._usuario.UsuarioSenha.ToUpper <> _Senha Then
                Dim _negocioUsuario As CLSN_USUARIO = New CLSN_USUARIO()
                _negocioUsuario.atualizarUsuario(Me.Obj_Seguranca._usuario)
                Throw New Exception("Email não autorizado")
            End If

            Me.Obj_Seguranca._usuario.UsuarioEmail = Me.TXT_Usuario.Text
            Me.Obj_Seguranca._usuario.UsuarioSenha = _Senha
            Session("Obj_Seguranca") = Me.Obj_Seguranca

            If Me.Obj_Seguranca._usuario.UsuarioTrocarSenha.ToString.ToUpper = "SIM" Then
                Me.TXT_Usuario.Enabled = False

                Me.CAMPO_SENHA_PADRAO.Visible = False

                Me.CAMPO_NOVASENHA.Visible = True

                Exit Sub
            End If

            'If Me.Obj_Seguranca.C010_PrincipalNome <> "" Then
            Me.S_Registra_Entrada()
            Response.Redirect("FRMClasse.aspx")
            'Else
            'Me.LBL_Mensagem.Text = "Usuário não possui tela principal"
            'Me.LBL_Mensagem.Visible = True
            'End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
            Me.CAMPO_MENSAGEM.Visible = True
        End Try

    End Sub

    Private Sub BTN_Acessar_Click(sender As Object, e As System.EventArgs) Handles BTN_LoginSlow.Click

        Try
            Me.LBL_Mensagem.Text = ""
            Me.CAMPO_MENSAGEM.Visible = False

            Me.TXT_NovaSenha.Text = Me.TXT_NovaSenha.Text.Replace("'", "´")
            Me.TXT_RepitaNovaSenha.Text = Me.TXT_RepitaNovaSenha.Text.Replace("'", "´")
            Me.TXT_Senha.Text = Me.TXT_Senha.Text.Replace("'", "´")
            Me.TXT_Usuario.Text = Me.TXT_Usuario.Text.Replace("'", "´")

            If Session("Obj_Seguranca") Is Nothing Then
                Throw New Exception("Sessão expirou - tente novamente")
                Exit Sub
            End If

            Me.Obj_Seguranca = Session("Obj_Seguranca")

            If Me.Obj_Seguranca._usuario.UsuarioEmail = "" Then
                Throw New Exception("Erro na autenticação - tente novamente")
                Exit Sub
            End If

            If Me.TXT_NovaSenha.Text = "" Then
                Throw New Exception("Digite a nova senha")
                Exit Sub
            End If

            If Me.TXT_RepitaNovaSenha.Text = "" Then
                Throw New Exception("Repita a nova senha")
                Exit Sub
            End If

            Dim _Email = Me.Obj_Seguranca._usuario.UsuarioEmail.ToLower
            Dim _Senha = Me.Obj_Seguranca.F_CriptografarMD5(_Email & Me.TXT_Senha.Text)

            If Me.TXT_NovaSenha.Text <> Me.TXT_RepitaNovaSenha.Text Then
                Throw New Exception("Senhas divergentes. Digite novamente")
                Exit Sub
            End If

            If Me.Obj_Seguranca._usuario.UsuarioSenha.ToUpper <> Me.Obj_Seguranca._usuario.UsuarioSenha.ToUpper Then

                Throw New Exception("Problema ao trocar. Tente novamente")

            End If

            Me.TXT_Usuario.Text = Me.Obj_Seguranca._usuario.UsuarioEmail

            _Senha = Me.Obj_Seguranca.F_CriptografarMD5(_Email.ToLower & Me.TXT_NovaSenha.Text)

            Me.Obj_Seguranca.atualizarSenhaUsuario(_Senha)

            Session("Obj_Seguranca") = Me.Obj_Seguranca

            Me.S_Registra_Entrada()

            Response.Redirect("FRMClasse.aspx")

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
            Me.CAMPO_MENSAGEM.Visible = True
        End Try

    End Sub

    Private Sub S_Registra_Entrada()

        Try
            Me.Obj_Seguranca.F_Registra_Entrada_Usuario()

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Function F_Recupera_Mac() As String

        Dim _mc As System.Management.ManagementClass
        Dim _mo As System.Management.ManagementBaseObject
        _mc = New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim _moc As System.Management.ManagementObjectCollection = _mc.GetInstances
        Dim _Mac As String = ""

        For Each _mo In _moc
            If _mo.Item("IPenabled") = True Then
                _Mac = _Mac & _mo.Item("MacAddress")
                Exit For
            End If
        Next

        If _Mac = "" Then
            Return "Não foi identificado"
        Else
            Return _Mac
        End If

    End Function

    Private Function F_Recupera_IP() As String

        Return Request.ServerVariables.Get("REMOTE_ADDR")

    End Function

End Class