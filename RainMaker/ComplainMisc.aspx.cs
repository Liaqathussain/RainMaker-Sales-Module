using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using RainMaker.Classes;
using System.IO;

namespace RainMaker
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public static string click = "";
        static int ComplainStatusID = 0;
        static int AssignmentDeptID = 0;
        static int TicketTypeID = 0;
        static int DataGridCount = 0;
        static int UserID = 0;
        static int RoleID = 0;
        static int DeptID = 0;
        static DataTable dt = new DataTable();
        int CircuitCount = 0;
        string RequestTypeAtNE = "";
        int FailedCount = 0;
        int SelectCount = 0;
        int AssginedDepart;

        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        Cls_Territory objCls = new Cls_Territory();
        BL objBL = new BL();


        protected void gvActiveCircuits_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                click = base.Request.QueryString["click"].ToString();
                UserID = Convert.ToInt32(Session["UserID"]);
                RoleID = Convert.ToInt32(Session["RoleID"]);
                DeptID = Convert.ToInt32(Session["DepartmentID"]);
                tbPersonSolvingComplain.Text = Session["Name"].ToString();
                lblEngineerName.Text = Session["Name"].ToString();
                lblDateTime.Text = Convert.ToString(DateTime.Now);
                lblstatus.Visible = false;
                lblSucessCount.Visible = false;
                lblFailedCount.Visible = false;


                if (click == "Solving")
                {
                    

                    pnlComplainSolving.Visible = true;
                    //cmbComplainStatus.Text = "Solved";
                    //cmbComplainStatus.Enabled = false;
                    lblCauses.Visible = false;
                    tbCauses.Visible = false;
                    lblRootCauseAnalysis.Visible = false;
                    tbRootCauseAnalysis.Visible = false;
                    lblPreventiveMeasures.Visible = false;
                    tbPreventiveMeasures.Visible = false;
                    LoadMyCombos(click);
                    //GetComplainDetails(Convert.ToInt32(Session["ComplainID"]));
                    GetComplainDetails(Convert.ToInt32(Session["ComplainID"]));
                    loadGridView(click);

                }
                if (click == "Complain Closure")
                {
                    pnlComplainClosure.Visible = true;
                    frmOts_ComplainClousrevb_Load();

                }
                if (click == "View History")
                {
                    MainFSCpanel.Visible = false;
                    ViewHistory.Visible = true;
                    LoadCustomer(1);
                    loadGridviewHistory(1);

                }
                if (click == "Follow Up")
                {
                    //pnlComplainInProcessForm.Visible = true;


                    dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
                    //dynamic dt = objBSS.GetComplainDetailByComplainID(85950);

                    //test liaqat code
                    //UserID = Convert.ToInt32(Session["UserID"]);
                    //RoleID = Convert.ToInt32(Session["RoleID"]);
                    //Session["DeptID"] = Convert.ToInt32(Session["DepartmentID"]);

                    //if (Session["DepartmentID"].ToString().Equals(1) || Convert.ToInt32(Session["DeptID"]) == 3)
                    //{
                    //    tbIPResponses.ReadOnly = false;
                    //    RadioRequestTypeNE.Visible = true;
                    //    lblRequest.Visible = true;
                    //    RadioRequestTypeNE.Visible = true;
                    //}





                    if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(3))
                    {
                        tbIPResponses.ReadOnly = false;
                        RadioRequestTypeNE.Visible = true;
                        lblRequest.Visible = true;
                        //RadioRequestTypeNE.Visible = true;
                    }
                    else
                    {
                        tbIPResponses.ReadOnly = true;
                        RadioRequestTypeNE.Visible = false;
                        lblRequest.Visible = false;
                    }
                    LoadMyCombos(click);
                    if (dt.Rows.Count > 0)
                    {

                        ViewState["Pic1"] = dt.Rows[0]["Picture1"].ToString();
                        ViewState["Pic2"] = dt.Rows[0]["Picture2"].ToString();

                        if (dt.Rows.Count < 2)
                        {
                            cbCheckAll.Enabled = false;
                        }

                        pnlComplainInProcessForm.Visible = true;
                        objBL.LoadComplainStatus(cmbCaseCategory0, "Follow");
                        objBL.loadAssignedDepartment(cmbCaseCategory1, "Follow");
                        tbLoggedBy0.Text = Session["Name"].ToString();
                        if (Convert.ToString(dt.Rows[0]["ETTR"]) != "")
                        {
                            RadDateTimePicker1.SelectedDate = (DateTime)dt.Rows[0]["ETTR"]; //(DateTime)Session["ETTR"];
                        }
                        if (Convert.ToString(dt.Rows[0]["ETA"]) != "")
                        {
                            RadDateTimePicker3.SelectedDate = (DateTime)dt.Rows[0]["ETA"]; //(DateTime)Session["ETA"];
                        }
                        tbLoggedBy3.Text = dt.Rows[0]["Remarks"]; //Session["Remarks"].ToString();

                        this.tbComplainTicketNo.Text = dt.Rows[0]["TicketNo"];
                        tbComplainLoggedBy.Text = dt.Rows[0]["LoggedBy"];
                        ComplainStatusID = dt.Rows[0]["ComplaintStatusID"];
                        tbComplaintReceivedDT.Text = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                        tbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];

                        cmbCaseCategory1.Text = dt.Rows[0]["AssignDepartment"];
                        cmbCaseCategory1.SelectedValue = Convert.ToString(dt.Rows[0]["AssignedDeptID"]);

                        cmbCaseCategory0.Text = dt.Rows[0]["ComplainStatus"];
                        cmbCaseCategory0.SelectedValue = Convert.ToString(dt.Rows[0]["ComplaintStatusID"]);

                        tbLoggedBy0.ReadOnly = true;

                        TicketTypeID = Convert.ToInt32(dt.Rows[0]["TicketTypeID"]);
                        if (TicketTypeID == 6)
                        {
                            cbCheckAll.Enabled = false;
                        }

                        if (ComplainStatusID.Equals(1) || ComplainStatusID.Equals(5))
                        {
                            btnUpdate.Visible = false;
                        }

                        if (ComplainStatusID.Equals("6"))
                        {
                            cmbCaseCategory1.Enabled = false;
                        }

                        tbRemarks.Text = dt.Rows[0]["Remarks"];
                        if (Convert.ToString(dt.Rows[0]["LastUpdatedDate"]) != "")
                        {
                            AppDomain.CurrentDomain.SetData("LastUpdatedDate", Convert.ToDateTime(dt.Rows[0]["LastUpdatedDate"]));
                        }
                        if (dt.Rows[0]["ComplaintStatusID"] == 4)
                        {

                            lblEngineerName.Text = Session["Name"].ToString();
                            lblDateTime.Text = DateTime.Now.ToShortDateString();
                            tbComplainLoggedBy.Text = dt.Rows[0]["PersonGivenETA"];
                            RadDateTimePicker3.SelectedDate = dt.Rows[0]["ETA"];
                            RadDateTimePicker1.SelectedDate = dt.Rows[0]["ETTR"];
                            tbIPResponses.Text = dt.Rows[0]["QueryResponse"];
                            if (dt.Rows[0]["RequestTypeAtNE"] == "Support Request")
                            {
                                RadioRequestTypeNE.Items[0].Selected = true;
                            }
                            else if (dt.Rows[0]["RequestTypeAtNE"] == "Service Request")
                            {
                                RadioRequestTypeNE.Items[0].Selected = true;
                            }

                        }
                        loadGridView(click);
                    }
                    else
                    {
                        ViewState["Pic1"] = "";
                        ViewState["Pic2"] = "";
                    }
                }
            }
        }



        private void loadGridviewHistory(int Flag)
        {
            try
            {
                int CompID = Convert.ToInt32(Session["Complain_ComplainID"].ToString());
                if (CompID != 0)
                {
                    dynamic dt = objBSS.GetComplainHistory(CompID, Flag);
                    if (dt.Rows.Count != 0)
                    {

                        RadGrid2.DataSource = dt;
                        RadGrid2.DataBind();
                        RadGrid2.MasterTableView.GetColumn("ComplainID").Display = false;
                        RadGrid2.MasterTableView.GetColumn("FLag").Display = false;

                    }
                    else
                    {
                        //lblNotify.Text = "No Record Transaction Found";
                        //lblNotify.Visible = true;
                        //lblNotify.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCustomer(int Flag)
        {
            try
            {
                if (Flag == 1)//Using BSS DB to show reports
                {
                    dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["Complain_ComplainID"].ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        lbl_CusName.InnerHtml = dt.Rows[0]["CircuitName"];
                        lbl_TicNum.InnerHtml = dt.Rows[0]["TicketNo"];
                        lbl_ComRec.InnerHtml = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                        lbl_LUT.InnerHtml = Convert.ToString(dt.Rows[0]["LastUpdatedDate"]);
                        lbl_CS.InnerHtml = dt.Rows[0]["ComplainStatus"];
                        lbl_AD.InnerHtml = dt.Rows[0]["AssignDepartment"];
                        lbl_CN.InnerHtml = dt.Rows[0]["CallerName"] + "/" + dt.Rows[0]["CallerNumber"];
                        lbl_LR.InnerHtml = dt.Rows[0]["Remarks"];

                    }


                }
                //else if (Flag == 0)//Using CMS DB to show reports
                //{
                //    dynamic dt_Old = objBSS.GetComplainHistory(AppDomain.CurrentDomain.GetData("Complain_ComplainID"), Flag);
                //    if (dt_Old.Rows.Count != 0)
                //    {
                //        lblCircuitName.Text = AppDomain.CurrentDomain.GetData("Complain_CiruitName");
                //        lblTicketNo.Text = dt_Old.Rows(0)("TicketNo");
                //        lblComplainDate.Text = dt_Old.Rows(0)("IssueDate");
                //        lblLastUpdateTime.Text = dt_Old.Rows(0)("LastUpdated");
                //        lblComplainStatus.Text = dt_Old.Rows(0)("Status");
                //        lblAssignedDept.Text = dt_Old.Rows(0)("Department");
                //        lblCallerNameNum.Text = "-/-";
                //        lblRemarks.Text = dt_Old.Rows(0)("Remarks");
                //    }
                //    else
                //    {
                //        lblNotify.Text = "No Record Transaction Found";
                //        lblNotify.Visible = true;
                //        lblNotify.ForeColor = Color.Red;
                //    }

                //}

            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.Message(), MsgBoxStyle.Information, "BSS Administrator");
            }

        }

        private void frmOts_ComplainClousrevb_Load()
        {
            try
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                RoleID = Convert.ToInt32(Session["RoleID"].ToString());
                //DeptID = Convert.ToInt32(Session["DepartmentID"].ToString());
                DeptID = Convert.ToInt16(Session["DepartmentID"]);
                lblEngineerName.Text = Session["Name"].ToString();
                lblDateTime.Text = Convert.ToString(DateTime.Now);
                LoadMyCombos("Complain Closure");
                tbComplainTicketNo.Text = Session["TicketNo"].ToString();
                GetComplainDetails(Convert.ToInt32(Session["ComplainID"].ToString()));
                loadGridView("Complain Closure");
            }
            catch (Exception ex)
            {
                //  Interaction.MsgBox("frmOts_ComplainClousrevb_Load:" + ex.Message + "of frmOts_ComplainClousrevb ", MsgBoxStyle.Critical, "BSS Addminstrator");
            }
        }

        private void LoadMyCombos(string click)
        {
            if (click == "Solving")
            {
                try
                {
                    objBL.LoadComplainStatus(cmbComplainStatus, "All");
                    objBL.loadAssignedDepartment(cmbAssignedDepartment, "Solve");
                    objBL.loadTypeDescbyOwnerID(cmbLastMileInfra, 0);
                    cmbAssignedDepartment.SelectedValue = "61";
                    cmbAssignedDepartment.Enabled = false;
                    cmbComplainStatus.SelectedValue = "1";
                    cmbComplainStatus.Enabled = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (click == "Follow Up")
            {
                try
                {
                    objBL.loadAssignedDepartment(cmbAssignedDepartment, "Follow");
                    objBL.LoadComplainStatus(cmbCaseCategory0, "Follow");
                    cmbCaseCategory0.SelectedValue = "4";


                    if (Convert.ToInt32(Session["DeptID"]) == 15 | Convert.ToInt32(Session["DeptID"]) == 1)
                    {
                        cmbAssignedDepartment.Enabled = true;
                    }


                    //if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                    //{
                    //    pnlEscalation.Visible = true;
                    //    DataTable DTTeam = objCls.GetTeam();
                    //    cmbTeam.DataSource = DTTeam;
                    //    cmbTeam.DataTextField = "TeamID";
                    //    cmbTeam.DataValueField = "TeamName";
                    //    cmbTeam.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                    //    DataTable DTPriority = objCls.GetPriority();
                    //    cmbPriority.DataSource = DTPriority;
                    //    cmbPriority.DataTextField = "OMPriorityName";
                    //    cmbPriority.DataValueField = "OMPriorityID";
                    //    cmbPriority.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                    //}
                    //else
                    //{
                    //    pnlEscalation.Visible = false;
                    //}


                    if (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                    {
                        pnlEscalation.Visible = true;
                        DataTable DTTeam = objBSS.GetTeamList();
                        cmbTeam.DataSource = DTTeam;
                      
                        cmbTeam.DataTextField = "TeamName";
                        cmbTeam.DataValueField = "TeamID";
                        cmbTeam.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                        cmbTeam.DataBind();
                       

                        //DataTable DTPriority = objCls.GetPriority(); 
                        DataTable DTPriority = objBSS.GetTeamPrioirty();
                        cmbPriority.DataSource = DTPriority;
                        cmbPriority.DataTextField = "OMPriorityName";
                        cmbPriority.DataValueField = "OMPriorityID";
                        cmbPriority.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                        cmbPriority.DataBind();

                    }
                    else
                    {
                        cmbTeam.SelectedValue = "0";
                        cmbPriority.SelectedValue = "0";
                        pnlEscalation.Visible = false;
                    }

                

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (click == "Complain Closure")
            {
                try
                {
                    objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                    cmbAssignedtoDepartment.SelectedValue = "8";
                    cmbAssignedtoDepartment.Enabled = false;
                    objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                    cmbComplaintStatus.SelectedValue = "5";
                    //cmbComplaintStatus.Text = "Closed";
                    //cmbComplaintStatus.SelectedValue = "5";
                    cmbComplaintStatus.Enabled = false;
                    rbFurtherAction.Enabled = false;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void GetComplainDetails(int ComplainID)
        {
            try
            {
                dynamic dt = objBSS.GetComplainDetailByComplainID(ComplainID);
                if (dt.Rows.Count > 0)
                {
                    //tbTicketNo.Text = dt.Rows(0)("TicketNo");
                    tbComplainTicketNo.Text = dt.Rows[0]["TicketNo"];
                    tbComplainLoggedBy.Text = dt.Rows[0]["LoggedBy"];
                    ComplainStatusID = dt.Rows[0]["ComplaintStatusID"];
                    TicketTypeID = dt.Rows[0]["TicketTypeID"];
                    tbRemarks.Text = dt.Rows[0]["Remarks"];
                    int SignUpId = dt.Rows[0]["SignUpID"];

                    if ( (TicketTypeID.Equals(6)) &  (Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60)))
                    {
                        DataTable dt_DeplDet =  objBSS.GetCircuitDeploymentDetatils(SignUpId);
                        //DataTable dt_DeplDet = objBSS.GetCircuitDeploymentDetatils(9630);

                        if (dt_DeplDet.Rows.Count > 0)
                        {
                            txtJoinName.Text = dt_DeplDet.Rows[0]["JoinName"].ToString();
                            txtTubeNameFromCustomer.Text = dt_DeplDet.Rows[0]["TubeNameFromCustomer"].ToString();
                            txtCoreColorFromCustomer.Text = dt_DeplDet.Rows[0]["CoreColorFromCustomer"].ToString();
                            txtTubeNameFromNode.Text = dt_DeplDet.Rows[0]["TubeNameFromNode"].ToString();
                            txtCoreColorFromNode.Text = dt_DeplDet.Rows[0]["CoreColorFromNode"].ToString();
                            txtCutDistance.Text = dt_DeplDet.Rows[0]["CutDistance"].ToString();

                        }
                         
                        pnlFiberDetails.Visible = true;                        
                    }
                    else
                    {
                        pnlFiberDetails.Visible = false;
                    }

                    if (TicketTypeID == 6)
                    {
                        cbCheckAll.Enabled = false;
                    }

                    //if (ComplainStatusID == 5 | ComplainStatusID == 1)
                    if (ComplainStatusID.Equals(5))
                    {
                        btnUpdate.Visible = false;
                    }

                    //else
                    //{
                    //    btnUpdate.Visible = true;
                    //}

                    tbComplainStatus.Text = dt.Rows[0]["ComplainStatus"];
                    cmbAssignedDepartment.SelectedValue = Convert.ToString(dt.Rows[0]["AssignedDeptID"]);
                    objBL.LoadProblemDignosedAt(cmbProblemDiagnosedat, Convert.ToInt32(cmbAssignedDepartment.SelectedValue));
                    objBL.LoadReasonOutage(cmbReasonofOutage, 0, 0, Convert.ToInt32(cmbAssignedDepartment.SelectedValue), 1, Convert.ToInt32(Session["UserID"]));
                    tbComplaintReceivedDT.Text = Convert.ToString(dt.Rows[0]["ComplaintReceivedDate"]);
                    AppDomain.CurrentDomain.SetData("LastUpdatedDate", Convert.ToDateTime(dt.Rows[0]["LastUpdatedDate"]));
                    tbRemarksSolving.Text = dt.Rows[0]["Remarks"];
                    //ComplainStatusID = 1;
                    if (ComplainStatusID.Equals(1) || ComplainStatusID.Equals(5))
                    {
                        //tbPersonSolvingComplain.Text = dt.Rows[0]["PersonSolving"];
                        dtSolving.SelectedDate = dt.Rows[0]["ComplainSolvingDate"];
                        cmbProblemDiagnosedat.SelectedValue = Convert.ToString(dt.Rows[0]["ProblemDignoseEndID"]);
                        cmbReasonofOutage.SelectedValue = Convert.ToString(dt.Rows[0]["ReasonOutageID"]);
                        if (dt.Rows[0]["FCR"] == "True")
                        {
                            rbFCR.SelectedIndex = 0;
                        }
                        else
                        {
                            rbFCR.SelectedIndex = 1;
                        }

                        tbCauses.Text = dt.Rows[0]["Dignose_Causes"];
                        tbRootCauseAnalysis.Text = dt.Rows[0]["Dignose_RootCauseAnalysis"];
                        tbPreventiveMeasures.Text = dt.Rows[0]["Dignose_PreventativeMeasureTake"];
                        cmbLastMileInfra.SelectedValue = Convert.ToString(dt.Rows[0]["LastMileInfraID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvActiveCircuits_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
            //gvActiveCircuits.DataSource = dt;
        }

        protected void cmbProblemDiagnosedat_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            dynamic dt = objBSS.GetComplainDetailByComplainID(Convert.ToInt32(Session["ComplainID"]));
            int AssignedDepartmentID = Convert.ToInt32(dt.Rows[0]["AssignedDeptID"]);
            if (!(Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(0)))
            {
                //objBL.LoadReasonOutage(cmbReasonofOutage, cmbProblemDiagnosedat.SelectedValue, 0, AssignedDepartmentID, 1);
                objBL.LoadReasonOutage(cmbReasonofOutage, Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue), 0, AssignedDepartmentID, 1, Convert.ToInt32(Session["UserID"]));

                if (Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(2) || Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue).Equals(7))
                {
                    lblCauses.Visible = true;
                    tbCauses.Visible = true;
                    lblRootCauseAnalysis.Visible = true;
                    tbRootCauseAnalysis.Visible = true;
                    lblPreventiveMeasures.Visible = true;
                    tbPreventiveMeasures.Visible = true;
                }
                else
                {
                    lblCauses.Visible = false;
                    tbCauses.Visible = false;
                    lblRootCauseAnalysis.Visible = false;
                    tbRootCauseAnalysis.Visible = false;
                    lblPreventiveMeasures.Visible = false;
                    tbPreventiveMeasures.Visible = false;
                }

            }


        }


        //protected void rbCustomerFeedback_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    if (rbCustomerFeedback.SelectedValue.Equals("Negative"))
        //    {
        //        rbFurtherAction.Enabled = false;
        //    }
        //}

        protected void rbCustomerFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbCustomerFeedback.SelectedValue.Equals("Negative"))
            {
                rbFurtherAction.Enabled = true;
            }

            if (rbCustomerFeedback.SelectedValue.Equals("Positive"))
            {
                rbFurtherAction.Enabled = false;
            }
        }

        protected void rbFurtherAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbFurtherAction.SelectedValue.Equals("N/A"))
            {
                objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                cmbAssignedtoDepartment.SelectedValue = "8";
                cmbAssignedtoDepartment.Enabled = false;
                objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                cmbComplaintStatus.SelectedValue = "5";
                cmbComplaintStatus.Enabled = false;
            }

            if (rbFurtherAction.SelectedValue.Equals("Re-Initiated"))
            {
                objBL.loadAssignedDepartment(cmbAssignedtoDepartment, "Close");
                cmbComplaintStatus.SelectedValue = "0";
                cmbAssignedtoDepartment.Enabled = true;
                objBL.LoadComplainStatus(cmbComplaintStatus, "All");
                cmbComplaintStatus.SelectedValue = "4";
                cmbComplaintStatus.Enabled = false;
            }
        }

        public void loadGridView(string click)
        {
            if (click == "Solving")
            {
                try
                {
                    int Count = 0;
                    string Modified_Tick = string.Empty;
                    if (TicketTypeID != 6 & TicketTypeID != 0)
                    {
                        //string[] str = tbComplainTicketNo.Text.Split(

                        string split = tbComplainTicketNo.Text;
                        string[] str = split.Split('-');
                        Count = 4;
                        Modified_Tick = string.Concat(str[0]) + "-" + string.Concat(str[1]) + "-" + string.Concat(str[2]);
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 4, 0, 0, "",
                        0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                        "", 0, 0, 0, 0, 0);
                    }
                    else if (TicketTypeID == 6)
                    {
                        Count = 3;
                        Modified_Tick = tbComplainTicketNo.Text;
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                        0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                        "", 0, 0, 0, 0, 0);

                    }


                    DataGridCount = dt.Rows.Count;
                    if (dt.Rows.Count > 0)
                    {
                        lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                        gvActiveCircuits.DataSource = dt;
                        gvActiveCircuits.DataBind();
                    }
                    else
                    {
                        lblTotalCount.Text = "0";
                        gvActiveCircuits.DataSource = null;
                        gvActiveCircuits.DataBind();
                        //gvActiveCircuits.Rows.Clear();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (click == "Follow Up")
            {
                int Count = 0;
                string Modified_Tick = string.Empty;
                //if (Convert.ToInt32(Session["TicketTypeID"]) != 6 & Convert.ToInt32(Session["TicketTypeID"]) != 0)
                if (TicketTypeID != 6 & TicketTypeID != 0)
                {
                    //string[] str = tbComplainTicketNo.Text.Split("-");
                    string split = tbComplainTicketNo.Text;
                    string[] str = split.Split('-');
                    Count = 4;
                    Modified_Tick = string.Concat(str[0]) + "-" + string.Concat(str[1]) + "-" + string.Concat(str[2]);
                    dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                    0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                    "", 0, 0, 0, 0, 0);
                }
                else if (TicketTypeID == 6)
                {
                    Count = 3;
                    Modified_Tick = tbComplainTicketNo.Text;
                    dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                    0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                    "", 0, 0, 0, 0, 0);
                }


                DataGridCount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    lblTotalCount.Text = Convert.ToString(dt.Rows.Count);
                    gvActiveCircuits.DataSource = dt;
                    gvActiveCircuits.DataBind();
                    //GridViewRowInfo lastRow1 = RadGrid1.Rows[RadGrid1.Rows.Count - 1];
                    //lastRow1.IsSelected = true;

                    //foreach (GridViewRow row in GridView1.Rows)
                    //{

                    //    //string abc = row.Cells[3].Text;
                    //    if (row.Cells[5].Text == "Solved")
                    //    {

                    //    }
                    //}
                }
                else
                {
                    lblTotalCount.Text = "0";
                    gvActiveCircuits.DataSource = null;
                    //RadGrid1.Rows.clear();
                }
            }
            //------------
            if (click == "Complain Closure")
            {
                try
                {
                    int Count = 0;
                    string Modified_Tick = string.Empty;
                    if (TicketTypeID != 6 & TicketTypeID != 0)
                    {
                        string[] str = tbComplainTicketNo.Text.Split('-');
                        Modified_Tick = "0" + "-" + "1" + "-" + "2";
                        Count = 4;
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 1, 0, 0, "",
                        0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                        "", 0, 0, 0, 0, 0);

                    }
                    else if (TicketTypeID == 6)
                    {
                        Modified_Tick = tbComplainTicketNo.Text;
                        Count = 3;
                        dt = objBSS.SearchComplainCircuits(Modified_Tick, 0, "", "", "", "", 0, 0, 0, "",
                        0, 0, 0, 0, Convert.ToDateTime("1/1/1900"), Convert.ToDateTime("1/1/1900"), 0, 0, 0, Count,
                        "", 0, 0, 0, 0, 0);
                    }

                    DataGridCount = dt.Rows.Count;
                    if (dt.Rows.Count > 0)
                    {
                        //lblComplainCount.Text = Convert.ToString(dt.Rows.Count);
                        gvActiveCircuits.DataSource = dt;
                    }
                    else
                    {
                        //  lblCount.Text = "0";
                        gvActiveCircuits.DataSource = null;

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }

        public bool CheckCustomerSelect()
        {
            bool @bool = false;

            try
            {
                foreach (GridDataItem item in gvActiveCircuits.Items)
                {
                    var cb = (CheckBox)item.FindControl("cb_Select");
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

        protected void btUpdateComplain_Click(object sender, EventArgs e)
        {
            if (click == "Complain Closure")
            {
                CheckCustomerSelect();


                if (rbCustomerFeedback.SelectedValue == "Positive")
                {
                    AssginedDepart = 8;
                    ComplainStatusID = 5;
                }
                else if (rbCustomerFeedback.SelectedValue == "Negative" && rbFurtherAction.SelectedValue == "New Complaint Logged")
                {
                    AssginedDepart = 8;
                    ComplainStatusID = 5;
                }
                else if (rbCustomerFeedback.SelectedValue == "Negative" & rbFurtherAction.SelectedValue == "Re-Initiated")
                {
                    AssginedDepart = Convert.ToInt32(cmbAssignedtoDepartment.SelectedValue);
                    ComplainStatusID = 4;
                }

                if (gvActiveCircuits.Items.Count > 0)
                {
                    foreach (GridDataItem item in gvActiveCircuits.Items)
                    {
                        int ComplainIDGridView = 0;
                        CheckBox CheckBox1 = item.FindControl("cb_Select") as CheckBox;
                        if (CheckBox1 != null && CheckBox1.Checked)
                        {
                            //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                            ComplainIDGridView = Convert.ToInt32(item["ComplaintID"].Text);
                            if (UpdateComplainDetails(ComplainIDGridView))
                            {
                                CircuitCount = CircuitCount + 1;
                            }
                            else
                            {
                                FailedCount = FailedCount + 1;
                            }
                            //    }
                            //}
                            CheckCustomerSelect();


                            if (CircuitCount > 0)
                            {
                                loadGridView(click);

                                lblTotalCount.Text = "Total Count : " + Convert.ToString(SelectCount);
                                lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                                lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);

                                lblTotalCount.Visible = true;
                                lblstatus.Visible = true;
                                lblSucessCount.Visible = true;
                                lblFailedCount.Visible = true;
                                //this.Close();
                                lblstatus.Text = "Record Save Sucessfully";
                                if (DataGridCount == 0)
                                {
                                    //this.Close();
                                }
                            }
                            else
                            {
                                lblstatus.Text = "None of any Complain Updated please try Again";
                                lblstatus.Visible = true;
                            }
                        }

                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                            lblstatus.Visible = true;
                        }
                    }
                }

                else
                {
                    lblstatus.Text = "There is no Circuits in Grid view";
                    lblstatus.Visible = true;
                }



            }

            if (click == "Solving")
            {
                //CheckCustomerSelect();
                //UpdateComplainDetails(Convert.ToInt32(Session["ComplainID"]));
                if (gvActiveCircuits.Items.Count > 0)
                {
                    foreach (GridDataItem item in gvActiveCircuits.Items)
                    {
                        int ComplainIDGridView = 0;
                        int SignUpGridView = 0;
                        CheckBox CheckBox1 = item.FindControl("cb_Select") as CheckBox;
                        if (CheckBox1 != null && CheckBox1.Checked)
                        {
                            //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                            ComplainIDGridView = Convert.ToInt32(item["ComplaintID"].Text);
                            SignUpGridView = Convert.ToInt32(item["SignUpId"].Text);

                            if (UpdateComplainDetails(ComplainIDGridView))
                            {
                                if ( (TicketTypeID.Equals(6)) & Convert.ToInt32(Session["DepartmentID"]).Equals(1) || Convert.ToInt32(Session["DepartmentID"]).Equals(58) || Convert.ToInt32(Session["DepartmentID"]).Equals(59) || Convert.ToInt32(Session["DepartmentID"]).Equals(60))
                                {
                                    UpdateFiberDetails(SignUpGridView);
                                }
                                
                                CircuitCount = CircuitCount + 1;
                            }
                            else
                            {
                                FailedCount = FailedCount + 1;
                            }
                            //    }
                            //}
                            CheckCustomerSelect();


                            if (CircuitCount > 0)
                            {                              



                                loadGridView(click);

                                lblTotalCount.Text = "Total Count : " + Convert.ToString(SelectCount);
                                lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                                lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);

                                lblTotalCount.Visible = true;
                                lblstatus.Visible = true;
                                lblSucessCount.Visible = true;
                                lblFailedCount.Visible = true;
                                //this.Close();
                                lblstatus.Text = "Record Save Sucessfully";
                                if (DataGridCount == 0)
                                {
                                    //this.Close();
                                }
                            }
                            else
                            {
                                lblstatus.Text = "None of any Complain Updated please try Again";
                                lblstatus.Visible = true;
                            }
                        }

                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                            lblstatus.Visible = true;
                        }
                    }
                }

                else
                {
                    lblstatus.Text = "There is no Circuits in Grid view";
                    lblstatus.Visible = true;
                }

            }


            if (click == "Follow Up")
            {
                if (Convert.ToInt32(cmbCaseCategory1.SelectedValue) == 0 | Convert.ToInt32(cmbCaseCategory0.SelectedValue) == 0)
                {
                    lblstatus.Text = "Please Select all validate fields";
                    lblstatus.Visible = true;

                }

                if (tbLoggedBy0.Text == string.Empty)
                {
                    lblstatus.Text = "Please Select all validate fields";
                    lblstatus.Visible = true;
                }

                if (Convert.ToInt32(Session["DeptID"]) == 3)
                {
                    if (RadioRequestTypeNE.Items[0].Selected == true)
                    {
                        Session["1"] = 1;
                    }


                    if (RadioRequestTypeNE.Items[0].Selected == false & RadioRequestTypeNE.Items[1].Selected == false)
                    {
                        lblstatus.Text = "Please Select Request Type before Forwading complain";
                        lblstatus.Visible = true;
                    }

                }


                if (gvActiveCircuits.Items.Count > 0)
                {
                    //RadGrid1  lastRow1 = RadGrid1.Items[RadGrid1.Items.Count - 1];
                    //foreach (DataGridViewRow row in RadGrid1.Items)
                    //{
                    //    DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells(0);

                    //    if (cb.EditedFormattedValue == true)
                    //    {

                    foreach (GridDataItem item in gvActiveCircuits.Items)
                    {
                        int ComplainIDGridView = 0;
                        CheckBox CheckBox1 = item.FindControl("cb_Select") as CheckBox;
                        if (CheckBox1 != null && CheckBox1.Checked)
                        {
                            //string strKey = item.GetDataKeyValue("ComplaintID").ToString();
                            ComplainIDGridView = Convert.ToInt32(item["ComplaintID"].Text);
                            if (UpdateComplainDetails(ComplainIDGridView))
                            {
                                CircuitCount = CircuitCount + 1;
                            }
                            else
                            {
                                FailedCount = FailedCount + 1;
                            }
                            //    }
                            //}
                            CheckCustomerSelect();


                            if (CircuitCount > 0)
                            {
                                loadGridView(click);

                                lblTotalCount.Text = "Total Count : " + Convert.ToString(SelectCount);
                                lblSucessCount.Text = "Solve Count : " + Convert.ToString(CircuitCount);
                                lblFailedCount.Text = "Failed Count: " + Convert.ToString(FailedCount);

                                lblTotalCount.Visible = true;
                                lblstatus.Visible = true;
                                lblSucessCount.Visible = true;
                                lblFailedCount.Visible = true;
                                //this.Close();
                                lblstatus.Text = "Record Save Sucessfully";
                                if (DataGridCount == 0)
                                {
                                    //this.Close();
                                }
                            }
                            else
                            {
                                lblstatus.Text = "None of any Complain Updated please try Again";
                                lblstatus.Visible = true;
                            }
                        }

                        else
                        {
                            lblstatus.Text = "None of any Complain Updated please select the complain from the grid";
                            lblstatus.Visible = true;
                        }



                    }





                }
                else
                {
                    lblstatus.Text = "There is no Circuits in Grid view";
                    lblstatus.Visible = true;
                }

            }
        }

        public bool UpdateComplainDetails(int CompID)
        {
            if (click == "Complain Closure")
            {
                try
                {
                    int ComplainID = CompID;
                    string TicketNo = tbComplainTicketNo.Text;
                    int ComplaintStatusID = ComplainStatusID;
                    int AssignedByDeptID = DeptID;
                    int AssignedToDeptID = AssginedDepart;
                    string AssignedToPersonName = lblEngineerName.Text;
                    string AssignedByPersonName = lblEngineerName.Text;
                    DateTime LastUpdatedDate = DateTime.Now;
                    DateTime ETA = DateTime.Now;
                    string PersonGivenETA = "";
                    DateTime ETTR = DateTime.Now;
                    string PersonSolving = "";
                    DateTime ComplainSolvingDate = DateTime.Now;
                    string FCR = "";
                    int ProblemDignoseEndID = 5;
                    int ReasonOutageID = 187;
                    string Dignose_Causes = "";
                    string Dignose_RootCauseAnalysis = "";
                    string Dignose_PreventativeMeasureTake = "";
                    string LastMileInfraID = "29";
                    string CustomerFeedBack = rbCustomerFeedback.SelectedValue;
                    string FurtherAction = rbFurtherAction.SelectedValue;

                    string NewComplainRef = tbNewComplaintReference.Text;
                    string QueryResponses = "";

                    string strWithTabsQR = tbRemarks.Text;
                    string lineQR = strWithTabsQR.Replace("\t", " ");
                    tbRemarks.Text = lineQR.Replace("\r\n", " ");
                   

                    string Remarks = tbRemarks.Text;
                    int TransactionBy = UserID;

                    if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                    ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                    CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "","","",1,0 ,TransactionBy))
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //---------------------
            if (click == "Solving")
            {

                try
                {
                    int ComplainID = CompID;
                    string TicketNo = tbComplainTicketNo.Text;
                    int ComplaintStatusID = Convert.ToInt32(cmbComplainStatus.SelectedValue);
                    int AssignedByDeptID = DeptID;
                    int AssignedToDeptID = 61;
                    string AssignedToPersonName = tbPersonSolvingComplain.Text;
                    string AssignedByPersonName = tbPersonSolvingComplain.Text;
                    //DateTime LastUpdatedDate = AppDomain.CurrentDomain.GetData("LastUpdatedDate");
                    DateTime LastUpdatedDate = DateTime.Now;
                    DateTime ETA = Convert.ToDateTime("1/1/1990");
                    string PersonGivenETA = "";
                    DateTime ETTR = Convert.ToDateTime("1/1/1990");
                    string PersonSolving = "";
                    //DateTime ComplainSolvingDate = dtComplainSolving.Value;
                    DateTime ComplainSolvingDate = dtSolving.SelectedDate.Value;
                    //string FCR = (rdFCR_Yes.Checked == true ? "Yes" : "No");
                    string FCR = rbFCR.SelectedIndex.ToString();
                    int ProblemDignoseEndID = Convert.ToInt32(cmbProblemDiagnosedat.SelectedValue);
                    int ReasonOutageID = Convert.ToInt32(cmbReasonofOutage.SelectedValue);
                    string Dignose_Causes = tbCauses.Text;
                    string Dignose_RootCauseAnalysis = tbRootCauseAnalysis.Text;
                    string Dignose_PreventativeMeasureTake = tbPreventiveMeasures.Text;
                    string LastMileInfraID = cmbLastMileInfra.SelectedValue;
                    string CustomerFeedBack = "";
                    string FurtherAction = "";
                    string NewComplainRef = "";
                    string QueryResponses = "";

                    string strWithTabsQR = tbRemarksSolving.Text;
                    string lineQR = strWithTabsQR.Replace("\t", " ");
                    tbRemarksSolving.Text = lineQR.Replace("\r\n", " ");

                    string Remarks = tbRemarksSolving.Text;
                    int TransactionBy = UserID;

                    //if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                    //ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, LastMileInfraID,

                    //CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "", TransactionBy))
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;

                    //}

                    //objBSS.UpdateComplain(ComplainID,TicketNo,ComplainStatusID,ass
                    //    .UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                    //ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, LastMileInfraID,

                    //CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "", TransactionBy));

                    objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                                          ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),
                                          CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, "", "","",1,0, TransactionBy);
                    


                    return true;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (click == "Follow Up")
            {
                try
                {
                    int ComplainID = CompID;
                    string TicketNo = tbComplainTicketNo.Text;
                    int ComplaintStatusID = Convert.ToInt32(cmbCaseCategory0.SelectedValue);
                    int AssignedByDeptID = DeptID;
                    int AssignedToDeptID = Convert.ToInt32(cmbCaseCategory1.SelectedValue);
                    string AssignedToPersonName = tbLoggedBy0.Text;
                    string AssignedByPersonName = tbLoggedBy0.Text;
                    DateTime LastUpdatedDate = Convert.ToDateTime(AppDomain.CurrentDomain.GetData("LastUpdatedDate"));
                    DateTime ETA = Convert.ToDateTime(RadDateTimePicker1.SelectedDate);
                    string PersonGivenETA = tbLoggedBy0.Text;
                    DateTime ETTR = Convert.ToDateTime(RadDateTimePicker3.SelectedDate);
                    string PersonSolving = "";
                    DateTime ComplainSolvingDate = Convert.ToDateTime("1/1/1990");
                    string FCR = "";
                    int ProblemDignoseEndID = 5;
                    int ReasonOutageID = 187;
                    string Dignose_Causes = "";
                    string Dignose_RootCauseAnalysis = "";
                    string Dignose_PreventativeMeasureTake = "";
                    string LastMileInfraID = "29";
                    string CustomerFeedBack = "";
                    string FurtherAction = "";
                    string NewComplainRef = "";

                    string strWithTabsQR = tbIPResponses.Text;
                    string lineQR = strWithTabsQR.Replace("\t", " ");
                    tbIPResponses.Text = lineQR.Replace("\r\n", " ");
                    
                    string QueryResponses = tbIPResponses.Text;

                    string strWithTabs = tbLoggedBy3.Text;
                    string line = strWithTabsQR.Replace("\t", " ");
                    tbLoggedBy3.Text = line.Replace("\r\n", " ");

                    string Remarks = tbLoggedBy3.Text;

                    if (RadioRequestTypeNE.Items[0].Selected == true)
                    {
                        RequestTypeAtNE = "Support Request";
                    }
                    else if (RadioRequestTypeNE.Items[1].Selected == true)
                    {
                        RequestTypeAtNE = "Service Request";
                    }
                    else if (RadioRequestTypeNE.Items[0].Selected == false & RadioRequestTypeNE.Items[1].Selected == false)
                    {
                        RequestTypeAtNE = "";
                    }

                    int TransactionBy = Convert.ToInt32(Session["UserID"]);

                    /*if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                    ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                    CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, "" ,"",1,0, TransactionBy))*/

                    if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                   ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                   CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, ViewState["Pic1"].ToString(), ViewState["Pic2"].ToString(), Convert.ToInt32(cmbTeam.SelectedValue) , Convert.ToInt32(cmbPriority.SelectedValue) , TransactionBy))

                   //     if (objBSS.UpdateComplain(ComplainID, TicketNo, ComplaintStatusID, AssignedByDeptID, AssignedToDeptID, AssignedToPersonName, AssignedByPersonName, LastUpdatedDate, ETA, PersonGivenETA,
                   //ETTR, PersonSolving, ComplainSolvingDate, FCR, ProblemDignoseEndID, ReasonOutageID, Dignose_Causes, Dignose_RootCauseAnalysis, Dignose_PreventativeMeasureTake, Convert.ToInt32(LastMileInfraID),

                   //CustomerFeedBack, FurtherAction, NewComplainRef, QueryResponses, Remarks, RequestTypeAtNE, ViewState["Pic1"].ToString(), ViewState["Pic2"].ToString(), Convert.ToInt32(ViewState["TeamID"]), Convert.ToInt32(ViewState["PriorityID"]), TransactionBy))

                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return true;
        }

        public void UpdateFiberDetails(int SignUpID)
        {
            try
            {
                //objBSS.UpdateFiberDetails(SignUpID, txtJoinName.Text, txtTubeNameFromCustomer.Text, txtCoreColorFromCustomer.Text, txtTubeNameFromNode.Text, txtTubeNameFromNode.Text,txtCutDistance.Text,UserID);
                //objBSS.UpdateFiberDetails(
                //if (objBSS.UpdateFiberDetails
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void cmbCaseCategory0_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbCaseCategory0.SelectedValue) == 6)
                {
                    //cmbAssignedDepartment.SelectedValue = "15";
                    //cmbAssignedDepartment.Enabled = false;

                    cmbCaseCategory1.SelectedValue = "15";
                    cmbCaseCategory1.Enabled = false;

                }
                else if (Convert.ToInt32(cmbCaseCategory0.SelectedValue) == 4)
                {
                    //
                    cmbCaseCategory1.SelectedValue = AssignmentDeptID.ToString();
                    cmbCaseCategory1.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public string GetPanelValue(Panel pnl)
        {
            try
            {
                string val = string.Empty;
                dynamic rd = pnl.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                if (rd == null)
                {
                    val = string.Empty;
                }
                else
                {
                    val = rd.Text;
                }
                return val;

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

        protected void cmbTeam_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["TeamID"] = cmbTeam.SelectedValue;
        }
        protected void cmbPriority_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["PriorityID"] = cmbPriority.SelectedValue;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] Attachment = new string[2];
            Attachment[0] = "";
            Attachment[1] = "";
            int count = 1;
            if (RadAsyncUpload1.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                {
                    //String targetFolder = Server.MapPath("~/Folder/");
                    String targetFolder = Server.MapPath("~/Resorces/");
                    
                    //file.SaveAs(targetFolder);

                    if (count == 1)
                    {
                        file.SaveAs(Path.Combine(targetFolder, tbComplainTicketNo.Text + "-P1.JPG"));
                        Attachment[0] = tbComplainTicketNo.Text + "-P1.JPG";
                        ViewState["Pic1"] = Attachment[0];
                    }
                    else
                    {
                        file.SaveAs(Path.Combine(targetFolder, tbComplainTicketNo.Text + "-P2.JPG"));
                        Attachment[1] = tbComplainTicketNo.Text + "-P2.JPG";
                        ViewState["Pic2"] = Attachment[1];
                    }
                    count = count + 1;
                    //
                }
            }
            else
            {
                Attachment[0] = "";
                Attachment[1] = "";
            }
        }


        protected void ShowPic2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbComplainTicketNo.Text))
            {
            }
            else
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=\" " + tbComplainTicketNo.Text + "-P2.JPG");
                Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Resorces/" + tbComplainTicketNo.Text + "-P2.JPG"));
                Response.End();
            }
        }

        protected void ShowPic_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbComplainTicketNo.Text))
            {
            }
            else
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=\" " + tbComplainTicketNo.Text + "-P1.JPG");
                Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Resorces/" + tbComplainTicketNo.Text + "-P1.JPG"));
                Response.End();
            }

        }



        protected void btnviewFiberHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ViewFiberDetails.aspx?SignupID=" + Convert.ToInt32(Session["SignupID"]));
            //btnViewHistoryFiberDetails.Attributes.Add("onclick", "window.open('/ViewFiberDetails.aspx?SignupID=' + '" + Convert.ToInt32(Session["SignupID"]) + "');return true;");
            //btnViewHistoryFiberDetails.Attributes.Add("onclick", "popWin();return false;"); 
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ComplainManager.aspx");
        }
    }
}