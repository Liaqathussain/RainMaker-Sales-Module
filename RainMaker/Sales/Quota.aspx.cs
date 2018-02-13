using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RainMaker.Classes;
using System.Data;
using Telerik.Web.UI;

namespace RainMaker
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Cls_Territory obj_TerrQut = new Cls_Territory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = obj_TerrQut.GetLOB();
                cmbLOB.DataSource = dt;
                cmbLOB.DataTextField = "LOB";
                cmbLOB.DataValueField = "LOB_ID";
                cmbLOB.DataBind();
                cmbLOB.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                DataTable dtRegion = obj_TerrQut.GetRegion();
                RegionName.DataSource = dtRegion;
                RegionName.DataTextField = "RegionName";
                RegionName.DataValueField = "RegionID";
                RegionName.DataBind();
                RegionName.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                cmbQRegionName.DataSource = dtRegion;
                cmbQRegionName.DataTextField = "RegionName";
                cmbQRegionName.DataValueField = "RegionID";
                cmbQRegionName.DataBind();
                cmbQRegionName.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));



                DataTable dtTerritoryHead = obj_TerrQut.GetTerritoryHead();
                cmbTerritoryOwner.DataSource = dtTerritoryHead;
                cmbTerritoryOwner.DataTextField = "UserName";
                cmbTerritoryOwner.DataValueField = "UserID";
                cmbTerritoryOwner.DataBind();
                cmbTerritoryOwner.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                DataTable dtSUnit = obj_TerrQut.GetServiceUnit();
                cmbServiceUnitID.DataSource = dtSUnit;
                cmbServiceUnitID.DataTextField = "ServiceUnit";
                cmbServiceUnitID.DataValueField = "ServiceUnitID";
                cmbServiceUnitID.DataBind();
                cmbServiceUnitID.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                DataTable dtstatus = obj_TerrQut.GetStatus();
                cmbStatus.DataSource = dtstatus;
                cmbStatus.DataTextField = "Status";
                cmbStatus.DataValueField = "StatusID";
                cmbStatus.DataBind();
                cmbStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                DataTable dtDomain = obj_TerrQut.GetDomain();
                cmbDomain.DataSource = dtDomain;
                cmbDomain.DataTextField = "Domain";
                cmbDomain.DataValueField = "DomainID";
                cmbDomain.DataBind();
                cmbDomain.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                cmbQDomain.DataSource = dtDomain;
                cmbQDomain.DataTextField = "Domain";
                cmbQDomain.DataValueField = "DomainID";
                cmbQDomain.DataBind();
                cmbQDomain.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));



                DataTable dtFiscalYear = obj_TerrQut.GetFiscalYear();
                cmbFiscalyear.DataSource = dtFiscalYear;
                cmbFiscalyear.DataTextField = "PlanName";
                cmbFiscalyear.DataValueField = "QuotaID";
                cmbFiscalyear.DataBind();
                cmbFiscalyear.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Grid view
                CallGridview();

            }
        }

        protected void CallGridview()
        {
            DataTable dtGridView = obj_TerrQut.GetTerritoryQuotasOnly();
            GVQuotas.DataSource = dtGridView;

            if (dtGridView.Rows.Count > 0)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.AddRange(new DataColumn[] 
                    {
		                new DataColumn("RegionID"),
		                new DataColumn("PlanName"),
                        new DataColumn("LOB"),
                        new DataColumn("LOB_ID"),
                        new DataColumn("RegionName"),
                        new DataColumn("Domain"),
                        new DataColumn("DomainID"),
                        new DataColumn("QuotaAmount"),
                        new DataColumn("RegionalHeadQuota"),
                        new DataColumn("UserName"),
                        new DataColumn("UserID"),
                        new DataColumn("QuotaID"),
                        new DataColumn("Status"),
                        new DataColumn("IsActive")
	                });
                for (int i = 0; i <= dtGridView.Rows.Count - 1; i++)
                {
                    dt1.Rows.Add(dtGridView.Rows[i]["RegionID"],
                    dtGridView.Rows[i]["PlanName"].ToString(),
                    dtGridView.Rows[i]["LOB"].ToString(),
                    dtGridView.Rows[i]["LOB_ID"].ToString(),
                    dtGridView.Rows[i]["RegionName"].ToString(),
                    dtGridView.Rows[i]["Domain"].ToString(),
                    dtGridView.Rows[i]["DomainID"].ToString(),
                    dtGridView.Rows[i]["QuotaAmount"].ToString(),
                    dtGridView.Rows[i]["RegionalHeadQuota"].ToString(),
                    dtGridView.Rows[i]["UserName"].ToString(),
                    dtGridView.Rows[i]["UserID"].ToString(),
                    dtGridView.Rows[i]["QuotaID"].ToString(),
                    dtGridView.Rows[i]["Status"].ToString(),
                    dtGridView.Rows[i]["IsActive"].ToString()
                    );
                }
                GVQuotas.DataSource = dt1;
                GVQuotas.DataBind();
                GVQuotas.MasterTableView.GetColumn("RegionID").Visible = false;
                GVQuotas.MasterTableView.GetColumn("QuotaID").Visible = false;
                GVQuotas.MasterTableView.GetColumn("UserID").Visible = false;
                GVQuotas.MasterTableView.GetColumn("LOB_ID").Visible = false;
                GVQuotas.MasterTableView.GetColumn("DomainID").Visible = false;
                GVQuotas.MasterTableView.GetColumn("IsActive").Visible = false;
            }
        }
        protected void btnSaveTerritory_Click(object sender, EventArgs e)
        {
            Cls_Territory obj_TerrQut = new Cls_Territory();

            if (txtQuotaPlanName.Text != "" && txtTerritoryQuota.Text != "" && DTStartDate.SelectedDate.ToString() != "" && DTEndDate.SelectedDate.ToString() != "" && cmbTerritoryOwner.Text != "" && txtOwnerQuotas.Text != "" && cmbStatus.Text != "")
            {
                object obj_nrfid = obj_TerrQut.InsertTerritoryQuotas(txtQuotaPlanName.Text, cmbLOB.SelectedValue.ToString(), RegionName.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString(), txtTerritoryQuota.Text, DTStartDate.SelectedDate.ToString(), DTEndDate.SelectedDate.ToString(), cmbTerritoryOwner.SelectedValue.ToString(), txtOwnerQuotas.Text, cmbServiceUnitID.SelectedValue.ToString(), cmbStatus.SelectedValue.ToString(), "1", DateTime.Now.ToString());

                //Grid view
                CallGridview();

            }

        }

        protected void cmbLOB_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbForTargetPlain_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtTQuota = obj_TerrQut.GetTerritoryQuotas();

            //lblTerritoryName.Text = dtTQuota.Rows(
        }

        protected void TerritoryName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //DataTable dtRegion = obj_TerrQut.GetRegionByTerritory(RegionName.Text);
            //txtFiscalYear1.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear2.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear3.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear4.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear5.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear6.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear7.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear8.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear9.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear10.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear11.Text = dtRegion.Rows[0]["PlanName"].ToString();
            //txtFiscalYear12.Text = dtRegion.Rows[0]["PlanName"].ToString();


            //lblTerritoryTargName.Text = dtRegion.Rows[0]["TerritoryName"].ToString();
            //lblTerritoryQuota.Text = dtRegion.Rows[0]["QuotaAmount"].ToString();
            //lblRegName.Text = dtRegion.Rows[0]["RegionName"].ToString();
            //lblRegionHead.Text = dtRegion.Rows[0]["UserName"].ToString();
            //lblRegHeadQuota.Text = dtRegion.Rows[0]["RegionalHeadQuota"].ToString();
        }

        protected void txtAmount1_TextChanged(object sender, EventArgs e)
        {
            txtPercentage1.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = txtAmount1.Text;
        }

        protected void txtAmount2_TextChanged(object sender, EventArgs e)
        {
            txtPercentage2.Text = Convert.ToString(Convert.ToInt32(txtAmount2.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text));
        }

        protected void txtAmount3_TextChanged(object sender, EventArgs e)
        {
            txtPercentage3.Text = Convert.ToString(Convert.ToInt32(txtAmount3.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text));
        }

        protected void txtAmount4_TextChanged(object sender, EventArgs e)
        {
            txtPercentage4.Text = Convert.ToString(Convert.ToInt32(txtAmount4.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text));
        }

        protected void txtAmount5_TextChanged(object sender, EventArgs e)
        {
            txtPercentage5.Text = Convert.ToString(Convert.ToInt32(txtAmount5.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text));
        }

        protected void txtAmount6_TextChanged(object sender, EventArgs e)
        {
            txtPercentage6.Text = Convert.ToString(Convert.ToInt32(txtAmount6.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text));
        }

        protected void txtAmount7_TextChanged(object sender, EventArgs e)
        {
            txtPercentage7.Text = Convert.ToString(Convert.ToInt32(txtAmount7.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text));
        }

        protected void txtAmount8_TextChanged(object sender, EventArgs e)
        {
            txtPercentage8.Text = Convert.ToString(Convert.ToInt32(txtAmount8.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text) + Convert.ToInt32(txtAmount8.Text));
        }

        protected void txtAmount9_TextChanged(object sender, EventArgs e)
        {
            txtPercentage9.Text = Convert.ToString(Convert.ToInt32(txtAmount9.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text) + Convert.ToInt32(txtAmount8.Text) + Convert.ToInt32(txtAmount9.Text));
        }

        protected void txtAmount10_TextChanged(object sender, EventArgs e)
        {
            txtPercentage10.Text = Convert.ToString(Convert.ToInt32(txtAmount10.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text) + Convert.ToInt32(txtAmount8.Text) + Convert.ToInt32(txtAmount9.Text) + Convert.ToInt32(txtAmount10.Text));
        }

        protected void txtAmount11_TextChanged(object sender, EventArgs e)
        {
            txtPercentage11.Text = Convert.ToString(Convert.ToInt32(txtAmount11.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text) + Convert.ToInt32(txtAmount8.Text) + Convert.ToInt32(txtAmount9.Text) + Convert.ToInt32(txtAmount10.Text) + Convert.ToInt32(txtAmount11.Text));
        }

        protected void txtAmount12_TextChanged(object sender, EventArgs e)
        {
            txtPercentage12.Text = Convert.ToString(Convert.ToInt32(txtAmount12.Text) * 100 / Convert.ToInt32(lblTerritoryQuota.Text) + "%");
            lblTotalTarget.Text = Convert.ToString(Convert.ToInt32(txtAmount1.Text) + Convert.ToInt32(txtAmount2.Text) + Convert.ToInt32(txtAmount3.Text) + Convert.ToInt32(txtAmount4.Text) + Convert.ToInt32(txtAmount5.Text) + Convert.ToInt32(txtAmount6.Text) + Convert.ToInt32(txtAmount7.Text) + Convert.ToInt32(txtAmount8.Text) + Convert.ToInt32(txtAmount9.Text) + Convert.ToInt32(txtAmount10.Text) + Convert.ToInt32(txtAmount11.Text) + Convert.ToInt32(txtAmount12.Text));
        }

        protected void cmbTerritoryOwner_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (e.Item.Text == "Save")
            {
                if (Convert.ToInt32(lblTotalTarget.Text) == Convert.ToInt32(lblTerritoryQuota.Text) && cmbQRegionName.Text != "Please Select" && cmbQDomain.Text != "Please Select")
                {
                    object obj_nrfid = obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month1.Text, lblQuarter1.Text, StartDate1.SelectedDate.ToString(), EndDate1.SelectedDate.ToString(), txtFiscalYear1.Text, txtAmount1.Text, txtPercentage1.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month2.Text, lblQuarter1.Text, StartDate2.SelectedDate.ToString(), EndDate2.SelectedDate.ToString(), txtFiscalYear2.Text, txtAmount2.Text, txtPercentage2.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month3.Text, lblQuarter1.Text, StartDate3.SelectedDate.ToString(), EndDate3.SelectedDate.ToString(), txtFiscalYear3.Text, txtAmount3.Text, txtPercentage3.Text, "1", "1", DateTime.Now.ToString());
                    //Second Quarter
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month4.Text, lblQuarter2.Text, StartDate4.SelectedDate.ToString(), EndDate4.SelectedDate.ToString(), txtFiscalYear4.Text, txtAmount4.Text, txtPercentage4.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month5.Text, lblQuarter2.Text, StartDate5.SelectedDate.ToString(), EndDate5.SelectedDate.ToString(), txtFiscalYear5.Text, txtAmount5.Text, txtPercentage5.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month6.Text, lblQuarter2.Text, StartDate6.SelectedDate.ToString(), EndDate6.SelectedDate.ToString(), txtFiscalYear6.Text, txtAmount6.Text, txtPercentage6.Text, "1", "1", DateTime.Now.ToString());
                    //Third Quarter
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month7.Text, lblQuarter3.Text, StartDate7.SelectedDate.ToString(), EndDate7.SelectedDate.ToString(), txtFiscalYear7.Text, txtAmount7.Text, txtPercentage7.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month8.Text, lblQuarter3.Text, StartDate8.SelectedDate.ToString(), EndDate8.SelectedDate.ToString(), txtFiscalYear8.Text, txtAmount8.Text, txtPercentage8.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month9.Text, lblQuarter3.Text, StartDate9.SelectedDate.ToString(), EndDate9.SelectedDate.ToString(), txtFiscalYear9.Text, txtAmount9.Text, txtPercentage9.Text, "1", "1", DateTime.Now.ToString());
                    //Forth Quarter
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month10.Text, lblQuarter4.Text, StartDate10.SelectedDate.ToString(), EndDate10.SelectedDate.ToString(), txtFiscalYear10.Text, txtAmount10.Text, txtPercentage10.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month11.Text, lblQuarter4.Text, StartDate11.SelectedDate.ToString(), EndDate11.SelectedDate.ToString(), txtFiscalYear11.Text, txtAmount11.Text, txtPercentage11.Text, "1", "1", DateTime.Now.ToString());
                    obj_TerrQut.InsertTargets(ViewState["QuotaID"].ToString(), Month12.Text, lblQuarter4.Text, StartDate12.SelectedDate.ToString(), EndDate12.SelectedDate.ToString(), txtFiscalYear12.Text, txtAmount12.Text, txtPercentage12.Text, "1", "1", DateTime.Now.ToString());
                    lblStatus.Text = "Saved Successfully";
                }
                else
                {
                    lblStatus.Text = "Target not matched or required Field";
                }
            }
            if (e.Item.Text == "Update")
            {
                object obj_nrfid = obj_TerrQut.UpdateQuotas(ViewState["QuotasID"].ToString(), txtQuotaPlanName.Text, RegionName.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString(), txtTerritoryQuota.Text, cmbTerritoryOwner.SelectedValue.ToString(), txtOwnerQuotas.Text, cmbStatus.SelectedValue.ToString());
                //Grid view 
                CallGridview();
                //Fiscal Year combo box updated
                DataTable dtFiscalYear = obj_TerrQut.GetFiscalYear();
                cmbFiscalyear.DataSource = dtFiscalYear;
                cmbFiscalyear.DataTextField = "PlanName";
                cmbFiscalyear.DataValueField = "QuotaID";
                cmbFiscalyear.DataBind();
                cmbFiscalyear.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }
        }

        protected void cmbFiscalyear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataTable dtTerritoryQuota = obj_TerrQut.GetTerritoryQuotaforTargets(cmbFiscalyear.Text);
            if (dtTerritoryQuota.Rows.Count > 0)
            {
                lblTerritoryQuota.Text = dtTerritoryQuota.Rows[0]["QuotaAmount"].ToString();

                // DataTable dtRegion = obj_TerrQut.GetRegionByTerritory(RegionName.Text);
                txtFiscalYear1.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear2.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear3.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear4.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear5.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear6.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear7.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear8.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear9.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear10.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear11.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();
                txtFiscalYear12.Text = dtTerritoryQuota.Rows[0]["PlanName"].ToString();

                ViewState["QuotaID"] = dtTerritoryQuota.Rows[0]["QuotaID"].ToString();

            }

        }

        protected void btnSearchQ_Click(object sender, EventArgs e)
        {
            DataTable dtRegion = obj_TerrQut.GetRegionByTerritory(cmbFiscalyear.Text, cmbQRegionName.Text, cmbQDomain.Text);



            if (dtRegion.Rows.Count > 0)
            {

                txtFiscalYear1.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear2.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear3.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear4.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear5.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear6.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear7.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear8.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear9.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear10.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear11.Text = dtRegion.Rows[0]["PlanName"].ToString();
                txtFiscalYear12.Text = dtRegion.Rows[0]["PlanName"].ToString();
                //-------------------------------------------------------------------
                if (dtRegion.Rows[0]["TargetAmount"].ToString() != "")
                {
                    txtAmount1.Text = dtRegion.Rows[0]["TargetAmount"].ToString();
                    txtAmount2.Text = dtRegion.Rows[1]["TargetAmount"].ToString();
                    txtAmount3.Text = dtRegion.Rows[2]["TargetAmount"].ToString();

                    txtAmount4.Text = dtRegion.Rows[3]["TargetAmount"].ToString();
                    txtAmount5.Text = dtRegion.Rows[4]["TargetAmount"].ToString();
                    txtAmount6.Text = dtRegion.Rows[5]["TargetAmount"].ToString();

                    txtAmount7.Text = dtRegion.Rows[6]["TargetAmount"].ToString();
                    txtAmount8.Text = dtRegion.Rows[7]["TargetAmount"].ToString();
                    txtAmount9.Text = dtRegion.Rows[8]["TargetAmount"].ToString();

                    txtAmount10.Text = dtRegion.Rows[9]["TargetAmount"].ToString();
                    txtAmount11.Text = dtRegion.Rows[10]["TargetAmount"].ToString();
                    txtAmount12.Text = dtRegion.Rows[11]["TargetAmount"].ToString();

                    //------------------------------
                    txtPercentage1.Text = dtRegion.Rows[0]["QuotaPercentage"].ToString();
                    txtPercentage2.Text = dtRegion.Rows[1]["QuotaPercentage"].ToString();
                    txtPercentage3.Text = dtRegion.Rows[2]["QuotaPercentage"].ToString();

                    txtPercentage4.Text = dtRegion.Rows[3]["QuotaPercentage"].ToString();
                    txtPercentage5.Text = dtRegion.Rows[4]["QuotaPercentage"].ToString();
                    txtPercentage6.Text = dtRegion.Rows[5]["QuotaPercentage"].ToString();

                    txtPercentage7.Text = dtRegion.Rows[6]["QuotaPercentage"].ToString();
                    txtPercentage8.Text = dtRegion.Rows[7]["QuotaPercentage"].ToString();
                    txtPercentage9.Text = dtRegion.Rows[8]["QuotaPercentage"].ToString();

                    txtPercentage10.Text = dtRegion.Rows[9]["QuotaPercentage"].ToString();
                    txtPercentage11.Text = dtRegion.Rows[10]["QuotaPercentage"].ToString();
                    txtPercentage12.Text = dtRegion.Rows[11]["QuotaPercentage"].ToString();
                    //---------------------------------
                }

            }
            else
            {
                txtAmount1.Text = "";
                txtAmount2.Text = "";
                txtAmount3.Text = "";

                txtAmount4.Text = "";
                txtAmount5.Text = "";
                txtAmount6.Text = "";

                txtAmount7.Text = "";
                txtAmount8.Text = "";
                txtAmount9.Text = "";

                txtAmount10.Text = "";
                txtAmount11.Text = "";
                txtAmount12.Text = "";

                //------------------------------
                txtPercentage1.Text = "";
                txtPercentage2.Text = "";
                txtPercentage3.Text = "";

                txtPercentage4.Text = "";
                txtPercentage5.Text = "";
                txtPercentage6.Text = "";

                txtPercentage7.Text = "";
                txtPercentage8.Text = "";
                txtPercentage9.Text = "";

                txtPercentage10.Text = "";
                txtPercentage11.Text = "";
                txtPercentage12.Text = "";
                //-------------------------
                txtFiscalYear1.Text = "";
                txtFiscalYear2.Text = "";
                txtFiscalYear3.Text = "";
                txtFiscalYear4.Text = "";
                txtFiscalYear5.Text = "";
                txtFiscalYear6.Text = "";
                txtFiscalYear7.Text = "";
                txtFiscalYear8.Text = "";
                txtFiscalYear9.Text = "";
                txtFiscalYear10.Text = "";
                txtFiscalYear11.Text = "";
                txtFiscalYear12.Text = "";
            }
        }

        protected void cmbDomain_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void cmbQRegionName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void GVQuotas_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void GVQuotas_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVQuotas.Items[index];
                //Get the values from the row uaing the columnUniqueName 
                txtQuotaPlanName.Text = item["PlanName"].Text;

                RegionName.DataTextField = item["RegionName"].Text;
                RegionName.SelectedValue = item["RegionID"].Text;

                cmbTerritoryOwner.DataTextField = item["UserName"].Text;
                cmbTerritoryOwner.SelectedValue = item["UserID"].Text;

                cmbLOB.DataTextField = item["LOB"].Text;
                cmbLOB.SelectedValue = item["LOB_ID"].Text;

                cmbDomain.DataTextField = item["Domain"].Text;
                cmbDomain.SelectedValue = item["DomainID"].Text;

                txtOwnerQuotas.Text = item["RegionalHeadQuota"].Text;

                txtTerritoryQuota.Text = item["QuotaAmount"].Text;

                cmbStatus.DataTextField = item["Status"].Text;
                cmbStatus.SelectedValue = item["IsActive"].Text;

                ViewState["QuotasID"] = item["QuotaID"].Text;


            }
        }
    }
}