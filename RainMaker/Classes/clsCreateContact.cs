using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RainMaker.Classes
{
    public class clsCreateContact
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;



        public clsCreateContact()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }


        public object CreateContact(int CustomerCode, string Prefix, string FirstName, string LastName, string Department, string CNIC, string JobTitle, string MobilePhone, string WorkPhone, string Email, string Address, int City, string State, int Country, string PinCode, string Gender, string Religion, string ContactType, int IsFav, int IsActive)
        {
            dynamic[,] para = { 
                                { "@CustomerCode", CustomerCode },
                                { "@Prefix", Prefix },
                                { "@FirstName", FirstName },
                                { "@LastName", LastName },
                                { "@Department", Department },
                                { "@CNIC", CNIC  },
                                { "@JobTitle", JobTitle },
                                { "@MobilePhone", MobilePhone },
                                { "@WorkPhone", WorkPhone },       
                                { "@Email", Email },
                                { "@Address" , Address},
                                { "@City", City},
                                { "@State",State},
                                { "@Country", Country},
                                { "@PinCode", PinCode},
                                { "@Gender", Gender},
                                { "@Religion", Religion},
                                { "@ContactType", ContactType},
                                { "@IsFav", IsFav},
                                { "@IsActive", IsActive}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_InsertCustomerContact", para);
            return objectCustomerID;
        }

        public void UpdateContact(int ContactID, int CustomerCode, string FirstName, string LastName, string Prefix , string Department,  string CNIC , string JobTitle, string MobilePhone, string WorkPhone, string Email, string Address, string City, string State, string Country, string PinCode, string Gender, string Religion, string ContactType, int IsFav, int IsActive)
        {
            dynamic[,] para = { 
                                { "@ContactID", ContactID },
                                { "@CustomerCode", CustomerCode },                                
                                { "@FirstName", FirstName },
                                { "@LastName", LastName },
                                { "@Prefix", Prefix },
                                { "@Department", Department },
                                { "@CNIC", CNIC },
                                { "@JobTitle", JobTitle },
                                { "@MobilePhone", MobilePhone },
                                { "@WorkPhone", WorkPhone },       
                                { "@Email", Email },
                                { "@Address" , Address},
                                { "@City", City},
                                { "@State",State},
                                { "@Country", Country},
                                { "@PinCode", PinCode},
                                { "@Gender", Gender},
                                { "@Religion", Religion},
                                { "@ContactType", ContactType},
                                { "@IsFav", IsFav},
                                { "@IsActive", IsActive}
            
                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectContactID = objDBAcess.executeProc("sp_UpdateCustomerContacts", para);
            
        }


    }





}