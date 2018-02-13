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
    public partial class NRFView : System.Web.UI.Page
    {
        
        BL obj_BL = new BL();
        clsNRFView obj_NRV = new clsNRFView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAccounts();
                GetLOBID();
            }
        }

        private void GetAccounts()
        {     
            obj_BL.loadCusCode(cmbAccount, null, null);
        }

        private void GetLOBID()
        {
            obj_BL.getLob(cmbLOBID);
        }

        protected void GVNRFView_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVNRFView.Items[index];
                int NRFID = Convert.ToInt32(item["NRFID"].Text);
                //Response.Redirect("~\\NRF\\NRFDetailView.aspx?NRFID=" + NRFID);
                Response.Redirect("~\\NRF\\NRFItemsView.aspx?NRFID=" + NRFID);
                //Response.Redirect("~/InfraCosting.aspx?Distance=" + _Distance + "&City=" + _City + "&CircuitType=Primary");
            }

            if (e.CommandName == "Taf")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVNRFView.Items[index];
                int NRFID = Convert.ToInt32(item["NRFID"].Text);
                Response.Redirect("~\\NRF\\TAFCreation.aspx?NRFID=" + NRFID);
                
            }
        }


        protected void GVNRFView_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable ddt_ShowCustomerNRF = obj_NRV.GetCustomerNRFMaster(Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbLOBID.SelectedValue));
            GVNRFView.DataSource = ddt_ShowCustomerNRF;
        }

        private void ShowNRF()
        {
            DataTable ddt_ShowCustomerNRF = obj_NRV.GetCustomerNRFMaster(Convert.ToInt32(cmbAccount.SelectedValue), Convert.ToInt32(cmbLOBID.SelectedValue));
            GVNRFView.DataSource = ddt_ShowCustomerNRF;
            GVNRFView.DataBind();
            GVNRFView.MasterTableView.GetColumn("NRFID").Visible = false;
            GVNRFView.MasterTableView.GetColumn("NRF").Visible = false;
        }

        protected void btShow_Click(object sender, EventArgs e)
        {
            ShowNRF();
        }

        protected void GVNRFView_ItemDataBound(object aSender, GridItemEventArgs anEventArgs)
        {
            int abc = 0;
        }
    }
}