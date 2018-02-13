<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TAFSearchData.aspx.cs" Inherits="RainMaker.NRF.TAFSearchData" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                    TAF</h6>
            </div>
        </div>
        <div class="container">
            <telerik:RadButton ID="btEdit" OnClick="btEdit_Click" Text="Edit" runat="server">
            </telerik:RadButton>

            

            <asp:UpdatePanel ID="UPPanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <table class="nav-justified">
                            <tr>
                                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                                    TAF 
                                </td>
                            </tr>
                        </table>
                        <table class="nav-justified">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_TAFormNo" runat="server" CssClass="lbl" Text="TAF Form No" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_TAFormNo" runat="server" Width="158px">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_RevisionNo" runat="server" CssClass="lbl" Text="Revision No" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_RevisionNo" runat="server" Width="158px">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_SubmissionDate" runat="server" CssClass="lbl" Text="SubmissionDate" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_SubmissionDate" Width="158px" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_CustomerName" runat="server" CssClass="lbl" Text="Customer Name" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbCustomerName" Enabled="false" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_Address" runat="server" CssClass="lbl" Text="Address" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_Address" runat="server" Width="158px">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_SitesJobLocation" runat="server" CssClass="lbl" Text="Sites / JobLocations"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_SitesJobLocation" runat="server" Width="158px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_AccountManager" runat="server" CssClass="lbl" Text="Account Manager"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_AccountManager" Width="158px" ReadOnly="true" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" CssClass="lbl" Text="Business Unit"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_BusinessUnit" Width="158px" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="nav-justified">
                            <tr>
                                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                                    Technical Specification / Service Parameter
                                </td>
                            </tr>
                        </table>
                        <table class="nav-justified">
                            <tr>
                            </tr>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_LastMileTopology" runat="server" CssClass="lbl" Text="Last Mile Topology"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbLastMileTopology" runat="server" AutoPostBack="True"
                                        Width="202px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Restorable" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Non-Restorable" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblCapacity" runat="server" CssClass="lbl" Text="Capacity / Bandwidth"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbCapacity" runat="server" AutoPostBack="True" Skin="Office2007"
                                        Width="202px">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_InterfaceHandoff" runat="server" CssClass="lbl" Text="Interface Handoff" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbInterfaceHandoff" Width="202px" runat="server">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Optical" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Elecetrical" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblInfra" runat="server" CssClass="lbl" Text="Infra" Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbInfra" runat="server" Enabled="false" Skin="Office2007"
                                        Width="202px">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblService" runat="server" CssClass="lbl" Text="Service" Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbService" Enabled="false" runat="server" Skin="Office2007"
                                        Width="202px" >
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblServiceType" runat="server" Visible="false" CssClass="lbl" Text="Service Type"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbServiceType" Visible="false" runat="server" Skin="Office2007"
                                        Width="202px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_LogicalTopology" runat="server" CssClass="lbl" Text="Logical Topology"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbLogicalTopology" runat="server" AutoPostBack="True" Width="202px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Point To Point" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Point To MultiPoint" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="MultiPoint To MultiPoint" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_RestorabilityMethod" runat="server" CssClass="lbl" Text="Restorability Method"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_RestorabilityMethod" Width="198px" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_AdditionalEquipment" runat="server" CssClass="lbl" Text="Additional Equipment"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbAdditionalEquipment" runat="server" AutoPostBack="True"
                                        Width="202px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Router" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Switch" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="Other" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="Make/Model" Value="4" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <%--<td align="right">
                                    <asp:Label ID="lbl_ServiceParameters" runat="server" CssClass="lbl" Text="Service Parameters"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_ServiceParameters" Width="198px" runat="server">
                                    </telerik:RadTextBox>
                                </td>--%>



                                <td align="right">
                                    <asp:Label ID="lbl_SLARequirement" runat="server" CssClass="lbl" Text="SLA Requirement" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cmbSLARequirement" runat="server" AutoPostBack="True" Width="202px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="Overall" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_LinkInformation" runat="server" CssClass="lbl" Visible="false"
                                        Text="Link Information" Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_LinkInformation" Visible="false" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_ConnectCommunication" Visible="false" runat="server" CssClass="lbl"
                                        Text="Connect Communication" Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_ConnectCommunication" Visible="false" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                        <table class="nav-justified">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAdditionalRequirement" runat="server" CssClass="lbl" Text="Addition / Special Requirement"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtAdditionalRequirement" TextMode="MultiLine" Width="986px"
                                        runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>

                        <asp:Panel ID="pnl_Ipcore" runat="server" Visible="false">
                        <table class="nav-justified">
                            <tr>
                                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                                    IP Core Segments
                                </td>
                            </tr>
                        </table>
                        <table class="nav-justified">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbl_ServiceDescription" runat="server" CssClass="lbl" Text="Service Description/Technical Parameters"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_ServiceDescription" TextMode="MultiLine" Width="986px"
                                        runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblComments" runat="server" CssClass="lbl" Text="Comments" Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtComments" TextMode="MultiLine" Width="986px" runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAdditionalEquipment" runat="server" CssClass="lbl" Text="Additional Equipment"
                                        Width="100px" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtAdditionalEquipment" TextMode="MultiLine" Width="986px"
                                        runat="server">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadButton ID="btnAccept" OnClick="btAccept_Click" Text="Accept" runat="server">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnReject" OnClick="btReject_Click" Text="Reject" runat="server">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btViewNRF" OnClick="btView_Click" Text="View NRF" runat="server">
                                    </telerik:RadButton>

                                    <asp:Label ID="lblApprovalSuccessfully" Visible="false" runat="server" Text=""></asp:Label>

                                </td>
                            </tr>
                        </table>
                        </asp:Panel>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
