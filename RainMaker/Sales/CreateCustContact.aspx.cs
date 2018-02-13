using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        BL objBL = new BL();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        clsCreateContact obj_CreateCont = new clsCreateContact();
        static int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMyCombo();
                UserID = Convert.ToInt32(Session["UserID"]);
            }
        }
        public void LoadMyCombo()
        {
            try
            {
                objBL.loadCities(cmbCity);
                objBL.loadCustomerList(cmbCustCode);
                loadContactType();
                loadContactReligion();
                loadContactTitle();

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Error Message");
            }
        }
        #region "LoadMyCombos"

        private void loadContactType()
        {
            DataTable dt = obj_clsGeneralFunction.GetContactType();
            cmbCustContactType.DataSource = dt;
            cmbCustContactType.DataTextField = "ContactType";
            cmbCustContactType.DataValueField = "ContactTypeID";
            cmbCustContactType.DataBind();
            cmbCustContactType.Items.Insert(0, new RadComboBoxItem("Please-Select", "0"));
            // int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);

        }

        private void loadContactReligion()
        {
            DataTable dt = obj_clsGeneralFunction.GetContactReligion();
            cmbReligion.DataSource = dt;
            cmbReligion.DataTextField = "Religion";
            cmbReligion.DataValueField = "ReligionID";
            cmbReligion.DataBind();
            cmbReligion.Items.Insert(0, new RadComboBoxItem("Please-Select", "0"));
            // int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);

        }

        private void loadContactTitle()
        {
            DataTable dt = obj_clsGeneralFunction.GetContactTitle();
            cmbCusstTitle.DataSource = dt;
            cmbCusstTitle.DataTextField = "Title";
            cmbCusstTitle.DataValueField = "TitleID";
            cmbCusstTitle.DataBind();
            cmbCusstTitle.Items.Insert(0, new RadComboBoxItem("Please-Select", "0"));
            // int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);

        }

        #endregion
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCusContact.Text == "" || txtCustAddress.Text == "" || txtCustEmail.Text == "" || txtCustMobile.Text == "" || txtCustName.Text == "")
                {
                    lblNotification.Text = "Please enter all fields before saving record";
                    lblNotification.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Convert.ToInt32(cmbCity.SelectedValue) == 0 || Convert.ToInt32(cmbCusstTitle.SelectedValue) == 0 || Convert.ToInt32(cmbCustCode.SelectedValue) == 0 || Convert.ToInt32(cmbCustContactType.SelectedValue) == 0 || Convert.ToInt32(cmbReligion.SelectedValue) == 0 || Convert.ToInt32(cmbGender.SelectedValue) == 0)
                {
                    lblNotification.Text = "Please select all drop down value before saving record";
                    lblNotification.ForeColor = System.Drawing.Color.Red;
                    return;
                }



                //object obj_CCID = obj_CreateCont.CreateContact(Convert.ToInt32(cmbCustCode.SelectedValue),
                //Convert.ToInt32(cmbCity.SelectedValue),
                //Convert.ToString(cmbCusstTitle.SelectedItem.Text),
                //txtCustName.Text,
                //txtCusContact.Text,
                //txtCustEmail.Text,
                //txtCustMobile.Text,
                //txtCustAddress.Text,
                //Convert.ToInt32(cmbCustContactType.SelectedValue),
                //Convert.ToString(cmbReligion.SelectedItem.Text),
                //Convert.ToString(cmbGender.SelectedItem.Text),
                //UserID);

                //if (!obj_CCID.Equals(""))
                //{
                //    lblNotification.Text = "Record Save Successfully";
                //    lblNotification.ForeColor = System.Drawing.Color.Green;
                //}
                //else
                //{
                //    lblNotification.Text = "Record not save";
                //    lblNotification.ForeColor = System.Drawing.Color.Red;
                //}

            }
            catch (Exception ex)
            {
            }

        }
    }
}