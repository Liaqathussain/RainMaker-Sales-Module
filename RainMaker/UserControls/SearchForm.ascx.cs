using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.BSS_Service;
namespace RainMaker
{
    public partial class SearchForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        Service1SoapClient objBSS = new Service1SoapClient();
        BL obl = new BL();
        public void LoadComboBox() {


            obl.loadCircuitType(cmbCircuitType, 3);
            obl.loadCities(cmbCity);
            obl.LoadCircuitOwner(cmbCircuitOwner);
            obl.loadStatus(cmbStatus);
            obl.loadCusCode(cmbCustCode,null,"");
            obl.loadNode(cmbNode, 0, 0, "");
            obl.loadRing(cmbRing, 0, 0);
            obl.loadSwitches(cmbSwtich, 0, 0, 0);
            obl.loadSwitchedPorts(cmbSwitchPort, 0, "");
            obl.GetInfra(cmbInfra, 0, 0);
            obl.getServicesUnitByLOb(cmbService, 0);

        
        }
        public void SearchActiveCircuits()
        {
            try
            {
        /*        gvActiveCircuits.Columns("col_view").Visible = true;
                if (DepartmentID == 1 | DepartmentID == 3 | DepartmentID == 11)
                {
                    if (RoleID == 1 | RoleID == 31 | RoleID == 32)
                    {
                        gvActiveCircuits.Columns("col_Edit").Visible = true;
                    }
                }


                if (DepartmentID == 1 | DepartmentID == 10)
                {
                    if (RoleID == 1 | RoleID == 39)
                    {
                        gvActiveCircuits.Columns("colTerminated").Visible = true;
                    }
                }

                */
                int signupID = 0;   
                int IsExtraIP = 0;
                int SwitchPortID = 0;
                if (string.IsNullOrEmpty(tbSignup.Text))
                {
                    signupID = 0;
                }
                else
                {
                    signupID = Convert.ToInt16(tbSignup.Text);
                }

                if ((cmbSwitchPort.DataSource != null))
                {
                    SwitchPortID = Convert.ToInt16(cmbSwitchPort.SelectedValue);
                }

                if (tbExtra_IP.Text != string.Empty)
                {
                    IsExtraIP = 1;
                }
                else
                {
                    IsExtraIP = 0;

                }

                string BssCode=tbBSSCode.Text.ToString();
                string cmsid=tbCMSID.Text.ToString();
                string gpid=tbGPID.Text.ToString();
                string ippool = tbCusIPPool.Text.ToString();
                string priceip= tbPriCEPIP.Text.ToString();
                string extraip=tbExtra_IP.Text.ToString();
                string company=tbCompany.Text.ToString();
                dynamic dt = objBSS.SearchActiveCricuits(signupID,BssCode,cmsid , gpid,company ,Convert.ToInt16(cmbCircuitType.SelectedValue),Convert.ToInt16(cmbCity.SelectedValue),Convert.ToInt16(cmbInfra.SelectedValue),Convert.ToInt16(cmbService.SelectedValue),Convert.ToInt16(cmbCircuitOwner.SelectedValue),
               Convert.ToInt16(cmbStatus.SelectedValue),Convert.ToInt16(cmbCustCode.SelectedValue),Convert.ToInt16(cmbNode.SelectedValue),Convert.ToInt16(cmbRing.SelectedValue),Convert.ToInt16(cmbSwtich.SelectedValue),0, ippool,priceip,extraip , IsExtraIP);
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
                
                
              ///  dynamic dt = objBSS.SearchActiveCricuits(signupID,"", "", "","",0,0,0,0,0,0,0,0,0,0,0, "", "", "", IsExtraIP);
                
                lblCount.Text = Convert.ToString(dt.Rows.Count);
            //    if (dt.Rows.Count > 0)
            //    {
            //        gvActiveCircuits.DataSource = dt;
            //        gvActiveCircuits.Columns["InfraID"].Visible = false;
            //        gvActiveCircuits.Columns["StatusID"].Visible = false;
            //        //DisableLastColums();

            //    }
            //    else
            //    {
            //        gvActiveCircuits.DataSource = null;
            //        gvActiveCircuits.Rows.Clear();
            //        Interaction.MsgBox("No Record Found ", MsgBoxStyle.Information, "BSS Administrator");
            //    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            SearchActiveCircuits();
        }




    }
}