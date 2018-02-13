<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPortPanel.aspx.cs" Inherits="RainMaker.TestPortPanel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

<telerik:RadTabStrip ID="RadTabStrip2" runat="server" MultiPageID="RadMultiPage1"
                                            SelectedIndex="2"
                                            >
                                            <Tabs>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 1" Visible="true">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 2" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 3" Selected="True">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="RadMultiPage3" runat="server" Font-Names="Calibri" SelectedIndex="0">
                                            <telerik:RadPageView ID="TS1" runat="server">
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="float: right">
                                                            Node Port Status
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_1NodePortStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Traffic Status at Node Port
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_2TrafficStatusatNodePort" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Traffic Utilization at Node Port
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_3TrafficUtilizationatNodePort" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Traffic Utilization on STG
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_4TrafficUtilizationatSTG" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Traffic Utilization on CTG
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_5TrafficUtilizationatCTG" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Error Discards at Node Port
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_6ErrorDiscards" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Last Mile Device Power Status
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_7LastMileDevicePowerStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            CPE Status
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS21_8CPEStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="TS2" runat="server">
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="float: right">
                                                            Fiber LED Status
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_1FiberLEDStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Traffic Status at CE Interface
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_2TrafficStatusatCEInterface" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            CE Interface Status
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_3CEInterfaceStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Bandwidth Utilization
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_4BandwidthUtilization" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Device Rebooted
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_5DeviceRebooted" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Customer IP Response
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_6CustomerIPResponse" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Customer Bandwidth Issue
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS22_7CustomerBandwidthIssue" runat="server">
                                                                <telerik:RadComboBox ID="cmbTS22_7CustomerBandwidthIssue" runat="server">
                                                                </telerik:RadComboBox>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="TS3" runat="server">
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="float: right">
                                                            Gateway Responses
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS23_1GatewayResponses" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Assigned DNS
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS23_2AssignedDNS" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            DNS Responding
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS23_3DNSResponding" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            IP Blocked by PTA
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlTS23_4IPBlockedbyPTA" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right">
                                                            Remarks
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="tbTS23_5Remarks" runat="server">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>

</asp:Content>
