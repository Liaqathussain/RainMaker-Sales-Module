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

namespace RainMaker.BSS_Administration
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        clsCreateAccount objClsAccount = new clsCreateAccount();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dtGridViewActivity = obj_TerrQut.GetActivity();
            //GVActivity.DataSource = dtGridViewActivity;
            //GVActivity.DataBind();

            if (!IsPostBack)
            {
                GetDomain();
                BindData();

            }

        }



        private void BindData()
        {
            DataTable dt_GetAccount = objClsAccount.GetAccountByCustomerCode(0, "", 1);
            GVAccount.DataSource = dt_GetAccount;
            GVAccount.DataBind();
        }

        protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string Attachment;
            if (e.Item.Text == "Save")
            {
                Attachment = "";
                if (RadAttachment.UploadedFiles.Count > 0)
                {
                    foreach (UploadedFile file in RadAttachment.UploadedFiles)
                    {
                        string targetFolder = Server.MapPath("~/Folder/");
                        file.SaveAs(Path.Combine(targetFolder, "test" + "-" + file.FileName));
                        //file.SaveAs(Path.Combine("test" + "-" + file.FileName));
                        //Me.WriteToFile("btnSubmit: " & targetFolder & TicketNo & "-" & file.FileName)
                        Attachment = DateTime.Now.ToShortDateString() + "-" + file.FileName;
                    }
                }
                else
                {
                    Attachment = "";
                }

                Save(Attachment);
            }

            if (e.Item.Text == "Update")
            {
                Attachment = "";
                if (RadAttachment.UploadedFiles.Count > 0)
                {
                    foreach (UploadedFile file in RadAttachment.UploadedFiles)
                    {
                        string targetFolder = Server.MapPath("~/Folder/");
                        file.SaveAs(Path.Combine(targetFolder, "test" + "-" + file.FileName));
                        //file.SaveAs(Path.Combine("test" + "-" + file.FileName));
                        //Me.WriteToFile("btnSubmit: " & targetFolder & TicketNo & "-" & file.FileName)
                        Attachment = DateTime.Now.ToShortDateString() + "-" + file.FileName;
                    }
                }
                else
                {
                    Attachment = "";
                }
                Update(Attachment);
            }

        }

        private void GetDomain()
        {
            DataTable dt_GetDomain = obj_clsGeneralFunction.GetDomain();
            cmbDomain.DataSource = dt_GetDomain;
            cmbDomain.DataTextField = "Domain";
            cmbDomain.DataValueField = "DomainID";
            cmbDomain.DataBind();
            cmbDomain.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

        }


        protected void GVAccount_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVAccount.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                ViewState["CustomerCode"] = item["CustomerCode"].Text;
                txtCustomerName.Text = item["Customer"].Text;
                txtPhoneNo.Text = item["Phone"].Text;
                //txtEmailAddress.DataTextField = item["Customer"].Text;
                txtEmailAddress.Text = item["EmailAddress"].Text;
                txtCountry.Text = item["Country"].Text;
                txtState.Text = item["State"].Text;
                txtCity.Text = item["City"].Text;
                cmbDomain.SelectedValue = item["Domain"].Text;
                cmbAccountType.SelectedValue = item["CustomerType"].Text;
                txtRemarks.Text = item["Remarks"].Text;
                txtAsyncUpload.Text = item["Logo"].Text;
                string IsActive = item["IsActive"].Text;

                if (IsActive.Equals("Yes"))
                {
                    chk_IsActive.Checked = true;
                }

                else
                {
                    chk_IsActive.Checked = false;
                }
            }
        }

        protected void GVAccount_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }


        private void Save(string AttachmentLogo)
        {
            int IsActive = 0;
            if (chk_IsActive.Checked)
            {
                IsActive = 1;
            }
            else
            {
                IsActive = 0;
            }
            //object obj_custID = objClsAccount.CreateAccount(txtCustomerName.Text, ViewState["FileName"].ToString(), txtCountry.Text, txtState.Text, txtCity.Text, txtEmailAddress.Text, txtPhoneNo.Text, txtRemarks.Text, IsActive, 1, cmbAccountType.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString());
            object obj_custID = objClsAccount.CreateAccount(txtCustomerName.Text, AttachmentLogo, txtCountry.Text, txtState.Text, txtCity.Text, txtEmailAddress.Text, txtPhoneNo.Text, txtRemarks.Text, IsActive, 1, cmbAccountType.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString());
            //DateTime sysdate = default(DateTime);
            DateTime sysdate = DateTime.Now;
            objClsAccount.CreateTransactionLog(Convert.ToInt32(obj_custID), "Account Screen", 1, "Done", 1, sysdate);
        }

        private void Update(string AttachmentUpdate)
        {
            objClsAccount.UpdateAccount(Convert.ToInt32(ViewState["CustomerCode"]), txtCustomerName.Text, AttachmentUpdate, txtCountry.Text, txtState.Text, txtCity.Text, txtEmailAddress.Text, txtPhoneNo.Text, txtRemarks.Text, 1, 1, cmbAccountType.SelectedValue, cmbDomain.SelectedValue);

        }


        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            string CustomerName = txtCustomerNameS.Text;
            DataTable dt_GetAccountByCustomer = objClsAccount.GetAccountByCustomerCode(0, CustomerName, 1);
            GVAccount.DataSource = dt_GetAccountByCustomer;
            GVAccount.DataBind();
        }
    }
}