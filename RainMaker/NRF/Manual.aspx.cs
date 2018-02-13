using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace RainMaker.NRF
{
    public partial class Manual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string FilePath = HttpContext.Current.Server.MapPath("~/Reports/" + ("NRF Manual") + ".pdf");
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=\" " + "NRF Manual"  + ".pdf\"");
            ////Response.WriteFile(Server.MapPath(Trim(InvoiceNumber) & ".pdf"))
            ////Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Reports/" + ("NRF") + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf"));
            //Response.TransmitFile(FilePath);

            //Response.Redirect("~/Reports/" + ("NRF Manual") + ".pdf");

            string path = Server.MapPath("~/Reports/" + ("NRF Manual") + ".pdf");
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
    }
}