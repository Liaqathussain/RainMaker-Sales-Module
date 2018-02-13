using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsOpportunity
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;


        public clsOpportunity()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        /*public object CreateOpportunity(string OppName, string PartnerID, string CustCode, string ContactID, string KAMID, string WinProbability, string CurrencyID, string StageID, int StatusID
            , int IsActive, string IsBudgetaryQuote, string BudgetaryQuoteDate, string BudgetaryQuoteAmount
            , string QuoteProposalDate, string NegotiatedMMR, string NegotiatedAmount, string NegotiatedRevenue)*/

        //    public object CreateOpportunity(string OppName, string PartnerID, string CustCode, string ContactID, string KAMID, string WinProbability, string CurrencyID, string StageID, int StatusID
        //    , int IsActive)
        //{
        //    //dynamic[,] para = { 
        //    //                    { "@OppName", OppName },
        //    //                    { "@PartnerID", PartnerID },
        //    //                    { "@CustCode", CustCode },
        //    //                    { "@ContactID", ContactID },
        //    //                    { "@KAMID", KAMID },
        //    //                    { "@WinProbability", WinProbability },       
        //    //                    { "@CurrencyID", CurrencyID },
        //    //                    { "@StageID" , StageID},
        //    //                    { "@StatusID", StatusID},
        //    //                    { "@IsActive", IsActive},
        //    //                    { "@IsBudgetaryQuote", IsBudgetaryQuote},
        //    //                    { "@BudgetaryQuoteDate", BudgetaryQuoteDate},
        //    //                    { "@BudgetaryQuoteAmount", BudgetaryQuoteAmount},
        //    //                    { "@QuoteProposalDate", QuoteProposalDate},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},
        //    //                    { "@NegotiatedAmount", NegotiatedAmount},
        //    //                    { "@NegotiatedRevenue", NegotiatedRevenue},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},

        //    //                 };

        //    dynamic[,] para = { 
        //                        { "@OppName", OppName },
        //                        { "@PartnerID", PartnerID },
        //                        { "@CustCode", CustCode },
        //                        { "@ContactID", ContactID },
        //                        { "@KAMID", KAMID },
        //                        { "@WinProbability", WinProbability },       
        //                        { "@CurrencyID", CurrencyID },
        //                        { "@StageID" , StageID},
        //                        { "@StatusID", StatusID},
        //                        { "@IsActive", IsActive},                             

        //                     };

        //    clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        //    object objectCustomerID = objDBAcess.executeProc("sp_InsertOpportunity", para);
        //    return objectCustomerID;
        //}

        public object CreateOpportunity(string OppName,string LOB_ID, int StageID,int PartnerID,int CustCode,int ContactID, string WinProbability,int KAMID, int WorkingBy, string Attachment1,int LastUpdateBy  )
        {

            dynamic[,] para = { 
                                { "@OppName", OppName },
                                { "@LOB_ID", LOB_ID },
                                { "@PartnerID", PartnerID },                                
                                { "@CustCode", CustCode },
                                { "@PartnerContactID", ContactID },
                                { "@KAMID",KAMID},
                                { "@WorkingBy", WorkingBy },
                                { "@WinProbability", WinProbability },
                                { "@CurrencyID", 1 },                                
                                { "@OppStageID" , StageID},
                                { "@OppStatusID" , 1},
                                { "@IsActive", 1},
                                { "@Attachment1", Attachment1}, 
                                { "@Attachment2", Attachment1}, 
                                { "@LastUpdateBy", LastUpdateBy}

                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.InsertProc_WithOutput("sp_Sales_InsertOpportunity", para, "@OppId");
            return objectOpportunityID;

        }

        public object UpdateOpportunity(int OppId, string OppName, int CustCode, int PartnerContactID, int KAMID, int WorkingBy, int CurrencyID, int OppStageID, int OppStatusID)
        {

            dynamic[,] para = { 
                                { "@OppId", OppId },
                                { "@OppName", OppName },
                                { "@CustCode", CustCode },                                
                                { "@PartnerContactID", PartnerContactID },
                                { "@KAMID", KAMID },                                
                                { "@WorkingBy" , WorkingBy},
                                { "@CurrencyID",CurrencyID},
                                { "@OppStageID",OppStageID},
                                { "@OppStatusID",OppStatusID}
                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.executeProc("sp_UpdateOpportunityMaster_New", para);
            return objectOpportunityID;

        }

        public object UpdateOpportunityEBU(int OppId, string OppName, int CustCode, int PartnerContactID, int KAMID, int WorkingBy, int CurrencyID, int OppStageID, int OppStatusID, string  WinProbibality, string GroupRTR, String  DTProposalIntDate, string OppRemarks, string NegotiationStatus, string  ProposalLastRevesionDate, string  NegotiationFollowUpDate, string NegotiationRemarks, string NegotiationResumeDate, string NegotiationHoldReason, String OrderDate, string WonLostReason, String DeploymentDate)
        {
            //String  NRFRequestDate
            dynamic[,] para = { 
                                { "@OppId", OppId },
                                { "@OppName", OppName },
                                { "@CustCode", CustCode },                                
                                { "@PartnerContactID", PartnerContactID },
                                { "@KAMID", KAMID },                                
                                { "@WorkingBy" , WorkingBy},
                                { "@CurrencyID",CurrencyID},
                                { "@OppStageID",OppStageID},
                                { "@OppStatusID",OppStatusID},
                                { "@WinProbability",WinProbibality},
                                { "@GroupRTR",GroupRTR} ,
                                {"@ProposalIntDate",DTProposalIntDate},
                                {"@Remarks",OppRemarks},
                                {"@NegotiationStatus",NegotiationStatus},
                                {"@NegotiationProposalRevisionDate",ProposalLastRevesionDate},
                                {"@NegotiationFollowUpDate",NegotiationFollowUpDate},
                                {"@NegotiationRemarks",NegotiationRemarks},
                                {"@NegotiationResumeDate",NegotiationResumeDate},
                                {"@NegotiationHoldReason",NegotiationHoldReason},
                                {"@OrderDate",OrderDate},
                                {"@OppCloseReason",WonLostReason},
                                {"@DeploymentDate",DeploymentDate}
                                
                              };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.executeProc("sp_UpdateOpportunityMaster_EBU", para);
            return objectOpportunityID;

        }
       
        public object CreateOpportunityDetails(string Site_A_Address, int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency, int OppID)
        {
            dynamic[,] para = { 
                                 
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@OppID", OppID}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.InsertProc_WithOutput("sp_Ins_OpportunityDetails_New", para, "@OppRevId");
            return objectCustomerID;
        }

        public object CreateOpportunityDetailsForProducts(int Productsid, int UOMID, int InterfaceID, int OppRevID, int TransactionBy)
        {
            dynamic[,] para = { 
                                 
                                { "@ProductID", Productsid },
                                { "@UOMID", UOMID },
                                { "@InterfaceID", InterfaceID },
                                { "@RevDelID", OppRevID},
                                {"@TransactionBy",TransactionBy}
                               
                            
                               
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_InsertRevDetails_ForProducts", para);
            return objectCustomerID;
        }
        public object CreateOpportunityDetailsEBU_ForProducts(int ProductsID, int BandWidthID, String BandwidthType, int ServiceUnitID, int InterfaceID, int MRCActual, int MRCP3, int OppRevID, int Transby)
        {
            dynamic[,] para = { 
                                 
                                { "@ProductID", ProductsID },
                                { "@BandwidthID", BandWidthID },
                                { "@BandwidthType", BandwidthType},
                                { "@ServiceUnitID", ServiceUnitID},
                                { "@InterfaceID", InterfaceID},
                                { "@OppRevID", OppRevID},
                                { "@MRCActual", MRCActual},
                                { "@MRCP3", MRCP3},
                                {"@TransactionBy",Transby}

                               
                            
                               
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objProductID = objDBAcess.InsertProc_WithOutput("sp_InsertRevDetails_ForProducts", para, "@ProductRenID");
            return objProductID;

           
        }

        public object CreateOpportunityDetailsForEBU(int OppID, int infraID, int ServiceUnitID, int RegionID, int City, int LocationCode, int BuildingID, string Site_A_Address, string Site_B_Address, string Latitude, string Longitude, int POC, int CircuitTypeID, string Remarks, int Estimated_Price, int Amount, int NRCActual, int MRCActual, int NRR, int MRR, int ROI, int TermProfit, int TermRevenue, int RecurringMarginage, int NonRecurringMargin, string NRFRequestDate, int LastUpdatedBy)
        {
            dynamic[,] para = { { "@OppID",OppID},
                                { "@InfraID", infraID }, 
                                { "@ServiceUnitID" , ServiceUnitID}, 
                                { "@RegionID" , RegionID},
                                { "@City", City },
                                { "@LocationCode", LocationCode },
                                { "@BuildingID", BuildingID },
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Lat", Latitude },
                                { "@Long", Longitude },
                                { "@POC", POC },
                                { "@CircuitTypeID", CircuitTypeID },
                                { "@Remarks", Remarks },
                                { "@Estimated_Price", Estimated_Price},
                                { "@Amount",Amount},
                                { "@NRCActual",NRCActual},
                                { "@MRCActual",MRCActual},
                                { "@NRR",NRR},
                                { "@MRR",MRR},
                                { "@LastUpdatedBy",LastUpdatedBy}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.InsertProc_WithOutput("sp_Ins_OpportunityDetails_EBU", para, "@OppRenID");
            return objectOpportunityID;

            //clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //object objectCustomerID = objDBAcess.executeProc("sp_Ins_OpportunityDetails_EBU", para);
            //return objectCustomerID;
        }

        public object UpdateOpportunityDetailsEBU(int OppID, int infraID, int ServiceUnitID, int RegionID, int City, int LocationCode, int BuildingID, string Site_A_Address, string Site_B_Address, string Latitude, string Longitude, int POC, int CircuitTypeID, string Remarks, int Estimated_Price, int Amount, int NRCActual, int MRCActual, int NRR, int MRR, int Cost_of_Additional_Equipment, int Difference, int PaybackPeriod, int PaybackPeriod35difff, int MRCOTS, int CosttoMPPL, string InfraType, string NRFCost, string TotalTAFcost, string PMRC3, string OTCP3, string NameOf3P, string NodeName, string WonLostStatus, string WinLossReason, string NRFRequestDate, int LastUpdatedBy)
        {
            dynamic[,] para = { 
                                { "@OppID", OppID }, 
                                { "@OppType",1},
                                { "@InfraID", infraID }, 
                                { "@ServiceUnitID" , ServiceUnitID}, 
                                { "@RegionID" , RegionID},
                                { "@City", City },
                                { "@LocationCode", LocationCode },
                                { "@BuildingID", BuildingID },
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Lat", Latitude },
                                { "@Long", Longitude },
                                { "@POC", POC },
                                { "@CircuitTypeID", CircuitTypeID },
                                { "@Remarks", Remarks },
                                { "@Estimated_Price", Estimated_Price},
                                { "@Amount",Amount},
                                { "@NRCActual",NRCActual},
                                { "@MRCActual",MRCActual},
                                { "@NRR",NRR},
                                { "@MRR",MRR},
                                { "@CostOfAdditionalEqp",Cost_of_Additional_Equipment},     //c
                                { "@Difference",Difference},                                //c
                                { "@PaybackPeriod",PaybackPeriod},                          //c
                                { "@PaybackPeriod35difff",PaybackPeriod35difff},            //c
                                { "@MRCOTS",MRCOTS},                                        //c
                                { "@CosttoMPPL", CosttoMPPL },                              //c
                                { "@InfraType", InfraType },
                                { "@NRFCost", NRFCost },
                                { "@TotalTAFcost", TotalTAFcost },
                                { "@MRCP3", PMRC3},
                                { "@OTCP3", OTCP3},
                                { "@NameOf3P", NameOf3P},
                                { "@NodeName", NodeName},
                                { "@WonLostStatus", WonLostStatus},
                                { "@WinLossReason",  WinLossReason},
                                { "@NRFRequestDate",  NRFRequestDate},
                                { "@LastUpdatedBy",LastUpdatedBy}

                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Update_OpportunityDetails_EBU", para);
            return objectCustomerID;
        }
        public object UpdateOpportunityDetails(int OppID,string Site_A_Address, int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency,decimal NRC_Budget,decimal MRC_Budget,decimal NRC_Cost_On_Net,decimal MRC_Cost_On_Net, decimal NRC_Cost_Off_Net, decimal MRC_Cost_Off_Net,decimal NRC_Cost_OOP,decimal MRC_Cost_OOP,string Name_of_3P,decimal NRC_Actual,decimal MRC_Actual,decimal NRR,decimal MRR,decimal ROI ,decimal Term_Profit ,decimal Term_Revenue,decimal Recurring_Margin_Percentage,decimal Non_Recurring_Margin_Percentage)
        {
            dynamic[,] para = { 
                                { "@OppID",OppID},
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@NRC_Budget", NRC_Budget},
                                { "@MRC_Budget", MRC_Budget},
                                { "@NRC_Cost_On_Net", NRC_Cost_On_Net},
                                { "@MRC_Cost_On_Net", MRC_Cost_On_Net},
                                { "@NRC_Cost_Off_Net", NRC_Cost_Off_Net},
                                { "@MRC_Cost_Off_Net", MRC_Cost_Off_Net},
                                { "@NRC_Cost_OOP", NRC_Cost_OOP},
                                { "@MRC_Cost_OOP", MRC_Cost_OOP},
                                { "@Name_of_3P", Name_of_3P},
                                { "@NRC_Actual", NRC_Actual},
                                { "@MRC_Actual", MRC_Actual},
                                { "@NRR", NRR},
                                { "@MRR", MRR},
                                { "@ROI", ROI},
                                { "@Term_Profit", Term_Profit},
                                { "@Term_Revenue", Term_Revenue},
                                { "@Recurring_Margin_Percentage", Recurring_Margin_Percentage},
                                { "@Non_Recurring_Margin_Percentage", Non_Recurring_Margin_Percentage}

                                
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Update_OpportunityDetails_New", para);
            return objectCustomerID;
        }

        public object InsertRevenueLines(int OppID, string Site_A_Address,int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency, decimal NRC_Budget, decimal MRC_Budget, decimal NRC_Cost_On_Net, decimal MRC_Cost_On_Net, decimal NRC_Cost_Off_Net, decimal MRC_Cost_Off_Net, decimal NRC_Cost_OOP, decimal MRC_Cost_OOP, string Name_of_3P, decimal NRC_Actual, decimal MRC_Actual, decimal NRR, decimal MRR, decimal ROI, decimal Term_Profit, decimal Term_Revenue, decimal Recurring_Margin_Percentage, decimal Non_Recurring_Margin_Percentage)
        {
            dynamic[,] para = { 
                                { "@OppID",OppID},
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@NRC_Budget", NRC_Budget},
                                { "@MRC_Budget", MRC_Budget},
                                { "@NRC_Cost_On_Net", NRC_Cost_On_Net},
                                { "@MRC_Cost_On_Net", MRC_Cost_On_Net},
                                { "@NRC_Cost_Off_Net", NRC_Cost_Off_Net},
                                { "@MRC_Cost_Off_Net", MRC_Cost_Off_Net},
                                { "@NRC_Cost_OOP", NRC_Cost_OOP},
                                { "@MRC_Cost_OOP", MRC_Cost_OOP},
                                { "@Name_of_3P", Name_of_3P},
                                { "@NRC_Actual", NRC_Actual},
                                { "@MRC_Actual", MRC_Actual},
                                { "@NRR", NRR},
                                { "@MRR", MRR},
                                { "@ROI", ROI},
                                { "@Term_Profit", Term_Profit},
                                { "@Term_Revenue", Term_Revenue},
                                { "@Recurring_Margin_Percentage", Recurring_Margin_Percentage},
                                { "@Non_Recurring_Margin_Percentage", Non_Recurring_Margin_Percentage}

                                
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Insert_Revenue_Lines", para);
            return objectCustomerID;
        }


        public DataTable GetAllOpportunity()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_Get_Opportunity");
            return dt_GAO;
        }
         public DataTable GetEBUOpportunity(string LOB_ID)
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            dynamic[,] para = { { "@LOB_ID", LOB_ID } };
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_Get_OpportunityEBU",para);
            return dt_GAO;
        }

        public DataTable GetOpportunityByID(int OppID)
        {
            dynamic[,] para = { 
                              {"OppID", @OppID} 
                              };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_Get_OpportunityById",para);
            return dt_GAO;
        }
        public DataTable GetOpportunityByIDEBU(int OppID)
        {
            dynamic[,] para = { 
                              {"OppID", @OppID} 
                              };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_SalesOpportunityEBU", para);
            return dt_GAO;
        }
    }
}