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
    public partial class TAFSearchData : System.Web.UI.Page
    {
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        clsNRFView obj_NRFView = new clsNRFView();
        clsTAF obj_TAF = new clsTAF();
        BL obj_BL = new BL();
        int _CustomerCode = 0;
        int _TAFID = 0;
        int _NRFID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _TAFID = Convert.ToInt32(base.Request.QueryString["TAFID"]);
                _NRFID = Convert.ToInt32(base.Request.QueryString["NRFID"]);
                ViewState["TAFID"] = _TAFID;
                ViewState["NRFID"] = _NRFID;
                ShowService();
                ShowInfra();
                ShowCapacity_Bandwidth();
                obj_BL.loadCusCode(cmbCustomerName, null, null);                
                ShowTAF();

                if (Session["DepartmentID"].Equals(3) || Session["DepartmentID"].Equals(1))
                {
                    pnl_Ipcore.Visible = true;
                    btEdit.Visible = true;
                }
            }
        }

        private void ShowInfra()
        {
            DataTable dt_TAF = obj_TAF.GetTAFData(_TAFID);
            if (dt_TAF.Rows.Count > 0)
            {
                obj_BL.GetInfraByLob(cmbInfra, 1, Convert.ToInt32(dt_TAF.Rows[0]["LOB"]));
            }
        }

        private void ShowService()
        {

            DataTable dt_TAF = obj_TAF.GetTAFData(_TAFID);
            if (dt_TAF.Rows.Count > 0)
            {
                obj_BL.getServiceUnitViaInfra(Convert.ToInt32(dt_TAF.Rows[0]["Infra"]), cmbService);

            }
        }

        private void ShowCapacity_Bandwidth()
        {
            
            DataTable dt_Capacity = obj_clsGeneralFunction.GetALLBandWidth();
            cmbCapacity.DataSource = dt_Capacity;
            cmbCapacity.DataTextField = "BandwidthDesc";
            cmbCapacity.DataValueField = "BandwidthID";
            cmbCapacity.DataBind();
        }

        public void ShowTAF()
        {
            DataTable dt_TAF = obj_TAF.GetTAFData(_TAFID);
            if (dt_TAF.Rows.Count > 0)
            {
                txt_TAFormNo.Text = dt_TAF.Rows[0]["TAFFormNo"].ToString();
                txt_RevisionNo.Text = dt_TAF.Rows[0]["RevisionNo"].ToString();
                txt_SubmissionDate.Text = dt_TAF.Rows[0]["SubmissionDate"].ToString();
                cmbCustomerName.SelectedValue = dt_TAF.Rows[0]["CustomerCode"].ToString();
                txt_Address.Text = dt_TAF.Rows[0]["SiteAddress"].ToString();
                txt_SitesJobLocation.Text = dt_TAF.Rows[0]["Sites_JobLocation"].ToString();
                txt_AccountManager.Text = dt_TAF.Rows[0]["AccountManager"].ToString();
                txt_BusinessUnit.Text = dt_TAF.Rows[0]["BusinessUnit"].ToString();
                cmbLastMileTopology.SelectedValue = dt_TAF.Rows[0]["LastMileTopology"].ToString();
                cmbCapacity.SelectedValue = dt_TAF.Rows[0]["Capacity"].ToString();
                cmbInterfaceHandoff.SelectedValue = dt_TAF.Rows[0]["InterfaceHandoff"].ToString();
                cmbInfra.SelectedValue = dt_TAF.Rows[0]["Infra"].ToString();
                cmbService.SelectedValue = dt_TAF.Rows[0]["NRFService"].ToString();
                cmbLogicalTopology.SelectedValue = dt_TAF.Rows[0]["LogicalTopology"].ToString();
                txt_RestorabilityMethod.Text = dt_TAF.Rows[0]["RestorabilityMethod"].ToString();
                cmbAdditionalEquipment.SelectedValue = dt_TAF.Rows[0]["AdditionalEquipment"].ToString();                
                cmbSLARequirement.SelectedValue = dt_TAF.Rows[0]["SLARequirement"].ToString();
                txtAdditionalRequirement.Text = dt_TAF.Rows[0]["SLARequirement"].ToString();
                //txt_ServiceDescription.Text = dt_TAF.Rows[0]["AdditionalEquipment"].ToString();
                //txtComments.Text = dt_TAF.Rows[0]["AdditionalEquipment"].ToString();




                if (dt_TAF.Rows[0]["NRFService"].ToString().Equals("25"))
                {
                    obj_BL.FLL_GetProductDetails(cmbServiceType, 1);
                    cmbServiceType.Visible = true;
                    lblServiceType.Visible = true;
                }
            }
        }
        protected void btEdit_Click(object sender, EventArgs e)
        {

            obj_TAF.UpdateTAF(Convert.ToInt32(ViewState["TAFID"]), txt_TAFormNo.Text, txt_RevisionNo.Text, txt_SitesJobLocation.Text, txt_AccountManager.Text, txt_BusinessUnit.Text, Convert.ToInt32(cmbLastMileTopology.SelectedValue), Convert.ToInt32(cmbCapacity.SelectedValue), Convert.ToInt32(cmbInterfaceHandoff.SelectedValue), Convert.ToInt32(cmbLogicalTopology.SelectedValue), txt_RestorabilityMethod.Text, Convert.ToInt32(cmbAdditionalEquipment.SelectedValue), Convert.ToInt32(cmbSLARequirement.SelectedValue), txtAdditionalRequirement.Text);
            //object obj_nrfid = obj_TAF.CreateTAF(txt_RevisionNo.Text, txt_SitesJobLocation.Text, txt_AccountManager.Text, txt_BusinessUnit.Text, Convert.ToInt32(cmbCapacity.SelectedValue), cmbLastMileTopology.SelectedValue.ToString(), txt_RestorabilityMethod.Text, cmbAdditionalEquipment.SelectedValue.ToString(), txt_ServiceParameters.Text, cmbSLARequirement.SelectedValue.ToString(), 1, 1);
            //object obj_nrfid = obj_TAF.CreateTAF("1", "1", "1", "1", 1, "1", "1", "1", "1", "1", 1, 1);
        }       

        protected void btView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\NRF\\NRFItemsView.aspx?NRFID=" + ViewState["NRFID"]);
        }

        protected void btReject_Click(object sender, EventArgs e)
        {
            string RejectButton = obj_TAF.RejectTAF( Convert.ToInt32(ViewState["NRFID"]), Convert.ToInt32(ViewState["TAFID"]), txt_ServiceDescription.Text, txtComments.Text, txtAdditionalEquipment.Text);

            if (RejectButton.Equals("R"))
            {
                lblApprovalSuccessfully.Visible = true;
                lblApprovalSuccessfully.Text = "Rejected";
            }
        }


        protected void btAccept_Click(object sender, EventArgs e)
        {
            string AcceptButton = obj_TAF.AcceptTAF(Convert.ToInt32(ViewState["NRFID"]), Convert.ToInt32(ViewState["TAFID"]), txt_ServiceDescription.Text, txtComments.Text, txtAdditionalEquipment.Text);

            if (AcceptButton.Equals("A"))
            {
                lblApprovalSuccessfully.Visible = true;
                lblApprovalSuccessfully.Text = "Accepted";
            }
        }
    }
}