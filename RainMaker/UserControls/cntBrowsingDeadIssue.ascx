<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntBrowsingDeadIssue.ascx.cs" Inherits="RainMaker.UserControls.cntBrowsingDeadIssue" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadTabStrip ID="RadTabStrip2" runat="server" MultiPageID="RadMultiPage1"
                                            SelectedIndex="0"
                                            >
                                            <Tabs>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 1" Visible="true">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 2">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 3">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Font-Names="Calibri" SelectedIndex="0">
                                            <telerik:RadPageView ID="TS1" runat="server">
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Node Port Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_1NodePortStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Status at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_2TrafficStatusatNodePort" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_3TrafficUtilizationatNodePort" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization on STG
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_4TrafficUtilizationatSTG" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization on CTG
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_5TrafficUtilizationatCTG" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Error Discards at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_6ErrorDiscards" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Last Mile Device Power Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_7LastMileDevicePowerStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            CPE Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS21_8CPEStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="TS2" runat="server">
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Fiber LED Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_1FiberLEDStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Status at CE Interface
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_2TrafficStatusatCEInterface" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            CE Interface Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_3CEInterfaceStatus" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Bandwidth Utilization
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_4BandwidthUtilization" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Device Rebooted
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_5DeviceRebooted" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Customer IP Response
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS22_6CustomerIPResponse" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Customer Bandwidth Issue
                                                        </td>
                                                        <td style="border:solid 1px;">
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
                                                        <td style="border:solid 1px;">
                                                            Gateway Responses
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS23_1GatewayResponses" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Assigned DNS
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS23_2AssignedDNS" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            DNS Responding
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS23_3DNSResponding" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            IP Blocked by PTA
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS23_4IPBlockedbyPTA" runat="server">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Remarks
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <telerik:RadTextBox ID="tbTS23_5Remarks" runat="server">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>