<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOpportunityEBU.aspx.cs" Inherits="RainMaker.EBU.CreateOpportunityEBU" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<style scoped>
                                td
                                {
    }
                            .style1
    {
        width: 220px;
    }
                            </style>

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
        <div class="col-lg-12" style="background-color: #f66519; border-left:thick solid #03828a;margin-left:0.2em; height: 30px;">
            <h6 class="center-block" style="text-align: center; color: White;">
                Create Opportunity EBU</h6>
        </div>
    </div>
    <div class="container-fluid">

    <asp:UpdatePanel ID="UPPanel1" runat="server">
        <ContentTemplate>

        <asp:Panel ID="Pnl_QualifiedLeads" runat="server">
        <table class="nav-justified">
            <tr>
                    <td>
                        <telerik:RadButton ID="btSave" Text="Save" runat="server" 
                            onclick="btSave_Click">
                        </telerik:RadButton>
                                   
                         <telerik:RadButton ID="btnUpdate" Text="Update" onclick="btnUpdate_Click" runat="server">
                        </telerik:RadButton>
                                       
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                    </td>
                </tr>

            <tr>
                <td>
                    
                      Opportunity Name
                </td>
                <td style ="width :220px">
                   
                   <l><asp:Label ID="MandatryAC" runat="server" Text="*"></asp:Label></l>
                   <telerik:RadTextBox ID="txtOpportunityName"  runat="server" Width="150px" >
                    </telerik:RadTextBox>

                </td>

                 

                <td>
                  Customer Name
                   
                </td>
                <td class="style1" >
                 <l><asp:Label ID="Mandatry" runat="server" Text="*"></asp:Label></l>
                     <telerik:RadComboBox ID="cmbAccount" autopostback="true" runat="server" 
                        onselectedindexchanged="cmbAccount_SelectedIndexChanged" Width="150px" 
                        AllowCustomText="True" AppendDataBoundItems="True" Filter="StartsWith" 
                        Sort="Ascending" >
                    </telerik:RadComboBox>
                   
                    <asp:LinkButton ID="LinkCustAdd" runat="server" Font-Size="Smaller" 
                        onclick="LinkCustAdd_Click">Add Cust</asp:LinkButton>

                   

                    
                </td>

                
            </tr>

            <tr>
                <td>
                   Primary Contact
                </td>
               <td>
                    <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                    <telerik:RadComboBox ID="cmbPrimaryCustomer" runat="server" Width="150px" onselectedindexchanged="cmbPrimaryCustomer_SelectedIndexChanged" AutoPostBack ="true" >
                    </telerik:RadComboBox>
                                <label >
                    <asp:LinkButton ID="LnkCustomerContact" runat="server" autopostback ="true"
                        onclick="LnkCustomerContact_Click" Font-Size="Smaller">Add New</asp:LinkButton></label>
                </td>   
                
                
                <td>
                    Sales Stage
                </td>
                <td style ="width :315px">
                <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                    <telerik:RadComboBox ID="cmbSalesStage" 
                        onselectedindexchanged="cmbSalesStage_SelectedIndexChanged" AutoPostBack="true"
                     runat="server" Width="150px">
                    </telerik:RadComboBox>
                </td>       
            </tr>

            <tr>
            <td>
                     Win Prob</td>
                <td>                    
                   
                 <asp:Label ID="Label16" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadComboBox ID="txtWinProb" Runat="server" Width="150px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Low" Value="Low" />
                            <telerik:RadComboBoxItem runat="server" Text="Medium" Value="Medium" />
                            <telerik:RadComboBoxItem runat="server" Text="High" Value="High" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
               

                 
            </tr>
         
            <tr>

                 <asp:Panel ID="Pnl_Stages_Proposal" runat="server">
                    <td>
                  <asp:Label ID="lblRTR" runat="server" Text="Group RTR"></asp:Label>
                </td>
                 <td>
                     <asp:TextBox ID="GroupRTR" runat="server"></asp:TextBox>
                 </td>
                 <td>
                    <asp:Label ID="lblProposalIntDate" runat="server" Text="Proposal Initiation Date"></asp:Label>
                </td>
                 <td>
                    <telerik:RadDatePicker ID="DTProposalIntDate" runat="server">
                    </telerik:RadDatePicker>
                 </td>
                 <tr>
                    <td>
                    <asp:Label ID="lblOppRemarks" runat="server" Text="Remarks"></asp:Label>
                </td>
                 <td>
                     <asp:TextBox ID="txtOppRemarks" runat="server" Width ="200px" TextMode="MultiLine"></asp:TextBox>
                 </td>
                 </tr>
                  </asp:Panel>

            </tr>

            <tr>
                 <asp:Panel ID="Pnl_Stages_Negotiation" runat="server">
                     <td>
                        <asp:Label ID="lblNegotiationStatus" runat="server" Text="Negotiation Status"></asp:Label>
                     </td>
                    <td>
                     <asp:Label ID="Label60" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                        <telerik:RadComboBox ID="cmbNegotiation" Runat="server">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Negotiating - Decision" Value="Negotiating - Decision" />
                                <telerik:RadComboBoxItem runat="server" Text="Negotiating - Hold" Value="Negotiating - Hold" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="Hold Reason"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label55" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                        <telerik:RadTextBox ID="cmbHoldReason" Runat="server" Width ="200px" TextMode="MultiLine">
                        </telerik:RadTextBox>
                    </td>
                <tr>
                     <td>
                        <asp:Label ID="lblLastRevesionDate" runat="server" 
                        Text="Proposal Last Revesion Date"></asp:Label>
                    </td>

                    <td>
                    <asp:Label ID="Label56" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                        <telerik:RadDatePicker ID="cmbProposalLastRevesionDate" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                 <td>
                    <asp:Label ID="lblLastUpdateDate" runat="server" Text="Last Follow Up Date"></asp:Label>
                </td>
                <td>
                <asp:Label ID="Label57" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadDatePicker ID="cmbLastFollowUpDate" Runat="server">
                    </telerik:RadDatePicker>
                </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="Label21" runat="server" Text="Resume Date"></asp:Label>
                        </td>
                <td>
                <asp:Label ID="Label58" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadDatePicker ID="cmbResumeDate" Runat="server">
                    </telerik:RadDatePicker>
                
                </td>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Last Follow Up Remarks"></asp:Label>
                </td>
                <td>
                <asp:Label ID="Label59" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadTextBox ID="txtNegotiationRemarks" runat="server">
                    </telerik:RadTextBox>
                </td>
                </tr>
                 </asp:Panel>
                
            </tr>
          
            <tr>
                <asp:Panel ID="pnl_Stages_WonLost" runat="server">
                    <td>
                        Order Date
                </td>
                <td>
                 <asp:Label ID="Label30" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadDatePicker ID="cmbOrderDate" runat="server">
                    </telerik:RadDatePicker>
                </td>
                 <td>
                   Won/Lost Reason
                </td>
                <td>
                <asp:Label ID="Label32" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadTextBox ID="txtWonLostReason" runat="server">
                    </telerik:RadTextBox>
                </td>
                <tr>
                <td>
                   Deployment Date
                </td>
                <td>
                <asp:Label ID="Label31" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                    <telerik:RadDatePicker ID="cmbDeploymentDate" runat="server">
                    </telerik:RadDatePicker>
                </td>
                </tr>
                 </asp:Panel>
                
            </tr>
           

            <tr>
                <td>
                    <telerik:RadButton ID="btn_AddRevenueLines" runat="server" 
                        CausesValidation="false" onclick="btn_AddRevenueLines_Click" 
                        Text="Add Revenue Lines">
                    </telerik:RadButton>
                     
                </td>
               
                <asp:Panel ID="Pnl_RevenueLines" runat="server">
                    <tr>
                   
                        <td>
                            <strong>Revenue Lines</strong>
                            
                        </td>
                        <td colspan"3">
                        
                           <asp:Label ID="RevenueLineStatus" runat="server" Text="Status"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblProStatus" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         <asp:Label ID="lblSite_A_Address" runat="server" Text="Site A Address"></asp:Label>
                           
                        </td>
                        <td>
                         <asp:Label ID="Label14" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                         <telerik:RadTextBox ID="txtSiteAAddress" runat="server" Width ="150px">
                            </telerik:RadTextBox>
                        </td>
                        
                         <td>
                        <asp:Label ID="lblCustPOC" runat="server" Text="POC"></asp:Label>
                          
                        </td>
                        <td>
                        <asp:Label ID="Label10" runat="server" Text="*"></asp:Label>
                         <telerik:RadComboBox ID="cmbPOC" runat="server" width="150px">
                            </telerik:RadComboBox>
                        </td>

                        <td>
                            <asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label9" runat="server" Text="*"></asp:Label>
                         <telerik:RadComboBox ID="cmbRegionName" Runat="server" Width="150px">
                        </telerik:RadComboBox>
                          <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="Please-Select" ForeColor="#FF3300" ControlToValidate="cmbRegionName" />--%>
                        </td>

                    </tr>
                    <tr>
                        <td>
                        <asp:Label ID="Label17" runat="server" Text="City"></asp:Label>
                        
                          
                        </td>
                        <td>
                         <asp:Label ID="Label12" runat="server" Text="*"></asp:Label>
                         <telerik:RadComboBox ID="cmbCity" AutoPostBack="true"  runat="server"  AppendDataBoundItems="true" EmptyMessage="Select Area" OnSelectedIndexChanged="cmbCity_SelectedIndexChanged" Width="150px" >
                            </telerik:RadComboBox>
                           
                        
                        </td>
                        <td>
                         <asp:Label ID="lblArea" runat="server" Text="Area"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="Label8" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbArea" runat="server" width="150px">
                            </telerik:RadComboBox>
                       
                        </td>
                       
                       <td>
                         <asp:Label ID="lblBuilding" runat="server" Text="Building"></asp:Label>
                        </td>
                        <td style ="width:220px">
                        <asp:Label ID="Label7" runat="server" Text="*"></asp:Label>
                             <telerik:RadComboBox ID="cmbBuilding" runat="server" width ="150px">
                            </telerik:RadComboBox>
                        </td>

                        
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLat" runat="server" Text="Lat"></asp:Label>
                        </td>
                        <td>
                           <asp:Label ID="Label4" runat="server" Text="*"></asp:Label>
                            <telerik:RadTextBox ID="txtLat" runat="server" Width ="150px">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblLong" runat="server" Text="Long"></asp:Label>
                        </td>
                        <td>
                        
                             <asp:Label ID="Label5" runat="server" Text="*"></asp:Label>
                        <telerik:RadTextBox ID="txtLong" runat="server" width="150px">
                            </telerik:RadTextBox>
                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  SetFocusOnError="true" 
                                ErrorMessage="*" InitialValue="" ForeColor="#FF3300" ControlToValidate="txtLong" />--%>
                         

                        </td>
                         <td>
                            <asp:Label ID="lblSite_B_Address" runat="server" Text="Site B Address"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="Label15" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtSite_B_Address" runat="server" Width="150px">
                            </telerik:RadTextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Infra"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbInfra" runat="server" AutoPostBack ="true"  OnSelectedIndexChanged ="cmbInfra_SelectedIndexChanged" width="150px">
                            </telerik:RadComboBox>
                        </td>

                        <td>
                              <asp:Label ID="lblServiceunit" runat="server" Text="Service Unit"></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="Label11" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbServiceUnit" AutoPostBack ="true" width="150px" OnSelectedIndexChanged ="cmbServiceUnit_OnSelectedIndexChanged" runat="server">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                           <asp:Label ID="lblCircuitType" runat="server" Text="Circuit Type"></asp:Label>
                        </td>
                        <td>
                           <asp:Label ID="Label13" runat="server" Text="*"></asp:Label>
                            <telerik:RadComboBox ID="cmbCircuitType" runat="server" Width="150px">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                        <td>
                           <asp:Label ID="Label18" runat="server" Text="Estimated Price"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="Label26" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtEstimatedPrice" runat="server" Width="150px">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                           <asp:Label ID="Label19" runat="server" Text="Amount"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="Label29" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtAmount" runat="server" Width="150px">
                            </telerik:RadTextBox>
                        </td>
                         <td>
                    
                    <asp:Label ID="lblNRFrequest" runat="server" Text="NRF Request Date"></asp:Label>
                </td>
                <td>                    
                    <telerik:RadDatePicker ID="NRFRequestDate" runat="server" Width="150px">
                    </telerik:RadDatePicker>
                </td>
                    <tr>
                         <td>
                        <asp:Label ID="lblRemarksEBU" runat="server" Text="Remarks"  ></asp:Label>
                        </td>
                        <td colspan="5">
                         <asp:Label ID="Label27" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                         <telerik:RadTextBox ID="txtRemarksEBU" runat="server" width="970px" Height ="80px" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </td>
                        
                        <td>
                        
                        </td>
                        <td>
                           
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        
                        <td>
                            <%--<asp:Label ID="lblEstimatedPrice" runat="server" Text="Estimated Price"></asp:Label>--%>
                        </td>
                        <td>
                            <%--<telerik:RadTextBox ID="txtEstimated_Price"  runat="server">
                            </telerik:RadTextBox>--%>
                        </td>
                        
                    </tr>
                </asp:Panel>
                
                <asp:Panel ID="Pnl_Proposal" runat="server">
                    <tr>
                        <td>
                            <strong>Proposal</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblGroupRTR" runat="server" Text="Group RTR"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtGroupRTR" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblProposal_Initiation_Date" runat="server" 
                                Text="Proposal Initiation Date"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="DatePickerProposalInitiationDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtRemarks" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                </asp:Panel>

                <asp:Panel ID="Pnl_Negotiating" runat="server">
                    <tr>
                        <td>
                            <strong>Negotiating</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%-- <asp:Label ID="lblNegotiation_Status" runat="server" Text="Negotiation Status"></asp:Label>--%>
                        </td>
                        <td>
                            <%--<telerik:RadComboBox ID="cmbNegotiationStatus" runat="server">
                            </telerik:RadComboBox>
                        </td>--%>
                        <td>
                            <asp:Label ID="lblProposalLastRevisionDate" runat="server" 
                                Text="Proposal Last RevisionDate"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="DatePickerProposalLastRevisionDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="lblHoldReason" runat="server" Text="Hold Reason"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtHoldReason" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLastFollowUpDate" runat="server" Text="Last Follow Up Date"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="DatePickerLastFollowUpDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="lblLastFollowUpRemarks" runat="server" 
                                Text="Last Follow Up Remarks"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtLastFollowUpRemarks" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblResumeDate" runat="server" Text="Resume Date"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="DatePickerResumeDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                <asp:Panel ID="Pnl_WinLossforRevenue" runat="server">
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Win/loss Reason"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="Label28" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtWinlossReasonRevenue" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="Won Lost Status"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label33" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadComboBox ID="cmbWonLostStatusRevenue" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Won" Value="Low" />
                                    <telerik:RadComboBoxItem runat="server" Text="Lost" Value="Medium" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                 </asp:Panel>
                 </tr>
                <asp:Panel ID="Pnl_WonLost" runat="server">
                    <tr>
                        <td>
                            <strong>WonLost</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOrderDate" runat="server" Text="OrderDate"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label51" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadDatePicker ID="DatePickerOrderDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="lblDeploymentDate" runat="server" Text="Deployment Date"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label52" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadDatePicker ID="DatePickerDeploymentDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <asp:Label ID="lblWinlossReason" runat="server" Text="Win/loss Reason"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label53" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtWinlossReason" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Won Lost Status"></asp:Label>
                        </td>
                        <td>

                        <asp:Label ID="Label54" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadComboBox ID="cmbWonLostStatus" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Won" Value="Low" />
                                    <telerik:RadComboBoxItem runat="server" Text="Lost" Value="Medium" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
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
                        <asp:Label ID="Label34" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtInfraType" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>

                            <asp:Label ID="lblTotal_CAPEX_NRF_cost" runat="server" 
                                Text="Total CAPEX (NRF cost)"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label35" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtTotal_CAPEX_NRF_cost" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal_TAF_cost" runat="server" Text="Total TAF cost"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label36" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtTotalTAFcost" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl3PMRC" runat="server" Text="3P MRC"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label37" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txt3P_MRC" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbl3P_OTC" runat="server" Text="3P OTC"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label38" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txt3P_OTC" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblName_of_3P" runat="server" Text="Name of 3P"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label39" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtName_of_3P" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNodeName" runat="server" Text="Node Name"></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="Label40" runat="server" Text="0" ForeColor ="White" ></asp:Label>
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
                        <asp:Label ID="Label41" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtNRCActual" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            MRC-Actual
                        </td>
                        <td>
                        <asp:Label ID="Label42" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtMRCActual" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            NRR
                        </td>
                        <td>
                        <asp:Label ID="Label43" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtNRR" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MRR
                        </td>
                        <td>
                        <asp:Label ID="Label44" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtMRR" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Cost of Additional Equipment
                        </td>
                        <td>
                        <asp:Label ID="Label45" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtCost_of_Additional_Equipment" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Difference
                        </td>
                        <td>
                        <asp:Label ID="Label46" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="RadTxtDifference" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                       <td>
                            Payback Period
                        </td>
                        <td>
                        <asp:Label ID="Label47" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtPaybackPeriod" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Payback Period 35% diff
                        </td>
                        <td>
                        <asp:Label ID="Label48" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtPaybackPeriod35diff" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            MRC OTS
                        </td>
                        <td>
                        <asp:Label ID="Label49" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtMRCOTS" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            Cost to MPPL
                        </td>
                        <td>
                        <asp:Label ID="Label50" runat="server" Text="0" ForeColor ="White" ></asp:Label>
                            <telerik:RadTextBox ID="txtCosttoMPPL" runat="server">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                </asp:Panel>
            </tr>

            </asp:Panel>
            <tr>
            <td>
             
                <telerik:RadButton ID="btn_Add" Text="Add" runat="server" 
                    onclick="btn_Add_Click" >
                        </telerik:RadButton>
            </td>
        </tr>
        </table>


         <asp:Panel ID="Pnl_GrdRequirements" runat="server" Width="2000px">
                <telerik:RadGrid ID="GV_GrdRequirements" runat="server"  
                    onitemcommand="GV_GrdRequirements_ItemCommand" GridLines="None" 
                    onneeddatasource="GV_GrdRequirements_NeedDataSource" 
                    AutoGenerateColumns="False">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to Pdf" />
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" Text="Select" 
                                UniqueName="column1">
                            </telerik:GridButtonColumn>
                            <telerik:GridDropDownColumn UniqueName="column2">
                            </telerik:GridDropDownColumn>
                            <telerik:GridBoundColumn DataField="Site_A_Address" HeaderText="Site A Address" 
                                UniqueName="column3">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CC_Name" HeaderText="CC Name" 
                                UniqueName="column4">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RegionName" HeaderText="Region Name" 
                                UniqueName="column5">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CityName" HeaderText="City Name" 
                                UniqueName="column6">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BuildName" HeaderText="Build Name" 
                                UniqueName="column7">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Lat" HeaderText="Latitude" 
                                UniqueName="column8">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Long" HeaderText="Longitude" 
                                UniqueName="column9">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Site_B_Address" HeaderText="Site B Address" 
                                UniqueName="column10">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InfraDetail" HeaderText="Infra Detail" 
                                UniqueName="column11">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" 
                                UniqueName="column12">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Estimated_Price" 
                                HeaderText="Estimated Price" UniqueName="column13">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" 
                                UniqueName="column14">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ServiceUnit" HeaderText="Service Unit" 
                                UniqueName="column15">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OppName" HeaderText="Opp Name" 
                                UniqueName="column16">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CircuitType" HeaderText="Circuit Type" 
                                UniqueName="column17">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NRCActual" HeaderText="NRC Actual" 
                                UniqueName="column18">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MRCActual" HeaderText="MRC Actual" 
                                UniqueName="column19">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NRR" HeaderText="NRR" UniqueName="column20">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MRR" HeaderText="MRR" UniqueName="column21">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CostOfAdditionalEqp" 
                                HeaderText="Cost Of Additional Eqp" UniqueName="column22">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Difference" HeaderText="Difference" 
                                UniqueName="column23">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PaybackPeriod" HeaderText="Pay Back Period" 
                                UniqueName="column24">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MRCOTS" HeaderText="MR COTS" 
                                UniqueName="column25">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PaybackPeriod35difff" 
                                HeaderText="Pay BackPeriod difrence" UniqueName="column26">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CosttoMPPL" HeaderText="Cost to MPPL" 
                                UniqueName="column27">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InfraType" HeaderText="Infra Type" 
                                UniqueName="column28">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NRFCost" HeaderText="NRF Cost" 
                                UniqueName="column29">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OTCP3" HeaderText="OTC P3" 
                                UniqueName="column30">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MRCP3" HeaderText="MRC P3" 
                                UniqueName="column31">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalTAFcost" HeaderText="Total TAF Cost" 
                                UniqueName="column32">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameOf3P" HeaderText="Name Of 3P" 
                                UniqueName="column33">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NodeName" HeaderText="Node Name" 
                                UniqueName="column34">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OrderDate" HeaderText="Order Date" 
                                UniqueName="column35">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DeploymentDate" 
                                HeaderText="Deployment Date" UniqueName="column36">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="WonLostStatus" HeaderText="Won Lost Status" 
                                UniqueName="column37">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="WinLossReason" HeaderText="Win Loss Reason" 
                                UniqueName="column38">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LastUpdatedBy" HeaderText="Last Updated By" 
                                UniqueName="column">
                                <HeaderStyle Width="200px" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                        EnableImageSprites="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </asp:Panel>
            
            <asp:Panel ID="Pnl_GrdSurvey" runat="server">
                <telerik:RadGrid ID="GV_GrdSurvey" runat="server" 
                    AutoGenerateColumns="true" onneeddatasource="GV_GrdSurvey_NeedDataSource">
                </telerik:RadGrid>
            </asp:Panel> 
            
            
            <asp:Panel ID="Pnl_GrdBusinessCase" runat="server">
                <telerik:RadGrid ID="GV_GrdBusinessCase" runat="server" 
                    AutoGenerateColumns="true">
                </telerik:RadGrid>
            </asp:Panel> 
            <asp:Button ID="Button1" runat="server" Text="Hide" onclick="Button1_Click" 
                Visible="False" />  
            <asp:Button ID="btnProductsView" runat="server" onclick="btnProductsView_Click" 
                Text="Show Products" Visible="False" />
            <asp:Button ID="btnHideProducts" runat="server" onclick="btnHideProducts_Click" 
                Text="Hide Products" />
                
            <div>

                     <asp:Panel ID="Pnl_RevenueDetailsForProducts" runat="server">
                        <telerik:radbutton id="btn_SaveDetail" text="Save" runat="server" onclick="btn_SaveDetail_Click" >
                        </telerik:radbutton>
                        

                         <asp:GridView ID="RadgridForProducts" runat="server"  onitemcommand="RadgridForProducts_ItemCommand" 
                            Width="1000px" >
                       
                            <Columns>
                              
                               <asp:TemplateField HeaderText="Check">
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" Text=""  Width="10px" runat="server" />
                                </ItemTemplate>

                                    <FooterStyle Width="10px" />
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle Width="10px" />

                                 </asp:TemplateField>
                                <asp:BoundField DataField="ServiceUnit" HeaderText="Service Unit"  >
                                <ControlStyle Width="300px" />
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Bandwidth">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbQuantityUOM" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                    <HeaderStyle Width="200px" />
                                    
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Interface">
                                    <ItemTemplate>
                                        <%--<telerik:RadComboBox ID="cmbInterface" runat="server"                                                                                             
                                        </telerik:RadComboBox>--%>
                                        <asp:DropDownList ID="cmbInterface" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                    <HeaderStyle Width="200px" />
                                    
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="MRC3P">
                                    <ItemTemplate>
                                        <asp:textbox ID="txtMRC3p" runat="server" AppendDataBoundItems="true" Width="200px">
                                        
                                        </asp:textbox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                     <HeaderStyle Width="200px" />
                                </asp:TemplateField>
                               
                               
                                 <asp:TemplateField HeaderText="Actual MRC">
                                    <ItemTemplate>
                                        <asp:textbox ID="txtActualMRC" runat="server" AppendDataBoundItems="true" Width="200px">
                                        
                                        </asp:textbox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                     <HeaderStyle Width="200px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                     </asp:Panel>

                    </div>
                     <div>
                     <asp:Panel ID="ProductGridView" runat="server">
                        <telerik:radgrid id="GVProducts" runat="server">

                         </telerik:radgrid>
                     </asp:Panel>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>

</asp:Content>
