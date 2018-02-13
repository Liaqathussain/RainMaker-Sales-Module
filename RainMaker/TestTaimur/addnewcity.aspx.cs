using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RainMaker.TestTaimur
{
    public partial class addnewcity : System.Web.UI.Page
    {
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        BL objBL = new BL();    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // objBL.GetInfra(cmbRegions,1,0);
                objBL.loadRegions(cmbRegions);
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            objBSS.InsertCity("abc", 123, 1, 1);

           
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objBSS.GetCityByRegion(1);
            gvGetCity.DataSource = dt;
            gvGetCity.DataBind();
            //gvGetCity.Columns["CityID"].Visible = false;
          //  gvGetCity.Columns


        }

        protected void cmbRegions_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
    }
}