using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker
{
    public class BL
    {
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();

        #region "SignUp Metronet"
        public void loadRegions(RadComboBox ddRegions)
        {
            try
            {
                dynamic dt = objBSS.GetRegions();

                if (dt.Rows.Count > 0)
                {
                    ddRegions.DataTextField = "RegionName";
                    ddRegions.DataValueField = "RegionID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    ddRegions.DataSource = dt;
                    ddRegions.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadPrioty(RadComboBox ddP)
        {
            try
            {
                dynamic dt = objBSS.GetPriority();

                if (dt.Rows.Count > 0)
                {
                    ddP.DataTextField = "Priority";
                    ddP.DataValueField = "PriorityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    ddP.DataSource = dt;
                    ddP.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadCity(RadComboBox DDCity)
        {
            try
            {
                dynamic dt = objBSS.Get_Cities();

                if (dt.Rows.Count > 0)
                {
                    DDCity.DataTextField = "CityName";
                    DDCity.DataValueField = "CityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCity.DataSource = dt;
                    DDCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCities(RadComboBox DDCity)
        {
            try
            {
                dynamic dt = objBSS.Get_Cities();

                if (dt.Rows.Count > 0)
                {
                    DDCity.DataTextField = "CityName";
                    DDCity.DataValueField = "CityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCity.DataSource = dt;
                    DDCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCusCode(RadComboBox DDCUS, RadComboBox DDProject, string Flag)
        {

            try
            {
                dynamic dt = objBSS.GetMasterCustomer();

                if (dt.Rows.Count > 0)
                {
                    DDCUS.DataTextField = "Customer";
                    DDCUS.DataValueField = "CustomerCode";
                    DataRow dr = dt.NewRow();
                    dr[1] = 0;
                    dr[2] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCUS.DataSource = dt;
                    DDCUS.DataBind();
                    if (Flag == "Insert")
                    {
                        loadProject(DDProject, dt.Rows(0)(1));
                    }

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadProject(RadComboBox DDProj, int custCode)
        {
            try
            {
                dynamic dt = objBSS.GetProjectsByCustomerCode(custCode);

                if (dt.Rows.Count > 0)
                {
                    DDProj.DataTextField = "Project";
                    DDProj.DataValueField = "ProjectCode";
                    DataRow dr = dt.NewRow();
                    dr[1] = 0;
                    dr[2] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDProj.DataSource = dt;
                    DDProj.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadLoca(RadComboBox DDLocation, int cityID)
        {
            try
            {
                dynamic dt = objBSS.GetLocations(cityID, 0, "CityID");
                if (dt.Rows.Count > 0)
                {
                    DDLocation.DataTextField = "location";
                    DDLocation.DataValueField = "LocationCode";
                    DDLocation.DataSource = dt;
                    DDLocation.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadCircuitType(RadComboBox DDCusType, int InfraID)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitTypeByInfraID(InfraID);

                if (dt.Rows.Count > 0)
                {
                    DDCusType.DataTextField = "CircuitType";
                    DDCusType.DataValueField = "CircuitTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCusType.DataSource = dt;
                    DDCusType.DataBind();

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadTypeDesc(RadComboBox DDTypeDesc)
        {
            try
            {
                dynamic dt = objBSS.GetTypeDesc();

                if (dt.Rows.Count > 0)
                {
                    DDTypeDesc.DataTextField = "TypeDesc";
                    DDTypeDesc.DataValueField = "TypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDTypeDesc.DataSource = dt;
                    DDTypeDesc.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadTypeDescbyOwnerID(RadComboBox DDTypeDesc, int OwnerID)
        {
            try
            {
                dynamic dt = objBSS.GetTypeDescbyOwnerID(OwnerID);

                if (dt.Rows.Count > 0)
                {
                    DDTypeDesc.DataTextField = "TypeDesc";
                    DDTypeDesc.DataValueField = "TypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDTypeDesc.DataSource = dt;
                    DDTypeDesc.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadBusinessType(RadComboBox DDBusinessTyp)
        {
            try
            {
                dynamic dt = objBSS.GetBusinessType();

                if (dt.Rows.Count > 0)
                {
                    DDBusinessTyp.DataTextField = "BusinessType";
                    DDBusinessTyp.DataValueField = "BID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDBusinessTyp.DataSource = dt;
                    DDBusinessTyp.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadSiteBwithService(RadComboBox DDRadComboBox, int CustomerCode, int ServiceUnitID, int InfraID)
        {
            try
            {
                dynamic dt = objBSS.GetSiteB_Circuits(CustomerCode, ServiceUnitID, InfraID);

                if (dt.Rows.Count > 0)
                {
                    DDRadComboBox.DataTextField = dt.Columns(1).ColumnName;
                    DDRadComboBox.DataValueField = dt.Columns(0).ColumnName;
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDRadComboBox.DataSource = dt;
                    DDRadComboBox.DataBind();
                }
                else
                {
                    DDRadComboBox.DataSource = null;
                    DDRadComboBox.DataValueField = string.Empty;
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadSiteB(string company, RadComboBox DDSiteB)
        {
            try
            {
                dynamic dt = objBSS.GetSiteB_ID(company + "%");

                if (dt.Rows.Count > 0)
                {
                    DDSiteB.DataTextField = dt.Columns(1).ColumnName;
                    DDSiteB.DataValueField = dt.Columns(0).ColumnName;
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSiteB.DataSource = dt;
                    DDSiteB.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadBandWidth(RadComboBox DDBandwidth)
        {
            try
            {
                dynamic dt = objBSS.GetBandwidthEnterprise();

                if (dt.Rows.Count > 0)
                {
                    DDBandwidth.DataTextField = "BandwidthDesc";
                    DDBandwidth.DataValueField = "BandwidthID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDBandwidth.DataSource = dt;
                    DDBandwidth.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadExchangeArea(RadComboBox DDExchangeArea, RadComboBox cmbAreaNode, int CityID, string Form)
        {

            try
            {
                dynamic dt = objBSS.GetAreaByCityID(CityID);

                if (dt.Rows.Count > 0)
                {
                    DDExchangeArea.DataTextField = "Area";
                    DDExchangeArea.DataValueField = "AreaID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDExchangeArea.DataSource = dt;
                    DDExchangeArea.DataBind();

                    if (Form.ToLower() == "insert")
                    {
                        loadNode(cmbAreaNode, 1, 0, "");
                    }


                }


            }
            catch (Exception ex)
            {
            }
        }

        public void loadODFPortCapacity(RadComboBox DDPortCapacity)
        {
            try
            {
                dynamic dt = objBSS.GetODFPortCapacity();
                if (dt.Rows.Count > 0)
                {
                    DDPortCapacity.DataTextField = "ODFPortCapacity";
                    DDPortCapacity.DataValueField = "ODFPortCapacityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDPortCapacity.DataSource = dt;
                    DDPortCapacity.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadSalesPerson(RadComboBox DDSalesPerson)
        {
            try{
                DataTable dt = objBSS.GetSalesPersons();
                if(dt.Rows.Count > 0 )
                {
                    DDSalesPerson.DataTextField = "SalesPersonName";
                    DDSalesPerson.DataValueField = "SalesPersonID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSalesPerson.DataSource = dt;
                    DDSalesPerson.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        

        public void loadGetPaymnetTerms(RadComboBox DDPaymentTerms)
        {
            try
            {
                dynamic dt = objBSS.GetPaymentTerms();

                if (dt.Rows.Count > 0)
                {
                    DDPaymentTerms.DataTextField = "PaymentTerm";
                    DDPaymentTerms.DataValueField = "PaymentTermID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDPaymentTerms.DataSource = dt;
                    DDPaymentTerms.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadGetEquipmentProperty(RadComboBox DDEquipment)
        {
            try
            {
                dynamic dt = objBSS.GetEquipmentProperty();

                if (dt.Rows.Count > 0)
                {
                    DDEquipment.DataTextField = "Property";
                    DDEquipment.DataValueField = "EquipmentPropertyID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDEquipment.DataSource = dt;
                    DDEquipment.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void GetReportCircuitStatus(RadComboBox combo, string Parameter)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitStatus(Parameter);

                if (dt.Rows.Count > 0)
                {
                    combo.DataTextField = "Status";
                    combo.DataValueField = "StatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    combo.DataSource = dt;
                    combo.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "BSS Administrator");
            }
        }

        public void getLob(RadComboBox combo)
        {
            try
            {
                dynamic dt = objBSS.Get_LOB();

                if (dt.Rows.Count > 0)
                {
                    combo.DataTextField = "LOB";
                    combo.DataValueField = "LOB_ID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    combo.DataSource = dt;
                    combo.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "BSS Administrator");
            }
        }

        public void getServicesUnitByLOb(RadComboBox combo, int id)
        {
            try
            {
                dynamic dt = objBSS.GetServiceUnitByLOB(id);

                if (dt.Rows.Count > 0)
                {
                    combo.DataTextField = "ServiceUnit";
                    combo.DataValueField = "ServiceUnitID";
                    DataRow dr = dt.NewRow();
                    dr[1] = 0;
                    dr[0] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    combo.DataSource = dt;
                    combo.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "BSS Administrator");
            }
        }

        public void loadCircuitStatus(RadComboBox combo, string Parameter)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitStatus(Parameter);

                if (dt.Rows.Count > 0)
                {
                    combo.DataTextField = "Status";
                    combo.DataValueField = "StatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    combo.DataSource = dt;

                }

            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region "SignUp TDM"

        public void loadTDMCusCode(RadComboBox DDCUS, RadComboBox DDProject)
        {
            try
            {
                dynamic dt = objBSS.GetMasterCustomer();

                if (dt.Rows.Count > 0)
                {
                    DDCUS.DataTextField = "Customer";
                    DDCUS.DataValueField = "CustomerCode";
                    DDCUS.DataSource = dt;
                    DDCUS.DataBind();
                    loadTDMProject(DDProject, dt.Rows(0)(1));
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadTDMProject(RadComboBox DDProj, int custCode)
        {
            try
            {
                dynamic dt = objBSS.GetProjectsByCustomerCode(custCode);

                if (dt.Rows.Count > 0)
                {
                    DDProj.DataTextField = "Project";
                    DDProj.DataValueField = "ProjectCode";
                    DDProj.DataSource = dt;
                    DDProj.DataBind();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadTDMCountries(RadComboBox DDCountry)
        {
            try
            {
                dynamic dt = objBSS.GetCountries();
                if (dt.Rows.Count > 0)
                {
                    DDCountry.DataTextField = "CountryName";
                    DDCountry.DataValueField = "Id";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCountry.DataSource = dt;
                    DDCountry.DataBind();
                }


            }
            catch (Exception ex)
            {
            }
        }

        public void GetSalesPersonsbyInfraID(RadComboBox DDSalesPerson, int InfraID)
        {
            try
            {
                dynamic dt = objBSS.GetSalesPersonsbyInfraID(InfraID);
                if (dt.Rows.Count > 0)
                {
                    DDSalesPerson.DataTextField = "SalesPersonName";
                    DDSalesPerson.DataValueField = "SalesPersonID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSalesPerson.DataSource = dt;
                    DDSalesPerson.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Helping Functions"

        public void GetRegions(RadComboBox cmbRegions)
        {
            try
            {
                dynamic dt = objBSS.GetRegions();
                if (dt.Rows.Count > 0)
                {
                    cmbRegions.DataTextField = "RegionName";
                    cmbRegions.DataValueField = "RegionID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    cmbRegions.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetInfra(RadComboBox cmbInfra, int IsActive, int ServiceUnitID)
        {
            try
            {
                dynamic dt = objBSS.GetInfra(IsActive, ServiceUnitID);

                if (dt.Rows.Count > 0)
                {
                    cmbInfra.DataTextField = "InfraDetail";
                    cmbInfra.DataValueField = "InfraID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    cmbInfra.DataSource = dt;
                    cmbInfra.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetRequestType(RadComboBox cmbRequestType)
        {
            try
            {
                dynamic dt = objBSS.GetRequestType();

                if (dt.Rows.Count > 0)
                {
                    cmbRequestType.DataTextField = "RequestType";
                    cmbRequestType.DataValueField = "RequestTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    cmbRequestType.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCityByRegion(RadComboBox DDCity, int RegionID)
        {
            try
            {
                dynamic dt = objBSS.GetCityByRegion(RegionID);

                if (dt.Rows.Count > 0)
                {
                    DDCity.DataTextField = "CityName";
                    DDCity.DataValueField = "CityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCity.DataSource = dt;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCustomerList(RadComboBox DDCus)
        {
            try
            {
                dynamic dt = objBSS.GetMasterCustomer();

                if (dt.Rows.Count > 0)
                {
                    DDCus.DataTextField = "Customer";
                    DDCus.DataValueField = "CustomerCode";
                    DDCus.DataSource = dt;

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void loadODFPortStatus(RadComboBox DDStatus)
        {
            try
            {
                dynamic dt = objBSS.GetODFPortStatus();

                if (dt.Rows.Count > 0)
                {
                    DDStatus.DataTextField = "Status";
                    DDStatus.DataValueField = "StatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDStatus.DataSource = dt;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsHoliday(DateTime originalDate)
        {
            string DateString = originalDate.ToString("dd/MM/yyyy");
            switch (DateString)
            {
                case "23/03/2017":
                    return false;
                case "01/05/2017":
                    return false;
                case "26/06/2017":
                    return false;
                case "27/06/2017":
                    return false;
                case "14/08/2017":
                    return false;
                case "01/09/2017":
                    return false;
                case "02/09/2017":
                    return false;
                case "29/09/2017":
                    return false;
                case "30/09/2017":
                    return false;
                case "01/12/2017":
                    return false;
                case "25/12/2017":
                    return false;
                default:
                    return true;
            }


            return false;
        }

        #endregion

        #region "Helping Function for Additional Forms"

        public void LoadThirdPartyType(RadComboBox ddP)
        {
            try
            {
                dynamic dt = objBSS.GetThirdPartyType();

                if (dt.Rows.Count > 0)
                {
                    ddP.DataTextField = "ThirdPartyName";
                    ddP.DataValueField = "ThirdPartyID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    ddP.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCircuitOwner(RadComboBox ddP)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitOwner();

                if (dt.Rows.Count > 0)
                {
                    ddP.DataTextField = "CircuitOwnerName";
                    ddP.DataValueField = "OwnerID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    ddP.DataSource = dt;
                    ddP.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "SD Panel"

        public void loadODF(RadComboBox combo, int CityID, int ODFTypeID, int NodeID)
        {
            try
            {
                dynamic dt = objBSS.GetODF(CityID, ODFTypeID, NodeID);

                if (dt.Rows.Count > 0)
                {
                    combo.DataTextField = "ODFName";
                    combo.DataValueField = "ODFID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    combo.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadTaskForce(RadComboBox DDSplicer, string Desgination, int RegionID)
        {
            try
            {
                dynamic dt = objBSS.GetTaskForce("", Desgination, RegionID);

                if (dt.Rows.Count > 0)
                {
                    DDSplicer.DataTextField = "Name";
                    DDSplicer.DataValueField = "TaskForceID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSplicer.DataSource = dt;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadODFPortbyODFID(RadComboBox DDODFPort, int ODFID, string Flag)
        {
            try
            {
                dynamic dt = objBSS.GetODFPortsbyODFID(ODFID, Flag);
                if (dt.Rows.Count > 0)
                {
                    DDODFPort.DataTextField = "PortNo";
                    DDODFPort.DataValueField = "PortID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDODFPort.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadSLA(RadComboBox DDODFSLA)
        {
            try
            {
                dynamic dt = objBSS.GetSLA();
                if (dt.Rows.Count > 0)
                {
                    DDODFSLA.DataTextField = "SLA";
                    DDODFSLA.DataValueField = "SLAID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDODFSLA.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadInterface(RadComboBox DDInterface)
        {
            try
            {
                dynamic dt = objBSS.GetInterface();
                if (dt.Rows.Count > 0)
                {
                    DDInterface.DataTextField = "Interface";
                    DDInterface.DataValueField = "InterfaceID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDInterface.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadInfraMedium(RadComboBox DDODFPort, int InfraMediumID)
        {
            try
            {
                dynamic dt = objBSS.GetInfraMedium(InfraMediumID);
                if (dt.Rows.Count > 0)
                {
                    DDODFPort.DataTextField = "InfraMedium";
                    DDODFPort.DataValueField = "InfraMediumID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDODFPort.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadODFTraybyODFID(RadComboBox DDODFTray, int ODFID)
        {
            try
            {
                dynamic dt = objBSS.GetODFTraybyODFID(ODFID);
                if (dt.Rows.Count > 0)
                {
                    DDODFTray.DataTextField = "ODFTray";
                    DDODFTray.DataValueField = "ODFTrayID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDODFTray.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadNo_ofTray(RadComboBox DDONo_ofTray)
        {
            try
            {
                dynamic dt = objBSS.GetNo_ofTray();
                if (dt.Rows.Count > 0)
                {
                    DDONo_ofTray.DataTextField = "No_of_ODFTray";
                    DDONo_ofTray.DataValueField = "No_of_ODFTrayID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDONo_ofTray.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadODFType(RadComboBox DDODFType)
        {
            try
            {
                dynamic dt = objBSS.GetODFType();
                if (dt.Rows.Count > 0)
                {
                    DDODFType.DataTextField = "ODFType";
                    DDODFType.DataValueField = "ODFTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDODFType.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "IP-NOC Module"

        public void loadRing(RadComboBox DD, int CityID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetRingByCity(CityID, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RingName";
                    DD.DataValueField = "RingID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
                else
                {
                    DD.DataSource = null;
                    DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void loadSwitchPortCapacity(RadComboBox DDSwitchPortCapacity)
        {
            try
            {
                dynamic dt = objBSS.GetSwitchPortCapacity();
                if (dt.Rows.Count > 0)
                {
                    DDSwitchPortCapacity.DataTextField = "SwitchPortCapacity";
                    DDSwitchPortCapacity.DataValueField = "SwitchPortCapacityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSwitchPortCapacity.DataSource = dt;

                }
                else
                {
                    DDSwitchPortCapacity.DataSource = null;
                    DDSwitchPortCapacity.DataBind();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadSwitches(RadComboBox DDSwitch, int NodeID, int SwitchId, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetSwitches(SwitchId, IsActive, NodeID);
                if (dt.Rows.Count > 0)
                {
                    DDSwitch.DataTextField = "SwitchName";
                    DDSwitch.DataValueField = "SwitchID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSwitch.DataSource = dt;
                    DDSwitch.DataBind();
                }
                else
                {
                    DDSwitch.DataSource = null;
                    DDSwitch.DataBind();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadSwitchedPorts(RadComboBox DDSw, int SwitchID, string flag)
        {
            try
            {
                dynamic dt = objBSS.GetSwitchPortsbySwitchID(SwitchID, flag);
                if (dt.Rows.Count > 0)
                {
                    DDSw.DataTextField = "SwitchPort";
                    DDSw.DataValueField = "SwitchPortID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSw.DataSource = dt;
                    DDSw.DataBind();
                }
                else
                {
                    DDSw.DataSource = null;
                    DDSw.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadModel(RadComboBox DDmodel, int ModelID, string ModelType, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetModel(ModelID, ModelType, IsActive, " ");
                if (dt.Rows.Count > 0)
                {
                    DDmodel.DataTextField = "ModelName";
                    DDmodel.DataValueField = "ModelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDmodel.DataSource = dt;
                }
                else
                {
                    DDmodel.DataSource = null;
                    DDmodel.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCPEWavelength(RadComboBox DDCPEWavelength)
        {
            try
            {
                dynamic dt = objBSS.GetCPEWaveLength();
                if (dt.Rows.Count > 0)
                {
                    DDCPEWavelength.DataTextField = "CPEWavelength";
                    DDCPEWavelength.DataValueField = "CPEWavelengthID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCPEWavelength.DataSource = dt;
                }
                else
                {
                    DDCPEWavelength.DataSource = null;
                    DDCPEWavelength.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCPEType(RadComboBox DDCPEType)
        {
            try
            {
                dynamic dt = objBSS.GetCPEType();
                if (dt.Rows.Count > 0)
                {
                    DDCPEType.DataTextField = "CPEType";
                    DDCPEType.DataValueField = "CPETypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCPEType.DataSource = dt;
                }
                else
                {
                    DDCPEType.DataSource = null;
                    DDCPEType.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadFeedType(RadComboBox DDFeedType)
        {
            try
            {
                dynamic dt = objBSS.GetFeedType();
                if (dt.Rows.Count > 0)
                {
                    DDFeedType.DataTextField = "FeedType";
                    DDFeedType.DataValueField = "FeedTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDFeedType.DataSource = dt;
                }
                else
                {
                    DDFeedType.DataSource = null;
                    DDFeedType.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRouterType(RadComboBox DDRouterType)
        {
            try
            {
                dynamic dt = objBSS.GetRouterType();
                if (dt.Rows.Count > 0)
                {
                    DDRouterType.DataTextField = "RouterType";
                    DDRouterType.DataValueField = "RouterTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDRouterType.DataSource = dt;
                }
                else
                {
                    DDRouterType.DataSource = null;
                    DDRouterType.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRouter(RadComboBox DDRouter, int RouterID, int RouterTypeID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetRouter(RouterID, RouterTypeID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDRouter.DataTextField = "RouterName";
                    DDRouter.DataValueField = "RouterID";
                    DataRow dr = dt.NewRow();
                    dr[1] = 0;
                    dr[3] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDRouter.DataSource = dt;

                }
                else
                {
                    DDRouter.DataSource = null;
                    DDRouter.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadVRF(RadComboBox DDVRF, int VRFID, int ServiceUnitID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetVRF(VRFID, ServiceUnitID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDVRF.DataTextField = "VRFName";
                    DDVRF.DataValueField = "VRFID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDVRF.DataSource = dt;

                }
                else
                {
                    DDVRF.DataSource = null;
                    DDVRF.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadOperation(RadComboBox DDOperation, int OperationID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetOperation(OperationID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDOperation.DataTextField = "OperationName";
                    DDOperation.DataValueField = "OperationID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDOperation.DataSource = dt;

                }
                else
                {
                    DDOperation.DataSource = null;
                    DDOperation.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadNode(RadComboBox DDAreaNode, int CityID, int RingID, string Node)
        {
            try
            {
                dynamic dt = objBSS.GetNode(0, CityID, RingID, 1, Node);

                if (dt.Rows.Count > 0)
                {
                    DDAreaNode.DataTextField = "Node";
                    DDAreaNode.DataValueField = "NodeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDAreaNode.DataSource = dt;
                    DDAreaNode.DataBind();
                }
                else
                {
                    DDAreaNode.DataSource = null;
                    DDAreaNode.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadODUMount(RadComboBox DDMount)
        {
            try
            {
                dynamic dt = objBSS.GetODUMount();
                if (dt.Rows.Count > 0)
                {
                    DDMount.DataTextField = "MountOn";
                    DDMount.DataValueField = "MountOnID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDMount.DataSource = dt;

                }
                else
                {
                    DDMount.DataSource = null;
                    DDMount.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadIpStatus(RadComboBox DDIpStatus)
        {
            try
            {
                dynamic dt = objBSS.GetIPStatus();
                if (dt.Rows.Count > 0)
                {
                    DDIpStatus.DataTextField = "IpStatus";
                    DDIpStatus.DataValueField = "IpStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDIpStatus.DataSource = dt;

                }
                else
                {
                    DDIpStatus.DataSource = null;
                    DDIpStatus.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadTopology(RadComboBox DDLS)
        {
            try
            {
                dynamic dt = objBSS.GetTopology();
                if (dt.Rows.Count > 0)
                {
                    DDLS.DataTextField = "Topology";
                    DDLS.DataValueField = "TopologyID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDLS.DataSource = dt;

                }
                else
                {
                    DDLS.DataSource = null;
                    DDLS.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCircuitMode(RadComboBox DDLS)
        {
            try
            {
                dynamic dt = objBSS.GetCircuitMode();
                if (dt.Rows.Count > 0)
                {
                    DDLS.DataTextField = "CircuitMode";
                    DDLS.DataValueField = "CircuitModeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDLS.DataSource = dt;

                }
                else
                {
                    DDLS.DataSource = null;
                    DDLS.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadOLT(RadComboBox DDOLT, int OLTID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetOLT(OLTID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDOLT.DataTextField = "OLT";
                    DDOLT.DataValueField = "OLTID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDOLT.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCPEModel(RadComboBox DDOLT, int CPETypeID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetCPEModel(CPETypeID, " ", IsActive, "Useless Parameter");
                if (dt.Rows.Count > 0)
                {
                    DDOLT.DataTextField = "CPEModel";
                    DDOLT.DataValueField = "CPEModelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[3] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDOLT.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region "Transmission"

        public void loadPortSpeed(RadComboBox DDPortSpeed, int PortSpeedID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetPortSpeed(PortSpeedID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDPortSpeed.DataTextField = "PortSpeed";
                    DDPortSpeed.DataValueField = "PortSpeedID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDPortSpeed.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadEquipment(RadComboBox DDEquipment, int EquipmentID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetEquipment(EquipmentID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDEquipment.DataTextField = "Equipment";
                    DDEquipment.DataValueField = "EquipmentID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDEquipment.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCapacity(RadComboBox DDCapacity, int CapacityID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetCapacity(CapacityID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DDCapacity.DataTextField = "Capacity";
                    DDCapacity.DataValueField = "CapacityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDCapacity.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPortType(RadComboBox DDPortType)
        {
            try
            {
                dynamic dt = objBSS.GetPortType();
                if (dt.Rows.Count > 0)
                {
                    DDPortType.DataTextField = "PortType";
                    DDPortType.DataValueField = "PortTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDPortType.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadTxnInterface(RadComboBox DDInterface)
        {
            try
            {
                dynamic dt = objBSS.GetTxnInterface();
                if (dt.Rows.Count > 0)
                {
                    DDInterface.DataTextField = "Interface";
                    DDInterface.DataValueField = "InterfaceID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDInterface.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadDuplexMode(RadComboBox DDDuplexMode)
        {
            try
            {
                dynamic dt = objBSS.GetDuplexMode();
                if (dt.Rows.Count > 0)
                {
                    DDDuplexMode.DataTextField = "DuplexMode";
                    DDDuplexMode.DataValueField = "DuplexModeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDDuplexMode.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadSDH(RadComboBox DDSDH)
        {
            try
            {
                dynamic dt = objBSS.GetSDH();
                if (dt.Rows.Count > 0)
                {
                    DDSDH.DataTextField = "SDH";
                    DDSDH.DataValueField = "SDHID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDSDH.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadStatus(RadComboBox DDStatus)
        {
            try
            {
                dynamic dt = objBSS.GetStatus();
                if (dt.Rows.Count > 0)
                {
                    DDStatus.DataTextField = "Status";
                    DDStatus.DataValueField = "StatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDStatus.DataSource = dt;
                    DDStatus.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadLMMediInfo(RadComboBox DDLmMediInfo)
        {
            try
            {
                dynamic dt = objBSS.GetLMMediaInfo();
                if (dt.Rows.Count > 0)
                {
                    DDLmMediInfo.DataTextField = "LMMediaInfo";
                    DDLmMediInfo.DataValueField = "LMMediaInfoID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDLmMediInfo.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region "Cloud Computing"

        public void loadRAM(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetRAM(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RAM";
                    DD.DataValueField = "RAMID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadProcessorSpeed(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetProcessorSpeed(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ProcessorSpeed";
                    DD.DataValueField = "ProcessorSpeedID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadCloudType(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetCloudType(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "CloudType";
                    DD.DataValueField = "CloudTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadOS(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetOS(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "OSName";
                    DD.DataValueField = "OSID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPackageType(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetPackageType(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PackageName";
                    DD.DataValueField = "PackageTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadStorageType(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetStorageType(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Storage";
                    DD.DataValueField = "StorageTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadSoftware(RadComboBox DD, int IsActive, string SWType)
        {
            try
            {
                dynamic dt = objBSS.GetSoftware(SWType, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "SWName";
                    DD.DataValueField = "SWID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void loadVMHost(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetVMHost(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "VMHost";
                    DD.DataValueField = "VMHostID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void loadServerLocation(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetDCLocation(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "DCLocation";
                    DD.DataValueField = "DCLocID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void loadServerPool(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetServerpool(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ServerPool";
                    DD.DataValueField = "ServerPoolID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void loadFreqency(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetFrequency(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Frequency";
                    DD.DataValueField = "FrequencyID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Data Center"

        public void loadDCLocation(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetDCLocation(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "DCLocation";
                    DD.DataValueField = "DCLocID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPDUModule(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetPDUModels(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PDUModel";
                    DD.DataValueField = "PDUModelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPDUCapacity(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetPDUCapacity(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PDUCapacity";
                    DD.DataValueField = "PDUCapacityID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPDUStatus(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetDCStatus();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Status";
                    DD.DataValueField = "StatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRackCapacity(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetRackCapacity(1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RacksCapacity";
                    DD.DataValueField = "RacksID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRackModels(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetRackModels(1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RackModel";
                    DD.DataValueField = "RackModelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRackMeasuringUnit(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetRackMeasuringUnit(1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "MeasuringUnit";
                    DD.DataValueField = "MeasuringUnitID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRackPowerFeed(RadComboBox DD, int IsActive)
        {
            try
            {
                DataTable dt = objBSS.GetRackPowerFeed(1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PowerFeed";
                    DD.DataValueField = "PowerFeedID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadPDU(RadComboBox DD, int IsActive, int RAckID)
        {
            try
            {
                DataTable dt = objBSS.SearchPDU("", 0, 0, RAckID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PDUName";
                    DD.DataValueField = "PDUID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadRack(RadComboBox DD)
        {
            try
            {
                DataTable DTRack = objBSS.SearchRack(0, "", 0, 0, 1);
                if (DTRack.Rows.Count > 0)
                {
                    DD.DataTextField = "RackName";
                    DD.DataValueField = "RackID";
                    DataRow dr = DTRack.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    DTRack.Rows.InsertAt(dr, 0);
                    DD.DataSource = DTRack;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region "OTS"

        public void loadTicketType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetTicketType();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "TicketType";
                    DD.DataValueField = "TicketCode";
                    DataRow dr = dt.NewRow();
                    dr[2] = "N/A";
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadAssignedDepartment(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetAssignedDepartment();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Department";
                    DD.DataValueField = "DepartmentID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadProblemDignosedAt(RadComboBox DD, int AssignDeptID)
        {
            try
            {
                dynamic dt = objBSS.GetProblemDignosedAt(AssignDeptID);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ProblemDignosedAt";
                    DD.DataValueField = "ProblemDignosedAtID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadComplainStatus(RadComboBox DD, string Flag)
        {
            try
            {
                dynamic dt = objBSS.GetComplainStatus(Flag);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplainStatus";
                    DD.DataValueField = "ComplainStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; 
                    DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadComplaintReportedVia(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetComplaintReportedVia();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplaintReportedVia";
                    DD.DataValueField = "ComplaintReportedViaID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCaseCategory(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetCaseCategory();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "CaseCategory";
                    DD.DataValueField = "CaseCategoryID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadPocStatus(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetPocStatus();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PocStatus";
                    DD.DataValueField = "PocStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadComplainType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetComplainType();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplainType";
                    DD.DataValueField = "ComplainTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadInitialStatement(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetInitialStatement();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "InitailStatement";
                    DD.DataValueField = "InitialStatementID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCustBandwidthIssue(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetCustBandwidthIssue();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "BandwidthIssue";
                    DD.DataValueField = "BandwidthIssue";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

           public void CreateDynamicRadioButton(string OptionType, Panel panel)
           {
               try
               {
                   RadioButtonList rb = new RadioButtonList();
                   rb.RepeatDirection = RepeatDirection.Horizontal;
                   RadioButton[] radioButtons = new RadioButton[9];
                   dynamic dt = objBSS.GetDignosesOptionValues(1, OptionType);

                   if (dt.Rows.Count != 0)
                   {
                       for (int i = 0; i <= dt.Rows.Count - 1; i++)
                       {
                           rb.Items.Add("rd" + OptionType + "_" + dt.Rows[i]["OptionValue"]);
                           rb.Items[i].Text = dt.Rows[i]["OptionValue"];
                           //radioButtons[i] = new RadioButton();
                           //radioButtons[i].Text = dt.Rows[i]["OptionValue"];
                           //radioButtons[i].ID = "rd" + OptionType + "_" + dt.Rows[i]["OptionValue"];
                           //radioButtons[i]. = new System.Drawing.Point(1 + i * 110, -1);
                           //panel.Controls.Add(radioButtons[i]);
                           

                       }
                       panel.Controls.Add(rb);
                   }

               }
               catch (Exception ex)
               {
               }
           }

           public void CreateDynamicRadioButtonOnView(string OptionType, Panel panel, string val)
           {
               try
               {
                   RadioButtonList rb = new RadioButtonList();
                   rb.RepeatDirection = RepeatDirection.Horizontal;
                   RadioButton[] radioButtons = new RadioButton[9];
                   //System.Windows.Forms.RadioButton[] radioButtons = new System.Windows.Forms.RadioButton[9];
                   dynamic dt = objBSS.GetDignosesOptionValues(1, OptionType);

                   if (dt.Rows.Count != 0)
                   {
                       for (int i = 0; i <= dt.Rows.Count - 1; i++)
                       {
                           rb.Items.Add("rd" + OptionType + "_" + dt.Rows[i]["OptionValue"]);
                           rb.Items[i].Text = dt.Rows[i]["OptionValue"];
                           //radioButtons(i) = new RadioButton();
                           //radioButtons(i).Text = dt.Rows(i)("OptionValue");
                          // radioButtons(i).Name = "rd" + OptionType + "_" + dt.Rows(i)("OptionValue");
                           //radioButtons(i).Location = new System.Drawing.Point(1 + i * 110, -1);
                          // panel.Controls.Add(radioButtons(i));
                           if (rb.Items[i].Text == val)
                           {
                               rb.Items[i].Selected = true;
                           }

                       }
                   }

               }
               catch (Exception ex)
               {
               }
           }

        public void LoadReasonOutage(RadComboBox DD, int ProblemDignoseID, int InfraID, int DepartmentID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetReasonOfOutage(ProblemDignoseID, InfraID, DepartmentID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ReasonOutage";
                    DD.DataValueField = "ReasonOutageID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
                else
                {
                    DD.DataSource = null;
                    DD.Items.Clear();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadLoggedBy(RadComboBox DDLogged)
        {
            try
            {
                dynamic dt = objBSS.GetLoggedBy();

                if (dt.Rows.Count > 0)
                {
                    DDLogged.DataTextField = "LoggedBy";
                    DDLogged.DataValueField = "LoggedBy";
                    DataRow dr = dt.NewRow();
                    dr[0] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DDLogged.DataSource = dt;
                    DDLogged.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "IP Ticketing"

        public void NOCTT_loadEsclatedPerson(RadComboBox DD, int RegionID)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetEscalatedPerson(0, RegionID, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "EscalatedPerson";
                    DD.DataValueField = "EscalatedPersonID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadFault(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetFault(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Fault";
                    DD.DataValueField = "FaultID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadIssueOn(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetIssueOn(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "IssueOn";
                    DD.DataValueField = "IssueOnID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadModeofTicket(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetModeofTicket(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ModeofTicket";
                    DD.DataValueField = "ModeofTicketID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadNode(RadComboBox DD, int CityId)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetTTNode(0, CityId, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "NewNode";
                    DD.DataValueField = "NodeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadRFO(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetRFO(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RFO";
                    DD.DataValueField = "RFOID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadImpact(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetImpact(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Impact";
                    DD.DataValueField = "ImpactID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadTicketOwner(RadComboBox DD, int RegionID)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetTicketOwner(0, RegionID, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "TicketOwner";
                    DD.DataValueField = "TicketOwnerID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadTicketStatus(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetTicketStatus(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "TicketStatus";
                    DD.DataValueField = "TicketStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_LoadTicketType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetTicketType(0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "TicketType";
                    DD.DataValueField = "TicketTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NOC_TT_AertEmail(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.Noctt_GetAlertEmail(0);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "EmailToName";
                    DD.DataValueField = "ID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "ICS"


        public void LoadICS_GetComplainStatus(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetComplainStatus();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplainStatus";
                    DD.DataValueField = "ComplainStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_AssignedDepartment(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_AssignedDepartment();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Department";
                    DD.DataValueField = "DepartmentID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_ComplainImpact(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_ComplainImpact();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Impact";
                    DD.DataValueField = "ImpactID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_ComplaintType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_ComplaintType(0, "", 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplaintType";
                    DD.DataValueField = "ComplaintTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_GetProblemDignoseEnd(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetProblemDignoseEnd(0, "", 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ProblemDignoseEnd";
                    DD.DataValueField = "ProblemDignoseEndID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_GetRFO(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetRFO(0, "", 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RFO";
                    DD.DataValueField = "RFOID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_GetServerityLevel(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetServerityLevel();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ServerityLevel";
                    DD.DataValueField = "ServerityLevelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_LoggedBy(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_LoggedBy();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Name";
                    DD.DataValueField = "UserID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_ModeofComplain(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_ModeofComplain(0, "", 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ModeofComplaint";
                    DD.DataValueField = "ModeofComplaintID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_ComplainOwner(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetComplainOwner();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ComplainOwner";
                    DD.DataValueField = "ComplainOwnerID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void loadICS_LinkStatus(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetICS_GetLinkStatus();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "LinkStatus";
                    DD.DataValueField = "LinkStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region "VSAT Deployment"

        public void LoadVSAT_GetVSPackage(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetVSPackages();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Package";
                    DD.DataValueField = "PackageID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadVSAT_GetModels(RadComboBox DD, string Stage)
        {
            try
            {
                dynamic dt = objBSS.GetVSATModels(Stage);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "VSModel";
                    DD.DataValueField = "VSModeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadVSAT_GetType(RadComboBox DD, int Stage)
        {
            try
            {
                dynamic dt = objBSS.GetVSATTypes(Stage);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "VSType";
                    DD.DataValueField = "VSTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "CTC"

        public void LoadCTC_GetNoticedPeriod(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetNoticedPeriod();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "NoticedPeriod";
                    DD.DataValueField = "NoticedPeriodID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCTC_GetRequestStatus(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetRequestStatus();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RequestStatus";
                    DD.DataValueField = "RequestStatusID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCTC_GetTerminationReason(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetTerminationReason();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "TerminationReason";
                    DD.DataValueField = "TerminationReasonID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCTC_GetTerminationSubReason(RadComboBox DD, int TerminationReasonID)
        {
            try
            {
                dynamic dt = objBSS.GetTerminationSubReason(TerminationReasonID);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "SubReason";
                    DD.DataValueField = "SubReasonID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region "Reports"

        public void LoadReports_ReportType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetReportType();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ReportType";
                    DD.DataValueField = "ReportTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "FLL"

        public void FLL_GetAggerationType(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetAggerationType();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "AggerationType";
                    DD.DataValueField = "AggerationTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetIPSubnet(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetIPSubnet();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Subnet";
                    DD.DataValueField = "SubnetID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetPABXModel(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.GetPABXModel();
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "PABXModel";
                    DD.DataValueField = "PABXModelID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetNumSeries(RadComboBox DD, int CityID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetNumSeries(CityID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "NumberingSeries";
                    DD.DataValueField = "SeriesID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
                else
                {
                    DD.DataSource = null;
                    DD.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetSubRegion(RadComboBox DD, int RegionID, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetSubRegion(RegionID, IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "SubRegion";
                    DD.DataValueField = "SubRegionID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
                else
                {
                    DD.DataSource = null;
                    DD.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetProductDetails(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GettProductDetails(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ProductDetails";
                    DD.DataValueField = "ProductDetailsID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetProductType(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetProductType(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "ProductType";
                    DD.DataValueField = "ProductTypeID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetRoutingProfile(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetRoutingProfile(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "RoutingProfile";
                    DD.DataValueField = "RoutingID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetVCVendor(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetVCVendor(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Vendor";
                    DD.DataValueField = "VendorID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetVAServices(RadComboBox DD, int IsActive)
        {
            try
            {
                dynamic dt = objBSS.GetVAServices(IsActive);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "VAS";
                    DD.DataValueField = "VASID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FLL_GetCoiceVPE(RadComboBox DD)
        {
            try
            {
                dynamic dt = objBSS.SearchVCInventory("", "", 0, 1);
                if (dt.Rows.Count > 0)
                {
                    DD.DataTextField = "Name";
                    DD.DataValueField = "VCID";
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "Please-Select";
                    dt.Rows.InsertAt(dr, 0);
                    DD.DataSource = dt; DD.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}