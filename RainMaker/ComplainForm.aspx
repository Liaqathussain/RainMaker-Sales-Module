<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ComplainForm.aspx.cs" Inherits="RainMaker.WebForm2" %>

<%@ Register TagPrefix="My" TagName="cntIntial_LinkDownDrops" Src="~/UserControls/cntIntial_LinkDownDrops.ascx" %>
<%@ Register TagPrefix="My" TagName="cntBrowsingDeadIssue" Src="~/UserControls/cntBrowsingDeadIssue.ascx" %>
<%@ Register TagPrefix="My" TagName="cntemailIsuee" Src="~/UserControls/cntemailIsuee.ascx" %>
<%@ Register TagPrefix="My" TagName="cntWebIssue" Src="~/UserControls/cntWebIssue.ascx" %>
<%@ Register TagPrefix="My" TagName="cntServiceRequest" Src="~/UserControls/cntServiceRequest.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100px;
        }
        .style2
        {
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div id="page-wrapper">
    <div class="container-fluid">
    <asp:UpdatePanel ID="UPPanel2" runat="server">
        <ContentTemplate>
            
                <telerik:RadTabStrip ID="tbstrip_ComplainForm" runat="server" MultiPageID="RadMultiPage1"
                    SelectedIndex="1">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="Customer Information" Visible="true">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Complain Form" Selected="True">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Font-Names="Calibri" 
                    SelectedIndex="1">
                    <telerik:RadPageView ID="CustomerInformation" runat="server">
                        <table class="nav-justified" style="float: left">
                            <tr>
                                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF"
                                    class="style2">
                                    Document Details
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="nav-justified" style="float: left">
                                        <tr>
                                            <td style="float: right">
                                                Signup ID
                                            </td>
                                            <td width="400px">
                                                <telerik:RadTextBox ID="tbSignupID" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                Service Unit
                                            </td>
                                            <td width="400px">
                                                <telerik:RadTextBox ID="tbServiceUnit" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                Infra
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbInfra" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="float: right">
                                                Region
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbRegion" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                Customer Email
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbCustomerEmail" runat="server" Width="250px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                Circuit Name
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbCircuitName" runat="server" Width="250px">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="float: right">
                                                Address
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbAddress" runat="server" Width="250px ">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                CPM Remarks
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbCPMRemarks" runat="server" TextMode="MultiLine" Width="250px ">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: right">
                                                Deployment Remarks
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbDeploymentRemarks" runat="server" TextMode="MultiLine"
                                                    Width="250px ">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                </td>
                                <tr>
                                    <td>
                                        <tr>
                                            <td style="float: right">
                                                Operational Remarks
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbOperationalRemarks" runat="server" TextMode="MultiLine"
                                                    Width=" 250px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left;">
                                                Deployment Date
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbDeploymentDate" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left">
                                                Deployment Person
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbDeploymentPerson" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="float: left">
                                                KAM Contact No
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbKAMContactNo" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left">
                                                3rd Party Account ID
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tb3rdPartyAccountID" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left">
                                                IP Whitelisted for VOIP
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbVOIP" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="float: right">
                                                Bandwidth
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbBandwidth" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left">
                                                Key Account Manager
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbKeyAccountManager" runat="server">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="float: left">
                                                Video Conferencing
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbVideo" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                        <tr>
                            <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                                Document Details
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage2"
                                    SelectedIndex="0">
                                    <Tabs>
                                        <telerik:RadTab runat="server" Text="Primary Information" Selected="True">
                                        </telerik:RadTab>
                                        <telerik:RadTab runat="server" Text="Secondary Information">
                                        </telerik:RadTab>
                                    </Tabs>
                                </telerik:RadTabStrip>
                                <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0">
                                    <telerik:RadPageView ID="PrimaryInformation" runat="server">
                                        <table class="nav-justified">
                                            <tr>
                                                <td width="200px">
                                                    Customer IP Pool
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCustomerIPPool1" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbCustomerIPPool2" runat="server" Enabled="false" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Subnet Mask / Gateway IP
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbSubnetMask" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbGatewayIP" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    RingName / NodeName
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbRingName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbNodeName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    SwitchName / Switch Port
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbSwitchName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbSwitchPort" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Fiber Length / Client Device
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbFiberLength" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RadioButtonList ID="rbClientDevice" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>CPE</asp:ListItem>
                                                        <asp:ListItem>ODU</asp:ListItem>
                                                        <asp:ListItem>MC</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CPE Model / Wavelength
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCPEModel" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbWavelength" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CPE Address / CPE Port
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCPEAddress" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbCPEPort" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Circuit Owner / ThirdParty
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCircuitOwner" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbThirdParty" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    OLT Pon Port / OLT IP Address
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbOLTPonPort" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbOLTIPAddress" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>
                                    <telerik:RadPageView ID="SecondaryInformation" runat="server">
                                        <table class="nav-justified">
                                            <tr>
                                                <td width="200px">
                                                    Customer IP Pool
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCustomerIPPool21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbCustomerIPPool22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Subnet Mask / Gateway IP
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbSubnetMask21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbGatewayIP22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    RingName / NodeName
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbRingName21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbNodeName22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    SwitchName / Switch Port
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbSwitchName21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbSwitchPort22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Fiber Length / Client Device
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbFiberLength21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RadioButtonList ID="rbClientDevice2" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>CPE</asp:ListItem>
                                                        <asp:ListItem>ODU</asp:ListItem>
                                                        <asp:ListItem>MC</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CPE Model / Wavelength
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCPEModel21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbWavelength22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CPE Address / CPE Port
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbCPEAddress21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbCPEPort22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Backup Circuit Owner /<br />
                                                    Backup ThirdParty Name
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbBackupCircuitOwner" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbBackupThirdPartyName" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    OLT Pon Port / OLT IP Address
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="tbOLTPonPort21" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="tbOLTIPAddress22" runat="server" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </telerik:RadPageView>
                                </telerik:RadMultiPage>
                            </td>
                        </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="ComplainFrm" runat="server">
                        <table class="nav-justified">
                            <tr>
                                <td>
                                    <telerik:RadButton ID="btSaveComplain" runat="server" SplitButtonPosition="Right"
                                        Text="Save Complain" OnClick="btSaveComplain_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btCancel" runat="server" Text="Cancel">
                                    </telerik:RadButton>
                                    <asp:Label ID="lblTicketNoAfterComplainGeneration"  runat="server"></asp:Label>
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
                                            <td width="150px">
                                                <telerik:RadTextBox ID="tbLoggedBy" runat="server" Width="125px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td width="150px">
                                                Caller Name
                                            </td>
                                            <td width="200px">
                                                <telerik:RadTextBox ID="tbCallerName" runat="server" Width="125px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Engineer Name
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Complaint Reported Via
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="cmbComplaintReportedVia" runat="server" Width="125px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                Caller Number
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbCallerNumber" runat="server" Width="125px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEngineerName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Case Category
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="cmbCaseCategory" runat="server" Width="125px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                POC Name
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbPOCName" runat="server" Width="125px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Date / Time
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                POC Number
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="tbPOCNumber" runat="server" Width="125px">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                POC Status
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="cmbPOCStatus" runat="server" Width="125px">
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
                                            <td width="150px">
                                                <telerik:RadComboBox ID="cmbComplainStatus" runat="server" Width="125px" AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                Assigned Department
                                            </td>
                                            <td width="200px">
                                                <telerik:RadComboBox ID="cmbAssignedDepartment" runat="server" Width="125px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                Complain Received D/T
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Initial Statement
                                            </td>
                                            <td width="150px">
                                                <telerik:RadComboBox ID="cmbInitialStatement" runat="server" Width="125px" OnSelectedIndexChanged="cmbInitialStatement_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td width="150px">
                                                Complain Type
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="cmbComplainType" runat="server" Width="125px">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <telerik:RadDateTimePicker ID="dtComplainReceived" runat="server">
                                                </telerik:RadDateTimePicker>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlInProcess" runat="server" Enabled="false">
                                            <tr>
                                                <td>
                                                    Person Given ETA/ETTR
                                                </td>
                                                <td width="150px">
                                                    <telerik:RadTextBox ID="tbPerson" runat="server" Width="125px">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    ETA
                                                </td>
                                                <td>
                                                    <telerik:RadDateTimePicker ID="dtETA" runat="server" MinDate="">
                                                    </telerik:RadDateTimePicker>
                                                </td>
                                                <td>
                                                    ETTR
                                                    <telerik:RadDateTimePicker ID="dtETTR" runat="server" MinDate="">
                                                    </telerik:RadDateTimePicker>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlTicketInfo" runat="server" Visible="false">
                                            <tr>
                                                <td style="float: right">
                                                    Ticket No. :
                                                </td>
                                                <td width="150px">
                                                    <asp:Label ID="lblTicketNo" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="float: right">
                                                    Logged Date/Time
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblLoggedDateTime" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                                    Trouble Shooting Step
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <My:cntIntial_LinkDownDrops runat="server" ID="cntIntial_LinkDownDrops" Visible="false" />
                                    <My:cntBrowsingDeadIssue runat="server" ID="cntBrowsingDeadIssue" Visible="false" />
                                    <My:cntemailIsuee runat="server" ID="cntemailIsuee" Visible="false" />
                                    <My:cntWebIssue runat="server" ID="cntWebIssue" Visible="false" />
                                    <My:cntServiceRequest runat="server" ID="cntServiceRequest" Visible="false" />
                                    <asp:Panel ID="pnlLinkDownToLatencyIssue" runat="server" Visible="false">
                                    </asp:Panel>
                                    <asp:Panel ID="pnlFlappingIssueToBrowsingIssue" runat="server" Visible="false">
                                    </asp:Panel>
                                    <asp:Panel ID="pnlEmailIssue" runat="server" Visible="false">
                                    </asp:Panel>
                                    <asp:Panel ID="pnlWebsiteIssue" runat="server" Visible="false">
                                    </asp:Panel>
                                    <asp:Panel ID="pnlServiceRequesttoMiscIssue" runat="server" Visible="false">
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <//div>
</asp:Content>
