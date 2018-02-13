using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

namespace RainMaker.UserControls
{
    public partial class pnl_Misc : System.Web.UI.UserControl
    {
        BL objBL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region EVENTS

        protected void cmbCity_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            objBL.loadLoca(cmbLocationCode, Convert.ToInt32(cmbCity.SelectedValue));
            objBL.loadExchangeArea(cmbExcArea, cmbNode, Convert.ToInt32(cmbCity.SelectedValue), "insert");
        }

        protected void cmbCustomerCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            objBL.loadProject(cmbProjectCode, Convert.ToInt32(cmbCustomerCode.SelectedValue));
        }

        protected void cbSame_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSame.Checked == true)
            {
                tbBIName.Text = tbName.Text;
                tbBICompany.Text = tbCompany.Text;
                tbBICell.Text = tbCell.Text;
                tbBIAddress.Text = tbAddress.Text;
                tbBIEmail.Text = tbEmail.Text;
            }
            else
            {
                tbBIName.Text = string.Empty;
                tbBICompany.Text = string.Empty;
                tbBICell.Text = string.Empty;
                tbBIAddress.Text = string.Empty;
                tbBIEmail.Text = string.Empty;
            }
        }

        protected void cmbBICircuitOwner_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbBICircuitOwner.SelectedIndex == 2 || cmbBICircuitOwner.SelectedIndex == 3)
            {
                pnlBIThirdPartyCharges.Visible = true;
                objBL.loadTypeDescbyOwnerID(cmbBI3rdPartyName, Convert.ToInt32(cmbBICircuitOwner.SelectedValue));
            }
            else
            {
                pnlBIThirdPartyCharges.Visible = false;
            }
        }

        protected void cmbBICircuitType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbBICircuitType.SelectedIndex == 1)
            {
                lblBIBackupInfra.Visible = true;
                cmbBIBackupInfra.Visible = true;
                lblBIBackupOwner.Visible = true;
                cmbBIBackupOwner.Visible = true;
            }
            else
            {
                lblBIBackupInfra.Visible = false;
                cmbBIBackupInfra.Visible = false;
                lblBIBackupOwner.Visible = false;
                cmbBIBackupOwner.Visible = false;
                pnlBackupCharges.Visible = false;
            }
        }

        protected void cmbBIBackupOwner_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmbBIBackupOwner.SelectedValue == "0" || cmbBIBackupOwner.SelectedValue == "1")
            {
                pnlBackupCharges.Visible = false;
            }
            else if (cmbBIBackupOwner.SelectedValue == "2" || cmbBIBackupOwner.SelectedValue == "3")
            {
                objBL.loadTypeDescbyOwnerID(cmbBI3rdBackupParty, Convert.ToInt32(cmbBIBackupOwner.SelectedValue));
                pnlBackupCharges.Visible = true;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "Please-Select")
            {
                args.IsValid = false;
                Response.Write("Please Select Business Type");
            }
        }

        #endregion EVENTS

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (args.ToString() == "Please-Select")
            {
                args.IsValid = false;
            }
            args.IsValid = true;
        }

        #region Function



        #endregion
    }
}