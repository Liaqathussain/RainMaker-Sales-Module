
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using RainMaker.Classes;
namespace RainMaker
{
    public class MethodCalling
    {
       
        clsDBAccess objBSS = new clsDBAccess("Password=Multi!@#$%;Persist Security Info=True;User ID=apps_admin;Initial Catalog=BSS;Data Source=202.141.239.197", DBEngineType.SQL);
        clsDBAccess objMidd = new clsDBAccess("Password=P@kistan;Persist Security Info=True;User ID=sa;Initial Catalog=BSS;Data Source=103.31.80.118\\APPDB", DBEngineType.SQL);
        DataTable dt_DL;
        DataTable dt_12;
        DataTable dt_DS;
        DataTable dt_DR;
        //------Complain Analysis---------
        DataTable dt_CD;
        DataTable dt_CPD;
        DataTable dt_Tr;
        DataTable dt_CC;
        DataTable dt_CViC;
        DataTable dt_CF;
        DataTable dt_CVD;
        DataTable dt_COL;
        DataTable dt_CDT;
        DataTable dt_CR;
        DataTable dt_CSRFO;
        //------Smart Search---------

        DataTable dt_SS;

        #region "Customer Analysis"

        public DataTable GetDeploymentMainDetails()
        {

            DataTable dt_MD = new DataTable();
            try
            {
                if (dt_MD == null)
                {
                    dt_MD = new DataTable();
                }
                dt_MD = objBSS.SP_Datatable("sp_Dash_GetDeploymentMainDetails");
                dt_MD.TableName = "sp_Dash_GetDeploymentMainDetails";
                return dt_MD;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetDeployofLast12Months()
        {
            try
            {
                if (dt_12 == null)
                {
                    dt_12 = new DataTable();
                }
                dt_12 = objBSS.SP_Datatable("sp_Dash_GetDeployofLast12Months");
                dt_12.TableName = "sp_Dash_GetDeployofLast12Months";
                return dt_12;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetDeploymentViaService()
        {
            try
            {
                if (dt_DS == null)
                {
                    dt_DS = new DataTable();
                }
                dt_DS = objBSS.SP_Datatable("sp_Dash_GetDeployViaService");
                dt_DS.TableName = "sp_Dash_GetDeployViaService";
                return dt_DS;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetDeploymentViaRegion()
        {
            try
            {
                if (dt_DR == null)
                {
                    dt_DR = new DataTable();
                }

                dt_DR = objBSS.SP_Datatable("sp_Dash_GetDeployViaRegion");
                dt_DR.TableName = "sp_Dash_GetDeployViaRegion";
                return dt_DR;


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetDeploymentViaLOB()
        {


            try
            {
                if (dt_DL == null)
                {
                    dt_DL = new DataTable();
                }
                dt_DL = objBSS.SP_Datatable("sp_Dash_GetDeployCountViaLOB");
                dt_DL.TableName = "sp_Dash_GetDeployCountViaLOB";
                return dt_DL;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }


        #endregion

        #region "Complain Analysis"

        public DataTable GetComplainDetails(int AssigDeptID)
        {


            try
            {
                if (dt_CD == null)
                {
                    dt_CD = new DataTable();
                }

                string[,] para = { {
				"@ASsginDepartID",
				AssigDeptID.ToString()
			} };
                dt_CD = objBSS.SP_Datatable("sp_Dash_GetCompDetails", para);
                dt_CD.TableName = "sp_Dash_GetCompDetails";
                return dt_CD;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainDetailsviaDepart()
        {

            try
            {
                if (dt_CPD == null)
                {
                    dt_CPD = new DataTable();
                }

                dt_CPD = objBSS.SP_Datatable("sp_Dash_GetCompViaDepartment");
                dt_CPD.TableName = "sp_Dash_GetCompViaDepartment";
                return dt_CPD;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetTigger(string Flag)
        {

            try
            {
                if (dt_Tr == null)
                {
                    dt_Tr = new DataTable();
                }

                string[,] para = { {
				"@Flag",
				Flag
			} };
                dt_Tr = objBSS.SP_Datatable("sp_Dash_GetComplainsTigger", para);
                dt_Tr.TableName = "sp_Dash_GetComplainsTigger";
                return dt_Tr;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainCount(int ComplaintStatusID, int AssignedDeptID)
        {


            try
            {
                if (dt_CC == null)
                {
                    dt_CC = new DataTable();
                }


                string[,] para = {
				{
					"@ComplaintStatusID",
					ComplaintStatusID.ToString()
				},
				{
					"@AssignedDeptID",
					AssignedDeptID.ToString()
				}
			};
                dt_CC = objBSS.SP_Datatable("sp_Dash_GetComplainCount", para);
                dt_CC.TableName = "sp_Dash_GetComplainCount";
                return dt_CC;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainsViaCustomer()
        {

            try
            {
                if (dt_CViC == null)
                {
                    dt_CViC = new DataTable();
                }
                dt_CViC = objBSS.SP_Datatable("sp_Dash_GetComplainsViaCustomer");
                dt_CViC.TableName = "sp_Dash_GetComplainsViaCustomer";
                return dt_CViC;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainsViaInfra()
        {


            try
            {
                if (dt_CF == null)
                {
                    dt_CF = new DataTable();
                }
                dt_CF = objBSS.SP_Datatable("sp_Dash_GetComplainsViaInfra");
                dt_CF.TableName = "sp_Dash_GetComplainsViaInfra";
                return dt_CF;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetCompViaDownTimeViaDept(int AssigDeptID)
        {

            try
            {
                if (dt_CVD == null)
                {
                    dt_CVD = new DataTable();
                }
                string[,] para = { {
				"@AssigDeptID",
				AssigDeptID.ToString()
			} };
                dt_CVD = objBSS.SP_Datatable("sp_Dash_GetCompViaDownTimeViaDept", para);
                dt_CVD.TableName = "sp_Dash_GetCompViaDownTimeViaDept";
                return dt_CVD;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetCompDetailsOnLabelClick(int RegionID, string AgingFlag, int AssginDepartID)
        {
            try
            {
                if (dt_COL == null)
                {
                    dt_COL = new DataTable();
                }
                string[,] para = {
				{
					"@RegionID",
					RegionID.ToString()
				},
				{
					"@AgingFlag",
					AgingFlag
				},
				{
					"@AssginDepartID",
					AssginDepartID.ToString()
				}
			};
                dt_COL = objBSS.SP_Datatable("sp_Dash_GetCompDetailsOnLabelClick", para);
                dt_COL.TableName = "sp_Dash_GetCompDetailsOnLabelClick";
                return dt_COL;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainsViaDownTime()
        {

            try
            {
                if (dt_CDT == null)
                {
                    dt_CDT = new DataTable();
                }
                dt_CDT = objBSS.SP_Datatable("sp_Dash_GetComplainsViaDownTime");
                dt_CDT.TableName = "sp_Dash_GetComplainsViaDownTime";
                return dt_CDT;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainsViaRegion()
        {

            try
            {
                if (dt_CR == null)
                {
                    dt_CR = new DataTable();
                }
                dt_CR = objBSS.SP_Datatable("sp_Dash_GetComplainsViaRegion");
                dt_CR.TableName = "sp_Dash_GetComplainsViaRegion";
                return dt_CR;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        public DataTable GetComplainSolvedViaRFO()
        {

            try
            {
                if (dt_CSRFO == null)
                {
                    dt_CSRFO = new DataTable();
                }
                dt_CSRFO = objBSS.SP_Datatable("sp_Dash_GetComplainSolvedViaRFO");
                dt_CSRFO.TableName = "sp_Dash_GetComplainSolvedViaRFO";
                return dt_CSRFO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        #endregion

        #region "Smart Search"

        public DataTable GetComplainsViaSmartSearch(string Detail)
        {


            try
            {
                if (dt_SS == null)
                {
                    dt_SS = new DataTable();
                }

                string[,] para = { {
				"@Detail",
				Detail
			} };
                dt_SS = objBSS.SP_Datatable("sp_Dash_GetComplainsViaSmartSearch", para);
                dt_SS.TableName = "sp_Dash_GetComplainsViaSmartSearch";
                return dt_SS;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
            }

        }

        #endregion








    }

}