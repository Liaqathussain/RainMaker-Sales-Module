<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="RainMaker.WebForm8" %>

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
                   Manage Users</h6>
            </div>
        </div>
    <div class="container-fluid">
    <table class="style1">
        <tr>
            <td align="center" class="style3" style="font-size: large" colspan="7">
        
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
            <td class="style3">
                &nbsp;</td>
            <td class="style19">
                Name</td>
            <td class="style21">
                <telerik:RadTextBox ID="txtName" Runat="server" Width="145px"  
                    AutoPostBack="true">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator1" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtName" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
                
            </td>
            <td class="style8">
                Email</td>
            <td class="style6">
                <telerik:RadTextBox ID="txtEmail" Runat="server" Width="145px">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator11" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtEmail" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
            </td>
            <td class="style7">
                Phone</td>
            <td>
                <telerik:RadTextBox ID="txtPhone" Runat="server" Width="145px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="style13">
                </td>
            <td class="style20">
                User Name</td>
            <td class="style22">
                <telerik:RadTextBox ID="txtUserName" Runat="server" Width="145px">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator2" ValidationGroup="ValidationProduct"
                             ControlToValidate="txtUserName" ErrorMessage="*"
                              ForeColor="#FF3300">
                 </asp:RequiredFieldValidator>
            </td>
            <td class="style16">
                Password</td>
            <td class="style17">
                <telerik:RadTextBox ID="txtpassword" Runat="server" Width="145px" 
                    TextMode="Password">
                </telerik:RadTextBox>
            </td>
            <td class="style18">
                Status</td>
            <td class="style13">
                <telerik:RadComboBox ID="lbluserStatus" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator5" ValidationGroup="ValidationProduct"
                             ControlToValidate="lbluserStatus" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style5">
                Department</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbDepartment" Runat="server" Width="145px">
                </telerik:RadComboBox>
                  <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator10" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbDepartment" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
            <td class="style5">
                LOB</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbLOB" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator4" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbLOB" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>

            </td>
            <td class="style5">
                Region</td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbRegion" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator8" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbRegion" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                </td>
            <td class="style2">
                Designation</td>
            <td class="style2">
                <telerik:RadComboBox ID="cmbDesignation" Runat="server" Width="145px">
                </telerik:RadComboBox>
                 <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator7" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbDesignation" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                Sub Department</td>
            <td class="style2">
                <telerik:RadComboBox ID="cmbSubDeptName" Runat="server" Width="145px">
                </telerik:RadComboBox>

            </td>
            <td class="style2">
                Domain</td>
            <td class="style2">
                <telerik:RadComboBox ID="cmbDomain" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator9" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbDomain" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                </td>
            <td class="style4">
                Resource Role</td>
            <td class="style4">
                <telerik:RadComboBox ID="cmbResourceRole" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator3" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbResourceRole" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                Reporting Manager</td>
            <td class="style4">
                <telerik:RadComboBox ID="cmbReportingManager" Runat="server" Width="145px">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" 
                             ID="RequiredFieldValidator6" ValidationGroup="ValidationProduct"
                             ControlToValidate="cmbReportingManager" ErrorMessage="*"
                             InitialValue="Please Select" ForeColor="#FF3300">
                   </asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9" colspan="6">
                 <asp:Label ID="Label1" runat="server" ForeColor="#009933" Text="Label"></asp:Label></td>
        </tr>
        </table>
         <telerik:RadGrid ID="GVUsers" runat="server" GridLines="None" 
        oninsertcommand="GVUsers_InsertCommand" onitemcommand="GVUsers_ItemCommand" 
        onneeddatasource="GVUsers_NeedDataSource" 
        AllowSorting="True" PageSize="50">
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
    <Columns>
        <telerik:GridButtonColumn CommandName="Select" Text="Select" 
            UniqueName="column">
        </telerik:GridButtonColumn>
    </Columns>
</MasterTableView>

<HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
</asp:Content>
