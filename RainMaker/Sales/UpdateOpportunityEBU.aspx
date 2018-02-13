<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateOpportunityEBU.aspx.cs" Inherits="RainMaker.WebForm11" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                    Create EBU Opportunity</h6>
            </div>
        </div>
        <div class="container">

        <asp:UpdatePanel ID="UPPanel1" runat="server" >
        <ContentTemplate>
 

      <table width="750px">
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
                    Customer Name</td>
             <td>
                    <telerik:RadComboBox ID="cmbAccount" runat="server" AutoPostBack ="true"  onselectedindexchanged="cmbAccount_SelectedIndexChanged" >
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
                    Primary Contact
                </td>
                <td>
                     <telerik:RadComboBox ID="cmbPrimaryContact" runat="server">
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
                     <telerik:RadComboBox ID="txtWinProb" Runat="server">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Low" Value="Low" />
                            <telerik:RadComboBoxItem runat="server" Text="Medium" Value="Medium" />
                            <telerik:RadComboBoxItem runat="server" Text="High" Value="High" />
                        </Items>
                    </telerik:RadComboBox>
                </td>

                

            
            </tr>

            

            

            

            <tr>

            <td>
                    KAM
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
                   <%-- <asp:Label ID="lblOrderDate" runat="server" Text="NRF Request Date"></asp:Label>--%>
                    
                    Order Date
                    
                </td>
                <td>                    
                   <%--<telerik:RadDatePicker ID="DatePickerNRFRequest" runat="server">
                    </telerik:RadDatePicker>--%>
                    <asp:Label ID="Label50" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadDatePicker ID="cmbOrderDate" runat="server">
                    </telerik:RadDatePicker>
                </td>

                <td>
                <asp:Label ID="lblDeploymentDate" runat="server" Text="Deployment Date"></asp:Label>
                    
                </td>
                <td> 
                <asp:Label ID="Label2" runat="server" Text="0" ForeColor ="White" ></asp:Label>                   
                     <telerik:RadDatePicker ID="DatePickerDeploymentDate" runat="server">
                    </telerik:RadDatePicker>
                </td>

                 <td>
                    <asp:Label ID="lblWinlossReason" runat="server" Text="Win/loss Reason"></asp:Label>
                </td>
                <td>    
                <asp:Label ID="Label3" runat="server" Text="0" ForeColor ="White" ></asp:Label>                
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
                <td>
                    GroupRTR
                </td>
                <td>
                    <telerik:RadTextBox ID="txtGroupRTR" ReadOnly="true"  runat="server">
                    </telerik:RadTextBox>
                </td>
            
            </tr>

            <tr>
               <td>
                    <asp:Label ID="lblProposalIntDate" runat="server" Text="Proposal Initiation Date"></asp:Label>
                </td>
                 <td>
                    <telerik:RadDatePicker ID="DTProposalIntDate" runat="server">
                    </telerik:RadDatePicker>
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
            <tr>
                <td>
                    <asp:Label ID="lblOppRemarks" runat="server" Text="Remarks"></asp:Label>
                </td>
                 <td>
                     <asp:TextBox ID="txtOppRemarks" runat="server" Width ="200px" TextMode="MultiLine"></asp:TextBox>
                 </td>
                 <td>
                        <asp:Label ID="lblNegotiationStatus" runat="server" Text="Negotiation Status"></asp:Label>
                     </td>
                    <td>
                        <telerik:RadComboBox ID="cmbNegotiation" Runat="server">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Negotiating - Decision" Value="Negotiating - Decision" />
                                <telerik:RadComboBoxItem runat="server" Text="Negotiating - Hold" Value="Negotiating - Hold" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:Label ID="lblLastRevesionDate" runat="server" 
                        Text="Proposal Last Revesion Date"></asp:Label>
                    </td>

                    <td>
                        <telerik:RadDatePicker ID="cmbProposalLastRevesionDate" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastUpdateDate" runat="server" Text="Last Follow Up Date"></asp:Label>
                </td>
                <td>
                    <telerik:RadDatePicker ID="cmbLastFollowUpDate" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Last Follow Up Remarks"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtNegotiationRemarks" runat="server">
                    </telerik:RadTextBox>
                </td>
                <td>
                        <asp:Label ID="Label21" runat="server" Text="Resume Date"></asp:Label>
                        </td>
                <td>
                
                    <telerik:RadDatePicker ID="cmbResumeDate" Runat="server">
                    </telerik:RadDatePicker>
                
                </td>
            </tr>
            <tr>
                <td>
                        <asp:Label ID="Label22" runat="server" Text="Hold Reason"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="cmbHoldReason" Runat="server" Width ="200px" TextMode="MultiLine">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        NRF Request Date</td>
                <td>
                    <telerik:RadDatePicker ID="DatePickerBudgetaryQuoteDate0" runat="server">
                    </telerik:RadDatePicker>
                </td>
                <td>
                   Won/Lost Reason
                </td>
                <td>
                    <telerik:RadTextBox ID="txtWonLostReason" runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                   Deployment Date
                </td>
                <td>
                    <telerik:RadDatePicker ID="cmbDeploymentDate" runat="server">
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


                <%--<td>
                    Site A Country
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteACountry" runat="server" >
                    </telerik:RadComboBox>
                </td>--%>

                <td>
                    City
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbSiteACity" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="cmbSiteACity_SelectedIndexChanged" >
                    </telerik:RadComboBox>
                </td>
                <td>
                     <asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label>
                </td>
                <td>
                   <%-- <asp:Label ID="Label9" runat="server" Text="*"></asp:Label>--%>
                        <telerik:RadComboBox ID="cmbRegionName" Runat="server" Width="150px">
                        </telerik:RadComboBox>
                 </td>
                
            </tr>


             <tr>
            
            <td>
                    Site B Address
                </td>
                <td>                    
                    <telerik:RadTextBox ID="txtSiteAddress"  runat="server">
                    </telerik:RadTextBox>
                </td>

               <td>
                    Area
                </td>
                <td> 
                    <telerik:RadComboBox ID="cmbArea" runat="server">
                    </telerik:RadComboBox>  
                    
                </td>
                <td>
                    Estimated Price
                </td>            

                 <td>                    
                   <telerik:RadTextBox ID="Estimated_Price"  runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>

             <tr>
            
             <td>
                         <asp:Label ID="lblBuilding" runat="server" Text="Building"></asp:Label>
                       </td>
                       <td style ="width:220px">
                        <%--<asp:Label ID="Label7" runat="server" Text="*"></asp:Label>--%>
                             <telerik:RadComboBox ID="cmbBuilding" runat="server" width ="150px">
                            </telerik:RadComboBox>
                       </td>
            <td>
                    On Site POC
                </td>
                <td>                    
                    <telerik:RadComboBox ID="cmbPOC" runat="server" width="150px">
                    </telerik:RadComboBox>
                </td>

                <td>
                    Remarks
                </td>
                <td>
                    <telerik:RadTextBox ID="Remarks"  runat="server">
                    </telerik:RadTextBox>
                </td>
              
            </tr>


             <tr>
            
                
                  <td>
                    Amount
                </td>
                <td>
                  <telerik:RadTextBox ID="Amount"  runat="server">
                    </telerik:RadTextBox>
                </td>
                <td>
                    NRF Request Date
                </td>
                <td> 
                  <telerik:RadDatePicker ID="DatePickerNRFRequest" runat="server">
                    </telerik:RadDatePicker>           
                    
                </td>

                 <td>
                           <asp:Label ID="Label1" runat="server" Text="Infra"></asp:Label>
                 </td>
                   <td>
                            <asp:Label ID="Label6" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbInfra" runat="server" AutoPostBack ="true"   width="150px">
                            </telerik:RadComboBox>
                   </td>
            </tr>

             <tr>
                <td>
                    <asp:Label ID="lblLat" runat="server" Text="Lat"></asp:Label>
                </td>
                <td>
                    <%--<asp:Label ID="Label4" runat="server" Text="*"></asp:Label>--%>
                        <telerik:RadTextBox ID="txtLat" runat="server" Width ="150px">
                        </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="lblLong" runat="server" Text="Long"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtLong" runat="server" width="150px">
                    </telerik:RadTextBox>
                </td>  
                <td>
                    <asp:Label ID="lblServiceunit" runat="server" Text="Service Unit"></asp:Label>
                 </td>
                 <td>
                    <asp:Label ID="Label11" runat="server" Text="*"></asp:Label>
                       <telerik:RadComboBox ID="cmbServiceUnit" AutoPostBack ="true" width="150px" OnSelectedIndexChanged ="cmbServiceUnit_OnSelectedIndexChanged" runat="server">
                       </telerik:RadComboBox>
                 </td>  
            </tr>

            <tr>
            <td>
                           <asp:Label ID="lblCircuitType" runat="server" Text="Circuit Type"></asp:Label>
                        </td>
                        <td>
                           <asp:Label ID="Label13" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbCircuitType" runat="server">
                            </telerik:RadComboBox>
                        </td>

                  
            
            </tr>
            

           <%-- <asp:Panel ID="Pnl_Proposal" runat="server">


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


            </asp:Panel>--%>
            
            </asp:Panel>

             <asp:Panel ID="Pnl_Survey" runat="server">
                    <tr>
                        <td>
                            <strong>Survey</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInfraType" runat="server" Text="Infra Type"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtInfraType" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal_CAPEX_NRF_cost" runat="server" 
                                Text="Total CAPEX (NRF cost)"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtTotal_CAPEX_NRF_cost" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal_TAF_cost" runat="server" Text="Total TAF cost"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtTotalTAFcost" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl3PMRC" runat="server" Text="3P MRC"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txt3P_MRC" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbl3P_OTC" runat="server" Text="3P OTC"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txt3P_OTC" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblName_of_3P" runat="server" Text="Name of 3P"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtName_of_3P" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNodeName" runat="server" Text="Node Name"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtNodeName" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                </asp:Panel>

               <asp:Panel ID="Pnl_BusinessCase" runat="server">
                    <tr>
                        <td>
                            <strong>BusinessCase</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            NRC-Actual
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtNRCActual" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            MRC-Actual
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtMRCActual" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            NRR
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtNRR" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MRR
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtMRR" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Cost of Additional Equipment
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtCost_of_Additional_Equipment" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Difference
                        </td>
                        <td>
                            <telerik:RadTextBox ID="RadTxtDifference" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                       <td>
                            Payback Period
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtPaybackPeriod" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Payback Period 35% diff
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtPaybackPeriod35diff" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            MRC OTS
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtMRCOTS" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            Cost to MPPL
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtCosttoMPPL" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                </asp:Panel>
                 <asp:Panel ID="Pnl_WinLossforRevenue" runat="server">
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Win/loss Reason"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtWinlossReasonRevenue" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="Won Lost Status"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmbWonLostStatusRevenue" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Won" Value="Low" />
                                    <telerik:RadComboBoxItem runat="server" Text="Lost" Value="Medium" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
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
