<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FRMClasse.aspx.vb" Inherits="EIBCATO.FRMClasse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tab-container z-depth-1">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">Classe N.C.</a></li>
                    <%--<li class="tab col s3"><a class="white-text waves-effect waves-light" href="#vestibulum">Vestibulum</a>
                </li>--%>
                </ul>
            </div>
            <div class="col s12">
                <div class="tab-content">
                    <div id="home" class="tab-pane cont active aba">
                        <div id="login-page" class="row" style="height: 100%; width: 100%">
                            <div runat="server" id="ASP_MENU" class="col-sm-12">
                                <%--MENU ABA--%>
                                <div runat="server" id="ASP_MENU_RESIDENCIA" class="scrollmenu">
                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_ALUNOS">Alunos</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_PROG_LETIVA">Frequência</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_PLANO_AULA">Plano Aula</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_DIARIO">Relatório</asp:LinkButton>

                                </div>
                            </div>
                            <div class="col s12 card-panel">
                                <div class="login-form" runat="server">
                                    <div class="row">

                                        <div class="Botoes">

                                            <asp:LinkButton ID="BTN_Limpar" runat="server"
                                                CssClass=" waves-effect waves-light btn small"> 
                                                <i class="material-icons left">clear</i>
                                                Limpar</asp:LinkButton>

                                            <asp:LinkButton ID="BTN_Gravar" runat="server" CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left">save</i>
                                                Gravar</asp:LinkButton>

                                            <asp:LinkButton ID="BTN_Excluir" runat="server"
                                                CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left">delete_forever</i>
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
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text">Código*</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Codigo"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Início*</span>
                                            </div>

                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_PERIODO_INICIO"
                                                        class="form-control"
                                                        type="text"
                                                        runat="server" />
                                                    <span class="input-group-addon btn btn-primary">
                                                        <i class="icon-th mdi mdi-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Término*</span>
                                            </div>
                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_PERIODO_FIM"
                                                        class="form-control"
                                                        type="text"
                                                        runat="server" />
                                                    <span class="input-group-addon btn btn-primary">
                                                        <i class="icon-th mdi mdi-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Carga Horária*</span>
                                            </div>
                                            <div class="col s2">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Carga"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text">Professor*</span>
                                            </div>

                                            <div class="col s6">
                                                <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                    TabIndex="-1"
                                                    aria-hidden="true"
                                                    runat="server" ID="DDL_Membresia_Professor" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text">Observação</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" Width="100%"
                                                    Height="80px" TextMode="MultiLine" ID="TXT_Observacao">
                                                </asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s3 cssTextForm">
                                                <span class="flow-text ">Situação*</span>
                                            </div>
                                            <div class="col s3">
                                                <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                    TabIndex="-1"
                                                    aria-hidden="true"
                                                    runat="server" ID="DDL_Status">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <hr />
                                        <%--Nome Table--%>
                                        <asp:Label ID="LBL_C001_ID" runat="server" Visible="False" />
                                        <asp:Label ID="LBL_Membresia_ID" runat="server" Visible="False" />
                                        <div class="panel-heading">
                                            Lista de Classes
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
                                                                            aria-label="" style="width: 300px;">Descrição</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 100px;">Data Início</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 100px;">Data Término</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 100px;">Situação</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 150px;">Professor</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr class="gradeA odd" role="row">
                                                                    <td class="sorting_1">
                                                                        <asp:LinkButton runat="server" ID="link_select_item" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ClasseId") %>'>
                                                                        <%# DataBinder.Eval(Container.DataItem, "ClasseCodigo") %>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <%# CDate(DataBinder.Eval(Container.DataItem, "ClasseDataInicio")).GetDateTimeFormats.GetValue(0)  %>
                                                                    </td>
                                                                    <td>
                                                                        <%# CDate(DataBinder.Eval(Container.DataItem, "ClasseDataFim")).GetDateTimeFormats.GetValue(0) %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "ClasseStatus") %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "Membresia.Usuario.UsuarioNome") %>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
