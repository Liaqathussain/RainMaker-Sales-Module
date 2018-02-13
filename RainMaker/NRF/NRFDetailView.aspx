<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NRFDetailView.aspx.cs" Inherits="RainMaker.NRF.NRFDetailView" %>

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


        <telerik:RadGrid ID="GVNRFViewDetails" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" OnNeedDataSource="GVNRFViewDetails_NeedDataSource" onitemcommand="GVNRFViewDetails_ItemCommand" 
         Skin="Office2007"  PageSize="20" Height="500px" >
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True"  />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
           <%-- <Columns>
                <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" 
                    Text="Select" UniqueName="column1">
                </telerik:GridButtonColumn>
            </Columns>--%>
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
    

</asp:Content>
