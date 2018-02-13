<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NRFView.aspx.cs" Inherits="RainMaker.NRF.NRFView" %>

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

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		
	</telerik:RadScriptManager>

 <div id="page-wrapper">
    <div class="row">
        <div class="col-lg-12" style="background-color: #f66519; border-left:thick solid #03828a;margin-left:0.2em; height: 30px;">
            <h6 class="center-block" style="text-align: center; color: White;">
Search NRF</h6>
        </div>
    </div>
    <div class="container-fluid">



     <asp:UpdatePanel ID="UPPanel1" runat="server">
        <ContentTemplate>
 

      <table class="style12">
      <tr>  
    
    <td>
                    Customer Name
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbAccount" runat="server" >
                    </telerik:RadComboBox>
                </td>

                <td>
                    LOBID
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbLOBID" runat="server" >
                    </telerik:RadComboBox>
                </td>


                <%--<td>
                    NRF ID
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbNRFID" runat="server" >
                    </telerik:RadComboBox>
                </td>--%>

                <td>
                <telerik:RadButton ID="btnShow" Text="ShowCustomerNRF" runat="server" 
                            onclick="btShow_Click">
                        </telerik:RadButton>
                </td>
   
   </tr>
   
   </table> 

   <%--<telerik:RadGrid ID="grd_NRFView" runat="server" AutoGenerateColumns = "true">
    </telerik:RadGrid>--%>
            

    <telerik:RadGrid ID="GVNRFView" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" OnNeedDataSource="GVNRFView_NeedDataSource" onitemcommand="GVNRFView_ItemCommand"  OnItemDataBound="GVNRFView_ItemDataBound"
         Skin="Office2007"  PageSize="20" Height="500px" >
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True"  />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" HeaderText="" 
                    Text="View" UniqueName="column1">
                </telerik:GridButtonColumn>

                <telerik:GridButtonColumn CommandName="Taf" HeaderText="" 
                    Text="CreateTAF" UniqueName="column1">
                </telerik:GridButtonColumn>

                 <telerik:GridTemplateColumn 
    UniqueName="TemplateLinkColumn" 
    AllowFiltering="false" 
    HeaderText="NRF">
    <ItemTemplate>
        <%--<asp:HyperLink ID="Link" Text="PDFView" NavigateUrl="~/Reports/NRF01-06-2017.pdf" runat="server"></asp:HyperLink>--%>
        <asp:HyperLink ID="HyperLink1" Text='<%# Eval("NRF") %>' NavigateUrl ='<%# "~/Reports/" + Eval("NRF") + ".pdf"%>'  runat="server"></asp:HyperLink>
       
    </ItemTemplate>
</telerik:GridTemplateColumn>
               
            </Columns>
            
        
    

        </MasterTableView>
        <PagerStyle Mode="NextPrev" />
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>

   </ContentTemplate>
   </asp:UpdatePanel>
  </div>
  </div>
        
 <%--<div>
        <table width="100%" cellpadding="2">
            <tr>
                <td >
                    <strong>NRF View</strong>
                </td>
            </tr>
            <tr>               


                <td align="right">
                <asp:Label ID="lbl_CustomerName" runat="server" CssClass="lbl" Text="Customer Name" Width="100px" />
                </td>
                <td>
                   <telerik:RadComboBox ID="cmbCustomerName" runat="server" AutoPostBack="True" 
                         Skin="Office2007" 
                        Width="202px">                        
                    </telerik:RadComboBox>
                </td>
                </tr>
                </table>
                </div>

    <telerik:RadGrid ID="grd_NRFView" runat="server" AutoGenerateColumns = "true">
    </telerik:RadGrid>--%>

    
</asp:Content>
