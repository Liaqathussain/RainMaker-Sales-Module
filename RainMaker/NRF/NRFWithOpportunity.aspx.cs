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
    public partial class NRFWithOpportunity : System.Web.UI.Page
    {
        clsNRFWithOpportunity obj_clsNRFWithOpportunity = new clsNRFWithOpportunity();
        BL obj_BL = new BL();
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();

        string query = " where 1=1 ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obj_BL.loadCusCode(cmbCustomer, null, null);
                obj_BL.loadCityByRegion(cmbcity,2);
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
                double Lat = Convert.ToDouble(item["LAT"].Text);
                double Lon = Convert.ToDouble(item["LNG"].Text);
                //Response.Redirect("~\\IBU\\UpdateOpportunityIBU.aspx?OppID=" + OppID);
                Response.Redirect("~\\NRF\\MapNRFWithOpportunity.aspx?OppID=" + OppID + "&Lat=" +Lat + "&Lon=" + Lon );
                //Response.Redirect("~/InfraCosting.aspx?Distance=" + _Distance + "&City=" + _City + "&CircuitType=Primary");
            }
        }

        protected void GVOpportunity_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //DataTable dt_GetOpportunity = objBSS.SearchOpportunity("1=1", 1);
            //GVOpportunity.DataSource = dt_GetOpportunity;

            BindGrid();

            //DataTable dt_GetOpportunity = obj_clsNRFWithOpportunity.GetOpportunityForNRF();
            //GVOpportunity.DataSource = dt_GetOpportunity;
        }

        private void BindGrid()
        {

            if (!(cmbcity.SelectedValue.Equals("0")))
            {
                query = query + " and  City= " + cmbcity.SelectedValue.ToString();
            }

            if (!(cmbCustomer.SelectedValue.Equals("0")))
            {
                query = query + " and  CustCode= " + cmbCustomer.SelectedValue.ToString();
            }

            DataTable dt_GetOpportunity = objBSS.SearchOpportunity(query, 1);
            GVOpportunity.DataSource = dt_GetOpportunity;
            GVOpportunity.DataBind();
            //DataTable dt_GetOpportunity = obj_clsNRFWithOpportunity.GetOpportunityForNRF();
            //GVOpportunity.DataSource = dt_GetOpportunity;
            //GVOpportunity.DataBind();
        }

        protected void cmbcity_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!(cmbcity.SelectedValue.Equals("0")))
            {
                query = query + " and  City= " + cmbcity.SelectedValue.ToString();
            }

            if (cmbCustomer.SelectedValue.Equals("0"))
            {
                query = query + " and  CustCode= " + cmbCustomer.SelectedValue.ToString();
            }

            DataTable dt_GetOpportunity = objBSS.SearchOpportunity(query, 1);
            GVOpportunity.DataSource = dt_GetOpportunity;
        }

        protected void cmbCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!(cmbcity.SelectedValue.Equals("0")))
            {
                query = query + " and  City= " + cmbcity.SelectedValue.ToString();
            }

            if (!(cmbCustomer.SelectedValue.Equals("0")))
            {
                query = query + " and  CustCode= " + cmbCustomer.SelectedValue.ToString();
            }

            DataTable dt_GetOpportunity = objBSS.SearchOpportunity(query, 1);
            GVOpportunity.DataSource = dt_GetOpportunity;
        }

        protected void btShow_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}