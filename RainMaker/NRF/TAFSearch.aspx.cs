using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.Data;

namespace RainMaker.NRF
{
    public partial class TAFSearch : System.Web.UI.Page
    {
        BL obj_BL = new BL();
        
        clsTAF obj_TAF = new clsTAF();
        
        int _CustomerCode = 0;
        int _TAFID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAccounts();
            }
        }

        private void GetAccounts()
        {
            obj_BL.loadCusCode(cmbAccount, null, null);
        }

        protected void GVNRFView_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVNRFView.Items[index];
                int TAFID = Convert.ToInt32(item["TAFID"].Text);
                int NRFID = Convert.ToInt32(item["NRFID"].Text);
                Response.Redirect("~\\NRF\\TAFSearchData.aspx?TAFID=" + TAFID + "&NRFID=" + NRFID);
               
            }

            if (e.CommandName == "Accept" || e.CommandName == "Reject")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVNRFView.Items[index];
                int TAFID = Convert.ToInt32(item["TAFID"].Text);
                int NRFID = Convert.ToInt32(item["NRFID"].Text);
                Response.Redirect("~\\NRF\\TAFSearchData.aspx?TAFID=" + TAFID + "&NRFID=" + NRFID);

            }
        }

        public void ShowTAFSearch()
        {
            DataTable dt_TAF = obj_TAF.GetTAF(Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToDateTime(dtTAFSearch.SelectedDate));
            GVNRFView.DataSource = dt_TAF;
        }

        protected void GVNRFView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dt_TAF = obj_TAF.GetTAF(Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToDateTime(dtTAFSearch.SelectedDate));
            GVNRFView.DataSource = dt_TAF;
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            ShowTAFSearch();
        }

    }
}