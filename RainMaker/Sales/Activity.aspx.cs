using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;
using System.IO;

namespace RainMaker
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Cls_Territory obj_TerrQut = new Cls_Territory();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        string TranuserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Customer Code 
                DataTable dt = objBSS.GetCustomerIdentification();
                cmbCustomerCode.DataSource = dt;
                cmbCustomerCode.DataTextField = "Customer";
                cmbCustomerCode.DataValueField = "CustomerCode";
                cmbCustomerCode.DataBind();
                cmbCustomerCode.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Activity Type
                DataTable dtActType = objBSS.GetActivityType();
                cmbActivityType.DataSource = dtActType;
                cmbActivityType.DataTextField = "ActivityName";
                cmbActivityType.DataValueField = "ActivityTypeID";
                cmbActivityType.DataBind();
                cmbActivityType.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Activity Status
                DataTable dtActivityStatus = objBSS.GetActivityStatus();
                cmbActivityStatus.DataSource = dtActivityStatus;
                cmbActivityStatus.DataTextField = "ActivityStatus";
                cmbActivityStatus.DataValueField = "ActivityStatusID";
                cmbActivityStatus.DataBind();
                cmbActivityStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Activity Status
                DataTable dtcloserRemarks = objBSS.GetCloserRemarks();
                RadCloserRemarks.DataSource = dtcloserRemarks;
                RadCloserRemarks.DataTextField = "ClosureRemarks";
                RadCloserRemarks.DataValueField = "CloserRID";
                RadCloserRemarks.DataBind();
                RadCloserRemarks.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));


                //Grid view 

                GetActivityData();

                cmbActivityOwner.Text = Session["Name"].ToString();
            }


        }

        public void GetActivityData()
        {
            DataTable dtGridViewActivity;

            dtGridViewActivity = objBSS.GetActivitySales(Session["UserID"].ToString());

            if (dtGridViewActivity.Rows.Count > 0)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.AddRange(new DataColumn[] 
                    {
		                new DataColumn("Subject"),
		                new DataColumn("Customer"),
                        new DataColumn("RefID"),
                        new DataColumn("POC"),
                        new DataColumn("POCName"),
                        new DataColumn("Address"),
                        new DataColumn("OppName"),
                        new DataColumn("SubRefID"),
                        new DataColumn("ActivityName"),
                        new DataColumn("ActivityTypeID"),
                        new DataColumn("Date"),
                        new DataColumn("Time"),
                        new DataColumn("ActivityStatus"),
                        new DataColumn("ActivityStatusID"),
                        new DataColumn("ActivityOwner"),
                        new DataColumn("ActivityOwnerID"),
                         new DataColumn("ClosureRemarks"),
                        new DataColumn("ClosureRemarksID"),
                        new DataColumn("Attachment"),
                        new DataColumn("Remarks"),
                         new DataColumn("ActivityID"),
                         new DataColumn("TransactionBy")
	                });
                for (int i = 0; i <= dtGridViewActivity.Rows.Count - 1; i++)
                {
                    dt1.Rows.Add(dtGridViewActivity.Rows[i]["Subject"].ToString(),
                    dtGridViewActivity.Rows[i]["Customer"].ToString(),
                    dtGridViewActivity.Rows[i]["RefID"].ToString(),
                    dtGridViewActivity.Rows[i]["POC"].ToString(),
                    dtGridViewActivity.Rows[i]["POCName"].ToString(),
                    dtGridViewActivity.Rows[i]["Address"].ToString(),
                    dtGridViewActivity.Rows[i]["OppName"].ToString(),
                    dtGridViewActivity.Rows[i]["SubRefID"].ToString(),
                    dtGridViewActivity.Rows[i]["ActivityName"].ToString(),
                    dtGridViewActivity.Rows[i]["ActivityTypeID"].ToString(),
                    dtGridViewActivity.Rows[i]["Date"].ToString(),
                    dtGridViewActivity.Rows[i]["Time"].ToString(),
                    dtGridViewActivity.Rows[i]["ActivityStatus"].ToString(),
                    dtGridViewActivity.Rows[i]["ActivityStatusID"].ToString(),
                     dtGridViewActivity.Rows[i]["ActivityOwner"].ToString(),
                    dtGridViewActivity.Rows[i]["ActivityOwnerID"].ToString(),
                     dtGridViewActivity.Rows[i]["ClosureRemarks"].ToString(),
                    dtGridViewActivity.Rows[i]["ClosureRemarksID"].ToString(),
                    dtGridViewActivity.Rows[i]["Attachment"].ToString(),
                     dtGridViewActivity.Rows[i]["Remarks"].ToString(),
                     dtGridViewActivity.Rows[i]["ActivityID"].ToString(),
                      dtGridViewActivity.Rows[i]["TransactionBy"].ToString()
                    );
                }
                GVActivity.DataSource = dt1;
                GVActivity.DataBind();
                GVActivity.MasterTableView.GetColumn("RefID").Visible = false;
                GVActivity.MasterTableView.GetColumn("POC").Visible = false;
                GVActivity.MasterTableView.GetColumn("Address").Visible = false;
                GVActivity.MasterTableView.GetColumn("SubRefID").Visible = false;
                GVActivity.MasterTableView.GetColumn("ActivityTypeID").Visible = false;
                GVActivity.MasterTableView.GetColumn("Time").Visible = false;
                GVActivity.MasterTableView.GetColumn("ActivityStatusID").Visible = false;
                GVActivity.MasterTableView.GetColumn("ActivityOwner").Visible = false;
                GVActivity.MasterTableView.GetColumn("ActivityOwnerID").Visible = false;
                GVActivity.MasterTableView.GetColumn("ClosureRemarksID").Visible = false;
                GVActivity.MasterTableView.GetColumn("Attachment").Visible = false;
                GVActivity.MasterTableView.GetColumn("Remarks").Visible = false;
                GVActivity.MasterTableView.GetColumn("ActivityID").Visible = false;
            }
        }

        protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if (e.Item.Text == "Save")
            {
                string Attachment;
                Attachment = "";
                if (RadAttachment.UploadedFiles.Count > 0)
                {
                    foreach (UploadedFile file in RadAttachment.UploadedFiles)
                    {
                        string targetFolder = Server.MapPath("~/Folder/");
                        file.SaveAs(Path.Combine(targetFolder, "test" + "-" + file.FileName));
                        //Me.WriteToFile("btnSubmit: " & targetFolder & TicketNo & "-" & file.FileName)
                        Attachment = DateTime.Now.ToShortDateString() + "-" + file.FileName;
                    }
                }
                else
                {
                    Attachment = "";
                }
                if (cmbActivityType.Text == "Visit" && cmbCustomerCode.Text != "Please Select" && cmbOpportunity.Text != "Please Select")
                {
                    
                    if (cmbActivityStatus.Text == "Initiated")
                    {
                        TranuserID = Session["UserID"].ToString();
                    }
                    else
                    {
                        TranuserID = Session["TransByID"].ToString();
                    }

                    object obj_nrfid = objBSS.InsertActivitySales(txtSubject.Text, cmbCustomerCode.SelectedValue.ToString(), "Account", txtAddress.Text, cmbContact.SelectedValue.ToString(), cmbOpportunity.SelectedValue.ToString(), "Opportunity", DTActivityDate.SelectedDate.ToString(), txtActivityTime.SelectedDate.ToString(), cmbActivityType.SelectedValue.ToString(), cmbActivityStatus.SelectedValue.ToString(), TranuserID, txtRemarks.Text, RadCloserRemarks.SelectedValue.ToString(), Attachment, "1", Session["UserID"].ToString(), DateTime.Now.ToString());
                    //Grid view 
                    GetActivityData();
                }
                if (cmbActivityType.Text != "Visit" && cmbCustomerCode.Text != "Please Select" && cmbOpportunity.Text == "Please Select")
                {
                    object obj_nrfid = objBSS.InsertActivitySales(txtSubject.Text, cmbCustomerCode.SelectedValue.ToString(), "Account", txtAddress.Text, cmbContact.SelectedValue.ToString(), "0", "0", DTActivityDate.SelectedDate.ToString(), txtActivityTime.SelectedDate.ToString(), cmbActivityType.SelectedValue.ToString(), cmbActivityStatus.SelectedValue.ToString(), TranuserID, txtRemarks.Text, RadCloserRemarks.SelectedValue.ToString(), Attachment, "1", Session["UserID"].ToString(), DateTime.Now.ToString());
                    //Grid view 
                    GetActivityData();
                }
                if (cmbActivityType.Text != "Visit" && cmbCustomerCode.Text == "Please Select" && cmbOpportunity.Text == "Please Select")
                {
                    object obj_nrfid = objBSS.InsertActivitySales(txtSubject.Text, "0", cmbActivityType.Text, txtAddress.Text, "0", "0", "0", DTActivityDate.SelectedDate.ToString(), txtActivityTime.SelectedDate.ToString(), cmbActivityType.SelectedValue.ToString(), cmbActivityStatus.SelectedValue.ToString(), TranuserID, txtRemarks.Text, RadCloserRemarks.SelectedValue.ToString(), Attachment, "1", Session["UserID"].ToString(), DateTime.Now.ToString());
                    //Grid view 
                    GetActivityData();
                }

            }
            if (e.Item.Text == "Update")
            {
                //object obj_nrfid = objBSS.UpdateActivity(ViewState["ActivityID"].ToString(), txtSubject.Text, cmbCustomerCode.SelectedValue.ToString(), "Account", txtAddress.Text, cmbContact.SelectedValue.ToString(), cmbOpportunity.SelectedValue.ToString(), "Opportunity", DTActivityDate.SelectedDate.ToString(), txtActivityTime.SelectedDate.ToString(), cmbActivityType.SelectedValue.ToString(), cmbActivityStatus.SelectedValue.ToString(), Session["TransByID"].ToString(), txtRemarks.Text, RadCloserRemarks.SelectedValue.ToString());
                object obj_nrfid = objBSS.UpdateActivitySales(ViewState["ActivityID"].ToString(), txtSubject.Text, cmbCustomerCode.SelectedValue.ToString(), "Account", txtAddress.Text, cmbContact.SelectedValue.ToString(), cmbOpportunity.SelectedValue.ToString(), "Opportunity", DTActivityDate.SelectedDate.ToString(), txtActivityTime.SelectedDate.ToString(), cmbActivityType.SelectedValue.ToString(), cmbActivityStatus.SelectedValue.ToString(), Session["TransByID"].ToString(), txtRemarks.Text, RadCloserRemarks.SelectedValue.ToString());
                //Grid view 
                GetActivityData();
            }
        }

        protected void cmbCustomerCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string RefID = cmbCustomerCode.SelectedValue.ToString();
            //Customer Contact
            DataTable dtCustomerContact = objBSS.GetCustomerContact(RefID);
            if (dtCustomerContact.Rows.Count > 0)
            {
                cmbContact.DataSource = dtCustomerContact;
                cmbContact.DataTextField = "FullName";
                cmbContact.DataValueField = "ContactID";
                cmbContact.DataBind();
                cmbContact.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Opportunity Name
                DataTable dtOpportunity = objBSS.GetOpportunity(RefID);
                cmbOpportunity.DataSource = dtOpportunity;
                cmbOpportunity.DataTextField = "OppName";
                cmbOpportunity.DataValueField = "OppID";
                cmbOpportunity.DataBind();
                cmbOpportunity.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
            else
            {
                cmbContact.Items.Clear();
                cmbContact.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                cmbOpportunity.Items.Clear();
                cmbOpportunity.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }

        }

        protected void GVActivity_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void GVActivity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GVActivity_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void GVActivity_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVActivity.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                txtSubject.Text = item["Subject"].Text;
                txtAddress.Text = item["Address"].Text;
                cmbCustomerCode.DataTextField = item["Customer"].Text;
                cmbCustomerCode.SelectedValue = item["RefID"].Text;

                DataTable dtCustomerContact = objBSS.GetCustomerContact(cmbCustomerCode.SelectedValue);
                if (dtCustomerContact.Rows.Count > 0)
                {
                    cmbContact.DataSource = dtCustomerContact;
                    cmbContact.DataTextField = "FullName";
                    cmbContact.DataValueField = "ContactID";
                    cmbContact.DataBind();
                    cmbContact.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                    //Opportunity Name
                    DataTable dtOpportunity = objBSS.GetOpportunity(cmbCustomerCode.SelectedValue);
                    cmbOpportunity.DataSource = dtOpportunity;
                    cmbOpportunity.DataTextField = "OppName";
                    cmbOpportunity.DataValueField = "OppID";
                    cmbOpportunity.DataBind();
                    cmbOpportunity.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                }

                cmbContact.DataTextField = item["POCName"].Text;
                cmbContact.SelectedValue = item["POC"].Text;

                cmbOpportunity.DataTextField = item["OppName"].Text;
                cmbOpportunity.SelectedValue = item["SubRefID"].Text;

                cmbActivityType.DataTextField = item["ActivityName"].Text;
                cmbActivityType.SelectedValue = item["ActivityTypeID"].Text;

                DTActivityDate.SelectedDate = Convert.ToDateTime(item["Date"].Text);
                txtActivityTime.SelectedDate = Convert.ToDateTime(item["Time"].Text);

                cmbActivityStatus.DataTextField = item["ActivityStatus"].Text;
                cmbActivityStatus.SelectedValue = item["ActivityStatusID"].Text;

                cmbActivityOwner.Text = item["ActivityOwner"].Text;

                RadCloserRemarks.DataTextField = item["ClosureRemarks"].Text;
                RadCloserRemarks.SelectedValue = item["ClosureRemarksID"].Text;

                txtRemarks.Text = item["Remarks"].Text;

                ViewState["ActivityID"] = item["ActivityID"].Text;
                Session["TransByID"] = item["TransactionBy"].Text;

            }
        }

        protected void RadCloserRemarks_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
   
    }
}