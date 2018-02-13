<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpportunityListEBU.aspx.cs" Inherits="RainMaker.WebForm10" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
</telerik:RadStyleSheetManager>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
 <style scoped>
        td
        {
            padding-top: 5px;
        }
    </style>
    

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                    EBU Opportunity</h6>
            </div>
        </div>
        <div class="container">
        <telerik:RadGrid ID="GVOpportunity" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" 
                OnNeedDataSource="GVOpportunity_NeedDataSource" onitemcommand="GVOpportunity_ItemCommand" 
         Skin="Office2007" Height="500px">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True"  />
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

        </div>
        </div>
</asp:Content>


    
