using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.IO;
using RainMaker.Classes;
using Telerik.Web.UI.GridExcelBuilder;
using System.Drawing;


namespace RainMaker
{
    public partial class TestExportExcel : System.Web.UI.Page
    {
        int DeptID;
        BL objBL = new BL();
        //BSS_ServiceLocal.Service1SoapClient objBSS = new BSS_ServiceLocal.Service1SoapClient();
        clsMap obj_clsMap = new clsMap();
        double _CurLat = 0;
        double _CurLon = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable dt_NearestPlaces = obj_clsMap.GetFiveNearestPlaceOFCurrentLocation(24.8298787, 67.09752139999999,1);
                    RadGrid1.DataSource = dt_NearestPlaces;
                    RadGrid1.DataBind();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.StackTrace);
                }
            }
        }


        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string alternateText = (sender as ImageButton).AlternateText;
            #region [ XSLX FORMAT ]
            if (alternateText == "Xlsx" && CheckBox2.Checked)
            {
                RadGrid1.MasterTableView.GetColumn("LAT").HeaderStyle.BackColor = Color.LightGray;
                RadGrid1.MasterTableView.GetColumn("LAT").ItemStyle.BackColor = Color.LightGray;
            }
            #endregion
            RadGrid1.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            RadGrid1.ExportSettings.IgnorePaging = CheckBox1.Checked;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.MasterTableView.ExportToExcel();
        }

        #region [ HTML FORMAT ]
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (CheckBox2.Checked)
            {
                if (e.Item is GridDataItem || e.Item is GridHeaderItem)
                {
                    e.Item.Cells[2].CssClass = "employeeColumn";
                }
            }
        }

        //protected void RadGrid1_HtmlExporting(object sender, GridHTMLExportingEventArgs e)
        //{
        //    if (CheckBox2.Checked)
        //    {
        //        e.Styles.Append("@page table .employeeColumn { background-color: #d3d3d3; }");
        //    }
        //}
        #endregion

        #region [ EXCELML FORMAT ]
        //protected void RadGrid1_ExcelMLWorkBookCreated(object sender, GridExcelMLWorkBookCreatedEventArgs e)
        //{
        //    if (CheckBox2.Checked)
        //    {
        //        foreach (RowElement row in e.WorkBook.Worksheets[0].Table.Rows)
        //        {
        //            row.Cells[0].StyleValue = "Style1";
        //        }

        //        StyleElement style = new StyleElement("Style1");
        //        style.InteriorStyle.Pattern = InteriorPatternType.Solid;
        //        style.InteriorStyle.Color = System.Drawing.Color.LightGray;
        //        e.WorkBook.Styles.Add(style);
        //    }
        //}

        #endregion

        #region [ BIFF FORMAT ]
        //protected void RadGrid1_BiffExporting(object sender, GridBiffExportingEventArgs e)
        //{
        //    if (CheckBox2.Checked)
        //    {
        //        e.ExportStructure.Tables[0].Columns[1].Style.BackColor = System.Drawing.Color.LightGray;
        //    }
        //}

        #endregion

        #region [ Built-in Export button configuration ]
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExportToExcelCommandName)
            {
                //RadGrid1.ExportSettings.Excel.Format = GridExcelExportFormat.Biff;
                RadGrid1.ExportSettings.IgnorePaging = CheckBox1.Checked;
                RadGrid1.ExportSettings.ExportOnlyData = true;
                RadGrid1.ExportSettings.OpenInNewWindow = true;
            }
        }
        #endregion



    }
}