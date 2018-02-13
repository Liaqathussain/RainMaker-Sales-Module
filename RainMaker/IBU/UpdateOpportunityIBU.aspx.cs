using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RainMaker.Classes;
using System.Data;
using System.IO;

namespace RainMaker.IBU
{
    public partial class UpdateOpportunityIBU : System.Web.UI.Page
    {
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        BL obj_BL = new BL();
        int _OppId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //trrHideMe.Visible = false;
            //trrBudgetary.Visible = false;
            //testDiv.Visible = false;

            if (!IsPostBack)
            {

                _OppId = Convert.ToInt32(base.Request.QueryString["OppID"]);
                ViewState["OppID"] = _OppId;

                DataTable dt_OpportunityById = obj_clsOpportunity.GetOpportunityByID(_OppId);

                if (dt_OpportunityById.Rows.Count > 0)
                {

                    txtOpportunityName.Text = dt_OpportunityById.Rows[0]["OppName"].ToString();
                    cmbSalesStage.SelectedValue = dt_OpportunityById.Rows[0]["OppStageID"].ToString();
                    cmbAccount.SelectedValue = dt_OpportunityById.Rows[0]["PartnerID"].ToString();
                    cmbEndCustomer.SelectedValue = dt_OpportunityById.Rows[0]["CustCode"].ToString();
                    cmbCurrency.SelectedValue = dt_OpportunityById.Rows[0]["Currency"].ToString();
                    cmbStatus.SelectedValue = dt_OpportunityById.Rows[0]["OppStatusID"].ToString();
                    txtWinProbability.Text = dt_OpportunityById.Rows[0]["WinProbability"].ToString();
                    txtSiteAAddress.Text = dt_OpportunityById.Rows[0]["Site_A_Address"].ToString();
                    cmbSiteACountry.SelectedValue = dt_OpportunityById.Rows[0]["Site_A_Country"].ToString();
                    cmbSiteACity.SelectedValue = dt_OpportunityById.Rows[0]["Site_A_City"].ToString();
                    txtSiteBAddress.Text = dt_OpportunityById.Rows[0]["Site_B_Address"].ToString();
                    cmbSiteBCountry.SelectedValue = dt_OpportunityById.Rows[0]["Site_B_Country"].ToString();
                    cmbSiteBCity.SelectedValue = dt_OpportunityById.Rows[0]["Site_B_City"].ToString();
                    cmbName.SelectedValue = dt_OpportunityById.Rows[0]["Name"].ToString();
                    cmbQuantityUOM.SelectedValue = dt_OpportunityById.Rows[0]["QuantityUOM"].ToString();
                    cmbInterface.SelectedValue = dt_OpportunityById.Rows[0]["Interface"].ToString();
                    txtLastMileProtection.Text = dt_OpportunityById.Rows[0]["Last_Mile_Protection"].ToString();
                    txtWetPortionRestorability.Text = dt_OpportunityById.Rows[0]["Wet_Portion_Restorability"].ToString();
                    txtSLA.Text = dt_OpportunityById.Rows[0]["SLA"].ToString();
                    DatePickerRFSDateDuration.SelectedDate = DateTime.Today;
                    txtContractTerm.Text = dt_OpportunityById.Rows[0]["Contract_Term"].ToString();
                    cmbWinLossStatus.SelectedValue = dt_OpportunityById.Rows[0]["win_loss"].ToString();
                    cmbCurrencyDetail.SelectedValue = dt_OpportunityById.Rows[0]["Currency"].ToString();
                    cmbStatus.SelectedValue = dt_OpportunityById.Rows[0]["Status"].ToString();
                    txtNRCBudget.Text = dt_OpportunityById.Rows[0]["NRC_Budget"].ToString();
                    txtMRCBudget.Text = dt_OpportunityById.Rows[0]["MRC_Budget"].ToString();
                    txtNRCCostOnNet.Text = dt_OpportunityById.Rows[0]["NRC_Cost_On_Net"].ToString();
                    txtMRCCostOnNet.Text = dt_OpportunityById.Rows[0]["MRC_Cost_On_Net"].ToString();
                    txtNRCCostOffNet.Text = dt_OpportunityById.Rows[0]["NRC_Cost_Off_Net"].ToString();
                    txtMRCCostOffNet.Text = dt_OpportunityById.Rows[0]["MRC_Cost_Off_Net"].ToString();
                    txtNRCCostOOP.Text = dt_OpportunityById.Rows[0]["NRC_Cost_OOP"].ToString();
                    txtMRCCostOOP.Text = dt_OpportunityById.Rows[0]["MRC_Cost_OOP"].ToString();
                    txtNameof3P.Text = dt_OpportunityById.Rows[0]["Name_of_3P"].ToString();
                    txtNRCActual.Text = dt_OpportunityById.Rows[0]["NRC_Actual"].ToString();
                    txtMRCActual.Text = dt_OpportunityById.Rows[0]["MRC_Actual"].ToString();
                    txtNRR.Text = dt_OpportunityById.Rows[0]["NRR"].ToString();
                    txtMRR.Text = dt_OpportunityById.Rows[0]["MRR"].ToString();
                    txtROI.Text = dt_OpportunityById.Rows[0]["ROI"].ToString();
                    txtTermProfit.Text = dt_OpportunityById.Rows[0]["Term_Profit"].ToString();
                    txtTermRevenue.Text = dt_OpportunityById.Rows[0]["Term_Revenue"].ToString();
                    txtRecurringMargin.Text = dt_OpportunityById.Rows[0]["Recurring_Margin_Percentage"].ToString();
                    txtNonRecurringMargin.Text = dt_OpportunityById.Rows[0]["Non_Recurring_Margin_Percentage"].ToString();

                    if (txtNRCBudget.Text.Equals(""))
                    {
                        txtNRCBudget.Text = "0.0";
                    }

                    if (txtMRCBudget.Text.Equals(""))
                    {
                        txtMRCBudget.Text = "0.0";
                    }


                    if (txtNRCCostOnNet.Text.Equals(""))
                    {
                        txtNRCCostOnNet.Text = "0.0";
                    }

                    if (txtMRCCostOnNet.Text.Equals(""))
                    {
                        txtMRCCostOnNet.Text = "0.0";
                    }

                    if (txtNRCCostOffNet.Text.Equals(""))
                    {
                        txtNRCCostOffNet.Text = "0.0";
                    }


                    if (txtMRCCostOffNet.Text.Equals(""))
                    {
                        txtMRCCostOffNet.Text = "0.0";
                    }


                    if (txtNRCCostOOP.Text.Equals(""))
                    {
                        txtNRCCostOOP.Text = "0.0";
                    }


                    if (txtMRCCostOOP.Text.Equals(""))
                    {
                        txtMRCCostOOP.Text = "0.0";
                    }

                    if (txtNameof3P.Text.Equals(""))
                    {
                        txtNameof3P.Text = "test";
                    }

                    if (txtNRCActual.Text.Equals(""))
                    {
                        txtNRCActual.Text = "0.0";
                    }

                    if (txtMRCActual.Text.Equals(""))
                    {
                        txtMRCActual.Text = "0.0";
                    }

                    if (txtNRR.Text.Equals(""))
                    {
                        txtNRR.Text = "0.0";
                    }

                    if (txtMRR.Text.Equals(""))
                    {
                        txtMRR.Text = "0.0";
                    }

                    if (txtROI.Text.Equals(""))
                    {
                        txtROI.Text = "0.0";
                    }

                    if (txtTermProfit.Text.Equals(""))
                    {
                        txtTermProfit.Text = "0.0";
                    }

                    if (txtTermRevenue.Text.Equals(""))
                    {
                        txtTermRevenue.Text = "0.0";
                    }

                    if (txtRecurringMargin.Text.Equals(""))
                    {
                        txtRecurringMargin.Text = "0.0";
                    }

                    if (txtNonRecurringMargin.Text.Equals(""))
                    {
                        txtNonRecurringMargin.Text = "0.0";
                    }














                    GetOppStages();
                    GetAccounts();
                    BindGrdDetails();
                    GetEndCustomer();
                    GetOppStatus();
                    GetCurrency();
                    GetCityA();
                    GetCityB();
                    GetCountryA();
                    GetCountryB();
                    GetCurrencyDetail();
                    GetOppStatusDetail();
                    GetName();
                    GetQuantityUOM();
                    System.DateTime dt = DateTime.Now;
                    DatePickerBudgetaryQuoteDate.SelectedDate = dt;
                    DatePickerQuoteProposalDate.SelectedDate = dt;

                    //Pnl_Opportunity.Visible = false;


                    txtKAM.Text = Session["Name"].ToString();
                    txtWorkingBy.Text = Session["Name"].ToString();
                    txtLastUpdateBy.Text = Session["Name"].ToString();
                    txtLastUpdatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");



                    lblOrderDate.Visible = false;
                    DatePickerOrderDate.Visible = false;

                    lblDeploymentDate.Visible = false;
                    DatePickerDeploymentDate.Visible = false;

                    lblWinlossReason.Visible = false;
                    txtWinlossReason.Visible = false;

                    ///budgetary stage
                    ///
                    Pnl_Budgetary.Visible = false;
                    lblBudgetaryQuote.Visible = false;
                    CheckBoxBudgetaryQuote.Visible = false;
                    lblBudgetaryQuoteDate.Visible = false;
                    DatePickerBudgetaryQuoteDate.Visible = false;

                    ///proposal
                    ///
                    Pnl_Proposal.Visible = false;
                    lblQuoteProposalDate.Visible = false;
                    DatePickerQuoteProposalDate.Visible = false;
                }

            }


        }

        protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {

            if (e.Item.Text == "Save")
            {
                Save();
            }
        }


        private void GetOppStages()
        {
            DataTable dt_GetStages = obj_clsGeneralFunction.GetOppStages(2);
            cmbSalesStage.DataSource = dt_GetStages;
            cmbSalesStage.DataTextField = "OppStage";
            cmbSalesStage.DataValueField = "OppStageID";
            cmbSalesStage.DataBind();
            cmbSalesStage.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }


        private void BindGrdDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityDetails(Convert.ToInt32(ViewState["OppID"]));
            GV_CreateOpportunity.DataSource = dt_GetOppDetails;
            GV_CreateOpportunity.DataBind();
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

        private void GetQuantityUOM()
        {
            obj_BL.loadBandWidth(cmbQuantityUOM);
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
            DataTable dt_GetStatus = obj_clsGeneralFunction.GetOppStatus();
            cmbStatus.DataSource = dt_GetStatus;
            cmbStatus.DataTextField = "OppStatus";
            cmbStatus.DataValueField = "OppStatusID";
            cmbStatus.DataBind();
            cmbStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
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
            DataTable dt_GetCurrency = obj_clsGeneralFunction.GetCurrency();
            cmbCurrencyDetail.DataSource = dt_GetCurrency;
            cmbCurrencyDetail.DataTextField = "CurrencyName";
            cmbCurrencyDetail.DataValueField = "CurrencyID";
            cmbCurrencyDetail.DataBind();
            cmbCurrencyDetail.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }

        public void GetEndCustomer()
        {
            obj_BL.loadCusCode(cmbEndCustomer, null, null);
        }

        private void GetCityA()
        {
            obj_BL.loadCity(cmbSiteACity);
        }

        private void GetCityB()
        {
            obj_BL.loadCity(cmbSiteBCity);
        }

        private void GetCountryA()
        {
            obj_BL.loadTDMCountries(cmbSiteACountry);
        }

        private void GetCountryB()
        {
            obj_BL.loadTDMCountries(cmbSiteBCountry);
        }

        private void GetName()
        {
            obj_BL.getServicesUnitByInfra(0, cmbName);
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
            DateTime BudgetaryQuoteDate = Convert.ToDateTime(DatePickerBudgetaryQuoteDate.SelectedDate.Value.ToShortDateString());
            DateTime QuoteProposalDate = Convert.ToDateTime(DatePickerQuoteProposalDate.SelectedDate.Value.ToShortDateString());


            //rdp1.SelectedDate != null && rdp1.SelectedDate.GetValueOrDefault() != DateTime.MinValue
            //object obj_OpportunityId = obj_clsOpportunity.UpdateOpportunity(Convert.ToInt32(ViewState["OppID"]), txtOpportunityName.Text, Convert.ToInt32(cmbSalesStage.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbEndCustomer.SelectedValue), 1, 1, txtWinProbability.Text, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), txtAttachement.Text, Convert.ToInt32(Session["UserID"]), CheckBoxBudgetaryQuote.Checked?1:0, DatePickerBudgetaryQuoteDate.SelectedDate.Value? DBNull.Value: Convert.ToDateTime(DatePickerBudgetaryQuoteDate.SelectedDate.Value), Convert.ToDateTime(DatePickerQuoteProposalDate.SelectedDate.Value));
            //object obj_OpportunityId = obj_clsOpportunity.UpdateOpportunity(Convert.ToInt32(ViewState["OppID"]), txtOpportunityName.Text, Convert.ToInt32(cmbSalesStage.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbEndCustomer.SelectedValue), 1, 1, txtWinProbability.Text, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), txtAttachement.Text, Convert.ToInt32(Session["UserID"]), CheckBoxBudgetaryQuote.Checked ? 1 : 0, BudgetaryQuoteDate, QuoteProposalDate);
            obj_clsOpportunity.UpdateOpportunityDetails(Convert.ToInt32(ViewState["OppID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text), Convert.ToDecimal(txtMRCActual.Text), Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text), Convert.ToDecimal(txtNonRecurringMargin.Text));
            //obj_clsOpportunity.UpdateOpportunityDetails(Convert.ToInt32(ViewState["OppID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, txtWinLoss.Text, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCActual.Text), Convert.ToDecimal(txtMRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCActual.Text), Convert.ToDecimal(txtNRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text).Equals("") ? 0 : Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtRecurringMargin.Text), Convert.ToDecimal(txtNonRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtNonRecurringMargin.Text));

        }

        private void AddRevenueLines()
        {
            //obj_clsOpportunity.InsertRevenueLines(Convert.ToInt32(ViewState["OppID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, txtWinLoss.Text, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text), Convert.ToDecimal(txtMRCActual.Text), Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text), Convert.ToDecimal(txtNonRecurringMargin.Text));
            obj_clsOpportunity.InsertRevenueLines(Convert.ToInt32(ViewState["OppID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRCActual.Text), Convert.ToDecimal(txtMRCActual.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRCActual.Text), Convert.ToDecimal(txtNRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text).Equals("") ? 0 : Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text).Equals("") ? 0 : Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text).Equals("") ? 0 : Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtRecurringMargin.Text), Convert.ToDecimal(txtNonRecurringMargin.Text).Equals("") ? 0 : Convert.ToDecimal(txtNonRecurringMargin.Text));
        }

        protected void cmbSalesStage_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbSalesStage.SelectedValue.Equals("2"))
            {
                lblBudgetaryQuote.Visible = true;
                CheckBoxBudgetaryQuote.Visible = true;
                lblBudgetaryQuoteDate.Visible = true;
                DatePickerBudgetaryQuoteDate.Visible = true;
                Pnl_Budgetary.Visible = true;
                //Pnl_GrdCreateOpportunity.Visible = false;
                //BindGrdBudgetary();


            }

            if (cmbSalesStage.SelectedValue.Equals("4"))
            {
                Pnl_Budgetary.Visible = true;
                //Pnl_GrdCreateOpportunity.Visible = false;
                Pnl_Proposal.Visible = true;
                lblQuoteProposalDate.Visible = true;
                DatePickerQuoteProposalDate.Visible = true;
                lblBudgetaryQuote.Visible = true;
                CheckBoxBudgetaryQuote.Visible = true;
                lblBudgetaryQuoteDate.Visible = true;
                DatePickerBudgetaryQuoteDate.Visible = true;
                //Pnl_GrdBudgetary.Visible = false;
                //BindGrdProposal();
            }

            if (cmbSalesStage.SelectedValue.Equals("6"))
            {
                //DatePickerOrderDate.Visible = true;
                //DatePickerDeploymentDate.Visible = true;
                //txtWinlossReason.Visible = true;


                lblOrderDate.Visible = true;
                DatePickerOrderDate.Visible = true;

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
            Pnl_Proposal.Visible = true;
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
                cmbSiteACountry.SelectedValue = item["Site_A_Country"].Text;
                cmbSiteACity.SelectedValue = item["Site_A_City"].Text;
                txtSiteBAddress.Text = item["Site_B_Address"].Text;
                cmbSiteBCountry.SelectedValue = item["Site_B_Country"].Text;
                cmbSiteBCity.SelectedValue = item["Site_B_City"].Text;
                cmbName.SelectedValue = item["Name"].Text;
                cmbQuantityUOM.SelectedValue = item["QuantityUOM"].Text;
                cmbInterface.SelectedValue = item["Interface"].Text;
                txtLastMileProtection.Text = item["Last_Mile_Protection"].Text;
                txtWetPortionRestorability.Text = item["Wet_Portion_Restorability"].Text;
                txtSLA.Text = item["SLA"].Text;
                DatePickerRFSDateDuration.SelectedDate = DateTime.Today;
                txtContractTerm.Text = item["Contract_Term"].Text;
                cmbWinLossStatus.SelectedValue = item["win_loss"].Text;
                cmbCurrencyDetail.SelectedValue = item["Currency"].Text;
                cmbStatus.SelectedValue = item["Status"].Text;
                txtNRCBudget.Text = item["NRC_Budget"].Text;
                txtMRCBudget.Text = item["MRC_Budget"].Text;
                txtNRCCostOnNet.Text = item["NRC_Cost_On_Net"].Text;
                txtMRCCostOnNet.Text = item["MRC_Cost_On_Net"].Text;
                txtNRCCostOffNet.Text = item["NRC_Cost_Off_Net"].Text;
                txtMRCCostOffNet.Text = item["MRC_Cost_Off_Net"].Text;
                txtNRCCostOOP.Text = item["NRC_Cost_OOP"].Text;
                txtMRCCostOOP.Text = item["MRC_Cost_OOP"].Text;
                txtNameof3P.Text = item["Name_of_3P"].Text;
                txtNRCActual.Text = item["NRC_Actual"].Text;
                txtMRCActual.Text = item["MRC_Actual"].Text;
                txtNRR.Text = item["NRR"].Text;
                txtMRR.Text = item["MRR"].Text;
                txtROI.Text = item["ROI"].Text;
                txtTermProfit.Text = item["Term_Profit"].Text;
                txtTermRevenue.Text = item["Term_Revenue"].Text;
                txtRecurringMargin.Text = item["Recurring_Margin_Percentage"].Text;
                txtNonRecurringMargin.Text = item["Non_Recurring_Margin_Percentage"].Text;
            }
        }

        protected void GrdProposal_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }


        protected void GV_CreateOpportunity_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GV_CreateOpportunity.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                ViewState["OppDetailID"] = item["OppDetID"].Text;
                txtSiteAAddress.Text = item["Site_A_Address"].Text;
                cmbSiteACountry.SelectedValue = item["Site_A_Country"].Text;
                cmbSiteACity.SelectedValue = item["Site_A_City"].Text;
                txtSiteBAddress.Text = item["Site_B_Address"].Text;
                cmbSiteBCountry.SelectedValue = item["Site_B_Country"].Text;
                cmbSiteBCity.SelectedValue = item["Site_B_City"].Text;
                cmbName.SelectedValue = item["Name"].Text;
                cmbQuantityUOM.SelectedValue = item["QuantityUOM"].Text;
                cmbInterface.SelectedValue = item["Interface"].Text;
                txtLastMileProtection.Text = item["Last_Mile_Protection"].Text;
                txtWetPortionRestorability.Text = item["Wet_Portion_Restorability"].Text;
                txtSLA.Text = item["SLA"].Text;
                DatePickerRFSDateDuration.SelectedDate = DateTime.Today;
                txtContractTerm.Text = item["Contract_Term"].Text;
                //txtWinLoss.Text = item["win_loss"].Text;
                cmbWinLossStatus.SelectedValue = item["win_loss"].Text;
                cmbCurrencyDetail.SelectedValue = item["Currency"].Text;
                cmbStatus.SelectedValue = item["Status"].Text;
                txtNRCBudget.Text = item["NRC_Budget"].Text;
                txtMRCBudget.Text = item["MRC_Budget"].Text;
                txtNRCCostOnNet.Text = item["NRC_Cost_On_Net"].Text;
                txtMRCCostOnNet.Text = item["MRC_Cost_On_Net"].Text;
                txtNRCCostOffNet.Text = item["NRC_Cost_Off_Net"].Text;
                txtMRCCostOffNet.Text = item["MRC_Cost_Off_Net"].Text;
                txtNRCCostOOP.Text = item["NRC_Cost_OOP"].Text;
                txtMRCCostOOP.Text = item["MRC_Cost_OOP"].Text;
                txtNameof3P.Text = item["Name_of_3P"].Text;
                txtNRCActual.Text = item["NRC_Actual"].Text;
                txtMRCActual.Text = item["MRC_Actual"].Text;
                txtNRR.Text = item["NRR"].Text;
                txtMRR.Text = item["MRR"].Text;
                txtROI.Text = item["ROI"].Text;
                txtTermProfit.Text = item["Term_Profit"].Text;
                txtTermRevenue.Text = item["Term_Revenue"].Text;
                txtRecurringMargin.Text = item["Recurring_Margin_Percentage"].Text;
                txtNonRecurringMargin.Text = item["Non_Recurring_Margin_Percentage"].Text;
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
            cmbEndCustomer.SelectedValue = "";
            cmbCurrency.SelectedValue = "";
            cmbStatus.SelectedValue = "";
            txtWinProbability.Text = "";
            txtSiteAAddress.Text = "";
            cmbSiteACountry.SelectedValue = "";
            cmbSiteACity.SelectedValue = "";
            txtSiteBAddress.Text = "";
            cmbSiteBCountry.SelectedValue = "";
            cmbSiteBCity.SelectedValue = "";
            cmbName.SelectedValue = "";
            cmbQuantityUOM.SelectedValue = "";
            cmbInterface.SelectedValue = "";
            txtLastMileProtection.Text = "";
            txtWetPortionRestorability.Text = "";
            txtSLA.Text = "";
            //DatePickerRFSDateDuration.SelectedDate = "";
            txtContractTerm.Text = "";
            cmbWinLossStatus.SelectedValue = "";
            cmbCurrencyDetail.SelectedValue = "";
            cmbStatus.SelectedValue = "";
            txtNRCBudget.Text = "";
            txtMRCBudget.Text = "";
            txtNRCCostOnNet.Text = "";
            txtMRCCostOnNet.Text = "";
            txtNRCCostOffNet.Text = "";
            txtMRCCostOffNet.Text = "";
            txtNRCCostOOP.Text = "";
            txtMRCCostOOP.Text = "";
            txtNameof3P.Text = "";
            txtNRCActual.Text = "";
            txtMRCActual.Text = "";
            txtNRR.Text = "";
            txtMRR.Text = "";
            txtROI.Text = "";
            txtTermProfit.Text = "";
            txtTermRevenue.Text = "";
            txtRecurringMargin.Text = "";
            txtNonRecurringMargin.Text = "";
        }
    }
}