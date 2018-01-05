<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FRMFrequencia.aspx.vb" Inherits="EIBCATO.FRMFrequencia" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tab-container z-depth-1">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">Frequência</a></li>
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


                                        <hr />
                                        <%--Nome Table--%>
                                        <asp:Label ID="LBL_C001_ID" runat="server" Visible="False" />
                                        <asp:Label ID="LBL_FrequenciaUnique" runat="server" Visible="False" />
                                        <div class="panel-heading">
                                            Frequências Registradas
                                        </div>
                                        <%--Table--%>
                                        <%--Div que controla a altura do scroll--%>

                                        <div class="panel-body">

                                            <div class="row be-datatable-body">
                                                <div class="col-sm-12">
                                                    <table id="table3" class="table table-striped table-hover table-fw-widget dataTable no-footer" role="grid" aria-describedby="table1_info">
                                                        <asp:Repeater ID="GridPesquisa_01" runat="server">
                                                            <HeaderTemplate>
                                                                <thead>
                                                                    <tr role="row">
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 100px;">Data</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 300px;">Plano</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr class="gradeA odd" role="row">
                                                                    <td class="sorting_1">
                                                                        <asp:LinkButton runat="server" ID="link_select_item" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FrequenciaUnique") %>'>
                                                                            <%# CDate(DataBinder.Eval(Container.DataItem, "FrequenciaData")).GetDateTimeFormats.GetValue(0) %>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "PlanoDescricao") %>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />

                                        <div class="panel-heading">
                                            Frequências
                                        </div>

                                        <div class="Botoes">

                                            <asp:LinkButton ID="BTN_Limpar" runat="server"
                                                CssClass=" waves-effect waves-light btn small"> 
                                                <i class="material-icons left">clear</i>
                                                Limpar</asp:LinkButton>

                                            <asp:LinkButton ID="BTN_Gravar" runat="server" CssClass="btn waves-effect waves-light"> 
                                                <i class="material-icons left">save</i>
                                                Gravar</asp:LinkButton>

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
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text ">Plano Aula*</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                    TabIndex="-1"
                                                    aria-hidden="true"
                                                    runat="server" ID="DDL_PLANO">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Data Frequência*</span>
                                            </div>

                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_DATA"
                                                        class="form-control"
                                                        type="text"
                                                        runat="server" />
                                                    <span class="input-group-addon btn btn-primary">
                                                        <i class="icon-th mdi mdi-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div runat="server" id="LBL_ALTERACAO" visible="false" class="panel-heading red-text">
                                        </div>
                                        <div class="panel-heading">
                                            Alunos da Classe
                                        </div>

                                        <table width="100%" style="padding-top: 5px">
                                            <tr>
                                                <td>
                                                    <table style="width: 40%; margin-left: 20px">
                                                        <tr>
                                                            <td align="left" style="padding-right: 5px">
                                                                <asp:CheckBox ID="CheckBox1"
                                                                    Text=" - Presente"
                                                                    TextAlign="Right"
                                                                    Checked="true"
                                                                    Enabled="false"
                                                                    runat="server" />
                                                            </td>
                                                            <td align="left" style="padding-right: 5px">
                                                                <asp:CheckBox ID="CheckBox2"
                                                                    Text=" - Ausente"
                                                                    TextAlign="Right"
                                                                    Checked="false"
                                                                    BackColor="White"
                                                                    Enabled="false"
                                                                    runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--Table--%>
                                        <div class="panel-body">
                                            <div class="row be-datatable-body">
                                                <div class="col-sm-12">
                                                    <table id="table4" class="table table-striped table-hover table-fw-widget dataTable no-footer" role="grid" aria-describedby="table1_info">
                                                        <asp:Repeater ID="GridPesquisa_LST_ALUNO" runat="server">
                                                            <HeaderTemplate>
                                                                <thead>
                                                                    <tr role="row">
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 300px;">Nome</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 200px;">CPF</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 150px;">Situação</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr class="gradeA odd" role="row">
                                                                    <td class="sorting_1">
                                                                        <asp:CheckBox ID="CheckBox1"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "AlunoNome") %>'
                                                                            TextAlign="Right"
                                                                            Checked="true"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoCPF") %>
                                                                    </td>
                                                                    <td id="TB_AlunoSituacao" runat="server">
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoSituacao") %>
                                                                    </td>
                                                                    <td id="TB_AlunoId" runat="server" visible="false">
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoId") %>
                                                                    </td>
                                                                    <td id="TB_ListaId" runat="server" visible="false">
                                                                        <%# DataBinder.Eval(Container.DataItem, "ListaId") %>
                                                                    </td>
                                                                    <td id="TB_FrequenciaID" runat="server" visible="false">
                                                                        <%# DataBinder.Eval(Container.DataItem, "FrequenciaId") %>
                                                                    </td>
                                                                    <td id="TB_FrequenciaSituacao" runat="server" visible="false">
                                                                        <%# DataBinder.Eval(Container.DataItem, "FrequenciaSituacao") %>
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
