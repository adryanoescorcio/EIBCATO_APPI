<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportFrequenciaAluno.aspx.vb" Inherits="EIBCATO.ReportFrequenciaAluno" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor=""
                ClientIDMode="AutoID" Height="541px" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204"
                InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor=""
                PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor=""
                SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor=""
                SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor=""
                ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor=""
                ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px"
                ToolBarItemPressedHoverBackColor="153, 187, 226" Width="662px">
                <LocalReport ReportPath="relatorios\RdlcFrequenciaAluno.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>

            </rsweb:ReportViewer>

            <asp:SqlDataSource ID="SqlDataSource1"
                runat="server" ConnectionString="<%$ ConnectionStrings:conexaoodbcpostgres %>"
                ProviderName="<%$ ConnectionStrings:conexaoodbcpostgres.ProviderName %>"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
