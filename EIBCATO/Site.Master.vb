Public Class SiteMaster
    Inherits MasterPage
    Private Obj_Seguranca As Cls_Seguranca
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Try

            If IsPostBack Then

            Else

                If Session("Obj_Seguranca") IsNot Nothing Then

                    Me.Obj_Seguranca = Session("Obj_Seguranca")

                    Me.SetPerfilUsuario()
                    Me.carregarMenu()
                End If

            End If

        Catch ex As Exception
            Me.LBL_Mensagem.Text = ex.Message
            Me.CAMPO_MENSAGEM.Visible = True
        End Try
    End Sub

    Private Sub SetPerfilUsuario()

        Me.LBL_Nome.Text = Obj_Seguranca._usuario.UsuarioNome
        Me.LBL_Lotacao.Text = "Igreja Batista Catedral de Adoração"
        Me.LBL_Acesso.Text = "Pastor"

    End Sub

    Private Sub carregarMenu()

        Dim div = _menu_lista
        div.InnerHtml = "<ul class='sidebar-elements'>

                            <li class='divider'>Menu</li> "

        'Cadastro de USUARIO
        div.InnerHtml &= "  <li class='parent'>
                                <a href='FRMClasse.aspx'>
                                        <i class=""material-icons left_menu"">assignment_ind</i>  Classe Nova Criatura
                                </a>"
        div.InnerHtml &= "  </li>"

        'Cadastro de USUARIO
        div.InnerHtml &= "  <li class='parent'>
                                <a href='FRMCadastroUsuario.aspx'>
                                    <i class=""material-icons left_menu"">assignment_ind</i> Cadastro de Usuários
                                </a>"
        div.InnerHtml &= "  </li>"

        'Cadastro de DOC ADM
        div.InnerHtml &= "  <li class='parent'>
                                        <a href='FRMRelatorios.aspx'>
                                            <i class=""material-icons left_menu"">report</i> Relatórios
                                        </a>"
        div.InnerHtml &= "  </li>"

        div.InnerHtml &= "<li class='parent'>
                                        <a href='default.aspx'>
                                            <i class=""material-icons left_menu"">exit_to_app</i> Sair
                                        </a>
                                     </li>"

        div.InnerHtml &= "</ul>"

    End Sub
End Class