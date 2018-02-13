using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RainMaker.BSS_Service;
using Telerik.Web.UI;
using System.IO;

namespace RainMaker
{
    public partial class WebForm3 : System.Web.UI.Page
    {

      static  object Frm;
      static int UserID;
      static int RoleID;
      static int DeptID;
      static string InfraCode;
      static string CircuitCode;
      static string TicketTypeCode;
      static public string TicketNumber;
      static int CircuitCount = 0;
      static string parentTicket;
      static int SelectCount;
      static int TicketTypeID;
      static int SelectedCount = 0;
        BL objBL = new BL();
        Service1SoapClient objBSS = new Service1SoapClient();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["GridView"];
                gvMultipleComplainForm.DataSource = dt;
                gvMultipleComplainForm.DataBind();
                
                BL objBL = new BL();
                objBL.LoadPocStatus(cmbPOCStatus);
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadAssignedDepartment(cmbAssignedDepartment,"All");
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.LoadComplaintReportedVia(cmbComplaintReportedVia);
                lblDateTime.Text = DateTime.Today.ToString();
                tbLoggedBy.Text = Session["Name"].ToString();
                tbLoggedBy.Enabled = false;
                lblEngineerName.Text = Session["Name"].ToString();
                tbPersonGivenETA.Text = Session["Name"].ToString();
                tbPersonGivenETA.Enabled = false;
                dtETA.SelectedDate = DateTime.MinValue;
                dtETTR.SelectedDate = DateTime.MinValue;
                dtETA.Enabled = false;
                dtETTR.Enabled = false;
                dtComplaintReceived.SelectedDate = DateTime.Now;
                //objBL.loadLoggedBy(tbLoggedBy);
            }
        }



   

        #region "Helping Function"

        private void LoadMyCombos()
        {
            try
            {
                objBL.LoadComplaintReportedVia(cmbComplaintReportedVia);
                objBL.LoadCaseCategory(cmbCaseCategory);
                objBL.LoadPocStatus(cmbPOCStatus);
                objBL.LoadInitialStatement(cmbInitialStatement);
                objBL.loadAssignedDepartment(cmbAssignedDepartment,"All");
                objBL.LoadComplainType(cmbComplainType);
                objBL.LoadComplainStatus(cmbComplainStatus, "All");
                cmbComplainStatus.SelectedValue = "2";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetParentTiket()
        {
            try
            {
                //TicketTypeCode = Session["Complain_TicketTypeCode"].ToString();
                TicketTypeCode = Session["Complain_TicketTypCode"].ToString();
                int seq = 0;
                CircuitCode = Session["Complain_CircuitOwnerCode"].ToString();
                string octate = objBSS.GetComplainParentTicket(CircuitCode, TicketTypeCode);
                string[] Str = octate.Split('-');
                if (Str.Length == 2)
                {
                    seq = Convert.ToInt32(Str[0]) + 1;
                }

                parentTicket = CircuitCode + "-" + TicketTypeCode + "-" + Convert.ToString(seq);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetChildTicket(int Count)
        {
            try
            {
                TicketNumber = parentTicket + "-" + Convert.ToString(Count);
                return TicketNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckCustomerSelect()
        {
            bool @bool = false;

            try
            {
                foreach (GridDataItem item in gvMultipleComplainForm.Items)
                {   
                    var cb =(CheckBox) item.FindControl("Select");
                    if (cb.Checked == true)
                    {
                        @bool = true;
                        SelectCount = SelectCount + 1;
                    }
                }

                if (!@bool)
                {
                    //Interaction.MsgBox("Please Select Atleast one Clients", MsgBoxStyle.Critical, Title: "Message Box");
                    return @bool;
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
            return @bool;
        }

        public bool InsertComplain(int SigID, string TickNo)
        {
            try
            {
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                UserID = Convert.ToInt32(Session["UserID"]);
                int SignupID = SigID;
                string TicketNo = TickNo;
                int InitailStatementID = Convert.ToInt32( cmbInitialStatement.SelectedValue);
                int ComplaintTypeID = Convert.ToInt32(cmbComplainType.SelectedValue);
                int TicketTypeID = Convert.ToInt32(Session["Complain_TicketTypeID"].ToString());
                int ComplaintStatusID = Convert.ToInt32(cmbComplainStatus.SelectedValue);
                int ProblemDignoseEndID = 5;
                string LoggedBy = tbLoggedBy.Text;
                int ComplaintReportedviaId = Convert.ToInt32(cmbComplaintReportedVia.SelectedValue);
                DateTime ComplaintReceivedDate = Convert.ToDateTime(dtComplaintReceived.SelectedDate.Value);
                string PersonSolving = string.Empty;
                int CaseCategoryID = Convert.ToInt32( cmbCaseCategory.SelectedValue );
                string CallerName = tbCallerName.Text;
                string CallerNumber = tbCallerNumber.Text;
                string PoCName = tbPOCName.Text;
                string PoCNumber = tbPOCNumber.Text;
                int PoCStatusID = Convert.ToInt32(cmbPOCStatus.SelectedValue);
                int AssignedToDeptID = Convert.ToInt32(cmbAssignedDepartment.SelectedValue);
                int AssignedByDeptID = DeptID;
                string FCR = "";
                DateTime Hold_UnHoldTime = Convert.ToDateTime("1/1/1990");
                string RCA = "";
                string Partner = "";
                int LinkStatusID = 1;
                string Location = "";
                string Fault = "";
                string TxnOwner = "";
                DateTime ETA = default(DateTime);
                DateTime ETTR = default(DateTime);
                string PersonGivenETA = "";
                if (ComplaintStatusID == 4)
                {
                    ETA = dtETA.SelectedDate.Value;
                    ETTR = dtETTR.SelectedDate.Value;
                    PersonGivenETA = tbPersonGivenETA.Text;
                }
                else
                {
                    ETA = Convert.ToDateTime("1/1/1900");
                    ETTR = Convert.ToDateTime("1/1/1900");
                    PersonGivenETA = "";
                }
                string Remarks = tbRemarks.Text;
                string QueryResponse = "";
                string IPOpsComments = "";
                string AssignedPersonName = Session["Name"].ToString();
                int TransactionBy = UserID;

                //int ComplainID = objBSS.InsertComplain(SignupID, TicketNo, InitailStatementID, ComplaintTypeID, TicketTypeID, ComplaintStatusID, ProblemDignoseEndID, LoggedBy, ComplaintReportedviaId, ComplaintReceivedDate,
                //PersonSolving, CaseCategoryID, CallerName, CallerNumber, PoCName, PoCNumber, PoCStatusID, AssignedToDeptID, AssignedByDeptID, FCR,
                //Hold_UnHoldTime, RCA, Partner, LinkStatusID, Location, Fault, TxnOwner, ETA, ETTR, PersonGivenETA,
                //Remarks, QueryResponse, IPOpsComments, AssignedPersonName, TransactionBy);

                int ComplainID = objBSS.InsertComplain(SignupID, TicketNo, InitailStatementID, ComplaintTypeID, TicketTypeID, ComplaintStatusID, ProblemDignoseEndID, LoggedBy, ComplaintReportedviaId, ComplaintReceivedDate,
                PersonSolving, CaseCategoryID, CallerName, CallerNumber, PoCName, PoCNumber, PoCStatusID, AssignedToDeptID, AssignedByDeptID, FCR,
                Hold_UnHoldTime, RCA, Partner, LinkStatusID, Location, Fault, TxnOwner, ETA, ETTR, PersonGivenETA,
                Remarks, QueryResponse, IPOpsComments, AssignedPersonName, TransactionBy);

                if (ComplainID > 0)
                {
                    return true;
                }
                else
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dgresult = MessageBox.Show("Are you sure to save the record?", "Business Support System", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dgresult == Windows.Forms.DialogResult.No)
                //{
                //    return;
                //}

                //if (cmbAssignedDepartment.SelectedValue == 0 | cmbCaseCategory.SelectedValue == 0 | cmbComplainStatus.SelectedValue == 0 | cmbComplaintReportedVia.SelectedValue == 0 | cmbComplainType.SelectedValue == 0 | cmbInitialStatement.SelectedValue == 0 | cmbPoCStatus.SelectedValue == 0)
                //{
                //    Interaction.MsgBox("Please Select all validate fields", MsgBoxStyle.Information, "BSS Administrator");
                //    return;
                //}

                //if (tbCallerName.Text == string.Empty | tbCallerNumber.Text == string.Empty | tbLoggedBy.Text == string.Empty | tbPoCName.Text == string.Empty | tbPoCNumber.Text == string.Empty)
                //{
                //    Interaction.MsgBox("Please enter all validate fields", MsgBoxStyle.Information, "BSS Administrator");
                //    return;
                //}

                CheckCustomerSelect();

                string msg = string.Empty;
                int TicketCount = 0;
                GetParentTiket();


                if (gvMultipleComplainForm.Items.Count > 0)
                {


                    foreach (GridDataItem row in gvMultipleComplainForm.Items)
                    {
                        var cb = (CheckBox)row.Cells[0].FindControl("cb_Select");


                        if (cb.Checked == true)
                        {
                            TicketCount = TicketCount + 1;
                            string ChildTicket= GetChildTicket(TicketCount);
                            int CellI=Convert.ToInt32(row.Cells[4].Text.ToString());
                            if (InsertComplain(CellI, ChildTicket))
                            {
                                CircuitCount = CircuitCount + 1;
                            }
                   
                        }
                    }

                    //if (CircuitCount == Convert.ToInt32(lblCount.Text))
                    //{
                    //   // Interaction.MsgBox("Complain Insert Sucessfully TicketNo is : " + TicketNumber, MsgBoxStyle.Information, "BSS Administrator");
                    //   // this.Close();
                    //}
                    //else
                    //{
                    //   // Interaction.MsgBox(Convert.ToString(CircuitCount) + " Record Insert Sucessfully Out of " + lblCount.Text, MsgBoxStyle.Information, "BSS Administrator");
                    //   // this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }

        }

       /* public void DignoseFormSenerio(string Flag, int ComplainID)
        {
            try
            {
                if (Flag == "Insert")
                {
                    lblEngineerName.Text = Session["Name"].ToString();
                    tbLoggedBy.Text = Session["Name"].ToString();
                    lblDateTime.Text = Convert.ToString(DateTime.Now);
                    CircuitCode = Session["Complain_CircuitOwnerCode"].ToString();
                    InfraCode = Session["Complain_InfraCode"].ToString();
                    TicketTypeCode = Session["Complain_TicketTypCode"].ToString();
                }
                else if (Flag == "View" & ComplainID != 0)
                {
                    lblEngineerName.Text = Session["Name"].ToString();
                    lblDateTime.Text = Convert.ToString(DateTime.Now);
                    GetComplainDetails(ComplainID);
                    CustomerlistEffected();
                    btSaveComplain.Visible = false;

                }
                else if (Flag == "Update" & ComplainID != 0)
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } */

       /* public void GetComplainDetails(int ComplainID)
        {
            try
            {
                dynamic dt = objBSS.GetComplainDetailByComplainID(ComplainID);
                if (dt.Rows.Count == 1)
                {
                    pnlComplainTD.Visible = true;
                    lblComplainTicketNo.Text = dt.Rows(0)("TicketNo");
                    lblLoggedDateTime.Text = dt.Rows(0)("LoggedDateTime");
                    tbLoggedBy.Text = dt.Rows(0)("LoggedBy");
                    TicketTypeID = dt.Rows(0)("TicketTypeID");
                    tbCallerName.Text = dt.Rows(0)("CallerName");
                    tbCallerNumber.Text = dt.Rows(0)("CallerNumber");
                    tbPoCName.Text = dt.Rows(0)("PoCName");
                    tbPoCNumber.Text = dt.Rows(0)("PoCNumber");
                    tbRemarks.Text = dt.Rows(0)("Remarks");
                    dtComplainRecived.Value = dt.Rows(0)("ComplaintReceivedDate");
                    cmbAssignedDepartment.SelectedValue = dt.Rows(0)("AssignedDeptID");
                    cmbCaseCategory.SelectedValue = dt.Rows(0)("CaseCategoryID");
                    cmbComplainStatus.SelectedValue = dt.Rows(0)("ComplaintStatusID");
                    cmbComplaintReportedVia.SelectedValue = dt.Rows(0)("ComplaintReportedviaId");
                    cmbComplainType.SelectedValue = dt.Rows(0)("ComplaintTypeID");
                    cmbInitialStatement.SelectedValue = dt.Rows(0)("InitialStatementID");
                    cmbPoCStatus.SelectedValue = dt.Rows(0)("PoCStatusID");
                }
                else
                {
                    pnlComplainTD.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } */

       /* public void CustomerlistEffected()
        {
            try
            {
                int Count = 0;
                string Modified_Tick = string.Empty;
                if (TicketTypeID != 6 | TicketTypeID != 0)
                {
                    string[] str = lblComplainTicketNo.Text.Split("-");
                    Count = 4;
                    Modified_Tick = Conversion.str(0) + "-" + Conversion.str(1) + "-" + Conversion.str(2);
                }


                dynamic dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, 0,
                0, 0, 0, 0, Convert.ToDateTime("1/1/1990"), Convert.ToDateTime("1/1/1990"), 0, 0, 0, Count,
                "", 0, 0, 0, 0, 0);
                lblCount.Text = Convert.ToString(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    gvActiveCircuits.DataSource = dt;
                    chkAll.Checked = true;
                }
                else
                {
                    lblCount.Text = "0";
                    gvActiveCircuits.DataSource = null;
                    gvActiveCircuits.Rows.Clear();
                    Interaction.MsgBox("No Record Found", MsgBoxStyle.Information, "BSS Administrator");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } */

       /* private void CheckTextInGridView()
        {
            try
            {
                foreach (GridDataItem row in gvMultipleComplainForm.Items)
                {
                    var cb = (CheckBox) row.Cells[0];
                    if ((row.Cells["Primary_IpAddres"].Value != null))
                    {
                        if (row.Cells["Primary_IpAddres"].Value == tbMultipleSearch.Text)
                        {
                            if (CheckComplainAlredyExists(row.Cells["SignupID"].value))
                            {
                                cb.Value = true;
                                lblNotify.Text = "Found";
                                lblNotify.ForeColor = Color.DarkGreen;
                                SelectedCount = SelectedCount + 1;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                            else
                            {
                                cb.Value = false;
                                lblNotify.Text = "Not Found";
                                lblNotify.ForeColor = Color.Red;
                            }

                        }
                        else
                        {
                            lblNotify.Text = "Not Found";
                            lblNotify.ForeColor = Color.Red;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        } */

       /* public bool CheckComplainAlredyExists(int SignupID)
        {
            try
            {
                DialogResult dgresult = default(DialogResult);
                dynamic dt = objBSS.checkComplainBySignupID(SignupID);
                if (dt.Rows.Count > 0)
                {
                    dgresult = MessageBox.Show("Already Exists having Ticket Number: " + dt.Rows(0)("TicketNo") + " And Complain Status: " + dt.Rows(0)("ComplainStatus") + " Do you View Complaint Details ?", "Business Support System", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dgresult == Windows.Forms.DialogResult.No | dgresult == Windows.Forms.DialogResult.Cancel)
                    {
                        return false;
                    }
                    else if (dgresult == Windows.Forms.DialogResult.Yes)
                    {
                        AppDomain.CurrentDomain.SetData("Complain_ComplainID", dt.Rows(0)("ComplaintID"));
                        AppDomain.CurrentDomain.SetData("Complain_Flag", "View");
                        if (dt.Rows(0)("TicketTypeID") == 6)
                        {
                            frmOts_SingleComplain objView = new frmOts_SingleComplain();
                            objView.MdiParent = this.ParentForm;
                            objView.Show();
                            objView.BringToFront();
                        }
                        else
                        {
                            frmOts_MultipleComplain objView = new frmOts_MultipleComplain();
                            objView.MdiParent = this.ParentForm;
                            objView.Show();
                            objView.BringToFront();
                        }
                    }

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
        } */

        #endregion


    }
}