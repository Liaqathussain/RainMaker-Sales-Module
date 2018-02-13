using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.IO;
using System.Data;

namespace RainMaker
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        BL obj_BL = new BL();
        int _OppId;
        string NRFReqDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                _OppId = Convert.ToInt32(base.Request.QueryString["OppID"]);
                ViewState["OppID"] = _OppId;

                DataTable dt_OpportunityById = obj_clsOpportunity.GetOpportunityByIDEBU(_OppId);
                Datevalidation();
                if (dt_OpportunityById.Rows.Count > 0)
                {
                    ViewState["OpportunityID"] = dt_OpportunityById.Rows[0]["OppID"].ToString();
                    ViewState["OppDetEBUID"] = dt_OpportunityById.Rows[0]["OppDetEBUID"].ToString();
                    txtOpportunityName.Text = dt_OpportunityById.Rows[0]["OppName"].ToString();
                    cmbSalesStage.SelectedValue = dt_OpportunityById.Rows[0]["OppStageID"].ToString();
                    cmbAccount.SelectedValue = dt_OpportunityById.Rows[0]["PartnerID"].ToString();
                    cmbOppStatus.SelectedValue = dt_OpportunityById.Rows[0]["OppStatusID"].ToString();
                    txtWinProb.Text = dt_OpportunityById.Rows[0]["WinProbability"].ToString();
                    txtLat.Text = dt_OpportunityById.Rows[0]["Lat"].ToString();
                    txtLong.Text = dt_OpportunityById.Rows[0]["Long"].ToString();
                    //if (dt_OpportunityById.Rows[0]["NRFRequestDate"].ToString() != "")
                    //{
                    //    DatePickerNRFRequest.SelectedDate = Convert.ToDateTime(dt_OpportunityById.Rows[0]["NRFRequestDate"].ToString());
                    //}
                   
                    cmbInfra.SelectedValue = dt_OpportunityById.Rows[0]["InfraID"].ToString();
                    cmbSiteACity.SelectedValue = dt_OpportunityById.Rows[0]["CityID"].ToString();
                    txtSiteAAddress.Text = dt_OpportunityById.Rows[0]["Site_A_Address"].ToString();
                    txtSiteAddress.Text  = dt_OpportunityById.Rows[0]["Site_B_Address"].ToString();
                    cmbBuilding.SelectedValue  = dt_OpportunityById.Rows[0]["BuildID"].ToString();
                    cmbPOC.SelectedValue = dt_OpportunityById.Rows[0]["CC_ID"].ToString();
                    Remarks.Text = dt_OpportunityById.Rows[0]["Remarks"].ToString();
                    Estimated_Price.Text = dt_OpportunityById.Rows[0]["Estimated_Price"].ToString ();
                    Amount.Text = dt_OpportunityById.Rows[0]["Amount"].ToString();
                    cmbServiceUnit.SelectedValue = dt_OpportunityById.Rows[0]["ServiceUnitID"].ToString();
                    cmbRegionName.SelectedValue = dt_OpportunityById.Rows[0]["RegionID"].ToString();
                    cmbPrimaryContact.SelectedValue = dt_OpportunityById.Rows[0]["CC_ID"].ToString();
                    txtOppRemarks.Text = dt_OpportunityById.Rows[0]["Opp_Remarks"].ToString();
                    if (dt_OpportunityById.Rows[0]["ProposalIntDate"].ToString() != null & dt_OpportunityById.Rows[0]["ProposalIntDate"].ToString() !="" & dt_OpportunityById.Rows[0]["ProposalIntDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        DTProposalIntDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["ProposalIntDate"].ToString());
                    }
                    txtNegotiationRemarks.Text = dt_OpportunityById.Rows[0]["NegotiationRemarks"].ToString();
                    txtGroupRTR.Text = dt_OpportunityById.Rows[0]["GroupRTR"].ToString();
                    if (dt_OpportunityById.Rows[0]["NegotiationResumeDate"].ToString() != null & dt_OpportunityById.Rows[0]["NegotiationResumeDate"].ToString() != "" & dt_OpportunityById.Rows[0]["NegotiationResumeDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        cmbResumeDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["NegotiationResumeDate"].ToString());
                    }
                    txtWonLostReason.Text = dt_OpportunityById.Rows[0]["WinLossReason"].ToString();
                    cmbHoldReason.Text = dt_OpportunityById.Rows[0]["NegotiationHoldReason"].ToString();
                    txtAttachement.Text = dt_OpportunityById.Rows[0]["Attachment1"].ToString();
                    cmbCurrency.SelectedValue = dt_OpportunityById.Rows[0]["CurrencyID"].ToString();
                    if (dt_OpportunityById.Rows[0]["Opp_OrderDate"].ToString() != null & dt_OpportunityById.Rows[0]["Opp_OrderDate"].ToString() != "" & dt_OpportunityById.Rows[0]["Opp_OrderDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        cmbOrderDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["Opp_OrderDate"].ToString());
                    }
                    if (dt_OpportunityById.Rows[0]["NegotiationProposalRevisionDate"].ToString() != null & dt_OpportunityById.Rows[0]["NegotiationProposalRevisionDate"].ToString() != "" & dt_OpportunityById.Rows[0]["NegotiationProposalRevisionDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        cmbProposalLastRevesionDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["NegotiationProposalRevisionDate"].ToString());
                    }
                    if (dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != null & dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != "" & dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        cmbLastFollowUpDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString());
                    }
                    if (dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != null & dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != "" & dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        cmbDeploymentDate.SelectedDate = DateTime.Parse(dt_OpportunityById.Rows[0]["NegotiationFollowUpDate"].ToString());
                    }
                    txtNRCActual.Text= dt_OpportunityById.Rows[0]["NRCActual"].ToString();
                    txtMRCActual.Text = dt_OpportunityById.Rows[0]["MRCActual"].ToString();
                    txtNRR.Text = dt_OpportunityById.Rows[0]["NRR"].ToString();
                    txtMRR.Text = dt_OpportunityById.Rows[0]["MRR"].ToString();
                    //proposal
                    cmbCircuitType.SelectedValue = dt_OpportunityById.Rows[0]["CircuitType"].ToString();

                    //Survay
                    txtInfraType.Text = dt_OpportunityById.Rows[0]["InfraDetail"].ToString();
                    txtTotal_CAPEX_NRF_cost.Text = dt_OpportunityById.Rows[0]["NRFCost"].ToString();
                    txtTotalTAFcost.Text = dt_OpportunityById.Rows[0]["TotalTAFcost"].ToString();
                    txt3P_MRC.Text = dt_OpportunityById.Rows[0]["MRCP3"].ToString();
                    txt3P_OTC.Text = dt_OpportunityById.Rows[0]["OTCP3"].ToString();
                    txtName_of_3P.Text = dt_OpportunityById.Rows[0]["NameOf3P"].ToString();
                    txtNodeName.Text = dt_OpportunityById.Rows[0]["NodeName"].ToString();
                    //Business Case
                    txtNRCActual.Text = dt_OpportunityById.Rows[0]["NRCActual"].ToString();
                    txtMRCActual.Text = dt_OpportunityById.Rows[0]["MRCActual"].ToString();
                    txtNRR.Text = dt_OpportunityById.Rows[0]["NRR"].ToString();
                    txtMRR.Text = dt_OpportunityById.Rows[0]["MRR"].ToString();
                    txtCost_of_Additional_Equipment.Text = dt_OpportunityById.Rows[0]["CostOfAdditionalEqp"].ToString();
                    RadTxtDifference.Text = dt_OpportunityById.Rows[0]["Difference"].ToString();
                    txtPaybackPeriod.Text = dt_OpportunityById.Rows[0]["PaybackPeriod"].ToString();
                    txtPaybackPeriod35diff.Text = dt_OpportunityById.Rows[0]["PaybackPeriod35difff"].ToString();
                    txtMRCOTS.Text = dt_OpportunityById.Rows[0]["MRCOTS"].ToString();
                    txtCosttoMPPL.Text = dt_OpportunityById.Rows[0]["CosttoMPPL"].ToString();
                    //Won Los
                    txtWinlossReasonRevenue.Text = dt_OpportunityById.Rows[0]["WinLossReason"].ToString();
                    cmbWonLostStatusRevenue.Text = dt_OpportunityById.Rows[0]["WonLostStatus"].ToString();



                    //if (txtNRCActual.Text.Equals(""))
                    //{
                    //    txtNRCActual.Text = "0.0";
                    //}

                    //if (txtMRCActual.Text.Equals(""))
                    //{
                    //    txtMRCActual.Text = "0.0";
                    //}

                    //if (txtNRR.Text.Equals(""))
                    //{
                    //    txtNRR.Text = "0.0";
                    //}

                    //if (txtMRR.Text.Equals(""))
                    //{
                    //    txtMRR.Text = "0.0";
                    //}

                    //if (txtROI.Text.Equals(""))
                    //{
                    //    txtROI.Text = "0.0";
                    //}

                    //if (txtTermProfit.Text.Equals(""))
                    //{
                    //    txtTermProfit.Text = "0.0";
                    //}

                    //if (txtTermRevenue.Text.Equals(""))
                    //{
                    //    txtTermRevenue.Text = "0.0";
                    //}

                    //if (txtRecurringMargin.Text.Equals(""))
                    //{
                    //    txtRecurringMargin.Text = "0.0";
                    //}

                    //if (txtNonRecurringMargin.Text.Equals(""))
                    //{
                    //    txtNonRecurringMargin.Text = "0.0";
                    //}


                    GetOppStages();
                    GetAccounts();
                    GetInfra();
                    BindGrdDetails();
                    GetCircuitType();
                    GetName();
                    GetEndCustomer();
                    GetOppStatus();
                    GetCurrency();
                    GetCityA();
                    GetArea();
                    GetPOC();
                    GetRegionName();
                    //ShowBuilding();
                    GetCurrencyDetail();
                    GetOppStatusDetail();
                    //GetName();
                    //GetQuantityUOM();
                    System.DateTime dt = DateTime.Now;
                    DatePickerBudgetaryQuoteDate.SelectedDate = dt;
                    DatePickerQuoteProposalDate.SelectedDate = dt;

                    //Pnl_Opportunity.Visible = false;


                    txtKAM.Text = Session["Name"].ToString();
                    txtWorkingBy.Text = Session["Name"].ToString();
                    txtLastUpdateBy.Text = Session["Name"].ToString();
                    txtLastUpdatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");



                    //lblOrderDate.Visible = false;
                    //DatePickerOrderDate.Visible = false;

                    lblDeploymentDate.Visible = false;
                    DatePickerDeploymentDate.Visible = false;

                    lblWinlossReason.Visible = false;
                    txtWinlossReason.Visible = false;

                    
                   
                    lblBudgetaryQuoteDate.Visible = false;
                    DatePickerBudgetaryQuoteDate.Visible = false;

                    ///proposal
                    ///
                    //Pnl_Proposal.Visible = false;
                    lblQuoteProposalDate.Visible = false;
                    DatePickerQuoteProposalDate.Visible = false;
                }

            }

        }
        protected void Datevalidation()
        {

            if (DTProposalIntDate.SelectedDate == null)
            {
                NRFReqDate = "1900-01-01";
            }
            else
            {
                //NRFReqDate = Convert.ToString(NRFRequestDate.SelectedDate);
            }

            if (DTProposalIntDate.SelectedDate == null)
            {
                //DTPropIntDate = "1900-01-01";
            }
            else
            {
                //DTPropIntDate = Convert.ToString(DTProposalIntDate.SelectedDate);
            }

            if (cmbProposalLastRevesionDate.SelectedDate == null)
            {
                //ProposalLastRevesionDate = "1900-01-01";
            }
            else
            {
                //ProposalLastRevesionDate = Convert.ToString(cmbProposalLastRevesionDate.SelectedDate);
            }

            if (cmbLastFollowUpDate.SelectedDate == null)
            {
                //LastFollowUpDate = "1900-01-01";
            }
            else
            {
                //LastFollowUpDate = Convert.ToString(cmbLastFollowUpDate.SelectedDate);
            }

            if (cmbResumeDate.SelectedDate == null)
            {
                //ResumeDate = "1900-01-01";
            }
            else
            {
                //ResumeDate = Convert.ToString(cmbResumeDate.SelectedDate);
            }

            if (cmbOrderDate.SelectedDate == null)
            {
                //OrderDateOpp = "1900-01-01";
            }
            else
            {
                //OrderDateOpp = Convert.ToString(cmbResumeDate.SelectedDate);
            }

            if (cmbDeploymentDate.SelectedDate == null)
            {
                //DeploymentDateOpp = "1900-01-01";
            }
            else
            {
                //DeploymentDateOpp = Convert.ToString(cmbDeploymentDate.SelectedDate);
            }
            if (txtNRCActual.Text == "")
            {
                txtNRCActual.Text = "0";
            }

            if (txtMRCActual.Text == "")
            {
                txtMRCActual.Text = "0";
            }

            if (txtNRR.Text == "")
            {
                txtNRR.Text = "0";
            }

            if (txtMRR.Text == "")
            {
                txtMRR.Text = "0";
            }

            if (txtCost_of_Additional_Equipment.Text == "")
            {
                txtCost_of_Additional_Equipment.Text = "0";
            }

            if (RadTxtDifference.Text == "")
            {
                RadTxtDifference.Text = "0";
            }

            if (txtPaybackPeriod.Text == "")
            {
                txtPaybackPeriod.Text = "0";
            }

            if (txtPaybackPeriod35diff.Text == "")
            {
                txtPaybackPeriod35diff.Text = "0";
            }

            if (txtMRCOTS.Text == "")
            {
                txtMRCOTS.Text = "0";
            }

            if (txtCosttoMPPL.Text == "")
            {
                txtCosttoMPPL.Text = "0";
            }
        }
        protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {

            if (e.Item.Text == "Save")
            {
                Save();
            }
        }
        private void ShowBuilding()
        {
            DataTable dt = obj_clsGeneralFunction.GetBuildingByCityName("Karachi");
            if (dt.Rows.Count > 0)
            {
                cmbBuilding.DataSource = dt;
                cmbBuilding.DataTextField = "BuildName";
                cmbBuilding.DataValueField = "BuildID";
                cmbBuilding.DataBind();
                cmbBuilding.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                //BuildID = Convert.ToInt32(cmbBuilding.SelectedItem.Value);
            }
            else
            {
                cmbBuilding.DataSource = null;
            }

           

        }
        private void GetRegionName()
        {
            obj_BL.GetRegionName(cmbRegionName, null, null);
        }
        private void GetOppStages()
        {
            DataTable dt_GetStages = obj_clsGeneralFunction.GetOppStages(1);
            cmbSalesStage.DataSource = dt_GetStages;
            cmbSalesStage.DataTextField = "OppStage";
            cmbSalesStage.DataValueField = "OppStageID";
            cmbSalesStage.DataBind();
            cmbSalesStage.Items.Insert(0, new RadComboBoxItem("Requirements", "11"));

            //DataTable dt_GetStages = obj_clsGeneralFunction.GetOppStages(2);
            //cmbSalesStage.DataSource = dt_GetStages;
            //cmbSalesStage.DataTextField = "OppStage";
            //cmbSalesStage.DataValueField = "OppStageID";
            //cmbSalesStage.DataBind();
            //cmbSalesStage.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }
        protected void cmbServiceUnit_OnSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        private void BindGrdDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityDetailsEBU(Convert.ToInt32(ViewState["OppID"]));
            GV_CreateOpportunity.DataSource = dt_GetOppDetails;
            GV_CreateOpportunity.DataBind();

           

                //GV_CreateOpportunity.MasterTableView.GetColumn("CityID").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("InfraID").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("RegionID").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("CC_ID").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("ServiceUnitID").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("LocationCode").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("CircuitType").Display = false;
                //GV_CreateOpportunity.MasterTableView.GetColumn("LOB_ID").Display = false;

           
        }
        private void GetName()
        {
            obj_BL.getServicesUnitByInfra(0, cmbServiceUnit);

        }
        private void BindGrdBudgetary()
        {
            DataTable dt_GetBudgetary = obj_clsGeneralFunction.GetOpportunityBudgetary();
            GV_GrdBudgetary.DataSource = dt_GetBudgetary;
            GV_GrdBudgetary.DataBind();
        }

        private void BindGrdProposal()
        {
            DataTable dt_GetStages = obj_clsGeneralFunction.GetOpportunityProposal(Convert.ToInt32(ViewState["OppID"]));
            GV_GrdProposal.DataSource = dt_GetStages;
            GV_GrdProposal.DataBind();
        }

        private void GetCircuitType()
        {
            obj_BL.loadCircuitType(cmbCircuitType, 9);
        }
        private void GetInfra()
        {
            obj_BL.GetInfra(cmbInfra, 0, 2);

        }
        private void GetAccounts()
        {
            //DataTable dt_GetDomain = obj_clsGeneralFunction.GetAllAccounts();
            //cmbAccount.DataSource = dt_GetDomain;
            //cmbAccount.DataTextField = "Customer";
            //cmbAccount.DataValueField = "CustomerCode";
            //cmbAccount.DataBind();
            //cmbAccount.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

            obj_BL.loadCusCode(cmbAccount, null, null);


        }

        private void GetOppStatus()
        {
            DataTable dt_GetStatus = obj_clsGeneralFunction.GetOppStatus();
            cmbOppStatus.DataSource = dt_GetStatus;
            cmbOppStatus.DataTextField = "OppStatus";
            cmbOppStatus.DataValueField = "OppStatusID";
            cmbOppStatus.DataBind();
            cmbOppStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }

        private void GetOppStatusDetail()
        {
            //DataTable dt_GetStatus = obj_clsGeneralFunction.GetOppStatus();
            //cmbStatus.DataSource = dt_GetStatus;
            //cmbStatus.DataTextField = "OppStatus";
            //cmbStatus.DataValueField = "OppStatusID";
            //cmbStatus.DataBind();
            //cmbStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }

        private void GetCurrency()
        {
            DataTable dt_GetCurrency = obj_clsGeneralFunction.GetCurrency();
            cmbCurrency.DataSource = dt_GetCurrency;
            cmbCurrency.DataTextField = "CurrencyName";
            cmbCurrency.DataValueField = "CurrencyID";
            cmbCurrency.DataBind();
            cmbCurrency.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }



        private void GetCurrencyDetail()
        {
            //DataTable dt_GetCurrency = obj_clsGeneralFunction.GetCurrency();
            //cmbCurrencyDetail.DataSource = dt_GetCurrency;
            //cmbCurrencyDetail.DataTextField = "CurrencyName";
            //cmbCurrencyDetail.DataValueField = "CurrencyID";
            //cmbCurrencyDetail.DataBind();
            //cmbCurrencyDetail.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }

        public void GetEndCustomer()
        {
            string RefID = cmbAccount.SelectedValue.ToString();
            DataTable dtCustomerContact = obj_clsGeneralFunction.GetPrimaryContacts(RefID);
            if (dtCustomerContact.Rows.Count > 0)
            {
                cmbPrimaryContact.DataSource = dtCustomerContact;
                cmbPrimaryContact.DataTextField = "CC_Name";
                cmbPrimaryContact.DataValueField = "CC_ID";
                cmbPrimaryContact.DataBind();
                cmbPrimaryContact.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
            else
            {
                cmbPrimaryContact.Items.Clear();
            }
        }

        private void GetCityA()
        {
            obj_BL.loadCity(cmbSiteACity);

        }
        private void GetArea()
        {
            int CityID = Convert.ToInt32(cmbSiteACity.SelectedValue);
            dynamic dt = objBSS.GetAreaByCityID(CityID);
            if (dt.Rows.Count > 0)
            {
                cmbArea.DataSource = dt;
                cmbArea.DataTextField = "Area";
                cmbArea.DataValueField = "AreaID";
                cmbArea.DataBind();
            }


        }

        private void GetPOC()
        {
            string RefID = cmbAccount.SelectedValue.ToString();
            DataTable dtCustomerContact = obj_clsGeneralFunction.GetPrimaryContacts(RefID);
            if (dtCustomerContact.Rows.Count > 0)
            {
                cmbPOC.DataSource = dtCustomerContact;
                cmbPOC.DataTextField = "CC_Name";
                cmbPOC.DataValueField = "CC_ID";
                cmbPOC.DataBind();
                cmbPOC.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
            else
            {
                cmbPOC.Items.Clear();
            }
        }

        private void Save()
        {

            string Attachment = "";
            if (RadAttachment.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadAttachment.UploadedFiles)
                {
                    string targetFolder = Server.MapPath("~/Folder/");
                    file.SaveAs(Path.Combine(targetFolder, "File" + "-" + file.FileName));
                    //file.SaveAs(Path.Combine("test" + "-" + file.FileName));
                    //Me.WriteToFile("btnSubmit: " & targetFolder & TicketNo & "-" & file.FileName)
                    Attachment = DateTime.Now.ToShortDateString() + "-" + file.FileName;
                }
            }
            else
            {
                Attachment = "";
            }
            Datevalidation();
            DateTime BudgetaryQuoteDate = Convert.ToDateTime(DatePickerBudgetaryQuoteDate.SelectedDate.Value.ToShortDateString());
            DateTime QuoteProposalDate = Convert.ToDateTime(DatePickerQuoteProposalDate.SelectedDate.Value.ToShortDateString());
            if (DatePickerNRFRequest.SelectedDate != null)
            {
                NRFReqDate = DatePickerNRFRequest.SelectedDate.Value.ToShortDateString();
                
            }
           
            object obj_OpportunityId = obj_clsOpportunity.UpdateOpportunityEBU(Convert.ToInt32(ViewState["OpportunityID"]), txtOpportunityName.Text, Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbPOC.SelectedValue), Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), 1, Convert.ToInt16(cmbSalesStage.SelectedValue), 1, txtWinProb.Text, txtGroupRTR.Text, Convert.ToString(DTProposalIntDate.SelectedDate), txtOppRemarks.Text, cmbNegotiation.SelectedValue, Convert.ToString(cmbProposalLastRevesionDate.SelectedDate), Convert.ToString(cmbLastFollowUpDate.SelectedDate), txtNegotiationRemarks.Text, Convert.ToString(cmbResumeDate.SelectedDate), cmbHoldReason.Text, Convert.ToString(cmbOrderDate.SelectedDate), txtWonLostReason.Text, Convert.ToString(cmbDeploymentDate.SelectedDate));
            obj_clsOpportunity.UpdateOpportunityDetailsEBU(Convert.ToInt32(ViewState["OpportunityID"]), 1, Convert.ToInt32(cmbServiceUnit.SelectedValue), Convert.ToInt32(cmbRegionName.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), 1, Convert.ToInt32(cmbBuilding.SelectedValue), txtSiteAAddress.Text, txtSiteAddress.Text, txtLat.Text, txtLong.Text, Convert.ToInt32(cmbPOC.SelectedValue), Convert.ToInt32(cmbCircuitType.SelectedValue), Remarks.Text, Convert.ToInt32(Estimated_Price.Text), Convert.ToInt32(Amount.Text), Convert.ToInt32(txtNRCActual.Text), Convert.ToInt32(txtMRCActual.Text), Convert.ToInt32(txtNRR.Text), Convert.ToInt32(txtMRR.Text), Convert.ToInt32(txtCost_of_Additional_Equipment.Text), Convert.ToInt32(RadTxtDifference.Text), Convert.ToInt32(txtPaybackPeriod.Text), Convert.ToInt32(txtPaybackPeriod35diff.Text), Convert.ToInt32(txtMRCOTS.Text), Convert.ToInt32(txtCosttoMPPL.Text), txtInfraType.Text, txtTotal_CAPEX_NRF_cost.Text, txtTotalTAFcost.Text, txt3P_MRC.Text, txt3P_OTC.Text, txtName_of_3P.Text, txtNodeName.Text, cmbWonLostStatusRevenue.Text, txtWinlossReasonRevenue.Text, Convert.ToString(NRFReqDate), Convert.ToInt32(Session["UserID"]));

            BindGrdDetails();
            //obj_clsOpportunity.UpdateOpportunityDetailsEBU("EBU", "", Convert.ToInt32(cmbSiteACity.SelectedValue), Convert.ToInt32(txtArea.Text), txtBuilding.Text, txtSiteAAddress.Text, txtSiteAddress.Text, txtOn_Site_POC.Text, Product_Name.Text, cmbQuantityUOM.Text, Convert.ToInt32(Quentity.Text), Google_Coordinates.Text, SD_Team.Text, Topology.Text, Remarks.Text, Convert.ToInt32(Estimated_Price.Text), Convert.ToInt32(Amount.Text), Convert.ToInt32(ViewState["OppID"]), txtNRCActual.Text, txtMRCActual.Text, txtNRR.Text, txtMRR.Text, txtROI.Text, txtTermProfit.Text, txtTermRevenue.Text, txtRecurringMargin.Text, txtNonRecurringMargin.Text);
           
        }

        private void AddRevenueLines()
        {
             //obj_clsOpportunity.InsertRevenueLines(Convert.ToInt32(ViewState["OppID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue,Int32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCActual.Text), Convert.ToDecimal(txtMRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCActual.Text), Convert.ToDecimal(txtNRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text).Equals("") ? 0 : Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtRecurringMargin.Text), Convert.ToDecimal(txtNonRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtNonRecurringMargin.Text));
        }

        protected void cmbSalesStage_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (cmbSalesStage.SelectedValue.Equals("2"))
            //{
            //    lblBudgetaryQuote.Visible = true;
            //    CheckBoxBudgetaryQuote.Visible = true;
            //    lblBudgetaryQuoteDate.Visible = true;
            //    DatePickerBudgetaryQuoteDate.Visible = true;
            //    Pnl_Budgetary.Visible = true;
            //    //Pnl_GrdCreateOpportunity.Visible = false;
            //    //BindGrdBudgetary();


            }

         protected void cmbAccount_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
             {

            string RefID = cmbAccount.SelectedValue.ToString();
            DataTable dtCustomerContact = obj_clsGeneralFunction.GetPrimaryContacts(RefID);
            if (dtCustomerContact.Rows.Count > 0)
            {
                cmbPOC.DataSource = dtCustomerContact;
                cmbPOC.DataTextField = "CC_Name";
                cmbPOC.DataValueField = "CC_ID";
                cmbPOC.DataBind();
                cmbPOC.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
            else
            {
                cmbPOC.Items.Clear(); 
            }
            

        

            if (cmbSalesStage.SelectedValue.Equals("4"))
            {
                
                //Pnl_GrdCreateOpportunity.Visible = false;
                //Pnl_Proposal.Visible = true;
                lblQuoteProposalDate.Visible = true;
                DatePickerQuoteProposalDate.Visible = true;
               
                lblBudgetaryQuoteDate.Visible = false;
                DatePickerBudgetaryQuoteDate.Visible = true;
                //Pnl_GrdBudgetary.Visible = false;
                //BindGrdProposal();
            }

            if (cmbSalesStage.SelectedValue.Equals("6"))
            {
                //DatePickerOrderDate.Visible = true;
                //DatePickerDeploymentDate.Visible = true;
                //txtWinlossReason.Visible = true;


                //lblOrderDate.Visible = true;
                //DatePickerOrderDate.Visible = true;

                lblDeploymentDate.Visible = true;
                DatePickerDeploymentDate.Visible = true;

                lblWinlossReason.Visible = true;
                txtWinlossReason.Visible = true;
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        protected void btnAddRevenue_Click(object sender, EventArgs e)
        {
            AddRevenueLines();
            //Pnl_Proposal.Visible = true;
            BindGrdProposal();

        }

        protected void GrdProposal_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GV_GrdProposal.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                ViewState["OppDetailID"] = item["OppDetID"].Text;
                txtSiteAAddress.Text = item["Site_A_Address"].Text;
                cmbArea.SelectedValue = item["AreaID"].Text;
                cmbSiteACity.SelectedValue = item["Site_A_City"].Text;
                //txtSiteBAddress.Text = item["Site_B_Address"].Text;
                //cmbSiteBCountry.SelectedValue = item["Site_B_Country"].Text;
                //cmbSiteBCity.SelectedValue = item["Site_B_City"].Text;
                //cmbName.SelectedValue = item["Name"].Text;
                //cmbQuantityUOM.SelectedValue = item["QuantityUOM"].Text;
                //cmbInterface.SelectedValue = item["Interface"].Text;
                //txtLastMileProtection.Text = item["Last_Mile_Protection"].Text;
                //txtWetPortionRestorability.Text = item["Wet_Portion_Restorability"].Text;
                //txtSLA.Text = item["SLA"].Text;
                //DatePickerRFSDateDuration.SelectedDate = DateTime.Today;
                //txtContractTerm.Text = item["Contract_Term"].Text;
                //cmbWinLossStatus.SelectedValue = item["win_loss"].Text;
                //cmbCurrencyDetail.SelectedValue = item["Currency"].Text;
                //cmbStatus.SelectedValue = item["Status"].Text;
               
                //txtNRCActual.Text = item["NRC_Actual"].Text;
                //txtMRCActual.Text = item["MRC_Actual"].Text;
                //txtNRR.Text = item["NRR"].Text;
                //txtMRR.Text = item["MRR"].Text;
                //txtROI.Text = item["ROI"].Text;
                //txtTermProfit.Text = item["Term_Profit"].Text;
                //txtTermRevenue.Text = item["Term_Revenue"].Text;
                //txtRecurringMargin.Text = item["Recurring_Margin_Percentage"].Text;
                //txtNonRecurringMargin.Text = item["Non_Recurring_Margin_Percentage"].Text;
            }
        }

        protected void GrdProposal_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void cmbSiteACity_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            int CityID = Convert.ToInt32(cmbSiteACity.SelectedValue);
            dynamic dt = objBSS.GetAreaByCityID(CityID);
            if (dt.Rows.Count > 0)
            {
                cmbArea.DataSource = dt;
                cmbArea.DataTextField = "Area";
                cmbArea.DataValueField = "AreaID";
                cmbArea.DataBind();
            }

            DataTable dtBuilding = obj_clsGeneralFunction.GetBuildingByCityName(cmbSiteACity.Text);
            if (dtBuilding.Rows.Count > 0)
            {
                cmbBuilding.DataSource = dtBuilding;
                cmbBuilding.DataTextField = "BuildName";
                cmbBuilding.DataValueField = "BuildID";
                cmbBuilding.DataBind();
            }
            else
            {
                cmbBuilding.Items.Clear(); 
            }

        }
        protected void GV_CreateOpportunity_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GV_CreateOpportunity.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                ViewState["OppDetailID"] = item["OppDetEBUID"].Text;


                //ViewState["OpportunityID"] = dt_OpportunityById.Rows[0]["OppID"].ToString();
                //ViewState["OppDetEBUID"] = dt_OpportunityById.Rows[0]["OppDetEBUID"].ToString();
                txtOpportunityName.Text = item["OppName"].Text;
                cmbSalesStage.SelectedValue = item["OppStageID"].Text ;
                //cmbAccount.SelectedValue = item["PartnerID"].Text  ;
                cmbOppStatus.SelectedValue = item["OppStatusID"].Text ;
                txtWinProb.Text = item["WinProbability"].Text ;
                txtLat.Text = item ["Lat"].Text ;
                txtLong.Text = item ["Long"].Text ;
                if (item ["NRFRequestDate"].Text  != "")
                {
                    DatePickerNRFRequest.SelectedDate = Convert.ToDateTime(item ["NRFRequestDate"].Text );
                }

                cmbInfra.SelectedValue = item ["InfraID"].Text ;
                cmbSiteACity.SelectedValue = item ["CityID"].Text ;
                txtSiteAAddress.Text = item ["Site_A_Address"].Text ;
                txtSiteAddress.Text = item ["Site_B_Address"].Text ;
                cmbBuilding.SelectedValue = item ["BuildID"].Text ;
                cmbPOC.SelectedValue = item ["CC_ID"].Text ;
                Remarks.Text = item ["Remarks"].Text ;
                Estimated_Price.Text = item ["Estimated_Price"].Text ;
                Amount.Text = item ["Amount"].Text ;
                cmbServiceUnit.SelectedValue = item ["ServiceUnitID"].Text ;
                cmbRegionName.SelectedValue = item ["RegionID"].Text ;
                cmbPrimaryContact.SelectedValue = item ["CC_ID"].Text ;
                txtOppRemarks.Text = item ["Opp_Remarks"].Text ;
                DTProposalIntDate.SelectedDate = DateTime.Parse(item ["ProposalIntDate"].Text );
                txtNegotiationRemarks.Text = item ["NegotiationRemarks"].Text ;
                txtGroupRTR.Text = item ["GroupRTR"].Text ;
                cmbResumeDate.SelectedDate = DateTime.Parse(item ["NegotiationResumeDate"].Text );
                txtWonLostReason.Text = item ["WinLossReason"].Text ;
                cmbHoldReason.Text = item ["NegotiationHoldReason"].Text ;
                txtAttachement.Text = item ["Attachment1"].Text ;
                cmbCurrency.SelectedValue = item ["CurrencyID"].Text ;
                if (item ["Opp_OrderDate"].Text  != null)
                {
                    cmbOrderDate.SelectedDate = DateTime.Parse(item ["Opp_OrderDate"].Text );
                }
                if (item ["NegotiationProposalRevisionDate"].Text  != null)
                {
                    cmbProposalLastRevesionDate.SelectedDate =  DateTime.Parse(item ["NegotiationProposalRevisionDate"].Text );
                }
                if (item ["NegotiationFollowUpDate"].Text  != null)
                {
                    cmbLastFollowUpDate.SelectedDate = DateTime.Parse(item ["NegotiationFollowUpDate"].Text );
                }
                if (item ["NegotiationFollowUpDate"].Text  != null)
                {
                    cmbDeploymentDate.SelectedDate = DateTime.Parse(item ["NegotiationFollowUpDate"].Text );
                }
                txtNRCActual.Text = item ["NRCActual"].Text ;
                txtMRCActual.Text = item ["MRCActual"].Text ;
                txtNRR.Text = item ["NRR"].Text ;
                txtMRR.Text = item ["MRR"].ToString();
                //proposal
                cmbCircuitType.SelectedValue = item ["CircuitType"].Text ;

                //Survay
                txtInfraType.Text = item ["InfraDetail"].Text ;
                txtTotal_CAPEX_NRF_cost.Text = item ["NRFCost"].Text ;
                txtTotalTAFcost.Text = item ["TotalTAFcost"].Text ;
                txt3P_MRC.Text = item ["MRCP3"].Text ;
                txt3P_OTC.Text = item ["OTCP3"].Text ;
                txtName_of_3P.Text = item ["NameOf3P"].Text ;
                txtNodeName.Text = item ["NodeName"].Text ;
                //Business Case
                txtNRCActual.Text = item ["NRCActual"].Text ;
                txtMRCActual.Text = item ["MRCActual"].Text ;
                txtNRR.Text = item ["NRR"].Text ;
                txtMRR.Text =item ["MRR"].Text ;
                txtCost_of_Additional_Equipment.Text = item ["CostOfAdditionalEqp"].Text ;
                RadTxtDifference.Text = item ["Difference"].Text ;
                txtPaybackPeriod.Text = item ["PaybackPeriod"].Text ;
                txtPaybackPeriod35diff.Text = item ["PaybackPeriod35difff"].Text ;
                txtMRCOTS.Text = item ["MRCOTS"].Text ;
                txtCosttoMPPL.Text = item ["CosttoMPPL"].Text ;
                //Won Los
                txtWinlossReasonRevenue.Text = item ["WinLossReason"].Text ;
                cmbWonLostStatusRevenue.Text = item ["WonLostStatus"].Text ;






                //txtSiteAAddress.Text = item["Site_A_Address"].Text;
                //cmbArea.SelectedValue = item["AreaID"].Text;
                //cmbSiteACity.SelectedValue = item["CityID"].Text;
                //txtLat .Text = item["Lat"].Text;
                //txtLong .Text  = item["Long"].Text;
                //cmbPrimaryContact.SelectedValue = item["CC_ID"].Text;
                //cmbSiteBCity.SelectedValue = item["Site_B_City"].Text;
                //cmbName.SelectedValue = item["Name"].Text;
                //cmbQuantityUOM.SelectedValue = item["QuantityUOM"].Text;
                //cmbInterface.SelectedValue = item["Interface"].Text;
                //txtLastMileProtection.Text = item["Last_Mile_Protection"].Text;
                //txtWetPortionRestorability.Text = item["Wet_Portion_Restorability"].Text;
                //txtSLA.Text = item["SLA"].Text;
                //DatePickerRFSDateDuration.SelectedDate = DateTime.Today;
                //txtContractTerm.Text = item["Contract_Term"].Text;
                //txtWinLoss.Text = item["win_loss"].Text;
                //cmbWinLossStatus.SelectedValue = item["win_loss"].Text;
                //cmbCurrencyDetail.SelectedValue = item["Currency"].Text;
                //cmbStatus.SelectedValue = item["Status"].Text;
                //txtNRCBudget.Text = item["NRC_Budget"].Text;
                //txtMRCBudget.Text = item["MRC_Budget"].Text;
                //txtNRCCostOnNet.Text = item["NRC_Cost_On_Net"].Text;
                //txtMRCCostOnNet.Text = item["MRC_Cost_On_Net"].Text;
                //txtNRCCostOffNet.Text = item["NRC_Cost_Off_Net"].Text;
                //txtMRCCostOffNet.Text = item["MRC_Cost_Off_Net"].Text;
                //txtNRCCostOOP.Text = item["NRC_Cost_OOP"].Text;
                //txtMRCCostOOP.Text = item["MRC_Cost_OOP"].Text;
                //txtNameof3P.Text = item["Name_of_3P"].Text;
                //txtNRCActual.Text = item["NRC_Actual"].Text;
                //txtMRCActual.Text = item["MRC_Actual"].Text;
                //txtNRR.Text = item["NRR"].Text;
                //txtMRR.Text = item["MRR"].Text;
                //txtROI.Text = item["ROI"].Text;
                //txtTermProfit.Text = item["Term_Profit"].Text;
                //txtTermRevenue.Text = item["Term_Revenue"].Text;
                //txtRecurringMargin.Text = item["Recurring_Margin_Percentage"].Text;
                //txtNonRecurringMargin.Text = item["Non_Recurring_Margin_Percentage"].Text;
            }
        }

        protected void GV_CreateOpportunity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        private void ClearFieldsValue()
        {
            txtOpportunityName.Text = "";
            cmbSalesStage.SelectedValue = "";
            cmbAccount.SelectedValue = "";
            cmbCurrency.SelectedValue = "";
            //cmbStatus.SelectedValue = "";
            txtWinProb.Text = "";
            txtSiteAAddress.Text = "";
            //cmbSiteACountry.SelectedValue = "";
            cmbSiteACity.SelectedValue = "";
            //txtSiteBAddress.Text = "";
            //cmbSiteBCountry.SelectedValue = "";
            //cmbSiteBCity.SelectedValue = "";
            //cmbName.SelectedValue = "";
            //cmbQuantityUOM.SelectedValue = "";
            //cmbInterface.SelectedValue = "";
            //txtLastMileProtection.Text = "";
            //txtWetPortionRestorability.Text = "";
            //txtSLA.Text = "";
            //DatePickerRFSDateDuration.SelectedDate = "";
            //txtContractTerm.Text = "";
            //cmbWinLossStatus.SelectedValue = "";
            //cmbCurrencyDetail.SelectedValue = "";
            //cmbStatus.SelectedValue = "";
           
            //txtNRCActual.Text = "";
            //txtMRCActual.Text = "";
            //txtNRR.Text = "";
            //txtMRR.Text = "";
            //txtROI.Text = "";
            //txtTermProfit.Text = "";
            //txtTermRevenue.Text = "";
            //txtRecurringMargin.Text = "";
            //txtNonRecurringMargin.Text = "";
        }
    }
}