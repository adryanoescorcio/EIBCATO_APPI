
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="EIBCATO._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>E-IBCA</title>

    <!--Import Google Icon Font-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">


    <link rel="stylesheet" type="text/css" href="assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/lib/material-design-icons/css/material-design-iconic-font.min.css" />
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="assets/css/style.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="assets/lib/datetimepicker/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/lib/select2/css/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/lib/datatables/css/dataTables.bootstrap.min.css" />
    <%--Estilização própria do sistema--%>
    <link rel="stylesheet" type="text/css" href="css/cssGlobal.css" />
    <link rel="stylesheet" type="text/css" href="css/materialize.css" />

</head>
<body class="panel panel-fundo">
    <%--Cabelhaço--%>
    <nav class="navbar navbar-default navbar-fixed-top be-top-header clr-royalblue3">
        <div class="container-fluid">

            <%--Logotipo do Sistema--%>
            <div class="navbar-header">
                <div class="DivMargemTopo3 ">
                    <%--<asp:Image runat="server" Height="80px" ImageUrl="~/Imagens/Logoempresa.png"></asp:Image>--%>
                </div>
            </div>
        </div>
    </nav>

    <div class="be-left-sidebar">
        <!-- Right sidebar -->
    </div>

    <div class="be-content">
        <div class="Div_Formulario">

            <div id="login-page" class="row" style="margin-left: 325px; margin-right: 325px; margin-top: 100px">
                <div class="col s12 z-depth-4 card-panel">
                    <form class="login-form" runat="server">
                        <div class="row">
                            <div class="input-field col s12 center">
                                <img src="Imagens/Logoempresa.png" alt="" class="circle responsive-img valign profile-image-login" style="height: 200px" />
                                <p class="center login-form-text texto_init">Sistema Igreja Batista Catedral de Adoração</p>
                                <br />
                            </div>
                        </div>

                        <div class="row margin">
                            <label class="center-align">Login</label>
                            <div class="input-field col s12">
                                <asp:TextBox runat="server" Width="100%" placeholder="Digite seu E-mail" ID="TXT_Usuario"></asp:TextBox>
                            </div>
                        </div>
                        <label style="height: 5px"></label>

                        <div runat="server" id="CAMPO_SENHA_PADRAO">
                            <div class="row margin">
                                <label class="">Senha</label>
                                <div class="input-field col s12">
                                    <asp:TextBox runat="server" Width="100%" placeholder="******" TextMode="Password" ID="TXT_Senha"></asp:TextBox>
                                </div>
                            </div>

                            <label style="height: 15px"></label>
                            <div class="row">
                                <div class="input-field col s12">

                                    <asp:LinkButton ID="BTN_LoginGo" runat="server" CssClass="btn waves-effect waves-light col s12" type="submit"> 
                                 Login</asp:LinkButton>
                                </div>
                            </div>
                            <label style="height: 2px"></label>
                            <div class="row">
                                <div class="input-field col s6 m6 l6">
                                    <p class="margin medium-small"><a href="page-register.html">Solicitar Acesso</a></p>
                                </div>
                                <label style="height: 5px"></label>
                                <div class="input-field col s6 m6 l6">
                                    <p class="margin right-align medium-small"><a href="page-forgot-password.html">Esqueceu a senha?</a></p>
                                </div>
                            </div>
                        </div>

                        <div runat="server" id="CAMPO_NOVASENHA" visible="false">
                            <div class="row margin">
                                <label class="">Nova Senha</label>
                                <div class="input-field col s12">
                                    <asp:TextBox runat="server" Width="100%" TextMode="Password" ID="TXT_NovaSenha"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row margin">
                                <label class="">Repita a Nova Senha</label>
                                <div class="input-field col s12">
                                    <asp:TextBox runat="server" Width="100%" TextMode="Password" ID="TXT_RepitaNovaSenha"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="height: 10px">
                                <div class="input-field col s12">

                                    <asp:LinkButton ID="BTN_LoginSlow" runat="server" CssClass="btn waves-effect waves-light col s12" type="submit"> 
                                 Concluir</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div runat="server" id="CAMPO_MENSAGEM" visible="false">
                            <label style="height=10px"></label>
                            <div role="alert" class="alert alert-danger alert-icon alert-icon-border alert-dismissible">
                                <div class="icon"><span class="mdi mdi-close-circle-o"></span></div>
                                <div class="message">
                                    <button type="button" data-dismiss="alert" aria-label="Close" class="close"><span aria-hidden="true" class="mdi mdi-close"></span></button>
                                    <strong>Atenção!</strong>
                                    <asp:Label runat="server" ID="LBL_Mensagem"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
            </div>

        </div>
    </div>

    <div class="be-right-sidebar">
        <!-- Right sidebar -->
    </div>

   <div class="clr-royalblue4">
                <div id="Div1" class="panel-footer ">
                    <a style="color: whitesmoke" target="_blank" href="http://www.saude.ma.gov.br">Sistema Eletrônico da Igreja Batista Catedral de Adoração</a> | Tel. (98) 9999-9999       
                </div>
            </div>

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/lib/prettify/prettify.js" type="text/javascript"></script>
    <script src="assets/lib/parsley/parsley.min.js" type="text/javascript"></script>
    <script src="assets/lib/datetimepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="assets/lib/select2/js/select2.min.js" type="text/javascript"></script>
    <script src="assets/lib/datatables/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="assets/lib/datatables/js/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/js/app-tables-datatables.js" type="text/javascript"></script>
    <script src="assets/js/app-form-elements.js" type="text/javascript"></script>
    <script src="js/app-global.js"></script>
    <script src="js/materialize.js"></script>

    <script>
        function bindEvents() {

            $(function EventosJS() {
                //initialize the javascript
                App.init();

                //Runs prettify
                prettyPrint();
                App.dataTables();
                App.formElements();

            });
        }

        $(document).ready(function () {
            bindEvents();

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                bindEvents();
            });

        });
    </script>

</body>
</html>
