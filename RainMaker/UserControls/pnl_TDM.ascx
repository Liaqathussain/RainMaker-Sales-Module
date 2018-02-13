<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pnl_TDM.ascx.cs" Inherits="RainMaker.UserControls.pnl_TDM" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style scoped>
    td
    {
        padding-top: 2px;
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
    .style4
    {
        width: 198px;
    }
    .style5
    {
        width: 47px;
    }
    .style6
    {
        width: 150px;
    }
    .style7
    {
        width: 106px;
    }
    .style8
    {
        width: 177px;
    }
    .style9
    {
        width: 68px;
    }
    .style10
    {
        width: 113px;
    }
    .style11
    {
        width: 475px;
    }
</style>
<telerik:RadTabStrip ID="tbstrip_pnlMisc" runat="server" MultiPageID="RadMultiPage1"
    SelectedIndex="0" CausesValidation="False">
    <Tabs>
        <telerik:RadTab runat="server" Text="Business Information" Selected="true" Visible="true">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Service Information">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Billing Information">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage ID="RadMultiPage1" runat="server" Font-Names="Calibri" SelectedIndex="0">
    <telerik:RadPageView ID="BusinessInformation" runat="server">
        <table class="style1">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Business Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="105px">
                                Company
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCompany" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                            <td width="120px">
                                Country
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCountry" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                NTN
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbNTN" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="105px">
                                Phone
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbPhone" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label1" runat="server" Text="Fax" Width="75px"></asp:Label>
                                <telerik:RadTextBox ID="tbBusinessFax" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                City
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCity" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="105px">
                                Address
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbAddress" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Business Type
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBusinessType" runat="server" Width="150px">
                                </telerik:RadComboBox>
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
                    Contact Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="105px">
                                Name
                            </td>
                            <td class="style4">
                                <telerik:RadTextBox ID="tbName" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style5">
                                CNIC
                            </td>
                            <td class="style6">
                                <telerik:RadTextBox ID="tbCNIC" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style7">
                                CNIC Expiry Date
                            </td>
                            <td>
                                &nbsp;
                                <telerik:RadDatePicker ID="dtCNIC" Runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="105px">
                                Email
                            </td>
                            <td class="style4">
                                <telerik:RadTextBox ID="tbEmail" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style5">
                                Cell
                            </td>
                            <td class="style6">
                                <telerik:RadTextBox ID="tbCell" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style7">
                                Department
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbDepartment" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="105px">
                                Desig.
                            </td>
                            <td class="style4">
                                <telerik:RadTextBox ID="tbDesignation" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style5">
                                Office
                            </td>
                            <td class="style6">
                                <telerik:RadTextBox ID="tbOffice" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style7">
                                Fax
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbContactFax" runat="server" Width="150px">
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
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Document Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="105px">
                                <asp:CheckBox ID="cbBCase" runat="server" Text="BCase" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FUBCase" runat="server" Width="330px" />
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
                    Other Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Signup Date
                            </td>
                            <td class="style8">
                                <telerik:RadDatePicker ID="dtSignup" runat="server" Width="150px">
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style9">
                                CPM Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtCPM" runat="server" Width="150px">
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style10">
                                Working Days
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCMSID0" runat="server" Text="0" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                RFS Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtRFS" runat="server" Width="150px">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Customer Code
                            </td>
                            <td class="style8">
                                <telerik:RadComboBox ID="cmbCustomerCode" runat="server" AutoPostBack="True"
                                    Width="150px" CausesValidation="False" 
                                    onselectedindexchanged="cmbCustomerCode_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style9">
                                Project Code
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbProjectCode" runat="server" Width="150px" CausesValidation="False">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style10">
                                Location Code
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbLocationCode" runat="server" CausesValidation="False"
                                    Width="150px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Sales Person
                            </td>
                            <td class="style8">
                                <telerik:RadComboBox ID="cmbSalesPerson" runat="server" Width="150px" CausesValidation="False">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbSalesPerson"
                                    Display="None" ErrorMessage="Sales Person Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style9">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style10">
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
                            <td width="75px">
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
                                <telerik:RadTextBox ID="tbCMSID" runat="server" Text="0" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;Reference Partner ID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbPartnerID" runat="server" Text="0" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2" width="75px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Reference GPID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbGPID" runat="server" Text="0" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style2" width="75px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Reference Contract ID
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbContractID" runat="server" Text="0" Width="150px">
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
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
                            <td width="105px">
                                Connectivity Type
                            </td>
                            <td>
                                <asp:CheckBoxList ID="cbConnectivityType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                    Width="400px">
                                    <asp:ListItem>IPLC</asp:ListItem>
                                    <asp:ListItem>DPLC</asp:ListItem>
                                    <asp:ListItem>P2P</asp:ListItem>
                                    <asp:ListItem>LocalAccess</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bandwidth Type
                            </td>
                            <td>
                                <asp:CheckBox ID="cbE1" runat="server" Text="E1" />
                                &nbsp;
                                <telerik:RadComboBox ID="cmbE1" runat="server" Width="50px">
                                </telerik:RadComboBox>
                                &nbsp;
                                <asp:CheckBox ID="cbE3DS3" runat="server" Text="E3/DS3" />
                                &nbsp;
                                <telerik:RadComboBox ID="cmbE3DS3" runat="server" Width="50px">
                                </telerik:RadComboBox>
                                &nbsp;
                                <asp:CheckBox ID="cbSTM" runat="server" Text="STM-1" />
                                &nbsp;
                                <telerik:RadComboBox ID="cmbSTM" runat="server" Width="50px">
                                </telerik:RadComboBox>
                                &nbsp;
                                <asp:CheckBox ID="cbOther" runat="server" Text="Other" />
                                &nbsp;
                                <telerik:RadTextBox ID="tbOther" runat="server">
                                </telerik:RadTextBox>
                                &nbsp;
                                <telerik:RadComboBox ID="cmbOther" runat="server" Width="50px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Additional Services
                            </td>
                            <td>
                                <asp:CheckBox ID="cbVOIP" runat="server" Text="VOIP" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbVC" runat="server" Text="VC" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbVPN" runat="server" Text="VPN" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="cbExtraIP" runat="server" Text="Extra IP" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold;">
                    Service Configuration
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Circuit Speed
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCircuitSpeed" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Site A (Type of Interface)
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbSiteA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="120px">
                                Contract Period
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbContractPeriod" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Site B (Type of Interface)
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbSiteB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold;">
                    Company A Installation Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Company (A)
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbCompanyA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblCellA" runat="server" Text="Cell No.#" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbCellA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Country
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCountryA" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbPhoneA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblEmailA" runat="server" Text="Email" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbEmailA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Fax
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbFaxA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbAddressA" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                City
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCityA" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="color: #FFFFFF; font-weight: bold;">
                    Company B Installation Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Company (B)
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbCompanyB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblCellB" runat="server" Text="Cell No.#" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbCellB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Country
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCountryB" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbPhoneB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblEmailB" runat="server" Text="Email" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbEmailB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Fax
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbFaxB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbAddressB" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                City
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCityB" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style11">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style11">
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
                        />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Company</td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbBICompany" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblBICell" runat="server" Text="Contact Person" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbBIContactPerson" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Country
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICountry" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbBIPhone" runat="server" Width="150px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblBIEmail" runat="server" Text="Email" Width="80px"></asp:Label>
                                <telerik:RadTextBox ID="tbBIEmail" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Postal Code</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIPostalCode" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td class="style11">
                                <telerik:RadTextBox ID="tbBIAddress" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                City
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBICity" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                Currency</td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICurrency" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                Payment Type</td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIPaymentType" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                Payment Term</td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIPaymentTerm" runat="server" Width="150px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                MRC Amt.</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIMRC" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                OTC Amt.</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIOTC" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Total</td>
                            <td>
                                <telerik:RadTextBox ID="tbBITotal" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Infra Cost</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIInfraCost" runat="server" Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Eqp/Port Cost</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIEquipmentCost" runat="server" Width="60px">
                                </telerik:RadTextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <telerik:RadTextBox ID="tbBIPortCost" runat="server" Width="60px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Payback</td>
                            <td>
                                <telerik:RadTextBox ID="tbBIPayback" runat="server" Width="150px">
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
                            <td width="120px">
                                Site Nature
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbBISiteNature" runat="server" RepeatDirection="Horizontal">
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
                            <td>
                                Project OTC
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectOTC" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Project Investment
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbBIProjectInvestment" runat="server" Text="0">
                                </telerik:RadTextBox>
                            </td>
                            <td>
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
                            <td width="120px">
                                Circuit Owner
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICircuitOwner" runat="server" AutoPostBack="True"
                                    CausesValidation="False" 
                                    onselectedindexchanged="cmbBICircuitOwner_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="cmbBICircuitOwner"
                                    Display="None" ErrorMessage="Billing Information Requires Circuit Owner" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <asp:Panel ID="pnlBIThirdPartyCharges" runat="server" Visible = "false">
                                <td>
                                    3rd Party Name
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbBI3rdPartyName" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Party OTC
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbBIPartyOTC" runat="server" Text="0">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    Party MRC
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbBIPartyMRC" runat="server" Text="0">
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
                            <td width="120px">
                                Circuit Type
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBICircuitType" runat="server" AutoPostBack="True"
                                    CausesValidation="False" 
                                    onselectedindexchanged="cmbBICircuitType_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="cmbBICircuitType"
                                    Display="None" ErrorMessage="Billing Information Requires Circuit Type" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblBIBackupInfra" runat="server" Visible="false" Text="Backup Infra"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIBackupInfra" Visible="False" runat="server">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Please-Select" Value="0" />
                                        <telerik:RadComboBoxItem runat="server" Text="TDM" Value="TDM" />
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
                                <asp:Label ID="lblBIBackupOwner" runat="server" Text="Backup Owner" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbBIBackupOwner" runat="server" Visible="false" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="cmbBIBackupOwner_SelectedIndexChanged" CausesValidation="False"
                                    >
                                </telerik:RadComboBox>
                            </td>
                            <asp:Panel ID="pnlBackupCharges" runat="server" Visible="false">
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
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
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
</telerik:RadMultiPage>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
    ShowSummary="false" />
