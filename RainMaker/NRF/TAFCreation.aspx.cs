using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;

namespace RainMaker.NRF
{
    public partial class TAFCreation : System.Web.UI.Page
    {
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        clsNRFView obj_NRFView = new clsNRFView();
        clsTAF obj_TAF = new clsTAF();
        BL obj_BL = new BL();
        int _CustomerCode = 0;
        int _NRFID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["DepartmentID"].Equals(3))
            {
                txt_TAFormNo.Enabled = false;
                txt_RevisionNo.Enabled = false;
                txt_SubmissionDate.Enabled = false;
                cmbCustomerName.Enabled = false;
                txt_Address.Enabled = false;
                txt_SitesJobLocation.Enabled = false;
                txt_AccountManager.Enabled = false;
                txt_BusinessUnit.Enabled = false;
                cmbLastMileTopology.Enabled = false;
                cmbCapacity.Enabled = false;
                cmbInterfaceHandoff.Enabled = false;
                cmbInfra.Enabled = false;
                cmbService.Enabled = false;
                cmbLogicalTopology.Enabled = false;
                txt_RestorabilityMethod.Enabled = false;
                cmbAdditionalEquipment.Enabled = false;
                txt_ServiceParameters.Enabled = false;
                cmbSLARequirement.Enabled = false;
                txtAdditionalRequirement.Enabled = false;

                pnlipcore.Visible = true;
            }
            //txt_TAFormNo.Enabled = false;

            _NRFID = Convert.ToInt32(base.Request.QueryString["NRFID"]);
            //_CustomerCode = Convert.ToInt32(base.Request.QueryString["CustomerCode"]);
            txt_SubmissionDate.Text = DateTime.Now.ToString();
            txt_AccountManager.Text = Session["Name"].ToString();
            txt_TAFormNo.Text = DateTime.Now.ToString("MM/dd/yyyy") + "TAF";


            if (!IsPostBack)
            {
                ShowService();
                ShowInfra();
                ShowCapacity_Bandwidth();
                obj_BL.loadCusCode(cmbCustomerName, null, null);
                ShowNRFView();
                cmbInfra.Enabled = false;
            }
        }


        public void ShowNRFView()
        {
            DataTable dt_NRFDetail = obj_NRFView.GetCustomerNRFMasterForDetail(_NRFID);
            if (dt_NRFDetail.Rows.Count > 0)
            {
                cmbCustomerName.SelectedValue = dt_NRFDetail.Rows[0]["CustomerCode"].ToString();
                txt_Address.Text = dt_NRFDetail.Rows[0]["SiteAddress"].ToString();
                cmbService.SelectedValue=dt_NRFDetail.Rows[0]["NRFService"].ToString();
                cmbInfra.SelectedValue = dt_NRFDetail.Rows[0]["Infra"].ToString();
                cmbCapacity.SelectedValue = dt_NRFDetail.Rows[0]["Capacity"].ToString();

                if (dt_NRFDetail.Rows[0]["NRFService"].ToString().Equals("25"))
                {
                    obj_BL.FLL_GetProductDetails(cmbServiceType, 1);
                    cmbServiceType.Visible = true;
                    lblServiceType.Visible = true;
                }
            }
        }

        private void ShowInfra()
        {
            DataTable dt_NRFDetail = obj_NRFView.GetCustomerNRFMasterForDetail(_NRFID);
            if (dt_NRFDetail.Rows.Count > 0)
            {
                obj_BL.GetInfraByLob(cmbInfra, 1, Convert.ToInt32(dt_NRFDetail.Rows[0]["LOB"]));
            }
        }

        private void ShowService()
        {
            //DataTable dt_Service = obj_clsGeneralFunction.GetALLServices();
            //cmbService.DataSource = dt_Service;
            //cmbService.DataTextField = "ServiceUnit";
            //cmbService.DataValueField = "ServiceUnitID";
            //cmbService.DataBind();
            DataTable dt_NRFDetail = obj_NRFView.GetCustomerNRFMasterForDetail(_NRFID);
            if (dt_NRFDetail.Rows.Count > 0)
            {
              //  obj_BL.getServicesUnitByInfra(Convert.ToInt32(dt_NRFDetail.Rows[0]["Infra"]), cmbService);
                obj_BL.getServiceUnitViaInfra(Convert.ToInt32(dt_NRFDetail.Rows[0]["Infra"]), cmbService);
                 
            }
        }

        private void ShowCapacity_Bandwidth()
        {
            //DataTable dt_Capacity = obj_clsGeneralFunction.GetALLBandWidth();
            //cmbCapacity.DataSource = dt_Capacity;
            //cmbCapacity.DataTextField = "BandwidthDesc";
            //cmbCapacity.DataValueField = "BandwidthID";
            //cmbCapacity.DataBind();

            DataTable dt_Capacity = obj_clsGeneralFunction.GetALLBandWidth();
            cmbCapacity.DataSource = dt_Capacity;
            cmbCapacity.DataTextField = "BandwidthDesc";
            cmbCapacity.DataValueField = "BandwidthID";
            cmbCapacity.DataBind();
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            //object obj_nrfid = obj_TAF.CreateTAF(txt_RevisionNo.Text, txt_SitesJobLocation.Text, txt_AccountManager.Text, txt_BusinessUnit.Text, Convert.ToInt32(cmbCapacity.SelectedValue), cmbLastMileTopology.SelectedValue.ToString(), txt_RestorabilityMethod.Text, cmbAdditionalEquipment.SelectedValue.ToString(), txt_ServiceParameters.Text, cmbSLARequirement.SelectedValue.ToString(), 1, 1);


            object obj_nrfid = obj_TAF.CreateTAF(txt_TAFormNo.Text,txt_RevisionNo.Text,txt_SitesJobLocation.Text,txt_AccountManager.Text,txt_BusinessUnit.Text, Convert.ToInt32(cmbLastMileTopology.SelectedValue), Convert.ToInt32(cmbCapacity.SelectedValue), Convert.ToInt32(cmbInterfaceHandoff.SelectedValue), Convert.ToInt32(cmbLogicalTopology.SelectedValue),txt_RestorabilityMethod.Text, Convert.ToInt32(cmbAdditionalEquipment.SelectedValue), Convert.ToInt32(cmbSLARequirement.SelectedValue), txtAdditionalRequirement.Text, 1,1) ;

            if (!obj_nrfid.Equals(""))
            {
                lbl_AccountManager.Visible = true;
            }


            //object obj_nrfid = obj_TAF.CreateTAF("1", "1", "1", "1", 1, "1", "1", "1", "1", "1", 1, 1);
        }

        protected void cmbService_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbService.SelectedValue.Equals("25"))
            {
                obj_BL.FLL_GetProductDetails(cmbServiceType, 1);
                cmbServiceType.Visible = true;
                lblServiceType.Visible = true;
            }
        }

        protected void btView_Click(object sender, EventArgs e)
        {            
            //Response.Redirect("~\\NRF\\NRFItemsView.aspx?NRFID=" + _NRFID);
        }

        protected void btReject_Click(object sender, EventArgs e)
        {
            //obj_TAF.RejectTAF(_NRFID);
        }


        protected void btAccept_Click(object sender, EventArgs e)
        {
            //obj_TAF.AcceptTAF(_NRFID);
        }
    }
}