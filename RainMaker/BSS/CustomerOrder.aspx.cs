using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.IO;


namespace RainMaker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        BSS_Service.Service1SoapClient objBSS = new BSS_Service.Service1SoapClient();

        BL objBL = new BL();

        #region EVENTS

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cmbService.Enabled = false;
                cmbInfra.Enabled = false;
                objBL.getLob(cmbLob);
            }
            //cbChangeForm.Visible = true;
        }

        protected void cmbLob_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string selected = cmbLob.Text;
            if (cmbLob.Text == "Please-Select")
            {
                cmbService.Enabled = false;
            }
            else
            {
                cmbService.Enabled = true;
                objBL.getServicesUnitByLOb(cmbService , Convert.ToInt32(cmbLob.SelectedValue));
            }
        }

        protected void cmbService_SelectedIndexChanged1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            objBL.GetInfra(cmbInfra, 1, Convert.ToInt32(cmbService.SelectedValue));
            cmbInfra.Enabled = true;
        }

        protected void cbInfra_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
            cmbLob.Enabled = false;
            cmbInfra.Enabled = false;
            cmbService.Enabled = false;
            cbChangeForm.Visible = true;
            cbChangeForm.Checked = false;
            

            //misc
            if (cmbInfra.SelectedValue == "9" || cmbInfra.SelectedValue == "10" || cmbInfra.SelectedValue == "18" || cmbInfra.SelectedValue == "14" || cmbInfra.SelectedValue == "17" || cmbInfra.SelectedValue == "16")
            {
                LoadMiscControl();
            }
            else if (cmbInfra.SelectedValue == "4")
            {
                loadTDMControl();
                pnl_TDM.Visible = true;
            }
            else if (cmbInfra.SelectedValue == "15")
            {
                //VM
            }

        }
        
        protected void cbChangeForm_CheckedChanged1(object sender, EventArgs e)
        {
            if (cbChangeForm.Checked == true)
            {
                cmbLob.Enabled = true;
                cmbService.Enabled = false;
                cmbService.SelectedIndex = 0;
                cmbInfra.Enabled = false;
                cmbInfra.SelectedIndex = 0;
                cmbLob.SelectedIndex = 0;
                pnl_Misc.Visible = false;
                pnl_TDM.Visible = false;
                cbChangeForm.Checked = false;
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        { 
            if(cmbInfra.SelectedValue == "4")
            insertOrdertdm();
        }

        #endregion EVENTS


        #region Functions

        protected void loadTDMControl()
        {
            RadComboBox cmbTDMCustomerCode = (RadComboBox)pnl_TDM.FindControl("cmbCustomerCode");
            RadComboBox cmbTDMProjectCode = (RadComboBox)pnl_TDM.FindControl("cmbProjectCode");
            objBL.loadTDMCusCode(cmbTDMCustomerCode, cmbTDMProjectCode);
            RadComboBox cmbTDMCountry= (RadComboBox)pnl_TDM.FindControl("cmbCountry");
            RadComboBox cmbTDMBICountry = (RadComboBox)pnl_TDM.FindControl("cmbBICountry");
            RadComboBox cmbTDMCountryA = (RadComboBox)pnl_TDM.FindControl("cmbCountryA");
            RadComboBox cmbTDMCountryB = (RadComboBox)pnl_TDM.FindControl("cmbCountryB");
            objBL.loadTDMCountries(cmbTDMCountry);
            objBL.loadTDMCountries(cmbTDMBICountry);
            objBL.loadTDMCountries(cmbTDMCountryA);
            objBL.loadTDMCountries(cmbTDMCountryB);
            RadComboBox cmbTDMSalesPerson = (RadComboBox)pnl_TDM.FindControl("cmbSalesPerson");
            objBL.GetSalesPersonsbyInfraID(cmbTDMSalesPerson,Convert.ToInt16(cmbInfra.SelectedValue));
            RadComboBox cmbTDMBusinessType = (RadComboBox)pnl_TDM.FindControl("cmbBusinessType");
            objBL.loadBusinessType(cmbTDMBusinessType);
            objBL.LoadCircuitOwner((RadComboBox)pnl_TDM.FindControl("cmbBICircuitOwner"));
            objBL.LoadCircuitOwner((RadComboBox)pnl_TDM.FindControl("cmbBIBackupOwner"));
            objBL.loadCircuitType((RadComboBox)pnl_TDM.FindControl("cmbBICircuitType"), Convert.ToInt32(cmbInfra.SelectedValue));
            objBL.loadTypeDescbyOwnerID((RadComboBox)pnl_TDM.FindControl("cmbBI3rdBackupParty"), 2);
            objBL.loadTypeDescbyOwnerID((RadComboBox)pnl_TDM.FindControl("cmbBI3rdPartyName"), 2);
            objBL.loadGetPaymnetTerms((RadComboBox)pnl_TDM.FindControl("cmbBIPaymentTerm"));
        }

        protected void LoadMiscControl()
        {
            Panel pnlBIThirdPartyCharges = (Panel)pnl_Misc.FindControl("pnlBIThirdPartyCharges");
            pnlBIThirdPartyCharges.Visible = false;
            Panel pnlVSAT = (Panel)pnl_Misc.FindControl("pnlVSAT");
            Panel pnlDC = (Panel)pnl_Misc.FindControl("pnlDC");
            pnlDC.Visible = false;
            pnlVSAT.Visible = false;
            pnlDC.Visible = false;
            pnlVSAT.Visible = false;
            objBL.loadBusinessType((RadComboBox)pnl_Misc.FindControl("cmbBusinessType"));
            RadComboBox cmbGetSiteB = (RadComboBox)pnl_Misc.FindControl("cmbGetSiteB");
            RadTextBox tbCompany = (RadTextBox)pnl_Misc.FindControl("tbCompany");
            objBL.loadSiteB(tbCompany.Text, cmbGetSiteB);
            RadComboBox cmbCity = (RadComboBox)pnl_Misc.FindControl("cmbCity");
            objBL.loadCity(cmbCity);
            RadComboBox cmbCustomerCode = (RadComboBox)pnl_Misc.FindControl("cmbCustomerCode");
            RadComboBox cmbProject = (RadComboBox)pnl_Misc.FindControl("cmbProject");
            objBL.loadCusCode(cmbCustomerCode, cmbProject, "insert");
            RadComboBox cmbSalesPerson = (RadComboBox)pnl_Misc.FindControl("cmbSalesPerson");
            objBL.loadSalesPerson(cmbSalesPerson);
            objBL.loadPrioty((RadComboBox)pnl_Misc.FindControl("cmbPriority"));
            objBL.loadLoca((RadComboBox)pnl_Misc.FindControl("cmbLocationCode"), Convert.ToInt32(cmbCity.SelectedValue));
            objBL.loadBandWidth((RadComboBox)pnl_Misc.FindControl("cmbBandwidth"));
            objBL.loadExchangeArea((RadComboBox)pnl_Misc.FindControl("cmbExcArea"), (RadComboBox)pnl_Misc.FindControl("cmbNode"), Convert.ToInt32(cmbCity.SelectedValue), "insert");
            objBL.loadNode((RadComboBox)pnl_Misc.FindControl("cmbNode"), Convert.ToInt32(cmbCity.SelectedValue), 0, "");
            objBL.loadInfraMedium((RadComboBox)pnl_Misc.FindControl("cmbInfraMedium"), Convert.ToInt32(cmbInfra.SelectedValue));
            objBL.loadGetPaymnetTerms((RadComboBox)pnl_Misc.FindControl("cmbBIPayTerms"));
            objBL.loadGetEquipmentProperty((RadComboBox)pnl_Misc.FindControl("cmbBIEquipmentOwner"));
            objBL.LoadCircuitOwner((RadComboBox)pnl_Misc.FindControl("cmbBICircuitOwner"));
            objBL.LoadCircuitOwner((RadComboBox)pnl_Misc.FindControl("cmbBIBackupOwner"));
            objBL.loadCircuitType((RadComboBox)pnl_Misc.FindControl("cmbBICircuitType"), Convert.ToInt32(cmbInfra.SelectedValue));
            objBL.loadTypeDescbyOwnerID((RadComboBox)pnl_Misc.FindControl("cmbBI3rdBackupParty"), 2);
            objBL.loadTypeDescbyOwnerID((RadComboBox)pnl_Misc.FindControl("cmbBI3rdPartyName"), 2);
            ////vsat
            if (cmbInfra.SelectedValue == "18")
            {
                pnlVSAT.Visible = true;
                RadComboBox cmbBandwidth = (RadComboBox)pnl_Misc.FindControl("cmbBandwidth");
                cmbBandwidth.SelectedValue = "262";
                cmbBandwidth.Enabled = false;
                objBL.LoadVSAT_GetVSPackage((RadComboBox)pnl_Misc.FindControl("cmbULPackage"));
                objBL.LoadVSAT_GetVSPackage((RadComboBox)pnl_Misc.FindControl("cmbDLPackage"));
                pnlDC.Visible = false;
            }
            //DC
            else if (cmbInfra.SelectedValue == "16")
            {
                pnlVSAT.Visible = false;
                pnlDC.Visible = true;
            }
            else
            {
                pnlVSAT.Visible = false;
                pnlDC.Visible = false;
            }
            pnl_Misc.Visible = true;
        }

        protected void InsertOrder()
        {
            try
            {
                //int ExpiryFlag = Convert.ToInt32(AppDomain.CurrentDomain.GetData("ExpiryFlag").ToString());
                //DialogResult dgresult = MessageBox.Show("Are you sure to save the record?", "Business Support System", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dgresult == Windows.Forms.DialogResult.No) {
                //SaveToolStripButton.Enabled = true;
                //return;
                //int ExpiryFlag = AppDomain.CurrentDomain.GetData("ExpiryFlag");
                //DialogResult dgresult = MessageBox.Show("Are you sure to save the record?", "Business Support System", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dgresult == Windows.Forms.DialogResult.No) {
                //SaveToolStripButton.Enabled = true;
                //return;
                //}
                //if (string.IsNullOrEmpty(tbName.Text) | string.IsNullOrEmpty(tbCompany.Text) | string.IsNullOrEmpty(tbAddress.Text) | string.IsNullOrEmpty(tbEmail.Text) | string.IsNullOrEmpty(tbCell.Text) | string.IsNullOrEmpty(tbBICompany.Text) | string.IsNullOrEmpty(tbBIAddress.Text) | string.IsNullOrEmpty(tbEmail.Text) | string.IsNullOrEmpty(tbNTN.Text)) {
                //    Response.MsgBox("Please Enter All Necessary Field", MsgBoxStyle.Information, "BSS Administrator");
                //    SaveToolStripButton.Enabled = true;
                //    return;
                //}
                //var msg = MessageBox.Show("Are you sure?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                int SignupID = 0;
                int LOBID = Convert.ToInt32(cmbLob.SelectedValue);
                int ServiceUnitID = Convert.ToInt32(cmbService.SelectedValue);
                int InfraID = Convert.ToInt32(cmbInfra.SelectedValue);
                RadComboBox cmbCustCode = (RadComboBox)pnl_Misc.FindControl("cmbCustomerCode");
                int CustomerCode = Convert.ToInt32(cmbCustCode.SelectedValue);
                RadComboBox cmbProject = (RadComboBox)pnl_Misc.FindControl("cmbProjectCode");
                int ProjectCode = Convert.ToInt32(cmbProject.SelectedValue);
                RadComboBox cmbLoc = (RadComboBox)pnl_Misc.FindControl("cmbLocationCode");
                int LocationCode = Convert.ToInt32(cmbLoc.SelectedValue);
                int CircuitCode = 0;
                RadTextBox tbCompany = (RadTextBox)pnl_Misc.FindControl("tbCompany");
                string CircuitName = tbCompany.Text;
                RadTextBox tbAddress = (RadTextBox)pnl_Misc.FindControl("tbAddress");
                string Address = tbAddress.Text;
                string Phone = string.Empty;
                string Email = string.Empty;
                string Fax = string.Empty;
                string Country = "Pakistan";
                string TD_City = string.Empty;
                RadComboBox cmbCity = (RadComboBox)pnl_Misc.FindControl("cmbCity");
                int CityID = Convert.ToInt32(cmbCity.SelectedValue);
                RadComboBox cmbExcArea = (RadComboBox)pnl_Misc.FindControl("cmbExcArea");
                int AreaID = Convert.ToInt32(cmbExcArea.SelectedValue);
                RadComboBox cmbNode = (RadComboBox)pnl_Misc.FindControl("cmbNode");
                int NodeID = Convert.ToInt32(cmbNode.SelectedValue);
                RadComboBox cmbBusinessType = (RadComboBox)pnl_Misc.FindControl("cmbBusinessType");
                int BusinessTypeID = Convert.ToInt32(cmbBusinessType.SelectedValue);
                RadTextBox tbNTN = (RadTextBox)pnl_Misc.FindControl("tbNTN");
                string NTN = tbNTN.Text;
                RadTextBox tbName = (RadTextBox)pnl_Misc.FindControl("tbName");
                string Contact_Name = tbName.Text;
                string Contact_Department = string.Empty;
                string Contact_Designation = string.Empty;
                string Contact_Office = string.Empty;
                RadTextBox tbPhone = (RadTextBox)pnl_Misc.FindControl("tbPhone");
                string Contact_Phone = tbPhone.Text;
                RadTextBox tbCell = (RadTextBox)pnl_Misc.FindControl("tbCell");
                string Contact_Cell = tbCell.Text;
                RadTextBox tbFax = (RadTextBox)pnl_Misc.FindControl("tbFax");
                string Contact_Fax = tbFax.Text;
                RadTextBox tbEmail = (RadTextBox)pnl_Misc.FindControl("tbEmail");
                string Contact_Email = tbEmail.Text;
                RadTextBox tbCellSMS = (RadTextBox)pnl_Misc.FindControl("tbCellSMS");
                string Contact_SMS = tbCellSMS.Text;
                RadTextBox tbCNIC = (RadTextBox)pnl_Misc.FindControl("tbCNIC");
                string CNIC = tbCNIC.Text;
                RadDatePicker dtCNIC = (RadDatePicker)pnl_Misc.FindControl("dtCNIC");
                DateTime CNICExpiryDate = dtCNIC.SelectedDate.Value;
                RadComboBox cmbPriority = (RadComboBox)pnl_Misc.FindControl("cmbPriority");
                int PriorityID = Convert.ToInt32(cmbPriority.SelectedValue);
                int IsSLA = 0;
                string SLA = string.Empty;
                RadioButtonList rbModeOfBilling = (RadioButtonList)pnl_Misc.FindControl("rbModeOfBilling");
                CheckBox cbBCase = (CheckBox)pnl_Misc.FindControl("cbBCase");
                int IsBOG = cbBCase.Checked ? 1 : 0;
                FileUpload FUBCase = (FileUpload)pnl_Misc.FindControl("FUBCase");
                string BOG = FUBCase.FileName.ToString().Remove(0, FUBCase.FileName.LastIndexOf("\\") + 1);
                CheckBox cbSignup = (CheckBox)pnl_Misc.FindControl("cbSignup");
                int IsSignup = cbSignup.Checked ? 1 : 0;
                FileUpload FUSignUp = (FileUpload)pnl_Misc.FindControl("FUSignUp");
                string Signup = FUSignUp.FileName.ToString().Remove(0, FUSignUp.FileName.LastIndexOf("\\") + 1);
                string TD_ConnectivityType = string.Empty;
                string TD_BandwidthType = string.Empty;
                string TD_CircuitSpeed = string.Empty;
                int BandwidthID = 0;
                int ULPackageID = 0;
                int DLPackageID = 0;


                if (cmbInfra.SelectedValue == "18")
                {
                    BandwidthID = 262;
                    RadComboBox cmbULPackage = (RadComboBox)pnl_Misc.FindControl("cmbULPackage");
                    ULPackageID = Convert.ToInt32(cmbULPackage.SelectedValue);
                    RadComboBox cmbDLPackage = (RadComboBox)pnl_Misc.FindControl("cmbDLPackage");
                    DLPackageID = Convert.ToInt32(cmbDLPackage.SelectedValue);
                }
                else
                {
                    RadComboBox cmbBandwidth = (RadComboBox)pnl_Misc.FindControl("cmbBandwidth");
                    BandwidthID = Convert.ToInt32(cmbBandwidth.SelectedValue);
                    ULPackageID = 19;
                    DLPackageID = 19;
                }
                RadComboBox cmbInfraMedium = (RadComboBox)pnl_Misc.FindControl("cmbInfraMedium");
                string InfraMedium = cmbInfraMedium.Text;
                RadTextBox tbInfraLength = (RadTextBox)pnl_Misc.FindControl("tbInfraLength");
                string InfraLength = tbInfraLength.Text;
                int IsAddReq = 0;
                CheckBox cbVIOP = (CheckBox)pnl_Misc.FindControl("cbVIOP");
                int IsVOIP = (cbVIOP.Checked ? 1 : 0);
                CheckBox cbVC = (CheckBox)pnl_Misc.FindControl("cbVC");
                int IsVC = (cbVC.Checked ? 1 : 0);
                CheckBox cbVPN = (CheckBox)pnl_Misc.FindControl("cbVPN");
                int IsVPN = (cbVPN.Checked ? 1 : 0);
                CheckBox cbExtraIP = (CheckBox)pnl_Misc.FindControl("cbExtraIP");
                int IsExtraIP = (cbExtraIP.Checked ? 1 : 0);
                string TD_ContractPeriod = string.Empty;
                RadTextBox tbBIName = (RadTextBox)pnl_Misc.FindControl("tbBIName");
                string Bil_Name = tbBIName.Text;
                RadTextBox tbBICompany = (RadTextBox)pnl_Misc.FindControl("tbBICompany");
                string Bil_Company = tbBICompany.Text;
                RadTextBox tbBIAddress = (RadTextBox)pnl_Misc.FindControl("tbBIAddress");
                string Bil_Address = tbBIAddress.Text;
                string Bil_Country = "Pakistan";
                string Bil_City = string.Empty;
                string Bil_PostalCode = "0";
                RadTextBox tbBIPhone = (RadTextBox)pnl_Misc.FindControl("tbBIPhone");
                string Bil_Phone = tbBIPhone.Text;
                RadTextBox tbBIEmail = (RadTextBox)pnl_Misc.FindControl("tbBIEmail");
                string Bil_Email = tbBIEmail.Text;
                RadTextBox tbBICell = (RadTextBox)pnl_Misc.FindControl("tbBICell");
                string Bil_Cell = tbBICell.Text;
                RadTextBox tbBIFax = (RadTextBox)pnl_Misc.FindControl("tbBIFax");
                string Bil_Fax = tbBIFax.Text;
                string Bil_Currency = "PKR";
                string OTC_Type = "Installation";
                RadTextBox tbBIOTC = (RadTextBox)pnl_Misc.FindControl("tbBIOTC");
                double OTC_Charges = Convert.ToDouble(tbBIOTC.Text);
                RadComboBox cmbBIPayTerms = (RadComboBox)pnl_Misc.FindControl("cmbBIPayTerms");
                int PaymentTermID = Convert.ToInt32(cmbBIPayTerms.SelectedValue);
                RadTextBox tbBIMRC = (RadTextBox)pnl_Misc.FindControl("tbBIMRC");
                double MRC_Charges = Convert.ToDouble(tbBIMRC.Text);

                int CircuitOwnerID = 0;
                string ThirdPartyAccountID = string.Empty;
                RadComboBox cmbBICircuitOwner = (RadComboBox)pnl_Misc.FindControl("cmbBICircuitOwner");
                if (Convert.ToInt32(cmbBICircuitOwner.SelectedValue) == 1)
                {
                    CircuitOwnerID = 1;
                }
                else
                {
                    RadComboBox cmbBI3rdPartyName = (RadComboBox)pnl_Misc.FindControl("cmbBI3rdPartyName");
                    CircuitOwnerID = Convert.ToInt32(cmbBI3rdPartyName.SelectedValue);
                    RadTextBox tbBIPartyAccountID = (RadTextBox)pnl_Misc.FindControl("tbBIPartyAccountID");
                    ThirdPartyAccountID = tbBIPartyAccountID.Text;
                    //OTC_part and MRC_Party
                }
                RadTextBox tbBI3rdPartyOTC = (RadTextBox)pnl_Misc.FindControl("tbBI3rdPartyOTC");
                double OTC_Party = Convert.ToDouble(tbBI3rdPartyOTC.Text);
                RadTextBox tbBI3rdPartyMRC = (RadTextBox)pnl_Misc.FindControl("tbBI3rdPartyMRC");
                double MRC_Party = Convert.ToDouble(tbBI3rdPartyMRC.Text);
                RadTextBox tbBIInfraCost = (RadTextBox)pnl_Misc.FindControl("tbBIInfraCost");
                double InfraCost = Convert.ToDouble(tbBIInfraCost.Text);
                RadComboBox cmbBIEquipmentOwner = (RadComboBox)pnl_Misc.FindControl("cmbBIEquipmentOwner");
                int EquipmentPropertyID = Convert.ToInt32(cmbBIEquipmentOwner.SelectedValue);
                RadTextBox tbBIEquipmentCost = (RadTextBox)pnl_Misc.FindControl("tbBIEquipmentCost");
                double EquipmentCost = Convert.ToDouble(tbBIEquipmentCost.Text);
                RadTextBox tbBIPayback = (RadTextBox)pnl_Misc.FindControl("tbBIPayback");
                double ROI_Month = Convert.ToDouble(tbBIPayback.Text);
                RadTextBox tbBIPortCost = (RadTextBox)pnl_Misc.FindControl("tbBIPortCost");
                double PortCost = Convert.ToDouble(tbBIPortCost.Text);
                RadioButtonList rbSiteNature = (RadioButtonList)pnl_Misc.FindControl("rbBISiteNature");
                string SiteNature = string.Empty;
                if (rbSiteNature.SelectedIndex == 0)
                {
                    SiteNature = "Individual";
                }
                else
                {
                    SiteNature = "MSP";
                }
                RadTextBox tbBIProjectMRC = (RadTextBox)pnl_Misc.FindControl("tbBIProjectMRC");
                double ProjectMRC = Convert.ToDouble(tbBIProjectMRC.Text);
                RadTextBox tbBIProjectOTC = (RadTextBox)pnl_Misc.FindControl("tbBIProjectOTC");
                double ProjectOTC = Convert.ToDouble(tbBIProjectOTC.Text);
                RadTextBox tbBIProjectInvestment = (RadTextBox)pnl_Misc.FindControl("tbBIProjectInvestment");
                double ProjectInvestment = Convert.ToDouble(tbBIProjectInvestment.Text);
                RadTextBox tbBIProjectPayback = (RadTextBox)pnl_Misc.FindControl("tbBIProjectPayback");
                double ProjectPayBack = Convert.ToDouble(tbBIProjectPayback.Text);

                int IsAdvancePayment = 0;
                double AdvanceAmount = 0;
                string ChequeNo = string.Empty;
                string ReceiptNo = string.Empty;
                RadComboBox cmbBICircuitType = (RadComboBox)pnl_Misc.FindControl("cmbBICircuitType");
                int CircuitTypeID = Convert.ToInt32(cmbBICircuitType.SelectedValue);
                int BackupInfraID = 0;
                int BackupOwnerID = 0;
                double BackupOTC = 0;
                double BackupMRC = 0;

                if (CircuitTypeID == 21)
                {
                    RadComboBox cmbBIBackupOwner = (RadComboBox)pnl_Misc.FindControl("cmbBIBackupOwner");
                    if (Convert.ToInt32(cmbBIBackupOwner.SelectedValue) == 1)
                    {
                        BackupOwnerID = 1;
                        BackupInfraID = Convert.ToInt32(AppDomain.CurrentDomain.GetData("BackupInfra").ToString());
                        BackupOTC = 0;
                        BackupMRC = 0;
                    }
                    else
                    {
                        RadComboBox cmbBI3rdBackupParty = (RadComboBox)pnl_Misc.FindControl("cmbBI3rdBackupParty");
                        BackupOwnerID = Convert.ToInt32(cmbBI3rdBackupParty.SelectedValue);
                        BackupInfraID = Convert.ToInt32(AppDomain.CurrentDomain.GetData("BackupInfra").ToString());
                        RadTextBox tbBIBackupOTC = (RadTextBox)pnl_Misc.FindControl("tbBIBackupOTC");
                        BackupOTC = Convert.ToDouble(tbBIBackupOTC.Text);
                        BackupMRC = Convert.ToDouble(tbBIProjectMRC.Text);
                    }

                }
                else if (CircuitTypeID == 22)
                {
                    BackupMRC = 0;
                    BackupOTC = 0;
                    BackupInfraID = 1;
                    BackupOwnerID = 25;
                }

                string SD_SiteA_Interface = string.Empty;
                string SD_SiteB_Interface = string.Empty;
                string SID_A_Company = string.Empty;
                string SID_A_Address = string.Empty;
                string SID_Country = string.Empty;
                string SID_A_City = string.Empty;
                string SID_A_Cell = string.Empty;
                string SID_A_Phone = string.Empty;
                string SID_A_Fax = string.Empty;
                string SID_A_Email = string.Empty;
                string SID_B_Company = string.Empty;
                string SID_B_Address = string.Empty;
                string SID_B_Country = string.Empty;
                string SID_B_City = string.Empty;
                string SID_B_Cell = string.Empty;
                string SID_B_Phone = string.Empty;
                string SID_B_Fax = string.Empty;
                string SID_B_Email = string.Empty;
                int ParentID = 0;
                //int SiteB = Convert.ToInt32(cmbGetSiteB.SelectedValue);
                int SiteB = 0;
                RadTextBox tbGPID = (RadTextBox)pnl_Misc.FindControl("tbGPID");
                string GPID = tbGPID.Text.Trim();
                RadTextBox tbCMSID = (RadTextBox)pnl_Misc.FindControl("tbCMSID");
                string ClientRefID = tbCMSID.Text;
                int PartnerID = 0;
                int IsBluechip = 0;
                RadDatePicker dtSignup = (RadDatePicker)pnl_Misc.FindControl("dtSignup");
                DateTime SignupDate = dtSignup.SelectedDate.Value;
                RadComboBox cmbSalesPerson = (RadComboBox)pnl_Misc.FindControl("cmbSalesPerson");
                int SalesPersonID = Convert.ToInt32(cmbSalesPerson.SelectedValue);
                RadDatePicker dtCPM = (RadDatePicker)pnl_Misc.FindControl("dtCPM");
                DateTime OrderDate = dtCPM.SelectedDate.Value;
                RadTextBox tbNoofWorkingDays = (RadTextBox)pnl_Misc.FindControl("tbNoofWorkingDays");
                string WorkingDays = tbNoofWorkingDays.Text;
                RadDatePicker dtRFS = (RadDatePicker)pnl_Misc.FindControl("dtRFS");
                DateTime RFSDate = dtRFS.SelectedDate.Value;
                RadTextBox tbNotes = (RadTextBox)pnl_Misc.FindControl("tbNotes");
                string Notes = tbNotes.Text;
                int StatusID = 1;
                //int TransactionBy = Convert.ToInt32(AppDomain.CurrentDomain.GetData("UserID").ToString());
                int TransactionBy = 90;
                // int Cus_Mail = Convert.ToInt32(AppDomain.CurrentDomain.GetData("CusMail").ToString());
                int Cus_Mail = 0;

                int LastSignupID = objBSS.InsertCustomerSignup(SignupID, LOBID, ServiceUnitID, InfraID, CustomerCode, ProjectCode, LocationCode, CircuitCode, CircuitName, Address,
                Phone, Email, Fax, Country, TD_City, CityID, AreaID, NodeID, BusinessTypeID, NTN,
                Contact_Name, Contact_Department, Contact_Designation, Contact_Office, Contact_Phone, Contact_Cell, Contact_Fax, Contact_Email, Contact_SMS, CNIC,
                CNICExpiryDate, PriorityID, IsSLA, SLA, IsBOG, BOG, IsSignup, Signup, TD_ConnectivityType, TD_BandwidthType,
                TD_CircuitSpeed, BandwidthID, ULPackageID, DLPackageID, InfraMedium, InfraLength, IsAddReq, IsVOIP, IsVC, IsVPN,
                IsExtraIP, TD_ContractPeriod, Bil_Name, Bil_Company, Bil_Address, Bil_Country, Bil_City, Bil_PostalCode, Bil_Phone, Bil_Email,
                Bil_Cell, Bil_Fax, Bil_Currency, OTC_Type, OTC_Charges, PaymentTermID, MRC_Charges, CircuitOwnerID, ThirdPartyAccountID, OTC_Party,
                MRC_Party, InfraCost, EquipmentPropertyID, EquipmentCost, ROI_Month, PortCost, SiteNature, ProjectMRC, ProjectOTC, ProjectInvestment,
                ProjectPayBack, IsAdvancePayment, AdvanceAmount, ChequeNo, ReceiptNo, CircuitTypeID, BackupInfraID, BackupOwnerID, BackupOTC, BackupMRC,
                SD_SiteA_Interface, SD_SiteB_Interface, SID_A_Company, SID_A_Address, SID_Country, SID_A_City, SID_A_Cell, SID_A_Phone, SID_A_Fax, SID_A_Email,
                SID_B_Company, SID_B_Address, SID_B_Country, SID_B_City, SID_B_Cell, SID_B_Phone, SID_B_Fax, SID_B_Email, ParentID, SiteB,
                GPID, ClientRefID, PartnerID, IsBluechip, SignupDate, SalesPersonID, OrderDate, WorkingDays, RFSDate, Notes,
                StatusID, TransactionBy, Cus_Mail);

                string MessageFlag = "";
                if (Convert.ToInt64(LastSignupID) > 0)
                {
                    if (Convert.ToInt16(cmbInfra.SelectedValue) == 16)
                    {
                        if (InsertDC_DeploymentDetails(LastSignupID))
                        {
                            MessageFlag = "1";
                        }
                        else
                        {
                            objBSS.ExecQuery("Delete From CustomerSignups where SignupID = " + Convert.ToString(LastSignupID));
                            MessageFlag = "0";
                            LastSignupID = 0;
                        }

                    }
                    else
                    {
                        MessageFlag = "1";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool InsertDC_DeploymentDetails(int SigID)
        {
            try
            {
                int SignupID = SigID;
                RadTextBox tbNoofUs = (RadTextBox)pnl_Misc.FindControl("tbNoofUs");
                int NoofUs = Convert.ToInt32(tbNoofUs.Text);
                string ModeofBilling = "";
                RadioButtonList rbModeOfBilling = (RadioButtonList)pnl_Misc.FindControl("rbModeOfBilling");

                if (rbModeOfBilling.SelectedIndex == 1)
                {
                    ModeofBilling = "As Per Actual";

                }
                else if (rbModeOfBilling.SelectedIndex == 0)
                {
                    ModeofBilling = "Fixed";
                }

                int DCLocID = 3;
                DateTime ActivationDate = System.DateTime.MinValue;
                int Internet_SignupID = 0;
                int MPLSLayer3_SignupID = 0;
                int MPLSLayer2_SignupID = 0;
                int FLL_SignupID = 0;
                int Transit_SignupID = 0;
                int layer2VPN_SignupID = 0;
                RadComboBox cmbInternet = (RadComboBox)pnl_Misc.FindControl("cmbInternet");
                if (cmbInternet.DataSource != null)
                {
                    Internet_SignupID = (Convert.ToInt16(cmbInternet.SelectedValue) != 0 ? Convert.ToInt16(cmbInternet.SelectedValue) : 0);
                }
                RadComboBox cmbMPLSLayer3 = (RadComboBox)pnl_Misc.FindControl("cmbMPLSLayer3");
                if (cmbMPLSLayer3.DataSource != null)
                {
                    MPLSLayer3_SignupID = (Convert.ToInt16(cmbMPLSLayer3.SelectedValue) != 0 ? Convert.ToInt16(cmbMPLSLayer3.SelectedValue) : 0);
                }
                RadComboBox cmbMPLSLayer2 = (RadComboBox)pnl_Misc.FindControl("cmbMPLSLayer2");
                if (cmbMPLSLayer2.DataSource != null)
                {
                    MPLSLayer2_SignupID = (Convert.ToInt16(cmbMPLSLayer2.SelectedValue) != 0 ? Convert.ToInt16(cmbMPLSLayer2.SelectedValue) : 0);
                }

                RadComboBox cmbFLL = (RadComboBox)pnl_Misc.FindControl("cmbFLL");
                if (cmbFLL.DataSource != null)
                {
                    FLL_SignupID = (Convert.ToInt16(cmbFLL.SelectedValue) != 0 ? Convert.ToInt16(cmbFLL.SelectedValue) : 0);
                }

                RadComboBox cmbTransit = (RadComboBox)pnl_Misc.FindControl("cmbTransit");
                if (cmbTransit.DataSource != null)
                {
                    Transit_SignupID = (Convert.ToInt16(cmbTransit.SelectedValue) != 0 ? Convert.ToInt16(cmbTransit.SelectedValue) : 0);
                }

                RadComboBox cmbVPNLayer2 = (RadComboBox)pnl_Misc.FindControl("cmbVPNLayer2");
                if (cmbVPNLayer2.DataSource != null)
                {
                    layer2VPN_SignupID = (Convert.ToInt16(cmbVPNLayer2.SelectedValue) != 0 ? Convert.ToInt16(cmbVPNLayer2.SelectedValue) : 0);
                }


                string Remarks = "";
                int TransactionBy = Convert.ToInt16(Session["UserID"]);


                if (objBSS.InsertPatching(SignupID, Convert.ToInt32(tbNoofUs.Text), ModeofBilling, DCLocID, ActivationDate, Internet_SignupID, MPLSLayer3_SignupID, MPLSLayer2_SignupID, FLL_SignupID, Transit_SignupID,
                layer2VPN_SignupID, Remarks, TransactionBy))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void insertOrdertdm()
        {
            try
            {
                int LastSignupID = 0;
                int ExpiryFlag = Convert.ToInt16(AppDomain.CurrentDomain.GetData("ExpiryFlag"));
                int SignupID = 0;
                int LOBID = Convert.ToInt16(cmbLob.SelectedValue);
                int ServiceUnitID = Convert.ToInt16(cmbService.SelectedValue);
                int InfraID = Convert.ToInt16(cmbInfra.SelectedValue);
                RadComboBox cmbTDMCustomerCode = (RadComboBox)pnl_TDM.FindControl("cmbCustomerCode");
                RadComboBox cmbTDMProjectCode = (RadComboBox)pnl_TDM.FindControl("cmbProjectCode");
                int CustomerCode = Convert.ToInt16(cmbTDMCustomerCode.SelectedValue);
                int ProjectCode = Convert.ToInt16(cmbTDMProjectCode.SelectedValue);
                int LocationCode = 1918;
                int CircuitCode = 0;
                RadTextBox tbCompany = (RadTextBox)pnl_TDM.FindControl("tbCompany");
                string CircuitName = tbCompany.Text;
                RadTextBox tbAddress= (RadTextBox)pnl_TDM.FindControl("tbAddress");
                string Address = tbAddress.Text;
                RadTextBox tbPhone = (RadTextBox)pnl_TDM.FindControl("tbPhone");
                string Phone = tbPhone.Text.ToString();
                string Email = string.Empty;
                //New Field in TDM
                RadTextBox tbBusinessFax = (RadTextBox)pnl_TDM.FindControl("tbBusinessFax");
                string Fax = tbBusinessFax.Text.ToString();
                RadComboBox cmbCountry = (RadComboBox)pnl_TDM.FindControl("cmbCountry");
                string Country = cmbCountry.Text.ToString();
                RadTextBox tbCity = (RadTextBox)pnl_TDM.FindControl("tbCity");
                string TD_City = tbCity.Text.ToString();
                int CityID = 120;
                //New Field in TDM / Default value set
                int AreaID = 114;
                //New Field in TDM / Default value set
                int NodeID = 114;
                //New Field in TDM / Default value set
                RadComboBox cmbBusinessType = (RadComboBox)pnl_TDM.FindControl("cmbBusinessType");
                int BusinessTypeID = Convert.ToInt16(cmbBusinessType.SelectedValue);
                RadTextBox tbNTN = (RadTextBox)pnl_TDM.FindControl("tbNTN");
                string NTN = tbNTN.Text;
                RadTextBox tbName = (RadTextBox)pnl_TDM.FindControl("tbName");
                string Contact_Name = tbName.Text;
                RadTextBox tbDepartment = (RadTextBox)pnl_TDM.FindControl("tbDepartment");
                string Contact_Department = tbDepartment.Text.ToString();
                RadTextBox tbDesignation = (RadTextBox)pnl_TDM.FindControl("tbDesignation");
                string Contact_Designation = tbDesignation.Text.ToString();
                RadTextBox tbOffice = (RadTextBox)pnl_TDM.FindControl("tbOffice");
                string Contact_Office = tbOffice.Text.ToString();
                RadTextBox tbTDMPhone = (RadTextBox)pnl_TDM.FindControl("tbPhone");
                string Contact_Phone = tbTDMPhone.Text;
                RadTextBox tbCell = (RadTextBox)pnl_TDM.FindControl("tbCell");
                string Contact_Cell = tbCell.Text;
                RadTextBox tbContactFax = (RadTextBox)pnl_TDM.FindControl("tbContactFax");
                string Contact_Fax = tbContactFax.Text;
                RadTextBox tbEmail = (RadTextBox)pnl_TDM.FindControl("tbEmail");
                string Contact_Email = tbEmail.Text;
                
                string Contact_SMS = string.Empty;
                //New Field in TDM
                RadTextBox tbCNIC = (RadTextBox)pnl_TDM.FindControl("tbCNIC");
                string CNIC = tbCNIC.Text;
                RadDatePicker dtCNIC = (RadDatePicker)pnl_TDM.FindControl("dtCNIC");
                DateTime CNICExpiryDate = dtCNIC.SelectedDate.Value;
                int PriorityID = 2;
                //'New Field in TDM / Default value set
                int IsSLA = 0;
                //'New Field in TDM
                string SLA = string.Empty;
                //'New Field in TDM
                CheckBox cbTDMBCase = (CheckBox)pnl_TDM.FindControl("cbBCase");
                int IsBOG = (cbTDMBCase.Checked ? 1 : 0);
                FileUpload FUTDMBCase = (FileUpload)pnl_TDM.FindControl("FUBCase");
                string BOG = FUTDMBCase.FileName.ToString().Remove(0, FUTDMBCase.FileName.LastIndexOf("\\") + 1);
                int IsSignup = 0;
                //'New Field in TDM
                string Signup = string.Empty;
                //'New Field in TDM
                string TD_ConnectivityType = Convert.ToString(AppDomain.CurrentDomain.GetData("ConnectivityType"));
                string TD_BandwidthType = "";
                RadTextBox tbCircuitSpeed= (RadTextBox)pnl_TDM.FindControl("tbCircuitSpeed");
                string TD_CircuitSpeed = tbCircuitSpeed.Text;
                int BandwidthID = 140;
                //New Field in TDM
                string InfraMedium = string.Empty;
                //New Field in TDM
                string InfraLength = string.Empty;
                //New Field in TDM
                int IsAddReq = 0;
                CheckBox cbTDMVOIP = (CheckBox)pnl_TDM.FindControl("cbVOIP");
                int IsVOIP = (cbTDMVOIP.Checked ? 1 : 0);
                CheckBox cbTDMVC = (CheckBox)pnl_TDM.FindControl("cbVC");
                int IsVC = (cbTDMVC.Checked ? 1 : 0);
                CheckBox cbTDMVPN = (CheckBox)pnl_TDM.FindControl("cbVPN");
                int IsVPN = (cbTDMVPN.Checked ? 1 : 0);
                CheckBox cbTDMExtraIP = (CheckBox)pnl_TDM.FindControl("cbExtraIP");
                int IsExtraIP = (cbTDMExtraIP.Checked ? 1 : 0);
                RadTextBox tbContractPeriod = (RadTextBox)pnl_TDM.FindControl("tbContractPeriod");
                string TD_ContractPeriod = tbContractPeriod.Text.ToString();
                RadTextBox tbBIContactPerson = (RadTextBox)pnl_TDM.FindControl("tbBIContactPerson");
                string Bil_Name = tbBIContactPerson.Text.ToString();
                RadTextBox tbBICompany = (RadTextBox)pnl_TDM.FindControl("tbBICompany");
                string Bil_Company = tbBICompany.Text;
                RadTextBox tbBIAddress = (RadTextBox)pnl_TDM.FindControl("tbBIAddress");
                string Bil_Address = tbBIAddress.Text;
                RadComboBox cmbBICountry = (RadComboBox)pnl_TDM.FindControl("cmbBICountry");
                string Bil_Country = cmbBICountry.Text;
                RadTextBox tbBICity = (RadTextBox)pnl_TDM.FindControl("tbBICity");
                string Bil_City = tbBICity.Text.ToString();
                RadTextBox tbBIPostalCode = (RadTextBox)pnl_TDM.FindControl("tbBIPostalCode");
                string Bil_PostalCode = tbBIPostalCode.Text.ToString();
                RadTextBox tbBIPhone = (RadTextBox)pnl_TDM.FindControl("tbBIPhone");
                string Bil_Phone = tbBIPhone.Text;
                RadTextBox tbBIEmail = (RadTextBox)pnl_TDM.FindControl("tbBIEmail");
                string Bil_Email = tbBIEmail.Text;
                string Bil_Cell = string.Empty;
                //New Field in TDM
                string Bil_Fax = string.Empty;
                //New Field in TDM
                string Bil_Currency = "PKR";
                //New Field in TDM / Default value set 
                RadComboBox cmbBIPaymentType = (RadComboBox)pnl_TDM.FindControl("cmbBIPaymentType");
                string OTC_Type = cmbBIPaymentType.Text;
                RadTextBox tbBIOTC = (RadTextBox)pnl_TDM.FindControl("tbBIOTC");
                double OTC_Charges = Convert.ToDouble(tbBIOTC.Text);
                RadComboBox cmbBIPaymentTerm = (RadComboBox)pnl_TDM.FindControl("cmbBIPaymentTerm");
                int PaymentTermID =  Convert.ToInt16(cmbBIPaymentTerm.SelectedValue);
                RadTextBox tbBIMRC = (RadTextBox)pnl_TDM.FindControl("tbBIMRC");
                double MRC_Charges = Convert.ToDouble(tbBIMRC.Text);

                int CircuitOwnerID = 0;
                string ThirdPartyAccountID = string.Empty;
                RadComboBox cmbTDMBICircuitType = (RadComboBox)pnl_TDM.FindControl("cmbBICircuitType");
                if (cmbTDMBICircuitType.SelectedValue == "1")
                {
                    CircuitOwnerID = 1;
                }
                else
                {
                    RadComboBox cmbTDM3rdPartyName = (RadComboBox)pnl_TDM.FindControl("cmb3rdPartyName");
                    CircuitOwnerID = Convert.ToInt16(cmbTDM3rdPartyName.SelectedValue);
                    RadTextBox tbTDMPartyAccountID = (RadTextBox)pnl_TDM.FindControl("tbPartyAccountID");
                    ThirdPartyAccountID = tbTDMPartyAccountID.Text;
                }

                RadTextBox tbTDMBIOTC = (RadTextBox)pnl_TDM.FindControl("tbBIPartyOTC");
                double OTC_Party = Convert.ToDouble(tbTDMBIOTC.Text);
                RadTextBox tbTDMBIMRCparty = (RadTextBox)pnl_TDM.FindControl("tbBIMRCparty");
                double MRC_Party = Convert.ToDouble(tbTDMBIMRCparty.Text);
                RadTextBox tbBIInfraCost = (RadTextBox)pnl_TDM.FindControl("tbBIInfraCost");
                double InfraCost = Convert.ToDouble(tbBIInfraCost.Text);
                int EquipmentPropertyID = 0;
                //New Field in TDM
                RadTextBox tbBIEquipmentCost = (RadTextBox)pnl_TDM.FindControl("tbBIEquipmentCost");
                double EquipmentCost = Convert.ToDouble(tbBIEquipmentCost.Text);
                RadTextBox tbBIPayback = (RadTextBox)pnl_TDM.FindControl("tbBIPayback");
                double ROI_Month = Convert.ToDouble(tbBIPayback.Text);
                RadTextBox tbBIPortCost = (RadTextBox)pnl_TDM.FindControl("tbBIPortCost");
                double PortCost = Convert.ToDouble(tbBIPortCost.Text);
                RadioButtonList rbSiteNature = (RadioButtonList)pnl_TDM.FindControl("rbBISiteNature");
                string SiteNature = string.Empty;
                if (rbSiteNature.SelectedIndex == 0)
                {
                    SiteNature = "Individual";
                }
                else
                {
                    SiteNature = "MSP";
                }
                RadTextBox tbBIProjectMRC = (RadTextBox)pnl_TDM.FindControl("tbBIProjectMRC");
                double ProjectMRC = Convert.ToDouble(tbBIProjectMRC.Text);
                RadTextBox tbBIProjectOTC = (RadTextBox)pnl_TDM.FindControl("tbBIProjectOTC");
                double ProjectOTC = Convert.ToDouble(tbBIProjectOTC.Text);
                RadTextBox tbBIProjectInvestment = (RadTextBox)pnl_TDM.FindControl("tbBIProjectInvestment");
                double ProjectInvestment = Convert.ToDouble(tbBIProjectInvestment.Text);
                RadTextBox tbBIProjectPayback = (RadTextBox)pnl_TDM.FindControl("tbBIProjectPayback");
                double ProjectPayBack = Convert.ToDouble(tbBIProjectPayback.Text);
                //
                int IsAdvancePayment = 0;
                //New Field in TDM
                double AdvanceAmount = 0;
                //New Field in TDM
                string ChequeNo = "0";
                //New Field in TDM
                string ReceiptNo = "0";
                //New Field in TDM
                RadComboBox cmbBICircuitType = (RadComboBox)pnl_TDM.FindControl("cmbBICircuitType");
                int CircuitTypeID = Convert.ToInt16(cmbBICircuitType.SelectedValue);
                int BackupInfraID = 0;
                int BackupOwnerID = 0;
                double BackupOTC = 0;
                double BackupMRC = 0;


                if (CircuitTypeID == 21)
                {
                    RadComboBox cmbBIBackupOwner = (RadComboBox)pnl_TDM.FindControl("cmbBIBackupOwner");
                    if (Convert.ToInt32(cmbBIBackupOwner.SelectedValue) == 1)
                    {
                        BackupOwnerID = 1;
                        BackupInfraID = Convert.ToInt32(AppDomain.CurrentDomain.GetData("BackupInfra").ToString());
                        BackupOTC = 0;
                        BackupMRC = 0;
                    }
                    else
                    {
                        RadComboBox cmbBI3rdBackupParty = (RadComboBox)pnl_TDM.FindControl("cmbBI3rdBackupParty");
                        BackupOwnerID = Convert.ToInt32(cmbBI3rdBackupParty.SelectedValue);
                        BackupInfraID = Convert.ToInt32(AppDomain.CurrentDomain.GetData("BackupInfra").ToString());
                        RadTextBox tbBIBackupOTC = (RadTextBox)pnl_TDM.FindControl("tbBIBackupOTC");
                        BackupOTC = Convert.ToDouble(tbBIBackupOTC.Text);
                        BackupMRC = Convert.ToDouble(tbBIProjectMRC.Text);
                    }

                }
                else if (CircuitTypeID == 22)
                {
                    BackupMRC = 0;
                    BackupOTC = 0;
                    BackupInfraID = 1;
                    BackupOwnerID = 25;
                }


                //If CircuitOwnerID = 1 Or CircuitOwnerID = 4 Or CircuitOwnerID = 25 Then
                //    OTC_Party = 0
                //    MRC_Party = 0
                //End If

                //If BackupOwnerID = 1 Or BackupOwnerID = 4 Or BackupOwnerID = 25 Then
                //    BackupMRC = 0
                //    BackupOTC = 0
                //End If

                RadTextBox tbSiteA = (RadTextBox)pnl_TDM.FindControl("tbSiteA");
                string SD_SiteA_Interface = tbSiteA.Text;
                RadTextBox tbSiteB = (RadTextBox)pnl_TDM.FindControl("tbSiteB");
                string SD_SiteB_Interface = tbSiteB.Text;
                RadTextBox tbCompanyA = (RadTextBox)pnl_TDM.FindControl("tbCompanyA");
                string SID_A_Company = tbCompanyA.Text;
                RadTextBox tbAddressA = (RadTextBox)pnl_TDM.FindControl("tbAddressA");
                string SID_A_Address = tbAddressA.Text;
                RadComboBox cmbCountryA = (RadComboBox)pnl_TDM.FindControl("cmbCountryA");
                string SID_Country = cmbCountryA.SelectedValue;
                RadTextBox tbCityA = (RadTextBox)pnl_TDM.FindControl("tbCityA");
                string SID_A_City = tbCityA.Text;
                RadTextBox tbCellA = (RadTextBox)pnl_TDM.FindControl("tbCellA");
                string SID_A_Cell = tbCellA.Text;
                RadTextBox tbPhoneA = (RadTextBox)pnl_TDM.FindControl("tbPhoneA");
                string SID_A_Phone = tbPhoneA.Text;
                RadTextBox tbFaxA = (RadTextBox)pnl_TDM.FindControl("tbFaxA");
                string SID_A_Fax = tbFaxA.Text;
                RadTextBox tbEmailA = (RadTextBox)pnl_TDM.FindControl("tbEmailA");
                string SID_A_Email = tbEmailA.Text;
                RadTextBox tbCompanyB = (RadTextBox)pnl_TDM.FindControl("tbCompanyB");
                string SID_B_Company = tbCompanyB.Text;
                RadTextBox tbAddressB = (RadTextBox)pnl_TDM.FindControl("tbAddressB");
                string SID_B_Address = tbAddressB.Text;
                RadComboBox cmbCountryB = (RadComboBox)pnl_TDM.FindControl("cmbCountryB");
                string SID_B_Country = cmbCountryB.SelectedValue;
                RadTextBox tbCityB = (RadTextBox)pnl_TDM.FindControl("tbCityB");
                string SID_B_City = tbCityB.Text;
                RadTextBox tbCellB = (RadTextBox)pnl_TDM.FindControl("tbCellB");
                string SID_B_Cell = tbCellB.Text;
                RadTextBox tbPhoneB = (RadTextBox)pnl_TDM.FindControl("tbPhoneB");
                string SID_B_Phone = tbPhoneB.Text;
                RadTextBox tbFaxB = (RadTextBox)pnl_TDM.FindControl("tbFaxB");
                string SID_B_Fax = tbFaxB.Text;
                RadTextBox tbEmailB = (RadTextBox)pnl_TDM.FindControl("tbEmailB");
                string SID_B_Email = tbEmailB.Text;
                int ParentID = 0;

                //New Field in TDM
                int SiteB = 0;
                //New Field in TDM
                RadTextBox tbGPID = (RadTextBox)pnl_TDM.FindControl("tbGPID");
                string GPID = tbGPID.Text.Trim();
                //New Field in TDM
                RadTextBox tbCMSID = (RadTextBox)pnl_TDM.FindControl("tbCMSID");
                string ClientRefID = tbCMSID.Text;
                RadTextBox tbPartnerID = (RadTextBox)pnl_TDM.FindControl("tbPartnerID");
                int PartnerID = Convert.ToInt16(tbPartnerID.Text);
                int IsBluechip = 0;
                //New Field in TDM
                RadDatePicker dtSignup = (RadDatePicker)pnl_TDM.FindControl("dtSignup");
                DateTime SignupDate = dtSignup.SelectedDate.Value;
                RadComboBox cmbSalesPerson = (RadComboBox)pnl_TDM.FindControl("cmbSalesPerson");
                int SalesPersonID = Convert.ToInt32(cmbSalesPerson.SelectedValue);
                RadDatePicker dtCPM = (RadDatePicker)pnl_TDM.FindControl("dtCPM");
                DateTime OrderDate = dtCPM.SelectedDate.Value;
                RadTextBox tbWorkingdays = (RadTextBox)pnl_TDM.FindControl("tbWorkingdays");
                string WorkingDays = tbWorkingdays.Text;
                RadDatePicker dtRFS = (RadDatePicker)pnl_TDM.FindControl("dtRFS");
                DateTime RFSDate = dtRFS.SelectedDate.Value;
                RadTextBox tbNotes = (RadTextBox)pnl_TDM.FindControl("tbNotes");
                string Notes = tbNotes.Text;
                int StatusID = 1;
                //New Field in TDM / Default value set
                int TransactionBy = Convert.ToInt32(AppDomain.CurrentDomain.GetData("UserID"));
                CheckBox cbEmailtoCustomer = (CheckBox)pnl_TDM.FindControl("cbEmailtoCustomer");
                int Cus_Mail = (cbEmailtoCustomer.Checked ? 1 : 0);
                int ULPackageID = 0;
                int DLPackageID = 0;
                LastSignupID = objBSS.InsertCustomerSignup(SignupID, LOBID, ServiceUnitID, InfraID, CustomerCode, ProjectCode, LocationCode, CircuitCode, CircuitName, Address,
                Phone, Email, Fax, Country, TD_City, CityID, AreaID, NodeID, BusinessTypeID, NTN,
                Contact_Name, Contact_Department, Contact_Designation, Contact_Office, Contact_Phone, Contact_Cell, Contact_Fax, Contact_Email, Contact_SMS, CNIC,
                CNICExpiryDate, PriorityID, IsSLA, SLA, IsBOG, BOG, IsSignup, Signup, TD_ConnectivityType, TD_BandwidthType,
                TD_CircuitSpeed, BandwidthID, ULPackageID, DLPackageID, InfraMedium, InfraLength, IsAddReq, IsVOIP, IsVC, IsVPN, IsExtraIP, TD_ContractPeriod,
                Bil_Name, Bil_Company, Bil_Address, Bil_Country, Bil_City, Bil_PostalCode, Bil_Phone, Bil_Email, Bil_Cell, Bil_Fax,
                Bil_Currency, OTC_Type, OTC_Charges, PaymentTermID, MRC_Charges, CircuitOwnerID, ThirdPartyAccountID, OTC_Party, MRC_Party, InfraCost,
                EquipmentPropertyID, EquipmentCost, ROI_Month, PortCost, SiteNature, ProjectMRC, ProjectOTC, ProjectInvestment, ProjectPayBack, IsAdvancePayment,
                AdvanceAmount, ChequeNo, ReceiptNo, CircuitTypeID, BackupInfraID, BackupOwnerID, BackupOTC, BackupMRC, SD_SiteA_Interface, SD_SiteB_Interface,
                SID_A_Company, SID_A_Address, SID_Country, SID_A_City, SID_A_Cell, SID_A_Phone, SID_A_Fax, SID_A_Email, SID_B_Company, SID_B_Address,
                SID_B_Country, SID_B_City, SID_B_Cell, SID_B_Phone, SID_B_Fax, SID_B_Email, ParentID, SiteB, GPID, ClientRefID,
                PartnerID, IsBluechip, SignupDate, SalesPersonID, OrderDate, WorkingDays, RFSDate, Notes, StatusID, TransactionBy,
                Cus_Mail);
                string MessageFlag = "";
                if (LastSignupID > 0)
                {
                    MessageFlag = "1";

                }
                else
                {
                    MessageFlag = "0";
                }

            }
            catch (Exception ex)
            {
                //SaveToolStripButton.Enabled = true;
                //Interaction.MsgBox("Error in Inserting TDM Signup Method", MsgBoxStyle.Critical, "BSS Administrator");
                return;
            }


            try
            {
                CheckBox cbTDMBCase = (CheckBox)pnl_TDM.FindControl("cbBCase");
                FileUpload FUBCase = (FileUpload)pnl_TDM.FindControl("FUBCase");
                if (cbTDMBCase.Checked == true & !string.IsNullOrEmpty(FUBCase.FileName))
                {
                    string filename = string.Empty;
                    filename = FUBCase.FileName.ToString().Remove(0, FUBCase.FileName.LastIndexOf("\\") + 1);

                    FileStream fileStream = new FileStream(FUBCase.FileName, FileMode.Open);
                    FileInfo fileInfo = new FileInfo(FUBCase.FileName);
                    int count = Convert.ToInt32(fileInfo.Length);
                    byte[] bArray = new byte[(count - 1) + 2];
                    fileStream.Read(bArray, 0, count);
                    fileStream.Close();
                    objBSS.UploadFileBOG(bArray, filename);
                    objBSS.InsertActivity(1, "File Upload Successfully", DateTime.Now, Session["UserID"].ToString());
                }
                else
                {
                    objBSS.InsertActivity(0, "Fail to File Upload", DateTime.Now, Session["UserID"].ToString());
                }

            }
            catch (Exception ex)
            {
                //Interaction.MsgBox("Error in Uploading File of TDM(BCase) Method", MsgBoxStyle.Critical, "BSS Administrator");
                //SaveToolStripButton.Enabled = true;
                //clearTDMControls(form);
                return;
            }


            //try
            //{

            //    if (LastSignupID > 0)
            //    {
            //        if (objBSS.OrderNotificationMailforTDM(cmbLob.SelectedValue, cmbService.SelectedValue, cmbInfra.SelectedValue, "SignUp", LastSignupID))
            //        {
            //            MessageFlag = MessageFlag + "1";
            //            SaveToolStripButton.Enabled = true;
            //        }
            //        else
            //        {
            //            MessageFlag = MessageFlag + "0";
            //        }

            //    }
            //    else
            //    {
            //        MessageFlag = MessageFlag + "00";
            //    }

            //}
            //catch (Exception ex)
            //{
            //    SaveToolStripButton.Enabled = true;
            //    clearTDMControls(form);
            //    Interaction.MsgBox("Error in Mailing TDM Signup Method ", MsgBoxStyle.Critical, "BSS Administrator");
            //    return;
            //}


            //try
            //{
            //    if (cbEmail.Checked == true)
            //    {
            //        if (objBSS.CustomerMailofTDM(LastSignupID))
            //        {
            //            MessageFlag = MessageFlag + "1";
            //        }
            //        else
            //        {
            //            MessageFlag = MessageFlag + "0";
            //        }
            //    }
            //    else
            //    {
            //        MessageFlag = MessageFlag + "0";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SaveToolStripButton.Enabled = true;
            //    clearTDMControls(form);
            //    Interaction.MsgBox("Error in Customer Mailing TDM Signup Method ", MsgBoxStyle.Critical, "BSS Administrator");
            //    return;
            //}

            //if (MessageFlag == "111")
            //{
            //    Interaction.MsgBox("Record Inserted Sucessfully", MsgBoxStyle.Information, "BSS Administrator");
            //    clearTDMControls(form);
            //    SaveToolStripButton.Enabled = true;
            //}
            //else if (MessageFlag == "110")
            //{
            //    Interaction.MsgBox("Record Inserted but Email to customer is not proceed", MsgBoxStyle.Information, "BSS Administrator");
            //    clearTDMControls(form);
            //    SaveToolStripButton.Enabled = true;
            //}
            //else if (MessageFlag == "100")
            //{
            //    Interaction.MsgBox("Record Inserted but both Email are not proceed", MsgBoxStyle.Information, "BSS Administrator");
            //    clearTDMControls(form);
            //    SaveToolStripButton.Enabled = true;
            //}
            //else if (MessageFlag == "000")
            //{
            //    Interaction.MsgBox("Record not Inserted", MsgBoxStyle.Information, "BSS Administrator");
            //    SaveToolStripButton.Enabled = true;
            //}

        }

        #endregion Functions


    }

        

       

        

        
    
}