<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntWebIssue.ascx.cs" Inherits="RainMaker.UserControls.cntWebIssue" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="nav-justified">
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Assigned DNS
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS41_1AssignedDNS" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Website in opening at our end
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS41_2Website" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    DNS Responding
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS41_3DNSResponding" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Remarks
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <telerik:RadTextBox ID="tbTS41_4Remarks" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>