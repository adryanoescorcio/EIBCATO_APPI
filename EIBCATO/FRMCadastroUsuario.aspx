<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FRMCadastroUsuario.aspx.vb" Inherits="EIBCATO.FRMCadastroUsuario" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="tab-container z-depth-1">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">Usuário</a></li>
            <%--<li class="tab col s3"><a class="white-text waves-effect waves-light" href="#vestibulum">Vestibulum</a>
                </li>--%>
        </ul>
    </div>
    <div class="col s12">
        <div class="tab-content">
            <div id="home" class="tab-pane cont active aba">
                <div id="login-page" class="row" style="height: 100%; width: 100%">
                    <div class="col s12 card-panel">
                        <div class="login-form" runat="server">
                            <div class="row">

                                <div class="Botoes">

                                    <asp:LinkButton ID="BTN_Limpar" runat="server"
                                        CssClass=" waves-effect waves-light btn small"> 
                                                <i class="material-icons left" >
                                                    clear</i>
                                                Limpar</asp:LinkButton>

                                    <asp:LinkButton ID="BTN_Gravar" runat="server" CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left" >
                                                save</i>
                                                Gravar</asp:LinkButton>

                                    <asp:LinkButton ID="BTN_Excluir" runat="server"
                                        CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left" >
                                                delete_forever</i>
                                                Excluir</asp:LinkButton>

                                </div>

                                <div runat="server" id="CAMPO_MENSAGEM" visible="false">
                                    <label style="height: 10px"></label>
                                    <div role="alert" class="alert alert-danger alert-icon alert-icon-border alert-dismissible">
                                        <div class="icon"><span class="mdi mdi-close-circle-o"></span></div>
                                        <div class="message">
                                            <button type="button" data-dismiss="alert" aria-label="Close" class="close"><span aria-hidden="true" class="mdi mdi-close"></span></button>
                                            <strong>Atenção!</strong>
                                            <asp:Label runat="server" ID="LBL_Mensagem"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s3 cssTextForm">
                                        <span class="flow-text ">CPF*</span>
                                    </div>
                                    <div class="col s3">
                                        <asp:TextBox runat="server" Width="100%" ID="TXT_C001_Cpf"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s6 cssTextForm">
                                        <span class="flow-text">Nome*</span>
                                    </div>
                                    <div class="col s6">
                                        <asp:TextBox runat="server" Width="100%" ID="TXT_C001_Nome"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s6 cssTextForm">
                                        <span class="flow-text ">Sobrenome*</span>
                                    </div>
                                    <div class="col s6">
                                        <asp:TextBox runat="server" Width="100%" ID="TXT_C001_SobreNome"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s6 cssTextForm">
                                        <span class="flow-text ">Observação</span>
                                    </div>
                                    <div class="col s6">
                                        <asp:TextBox runat="server" Width="100%" TextMode="MultiLine" Height="80px" ID="TXT_C001_Detalhe"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s3 cssTextForm">
                                        <span class="flow-text ">Email*</span>
                                    </div>
                                    <div class="col s3">
                                        <asp:TextBox runat="server" TextMode="Email" Width="100%" ID="TXT_C001_Email"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="input-field col s12">
                                    <div class=" col s3 cssTextForm">
                                        <span class="flow-text ">Sexo</span>
                                    </div>
                                    <div class="col s3">
                                        <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                            TabIndex="-1"
                                            aria-hidden="true"
                                            runat="server" ID="DDL_C001_Sexo">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <hr />
                                <%-- Deve ser invisivel para os usuário comuns, desde que seja o próprio dono do registro --%>
                                <div runat="server" id="CAMPO_ACESSO">
                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Nova Senha</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:TextBox runat="server" TextMode="Password" Width="100%" ID="TXT_C001_Senha"></asp:TextBox>
                                        </div>
                                        <span class="text-info">Todas as senhas são criptografadas.</span>
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Repetir a Senha</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:TextBox runat="server" TextMode="Password" Width="100%" ID="TXT_C001_Senha_Repetir"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Trocar a senha</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                TabIndex="-1"
                                                aria-hidden="true"
                                                runat="server" ID="DDL_C001_TrocarSenha">
                                            </asp:DropDownList>
                                            <span class="text-info">Uma nova senha será solicitada no seu próximo acesso.</span>
                                        </div>
                                    </div>

                                    <div class="input-field col s12" runat="server" visible="false">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Validade da Senha*</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:TextBox runat="server" TextMode="Date" Width="100%" ID="TXT_C001_Date"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s1 cssTextForm">
                                            <span class="flow-text ">Tentativas*</span>
                                        </div>
                                        <div class="col s1">
                                            <asp:TextBox runat="server" Width="100%" ID="TXT_C001_Tentativa"></asp:TextBox>
                                        </div>
                                    </div>

                                    <hr />

                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Status</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                TabIndex="-1"
                                                aria-hidden="true"
                                                runat="server" ID="DDL_C001_Status">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                                <div id="CAMPO_MEMBRESIA" runat="server" visible="false">
                                    <hr />
                                    <div class="panel-heading">
                                        Membresia
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Igreja*</span>
                                        </div>
                                        <div class="col s6">
                                            <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                TabIndex="-1"
                                                aria-hidden="true"
                                                runat="server" ID="DDL_C003_Igreja">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s3 cssTextForm">
                                            <span class="flow-text ">Perfil*</span>
                                        </div>
                                        <div class="col s3">
                                            <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                TabIndex="-1"
                                                aria-hidden="true"
                                                runat="server" ID="DDL_C005_Perfil">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="input-field col s12">
                                        <div class=" col s6 cssTextForm">
                                            <span class="flow-text">Matrícula*</span>
                                        </div>
                                        <div class="col s4">
                                            <asp:TextBox runat="server" Width="100%" ID="TXT_Matricula" Enabled="false"></asp:TextBox>
                                        </div>
                                        <span class="text-info">Por padrão será o CPF do Usuário.</span>
                                    </div>
                                </div>
                                <hr />
                                <%--Nome Table--%>
                                <asp:Label ID="LBL_C001_ID" runat="server" Visible="False" />
                                <asp:Label ID="LBL_Membresia_ID" runat="server" Visible="False" />
                                <div class="panel-heading">
                                    Lista de Membros
                                </div>
                                <%--Table--%>
                                <div class="panel-body">
                                    <div class="row be-datatable-body">
                                        <div class="col-sm-12">
                                            <table id="table1" class="table table-striped table-hover table-fw-widget dataTable no-footer" role="grid" aria-describedby="table1_info">
                                                <asp:Repeater ID="GridPesquisa_01" runat="server">
                                                    <HeaderTemplate>
                                                        <thead>
                                                            <tr role="row">
                                                                <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                    aria-label="" style="width: 500px;">Nome</th>
                                                                <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                    aria-label="" style="width: 100px;">Status</th>
                                                                <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                    aria-label="" style="width: 150px;">Último Usuário</th>
                                                                <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                    aria-label="" style="width: 150px;">Data</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <tr class="gradeA odd" role="row">
                                                            <td class="sorting_1">
                                                                <asp:LinkButton runat="server" ID="link_select_item" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UsuarioId") %>'>
                                                                        <%# DataBinder.Eval(Container.DataItem, "UsuarioNome") & " " %>  <%# DataBinder.Eval(Container.DataItem, "UsuarioSobrenome") %>
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "UsuarioStatus") %>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "UsuarioUsuario") %>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "UsuarioTempo") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--<div id="vestibulum" class="col s12  cyan lighten-4" style="display: none;">
                <p>
                    Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies
                        mi vitae est. Mauris placerat eleifend leo.
                </p>
            </div>--%>
    </div>
</asp:Content>

