<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FRMPlanoAula.aspx.vb" Inherits="EIBCATO.FRMPlanoAula" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tab-container z-depth-1">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">Plano Aula</a></li>
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
                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_CLASSE">Classe</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_ALUNOS">Alunos</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_FREQUENCIA">Frequência</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_ITEM_PLANO_AULA">Plano Aula</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="ASP_MENU_RELATORIO">Relatório</asp:LinkButton>

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

                                            <asp:LinkButton ID="BTN_Imprimir" runat="server"
                                                CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left">delete_forever</i>
                                                Imprimir</asp:LinkButton>

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
                                            <div class=" col s5 cssTextForm">
                                                <span class="flow-text">Descrição*</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Descricao"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text">Professor</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" placeholder="Não Definido" Width="100%" ID="TXT_Professor"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Data prevista*</span>
                                            </div>

                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_DATA_PREVISTO"
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
                                                <span class="flow-text">Hora Aula*</span>
                                            </div>
                                            <div class="col s2">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Hora_Aula"></asp:TextBox>
                                                <asp:Label class="text-info" runat="server" ID="LBL_CH_RESTANTE"></asp:Label>
                                                <span class="text-info">Hora-aula acumulada
                                                </span>
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


                                        <hr />
                                        <%--Nome Table--%>
                                        <asp:Label ID="LBL_C001_ID" runat="server" Visible="False" />
                                        <asp:Label ID="LBL_Membresia_ID" runat="server" Visible="False" />
                                        <div class="panel-heading">
                                            Lista de Planos de Aula
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
                                                                            aria-label="" style="width: 100px;">Data Prevista</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 200px;">Professor</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 100px;">Hora Aula</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr class="gradeA odd" role="row">
                                                                    <td class="sorting_1">
                                                                        <asp:LinkButton runat="server" ID="link_select_item" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PlanoId") %>'>
                                                                        <%# DataBinder.Eval(Container.DataItem, "PlanoDescricao") %>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <%# CDate(DataBinder.Eval(Container.DataItem, "PlanoDataPrevista")).GetDateTimeFormats.GetValue(0)  %>
                                                                    </td>

                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "PlanoProfessor") %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "PlanoHoraAula") %>
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
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
