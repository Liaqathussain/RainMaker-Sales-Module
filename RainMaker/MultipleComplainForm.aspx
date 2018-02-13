<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MultipleComplainForm.aspx.cs" Inherits="RainMaker.WebForm3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 125px;
        }
        .style3
        {
            width: 359px;
        }
        .style4
        {
            width: 200px;
        }
        .style5
        {
            width: 198px;
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
                   Multiple Complains</h6>
            </div>
        </div>
        <ContentTemplate>
            <div class="container-fluid">
                <table class="nav-justified">
                    <tr>
                        <td>
                            <telerik:RadButton ID="btSaveComplain" runat="server" SplitButtonPosition="Right"
                                Text="Save Complain" OnClick="SaveToolStripButton_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btCancel" runat="server" Text="Cancel">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                            Basic Information
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="nav-justified">
                                <tr>
                                    <td width="200px">
                                        Logged By
                                    </td>
                                    <td width="200px">
                                        <telerik:RadTextBox ID="tbLoggedBy" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        Caller Name
                                    </td>
                                    <td width="200px">
                                        <telerik:RadTextBox ID="tbCallerName" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td style="font-weight: bold">
                                        Engineer Name
                                    </td>
                                </tr>
                                <tr>
                                    <td width="200px">
                                        Complaint Reported Via
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbComplaintReportedVia" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        Caller Number
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="tbCallerNumber" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEngineerName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="200px">
                                        Case Category
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbCaseCategory" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td width="200px">
                                        POC Name
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="tbPOCName" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td style="font-weight: bold">
                                        Date / Time
                                    </td>
                                </tr>
                                <tr>
                                    <td width="200px">
                                        POC Number
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="tbPOCNumber" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        POC Status
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbPOCStatus" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                            Other Information
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="nav-justified">
                                <tr>
                                    <td width="200px">
                                        Complain Status
                                    </td>
                                    <td width="200px">
                                        <telerik:RadComboBox ID="cmbComplainStatus" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                        &nbsp;
                                    </td>
                                    <td width="200px">
                                        Assigned Department
                                    </td>
                                    <td width="200px">
                                        <telerik:RadComboBox ID="cmbAssignedDepartment" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                        &nbsp;
                                    </td>
                                    <td>
                                        Complain Received D/T
                                    </td>
                                </tr>
                                <tr>
                                    <td width="144px">
                                        Initial Statement
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbInitialStatement" runat="server" Width="175px" Height="22px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        Complain Type
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbComplainType" runat="server" Width="175px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <telerik:RadDateTimePicker ID="dtComplaintReceived" runat="server" Width="175px">
                                        </telerik:RadDateTimePicker>
                                    </td>
                                </tr>
                            </table>
                            <table class="nav-justified">
                                <tr>
                                    <td width="200px" class="style5">
                                        Remarks
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="tbRemarks" runat="server" TextMode="MultiLine" Width="485px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table class="nav-justified">
                                <tr>
                                    <td width="200px">
                                        Person Given ETA/ETTR
                                    </td>
                                    <td width="200px">
                                        <telerik:RadTextBox ID="tbPersonGivenETA" runat="server" Width="175px">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        ETA
                                    </td>
                                    <td class="style3">
                                        <telerik:RadDateTimePicker ID="dtETA" runat="server" MinDate="" Width="175px">
                                        </telerik:RadDateTimePicker>
                                    </td>
                                    <td>
                                        ETTR&nbsp;
                                        <telerik:RadDateTimePicker ID="dtETTR" runat="server" MinDate="" Width="175px">
                                        </telerik:RadDateTimePicker>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total Count :
                            <asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <table class="nav-justified">
                        <tr>
                            <td class="style4">
                                <asp:CheckBox ID="cbCheckAll" runat="server" Text="Check All" />
                            </td>
                            <td class="style1">
                                Primary IP Address
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbPrimaryIPAddress" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Selected Count:
                                <asp:Label ID="tbSelectedCount" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="nav-justified">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="gvMultipleComplainForm" runat="server" AllowPaging="True" AllowSorting="True"
                                    GridLines="None" Skin="Office2007">
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridButtonColumn CommandName="Complain" HeaderText="Complain" Text="Complain"
                                                UniqueName="column1">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <PagerStyle Mode="NextPrev" />
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </table>
            </div>
        </ContentTemplate>

        </div>
   
</asp:Content>
