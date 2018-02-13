<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchForm.ascx.cs" Inherits="RainMaker.SearchForm" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>

<div class="row">
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background-color:#f66519;height:30px;"><h6 class="center-block" style="text-align:center;color:White;">ROOGLE</h6></div>
<div class="row"></div>
<div class=" pull-right form-text" style="margin-right:5em;">
    <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="Search Me">
    </telerik:RadButton>
     <telerik:RadButton ID="RadButton2" runat="server" OnClick="RadButton1_Click" Text="Export to Excel">
    </telerik:RadButton>
</div>
</div>

<div class="container-fluid">

<div class="row">
<div class="form-group">

<div class="col-lg-3 col-md-3 col-xs-6 col-sm-6 ">

<asp:Label ID="Label1" runat="server" Text="Sign Up ID"></asp:Label>
  <telerik:RadTextBox ID="tbSignup" runat="server"  CssClas="RadBox">
    </telerik:RadTextBox>
</div>


<div class="col-lg-3 col-md-3 col-xs-6 col-sm-6">
<asp:Label ID="Label2" runat="server" Text="BSS Code" CssClas="RadBox"></asp:Label>
<telerik:RadTextBox ID="tbBSSCode" runat="server">
    </telerik:RadTextBox>
</div>


<div class="col-lg-3 col-md-3 col-xs-6 col-sm-6 ">
<asp:Label ID="Label3" runat="server" Text="CMS ID" CssClas="RadBox"></asp:Label>
<telerik:RadTextBox ID="tbCMSID" runat="server">
    </telerik:RadTextBox>
</div>



<div class="col-lg-3 col-md-3 col-xs-6 col-sm-6 ">
<asp:Label ID="Label4" runat="server" Text="GPID" CssClas="RadBox"></asp:Label>
<telerik:RadTextBox ID="tbGPID" runat="server">
    </telerik:RadTextBox>
</div>

</div>
</div>


<div class="row">
<div class="form-group">

<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6  ">
<asp:Label ID="Label5" runat="server" Text="Circuit Type"></asp:Label>
<telerik:RadComboBox ID="cmbCircuitType" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>


<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
<telerik:RadComboBox ID="cmbCity" runat="server"  Width="124px">
</telerik:RadComboBox>
</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label7" runat="server" Text="Infra"></asp:Label>
<telerik:RadComboBox ID="cmbInfra" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label8" runat="server" Text="Service Unit"></asp:Label>
<telerik:RadComboBox ID="cmbService" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>

</div>
</div>


<div class="row">
<div class="form-group">

<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label9" runat="server" Text="Company Name"></asp:Label>
<telerik:RadTextBox ID="tbCompany" runat="server">
    </telerik:RadTextBox>
</div>


<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6">
<asp:Label ID="Label10" runat="server" Text="Circuit Owner"></asp:Label>
<telerik:RadComboBox ID="cmbCircuitOwner" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label11" runat="server" Text="Status"></asp:Label>
<telerik:RadComboBox ID="cmbStatus" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label12" runat="server" Text="Customer "></asp:Label>
<telerik:RadComboBox ID="cmbCustCode" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>

</div>
</div>

<div class="row">
<div class="form-group">

<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label13" runat="server" Text="Primary Node"></asp:Label>
<telerik:RadComboBox ID="cmbNode" runat="server"  Width="125px">
</telerik:RadComboBox>

</div>


<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label14" runat="server" Text="Ring"></asp:Label>
<telerik:RadComboBox ID="cmbRing" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label15" runat="server" Text="Primary Switch"></asp:Label>
<telerik:RadComboBox ID="cmbSwtich" runat="server" Width="125px">
</telerik:RadComboBox>

</div>



<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label16" runat="server" Text=" Switch Port"></asp:Label>
<telerik:RadComboBox ID="cmbSwitchPort" runat="server"  Width="125px">
</telerik:RadComboBox>
</div>

</div>
</div>

<div class="row">
<div class="form-group">

<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label17" runat="server" Text="Customer Ip Pool"></asp:Label>
<telerik:RadTextBox ID="tbCusIPPool" runat="server">
    </telerik:RadTextBox>
</div>


<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label18" runat="server" Text="Primary CPE IP"></asp:Label>
<telerik:RadTextBox ID="tbPriCEPIP" runat="server">
    </telerik:RadTextBox>

</div>


<div class="col-lg-3 col-md-4 col-xs-6 col-sm-6 ">
<asp:Label ID="Label19" runat="server" Text="Extra IP"></asp:Label>
<telerik:RadTextBox ID="tbExtra_IP" runat="server">
    </telerik:RadTextBox>
</div>



</div>
</div>
<div class="row">
<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ">
<asp:Label ID="Label20" runat="server" Text="Total Count :"></asp:Label><asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
</div>

</div>

<div class="table-responsive">
<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" Skin="Web20" >
    <ClientSettings>
        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
    </ClientSettings>
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
</MasterTableView>

<HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
</telerik:RadGrid>
</div>
</div>