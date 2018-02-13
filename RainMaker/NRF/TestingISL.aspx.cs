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
    public partial class TestingISL : System.Web.UI.Page
    {
        clsMap obj_clsMap = new clsMap();
        double _CurLat = 0;
        double _CurLon = 0;
        public string jsonString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _CurLat = Convert.ToDouble(base.Request.QueryString["Lat"]);
                _CurLon = Convert.ToDouble(base.Request.QueryString["Lon"]);
                //_CurLat = 24.8298787;
                //_CurLon = 67.0977501;

                DataTable dt_NearestPlaces = obj_clsMap.GetFiveNearestPlaceOFCurrentLocation(_CurLat, _CurLon, 1);
                DataTable dt_NearestTopPlaces = obj_clsMap.GetTopNearestPlaceOFCurrentLocation(_CurLat, _CurLon);
                if (dt_NearestTopPlaces.Rows.Count > 0)
                {
                    //grd_Coordinates.DataSource = dt_NearestPlaces;
                    //grd_Coordinates.DataBind();
                    string str_TopCoordinate = dt_NearestTopPlaces.Rows[0]["lat"].ToString() + "," + dt_NearestPlaces.Rows[0]["lng"].ToString();
                    txt_end.Value = str_TopCoordinate;
                    jsonString = "[";
                    foreach (DataRow row in dt_NearestPlaces.Rows)
                    {
                        jsonString += " {lat: " + row["lat"] + " , lng: " + row["lng"] + " }, ";
                    }
                    if (jsonString.LastIndexOf(",") >= 0)
                    {
                        jsonString.Remove(jsonString.LastIndexOf(","), 1);
                    }
                    jsonString += "]";
                }
                Response.Write("<script>console.log(" + _CurLat + "," + _CurLon + ");</script>");
                //end.Value = str_TopCoordinate;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

        }        
    }
}