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
    public partial class pnl_TDM : System.Web.UI.UserControl
    {
        BL objBL = new BL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region EVENTS

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

        protected void cmbCustomerCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            objBL.loadProject(cmbProjectCode, Convert.ToInt32(cmbCustomerCode.SelectedValue));
        }

        #endregion EVENTS

    }
}