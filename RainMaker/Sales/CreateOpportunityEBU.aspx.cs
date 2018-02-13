using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using System.Globalization;

namespace RainMaker.EBU
{
    
    public partial class CreateOpportunityEBU : System.Web.UI.Page
    {
        string NRFReqDate, DTPropIntDate, ProposalLastRevesionDate, LastFollowUpDate, ResumeDate, OrderDateOpp, DeploymentDateOpp;
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        BL obj_BL = new BL();
      
        int _OppId;
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _OppId = Convert.ToInt32(base.Request.QueryString["OppID"]);
                ViewState["OppID"] = _OppId;
                //GetBandwidthType();
                GetOppStages();
                GetAccounts();
                GetCity();
                GetArea();
                //GetAccountsRev();
                GetCircuitType();
                GetInfra();
                GetName();
                GetRegionName ();
                //GetQuantityUOM();
                //cmbCity_OnSelectedIndexChanged(cmbCity, e);

                //txtOwner.Text = Session["Name"].ToString();
                DateTime time = Convert .ToDateTime ( System.DateTime.Today.ToShortDateString());
                //txt_WeekofMonth.Text  = GetWeekNumber();

                //Requirement
                Pnl_RevenueLines.Visible = false;
                btn_Add.Visible = false;

                //Proposal
                Pnl_Proposal.Visible = false;


                //Negotiating
                Pnl_Negotiating.Visible = false;

                //WonLoss
                Pnl_WonLost.Visible = false;
                Pnl_WinLossforRevenue.Visible = false;

                //Survey
                Pnl_Survey.Visible = false;

                //Business Case
                Pnl_BusinessCase.Visible = false;

                //Proposal
                Pnl_Stages_Proposal.Visible = false;

                //Requirements
                NRFRequestDate.Visible = false;
                lblNRFrequest.Visible = false;

                //Negotiation
                Pnl_Stages_Negotiation.Visible = false;

                //Won Lost Status
                pnl_Stages_WonLost.Visible = false;
            }

        }
        static string GetWeekNumber()
        {

            var weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Sunday) -
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(1 - DateTime.Now.Day),
                CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday) + 1;

            switch (weekNumber)
            {
                case 1:
                    return "First";
                case 2:
                    return "Second";
                case 3:
                    return "Third";
                default:
                    return "Fourth";
            }
        }
        private void GetAccounts()
        {
            obj_BL.loadCusCode(cmbAccount, null, null);
          
        }
       
       
        private void GetCircuitType()
        {
            obj_BL.loadCircuitType(cmbCircuitType,9);
        }
        private void GetInfra()
        {
            obj_BL.GetInfra(cmbInfra, 0, 2);
           
        }
        protected void btn_AddRevenueLines_Click(object sender, EventArgs e)
        {

            Pnl_RevenueLines.Visible = true;
            btn_Add.Visible = true;
        }

       
       

        private void GetOppStages()
        {
            DataTable dt_GetStages = obj_clsGeneralFunction.GetOppStages(1);
            cmbSalesStage.DataSource = dt_GetStages;
            cmbSalesStage.DataTextField = "OppStage";
            cmbSalesStage.DataValueField = "OppStageID";
            cmbSalesStage.DataBind();
            cmbSalesStage.Items.Insert(0, new RadComboBoxItem("Qualified Leads", "10"));
        }

       
        protected void cmbSalesStage_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbSalesStage.SelectedValue.Equals("11")) //requirements
            {
                //Boolean flag = obj_clsGeneralFunction
                NRFRequestDate.Visible = true;
                lblNRFrequest.Visible  = true;
                Pnl_Stages_Proposal.Visible = false ;
                Pnl_Stages_Negotiation.Visible = false;

                Pnl_RevenueLines.Visible = false;
                Pnl_Proposal.Visible = false;
                Pnl_Negotiating.Visible = false;
                Pnl_WonLost.Visible = false;
                Pnl_Survey.Visible = false;
                Pnl_BusinessCase.Visible = false;
            }
            if (cmbSalesStage.SelectedValue.Equals("14")) //Proposal
            {
                NRFRequestDate.Visible = true;
                lblNRFrequest.Visible = true;
                Pnl_Stages_Proposal.Visible = true;
                Pnl_Stages_Negotiation.Visible = false;

            }
            if (cmbSalesStage.SelectedValue.Equals("15")) //Negotiation
            {
               Pnl_Stages_Negotiation.Visible = true;

            }
            if (cmbSalesStage.SelectedValue.Equals("16")) //WonLost
            {
                Pnl_WonLost.Visible = true;
                pnl_Stages_WonLost.Visible = true;
                Pnl_WinLossforRevenue.Visible = false;

            }
            if (cmbSalesStage.SelectedValue.Equals("17")) //WonLost
            {
                pnl_Stages_WonLost.Visible = true;
                //Pnl_WinLossforRevenue.Visible = false;

            }
            if (cmbSalesStage.SelectedValue.Equals("10")) //Qualified
            {
               
                Pnl_RevenueLines.Visible = false;
                NRFRequestDate.Visible = false;
                lblNRFrequest.Visible  = false;
                BindGrdRequirements();
            }

            if (cmbSalesStage.SelectedValue.Equals("4"))
            {
                Pnl_RevenueLines.Visible = true;
                Pnl_Proposal.Visible = true;
            }

            if (cmbSalesStage.SelectedValue.Equals("5"))
            {
                Pnl_RevenueLines.Visible = true;
                Pnl_Proposal.Visible = true;
                Pnl_Negotiating.Visible = true;
            }

            if (cmbSalesStage.SelectedValue.Equals("6"))
            {
                Pnl_RevenueLines.Visible = true;
                Pnl_Proposal.Visible = true;
                Pnl_Negotiating.Visible = true;
                Pnl_WonLost.Visible = true;

            }

            if (cmbSalesStage.SelectedValue.Equals("12")) //Survey
            {
                DataTable DTOpp = obj_clsGeneralFunction.GetOpp(Convert .ToString(ViewState["OpportunityID"]));
                if (DTOpp.Rows.Count > 0)
                {
                    Pnl_RevenueLines.Visible = true;
                    Pnl_Proposal.Visible = false;
                    Pnl_Negotiating.Visible = false;
                    Pnl_WonLost.Visible = false;
                    Pnl_Survey.Visible = true;
                    //Pnl_GrdRequirements.Visible = false;
                    BindGrdSurvey();
                }
                else
                {
                    lblStatus.Text = "Please Create Revenue Line before";
                }
               

            }

            if (cmbSalesStage.SelectedValue.Equals("13")) //Business Case
            {
                 DataTable DTOpp = obj_clsGeneralFunction.GetOpp(Convert .ToString(ViewState["OpportunityID"]));
                 if (DTOpp.Rows.Count > 0)
                 {
                     Pnl_RevenueLines.Visible = true;
                     Pnl_Proposal.Visible = false;
                     Pnl_Negotiating.Visible = false;
                     Pnl_WonLost.Visible = false;
                     Pnl_Survey.Visible = true;
                     Pnl_BusinessCase.Visible = true;
                     Pnl_GrdRequirements.Visible = false;
                     Pnl_GrdSurvey.Visible = false;
                     BindGrdBusinessCase();
                 }
                 else
                 {
                     lblStatus.Text  = "Please Create Revenue Line before";
                 }

            }

        }


        private void BindGrdRequirements()
        {
            DataTable dt_GetRequirements = obj_clsGeneralFunction.GetOpportunityRequirementEBU();
            GV_GrdRequirements.DataSource = dt_GetRequirements;
            GV_GrdRequirements.DataBind();
        }

        public void BindGrdSurvey()
        {
            DataTable dt_Survey = obj_clsGeneralFunction.GetOpportunitySurveyEBU();
            GV_GrdSurvey.DataSource = dt_Survey;
            GV_GrdSurvey.DataBind();
        }

        private void BindGrdBusinessCase()
        {
            DataTable dt_BusinessCase = obj_clsGeneralFunction.GetOpportunityBusinessCaseEBU();
            GV_GrdSurvey.DataSource = dt_BusinessCase;
            GV_GrdSurvey.DataBind();
        }
        
        private void GetCity()
        {
            obj_BL.loadCity(cmbCity);
        }
         private void GetArea()
        {

           
        }
         //private void GetQuantityUOM()
         //{
         //    obj_BL.loadBandWidth(cmbUMO);
         //}

         private void GetName()
         {
             obj_BL.getServicesUnitByInfra(0, cmbServiceUnit);

         }
         private void GetRegionName()
         {
            obj_BL.GetRegionName(cmbRegionName  , null, null);
         }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (txtOpportunityName.Text.Equals(""))
            {
                lblStatus.Text = "Opportunity Missing";
            }
            else
            {
                object obj_OpportunityId = obj_clsOpportunity.CreateOpportunity(txtOpportunityName.Text, "1", Convert.ToInt32(cmbSalesStage.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbPrimaryCustomer.SelectedValue), txtWinProb.Text , Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), "0", Convert.ToInt32(Session["UserID"]));
            ViewState["OpportunityID"] = obj_OpportunityId;
            lblStatus.Text = txtOpportunityName.Text  + "-" + ViewState["OpportunityID"] + " has updated successfully";
           
            }
            

        }

        protected void cmbRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
             {

             }
        protected void cmbInfra_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            obj_BL.getServicesUnitByInfra(Convert.ToInt32 (cmbInfra.SelectedValue) , cmbServiceUnit);
         
        }
        protected void cmbAccount_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            string RefID = cmbAccount.SelectedValue.ToString();
            //Customer Contact
            DataTable dtCustomerContact = obj_clsGeneralFunction.GetPrimaryContacts(RefID);
            if (dtCustomerContact.Rows.Count > 0)
            {
                //DataView view = new DataView(dtCustomerContact);
                //view.Sort = "ServiceUnit desc";
                //cmbPrimaryCustomer.DataSource = view;
                cmbPrimaryCustomer.DataSource = dtCustomerContact;
                cmbPrimaryCustomer.DataTextField = "CC_Name";
                cmbPrimaryCustomer.DataValueField = "CC_ID";
                cmbPrimaryCustomer.DataBind();
                cmbPrimaryCustomer.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                cmbPOC.DataSource = dtCustomerContact;
                cmbPOC.DataTextField = "CC_Name";
                cmbPOC.DataValueField = "CC_ID";
                cmbPOC.DataBind();
                cmbPOC.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
            else
            {
                cmbPrimaryCustomer.Items.Clear(); 
            }
            

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtLat.Text.Equals(""))
            {
                lblStatus.Text = "Latitue Missing";
            }
            if (txtLong .Text.Equals("")) 
            {
                lblStatus.Text = "Longitude Missing";
            }
            if (cmbCity.Text.Equals("Please-Select") || cmbPOC.Text.Equals("Please Select") || cmbBuilding.Text.Equals("") || cmbArea.Text.Equals("") || cmbInfra.Text.Equals("Please-Select") || cmbServiceUnit.Text.Equals("Please-Select") || cmbCircuitType.Text.Equals("Please-Select") || cmbRegionName.Text.Equals("Please-Select")) 
            {
                lblStatus.Text = "Missing Fields";
            }
               
            else
            {
                AddRevenueLines();
                BindGrdDetails();
            }
           // Pnl_GrdCreateOpportunity.Visible = true;
        }
        private void AddRevenueLines()
        {

            object obj_OpportunityDetId = obj_clsOpportunity.CreateOpportunityDetailsForEBU(Convert.ToInt32(ViewState["OpportunityID"]), 1, Convert.ToInt32(cmbServiceUnit.SelectedValue), Convert.ToInt32(cmbRegionName.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), 1, Convert.ToInt32(cmbBuilding.SelectedValue), txtSiteAAddress.Text, txtSite_B_Address.Text, txtLat.Text, txtLong.Text, Convert.ToInt32(cmbPOC.SelectedValue), Convert.ToInt32(cmbCircuitType.SelectedValue), txtRemarksEBU.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "1900-01-01", Convert.ToInt32(198));
           ViewState["OpportunityRevID"] = obj_OpportunityDetId;
           RevenueLineStatus.Text = "RevenueLine " + obj_OpportunityDetId + " has updated Successfully";
           

        }
        private void BindGrdDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityRevEBU(Convert.ToInt32(ViewState["OpportunityID"]));

            GV_GrdRequirements.DataSource = dt_GetOppDetails;
            GV_GrdRequirements.DataBind();
            

            //GV_GrdRequirements.MasterTableView.GetColumn("CityID").Display = false;
            //GV_GrdRequirements.MasterTableView.GetColumn("InfraID").Display = false;
            //GV_GrdRequirements.MasterTableView.GetColumn("RegionID").Display = false;
            //GV_GrdRequirements.MasterTableView.GetColumn("CC_ID").Display = false;
            //GV_GrdRequirements.MasterTableView.GetColumn("ServiceUnitID").Display = false;

           
            //GV_GrdRequirements.MasterTableView.GetColumn("Site_A_Address").FilterControlWidth = 300;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Datevalidation();
            //Convert.ToString(NRFReqDate)
            object obj_OpportunityId = obj_clsOpportunity.UpdateOpportunityEBU(Convert.ToInt32(ViewState["OpportunityID"]), txtOpportunityName.Text, Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbPOC.SelectedValue), Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), 1, Convert.ToInt16(cmbSalesStage.SelectedValue), 1,"", GroupRTR.Text, Convert.ToString(DTProposalIntDate.SelectedDate), txtOppRemarks.Text, cmbNegotiation.SelectedValue, Convert.ToString(ProposalLastRevesionDate), Convert.ToString(LastFollowUpDate), txtNegotiationRemarks.Text, Convert.ToString(ResumeDate), cmbHoldReason.Text, Convert.ToString(OrderDateOpp), txtWonLostReason.Text, Convert.ToString(DeploymentDateOpp));
           obj_clsOpportunity.UpdateOpportunityDetailsEBU(Convert.ToInt32(ViewState["OpportunityID"]), 1, Convert.ToInt32(cmbServiceUnit.SelectedValue), Convert.ToInt32(cmbRegionName.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue), 1, Convert.ToInt32(cmbBuilding.SelectedValue), txtSiteAAddress.Text, txtSite_B_Address.Text, txtLat.Text, txtLong.Text, Convert.ToInt32(cmbPOC.SelectedValue), Convert.ToInt32(cmbCircuitType.SelectedValue), "Remarks", Convert.ToInt32(txtEstimatedPrice.Text), Convert.ToInt32(txtAmount.Text), Convert.ToInt32(txtNRCActual.Text), Convert.ToInt32(txtMRCActual.Text), Convert.ToInt32(txtNRR.Text), Convert.ToInt32(txtMRR.Text), Convert.ToInt32(txtCost_of_Additional_Equipment.Text), Convert.ToInt32(RadTxtDifference.Text), Convert.ToInt32(txtPaybackPeriod.Text), Convert.ToInt32(txtPaybackPeriod35diff.Text), Convert.ToInt32(txtMRCOTS.Text), Convert.ToInt32(txtCosttoMPPL.Text), txtInfraType.Text, txtTotal_CAPEX_NRF_cost.Text, txtTotalTAFcost.Text, txt3P_MRC.Text, txt3P_OTC.Text, txtName_of_3P.Text, txtNodeName.Text, cmbWonLostStatus.Text, txtWinlossReason.Text,Convert.ToString(NRFReqDate), Convert.ToInt32(Session["UserID"]));
           
            Pnl_GrdRequirements.Visible = true;
            BindGrdDetails();
            lblStatus.Text = "Successfully inserted" + "-" + ViewState["OpportunityRevID"];
        }
        protected void cmbServiceUnit_OnSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void Datevalidation()
        {
           
            if (NRFRequestDate.SelectedDate == null )
            {
                 NRFReqDate = "1900-01-01";
            }
            else
            {
                NRFReqDate = Convert.ToString(NRFRequestDate.SelectedDate);
            }

            if (DTProposalIntDate.SelectedDate == null)
            {
                DTPropIntDate = "1900-01-01";
            }
            else
            {
                DTPropIntDate = Convert.ToString(DTProposalIntDate.SelectedDate);
            }

            if (cmbProposalLastRevesionDate.SelectedDate == null)
            {
                ProposalLastRevesionDate = "1900-01-01";
            }
            else
            {
                ProposalLastRevesionDate = Convert.ToString(cmbProposalLastRevesionDate.SelectedDate);
            }

            if (cmbLastFollowUpDate.SelectedDate == null)
            {
                LastFollowUpDate = "1900-01-01";
            }
            else
            {
                LastFollowUpDate = Convert.ToString(cmbLastFollowUpDate.SelectedDate);
            }

            if (cmbResumeDate.SelectedDate == null)
            {
                ResumeDate = "1900-01-01";
            }
            else
            {
                ResumeDate = Convert.ToString(cmbResumeDate.SelectedDate);
            }

            if (cmbOrderDate.SelectedDate == null)
            {
                OrderDateOpp = "1900-01-01";
            }
            else
            {
                OrderDateOpp = Convert.ToString(cmbResumeDate.SelectedDate);
            }

            if (cmbDeploymentDate.SelectedDate == null)
            {
                DeploymentDateOpp = "1900-01-01";
            }
            else
            {
                DeploymentDateOpp = Convert.ToString(cmbDeploymentDate.SelectedDate);
            }
            if (txtNRCActual.Text  == "")
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



        protected void cmbPrimaryCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            cmbPOC.SelectedValue = cmbPrimaryCustomer.SelectedValue;
            //dynamic dt = objBSS.GetAreaByCityID(CityID);
            //if (dt.Rows.Count > 0)
            //{
            //    cmbArea.DataSource = dt;
            //    cmbArea.DataTextField = "Area";
            //    cmbArea.DataValueField = "AreaID";
            //    cmbArea.DataBind();
            //}
        }
        protected void cmbCity_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
           {

            int CityID = Convert .ToInt32 (cmbCity.SelectedValue);
            dynamic dt = objBSS.GetAreaByCityID(CityID);
            if (dt.Rows.Count > 0)
            {
                cmbArea.DataSource = dt;
                cmbArea.DataTextField = "Area";
                cmbArea.DataValueField = "AreaID";
                cmbArea.DataBind();
            }

            DataTable dtBuilding = obj_clsGeneralFunction.GetBuildingByCityName(cmbCity.Text );
            if (dtBuilding.Rows.Count > 0)
            {
                cmbBuilding.DataSource = dtBuilding;
                cmbBuilding.DataTextField = "BuildName";
                cmbBuilding.DataValueField = "BuildID";
                cmbBuilding.DataBind();
            }

        }
        protected void btn_SaveDetail_Click(object sender, EventArgs e)
        {
            AddRevenueLinesDetails();
            Pnl_RevenueDetailsForProducts.Visible = false;

        }
        //protected void GV_GrdRequirements_SelectedIndexChanged(object sender, GridCommandEventArgs e)
        //{
            //foreach (GridDataItem item in GV_GrdRequirements.SelectedItems)
            //{
            //    if (RadGrid.SelectCommandName == "AddProduct")
            //    {
            //        //Session["TicketNo"] = item("Ticket No").Text;

            //    }
            //}
        //}
        protected void GV_GrdRequirements_ItemCommand(object sender, GridCommandEventArgs e)
        {
                    Pnl_GrdRequirements.Visible = true;
                    BindGrdDetails();
                    Pnl_RevenueDetailsForProducts.Visible = true;
                    //AddRevenueLinesDetails();
                   
                    //BindGrdRevenueDetails();
                   
                   

                    DataTable dt_GetOppDetails = obj_BL.getProductName(1);
                    RadgridForProducts.DataSource = dt_GetOppDetails;
                    RadgridForProducts.DataBind();
                    for (int i = 0; i < dt_GetOppDetails.Rows.Count; i++)
                    {

                        DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[i].Cells[1].FindControl("cmbQuantityUOM");
                        TextBox ddl2 = (TextBox)RadgridForProducts.Rows[i].Cells[1].FindControl("txtMRC3p");
                        DropDownList ddl3 = (DropDownList)RadgridForProducts.Rows[i].Cells[2].FindControl("cmbInterface");
                        TextBox ddl4 = (TextBox)RadgridForProducts.Rows[i].Cells[1].FindControl("txtActualMRC");
                        FillDropDownList1(ddl1);
                        FillDropDownList2(ddl2);
                        FillDropDownList3(ddl3);
                        FillDropDownList4(ddl4);

                        
                    }

                  
            
        }
        private void FillDropDownList1(DropDownList dd1)
        {

            DataTable DTUOM = obj_BL.GetloadBandWidth(cmbQuantityUOM);

            foreach (DataRow row in DTUOM.Rows)
            {
                dd1.Items.Add(new ListItem(row["BandwidthDesc"].ToString(), row["BandwidthID"].ToString()));
            }
        }

        private void FillDropDownList2(TextBox  dd2)
        {
          
        }
        private void FillDropDownList4(TextBox dd4)
        {
        }

               
       
        private void FillDropDownList3(DropDownList dd3)
        {

            DataTable DTInterface = obj_BL.GetInterface(cmbInterface);

            foreach (DataRow row in DTInterface.Rows)
            {
                dd3.Items.Add(new ListItem(row["Interface"].ToString(), row["InterfaceID"].ToString()));
            }
        }
        private void AddRevenueLinesDetails()
        {
          
            foreach (GridViewRow row in RadgridForProducts.Rows)
            {
            

                if (row.RowType == DataControlRowType.DataRow)
                {
                   
                    CheckBox chkRow = (row.Cells[row.RowIndex].FindControl("chkRow") as CheckBox);
                    
                    if (chkRow.Checked)
                    {
                        DataTable dt_GetOppDetails = obj_BL.getProductName(1);

                        DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[row.RowIndex].FindControl("cmbQuantityUOM");
                        string BandWidthID = ddl1.SelectedValue.ToString();

                        DropDownList ddl2 = (DropDownList)RadgridForProducts.Rows[row.RowIndex].FindControl("cmbInterface");
                        string InterfaceID = ddl2.SelectedValue.ToString();

                        string ServiceID = dt_GetOppDetails.Rows[row.RowIndex]["ServiceUnitID"].ToString();

                        TextBox txt3 = (TextBox)RadgridForProducts.Rows[row.RowIndex].FindControl("txtMRC3p");
                        string MRC3P = txt3.Text;

                        TextBox txt4 = (TextBox)RadgridForProducts.Rows[row.RowIndex].FindControl("txtActualMRC");
                        string ActualMRC = txt4.Text;

                        if (!(BandWidthID.Equals("-1")))
                        {
                            object obj_OpportunityRevId = obj_clsOpportunity.CreateOpportunityDetailsEBU_ForProducts(Convert.ToInt32(ServiceID), Convert.ToInt32(BandWidthID), "BandWidthType", 0, Convert.ToInt32(InterfaceID), Convert.ToInt32(ActualMRC), Convert.ToInt32(MRC3P), Convert.ToInt32(ViewState["OpportunityRevID"]), Convert .ToInt32 ( Session["UserID"]));
                            ViewState["OpportunityRevID"] = obj_OpportunityRevId;
                            ViewState["ProductStatus"] = "Products-" + ViewState["OpportunityRevID"] + " has updated Successfully";
                        }
                    }
                }
                //RadgridForProducts.DataSource = null;
                //RadgridForProducts.DataBind();
                lblProStatus.Text = Convert.ToString(ViewState["ProductStatus"]);
            }

        }

   

        private void BindGrdRevenueDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityRevenueDetailsEBU(Convert.ToInt32(ViewState["OpportunityRevID"]));
            GV_GrdSurvey.DataSource = dt_GetOppDetails;
            GV_GrdSurvey.DataBind();
        }

        //private void ShowBuilding()
        //{
        //    DataTable dt = obj_clsGeneralFunction.GetBuildingByCityName(cmbCity.SelectedValue);
        //    cmbBuilding.DataSource = dt;
        //    cmbBuilding.DataTextField = "BuildName";
        //    cmbBuilding.DataValueField = "BuildID";
        //    cmbBuilding.DataBind();
        //    //cmbBuilding.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        //    //BuildID = Convert.ToInt32(cmbBuilding.SelectedItem.Value);

        //}

        public RadComboBox cmbInterface { get; set; }

        public RadComboBox cmbQuantityUOM { get; set; }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Pnl_RevenueDetailsForProducts.Visible = false;
        }

        protected void LnkCustomerContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCustContact.aspx", true);
        }

        protected void GV_GrdRequirements_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void btnProductsView_Click(object sender, EventArgs e)
        {
            //GV_GrdSurvey.Visible = true;
            //Pnl_RevenueDetailsForProducts.Visible = true;
            //BindGrdRevenueDetails();
        }

        protected void btnHideProducts_Click(object sender, EventArgs e)
        {
            GV_GrdSurvey.Visible = false;
            Pnl_RevenueDetailsForProducts.Visible = false;
            BindGrdDetails();
            lblProStatus .Text = Convert.ToString(ViewState["ProductStatus"]);
        }

        protected void LinkCustAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx", true);
        }

        protected void GV_GrdSurvey_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
           

        }
        

       
       
    }
}