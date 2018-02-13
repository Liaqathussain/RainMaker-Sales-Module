using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RainMaker
{
    public partial class frmLogin : System.Web.UI.Page
    {
        String IsADAuthenticate = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbuser.Text == string.Empty || tbpass.Text == string.Empty)
                {
                    lblnotify.Text = "Please enter username or password";
                    lblnotify.Visible = true;
                    return;
                }

                BSS_Service.Service1SoapClient client = new BSS_Service.Service1SoapClient();
                //BSS_ServiceLocal.Service1SoapClient client = new BSS_ServiceLocal.Service1SoapClient();
                DataTable dt = client.AuthenticateUser(tbuser.Text, tbpass.Text);

                if (dt.Rows.Count == 1)
                {
                    AppDomain.CurrentDomain.SetData("DepartmentID", dt.Rows[0]["DepartmentID"]);
                    AppDomain.CurrentDomain.SetData("UserID", dt.Rows[0]["UserID"]);
                    AppDomain.CurrentDomain.SetData("RoleID", dt.Rows[0]["RoleID"]);
                    AppDomain.CurrentDomain.SetData("Name", dt.Rows[0]["Name"]);
                    IsADAuthenticate = dt.Rows[0]["IsADAuthenticate"].ToString();
                    Session["UserID"] = dt.Rows[0]["UserID"];
                    Session["Name"] = dt.Rows[0]["Name"];
                    Session["ManagerID"] = dt.Rows[0]["ManagerID"];
                    Session["RoleID"] = dt.Rows[0]["RoleID"];
                    Session["DepartmentID"] = dt.Rows[0]["DepartmentID"];

                    if (IsADAuthenticate == "1")
                    {
                        if (client.Ldap_Authentication(tbuser.Text, tbpass.Text) == true)
                        {
                            Server.Transfer("Default.aspx", true);
                            //Server.Transfer("~/NRF/MapCoordinates.aspx", true);
                            
                        }
                        else
                        {
                            lblnotify.Visible = true;
                            lblnotify.Text = "You are not authenticated from domain.";
                            return;
                        }
                    }
                    else if (IsADAuthenticate == "0")
                    {
                        //Server.Transfer("Default.aspx", true);
                        Response.Redirect("Default.aspx", true);
                        //Response.Redirect("~/NRF/MapCoordinates.aspx", true);
                    }
                }
                else
                {
                    lblnotify.Visible = true;
                    lblnotify.Text = "Invalid username or password";
                }
            }
            catch (InvalidCastException)
            {
            }
        }
    }
}