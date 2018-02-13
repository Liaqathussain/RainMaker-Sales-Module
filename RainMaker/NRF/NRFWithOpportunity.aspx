<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NRFWithOpportunity.aspx.cs" Inherits="RainMaker.NRF.NRFWithOpportunity" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


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
                    NRF With Opportunity</h6>
            </div>
        </div>
        <div class="container">
        
        <asp:UpdatePanel ID="UPPanel2" runat="server">
                <ContentTemplate>

                <table class="nav-justified">
                        <tr>
                            <td>
                                Customer Name
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbCustomer" runat="server" AutoPostBack="true"
                                    >
                                </telerik:RadComboBox>
                            </td>
                            <%--<td align="right">
                                Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtTAFSearch" runat="server">
                                </telerik:RadDatePicker>
                            </td>--%>

                            <td>
                                            City
                                        </td>
                                        <td>
                                             <telerik:RadComboBox ID="cmbcity" runat="server" AutoPostBack="true"
                                                 >
                                            </telerik:RadComboBox>
                                        </td>

                                         <td>
                <telerik:RadButton ID="btnShow" Text="ShowOpportunity" runat="server" 
                            onclick="btShow_Click">
                        </telerik:RadButton>
                </td>
                           
                        </tr>
                    </table>

            <telerik:RadGrid ID="GVOpportunity" runat="server" AllowPaging="True" AllowSorting="True"
                GridLines="None" OnNeedDataSource="GVOpportunity_NeedDataSource"  OnItemCommand="GVOpportunity_ItemCommand"
                Skin="Office2007" Height="475px" Width="98%">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" />
                </ClientSettings>
                <MasterTableView>
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" Text="Select"
                            UniqueName="column1">
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
                <PagerStyle Mode="NextPrev" />
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                </HeaderContextMenu>
            </telerik:RadGrid>

            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </div>
</asp:Content>
