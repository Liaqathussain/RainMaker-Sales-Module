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
    public partial class WebForm10 : System.Web.UI.Page
    {
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            DataTable dt_GetOpportunity = obj_clsOpportunity.GetEBUOpportunity("1");
            GVOpportunity.DataSource = dt_GetOpportunity;
            GVOpportunity.DataBind();
        }

        protected void GVOpportunity_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVOpportunity.Items[index];
                int OppID = Convert.ToInt32(item["OppID"].Text);
                Response.Redirect("~\\Sales\\UpdateOpportunityEBU.aspx?OppID=" + OppID);
                //Response.Redirect("~/InfraCosting.aspx?Distance=" + _Distance + "&City=" + _City + "&CircuitType=Primary");
            }
        }
        protected void GVOpportunity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dt_GetOpportunity = obj_clsOpportunity.GetEBUOpportunity("1");
            GVOpportunity.DataSource = dt_GetOpportunity;
        }
    }
}