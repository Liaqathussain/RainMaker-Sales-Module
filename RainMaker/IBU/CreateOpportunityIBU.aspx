<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOpportunityIBU.aspx.cs" Inherits="RainMaker.IBU.CreateOpportunityIBU" %>
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
                    Create Opportunity</h6>
            </div>
        </div>
        <div class="container-fluid">
            <asp:UpdatePanel ID="UPPanel1" runat="server">
                <ContentTemplate>
                    <table class="nav-justified">
                        <tr>
                            <td>
                                <telerik:radbutton id="btSave" text="Save" runat="server" onclick="btSave_Click">
                        </telerik:radbutton>
                                <telerik:radbutton id="btUpdate" text="Update" runat="server" 
                                    causesvalidation="false" onclick="btUpdate_Click1">
                        </telerik:radbutton>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Opportunity Name
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                                <telerik:radtextbox id="txtOpportunityName" runat="server" Width="150px">
                                </telerik:radtextbox>
                                <asp:RequiredFieldValidator ID="rfvEditor1" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="" ForeColor="#FF3300" ControlToValidate="txtOpportunityName" />
                                
                                   <%-- <asp:RequiredFieldValidator runat="server" 
                                     ID="RequiredFieldValidator10" ValidationGroup="ValidationProduct"
                                     ControlToValidate="txtOpportunityName" ErrorMessage="*"
                                     InitialValue="" ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                                Sales Stage
                            </td>
                            <td>
                             <asp:Label ID="Label4" runat="server" Text="*"></asp:Label>
                                <telerik:radcombobox id="cmbSalesStage" runat="server" onselectedindexchanged="cmbSalesStage_SelectedIndexChanged"
                                    autopostback="true" Width="150px">
                    </telerik:radcombobox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="" ForeColor="#FF3300" ControlToValidate="cmbSalesStage" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                Account
                            </td>
                            <td>
                             <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                                <telerik:radcombobox id="cmbAccount" runat="server" AllowCustomText="True" 
                                    AppendDataBoundItems="True" Filter="StartsWith" Sort="Ascending">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbAccount" />
                            </td>
                            <%-- <td>
                   Primary Contact
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPrimaryContact"  runat="server">
                    </telerik:RadTextBox>
                </td>--%>
                            <td>
                                End Customer
                            </td>
                            <td>
                             <asp:Label ID="Label5" runat="server" Text="*"></asp:Label>
                                <telerik:radcombobox id="cmbEndCustomer" runat="server" Width="150px">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbEndCustomer" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Currency
                            </td>
                            <td>
                             <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                                <telerik:radcombobox id="cmbCurrency" runat="server">
                    </telerik:radcombobox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbCurrency" />
                            </td>
                            <td>
                                <%--Status--%>
                                Working By </td>
                            <td>
                               <%-- <telerik:radcombobox id="cmbOppStatus" runat="server">--%>
                   
                                <telerik:RadTextBox ID="txtWorkingBy" runat="server" readonly="true" 
                                    Width="150px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Win Probability (%)
                            </td>
                            <td>
                                <telerik:radtextbox id="txtWinProbability" runat="server" Width="150px">
                    </telerik:radtextbox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                KAM
                            </td>
                            <td>
                                <telerik:radtextbox id="txtKAM" readonly="true" runat="server" Width="150px">
                    </telerik:radtextbox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                Attachement
                            </td>
                            <td>
                                <%--<telerik:RadTextBox ID="txtAttachement" runat="server">
                    </telerik:RadTextBox>--%>
                                <telerik:radtextbox id="txtAttachement" runat="server" text="" Width="150px" />
                                <telerik:radasyncupload id="RadAttachment" runat="server" width="20px">
                </telerik:radasyncupload>
                            </td>
                        </tr>
                        <tr>

                        <td>
                        Opportunity Creation Date
                        </td>
                        <td>
                        <telerik:radtextbox id="txtOpportunityCreation" readonly="true" runat="server" 
                                Width="150px">
                        </telerik:radtextbox>
                        </td>
                        
                        
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOrderDate" runat="server" Text="OrderDate"></asp:Label>
                            </td>
                            <td>
                            <%-- <asp:Label ID="Label6" runat="server" Text="*"></asp:Label>--%>
                                <telerik:raddatepicker id="DatePickerOrderDate" runat="server" Width="150px">
                    </telerik:raddatepicker>
                            </td>
                            <td>
                                <asp:Label ID="lblDeploymentDate" runat="server" Text="Deployment Date"></asp:Label>
                            </td>
                            <td>
                             <%--<asp:Label ID="Label7" runat="server" Text="*"></asp:Label>--%>
                                <telerik:raddatepicker id="DatePickerDeploymentDate" runat="server" 
                                    Width="150px">
                    </telerik:raddatepicker>
                            </td>
                            <td>
                                <asp:Label ID="lblWinlossReason" runat="server" Text="Win/loss Reason"></asp:Label>
                            </td>
                            <td>
                                <telerik:radtextbox id="txtWinlossReason" runat="server" Width="150px">
                    </telerik:radtextbox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastUpdatedDate" runat="server" Text="Last Updated Date"></asp:Label>
                            </td>
                            <td>
                                <%--<telerik:RadDatePicker ID="DatePickerLastUpdateDate" runat="server">
                    </telerik:RadDatePicker>--%>
                                <telerik:radtextbox id="txtLastUpdatedDate" readonly="true" runat="server">
                    </telerik:radtextbox>
                            </td>
                            <td>
                                <asp:Label ID="lblLastUpdatedBy" runat="server" Text="Last Updated By"></asp:Label>
                            </td>
                            <td>
                                <telerik:radtextbox id="txtLastUpdateBy" readonly="true" runat="server" 
                                    Width="150px">
                    </telerik:radtextbox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBudgetaryQuote" runat="server" Text="Budgetary Quote"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxBudgetaryQuote" runat="server"></asp:CheckBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBudgetaryQuoteDate" runat="server" Text="BudgetaryQuote Date"></asp:Label>
                            </td>
                            <td>
                             <%--<asp:Label ID="Label8" runat="server" Text="*"></asp:Label>--%>
                                <telerik:raddatepicker id="DatePickerBudgetaryQuoteDate" runat="server" 
                                    Width="150px">
                                </telerik:raddatepicker>
                                
                            </td>
                            <td>
                                <asp:Label ID="lblQuoteProposalDate" runat="server" Text="QuoteProposal Date"></asp:Label>
                            </td>
                            <td>
                             <%--<asp:Label ID="Label9" runat="server" Text="*"></asp:Label>--%>
                                <telerik:raddatepicker id="DatePickerQuoteProposalDate" runat="server" 
                                    Width="150px">
                    </telerik:raddatepicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:radbutton id="btn_AddRevenueLines" text="Add Revenue Lines" runat="server"
                                    causesvalidation="false" onclick="btn_AddRevenueLines_Click">
                        </telerik:radbutton>
                            </td>
                        </tr>
                        <asp:Panel ID="Pnl_Opportunity" runat="server">

                        <asp:Panel ID="Panel1" runat="server">

                        </asp:Panel>
                        
                            <asp:Panel ID="Pnl_RevenueLines" runat="server">
                                <tr>
                                    <td>
                                        <strong>Revenue Lines</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Site A Address
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtSiteAAddress" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        Site A Country
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbSiteACountry" runat="server">
                    </telerik:radcombobox>
                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbSiteACountry" />--%>
                                    </td>
                                    <td>
                                        Site A City
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbSiteACity" runat="server">
                    </telerik:radcombobox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Site B Address
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtSiteBAddress" runat="server">
                                        </telerik:radtextbox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="txtSiteBAddress" />
                                    </td>
                                    <td>
                                        Site B Country
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbSiteBCountry" runat="server">
                    </telerik:radcombobox>
                                    </td>
                                    <td>
                                        Site B City
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbSiteBCity" runat="server">
                    </telerik:radcombobox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Name
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbName" runat="server">
                                        </telerik:radcombobox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbName" />--%>

                                    </td>
                                    <td>
                                        UOM
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbQuantityUOM" runat="server">
                                        </telerik:radcombobox>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbQuantityUOM" />--%>
                                    </td>
                                    <%--<td>
                    Quantity
                </td>
                <td>
                    <telerik:RadTextBox ID="txtQuantity"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    UOM
                </td>
                <td>
                   <telerik:RadTextBox ID="txtUOM"  runat="server">
                    </telerik:RadTextBox>
                </td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        Interface
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbInterface" runat="server">
                                        </telerik:radcombobox>
                                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="true" 
                                             ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbName" />--%>
                                    </td>
                                    <td>
                                        Last Mile Protection
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtLastMileProtection" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        Wet Portion Restorability
                                    </td>
                                    <td>
                                    <telerik:radcombobox id="cmbWetPortionRestorability" runat="server">
                   <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Restorable" Value="Restorable" />
                            <telerik:RadComboBoxItem runat="server" Text="Non-Restorable" Value="Non-Restorable" />
                        </Items>
                    </telerik:radcombobox>
                                        <%--<telerik:radtextbox id="txtWetPortionRestorability" runat="server"></telerik:radtextbox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        SLA%
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtSLA" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        RFS Date(Duration)
                                    </td>
                                    <td>
                                        <telerik:raddatepicker id="DatePickerRFSDateDuration" runat="server">
                                         </telerik:raddatepicker>
                                         <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  SetFocusOnError="true" 
                                             ErrorMessage="*" InitialValue="" ForeColor="#FF3300" ControlToValidate="DatePickerRFSDateDuration" />--%>
                                    </td>
                                    <td>
                                        Contract Term
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtContractTerm" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Status(W/L)
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbWinLossStatus" runat="server">
                   <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Win" Value="Win" />
                            <telerik:RadComboBoxItem runat="server" Text="Loss" Value="Loss" />
                        </Items>
                    </telerik:radcombobox>
                                    </td>
                                    <td>
                                        Currency
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbCurrencyDetail" runat="server">
                                         </telerik:radcombobox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  SetFocusOnError="true" 
                                             ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbCurrencyDetail" />
                                    </td>
                                    <td>
                                        Status
                                    </td>
                                    <td>
                                        <telerik:radcombobox id="cmbStatus" runat="server">
                    </telerik:radcombobox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="Pnl_Budgetary" runat="server">
                                <tr>
                                    <td class="style1">
                                        <strong>Budgetary</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        NRC-Budget
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNRCBudget" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        MRC-Budget
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtMRCBudget" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        NRC-Cost On Net
                                    </td>
                                    <td>
                                    <telerik:radtextbox id="txtNRCCostOnNet" runat="server">
                                    </telerik:radtextbox>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        MRC Cost On Net
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtMRCCostOnNet" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        NRC-Cost Off Net
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNRCCostOffNet" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        MRC Cost Off Net
                                    </td>
                                    <td>
                                    <telerik:radtextbox id="txtMRCCostOffNet" runat="server">
                                    </telerik:radtextbox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        NRC Cost OOP
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNRCCostOOP" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        MRC Cost OOP
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtMRCCostOOP" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        Name of 3P
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNameof3P" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="Pnl_Proposal" runat="server">
                                <tr runat="server" id="tr2">
                                    <td>
                                        <strong>Proposal</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        NRC-Actual
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNRCActual" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        MRC-Actual
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtMRCActual" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        NRR
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNRR" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        MRR
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtMRR" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        ROI
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtROI" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td>
                                        Term Profit
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtTermProfit" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Term Revenue
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtTermRevenue" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lbl_RecurringMargin" runat="server" CssClass="lbl" Text="Recurring Margin %age" />
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtRecurringMargin" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lbl_NonRecurringMargin" runat="server" CssClass="lbl" Text="Non Recurring Margin" />
                                    </td>
                                    <td>
                                        <telerik:radtextbox id="txtNonRecurringMargin" runat="server">
                    </telerik:radtextbox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td>
                                    <telerik:radbutton id="btn_Add" text="Add" runat="server" onclick="btn_Add_Click">
                        </telerik:radbutton>
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                   
                    
                        <%--onclick="btn_Add_Click"--%>
                    <asp:Panel ID="Pnl_GrdBudgetary" runat="server">

                        <telerik:radgrid id="GV_GrdBudgetary" runat="server">
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Select" Text="Add" UniqueName="column">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                EnableImageSprites="True">
                            </HeaderContextMenu>
                </telerik:radgrid>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_GrdProposal" runat="server">
                        <telerik:radgrid id="GV_GrdProposal" runat="server" autogeneratecolumns="true">
                </telerik:radgrid>
                    </asp:Panel>

                    <div>
                   <%-- onitemcommand="GV_CreateOpportunity_ItemCommand"--%>
                     <asp:Panel ID="Pnl_GrdCreateOpportunity" runat="server">
                        <telerik:radgrid id="GV_CreateOpportunity" 
                              runat="server" 
                             GridLines="None" onneeddatasource="GV_CreateOpportunity_NeedDataSource">
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Select" Text="Add" UniqueName="column1">
                                    </telerik:GridButtonColumn>
                                </Columns>
                                
                            </MasterTableView>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                EnableImageSprites="True">
                            </HeaderContextMenu>
                        </telerik:radgrid>
                    </asp:Panel>
                    
                    </div>
                     
                     <div>

                     <asp:Panel ID="Pnl_RevenueDetailsForProducts" runat="server">
                        <telerik:radbutton id="btn_SaveDetail" text="Save" runat="server" onclick="btn_SaveDetail_Click" >
                        </telerik:radbutton>

                         

                         <asp:GridView ID="RadgridForProducts" runat="server" onitemcommand="RadgridForProducts_ItemCommand" 
                       
                             ShowFooter="True" 
                            Width="915px" 
                             onselectedindexchanged="RadgridForProducts_SelectedIndexChanged" >
                       
                            <Columns>
                              
                                <%--<asp:BoundField DataField="ProductID" HeaderText ="Product Name" />--%>
                               

                          

                                <%--<asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbProductName" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                              
                                <asp:CommandField ShowSelectButton="True" />
                              
                               <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" Text="Select" Width="80px" runat="server" />
                                </ItemTemplate>

                                    <ControlStyle Width="100px" />
                                    <HeaderStyle Width="100px" />

                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbUOM" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                    <HeaderStyle Width="220px" />
                                    
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Interface">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbInterface" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                    <HeaderStyle Width="150px" />
                                    
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                     </asp:Panel>

                    </div>
                <div>
                     <asp:Panel ID="ProductGridView" runat="server">
                        <telerik:radgrid id="GVProducts" runat="server">

                         </telerik:radgrid>
                         <asp:Button ID="btnHide" runat="server" onclick="btnHide_Click" Text="Hide" />
                     <asp:Button ID="btnProductsView" runat="server" 
                        onclick="btnProductsView_Click" Text="Show Products" />
                     </asp:Panel>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
