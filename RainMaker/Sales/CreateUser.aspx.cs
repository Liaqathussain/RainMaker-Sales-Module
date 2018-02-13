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
    public partial class WebForm8 : System.Web.UI.Page
    {
        Cls_Territory obj_TerrQut = new Cls_Territory();
        string UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Designation combo
                DataTable dt = obj_TerrQut.GetDesignation();
                cmbDesignation.DataSource = dt;
                cmbDesignation.DataTextField = "Designation";
                cmbDesignation.DataValueField = "ID";
                cmbDesignation.DataBind();
                cmbDesignation.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Department Combo
                DataTable dtdept = obj_TerrQut.GetDepartment();
                cmbDepartment.DataSource = dtdept;
                cmbDepartment.DataTextField = "Department";
                cmbDepartment.DataValueField = "DepartmentID";
                cmbDepartment.DataBind();
                cmbDepartment.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Department Combo
                DataTable dtsubdept = obj_TerrQut.GetSubDepartment();
                cmbSubDeptName.DataSource = dtsubdept;
                cmbSubDeptName.DataTextField = "SubDepName";
                cmbSubDeptName.DataValueField = "SubDepID";
                cmbSubDeptName.DataBind();
                cmbSubDeptName.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                ////Service Unit Combo
                //DataTable dtServiceUnit = obj_TerrQut.GetServiceUnitSysUser();
                //cmbServiceUnit.DataSource = dtServiceUnit;
                //cmbServiceUnit.DataTextField = "ServiceUnit";
                //cmbServiceUnit.DataValueField = "ServiceUnitID";
                //cmbServiceUnit.DataBind();
                //cmbServiceUnit.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //LOB Combo
                DataTable dtLOB = obj_TerrQut.GetLOBForSysUsers();
                cmbLOB.DataSource = dtLOB;
                cmbLOB.DataTextField = "LOB";
                cmbLOB.DataValueField = "LOB_ID";
                cmbLOB.DataBind();
                cmbLOB.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Status Combo
                DataTable dtStatus = obj_TerrQut.Getstatus();
                lbluserStatus.DataSource = dtStatus;
                lbluserStatus.DataTextField = "Status";
                lbluserStatus.DataValueField = "StatusID";
                lbluserStatus.DataBind();
                lbluserStatus.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Resource Role Combo
                DataTable dtResourceRole = obj_TerrQut.GetResourceRole();
                cmbResourceRole.DataSource = dtResourceRole;
                cmbResourceRole.DataTextField = "RoleName";
                cmbResourceRole.DataValueField = "RoleID";
                cmbResourceRole.DataBind();
                cmbResourceRole.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Reporting Manager Combo
                DataTable dtReportingManager = obj_TerrQut.GetReportingManager();
                cmbReportingManager.DataSource = dtReportingManager;
                cmbReportingManager.DataTextField = "Name";
                cmbReportingManager.DataValueField = "UserID";
                cmbReportingManager.DataBind();
                cmbReportingManager.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Region Combo
                DataTable dtRegion = obj_TerrQut.GetRegionforSysUsers();
                cmbRegion.DataSource = dtRegion;
                cmbRegion.DataTextField = "RegionName";
                cmbRegion.DataValueField = "RegionID";
                cmbRegion.DataBind();
                cmbRegion.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));

                //Grid view Data
                UserGridview();

                //Domain Combo
                DataTable dtDomain = obj_TerrQut.GetDomain();
                cmbDomain.DataSource = dtDomain;
                cmbDomain.DataTextField = "Domain";
                cmbDomain.DataValueField = "DomainID";
                cmbDomain.DataBind();
                cmbDomain.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
            }

        }

        protected void UserGridview()
        {
            DataTable dtSysUsers = obj_TerrQut.GetSysUsers();
            //GVUsers.DataSource = dtSysUsers;
            GVUsers.DataSource = dtSysUsers;
            GVUsers.DataBind();
            GVUsers.MasterTableView.GetColumn("StatusID").Visible = false;
            GVUsers.MasterTableView.GetColumn("DepartmentID").Visible = false;
            GVUsers.MasterTableView.GetColumn("RoleID").Visible = false;
            GVUsers.MasterTableView.GetColumn("ManagerID").Visible = false;
            GVUsers.MasterTableView.GetColumn("DesignationID").Visible = false;
            GVUsers.MasterTableView.GetColumn("LOBID").Visible = false;
            GVUsers.MasterTableView.GetColumn("SubDepID").Visible = false;
            GVUsers.MasterTableView.GetColumn("DomainID").Visible = false;
            GVUsers.MasterTableView.GetColumn("RegionID").Visible = false;
            GVUsers.MasterTableView.GetColumn("UserID").Visible = false;
            GVUsers.MasterTableView.GetColumn("Email").Visible = false;
            GVUsers.MasterTableView.GetColumn("Password").Visible = false;
            GVUsers.MasterTableView.GetColumn("Phone").Visible = false;

        }

        protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (e.Item.Text == "Save")
            {
                object obj_nrfid = obj_TerrQut.InsertSystemUsers(txtName.Text, txtUserName.Text, cmbDepartment.SelectedValue.ToString(), cmbDesignation.SelectedValue.ToString(), cmbResourceRole.SelectedValue.ToString(), txtEmail.Text, txtpassword.Text, cmbLOB.SelectedValue.ToString(), cmbSubDeptName.SelectedValue.ToString(), cmbReportingManager.SelectedValue.ToString(), txtPhone.Text, lbluserStatus.SelectedValue.ToString(), cmbRegion.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString(), Session["UserID"].ToString());
                // Name, DepartmentID, Username, [Password], RoleID, ManagerID, DesignationID, Email, Phone, SubDepID, LOBID, Domain, Region, CreatedBy, TransactionDateTime, IsADAuthenticate, IsActive
                //Grid view Data
                UserGridview();

            }

            if (e.Item.Text == "Update")
            {
                object obj_nrfid = obj_TerrQut.UpdateUsers(txtName.Text, txtUserName.Text, cmbDepartment.SelectedValue.ToString(), cmbDesignation.SelectedValue.ToString(), cmbResourceRole.SelectedValue.ToString(), txtEmail.Text, txtpassword.Text, cmbLOB.SelectedValue.ToString(), cmbSubDeptName.SelectedValue.ToString(), cmbReportingManager.SelectedValue.ToString(), txtPhone.Text, lbluserStatus.SelectedValue.ToString(), cmbRegion.SelectedValue.ToString(), cmbDomain.SelectedValue.ToString(), ViewState["UserID"].ToString());

                //Grid view Data
                UserGridview();

            }
        }

        protected void GVUsers_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }

        protected void GVUsers_InsertCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void GVUsers_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = e.Item.ItemIndex;
                GridDataItem item = (GridDataItem)GVUsers.Items[index];

                txtName.Text = item["Name"].Text;
                txtUserName.Text = item["Username"].Text;

                cmbDesignation.DataTextField = item["Designation"].Text;
                cmbDesignation.SelectedValue = item["DesignationID"].Text;

                cmbResourceRole.DataTextField = item["RoleName"].Text;
                cmbResourceRole.SelectedValue = item["RoleID"].Text;

                cmbDepartment.DataTextField = item["Department"].Text;
                cmbDepartment.SelectedValue = item["DepartmentID"].Text;

                cmbLOB.DataTextField = item["LOB"].Text;
                cmbLOB.SelectedValue = item["LOBID"].Text;

                cmbReportingManager.DataTextField = item["ManagerName"].Text;
                cmbReportingManager.SelectedValue = item["ManagerID"].Text;

                //Reporting Manager Combo
                DataTable dtReportingManager = obj_TerrQut.GetReportingManagerByUserID(cmbReportingManager.SelectedValue);
                if (dtReportingManager.Rows.Count > 0)
                {
                    cmbReportingManager.DataSource = dtReportingManager;
                    cmbReportingManager.DataTextField = "Name";
                    cmbReportingManager.DataValueField = "UserID";
                    cmbReportingManager.DataBind();
                    cmbReportingManager.Items.Insert(0, new RadComboBoxItem("Please Select", "0"));
                }

                txtEmail.Text = item["Email"].Text;

                lbluserStatus.DataTextField = item["Status"].Text;
                lbluserStatus.SelectedValue = item["StatusID"].Text;

                txtPhone.Text = item["Phone"].Text;
                txtpassword.Text = item["Password"].Text;

                cmbRegion.DataTextField = item["RegionName"].Text;
                cmbRegion.SelectedValue = item["RegionID"].Text;


                cmbDomain.DataTextField = item["Domain"].Text;
                cmbDomain.SelectedValue = item["DomainID"].Text;


                ViewState["UserID"] = item["UserID"].Text;


            }
        }
    }
}