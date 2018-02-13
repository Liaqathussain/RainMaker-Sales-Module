<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="RainMaker.WebForm6" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   Create Appointment</h6>
            </div>
        </div>
    <div class="container-fluid">
    <table class="style1">
        <tr>
            <td class="style6" colspan="7">
        
        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Skin="Office2007"
            ValidationGroup="ValidationProduct" onbuttonclick="RadToolBar1_ButtonClick"  >
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
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                Subject</td>
            <td class="style3">
                <telerik:RadTextBox ID="txtSubject" Runat="server" Width="140px">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator1" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtSubject" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                Customer Code</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbCustomerCode" Runat="server" Width="145px" autopostback="true"
                    onselectedindexchanged="cmbCustomerCode_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                Activity Owner</td>
            <td>
                <telerik:RadTextBox ID="cmbActivityOwner" Runat="server" Width="140px" 
                    ReadOnly="True">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                Address</td>
            <td class="style3">
                <telerik:RadTextBox ID="txtAddress" Runat="server" Width="140px">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator2" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtAddress" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                Contact</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbContact" Runat="server" Width="145px">
                </telerik:RadComboBox>
            </td>
            <td>
                Activity Status</td>
            <td>
                <telerik:RadComboBox ID="cmbActivityStatus" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator4" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbActivityStatus" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                Type</td>
            <td class="style3">
                <telerik:RadComboBox ID="cmbActivityType" Runat="server" Width="145px">
                </telerik:RadComboBox>
                 <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator10" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbActivityType" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                Opportunity</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbOpportunity" Runat="server" Width="145px">
                </telerik:RadComboBox>
            </td>
            <td>
                Closure Remarks</td>
            <td>
                <telerik:RadComboBox ID="RadCloserRemarks" Runat="server" Width="145px" 
                    onselectedindexchanged="RadCloserRemarks_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                Activity Date</td>
            <td class="style3">
                <telerik:RadDatePicker ID="DTActivityDate" Runat="server">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator3" ValidationGroup="ValidationProduct"
                             ControlToValidate="DTActivityDate" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>

            </td>
            <td class="style4">
                Attachement</td>
            <td class="style5">
                <telerik:RadAsyncUpload ID="RadAttachment" runat="server" Height="24px" 
                    Width="216px">
                </telerik:RadAsyncUpload>
            </td>
            <td>
                Activity Time</td>
            <td>
                <telerik:RadTimePicker ID="txtActivityTime" Runat="server">
                </telerik:RadTimePicker>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator5" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtActivityTime" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                Remarks</td>
            <td class="style3" colspan="3" rowspan="4">
                <telerik:RadTextBox ID="txtRemarks" Runat="server" Width="520px" 
                    AutoCompleteType="Cellular" Height="70px" TextMode="MultiLine" 
                    ontextchanged="txtRemarks_TextChanged">
                </telerik:RadTextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
      
         <telerik:RadGrid ID="GVActivity" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" onitemcommand="GVActivity_ItemCommand1" 
        onneeddatasource="GVActivity_NeedDataSource1" Skin="Office2007" 
        Width="100%" PageSize="50" Height="250px">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" 
                    Text="Select" UniqueName="column1">
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
        <PagerStyle Mode="NextPrev" />
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>
     <br />
</asp:Content>
