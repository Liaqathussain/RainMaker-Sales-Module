using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker
{
    public partial class SearchCircuits : System.Web.UI.Page
    {
        Service1SoapClient objBSS = new Service1SoapClient();
        BL obl = new BL();
        static DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                tbCMSID.Text = string.Empty;
                tbCPEIPAddress.Text = string.Empty;
                tbCustomerName.Text = string.Empty;
                tbGPID.Text = string.Empty;
                tbIPAddress.Text = string.Empty;
                LoadComboBox();
                Session["SignupID"] = tbSignupID.Text;
                lblAlreadyExist.Visible = false;
                btnViewDetails.Visible = false;
            }
        }

        public void LoadComboBox()
        {
            obl.loadTicketType(cmbTicketType);
            obl.LoadCircuitOwner(cmbComplainAt);
            obl.loadRegions(cmbRegion);
            obl.loadRing(cmbRing, 0, 1);
            obl.loadCusCode(cmbCustomerCode, cmbCity1, "Serach");
            obl.loadCities(cmbCity1);
            obl.loadNode(cmbNode, 0, 0, "");
            obl.GetReportCircuitStatus(cmbStatus, "View");
            obl.loadCities(cmbCity2);
            obl.getServicesUnitByLOb(cmbServiceUnit, 0);
            obl.GetInfra(cmbInfra, 1, 0);
            cmbTicketType.SelectedValue = "CU";
            cmbComplainAt.SelectedValue = "1";
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            loadCircuitDetails();
        }

        protected void gvActiveCircuits_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                string Check = e.CommandName;
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)gvActiveCircuits.Items[index];
                if (cmbComplainAt.SelectedValue == "0" || cmbTicketType.SelectedValue == "N/A")
                {
                    //Interaction.MsgBox("Please Select Above Inforamtion First", MsgBoxStyle.Information, "BSS Adminstrator");
                    return;
                }
                Session["Complain_SignupID"] = item["SignupID"].Text;
                Session["Complain_CMSID"] = item["CMSID"].Text;
                Session["Complain_InfraID"] = item["InfraID"].Text;
                Session["Complain_InfraCode"] = item["InfraCode"].Text;
                
                if (cmbTicketType.SelectedValue == "CU")
                {
                    Session["Complain_TicketTypeID"] = 6; 
                }

                if (cmbComplainAt.SelectedValue == "1")
                {
                    Session["Complain_CircuitOwnerCode"] = "MP";
                }
                else if (cmbComplainAt.SelectedValue == "2")
                {
                    Session["Complain_CircuitOwnerCode"] = "TD";
                }

                if (Check == "Complain")
                {
                    //if (CheckComplainAlredyExists(Convert.ToInt16(item["SignupID"].Text)))
                    //if (CheckComplainAlredyExists(Convert.ToInt16(tbSignupID.Text)))                    
                    if (CheckComplainAlredyExists(Convert.ToInt32(Session["Complain_SignupID"])))
                    {
                        Session["Complain_Flag"] = "Insert";
                        //Response.Redirect("~\\ComplainForm.aspx");
                        Response.Redirect("~\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["Complain_SignupID"]) + "&ComplainID=" + 0 +"&Flag="+Session["Complain_Flag"]);
                    }
                    else
                    {
                        return;
                    }

                }

                if (Check == "ComplainHistory")
                {
                    Session["Complain_MultiFlag"] = "ViewCircuitTransaction";
                    //Response.Redirect("~\\ComplainForm.aspx");
                    
                }

                if (Check == "StatusHistory")
                {
                    Session["Complain_MultiFlag"] = "ViewClientStatusHistory";
                    Session["View_SignupID"] = item["SignupID"].Text;
                    Session["View_CMSID"] = item["CMSID"].Text;
                    Response.Redirect("~\\ComplainForm.aspx");
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("gvActiveCircuits_CellClick:" + ex.Message + "of frmSearchCircuitsForOTS ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void EnableCombo(string TicketType)
        {
            try
            {
                if (TicketType == "RN")
                {
                    cmbRegion.Enabled = true;
                    cmbCity2.Enabled = false;
                    cmbRing.Enabled = false;
                    cmbNode.Enabled = false;
                    cmbCustomerCode.Enabled = false;
                }
                else if (TicketType == "CT")
                {
                    cmbCity2.Enabled = true;
                    cmbRegion.Enabled = false;
                    cmbRing.Enabled = false;
                    cmbNode.Enabled = false;
                    cmbCustomerCode.Enabled = false;
                }
                else if (TicketType == "ND")
                {
                    cmbCity2.Enabled = false;
                    cmbRegion.Enabled = false;
                    cmbRing.Enabled = false;
                    cmbNode.Enabled = true;
                    cmbCustomerCode.Enabled = false;
                }
                else if (TicketType == "RG")
                {
                    cmbCity2.Enabled = false;
                    cmbRegion.Enabled = false;
                    cmbRing.Enabled = true;
                    cmbNode.Enabled = false;
                    cmbCustomerCode.Enabled = false;

                }
                else if (TicketType == "CP")
                {
                    cmbCity2.Enabled = false;
                    cmbRegion.Enabled = false;
                    cmbRing.Enabled = false;
                    cmbNode.Enabled = false;
                    cmbCustomerCode.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCircuitDetails()
        {
            try
            {
                int signupid = 0;
                if (tbSignupID.Text != string.Empty)
                {
                    signupid = Convert.ToInt16(tbSignupID.Text);
                }
                else
                {
                    signupid = 0;
                }

                dt = objBSS.GetCircuitforOTS(signupid,tbCMSID.Text, tbCustomerName.Text, tbGPID.Text,Convert.ToInt16(cmbRegion.SelectedValue), cmbTicketType.SelectedValue == "CU" ? Convert.ToInt16(cmbCity2.SelectedValue) : Convert.ToInt16(cmbCity1.SelectedValue) ,Convert.ToInt16(cmbRing.SelectedValue),Convert.ToInt16(cmbNode.SelectedValue),Convert.ToInt16(cmbCustomerCode.SelectedValue),tbCPEIPAddress.Text,Convert.ToInt16(cmbStatus.SelectedValue),Convert.ToInt16(cmbInfra.SelectedValue),Convert.ToInt16(cmbServiceUnit.SelectedValue),tbCPEIPAddress.Text);

                Session["ComplainDataSource"] = dt;

                if (dt.Rows.Count != 0)
                {
                    lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                    gvActiveCircuits.DataSource = dt;
                    gvActiveCircuits.DataBind();
                    if (cmbTicketType.SelectedValue == "CU")
                    {
                        gvActiveCircuits.MasterTableView.GetColumn("colComp").Display = false;
                        gvActiveCircuits.MasterTableView.GetColumn("colHistoryView").Display = false;
                        gvActiveCircuits.MasterTableView.GetColumn("colStatusHis").Display = false;
                    }
                    gvActiveCircuits.MasterTableView.GetColumn("CityID").Display = false;
                    gvActiveCircuits.MasterTableView.GetColumn("InfraID").Display = false;
                    gvActiveCircuits.MasterTableView.GetColumn("InfraCode").Display = false;
                    gvActiveCircuits.MasterTableView.GetColumn("ServiceUnitID").Display = false;

                }
                else
                {
                    gvActiveCircuits.MasterTableView.GetColumn("colComp").Display = false;
                    gvActiveCircuits.MasterTableView.GetColumn("colHistoryView").Display = false;
                    lblTotalCount.Text = "0";
                    gvActiveCircuits.DataSource = null;
                    gvActiveCircuits.DataBind();
                    
                }
                
            }

            catch (Exception e)
            {
            }

        }

        public bool CheckComplainAlredyExists(int SignupID)
        {
            try
            {
                // DialogResult dgresult = default(DialogResult);
                dynamic dt = objBSS.checkComplainBySignupID(SignupID);
                if (dt.Rows.Count > 0)
                {
                    //dgresult = MessageBox.Show("Already Exists having Ticket Number: " + dt.Rows(0)("TicketNo") + " And Complain Status: " + dt.Rows(0)("ComplainStatus") + " Do you View Complaint Details ?", "Business Support System", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if (dgresult == Windows.Forms.DialogResult.No | dgresult == Windows.Forms.DialogResult.Cancel)
                    //{
                    //    return false;
                    //}
                    //else if (dgresult == Windows.Forms.DialogResult.Yes)
                    //{
                    //    AppDomain.CurrentDomain.SetData("Complain_ComplainID", dt.Rows(0)("ComplaintID"));
                    //    AppDomain.CurrentDomain.SetData("Complain_Flag", "View");
                    //    if (dt.Rows(0)("TicketTypeID") == 6)
                    //    {
                    //        frmOts_SingleComplain objView = new frmOts_SingleComplain();
                    //        objView.MdiParent = this.ParentForm;
                    //        objView.Show();
                    //        objView.BringToFront();
                    //    }
                    //    else
                    //    {
                    //        frmOts_MultipleComplain objView = new frmOts_MultipleComplain();
                    //        objView.MdiParent = this.ParentForm;
                    //        objView.Show();
                    //        objView.BringToFront();
                    //    }
                    //}
                    Session["SignupID"] = dt.Rows[0]["SignupID"];
                    Session["ComplainID"] = dt.Rows[0]["ComplaintID"];
                    btnViewDetails.Visible = true;
                    lblAlreadyExist.Visible = true;
                    lblAlreadyExist.Text = "Already Exist With Ticket No :" + dt.Rows[0]["TicketNo"];
                    
                    

                    return false;
                }
                else
                {
                    return true;
                }


                //MsgBox("Already Exists having Ticket Number: " + dt.Rows(0)("TicketNo") + " And Complain Status" + dt.Rows(0)("ComplainStatus"), MsgBoxStyle.Information, "BSS Administrator")

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnviewDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainForm.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]) + "&ComplainID=" + Convert.ToInt32(Session["ComplainID"]) + "&Flag=View");
        }

        private void SetTicketTypeID()
        {
            try
            {
                if (cmbTicketType.SelectedValue == "RG")
                {
                    //AppDomain.CurrentDomain.SetData("Complain_TicketTypeID", 1);
                    Session["Complain_TicketTypeID"] = 1;

                }
                else if (cmbTicketType.SelectedValue == "CT")
                {
                    //AppDomain.CurrentDomain.SetData("Complain_TicketTypeID", 2);
                    Session["Complain_TicketTypeID"] = 2;
                }
                else if (cmbTicketType.SelectedValue == "ND")
                {
                    //AppDomain.CurrentDomain.SetData("Complain_TicketTypeID", 3);
                    Session["Complain_TicketTypeID"] = 3;
                }
                else if (cmbTicketType.SelectedValue == "RN")
                {
                    //AppDomain.CurrentDomain.SetData("Complain_TicketTypeID", 4);
                    Session["Complain_TicketTypeID"] = 4;
                }
                else if (cmbTicketType.SelectedValue == "CP")
                {
                    AppDomain.CurrentDomain.SetData("Complain_TicketTypeID", 5);
                    Session["Complain_TicketTypeID"] = 5;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbRegion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbRegion.SelectedValue != "0")
                {
                    loadCircuitDetails();
                }
            }
            catch (Exception ex)
            {
               // Interaction.MsgBox("cmbRegion_SelectedIndexChanged:" + ex.Message + "of cntSerachSingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void cmbNode_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbNode.SelectedValue != "0")
                {
                    loadCircuitDetails();
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cmbNode_SelectedIndexChanged:" + ex.Message + "of cntSerachSingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void cmbRing_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbRing.SelectedValue != "0")
                {
                    loadCircuitDetails();
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cmbRing_SelectedIndexChanged:" + ex.Message + "of cntSerachSingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void cmbCustomerCode_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbCustomerCode.SelectedValue != "0")
                {
                    loadCircuitDetails();
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cmbCustomerCode_SelectedIndexChanged:" + ex.Message + "of cntSerachSingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void cmbCity_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbCity2.SelectedValue != "0")
                {
                    loadCircuitDetails();
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cmbCity_SelectedIndexChanged:" + ex.Message + "of cntSerachSingleComplain ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        protected void cmbTicketType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (cmbTicketType.SelectedValue != "N/A")
                {
                    if (cmbTicketType.SelectedValue == "CU")
                    {
                        pnlSingleSearch.Enabled = true;
                        pnlMultipleSearch.Enabled = false;
                        cmbCity2.SelectedValue = "0";
                        cmbCustomerCode.SelectedValue = "0";
                        cmbRegion.SelectedValue = "0";
                        cmbNode.SelectedValue = "0";
                        cmbRing.SelectedValue = "0";
                        cmbStatus.SelectedValue = "0";
                        cmbInfra.SelectedValue = "0";
                        cmbStatus.Enabled = true;
                        cmbCity1.SelectedValue = "0";
                        cmbServiceUnit.SelectedValue = "0";
                    }
                    else
                    {
                        EnableCombo(cmbTicketType.SelectedValue);
                        pnlSingleSearch.Enabled = false;
                        pnlMultipleSearch.Enabled = true;
                        //FormComplainStripButton1.Visible = true;
                        btMultipleCircuitsComplain.Visible = true;
                        cmbStatus.SelectedValue = "4";
                        cmbStatus.Enabled = false;
                        tbCMSID.Text = string.Empty;
                        tbCustomerName.Text = string.Empty;
                        tbIPAddress.Text = string.Empty;
                        tbSignupID.Text = string.Empty;
                        tbGPID.Text = string.Empty;

                        if (cmbTicketType.SelectedValue == "RN")
                        {
                            cmbCity2.SelectedValue = "0";
                            cmbCustomerCode.SelectedValue = "0";
                            cmbNode.SelectedValue = "0";
                            cmbRing.SelectedValue = "0";

                        }
                        else if (cmbTicketType.SelectedValue == "CT")
                        {
                            cmbRegion.SelectedValue = "0";
                            cmbCustomerCode.SelectedValue = "0";
                            cmbNode.SelectedValue = "0";
                            cmbRing.SelectedValue = "0";

                        }
                        else if (cmbTicketType.SelectedValue == "RG")
                        {
                            cmbRegion.SelectedValue = "0";
                            cmbCustomerCode.SelectedValue = "0";
                            cmbNode.SelectedValue = "0";
                            cmbCity2.SelectedValue = "0";

                        }
                        else if (cmbTicketType.SelectedValue == "ND")
                        {
                            cmbRegion.SelectedValue = "0";
                            cmbCustomerCode.SelectedValue = "0";
                            cmbRing.SelectedValue = "0";
                            cmbCity2.SelectedValue = "0";

                        }
                        else if (cmbTicketType.SelectedValue == "CP")
                        {
                            cmbRegion.SelectedValue = "0";
                            cmbNode.SelectedValue = "0";
                            cmbRing.SelectedValue = "0";
                            cmbCity2.SelectedValue = "0";

                        }

                        gvActiveCircuits.DataSource = null;
                        gvActiveCircuits.DataBind();
                    }

                }
                else
                {
                    btMultipleCircuitsComplain.Visible = false;
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("cmbTicketType_SelectedIndexChanged:" + ex.Message + "of frmSearchCircuitsForOTS ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        protected void btMultipleCircuitsComplain_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComplainAt.SelectedValue == "1")
                {
                    Session["Complain_CircuitOwnerCode"] = "MP";
                    //AppDomain.CurrentDomain.SetData("Complain_CircuitOwnerCode", "MP");
                }
                else if (cmbComplainAt.SelectedValue == "2")
                {
                    Session["Complain_CircuitOwnerCode"] = "TD";
                    //AppDomain.CurrentDomain.SetData("Complain_CircuitOwnerCode", "TD");
                }
                Session["Complain_ComplainID"] = 0;
                Session["Complain_TicketTypCode"] = cmbTicketType.SelectedValue;
                Session["Complain_Flag"] = "Insert";
                SetTicketTypeID();

                //AppDomain.CurrentDomain.SetData("Complain_ComplainID", 0);
               
                //AppDomain.CurrentDomain.SetData("Complain_Flag", "Insert");
               // Session["Complain_TicketTypCode"] = "Insert";
                // AppDomain.CurrentDomain.SetData("Complain_TicketTypCode", "Insert");
              
                //AppDomain.CurrentDomain.SetData("Complain_TicketTypCode", cmbTicketType.SelectedValue);

       

                //int SignupID = Convert.ToInt32(item["SignupID"].Text);

                //Response.Redirect("~/InfraCosting.aspx?Distance=" + Distance + "&City=" + City + "&CircuitType=Primary");


                if (dt == null)
                {
                    return;
                }
                else
                {
                    Session["GridView"] = dt;
                    Response.Redirect("~\\MultipleComplainForm.aspx");
                }
            }
            catch (Exception ex)
            {
                //  Interaction.MsgBox("FormComplainStripButton1_Click:" + ex.Message + "of frmSearchCircuitsForOTS ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }


    }
}