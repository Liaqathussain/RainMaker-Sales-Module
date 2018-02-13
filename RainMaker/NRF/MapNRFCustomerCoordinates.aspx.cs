using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RainMaker.Classes;

namespace RainMaker.NRF
{
    public partial class MapNRFCustomerCoordinates : System.Web.UI.Page
    {
        clsMap obj_clsMap = new clsMap();
        double _CurLat = 0;
        double _CurLon = 0;
        public string jsonString = "";
        string _CustomerValue = "";
        int _InfraType = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblCoordinatesUnAvail.Visible = false;

                _CurLat = Convert.ToDouble(base.Request.QueryString["Lat"]);
                _CurLon = Convert.ToDouble(base.Request.QueryString["Lon"]);
                _CustomerValue = Convert.ToString(base.Request.QueryString["CustomerValue"]);
                _InfraType = Convert.ToInt32(base.Request.QueryString["InfraType"]);
                int InfraTypeIndex = 0;
                //_CurLat = 24.8298787;
                //_CurLon = 67.0977501;
                if (_InfraType.Equals(1))
                {
                    InfraTypeIndex = 0;
                }

                if (_InfraType.Equals(2))
                {
                    InfraTypeIndex = 1;
                }




                cmbInfraType.SelectedIndex = InfraTypeIndex;

                DataTable dt_NearestPlaces = obj_clsMap.GetFiveNearestPlaceOFCurrentLocation(_CurLat, _CurLon,_InfraType);
                DataTable dt_NearestTopPlaces = obj_clsMap.GetTopNearestPlaceOFCurrentLocation(_CurLat, _CurLon);
                if (dt_NearestTopPlaces.Rows.Count > 0)
                {
                    string str_TopCoordinate = dt_NearestTopPlaces.Rows[0]["lat"].ToString() + "," + dt_NearestPlaces.Rows[0]["lng"].ToString();
                    txt_end.Value = str_TopCoordinate;
                    start.Value = _CustomerValue;
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
                else
                {
                    lblCoordinatesUnAvail.Visible = true;
                }
                //string str_TopCoordinate = dt_NearestTopPlaces.Rows[0]["lat"].ToString() + "," + dt_NearestPlaces.Rows[0]["lng"].ToString();
                //Response.Write("<script>console.log(" + _CurLat + "," + _CurLon + ");</script>");
                ////end.Value = str_TopCoordinate;
                //txt_end.Value = str_TopCoordinate;
                //jsonString = "[";
                //foreach (DataRow row in dt_NearestPlaces.Rows)
                //{
                //    jsonString += " {lat: " + row["lat"] + " , lng: " + row["lng"] + " }, ";
                //}
                //if (jsonString.LastIndexOf(",") >= 0)
                //{
                //    jsonString.Remove(jsonString.LastIndexOf(","), 1);
                //}
                //jsonString += "]";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

        }    
    }
}