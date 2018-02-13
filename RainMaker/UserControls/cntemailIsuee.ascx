<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntemailIsuee.ascx.cs" Inherits="RainMaker.UserControls.cntemailIsuee" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="nav-justified">
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Issue in
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_1Issuein" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Domain
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_2Domain" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    MPPL SMTP/POP Response
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_3MPPLResponse" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    MPPL SMTP/POP Telnet
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_4MPPLTelnet" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Issue On
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_5IssueOn" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Domain on which facing Problem
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_6DomainOnWhichfacingProblem" runat="server">
                                                        <telerik:RadTextBox ID="tbEmail_DomainFacingProblem" runat="server">
                                                        </telerik:RadTextBox>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    IP Blacklisted on international servers
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <asp:Panel ID="pnlTS31_7IPBlacklisted" runat="server">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Remarks
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <telerik:RadTextBox ID="tbTS31_8Remarks" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>