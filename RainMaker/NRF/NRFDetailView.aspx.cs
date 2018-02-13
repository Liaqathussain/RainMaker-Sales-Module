using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker.NRF
{
    public partial class NRFDetailView : System.Web.UI.Page
    {
        clsNRFView obj_NRV = new clsNRFView();
        int _NRFID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _NRFID = Convert.ToInt32(base.Request.QueryString["NRFID"]);
                ShowNRFDetails();
            }
        }

        protected void GVNRFViewDetails_ItemCommand(object sender, GridCommandEventArgs e)
        {
            
        }

        protected void GVNRFViewDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dt_NRFDetail = obj_NRV.GetCustomerNRFDetail(_NRFID);
            GVNRFViewDetails.DataSource = dt_NRFDetail;
        }

        public void ShowNRFDetails()
        {
            DataTable dt_NRFDetail = obj_NRV.GetCustomerNRFDetail(_NRFID);
            GVNRFViewDetails.DataSource = dt_NRFDetail;
            GVNRFViewDetails.DataBind();
            
        }
    }
}