<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchCircuits.aspx.cs" Inherits="RainMaker.SearchCircuits" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 150px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   Search Circuits</h6>
            </div>
        </div>
    <div class="container-fluid">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
        <table class="nav-justified">
            <tr>
                <td>
                    <telerik:RadButton ID="btSearch" Text="Search" runat="server" 
                        OnClick="btSearch_Click" SplitButtonPosition="Right">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btMultipleCircuitsComplain" runat="server" Visible = "false"
                        Text="Multiple Circuits Complain" AutoPostBack = "true"
                        onclick="btMultipleCircuitsComplain_Click">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btClear" Text="Clear" runat="server">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btClose" Text="Close" runat="server">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Searching Engine
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td>
                                <table class="nav-justified" style="border: thin groove #C0C0C0;">
                                    <style scoped>
                                        td
                                        {
                                            width: 150px;
                                        }
                                    </style>
                                    <tr>
                                        <td width="100px">
                                            Complain At
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbComplainAt" runat="server" Width="150px" 
                                                AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Ticket Type
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbTicketType" runat="server" Width="150px" 
                                                AutoPostBack="True" OnSelectedIndexChanged = "cmbTicketType_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Panel ID="pnlSingleSearch" runat="server" Enabled = "true">
                                <table class="nav-justified" style="border: thin groove #C0C0C0;">
                                    <style scoped>
                                        td
                                        {
                                            width: 150px;
                                        }
                                    </style>
                                    <tr>
                                        <td class="style1">
                                            Signup ID
                                        </td>
                                        <td class="style5">
                                            <telerik:RadTextBox ID="tbSignupID" runat="server" Width="150px" 
                                                AutoPostBack="True">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td width="150px">
                                            CMSID
                                        </td>
                                        <td width="150px">
                                            <telerik:RadTextBox ID="tbCMSID" runat="server" Width="150px" Text=" ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td width="150px">
                                            GPID
                                        </td>
                                        <td width="150px">
                                            <telerik:RadTextBox ID="tbGPID" runat="server" Width="150px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Customer Name
                                        </td>
                                        <td class="style5" width="200px">
                                            <telerik:RadTextBox ID="tbCustomerName" runat="server" Width="150px" Text=" ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            
                                            ServiceUnit</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbServiceUnit" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            IP Address
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="tbIPAddress" runat="server" Width="150px">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            CPE IP Address
                                        </td>
                                        <td class="style5">
                                            <telerik:RadTextBox ID="tbCPEIPAddress" runat="server" Width="150px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCity1" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            </td>
                                        <td>
                                            </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <table class="nav-justified" style="border: thin groove #C0C0C0;">
                                    <style scoped>
                                        td
                                        {
                                            width: 150px;
                                        }
                                    </style>
                                    <tr>
                                        <td width="100px">
                                            Status
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbStatus" runat="server" Width="150px" 
                                                AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Infra
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbInfra" runat="server" Width="150px" 
                                                AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Panel ID="pnlMultipleSearch" runat="server" Enabled = "false">
                                <table class="nav-justified" style="border: thin groove #C0C0C0;">
                                    <style scoped>
                                        td
                                        {
                                            width: 150px;
                                        }
                                    </style>
                                    <tr>
                                        <td>
                                            Region
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbRegion" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Node
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbNode" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Ring
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbRing" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Customer Code
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCustomerCode" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            City</td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCity2" runat="server" Width="150px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            </td>
                                        <td>
                                            </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Total Count :
                    <asp:Label ID="lblTotalCount" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>                    
                    <asp:Label ID="lblAlreadyExist"  runat="server"></asp:Label>
                </td>           
            </tr>
            <tr>
            
            <td>                    
                    <asp:Button ID="btnViewDetails" OnClick="btnviewDetails_Click" runat="server" Text="View Details" />
            </td>
            
            </tr>

            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UPPanel2" runat="server">
        <ContentTemplate>
        <div class="table-responsive">
                        <telerik:RadGrid ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" Skin="Office2007" onitemcommand="gvActiveCircuits_ItemCommand" 
                            >
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Complain" HeaderText="Complain" Text="Complain"
                                        UniqueName="column1">
                                    </telerik:GridButtonColumn>
                                    <%--<telerik:GridButtonColumn CommandName="ComplainHistory" HeaderText="ComplainHistory" Text="ComplainHistory"
                                        UniqueName="column2">
                                    </telerik:GridButtonColumn><telerik:GridButtonColumn CommandName="StatusHistory" HeaderText="StatusHistory" Text="StatusHistory"
                                        UniqueName="column3">
                                    </telerik:GridButtonColumn>--%>
                                </Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrev" />
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
