using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script;
namespace RainMaker
{
    public partial class Site : System.Web.UI.MasterPage
    {
        
        //ResolveURL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude("Jquery", ResolveUrl("~/Scripts/jquery-1.4.1.js"));
                Page.ClientScript.RegisterClientScriptInclude("Javascript", ResolveUrl("~/Scripts/js/jquery.js"));
                Page.ClientScript.RegisterClientScriptInclude("Moriss", ResolveUrl("~/Scripts/js/plugins/morris/morris.js"));
                Page.ClientScript.RegisterClientScriptInclude("BootStrap", ResolveUrl("~/Scripts/js/bootstrap.js"));
                Page.ClientScript.RegisterClientScriptInclude("BootStapmin", ResolveUrl("~/Scripts/js/bootstrap.min.js"));


            if (!IsPostBack)
            {
                
                SetMainControls();
            }
        }

        protected void SetMainControls()
        {
            BSS_Service.Service1SoapClient client = new BSS_Service.Service1SoapClient();
            String roleid = AppDomain.CurrentDomain.GetData("RoleID").ToString();
            //string roleid = "45";
            DataTable dt = client.GetModuleFormsViaRoleID(Convert.ToInt16(roleid));
            string name = AppDomain.CurrentDomain.GetData("Name").ToString();
            UserName.InnerText = name;
            string previous = "";
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            var cls = dt.Rows[1][1].ToString();

            int c = 0;
            int i = 0;
            //RepeaterItem ItemTemplate = new RepeaterItem();
            Label lbl = new Label();
            TextBox tb = new TextBox();
            /*  foreach (DataRow row in dt.Rows) {
                     previous = row.ToString();
                     foreach (DataColumn col in dt.Columns) {
                    
                         if (col.ColumnName == "ModuleName" && previous!=col.ToString())
                         {
                             lbl.Text += row[col.ToString()].ToString() + "<br/>";

                            
                         }
                     }
            
                 }*/
            foreach (DataRow row in dt.Rows)
            {
                if (row["WebDisplayName"].ToString() != "0")
                {
                    if (row["ModuleName"].ToString() != previous)
                    {
                        if (c != 0)
                        {
                            NavBar.InnerHtml += "</ul></li>";

                        }
                        NavBar.InnerHtml += "<li><a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#" + row["FormIDName"].ToString() + "\"><i class=\"fa fa-fw fa-arrows-v\"></i>" + row["ModuleName"].ToString() + "<i class=\"fa fa-fw fa-caret-down\"></i></a>";
                        NavBar.InnerHtml += "<ul id=" + row["FormIDName"].ToString() + " class=\"collapse\">";
                        if (c == 0) { c++; }
                        previous = row["ModuleName"].ToString();
                        i++;
                    }

                    if (row["ModuleName"].ToString() == previous)
                    {
                        if (row["WebDisplayName"].ToString() != "0")
                            NavBar.InnerHtml += "<li style=\"font-size:x-small;\"><a runat=\"server\" href=\"" +ResolveUrl(row["Redirection"].ToString()) + "\">" + row["WebDisplayName"].ToString() + "</a> </li>";
                        //control.Controls.Add(lbll);
                      
                    }

                }


                // foreach (DataColumn col in row) { }
            }
            //lbl.Text = dt.Rows[1][3].ToString() ;*/
            NavBar.InnerHtml += "</ul></li>";
            NavBar.InnerHtml += "<li ><a href=\"..\\frmLogin.aspx\">Log Out</a></li>";





        }
    }
}