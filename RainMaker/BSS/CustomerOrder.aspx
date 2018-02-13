<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CustomerOrder.aspx.cs" Inherits="RainMaker.WebForm1" %>

<%@ Register TagPrefix="My" TagName="TDM" Src="~/UserControls/pnl_TDM.ascx" %>
<%@ Register TagPrefix="My" TagName="Misc" Src="~/UserControls/pnl_Misc.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style scoped>
        td
        {
            padding-top: 2px;
        }
    </style>
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:UpdatePanel ID="UPPanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <table class="nav-justified">
                    <tr>
                        <td style="float: right">
                            <telerik:RadButton ID="btSave" Text="Save" runat="server" OnClick="btSave_Click"
                                CausesValidation="true">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btClear" Text="Clear" runat="server" CausesValidation="false">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btClose" Text="Close" runat="server" CausesValidation="false">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                            Strategic Business Units
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="nav-justified">
                                <tr>
                                    <td>
                                        Line of Business
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbLob" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbLob_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        Service
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbService" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbService_SelectedIndexChanged1">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        Infra
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbInfra" runat="server" AutoPostBack="True" CausesValidation="false"
                                            OnSelectedIndexChanged="cbInfra_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="cbChangeForm" runat="server" Text="Change Form" AutoPostBack="True"
                                            OnCheckedChanged="cbChangeForm_CheckedChanged1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <My:Misc runat="server" ID="pnl_Misc" Visible="false" />
                            <My:TDM runat="server" ID="pnl_TDM" Visible="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
