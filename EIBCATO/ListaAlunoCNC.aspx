<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListaAlunoCNC.aspx.vb" Inherits="EIBCATO.ListaAlunoCNC" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tab-container z-depth-1">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#home" data-toggle="tab" aria-expanded="true">Lista Aluno</a></li>
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
                                                <span class="flow-text">Nome*</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_NOME"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s6 cssTextForm">
                                                <span class="flow-text">CPF*</span>
                                            </div>
                                            <div class="col s6">
                                                <asp:TextBox runat="server" placeholder="Não Definido" Width="100%" ID="TXT_CPF"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Data Nascimento*</span>
                                            </div>

                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_DATA_NASC"
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
                                            <div class=" col s5 cssTextForm">
                                                <span class="flow-text ">Escolaridade</span>
                                            </div>
                                            <div class="col s5">
                                                <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                    TabIndex="-1"
                                                    aria-hidden="true"
                                                    runat="server" ID="DDL_Escolaridade">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s3 cssTextForm">
                                                <span class="flow-text">Celular*</span>
                                            </div>
                                            <div class="col s3">
                                                <asp:TextBox runat="server" Width="100%"  data-mask="tel" placeholder="(98)99999-9999" ID="TXT_Celular"></asp:TextBox>
                                                </span>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s5 cssTextForm">
                                                <span class="flow-text">Equipe</span>
                                            </div>
                                            <div class="col s5">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Equipe">
                                                </asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s5 cssTextForm">
                                                <span class="flow-text">Célula</span>
                                            </div>
                                            <div class="col s5">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Celula">
                                                </asp:TextBox>
                                            </div>
                                        </div>

                                         <div class="input-field col s12">
                                            <div class=" col s5 cssTextForm">
                                                <span class="flow-text">Dicipulador</span>
                                            </div>
                                            <div class="col s5">
                                                <asp:TextBox runat="server" Width="100%" ID="TXT_Dicipulador">
                                                </asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="input-field col s12">
                                            <div class=" col s2 cssTextForm">
                                                <span class="flow-text">Batismo</span>
                                            </div>

                                            <div class="col s2">
                                                <div data-min-view="2" data-date-format="dd/mm/yyyy" class="input-group date datetimepicker">
                                                    <asp:TextBox
                                                        ID="TXT_Batismo"
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
                                            <div class=" col s4 cssTextForm">
                                                <span class="flow-text ">Situação*</span>
                                            </div>
                                            <div class="col s4">
                                                <asp:DropDownList CssClass="select2 select2-hidden-accessible"
                                                    TabIndex="-1"
                                                    aria-hidden="true"
                                                    runat="server" ID="DDL_SITUACAO">
                                                </asp:DropDownList>
                                            </div>
                                        </div>


                                        <hr />
                                        <%--Nome Table--%>
                                        <asp:Label ID="LBL_C001_ID" runat="server" Visible="False" />
                                        <asp:Label ID="LBL_Membresia_ID" runat="server" Visible="False" />
                                        <div class="panel-heading">
                                            Alunos da Turma
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
                                                                            aria-label="" style="width: 100px;">CPF</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 300px;">Nome</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 200px;">Dicipulador</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 80px;">Situação</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 80px;">Presenças</th>
                                                                        <th class="sorting_asc" tabindex="0" aria-controls="table1" rowspan="1" colspan="1"
                                                                            aria-label="" style="width: 80px;">Faltas</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr class="gradeA odd" role="row">
                                                                    <td class="sorting_1">
                                                                        <asp:LinkButton runat="server" ID="link_select_item" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "AlunoId") %>'>
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoCPF") %>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoNome") %>
                                                                    </td>

                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoDiscipulador") %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "AlunoSituacao") %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "presenca") %>
                                                                    </td>
                                                                    <td>
                                                                        <%# DataBinder.Eval(Container.DataItem, "faltas") %>
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
