using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using Telerik.Web.UI;
using System.Data;

namespace RainMaker.IBU
{
    public partial class OpportunityList : System.Web.UI.Page
    {
        clsOpportunity obj_clsOpportunity = new clsOpportunity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GVOpportunity_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVOpportunity.Items[index];
                int OppID = Convert.ToInt32(item["OppID"].Text);
                Response.Redirect("~\\IBU\\UpdateOpportunityIBU.aspx?OppID=" + OppID);
                //Response.Redirect("~/InfraCosting.aspx?Distance=" + _Distance + "&City=" + _City + "&CircuitType=Primary");
            }
        }

        protected void GVOpportunity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dt_GetOpportunity = obj_clsOpportunity.GetEBUOpportunity("2");
            GVOpportunity.DataSource = dt_GetOpportunity;
        }

        private void BindGrid()
        {
            DataTable dt_GetOpportunity = obj_clsOpportunity.GetEBUOpportunity("2");
            GVOpportunity.DataSource = dt_GetOpportunity;
            GVOpportunity.DataBind();
        }
    }
}