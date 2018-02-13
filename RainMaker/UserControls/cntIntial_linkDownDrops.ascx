<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntIntial_linkDownDrops.ascx.cs" Inherits="RainMaker.UserControls.cntIntial_linkDownDrops" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadTabStrip ID="RadTabStrip3" runat="server" MultiPageID="RadMultiPage4"
                                            SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 1" Selected="True" Visible="true">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" Text="Trouble Shooting Page 2" >
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="RadMultiPage4" runat="server" Font-Names="Calibri" 
                                            SelectedIndex="0">
                                            <telerik:RadPageView ID="TS11" runat="server">
                                                <table>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Node Port Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_1NodePortStatus" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Status at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_2TrafficStatusatNodePort" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_3TrafficUtilizationatNodePort" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization on STG
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_4TrafficUtilizationonSTG" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Utilization on CTG
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_5TrafficUtilizationonCTG" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Error Discards at Node Port
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_6ErrorDiscardsatNodePort" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Last Mile Device Power Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_7LastMileDevicePowerStatus" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            CPE Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_8CPEStatus" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            CE Interface Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS11_9CEInterfaceStatus" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="TS12" runat="server">
                                                <table>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Fiber LED Status
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS12_1FiberLEDStatus" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Traffic Status at CE Interface
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS12_2TrafficStatusatCEInterface" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Bandwidth Utilization
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS12_3BandwidthUtilization" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Device Rebooted
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <asp:Panel ID="pnlTS12_4DeviceRebooted" runat="server" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border:solid 1px;">
                                                            Remarks
                                                        </td>
                                                        <td style="border:solid 1px;">
                                                            <telerik:RadTextBox ID="tbTS12_5Remarks" runat="server" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>