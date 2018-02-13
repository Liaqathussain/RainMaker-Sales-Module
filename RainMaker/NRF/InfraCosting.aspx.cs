using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;
using System.Net.Mail;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace RainMaker.NRF
{
    public partial class InfraCosting : System.Web.UI.Page
    {
        clsInfraCosting obj_clsInfraCosting = new clsInfraCosting();
        clsGeneralFunction obj_clsGeneralFunction = new clsGeneralFunction();
        clsNRFView obj_NRFView = new clsNRFView();
        BL obj_BL = new BL();
        float _Distance;
        string _City;        
        int _InfraType;
        int BuildID = 0;
        int city = 0;
        int int_AreaID = 0;
        int int_IS_Aerial = 5;
        int int_RegionID = 0;
        string str_KeyForPDF = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            _City = Convert.ToString(base.Request.QueryString["City"]);
            _Distance = float.Parse(base.Request.QueryString["Distance"]);
            _InfraType = Convert.ToInt32(base.Request.QueryString["InfraType"]);

            //txtNRFTypeError.Visible = false;
            lblNRFTypeError.Visible = false;
            if (!IsPostBack)
            {


                if (_InfraType.Equals(1))
                {
                    txtNRFType.Text = "Aerial";
                    txtNRFType.ReadOnly = true;
                    lblNRFTypeError.Text = "Aerial";
                }

                else
                {
                    txtNRFType.Text = "Burried";
                    txtNRFType.ReadOnly = true;
                    lblNRFTypeError.Text = "Burried";
                }

                if (_City.Equals("Karachi"))
                {
                    city = 1;
                }

                if (_City.Equals("Lahore"))
                {
                    city = 2;
                }

                if (_City.Equals("Islamabad"))
                {
                    city = 3;
                }


                txtROI.Text = "12";
                txtCity.Text = _City;


                cmbService.Enabled = false;
                cmbInfra.Enabled = false;
                obj_BL.getLob(cmbLOB);
                SetRegion();
                ShowBuilding();
                //ShowService();
                //ShowCapacity_Bandwidth();
                obj_BL.loadBandWidth(cmbCapacity);

                //ShowIndusry();
                obj_BL.loadBusinessType(cmbIndustry);
                //ShowLOB();

                //ShowCustomer();
                obj_BL.loadCusCode(cmbCustomerName, null, null);
                ShowArea();
                

                

                DataTable dt = obj_clsInfraCosting.GetDefaultItems(_Distance, _InfraType, BuildID, city, int_AreaID);
                Session["dt_ItemLines"] = dt;
                CalculateMRC(12);
            }
        }

        protected void grid_ItemDetail_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            grid_ItemDetail.DataSource = (DataTable)Session["dt_ItemLines"];
        }

        protected void grid_ItemDetail_InsertCommand(object source, GridCommandEventArgs e)
        {
            int RowID = e.Item.DataSetIndex;
            GridDataInsertItem edititem = (GridDataInsertItem)e.Item;
            DataTable dt_ItemLines = (DataTable)Session["dt_ItemLines"];

            string ItemCode = ((RadTextBox)edititem["ItemCode"].FindControl("tbItemCode")).Text.Trim();

            if (ItemCode == "") return;

            foreach (DataRow dr in dt_ItemLines.Rows)
            {
                if (ItemCode == (string)dr["ItemCode"])
                {
                    grid_ItemDetail.Rebind();
                    return;
                }
            }

            string ItemName = ((Label)edititem["ItemName"].FindControl("tbItemName")).Text.Trim();

            string Unit = ((Label)edititem["Unit"].FindControl("tbUnit")).Text.Trim();

            string UnitCost = ((Label)edititem["UnitCost"].FindControl("tbUnitCost")).Text.Trim();

            decimal Quantity = Convert.ToDecimal(((RadNumericTextBox)edititem["Quantity"].FindControl("tbQuantity")).Text.Trim());
            decimal Amount = Convert.ToDecimal(((RadNumericTextBox)edititem["Amount"].FindControl("tbAmount")).Text.Trim());


            dt_ItemLines.Rows.Add(ItemCode, ItemName, Unit, UnitCost, Quantity, Amount, "Insert");
            Session["dt_ItemLines"] = dt_ItemLines;

            CalculateMRC(12);


            grid_ItemDetail.Rebind();
        }


        protected void grid_ItemDetail_UpdateCommand(object source, GridCommandEventArgs e)
        {
            int RowID = e.Item.DataSetIndex;
            GridEditableItem editedItem = e.Item as GridEditableItem;
            DataTable dt_ItemLines = (DataTable)Session["dt_ItemLines"];

            decimal Quantity = Convert.ToDecimal(((RadNumericTextBox)editedItem["Quantity"].FindControl("tbQuantity")).Text.Trim());
            decimal Amount = Convert.ToDecimal(((RadNumericTextBox)editedItem["Amount"].FindControl("tbAmount")).Text.Trim());

            dt_ItemLines.Rows[RowID]["Quantity"] = Quantity;
            dt_ItemLines.Rows[RowID]["Amount"] = Amount;

            if (dt_ItemLines.Rows[RowID]["Edit"].ToString() == "")
            {
                dt_ItemLines.Rows[RowID]["Edit"] = "Update";
                Session["dt_ItemLines"] = dt_ItemLines;
            }

            CalculateMRC(12);

            grid_ItemDetail.Rebind();
        }

        protected void grid_ItemDetail_DeleteCommand(object source, GridCommandEventArgs e)
        {
            int RowID = e.Item.DataSetIndex;
            GridDataItem item = (GridDataItem)e.Item;
            DataTable dt_ItemLines = (DataTable)Session["dt_ItemLines"];

            dt_ItemLines.Rows.Remove(dt_ItemLines.Rows[RowID]);
            Session["dt_ItemLines"] = dt_ItemLines;

            CalculateMRC(12);

            grid_ItemDetail.Rebind();



        }

        protected void grid_ItemDetail_ItemCreated(object sender, GridItemEventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            DBEngineType _eDBType = new DBEngineType();
            clsDBAccess obj_clsDBAccess = new clsDBAccess(conn, _eDBType);


            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                int RowID = e.Item.DataSetIndex;
                GridEditableItem edititem = (GridEditableItem)e.Item;
                DataTable dt_ItemLines = (DataTable)Session["dt_ItemLines"];

                RadTextBox tbItemCode = (RadTextBox)edititem["ItemCode"].FindControl("tbItemCode");
                tbItemCode.AutoPostBack = true;
                tbItemCode.TextChanged += new System.EventHandler(this.tbItemCode_TextChanged);

                RadNumericTextBox tbQuantity = (RadNumericTextBox)edititem["Quantity"].FindControl("tbQuantity");
                tbQuantity.AutoPostBack = true;
                tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);

                RadNumericTextBox tbAmount = (RadNumericTextBox)edititem["Amount"].FindControl("tbAmount");
                tbAmount.AutoPostBack = true;
                tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);

                if (RowID > -1)
                {
                    if (dt_ItemLines.Rows[RowID]["ItemCode"].ToString() != "")
                    {


                        tbItemCode.ShowButton = false;
                        tbItemCode.Enabled = false;


                    }
                }
            }

            obj_clsDBAccess.DisposeConnection();
        }


        //------------------------- TEXT CHANGED EVENTS -------------------------//

        protected void tbItemCode_TextChanged(object sender, System.EventArgs e)
        {

            DataTable temp_dt;
            GridEditableItem editedItem = (sender as RadTextBox).NamingContainer as GridEditableItem;
            //Classes.ClsDatabaseManager ObjDB_MLTNT = new Classes.ClsDatabaseManager(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr_MLTNT"].ConnectionString);

            RadTextBox tbItemCode = (RadTextBox)sender;
            Label ItemDesc = editedItem["ItemName"].FindControl("tbItemName") as Label;

            Label Unit = editedItem["Unit"].FindControl("tbUnit") as Label;

            Label UnitCost = editedItem["UnitCost"].FindControl("tbUnitCost") as Label;

            RadNumericTextBox tbQuantity = editedItem["Quantity"].FindControl("tbQuantity") as RadNumericTextBox;
            RadNumericTextBox tbAmount = editedItem["Amount"].FindControl("tbAmount") as RadNumericTextBox;
            # region CommentedCode

            # endregion


            temp_dt = obj_clsInfraCosting.GetAllItemsWithItemNumber(tbItemCode.Text.Trim());



            if (temp_dt.Rows.Count > 0)
            {
                ItemDesc.Text = temp_dt.Rows[0]["ItemName"].ToString().Trim();

                Unit.Text = temp_dt.Rows[0]["Unit"].ToString().Trim();

                UnitCost.Text = temp_dt.Rows[0]["UnitCost"].ToString().Trim();

                tbQuantity.Text = "0";
                tbAmount.Text = "0.00";

                tbQuantity.Enabled = true;
                tbAmount.Enabled = false;


            }
            else
            {
                tbItemCode.Text = "";
                ItemDesc.Text = "";

                Unit.Text = "";

                UnitCost.Text = "";
                tbQuantity.Text = "0";
                tbAmount.Text = "0.00";
                tbQuantity.Enabled = true;
                tbAmount.Enabled = true;
            }

            //ObjDB_MLTNT.DisposeConnection();
        }

        protected void tbQuantity_TextChanged(object sender, System.EventArgs e)
        {
            GridEditableItem editedItem = (sender as RadNumericTextBox).NamingContainer as GridEditableItem;
            RadNumericTextBox tbQuantity = editedItem["Quantity"].FindControl("tbQuantity") as RadNumericTextBox;
            RadNumericTextBox tbAmount = editedItem["Amount"].FindControl("tbAmount") as RadNumericTextBox;
            Label UnitCost = editedItem["UnitCost"].FindControl("tbUnitCost") as Label;
            if (UnitCost.Text == "") return;
            tbAmount.Text = (Convert.ToDecimal(tbQuantity.Text) * Convert.ToDecimal(UnitCost.Text)).ToString();



        }

        protected void tbAmount_TextChanged(object sender, System.EventArgs e)
        {
            GridEditableItem editedItem = (sender as RadNumericTextBox).NamingContainer as GridEditableItem;
            RadNumericTextBox tbQuantity = editedItem["Quantity"].FindControl("tbQuantity") as RadNumericTextBox;
            Label UnitCost = editedItem["UnitCost"].FindControl("tbUnitCost") as Label;
            if (UnitCost.Text == "") return;
            tbQuantity.Text = "0";

        }


        protected void txtMRC_TextChanged(object sender, EventArgs e)
        {

            CalculateROI();

        }

        protected void txtROI_TextChanged(object sender, EventArgs e)
        {
            CalculateMRC();
        }

        protected void cmbBuilding_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (_City.Equals("Karachi"))
            {
                city = 1;
            }

            if (_City.Equals("Lahore"))
            {
                city = 2;
            }

            if (_City.Equals("Islamabad"))
            {
                city = 3;
            }
            BuildID = Convert.ToInt32(cmbBuilding.SelectedItem.Value);
            DataTable dt = obj_clsInfraCosting.GetDefaultItems(_Distance, _InfraType, BuildID, city, int_AreaID);
            Session["dt_ItemLines"] = dt;
            grid_ItemDetail.Rebind();
            CalculateMRC();
        }

        protected void cmbArea_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (_City.Equals("Karachi"))
            {
                city = 1;
            }

            if (_City.Equals("Lahore"))
            {
                city = 2;
            }

            if (_City.Equals("Islamabad"))
            {
                city = 3;
            }
            BuildID = Convert.ToInt32(cmbBuilding.SelectedItem.Value);
            int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);
            DataTable dt_IsAerial = obj_clsGeneralFunction.GetAreabyAreaID(int_AreaID);
            int_IS_Aerial = Convert.ToInt32(dt_IsAerial.Rows[0]["IsAerial"]);
            hdnAreaID.Value = int_IS_Aerial.ToString();

            DataTable dt = obj_clsInfraCosting.GetDefaultItems(_Distance, _InfraType, BuildID, city, int_AreaID);
            Session["dt_ItemLines"] = dt;
            grid_ItemDetail.Rebind();
            CalculateMRC();
        }

        protected void cmbLob_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbInfra.Enabled = true;
            obj_BL.GetInfraByLob(cmbInfra, 1, Convert.ToInt32(cmbLOB.SelectedValue));
        }

        protected void cbInfra_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbService.Enabled = true;
            obj_BL.getServicesUnitByInfra(Convert.ToInt32(cmbInfra.SelectedValue), cmbService);

        }

        protected void cmbService_SelectedIndexChanged1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void btSave_Click(object sender, EventArgs e)
        {
           // Save();

            int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);
            DataTable dt_IsAerial = obj_clsGeneralFunction.GetAreabyAreaID(int_AreaID);
            int_IS_Aerial = Convert.ToInt32(dt_IsAerial.Rows[0]["IsAerial"]);
            hdnAreaID.Value = int_IS_Aerial.ToString();

            if (int_IS_Aerial.Equals("0"))
            {
                if (int_RegionID.Equals(2))
                {
                    ConformationEmail();
                }
                else
                {
                    ConformationEmail();
                }


               // Response.Write("<span style= 'color:red; font-size: x-large;'>  This is no infra zone, we can only provide third party solution.  </span>");

                Vailda.InnerHtml = "<span style= 'color:red; font-size: x-large;'>  This is no infra zone, we can only provide third party solution.  </span><br/>";
                
                
            }

            else if (_InfraType.Equals(1) && int_IS_Aerial.Equals(1))
            {
                CreateNRF();
                return;
            }

            else if ((_InfraType.Equals(2) && int_IS_Aerial.Equals(2)) || (_InfraType.Equals(2) && int_IS_Aerial.Equals(1)))
            {
                CreateNRF();
                return;
            }
            else
            {
                //Response.Write(lblNRFTypeError.Text + "<span style= 'color:red; font-size: x-large;'>InfraType selected Cannot be supplied in this area. </span>");
                //Response.Write("<span style= 'color:red; font-size: x-large;'>InfraType selected Cannot be supplied in this area. </span>");
                Response.Write("<script>alert(hello);</script>");

                Vailda.InnerHtml = "<span style= 'color:red; font-size: x-large;'>InfraType selected Cannot be supplied in this area. </span><br/>";
            }
        }

        //protected void btSave_Click(object sender, EventArgs e)
        //{
        //    InsertOrder();
        //}

        //protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        //{
        //    int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);
        //    DataTable dt_IsAerial = obj_clsGeneralFunction.GetAreabyAreaID(int_AreaID);
        //    int_IS_Aerial = Convert.ToInt32(dt_IsAerial.Rows[0]["IsAerial"]);
        //    hdnAreaID.Value = int_IS_Aerial.ToString();

        //    if (e.Item.Text == "Save")
        //    {

        //        if (int_IS_Aerial.Equals("0"))
        //        {
        //            if (int_RegionID.Equals(2))
        //            {
        //                ConformationEmail();
        //            }
        //            else
        //            {
        //                ConformationEmail();
        //            }


        //            Response.Write("<span style= 'color:red; font-size: x-large;'>  This is no infra zone, we can only provide third party solution.  </span>");
        //        }

        //        else if (_InfraType.Equals(1) && int_IS_Aerial.Equals(1))
        //        {
        //            CreateNRF();
        //            return;
        //        }

        //        else if ((_InfraType.Equals(2) && int_IS_Aerial.Equals(2)) || (_InfraType.Equals(2) && int_IS_Aerial.Equals(1)))
        //        {
        //            CreateNRF();
        //            return;
        //        }
        //        else
        //        {
        //            //Response.Write(lblNRFTypeError.Text + "<span style= 'color:red; font-size: x-large;'>InfraType selected Cannot be supplied in this area. </span>");
        //            Response.Write("<span style= 'color:red; font-size: x-large;'>InfraType selected Cannot be supplied in this area. </span>");
        //        }
        //    }


        //}


        #region
        //All Functions 
        private void CalculateROI()
        {
            DataTable dt = (DataTable)Session["dt_ItemLines"];
            int int_ROI = 0;
            double dbl_Amount = 0;
            double dbl_OTC = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dbl_Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                    dbl_OTC = dbl_OTC + dbl_Amount;
                }
                dbl_OTC = Math.Round(dbl_OTC, 2);
                int_ROI = Convert.ToInt32(dbl_OTC / (Convert.ToInt32(txtMRC.Text) * 0.35));
                txtROI.Text = int_ROI.ToString();
                txtROI.Focus();

            }
        }


        private void CalculateMRC()
        {
            DataTable dt = (DataTable)Session["dt_ItemLines"];
            double dbl_OTC = 0;
            int int_MRC = 0;
            double dbl_Amount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dbl_Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                    dbl_OTC = dbl_OTC + dbl_Amount;
                }
                dbl_OTC = Math.Round(dbl_OTC, 2);
                int_MRC = Convert.ToInt32((dbl_OTC / Convert.ToInt32(txtROI.Text)) / 0.35);
                txtMRC.Text = int_MRC.ToString();
                txtMRC.Focus();

            }
        }


        private void CalculateMRC(int int_ROI)
        {
            DataTable dt = (DataTable)Session["dt_ItemLines"];
            double dbl_OTC = 0;
            int int_MRC = 0;
            double dbl_Amount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dbl_Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                    dbl_OTC = dbl_OTC + dbl_Amount;
                }
                dbl_OTC = Math.Round(dbl_OTC, 2);
                int_MRC = Convert.ToInt32((dbl_OTC / int_ROI) / 0.35);
                txtMRC.Text = int_MRC.ToString();
                txtMRC.Focus();

            }
        }

        private void ShowService()
        {
            DataTable dt_Service = obj_clsGeneralFunction.GetALLServices();
            cmbService.DataSource = dt_Service;
            cmbService.DataTextField = "ServiceUnit";
            cmbService.DataValueField = "ServiceUnitID";
            cmbService.DataBind();


        }

        private void ShowCapacity_Bandwidth()
        {
            DataTable dt_Capacity = obj_clsGeneralFunction.GetALLBandWidth();
            cmbCapacity.DataSource = dt_Capacity;
            cmbCapacity.DataTextField = "BandwidthDesc";
            cmbCapacity.DataValueField = "BandwidthID";
            cmbCapacity.DataBind();


        }

        private void ShowIndusry()
        {
            DataTable dt_Industry = obj_clsGeneralFunction.GetALLBusinessType();
            cmbIndustry.DataSource = dt_Industry;
            cmbIndustry.DataTextField = "BusinessType";
            cmbIndustry.DataValueField = "BID";
            cmbIndustry.DataBind();
        }

        private void ShowBuilding()
        {
            DataTable dt = obj_clsGeneralFunction.GetBuildingByCityName(_City);
            cmbBuilding.DataSource = dt;
            cmbBuilding.DataTextField = "BuildName";
            cmbBuilding.DataValueField = "BuildID";
            cmbBuilding.DataBind();
            //cmbBuilding.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            BuildID = Convert.ToInt32(cmbBuilding.SelectedItem.Value);

        }


        private void SetRegion()
        {
            DataTable dt_Area = obj_clsGeneralFunction.GetRegionByCityID(city);
            txtRegion.Text = dt_Area.Rows[0]["RegionName"].ToString();
            int_RegionID = Convert.ToInt32(dt_Area.Rows[0]["RegionID"]);

        }

        private void ShowArea()
        {
            DataTable dt_Area = obj_clsGeneralFunction.GetArea(city);
            cmbArea.DataSource = dt_Area;
            cmbArea.DataTextField = "Area";
            cmbArea.DataValueField = "AreaID";
            cmbArea.DataBind();
            cmbArea.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            int_AreaID = Convert.ToInt32(cmbArea.SelectedItem.Value);

        }


        private void ShowLOB()
        {
            DataTable dt = obj_clsGeneralFunction.GetAllLOB();
            cmbLOB.DataSource = dt;
            cmbLOB.DataTextField = "LOB";
            cmbLOB.DataValueField = "LOB_ID";
            cmbLOB.DataBind();
        }


        private void ShowCustomer()
        {
            DataTable dt = obj_clsGeneralFunction.GetAllCustomer();
            cmbCustomerName.DataSource = dt;
            cmbCustomerName.DataTextField = "Customer";
            cmbCustomerName.DataValueField = "CustomerCode";
            cmbCustomerName.DataBind();
            cmbCustomerName.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            //1.Items.Insert(0, new ListItem("Please Select", "NULL"));


        }

        private void CreateNRF()
        {
            DataTable dt_NRF = (DataTable)Session["dt_ItemLines"];
            double dbl_Amount = 0;
            double dbl_OTC = 0;
            if (dt_NRF.Rows.Count > 0)
            {
                for (int i = 0; i < dt_NRF.Rows.Count; i++)
                {
                    dbl_Amount = Convert.ToDouble(dt_NRF.Rows[i]["Amount"]);
                    dbl_OTC = dbl_OTC + dbl_Amount;
                }


            }

            //object obj_nrfid = obj_clsInfraCosting.CreateNRF( Convert.ToInt32(cmbCustomerName.SelectedValue), txtSiteAddress.Text, txtCity.Text, cmbIndustry.SelectedValue, txtCircuitName.Text, cmbService.SelectedValue,  cmbCapacity.SelectedValue, txtNRFType.Text, cmbTopology.SelectedValue, Convert.ToInt32(_Distance), txtPOCName.Text, txtPOCContact.Text, txtPOCEmail.Text, Convert.ToInt32(txtMRC.Text), Convert.ToInt32(dbl_OTC), Convert.ToInt32(txtROI.Text));
            //object obj_nrfid = obj_clsInfraCosting.CreateNRF(Convert.ToInt32(cmbCustomerName.SelectedValue), txtSiteAddress.Text, txtCity.Text, cmbIndustry.SelectedValue, txtCircuitName.Text, cmbService.SelectedValue, cmbCapacity.SelectedValue, txtNRFType.Text, Convert.ToInt32(cmbLOB.SelectedValue), Convert.ToInt32(_Distance), txtPOCName.Text, txtPOCContact.Text, txtPOCEmail.Text, Convert.ToInt32(txtMRC.Text), Convert.ToInt32(dbl_OTC), Convert.ToInt32(txtROI.Text), Convert.ToInt32(cmbBuilding.SelectedValue), Convert.ToInt32(cmbArea.SelectedValue), Convert.ToInt32(cmbInfra.SelectedValue), txtRegion.Text, Convert.ToString(Session["Name"]));
            object obj_nrfid = obj_clsInfraCosting.CreateNRF(Convert.ToInt32(cmbCustomerName.SelectedValue), txtSiteAddress.Text, txtCity.Text, cmbIndustry.SelectedValue, txtCircuitName.Text, cmbService.SelectedValue, cmbCapacity.SelectedValue, txtNRFType.Text, Convert.ToInt32(cmbLOB.SelectedValue), Convert.ToInt32(_Distance), txtPOCName.Text, txtPOCContact.Text, txtPOCEmail.Text, Convert.ToInt32(txtMRC.Text), Convert.ToInt32(dbl_OTC), Convert.ToInt32(txtROI.Text), Convert.ToInt32(cmbBuilding.SelectedValue), Convert.ToInt32(cmbArea.SelectedValue), 4, txtRegion.Text, Convert.ToString(Session["Name"]));
            obj_clsInfraCosting.UpdateNRFKey(obj_nrfid.ToString());
            DataTable dt_GNKFP =  obj_clsInfraCosting.GetNRFKeyForPDF(Convert.ToInt32(obj_nrfid));
            str_KeyForPDF = dt_GNKFP.Rows[0]["NRFKey"].ToString();


            DataTable dt = (DataTable)Session["dt_ItemLines"];
            string str_ItemNumber = null;
            int int_Quantity = 0;
            decimal dec_Cost = 0;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str_ItemNumber = dt.Rows[i]["ItemCode"].ToString();
                    int_Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    dec_Cost = Convert.ToDecimal(dt.Rows[i]["UnitCost"]);
                    dbl_Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                    dbl_OTC = dbl_OTC + dbl_Amount;
                    obj_clsInfraCosting.InsertItems(Convert.ToInt32(obj_nrfid), str_ItemNumber, int_Quantity, dec_Cost);
                }
            }

            PDFSendToCustomers(Convert.ToInt32(obj_nrfid));


        }



        public void Save()
        {

        }


        public void ConformationEmail()
        {
            try
            {

                dynamic counter = 1;
                SmtpClient Smtp_Server = default(SmtpClient);
                //needs to hassaan dynamic dt_Server = objGP.SP_Datatable("sp_GetEmailServer");
                Smtp_Server = new SmtpClient();
                //string[,] Parameters = { { "@CUSTCLAS", 2605} };
                //return true;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("hassaan.mohsin@multinet.com.pk");
                msg.To.Add("hassaan.mohsin@multinet.com.pk");
                msg.CC.Add("shahbaz.iqbal@multinet.com.pk");
                //msg.Subject = Subject + " - " + Strings.Trim(ClientName) + "(" + Strings.Format(System.DateTime.Now, "MMM-yyyy") + ")";
                msg.Subject = "Test Email";
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                msg.Body = "Just to test the body";
                Smtp_Server.Host = "103.31.80.114";
                Smtp_Server.Send(msg);
                msg.To.Clear();
                msg.CC.Clear();
                msg.Dispose();
                //return true;
            }

            catch (Exception ex)
            {
                //ex.Message();
            }

        }       

        /* nechay wala */
        private void PDFSendToCustomers(int nrf_id)
        {
            try
            {

                //ReportDocument cryRpt = new ReportDocument();

                ReportDocument cryRpt = new ReportDocument();

                Session["CurrentMonth"] = "";


                string startdate = Convert.ToString(Session["StartDate"]);
                string enddate = Convert.ToString(Session["EndDate"]);
                DataTable dt_NRFView = obj_NRFView.GetNRF(nrf_id);
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + "NRF.rpt"));
                CrystalReportViewer1.ReportSource = cryRpt;
                //cryRpt.SetParameterValue("@CustomerCode", nrf_id);
                CrystalReportViewer1.RefreshReport();
                cryRpt.Database.Tables[0].SetDataSource(dt_NRFView);
                if (dt_NRFView.Rows.Count > 0)
                {
                    CrystalReportViewer1.ReportSource = dt_NRFView;
                    try
                    {
                        ExportOptions CrExportOptions = default(ExportOptions);
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        //CrDiskFileDestinationOptions.DiskFileName = HttpContext.Current.Server.MapPath("~/Reports/" + ("NRF") + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf");
                        CrDiskFileDestinationOptions.DiskFileName = HttpContext.Current.Server.MapPath("~/Reports/" + str_KeyForPDF + ".pdf");


                        CrExportOptions = cryRpt.ExportOptions;

                        var _with1 = CrExportOptions;
                        _with1.ExportDestinationType = ExportDestinationType.DiskFile;
                        _with1.ExportFormatType = ExportFormatType.PortableDocFormat;
                        _with1.DestinationOptions = CrDiskFileDestinationOptions;
                        _with1.FormatOptions = CrFormatTypeOptions;
                        cryRpt.Export();
                        cryRpt.Close();
                        Response.Write("<span style= 'color:blue; font-size: x-large;'>  PDF Created Successfully. PDF can be viewed on \\202.141.239.194\\d$\\BusinessApps\\RainMaker\\New Rainmaker\\RainMaker\\RainMaker\\Reports" + DateTime.Now.ToString("dd-MM-yyyy") + "  </span>");

                        
                        //string FilePath = HttpContext.Current.Server.MapPath("~/Reports/" + ("NRF") + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf");
                        string FilePath = HttpContext.Current.Server.MapPath("~/Reports/" + str_KeyForPDF + ".pdf");

                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        //Response.AddHeader("Content-Disposition", "attachment; filename=\" " + "NRF" + DateTime.Now.ToString("dd-MM-yyyy")  +".pdf\"");
                        Response.AddHeader("Content-Disposition", "attachment; filename=\" " + str_KeyForPDF + ".pdf\"");
                        //Response.WriteFile(Server.MapPath(Trim(InvoiceNumber) & ".pdf"))
                        //Response.TransmitFile(HttpContext.Current.Server.MapPath("~/Reports/" + ("NRF") + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf"));
                        Response.TransmitFile(FilePath);

                        //Response.End();

                        //Response.ContentType = "application/pdf";
                        //Response.AddHeader("content-disposition", "attachment; filename= SampleExport.pdf");
                        //Response.End();

                        //Response.Buffer = false;
                        //Response.ClearContent();
                        //Response.ClearHeaders();
                        //Stream stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        //stream.Seek(0, SeekOrigin.Begin);
                        
                        //return File(stream, "application/pdf", "Salal.pdf");

                    }
                    catch (Exception ex)
                    {
                        //Interaction.MsgBox(ex.ToString);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }




        #endregion  
    }
}