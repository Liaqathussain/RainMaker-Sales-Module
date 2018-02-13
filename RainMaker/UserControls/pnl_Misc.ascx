<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pnl_Misc.ascx.cs" Inherits="RainMaker.UserControls.pnl_Misc" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style scoped>
td
{
    padding-top:2px;
}
</style>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 38px;
    }
    .style3
    {
        width: 120px;
    }
</style>

<telerik:RadTabStrip ID="tbstrip_pnlMisc" runat="server" MultiPageID="RadMultiPage1"
    SelectedIndex="0" CausesValidation="False">
    <Tabs>
        <telerik:RadTab runat="server" Text="Customer Information" Selected = "true" Visible = "true">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Service Information">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Billing Information">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage ID="RadMultiPage1" runat="server" Font-Names="Calibri" 
    SelectedIndex="0">
    <telerik:RadPageView ID="CustomerInformation" runat="server">
        <table class="style1">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Client Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Name
                            </td>
                            <td width="30%">
                                <telerik:RadTextBox ID="tbName" runat="server" Width="250px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="tbName" ErrorMessage="Client Name Required" 
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                BusinessType
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBusinessType" runat="server" AutoPostBack="True" 
                                    Width="175px" CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                    ControlToValidate="cmbBusinessType" Display="None" 
                                    ErrorMessage="Business Type Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Company
                            </td>
                            <td width="30%">
                                <telerik:RadTextBox ID="tbCompany" runat="server" Width="250px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="tbCompany" ErrorMessage="Company Name Required" 
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td width="120px">
                                <telerik:RadButton ID="btGetSiteB" runat="server" Text="Get SiteB">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbGetSiteB" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Address
                            </td>
                            <td width="30%">
                                <telerik:RadTextBox ID="tbAddress" runat="server" Width="250px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="tbAddress" ErrorMessage="Client Address Required" 
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td width="120px">
                                City
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCity" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="cmbCity_SelectedIndexChanged" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                &nbsp;
                            </td>
                            <td width="30%">
                                &nbsp;
                            </td>
                            <td width="120px">
                                NTN
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbNTN" runat="server" Width="175px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="tbNTN" Display="None" ErrorMessage="NTN Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Contact Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Phone
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbPhone" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td width="auto">
                                Cell#
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCell" runat="server" Width="175px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="tbCell" Display="None" ErrorMessage="Cell Number Required"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Cell#(SMS)
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCellSMS" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td width="auto">
                                Email
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbEmail" runat="server" Width="175px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="tbEmail" Display="None" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Fax
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbFax" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                CNIC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCNIC" runat="server" Width="175px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="tbCNIC" Display="None" ErrorMessage="CNIC Required"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                CNIC Expiry Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtCNIC" runat="server" Width="175px">
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="dtCNIC" Display="None" 
                                    ErrorMessage="CNIC Expiry Date Required"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Document Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                <asp:CheckBox ID="cbBCase" runat="server" Text="BCase" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FUBCase" runat="server" Width="330px" />
                            </td>
                            <td width="auto">
                                <asp:CheckBox ID="cbSignUp" runat="server" Text="SignUp" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FUSignUp" runat="server" Width="330px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Other Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Signup Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtSignup" runat="server" Width="175px">
                                </telerik:RadDatePicker>
                            </td>
                            <td width="auto">
                                CPM Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtCPM" runat="server" Width="175px">
                                </telerik:RadDatePicker>
                            </td>
                            <td width="auto">
                                RFS Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtRFS" runat="server" Width="175px">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer Code
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCustomerCode" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="cmbCustomerCode_SelectedIndexChanged" 
                                    Width="175px" CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                Project Code
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbProjectCode" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                Location Code
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbLocationCode" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales Person
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbSalesPerson" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                    ControlToValidate="cmbSalesPerson" Display="None" 
                                    ErrorMessage="Sales Person Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Priority
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbPriority" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="cmbPriority" Display="None" ErrorMessage="Priority Required" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
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
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Notes
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbNotes" runat="server" Height="40px" TextMode="MultiLine"
                                    Width="305px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Reference CMS ID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCMSID" runat="server" Text="0" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Reference Contract ID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbContract" runat="server" Text="0" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Reference GPID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbGPID" runat="server" Text="0" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
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
                    <asp:CheckBox ID="cbEmailtoCustomer" runat="server" Text="Send email to Customer" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView ID="ServiceInformation" runat="server">
        <table class="style1">
            <tr>
                <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold">
                    Service Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Bandwidth
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBandwidth" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                    ControlToValidate="cmbBandwidth" Display="None" 
                                    ErrorMessage="Bandwidth Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Additional Services
                            </td>
                            <td width="auto">
                                <asp:CheckBox ID="cbVPN" runat="server" Text="VPN" style="text-align: center" />
                            </td>
                            <td width="auto">
                                <asp:CheckBox ID="cbVC" runat="server" Text="VC" style="text-align: center" />
                            </td>
                            <td width="auto">
                                <asp:CheckBox ID="cbVIOP" runat="server" Text="VIOP" />
                            </td>
                            <td width="auto">
                                <asp:CheckBox ID="cbExtraIP" runat="server" Text="Extra IP" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Exc/Area
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbExcArea" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                    ControlToValidate="cmbExcArea" Display="None" 
                                    ErrorMessage="Exchange Area Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Node
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbNode" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                    ControlToValidate="cmbNode" Display="None" ErrorMessage="Node Required" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <asp:Panel ID="pnlVSAT" runat="server">
                                <td>
                                    U/L Package
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbULPackage" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    D/L Package
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbDLPackage" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                            </asp:Panel>
                        </tr>
                        <tr>
                            <td>
                                Infra Medium
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbInfraMedium" runat="server" Width="175px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                    ControlToValidate="cmbInfraMedium" Display="None" 
                                    ErrorMessage="Infra Medium Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Infra Length
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbInfraLength" runat="server" Text="0" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                No. of Working Days
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbNoofWorkingDays" runat="server" Text="0" 
                                    Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:Panel ID="pnlDC" runat="server">
                <tr>
                    <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold;">
                        Data Centre Information
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td Width="120px">
                                    Mode of Billing
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbModeOfBilling" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Fixed</asp:ListItem>
                                        <asp:ListItem>As Per Actual</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td Width="120px">
                                    No of U&#39;s
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbNoofUs" runat="server" Width="175px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold;">
                        Data Centre Linked Circuit
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td Width="120px">
                                    MPLS Layer3 SignupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbMPLSLayer3" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Internet SIgnupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbInternet" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    FLL SignupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbFLL" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td Width="120px">
                                    MPLS Layer2 SignupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbMPLSLayer2" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Layer 2 VPN SignupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbVPNLayer2" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Transit SignupID
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbTransit" runat="server" Width="175px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </asp:Panel>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView ID="BillingInformation" runat="server">
        <table class="style1">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF;">
                    Service Charges
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbSame" runat="server" Text="Same as Basic Info" AutoPostBack="True"
                        OnCheckedChanged="cbSame_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="auto">
                                Name
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIName" runat="server" Width="125px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                    ControlToValidate="tbBIName" Display="None" 
                                    ErrorMessage="Billing Information Requires Name" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Company
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBICompany" runat="server" Width="450px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                    ControlToValidate="tbBICompany" Display="None" 
                                    ErrorMessage="Billing Information Requires Company Name" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Cell#
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBICell" runat="server" Width="125px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                    ControlToValidate="tbBICell" Display="None" 
                                    ErrorMessage="Billing Information Requires Cell Number" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Phone
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIPhone" runat="server" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td width="120px">
                                Address
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIAddress" runat="server" Width="450px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                    ControlToValidate="tbBIAddress" Display="None" 
                                    ErrorMessage="Billing Information Requires Address" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Email
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIEmail" runat="server" Width="125px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                    ControlToValidate="tbBIEmail" Display="None" 
                                    ErrorMessage="Billing Information Requires Email" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td class="style3" width="auto">
                                Pay. Terms
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIPayTerms" runat="server" Width="125px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                    ControlToValidate="cmbBIPayTerms" Display="None" 
                                    ErrorMessage="Billing Information Requires Payment Terms" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Equipment Owner
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIEquipmentOwner" runat="server" Width="125px" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                    ControlToValidate="cmbBIEquipmentOwner" Display="None" 
                                    ErrorMessage="Billing Information Requires Equipment Owner" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="auto">
                                Fax
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIFax" runat="server" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td width="auto">
                                Installation Cost
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIInstallationCost" runat="server" Text="0" 
                                    Width="125px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                    ControlToValidate="tbBIInstallationCost" Display="None" 
                                    ErrorMessage="Billing Information Requires Installation Cost"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Infra Cost
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIInfraCost" runat="server" Text="0" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Equipment/Port Cost
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIEquipmentCost" runat="server" Text="0" Width="50px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <telerik:RadTextBox ID="tbBIPortCost" runat="server" Text="0" Width="50px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Total Investment
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBITotalInvestment" runat="server" Text="0" 
                                    Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Recurring Cost
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIRecurringCost" runat="server" Text="0" 
                                    Width="125px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                    ControlToValidate="tbBIRecurringCost" Display="None" 
                                    ErrorMessage="Billing Information Requires Recurring Cost"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                OTC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIOTC" runat="server" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                MRC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIMRC" runat="server" Text="0" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Payback
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIPayback" runat="server" Text="0" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Total Cost
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBITotalCost" runat="server" Text="0" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF;">
                    Project Costing
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="150px">
                                Site Nature
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbBISiteNature" runat="server" 
                                    RepeatDirection="Horizontal" Width="150px">
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>MSP</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Project MRC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectMRC" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td width="150px">
                                Project OTC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectOTC" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td width="150px">
                                Project Investment
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectInvestment" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td width="150px">
                                Project Payback
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectPayback" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF;">
                    Third Party Charges
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="150px">
                                Circuit Owner
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICircuitOwner" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="cmbBICircuitOwner_SelectedIndexChanged" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                    ControlToValidate="cmbBICircuitOwner" Display="None" 
                                    ErrorMessage="Billing Information Requires Circuit Owner" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <asp:Panel ID="pnlBIThirdPartyCharges" runat="server">
                                <td>
                                    3rd Party Name
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbBI3rdPartyName" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    3rd Party OTC
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbBI3rdPartyOTC" runat="server" Text="0">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    3rd Party MRC
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbBI3rdPartyMRC" runat="server" Text="0">
                                    </telerik:RadTextBox>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Party Account ID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIPartyAccountID" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            </asp:Panel>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF;">
                    Backup Charges
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="150px">
                                Circuit Type
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICircuitType" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="cmbBICircuitType_SelectedIndexChanged" 
                                    CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                                    ControlToValidate="cmbBICircuitType" Display="None" 
                                    ErrorMessage="Billing Information Requires Circuit Type" 
                                    InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td width="150px">
                                <asp:Label ID="lblBIBackupInfra" runat="server" Visible = "false" Text="Backup Infra"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIBackupInfra" Visible = "False" runat="server">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Please-Select" Value="0" />
                                        <telerik:RadComboBoxItem runat="server" Text="Metronet" Value="Metronet" />
                                        <telerik:RadComboBoxItem runat="server" Text="Wireless" Value="Wireless" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBIBackupOwner" runat="server" Text="Backup Owner" Visible = "false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIBackupOwner" runat="server" Visible = "false" AutoPostBack="True" OnSelectedIndexChanged="cmbBIBackupOwner_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <asp:Panel ID = "pnlBackupCharges" runat = "server" Visible = "false">
                            <td>
                                <asp:Label ID="lblBI3rdBackupParty" runat="server" Text="3rd Backup Party"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBI3rdBackupParty" runat="server">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBIBackUpOTC" runat="server" Text="BackUp OTC"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIBackUpOTC" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBIBackUpMRC" runat="server" Text="BackUp MRC"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIBackUpMRC" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            </asp:Panel>
                            
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
</telerik:RadMultiPage>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />