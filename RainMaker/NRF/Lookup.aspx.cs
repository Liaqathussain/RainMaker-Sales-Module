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
    public partial class Lookup : System.Web.UI.Page
    {
        clsGeneralFunction obj_GeneralFunction = new clsGeneralFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Query = string.Empty;
            string Filter = Request.QueryString.Get("Filter");
            string Year1 = Request.QueryString.Get("Year1");
            hdnLookupName.Value = Request.QueryString.Get("Lookup");
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            DBEngineType _eDBType = new DBEngineType();
            clsDBAccess obj_clsDBAccess = new clsDBAccess(conn, _eDBType);
            switch (hdnLookupName.Value)
            {
                case "Item":



                    DataTable dt_Items = obj_GeneralFunction.GetAllItems();

                    this.Title = "Item Lookup";
                    //grid_Lookup.DataSource = ObjDB_MLTNT.GetDataTable(Query);
                    grid_Lookup.DataSource = dt_Items;
                    break;

                default:
                    break;
            }

            obj_clsDBAccess.DisposeConnection();
        }

        protected void grid_Lookup_ColumnCreated(object sender, Telerik.Web.UI.GridColumnCreatedEventArgs e)
        {
            e.Column.AutoPostBackOnFilter = true;
            if (e.Column.DataType == typeof(decimal) || e.Column.DataType == typeof(int))
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "CloseMe();", true);
        }
    }
}