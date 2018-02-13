<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cntServiceRequest.ascx.cs" Inherits="RainMaker.UserControls.cntServiceRequest" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<table class="nav-justified">
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Customer Request/Query
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <telerik:RadTextBox ID="tbTS51_1CustomerRequest" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border:solid 1px;">
                                                    Remarks
                                                </td>
                                                <td style="border:solid 1px;">
                                                    <telerik:RadTextBox ID="tbTS51_2Remarks" runat="server">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>