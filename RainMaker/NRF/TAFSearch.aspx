<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TAFSearch.aspx.cs" Inherits="RainMaker.NRF.TAFSearch" %>

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
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                    Search TAF</h6>
            </div>
        </div>
        <div class="container-fluid">
            <asp:UpdatePanel ID="UPPanel2" runat="server">
                <ContentTemplate>
                    <table class="nav-justified">
                        <tr>
                            <td>
                                Customer Name
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbAccount" runat="server">
                                </telerik:RadComboBox>
                            </td>
                            <td align="right">
                                Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="dtTAFSearch" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                <telerik:RadButton ID="btnAccept" OnClick="btSearch_Click" Text="Search" runat="server">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="GVNRFView" runat="server" AllowPaging="True" AllowSorting="True"
                        GridLines="None" OnNeedDataSource="GVNRFView_NeedDataSource" OnItemCommand="GVNRFView_ItemCommand"
                        Skin="Office2007" PageSize="20" Height="500px">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" />
                        </ClientSettings>
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <Columns>
                                <telerik:GridButtonColumn CommandName="Select" HeaderText="" Text="ViewTAF" UniqueName="column1">
                                </telerik:GridButtonColumn>


                                <telerik:GridButtonColumn CommandName="Accept" HeaderText="Accept" Text="Accept"
                                        UniqueName="colAccept">
                                    </telerik:GridButtonColumn>



                                    <telerik:GridButtonColumn CommandName="Reject" HeaderText="Reject" Text="Reject"
                                        UniqueName="colReject">
                                    </telerik:GridButtonColumn>


                                    <telerik:GridButtonColumn CommandName="Revise" HeaderText="Revise" Text="Revise"
                                        UniqueName="colRevise">
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
