<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quota.aspx.cs" Inherits="RainMaker.WebForm9" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" Runat="server">
    </telerik:RadStyleSheetManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   Manage Sales Quotas</h6>
            </div>
        </div>
    <div class="container-fluid">
    <table class="style1">
    <tr>
        <td align="center" style="font-size: large" class="style28" colspan="7">
        
        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Skin="Office2007"
            ValidationGroup="ValidationProduct" onbuttonclick="RadToolBar1_ButtonClick" >
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SaveIcon.png" Text="Save" ValidationGroup="ValidationProduct">
                </telerik:RadToolBarButton>
            </Items>
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/SaveIcon.png" Text="Update" ValidationGroup="ValidationProduct">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
                </td>
    </tr>
    
    <tr>
        <td align="center" style="font-size: large" class="style21">
                    &nbsp;</td>
        <td align="center" colspan="6" style="font-size: large">
                    &nbsp;</td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style29">
            <span>Plan Name</span></td>
        <td class="style26">
            <telerik:RadTextBox ID="txtQuotaPlanName" Runat="server" Width="140px">
            </telerik:RadTextBox>
            <%--<asp:RequiredFieldValidator ID="req1" runat="server" ForeColor ="Red" ControlToValidate="txtQuotaPlanName" Text="*" />--%>

        </td>
        <td class="style25">LOB</td>
        <td class="style27" >
            <telerik:RadComboBox ID="cmbLOB" Runat="server" 
                onselectedindexchanged="cmbLOB_SelectedIndexChanged" Width="145px">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Territory" Value="Territory" 
                        Owner="cmbLOB" />
                    <telerik:RadComboBoxItem runat="server" Text="Resources" Value="Resources" 
                        Owner="cmbLOB" />
                </Items>
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor ="Red" ControlToValidate="cmbLOB" Text="*" />
        </td>
        <td class="style6">
            <span style="letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none; ht: normal;">Quota 
            Amount</span></td>
        <td>
            <telerik:RadTextBox ID="txtTerritoryQuota" Runat="server" Width="140px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style22">
                    &nbsp;</td>
        <td class="style19">
                    Region Name</td>
        <td class="style26">
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor ="Red" ControlToValidate="txtTerritoryQuota" Text="*" />--%>
            <telerik:RadComboBox ID="RegionName" Runat="server" AutoPostBack="true"
                onselectedindexchanged="TerritoryName_SelectedIndexChanged" Width="145px">
            </telerik:RadComboBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor ="Red" ControlToValidate="RegionName" Text="*" />
        </td>
        <td class="style25">
                    Domain</td>
        <td class="style27">
            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor ="Red" ControlToValidate="DTStartDate" Text="*" />--%>
            <telerik:RadComboBox ID="cmbDomain" Runat="server"  AutoPostBack ="true"
                onselectedindexchanged="cmbDomain_SelectedIndexChanged" Width="140px">
            </telerik:RadComboBox>
        </td>
        <td class="style6">
                    Start Date</td>
        <td>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor ="Red" ControlToValidate="DTEndDate" Text="*" />--%>
            <telerik:RadDatePicker ID="DTStartDate" Runat="server" Culture="en-US" 
                Width="145px">
                
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"></DateInput>

                

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
                    Region Owner</td>
        <td class="style10">
            <telerik:RadComboBox ID="cmbTerritoryOwner" Runat="server" Width="145px" 
                onselectedindexchanged="cmbTerritoryOwner_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor ="Red" ControlToValidate="cmbTerritoryOwner" Text="*" />
        </td>
        <td class="style11">
                    Owner Quotas</td>
        <td class="style12">
            <telerik:RadTextBox ID="txtOwnerQuotas" Runat="server" Width="140px">
            </telerik:RadTextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor ="Red" ControlToValidate="txtOwnerQuotas" Text="*" />--%>
        </td>
        <td class="style13">
            <span>Status</span></td>
        <td class="style14">
            <telerik:RadComboBox ID="cmbStatus" Runat="server" Width="140px">
            </telerik:RadComboBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor ="Red" ControlToValidate="cmbStatus" Text="*" />
        </td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
            <span>End Date</span></td>
        <td class="style10">
            <telerik:RadDatePicker ID="DTEndDate" Runat="server" Width="145px">
            </telerik:RadDatePicker>
        </td>
        <td class="style11">
                    Service Unit ID</td>
        <td class="style12">
            <telerik:RadComboBox ID="cmbServiceUnitID" Runat="server" Width="145px">
            </telerik:RadComboBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style14">
                    <telerik:RadButton ID="btnSaveTerritory" runat="server" 
                        onclick="btnSaveTerritory_Click" Text="Save" Width="60px">
                    </telerik:RadButton>
        </td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
            &nbsp;</td>
        <td class="style10" style="font-weight: bold">
            &nbsp;</td>
        <td class="style11">
                    &nbsp;</td>
        <td class="style12" style="font-weight: bold">
            &nbsp;</td>
        <td class="style13">
                    &nbsp;</td>
        <td class="style14" style="font-weight: bold">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23" colspan="7">
                    <telerik:RadGrid ID="GVQuotas" runat="server" GridLines="None" 
                        onitemcommand="GVQuotas_ItemCommand" onneeddatasource="GVQuotas_NeedDataSource">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridButtonColumn CommandName="Select" Text="Select" 
            UniqueName="column">
        </telerik:GridButtonColumn>
    </Columns>
</MasterTableView>

<HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                    </telerik:RadGrid>
        </td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
            &nbsp;</td>
        <td class="style10" style="font-weight: bold">
            &nbsp;</td>
        <td class="style11">
                    &nbsp;</td>
        <td class="style12" style="font-weight: bold">
            &nbsp;</td>
        <td class="style13" style="font-weight: bold">
                    &nbsp;</td>
        <td class="style14" style="font-weight: bold">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
            Fiscal Year</td>
        <td class="style10" style="font-weight: bold">
            <telerik:RadComboBox ID="cmbFiscalyear" Runat="server"  AutoPostBack ="true"
                onselectedindexchanged="cmbFiscalyear_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
        <td class="style11">
                    Region Name</td>
        <td class="style12" style="font-weight: bold">
            <telerik:RadComboBox ID="cmbQRegionName" Runat="server" 
                onselectedindexchanged="cmbQRegionName_SelectedIndexChanged" Width="145px">
            </telerik:RadComboBox>
        </td>
        <td class="style13" style="font-weight: bold">
                    Domain</td>
        <td class="style14" style="font-weight: bold">
            <telerik:RadComboBox ID="cmbQDomain" Runat="server" Width="145px">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="style23">
                    &nbsp;</td>
        <td class="style30">
                    <asp:Label ID="Label1" runat="server" Text="Regional Quota" 
                Font-Bold="False"></asp:Label>
        </td>
        <td class="style10" style="font-weight: bold">
            <asp:Label ID="lblTerritoryQuota" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style11">
                    &nbsp;</td>
        <td class="style12" style="font-weight: bold">
            &nbsp;</td>
        <td class="style13" style="font-weight: bold">
                    &nbsp;</td>
        <td class="style14" style="font-weight: bold">
            <telerik:RadButton ID="btnSearchQ" runat="server" onclick="btnSearchQ_Click" 
                Text="Search">
            </telerik:RadButton>
        </td>
    </tr>
    </table>
    <table class="style1">
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24" style="font-weight: bold">
                    Month</td>
        <td class="style3" style="font-weight: bold">
                    Start Date</td>
        <td class="style8" style="font-weight: bold">
                    End Date</td>
        <td class="style5" style="font-weight: bold">
                    Fiscal Year</td>
        <td class="style6" style="font-weight: bold">
                    Amount</td>
        <td>
                    Percentage</td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style7" colspan="6">
                    <asp:Label ID="lblQuarter1" runat="server" Font-Bold="True" Text="Quarter1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month1" Runat="server" Text="Jan">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate1" Runat="server" SelectedDate="2017-01-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-01-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate1" Runat="server" SelectedDate="2017-01-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-01-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear1" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount1" Runat="server"  AutoPostBack="true"
                ontextchanged="txtAmount1_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage1" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month2" Runat="server" Text="Feb">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate2" Runat="server" SelectedDate="2017-02-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-02-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate2" Runat="server" SelectedDate="2017-02-28">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-02-28"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear2" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount2" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount2_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage2" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month3" Runat="server" Text="Mar">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate3" Runat="server" SelectedDate="2017-03-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-03-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate3" Runat="server" SelectedDate="2017-03-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-03-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear3" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount3" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount3_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage3" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style7" colspan="6">
                    <asp:Label ID="lblQuarter2" runat="server" Font-Bold="True" Text="Quarter2"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month4" Runat="server" Text="Apr">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate4" Runat="server" SelectedDate="2017-04-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-04-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate4" Runat="server" SelectedDate="2017-04-30">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-04-30"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear4" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount4" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount4_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage4" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month5" Runat="server" Text="May">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate5" Runat="server" SelectedDate="2017-05-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-05-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate5" Runat="server" SelectedDate="2017-05-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-05-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear5" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount5" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount5_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage5" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month6" Runat="server" Text="Jun">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate6" Runat="server" SelectedDate="2017-06-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-06-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate6" Runat="server" SelectedDate="2017-06-30">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-06-30"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear6" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount6" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount6_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage6" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style7" colspan="6">
                    <asp:Label ID="lblQuarter3" runat="server" Font-Bold="True" Text="Quarter3"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month7" Runat="server" Text="Jul">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate7" Runat="server" SelectedDate="2017-07-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-07-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate7" Runat="server" SelectedDate="2017-07-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-07-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear7" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount7" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount7_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage7" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month8" Runat="server" Text="Aug">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate8" Runat="server" SelectedDate="2017-08-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-08-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate8" Runat="server" SelectedDate="2017-08-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-08-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear8" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount8" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount8_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage8" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month9" Runat="server" Text="Sep">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate9" Runat="server" SelectedDate="2017-09-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-09-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate9" Runat="server" SelectedDate="2017-09-30">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-09-30"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear9" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount9" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount9_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage9" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style7" colspan="6">
                    <asp:Label ID="lblQuarter4" runat="server" Font-Bold="True" Text="Quarter4"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month10" Runat="server" Text="Oct">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate10" Runat="server" 
                SelectedDate="2017-10-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-10-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate10" Runat="server" SelectedDate="2017-10-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-10-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear10" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount10" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount10_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage10" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month11" Runat="server" Text="Nov">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate11" Runat="server" 
                SelectedDate="2017-11-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-11-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate11" Runat="server" SelectedDate="2017-11-30">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-11-30"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear11" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount11" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount11_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage11" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
            <telerik:RadTextBox ID="Month12" Runat="server" Text="Dec">
            </telerik:RadTextBox>
        </td>
        <td class="style3">
            <telerik:RadDatePicker ID="StartDate12" Runat="server" 
                SelectedDate="2017-12-01">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-12-01"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style8">
            <telerik:RadDatePicker ID="EndDate12" Runat="server" SelectedDate="2017-12-31">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" SelectedDate="2017-12-31"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
        <td class="style5">
            <telerik:RadTextBox ID="txtFiscalYear12" Runat="server">
            </telerik:RadTextBox>
        </td>
        <td class="style6">
            <telerik:RadTextBox ID="txtAmount12" Runat="server" AutoPostBack="true"
                ontextchanged="txtAmount12_TextChanged">
            </telerik:RadTextBox>
        </td>
        <td>
            <telerik:RadTextBox ID="txtPercentage12" Runat="server">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style21">
                    &nbsp;</td>
        <td class="style24">
                    &nbsp;</td>
        <td class="style3">
                    &nbsp;</td>
        <td class="style8">
                    &nbsp;</td>
        <td class="style5">
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style6">
            &nbsp;</td>
        <td>
            
                    <asp:Label ID="lblTotalTarget" runat="server" Font-Bold="True" Text="0"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
