<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="RainMaker.BSS_Administration.CreateAccount" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<style scoped>
        td
        {
            padding-top: 5px;
        }
    </style>
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:radscriptmanager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                    Create Account</h6>
            </div>
        </div>
        <div class="container">
        </div>
        </div>

        <table class="style1">
        <tr>
            <td class="style6" colspan="7">
        
        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Skin="Office2007"
            ValidationGroup="ValidationAccount" onbuttonclick="RadToolBar1_ButtonClick" OnClientButtonClicked="OnClientButtonClicked"  >
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
            <td align="center" colspan="6" style="font-size: x-large; font-weight: bold;">
                Create Account</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td align="center" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
               <asp:Label ID="lbl_CustomerName" runat="server" CssClass="lbl" Text="Customer Name" /></td>
            <td>
               <telerik:RadTextBox ID="txtCustomerName" runat="server">
                    </telerik:RadTextBox>
                    <asp:Label ID="lbl_CustomerNameMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
               
            </td>
            <td class="style4">
                <asp:Label ID="lbl_PhoneNo" runat="server" CssClass="lbl" Text="Phone No #" /></td>
            <td class="style5">
                <telerik:RadTextBox ID="txtPhoneNo"  runat="server">
                    </telerik:RadTextBox>
                   <%-- <telerik:RadNumericTextBox ID="txtPhoneNo" runat="server">
                    </telerik:RadNumericTextBox>--%>
                    <asp:Label ID="lbl_PhoneMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
            </td>
            <td>
               <asp:Label ID="lbl_Logo" runat="server" CssClass="lbl" Text="Logo" /></td>
            <td>
            <telerik:RadTextBox ID="txtAsyncUpload" runat="server" Text=""/>
                <telerik:RadAsyncUpload ID="RadAttachment" runat="server" Height="24px" 
                    Width="216px">
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
               <asp:Label ID="lbl_EmailAddress" runat="server" CssClass="lbl" Text="Email Address" /></td>
            <td>
                <telerik:RadTextBox ID="txtEmailAddress" runat="server">
                    </telerik:RadTextBox>
                    <asp:Label ID="lbl_EmailAddressMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
                    <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Please enter valid e-mail address" ValidationGroup ="ValidationAccount" SetFocusOnError="true" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                ControlToValidate="txtEmailAddress">
                            </asp:RegularExpressionValidator>
                
            </td>
            <td class="style4">
               <asp:Label ID="lbl_Country" runat="server" CssClass="lbl" Text="Country" /></td>
            <td class="style5">
                <telerik:RadTextBox ID="txtCountry" runat="server">
                    </telerik:RadTextBox>
                    <asp:Label ID="lbl_CountryMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
            </td>
            <td>
                <asp:Label ID="lbl_State" runat="server" CssClass="lbl" Text="State" /></td>
            <td>
                <telerik:RadTextBox ID="txtState" runat="server">
                    </telerik:RadTextBox>
                    <asp:Label ID="lbl_StateMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
                
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
               <asp:Label ID="lbl_City" runat="server" CssClass="lbl" Text="City" /></td>
            <td>
                <telerik:RadTextBox ID="txtCity" runat="server">
                    </telerik:RadTextBox>
                    <asp:Label ID="lbl_CityMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
                 
            </td>
            <td class="style4">
               <asp:Label ID="lbl_IsActive" runat="server" CssClass="lbl" Text="Is Active" /></td>
            <td class="style5">
                <asp:CheckBox ID="chk_IsActive" runat="server" />
            </td>
            
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="lbl_AccountType" runat="server" CssClass="lbl" Text="Account Type"/></td>
            <td>
                <telerik:RadComboBox ID="cmbAccountType" runat="server" AutoPostBack="True" Skin="Office2007"
                        Width="145px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Normal" Value="Normal" />
                            <telerik:RadComboBoxItem runat="server" Text="Partner" Value="Partner" />
                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Please Select" 
                                Value="Please Select" />
                        </Items>
                    </telerik:RadComboBox>
               

            </td>
            <td class="style4">
                <asp:Label ID="lbl_Domain" runat="server" CssClass="lbl" Text="Domain"  /></td>
            <td class="style5">
                <telerik:RadComboBox ID="cmbDomain" runat="server" AutoPostBack="True" Width="145px" Skin="Office2007">                       
                    </telerik:RadComboBox>
            </td>
            
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
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
                Remarks</td>
            <td class="style3" colspan="3" rowspan="4">
                <telerik:RadTextBox ID="txtRemarks" Runat="server" Width="520px" 
                    AutoCompleteType="Cellular" Height="70px" TextMode="MultiLine">
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

         <tr>
            <td class="style6">
                &nbsp;</td>
            <td align="center" colspan="6" style="font-size: x-large; font-weight: bold;">
                Search Account</td>
        </tr>

            <tr>
            <td class="style6">
                &nbsp;</td>
            
            <td class="style6">
             <asp:Label ID="lbl_CustomerNameS" runat="server" CssClass="lbl" Text="Customer Name" /></td>
                    
               
                <td>
                    <telerik:RadTextBox ID="txtCustomerNameS" runat="server">
                    </telerik:RadTextBox>
                    <td>
                    <asp:Button ID="btnSearchCustomer" runat="server" Text="Search Customer" onclick="btnSearchCustomer_Click" />
                    </td>
                    
                </td>
                
            </tr>

        </table>
    <br />
    <telerik:RadGrid ID="GVAccount" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" onitemcommand="GVAccount_ItemCommand" 
        onneeddatasource="GVAccount_NeedDataSource" Skin="Office2007" 
        Width="100%">
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

     <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">


            function OnClientButtonClicked(sender, args) {


                var CustomerName = document.getElementById('<%=txtCustomerName.ClientID %>').value;
                var Phone = document.getElementById('<%=txtPhoneNo.ClientID %>').value;
                var EmailAddress = document.getElementById('<%=txtEmailAddress.ClientID %>').value;
                var Country = document.getElementById('<%=txtCountry.ClientID %>').value;
                var State = document.getElementById('<%=txtState.ClientID %>').value;
                var City = document.getElementById('<%=txtCity.ClientID %>').value;
                var AccountType = document.getElementById('<%=cmbAccountType.ClientID %>').value;
                var Domain = document.getElementById('<%=cmbDomain.ClientID %>').value;


                if (CustomerName == "") {
                    alert("CustomerName Name cannot be empty");
                    args.set_cancel(true);
                }

                if (Phone == "") {

                    alert("Phone Name cannot be empty");
                    args.set_cancel(true);
                }

                if (EmailAddress == "") {

                    alert("EmailAddress Name cannot be empty");
                    args.set_cancel(true);
                }

                if (Country == "") {

                    alert("Country Name cannot be empty");
                    args.set_cancel(true);
                }


                if (State == "") {

                    alert("State Name cannot be empty");
                    args.set_cancel(true);
                }

                if (City == "") {

                    alert("City Name cannot be empty");
                    args.set_cancel(true);
                }



                if (AccountType == 'Please Select') {
                    alert("Please Select AccountType");
                    args.set_cancel(true);
                }

                if (Domain == 'Please Select') {
                    alert("Please Select Domain");
                    args.set_cancel(true);
                }


            }

        </script>


        


        </telerik:RadCodeBlock>


</asp:Content>
