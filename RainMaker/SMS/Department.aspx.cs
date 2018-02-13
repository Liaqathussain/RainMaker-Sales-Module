using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RainMaker
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        BL objBL = new BL();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCities();
                getGroup();
            }
            
        }

        public void getCities()
        {
            try
            {
                objBL.loadCities(cmbCity);

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Error Message");
            }
        }

        public void getGroup()
        {
            try
            {
                objBL.GetGroups(cmbGroup);

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Error Message");
            }
        }

        public void GetEmployeeDetails(int GroupID, int CityID)
        {
            try
            {
                dynamic dt = objBSS.GetEmployeeViaGroup(GroupID, CityID);
                if (dt.Rows.Count > 0)
                {
                    grdEmployee.DataSource = dt;
                    grdEmployee.DataBind();

                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
        }

        protected void cmbCity_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!cmbCity.SelectedValue.Equals(0))
            {
                GetEmployeeDetails(Convert.ToInt32(cmbGroup.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue));
            }
        }

        protected void cmbGroup_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!cmbGroup.SelectedValue.Equals(0))
            {
                GetEmployeeDetails(Convert.ToInt32(cmbGroup.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue));
            }
        }

        protected void grdEmployee_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEmployeeDetails(Convert.ToInt32(cmbGroup.SelectedValue), Convert.ToInt32(cmbCity.SelectedValue));
        }

        protected void chkIsSelectAll_changed(object sender, EventArgs e)
        {
            try
            {
                if (chkIsSelectAll.Checked == true)
                {

                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == false)
                        {
                            cb.Checked = true;
                        }
                    }


                }
                else
                {
                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            cb.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (isValidate().Equals(true))
            {

                if (grdEmployee.Items.Count > 0)
                {
                    foreach (GridDataItem item in grdEmployee.Items)
                    {
                        var cb = (CheckBox)item.FindControl("cb_Select");
                        if (cb.Checked == true)
                        {
                            //string ContactNo = Convert.ToInt32(item["ComplaintID"].Text);
                            string contactno = item["SMSNo"].Text;
                            // contactno = "923343673008";
                            objBSS.SendSMS("External SMS", contactno, tbSMS.Text, 1);
                        }
                    }
                }
            }

            else
            {
                lblNotify.Text = "Either your message box is empty or none of the record is selected";
                lblNotify.Visible = true;
            }
        }

        public bool isValidate()
        {
            bool @bool = false;

            try
            {
                foreach (GridDataItem item in grdEmployee.Items)
                {
                    var cb = (CheckBox)item.FindControl("cb_Select");
                    if (cb.Checked == true)
                    {
                        @bool = true;
                    }
                }

                if (!@bool)
                {
                    return @bool;
                }

                if (tbSMS.Text.Equals(""))
                {
                    @bool = false;
                    return @bool;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, Title: "Message Box");
            }
            return @bool;
        }
    }
}