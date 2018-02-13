<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateOpportunityIBU.aspx.cs" Inherits="RainMaker.IBU.UpdateOpportunityIBU" %>
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
        <div class="container">

        <asp:UpdatePanel ID="UPPanel1" runat="server">
        <ContentTemplate>
 

      <table class="style12">
                <tr>
                    <td>
                        <telerik:RadButton ID="btSave" Text="Save" runat="server" 
                            onclick="btSave_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btClear" Text="Clear" runat="server" CausesValidation="false">
                        </telerik:RadButton>                        
                    </td>
                </tr>
               
               <tr>
                <td>
                    Opportunity Name
                </td>
                <td>
                    <telerik:RadTextBox ID="txtOpportunityName"  runat="server">
                    </telerik:RadTextBox>
                </td>

                   

                <td>
                    Sales Stage
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSalesStage" runat="server" 
                        onselectedindexchanged="cmbSalesStage_SelectedIndexChanged" AutoPostBack="true" >
                    </telerik:RadComboBox>
                </td>

                
            </tr>

                <tr>
            <td>
                    Account
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbAccount" runat="server" >
                    </telerik:RadComboBox>
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
                     <telerik:RadComboBox ID="cmbEndCustomer" runat="server">
                    </telerik:RadComboBox>
                </td>
            </tr>

            <tr>

                <td>
                    Currency
                </td>
                <td>
                    
                    <telerik:RadComboBox ID="cmbCurrency" runat="server" >
                    </telerik:RadComboBox>
                </td>  
                
                
                <td>
                   Status
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbOppStatus" runat="server" >
                    </telerik:RadComboBox>
                </td>        


                <td>
                    Win Probability (%)
                </td>
                <td>
                    <telerik:RadTextBox ID="txtWinProbability"   runat="server">
                    </telerik:RadTextBox>
                </td>

                

            
            </tr>

            

            

            

            <tr>

            <td>
                    Owner
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtKAM"  ReadOnly="true"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    Working By
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtWorkingBy" ReadOnly="true" runat="server">
                    </telerik:RadTextBox>
                </td>

                 <td>
                    Attachement
                </td>
                <td>                    
                    <%--<telerik:RadTextBox ID="txtAttachement" runat="server">
                    </telerik:RadTextBox>--%>

                    <telerik:RadTextBox ID="txtAttachement" runat="server" Text=""/>
                    <telerik:RadAsyncUpload ID="RadAttachment" runat="server">
                </telerik:RadAsyncUpload>
                </td>
            
            </tr>
          

            <tr>

            <td>
            <asp:Label ID="lblOrderDate" runat="server" Text="OrderDate"></asp:Label>
                    
                </td>
                <td>                    
                   <telerik:RadDatePicker ID="DatePickerOrderDate" runat="server">
                    </telerik:RadDatePicker>
                </td>

                <td>
                <asp:Label ID="lblDeploymentDate" runat="server" Text="Deployment Date"></asp:Label>
                    
                </td>
                <td>                    
                     <telerik:RadDatePicker ID="DatePickerDeploymentDate" runat="server">
                    </telerik:RadDatePicker>
                </td>

                 <td>
                    <asp:Label ID="lblWinlossReason" runat="server" Text="Win/loss Reason"></asp:Label>
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtWinlossReason"   runat="server">
                    </telerik:RadTextBox>
                </td>
            
            </tr>

            <tr>

            <td>
                   <asp:Label ID="lblLastUpdatedDate" runat="server" Text="Last Updated Date"></asp:Label>
                </td>
                <td>                    
                     <%--<telerik:RadDatePicker ID="DatePickerLastUpdateDate" runat="server">
                    </telerik:RadDatePicker>--%>

                    <telerik:RadTextBox ID="txtLastUpdatedDate"  ReadOnly="true" runat="server">
                    </telerik:RadTextBox>

                </td>

            <td>
                    Last Update By
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtLastUpdateBy" ReadOnly="true"  runat="server">
                    </telerik:RadTextBox>
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
                <telerik:RadDatePicker ID="DatePickerBudgetaryQuoteDate" runat="server">
                    </telerik:RadDatePicker>
                </td>

                
                <td>
                    <asp:Label ID="lblQuoteProposalDate" runat="server" Text="QuoteProposal Date"></asp:Label>
                    
                </td>
                <td>
                <telerik:RadDatePicker ID="DatePickerQuoteProposalDate" runat="server">
                    </telerik:RadDatePicker>
                
                </td>         
                
            </tr>

            
           
           
       <asp:Panel ID="Pnl_Opportunity" runat="server">

           
            
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
                    <telerik:RadTextBox ID="txtSiteAAddress"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    Site A Country
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteACountry" runat="server" >
                    </telerik:RadComboBox>
                </td>

                <td>
                    Site A City
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteACity" runat="server" >
                    </telerik:RadComboBox>
                </td>

                
            </tr>


             <tr>
            
            <td>
                    Site B Address
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtSiteBAddress"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    Site B Country
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteBCountry" runat="server" >
                    </telerik:RadComboBox>
                </td>

                <td>
                    Site B City
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteBCity" runat="server" >
                    </telerik:RadComboBox>
                </td>

                
            </tr>

             <tr>
            
            <td>
                    Name
                </td>
                <td>                    
                    <telerik:RadComboBox ID="cmbName" runat="server" >
                    </telerik:RadComboBox>
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

                
                <td>
                    UOM
                </td>
                <td>
                   
                   <telerik:RadComboBox ID="cmbQuantityUOM" runat="server">
                   </telerik:RadComboBox>
                </td>

            </tr>


             <tr>
            
            <td>
                    Interface
                </td>
                <td>                    
                    <telerik:RadComboBox ID="cmbInterface" runat="server">
                    <Items>
                           <telerik:RadComboBoxItem runat="server" Text="Test" Value="1" />
                       </Items>
                    </telerik:RadComboBox>
                </td>


                <td>
                    Last Mile Protection
                </td>
                <td>
                    <telerik:RadTextBox ID="txtLastMileProtection"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    Wet Portion Restorability
                </td>
                <td>
                   <telerik:RadTextBox ID="txtWetPortionRestorability"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


             <tr>
            
            <td>
                    SLA%
                </td>
                <td> 
                 <telerik:RadTextBox ID="txtSLA"  runat="server">
                    </telerik:RadTextBox>                   
                    
                </td>


                <td>
                    RFS Date(Duration)
                </td>            

                    <td>                    
                   <telerik:RadDatePicker ID="DatePickerRFSDateDuration" runat="server">
                    </telerik:RadDatePicker>
                </td>
                

                <td>
                    Contract Term
                </td>
                <td>
                   <telerik:RadTextBox ID="txtContractTerm"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>

            <tr>
            <td>
                    Status(W/L)
                </td>
                <td>
                   <telerik:RadComboBox ID="cmbWinLossStatus" runat="server" >
                   <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Win" Value="Win" />
                            <telerik:RadComboBoxItem runat="server" Text="Loss" Value="Loss" />
                        </Items>
                    </telerik:RadComboBox>
                    

                </td>

                 <td>
                    Currency
                </td>
                <td>
                    
                    <telerik:RadComboBox ID="cmbCurrencyDetail" runat="server" >
                    </telerik:RadComboBox>
                </td>  
                
                
                <td>
                   Status
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbStatus" runat="server" >
                    </telerik:RadComboBox>
                </td>   
            
            </tr>
            <asp:Panel ID="Pnl_Budgetary" runat ="server">

            
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
                    <telerik:RadTextBox ID="txtNRCBudget"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                   MRC-Budget
                </td>
                <td>
                    <telerik:RadTextBox ID="txtMRCBudget"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    NRC-Cost On Net
                </td>
                <td>
                   <telerik:RadTextBox ID="txtNRCCostOnNet"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


            <tr>
            
            <td>
                    MRC Cost On Net
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtMRCCostOnNet"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    NRC-Cost Off Net
                </td>
                <td>
                    <telerik:RadTextBox ID="txtNRCCostOffNet"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    MRC Cost Off Net
                </td>
                <td>
                  
                    <telerik:RadTextBox ID="txtMRCCostOffNet"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


            <tr>
            
            <td>
                    NRC Cost OOP
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtNRCCostOOP"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    MRC Cost OOP
                </td>
                <td>
                    <telerik:RadTextBox ID="txtMRCCostOOP"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    Name of 3P
                </td>
                <td>
                     <telerik:RadTextBox ID="txtNameof3P"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>
             
            
            </asp:Panel>

            <asp:Panel ID="Pnl_Proposal" runat="server">


            <tr >
            <td>
                    <strong>Proposal</strong>
                </td>
            </tr>

             <tr>
            
            <td>
                    NRC-Actual
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtNRCActual"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    MRC-Actual
                </td>
                <td>
                    <telerik:RadTextBox ID="txtMRCActual"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    NRR
                </td>
                <td>
                     <telerik:RadTextBox ID="txtNRR"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


             <tr>
            
            <td>
                    MRR
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtMRR"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    ROI
                </td>
                <td>
                    <telerik:RadTextBox ID="txtROI"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    Term Profit
                </td>
                <td>
                     <telerik:RadTextBox ID="txtTermProfit"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


              <tr>
            
            <td>
                    Term Revenue
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtTermRevenue"  runat="server">
                    </telerik:RadTextBox>
                </td>


                <td>
                    <asp:Label ID="lbl_RecurringMargin" runat="server" CssClass="lbl" Text="Recurring Margin %age" />
                </td>
                <td>
                    <telerik:RadTextBox ID="txtRecurringMargin"  runat="server">
                    </telerik:RadTextBox>
                </td>

                <td>
                    <asp:Label ID="lbl_NonRecurringMargin" runat="server" CssClass="lbl" Text="Non Recurring Margin" />
                </td>
                <td>
                     <telerik:RadTextBox ID="txtNonRecurringMargin"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>


            </asp:Panel>
            
            
            <%--<tr>
            <td>

                <telerik:RadButton ID="btn_AddRevenueLines" Text="Add Revenue Lines" runat="server" onclick="btnAddRevenue_Click">
                        </telerik:RadButton>
            </td>
             
            </tr>--%>
            </asp:Panel>

             


            </table>       
          
            <asp:Panel ID="Pnl_GrdCreateOpportunity" runat="server">
                

                 <telerik:RadGrid ID="GV_CreateOpportunity" runat="server" AllowPaging="True"  AutoGenerateColumns="true"
        AllowSorting="True" GridLines="None" onitemcommand="GV_CreateOpportunity_ItemCommand" 
        onneeddatasource="GV_CreateOpportunity_NeedDataSource"
         Skin="Office2007">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True"  />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" 
                    Text="Select" UniqueName="column1">
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
        <PagerStyle Mode="NextPrev" />
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>

            </asp:Panel>          
            
             <asp:Panel ID="Pnl_GrdBudgetary" runat="server">
                <telerik:RadGrid ID="GV_GrdBudgetary" runat="server" AutoGenerateColumns="true">
                </telerik:RadGrid>
            </asp:Panel>


            <asp:Panel ID="Pnl_GrdProposal" runat="server">
                <%--<telerik:RadGrid ID="GV_GrdProposal" runat="server" AutoGenerateColumns="true">
                </telerik:RadGrid>--%>

                 <telerik:RadGrid ID="GV_GrdProposal" runat="server" AllowPaging="True" 
        AllowSorting="True" GridLines="None" onitemcommand="GrdProposal_ItemCommand" 
        onneeddatasource="GrdProposal_NeedDataSource"
         Skin="Office2007">
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True"  />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf" />
            <Columns>
                <telerik:GridButtonColumn CommandName="Select" HeaderText="Select" 
                    Text="Select" UniqueName="column1">
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
        <PagerStyle Mode="NextPrev" />
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
            EnableImageSprites="True">
        </HeaderContextMenu>
    </telerik:RadGrid>


            </asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>

        </div>
        </div>


</asp:Content>
