<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="RainMaker.WebForm13" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</telerik:RadStyleSheetManager>
                <telerik:RadScriptManager ID="RadScriptManager2" Runat="server">
                </telerik:RadScriptManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   Add Customer</h6>
            </div>
        </div>
        <table class="style1">

        <%--Table Header--%>

         <%--Default Row--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td align="center" colspan="6" 
                style="font-size: x-large; font-weight: bold; color: #000066;">
                Create Customer</td>
        </tr>

         <%--First Row--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td align="center" colspan="6">
                &nbsp;</td>
        </tr>

         <%--Second Row--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style3">
               <asp:Label ID="lbl_CustomerName" runat="server" CssClass="lbl" Width="145px" Text="Customer Name" /></td>
            <td>
                <telerik:RadComboBox ID="cmbCustCode" Runat="server">
                </telerik:RadComboBox>
            </td>
            
            <td class="style4">
                <asp:Label ID="lblCity" runat="server" Width="145px" CssClass="lbl" Text="City"/></td>
            <td class="style5">
                   <telerik:RadComboBox ID="cmbCity" runat="server" AutoPostBack="true" Width="145px"></telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="lblTitle" runat="server" Width="145px" CssClass="lbl" Text="Customer Title"/></td>
            <td>
              <telerik:RadComboBox ID="cmbCusstTitle" runat="server" AutoPostBack="true" Width="145px"></telerik:RadComboBox></td>
        </tr>

          <%--Third Row--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style3">
               <asp:Label ID="lblCustName" runat="server" Width="145px" CssClass="lbl" Text="Customer Name" /></td>
            <td>
                <telerik:RadTextBox ID="txtCustName" runat="server" Width="145px"> </telerik:RadTextBox>
   
                
            </td>
            <td class="style4">
               <asp:Label ID="lblContact" runat="server" Width="145px" CssClass="lbl" Text="Customer Contact" /></td>
            <td class="style5">
                <telerik:RadTextBox ID="txtCusContact" runat="server" Width="145px"></telerik:RadTextBox>
            </td>
            <td>
               <asp:Label ID="lblCustEmail" runat="server" Width="145px" CssClass="lbl" Text="Customer Email" /></td>
            <td>
                 <telerik:RadTextBox ID="txtCustEmail" runat="server" Width="145px"></telerik:RadTextBox>
               </td>
        </tr>

          <%--<td class="style4">
               <asp:Label ID="lbl_IsActive" runat="server" Width="145px" CssClass="lbl" Text="Active" /></td>
            <td class="style5">
                <asp:CheckBox ID="chk_IsActive" runat="server" Width="145px"/>
            </td>--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style3">
               <asp:Label ID="lblCustMobile" runat="server" Width="145px" CssClass="lbl" Text="Customer Mobile" /></td>
            <td>
                <telerik:RadTextBox ID="txtCustMobile" runat="server" Width="145px"></telerik:RadTextBox>
                       
            </td>

            <td class="style2">
               <asp:Label ID="lblCustAddress" runat="server" Width="145px" CssClass="lbl" Text="Customer Address" /></td>
            <td>
                <telerik:RadTextBox ID="txtCustAddress" runat="server" Width="145px"></telerik:RadTextBox>
                       
            </td>

              
             <td class="style4"><asp:Label ID="lblGender" runat="server" Width="145px" CssClass="lbl" Text="Gender"  /></td>

            <td class="style5">
                <telerik:RadComboBox ID="cmbGender" runat="server" AutoPostBack="True" Width="145px" Skin="Office2007">   
                <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Please-Select" Value="PS" />
                            <telerik:RadComboBoxItem runat="server" Text="Male" Value="Male" />
                            <telerik:RadComboBoxItem runat="server" Text="Female" Value="Female" />
                            
                        </Items>                    
                    </telerik:RadComboBox>
            </td>

            <%--Fourth Row--%>
            
        </tr>

          <%--Fourth Row--%>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblCustContactType" runat="server" Width="145px" CssClass="lbl" Text="Contact Type"/></td>
           
            <td>
                <telerik:RadComboBox ID="cmbCustContactType" runat="server" AutoPostBack="True" Skin="Office2007" Width="145px"></telerik:RadComboBox>
               

            </td>
           
            <td class="style4"><asp:Label ID="lblReligion" runat="server" Width="145px" CssClass="lbl" Text="Religion"  /></td>
            
            <td class="style5">
                <telerik:RadComboBox ID="cmbReligion" runat="server" AutoPostBack="True" Width="145px" Skin="Office2007">                       
                    </telerik:RadComboBox>
            </td>

            <td>&nbsp;</td>


        </tr>

        <tr>
          <td class="style6">
                &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
          </tr>

        <tr font-italic="True">
        <td class="style6">
                &nbsp;</td>
        <td class="style3"><asp:Label ID="lblNotification" runat="server" Width="145px" CssClass="lbl" Text="Note:" ForeColor="Black" Font-Size="XX-Small" Font-Italic="True" /></td>
        <td class="style6" colspan="7"><telerik:RadButton ID="btnSave"  Text="Save Record" runat="server"></telerik:RadButton></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
            
        </tr>
        
      
        </table>
</asp:Content>
