using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Data;
using RainMaker.Classes;
using System.ComponentModel;


namespace RainMaker.IBU
{
    public partial class CreateOpportunityIBU : System.Web.UI.Page
    {
        
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        BL obj_BL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //trrHideMe.Visible = false;
            //trrBudgetary.Visible = false;
            //testDiv.Visible = false;
            if (!IsPostBack)
            {
                GetOppStages();
                GetAccounts();
                //BindGrdDetails();
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
                GetInterface();
                


                //Pnl_Opportunity.Visible = false;


                txtKAM.Text = Session["Name"].ToString();
                txtWorkingBy.Text = Session["Name"].ToString();
                txtLastUpdateBy.Text = Session["Name"].ToString();
                txtLastUpdatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtOpportunityCreation.Text = DateTime.Now.ToString("dd/MM/yyyy");



                lblOrderDate.Visible = false;
                DatePickerOrderDate.Visible = false;

                lblDeploymentDate.Visible = false;
                DatePickerDeploymentDate.Visible = false;

                lblWinlossReason.Visible = false;
                txtWinlossReason.Visible = false;

                //RevenueLines
                Pnl_RevenueLines.Visible = false;
                btn_Add.Visible = false;


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

                System.DateTime dt = DateTime.Now;
                DatePickerBudgetaryQuoteDate.SelectedDate = dt;
                DatePickerQuoteProposalDate.SelectedDate = dt;


                //Last Updated By and Last Updated Date
                lblLastUpdatedDate.Visible = false;
                txtLastUpdatedDate.Visible = false;

                lblLastUpdatedBy.Visible = false;
                txtLastUpdateBy.Visible = false;

               

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
            //cmbSalesStage.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
        }


        private void BindGrdDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityDetails(Convert.ToInt32(ViewState["OpportunityID"]));
            //GV_CreateOpportunity.DataSource = dt_GetOppDetails;
            //GV_CreateOpportunity.DataBind();
            RadgridForProducts.DataSource = dt_GetOppDetails;
            RadgridForProducts.DataBind();
            //DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpp(Convert.ToString(ViewState["OpportunityID"]));
            //RadgridForProducts.DataSource = dt_GetOppDetails;
            //RadgridForProducts.DataBind();

            for (int i = 0; i < dt_GetOppDetails.Rows.Count; i++)
            {
                DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[i].Cells[1].FindControl("cmbUOM");
                DropDownList ddl3 = (DropDownList)RadgridForProducts.Rows[i].Cells[2].FindControl("cmbInterface");
                FillDropDownList1(ddl1);
                FillDropDownList3(ddl3);

            }
           
        }
        private void BindGrdRevenueDetails()
        {
            DataTable dt_GetOppDetails = obj_clsGeneralFunction.GetOpportunityRevenueDetails(Convert.ToInt32(ViewState["OpportunityRevID"]));
            GVProducts.DataSource = dt_GetOppDetails;
            GVProducts.DataBind();
        }

        private void BindGrdBudgetary()
        {
            DataTable dt_GetBudgetary = obj_clsGeneralFunction.GetOpportunityBudgetary();
            GV_GrdBudgetary.DataSource = dt_GetBudgetary;
            GV_GrdBudgetary.DataBind();
        }

        private void BindGrdProposal()
        {
            DataTable dt_GetStages = obj_clsGeneralFunction.GetOpportunityProposal();
            GV_GrdProposal.DataSource = dt_GetStages;
            GV_GrdProposal.DataBind();
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
            //DataTable dt_GetStatus = obj_clsGeneralFunction.GetOppStatus();
            //cmbOppStatus.DataSource = dt_GetStatus;
            //cmbOppStatus.DataTextField = "OppStatus";
            //cmbOppStatus.DataValueField = "OppStatusID";
            //cmbOppStatus.DataBind();
            //cmbOppStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
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
            cmbCurrency.Items.Insert(0, new RadComboBoxItem("Please-Select", "0"));
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

        private void GetQuantityUOM()
        {
            obj_BL.loadBandWidth(cmbQuantityUOM);
        }

        private void GetInterface()
        {
            obj_BL.GetInterface(cmbInterface );
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

            if (txtOpportunityName.Text.Equals(""))
            {
                lblStatus.Text = "Insert Opportunity Name";
                
            }
            else
            {
                                       // public object CreateOpportunity(string OppName,string LOB_ID, int StageID,int PartnerID,int CustCode,int ContactID, string WinProbability,int KAMID, int WorkingBy, string Attachment1,int LastUpdateBy  )
                object obj_OpportunityId = obj_clsOpportunity.CreateOpportunity(txtOpportunityName.Text,"2", Convert.ToInt32(cmbSalesStage.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), 2, Convert.ToInt32(cmbEndCustomer.SelectedValue), "", Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), txtAttachement.Text, Convert.ToInt32(Session["UserID"]));
                ViewState["OpportunityID"] = obj_OpportunityId;
                lblStatus.Text = "Updated Successfully" + "-" + obj_OpportunityId;
            }
           
            //obj_clsOpportunity.CreateOpportunityDetails(txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), txtQuantity.Text, txtUOM.Text,  Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, txtWinLoss.Text, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToInt32(obj_OpportunityId));

        }


        private void Update()
        {
            DateTime BudgetaryQuoteDate = Convert.ToDateTime(DatePickerBudgetaryQuoteDate.SelectedDate.Value.ToShortDateString());
            DateTime QuoteProposalDate = Convert.ToDateTime(DatePickerQuoteProposalDate.SelectedDate.Value.ToShortDateString());

            object obj_OpportunityId = obj_clsOpportunity.UpdateOpportunity(Convert.ToInt32(ViewState["OpportunityID"]), txtOpportunityName.Text, Convert.ToInt32(cmbEndCustomer.SelectedValue), Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(Session["UserID"]), Convert.ToInt32(Session["UserID"]), 1, Convert.ToInt32(cmbSalesStage.SelectedValue), 1);
            //obj_clsOpportunity.UpdateOpportunityDetails(Convert.ToInt32(ViewState["OpportunityID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue, Convert.ToInt32(cmbCurrency.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, txtNameof3P.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            obj_clsOpportunity.UpdateOpportunityDetails(Convert.ToInt32(ViewState["OpportunityID"]), txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, cmbWetPortionRestorability.SelectedValue.ToString(), txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue, Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToDecimal(txtNRCBudget.Text), Convert.ToDecimal(txtMRCBudget.Text), Convert.ToDecimal(txtNRCCostOnNet.Text), Convert.ToDecimal(txtMRCCostOnNet.Text), Convert.ToDecimal(txtNRCCostOffNet.Text), Convert.ToDecimal(txtMRCCostOffNet.Text), Convert.ToDecimal(txtNRCCostOOP.Text), Convert.ToDecimal(txtMRCCostOOP.Text), txtNameof3P.Text, Convert.ToDecimal(txtNRCActual.Text), Convert .ToDecimal (txtMRCActual.Text) , Convert.ToDecimal(txtNRR.Text), Convert.ToDecimal(txtMRR.Text), Convert.ToDecimal(txtROI.Text), Convert.ToDecimal(txtTermProfit.Text), Convert.ToDecimal(txtTermRevenue.Text), Convert.ToDecimal(txtRecurringMargin.Text), Convert .ToDecimal ( txtNonRecurringMargin.Text));
                                                                                           

        }

        private void AddRevenueLines()
        {
                                                                                    //public object CreateOpportunityDetails(string Site_A_Address, int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency, int OppID)
            //obj_clsOpportunity.CreateOpportunityDetails(txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, txtWetPortionRestorability.Text, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue.ToString(), Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToInt32(ViewState["OpportunityID"]));
            object obj_OpportunityRevId = obj_clsOpportunity.CreateOpportunityDetails(txtSiteAAddress.Text, Convert.ToInt32(cmbSiteACountry.SelectedValue), Convert.ToInt32(cmbSiteACity.SelectedValue), txtSiteBAddress.Text, Convert.ToInt32(cmbSiteBCountry.SelectedValue), Convert.ToInt32(cmbSiteBCity.SelectedValue), Convert.ToInt32(cmbName.SelectedValue), Convert.ToInt32(cmbQuantityUOM.SelectedValue), Convert.ToInt32(cmbInterface.SelectedValue), txtLastMileProtection.Text, cmbWetPortionRestorability.SelectedValue, txtSLA.Text, DatePickerRFSDateDuration.SelectedDate.Value, txtContractTerm.Text, cmbWinLossStatus.SelectedValue.ToString(), Convert.ToInt32(cmbCurrency.SelectedValue), Convert.ToInt32(ViewState["OpportunityID"]));
            ViewState["OpportunityRevID"] = obj_OpportunityRevId;
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
                        
                            DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[row.RowIndex].FindControl("cmbUOM");
                            string BandWidthID = ddl1.SelectedValue.ToString();

                            DropDownList ddl2 = (DropDownList)RadgridForProducts.Rows[row.RowIndex].FindControl("cmbInterface");
                            string InterfaceID = ddl2.SelectedValue.ToString();
                            string ServiceID = dt_GetOppDetails.Rows[row.RowIndex ]["ServiceUnitID"].ToString();
                            if (!(BandWidthID.Equals("-1")))
                            {
                                object obj_OpportunityRevId = obj_clsOpportunity.CreateOpportunityDetailsEBU_ForProducts(Convert.ToInt32(ServiceID), Convert.ToInt32(BandWidthID), "BandWidthType", 0, Convert.ToInt32(InterfaceID), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(ViewState["OpportunityRevID"]), Convert.ToInt32(Session["UserID"]));
                                ViewState["OpportunityRevID"] = obj_OpportunityRevId;

                                //object obj_OpportunityRevId = obj_clsOpportunity.CreateOpportunityDetailsForProducts(Convert.ToInt32 (ServiceID), Convert.ToInt32(UMID), Convert.ToInt32(InterfaceID), Convert.ToInt32(ViewState["OpportunityRevID"]), 1);
                                //ViewState["OpportunityRevID"] = obj_OpportunityRevId;
                            }     
                    }
                }
               
            }
           
        }

        protected void cmbSalesStage_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbSalesStage.SelectedValue.Equals("2"))
            {
                //lblBudgetaryQuote.Visible = true;
                //CheckBoxBudgetaryQuote.Visible = true;
                //lblBudgetaryQuoteDate.Visible = true;
                //DatePickerBudgetaryQuoteDate.Visible = true;
                Pnl_Budgetary.Visible = true;
                ////Pnl_GrdCreateOpportunity.Visible = false;
                //BindGrdBudgetary();


            }

            if (cmbSalesStage.SelectedValue.Equals("4"))
            {
                // Pnl_Budgetary.Visible = true;
                //// Pnl_GrdCreateOpportunity.Visible = false;
                 Pnl_Proposal.Visible = true;
                // lblQuoteProposalDate.Visible = true;
                // DatePickerQuoteProposalDate.Visible = true;
                // lblBudgetaryQuote.Visible = true;
                // CheckBoxBudgetaryQuote.Visible = true;
                // lblBudgetaryQuoteDate.Visible = true;
                // DatePickerBudgetaryQuoteDate.Visible = true;
                // Pnl_GrdBudgetary.Visible = false;
                // BindGrdProposal();
            }

            if (cmbSalesStage.SelectedValue.Equals("6"))
            {
                //DatePickerOrderDate.Visible = true;
                //DatePickerDeploymentDate.Visible = true;
                //txtWinlossReason.Visible = true;


                //lblOrderDate.Visible = true;
                //DatePickerOrderDate.Visible = true;

                //lblDeploymentDate.Visible = true;
                //DatePickerDeploymentDate.Visible = true;

                //lblWinlossReason.Visible = true;
                //txtWinlossReason.Visible = true;
                
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btn_SaveDetail_Click(object sender, EventArgs e)
        {
            AddRevenueLinesDetails();
            //RadgridForProducts.Visible = false;
            GVProducts.Visible = true;
            BindGrdRevenueDetails();
        }
        
        //protected void GV_CreateOpportunity_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    Pnl_RevenueDetailsForProducts.Visible = true;
        //    //AddRevenueLinesDetails();
        //    //BindGrdRevenueDetails();
        //    Pnl_GrdCreateOpportunity.Visible = true;



        //    DataTable dt_GetOppDetails = obj_BL.getProductName(1);
        //    RadgridForProducts.DataSource = dt_GetOppDetails;
        //    RadgridForProducts.DataBind();

        //    for (int i = 0; i < dt_GetOppDetails.Rows.Count; i++)
        //    {
        //        DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[i].Cells[1].FindControl("cmbUOM");
        //        DropDownList ddl3 = (DropDownList)RadgridForProducts.Rows[i].Cells[2].FindControl("cmbInterface");
        //        FillDropDownList1(ddl1);
        //        FillDropDownList3(ddl3);

        //    }
        //}

        protected void RadgridForProducts_ItemCommand(object sender, GridCommandEventArgs e)
        {
            Pnl_RevenueDetailsForProducts.Visible = true;
            //AddRevenueLinesDetails();
            //BindGrdRevenueDetails();
            Pnl_GrdCreateOpportunity.Visible = true;
            //if (e.CommandName == "Select")
            //{
            //    int index = e.Item.ItemIndex;
            //    GridDataItem item = (GridDataItem)GV_GrdProposal.Items[index];
            //    //Get the values from the row uaing the columnUniqueName 
            //    ViewState["OppDetailID"] = item["OppDetID"].Text;


            //}


            DataTable dt_GetOppDetails = obj_BL.getProductName(1);
            RadgridForProducts.DataSource = dt_GetOppDetails;
            RadgridForProducts.DataBind();

            for (int i = 0; i < dt_GetOppDetails.Rows.Count; i++)
            {
                DropDownList ddl1 = (DropDownList)RadgridForProducts.Rows[i].Cells[1].FindControl("cmbUOM");
                DropDownList ddl3 = (DropDownList)RadgridForProducts.Rows[i].Cells[2].FindControl("cmbInterface");
                FillDropDownList1(ddl1);
                FillDropDownList3(ddl3);

            }
        }
        protected void btn_AddRevenueLines_Click(object sender, EventArgs e)
        {
            Pnl_RevenueLines.Visible = true;
            btn_Add.Visible = true;
        }


        protected void btn_Add_Click(object sender, EventArgs e)
        {
            ProductGridView.Visible = true;
            AddRevenueLines();
            BindGrdDetails();
            ProductGridView.Visible = true;
            
            //Pnl_GrdCreateOpportunity.Visible = true;
          
            lblStatus.Text = "Saved Successfully" + "-" + ViewState["OpportunityRevID"];
        }

       
        protected void btUpdate_Click1(object sender, EventArgs e)
        {
            Update();
            BindGrdDetails();
        }



        //private void FillDropDownList2(DropDownList dd2)
        //{
        //    DataTable dtProductName = obj_BL.getProductName(0, cmbName);
        //    foreach (DataRow row in dtProductName.Rows)
        //    {
        //        dd2.Items.Add(new ListItem(row["ServiceUnit"].ToString(), row["ServiceUnitID"].ToString()));
        //    }
        //}

        private void FillDropDownList1(DropDownList dd1)
        {

            DataTable DTUOM = obj_BL.GetloadBandWidth(cmbQuantityUOM);

            foreach (DataRow row in DTUOM.Rows)
            {
                dd1.Items.Add(new ListItem(row["BandwidthDesc"].ToString(), row["BandwidthID"].ToString()));
            }
        }

        private void FillDropDownList3(DropDownList dd3)
        {

            DataTable DTInterface = obj_BL.GetInterface(cmbInterface);

            foreach (DataRow row in DTInterface.Rows)
            {
                dd3.Items.Add(new ListItem(row["Interface"].ToString(), row["InterfaceID"].ToString()));
            }
        }

        protected void btnHide_Click(object sender, EventArgs e)
        {
            GVProducts.Visible = false; 
        }

        protected void GV_CreateOpportunity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void btnProductsView_Click(object sender, EventArgs e)
        {
            ProductGridView.Visible = true;
            GVProducts.Visible = true;
            BindGrdRevenueDetails();
        }

        protected void RadgridForProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void RadgridForProducts_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {
        //        int index = e.Item.ItemIndex;
        //        GridDataItem item = (GridDataItem)GV_GrdProposal.Items[index];
        //        //Get the values from the row uaing the columnUniqueName 
        //        ViewState["OppDetailID"] = item["OppDetID"].Text;


        //    }
        //}
       
              
    }
}