using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainMaker.TestTaimur
{
    public partial class addcity : System.Web.UI.Page
    {
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            objBSS.GetRegions();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}