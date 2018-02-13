<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addnewcity.aspx.cs" Inherits="RainMaker.TestTaimur.addnewcity" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 247px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
 <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   View City</h6>
            </div>
        </div>
    <div class="container-fluid">

    <table class="nav-justified">
            <tr>
                <td class="style1">
                    <telerik:RadButton ID="btSearch" runat="server" Text="Search" 
                        onclick="btSearch_Click">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btninsert" runat="server"  Text="Insert" 
                        onclick="btninsert_Click">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnupdate" runat="server"  Text="update">
                    </telerik:RadButton>
                    
                    </td>
                    </tr>
                    
                    <tr>
                    
                    <td>
                                Regions
                            </td>

                    <td>


                                <telerik:RadComboBox ID="cmbRegions" runat="server" 
                                    onselectedindexchanged="cmbRegions_SelectedIndexChanged"  >
                                </telerik:RadComboBox>
                            </td>

                             <td>
                                City
                            </td>
                    <td>
                    
                    <telerik:RadTextBox ID="txtCity" runat="server" >
                                </telerik:RadTextBox>
                    
                    </td>

                    <td>
                                CityCode
                            </td>

                    <td>
                    
                    <telerik:RadTextBox ID="txtCityCode" runat="server" >
                                </telerik:RadTextBox>
                    
                    </td>

                    </tr>



                    </table>

                    <telerik:RadGrid ID="gvGetCity" runat="server" Skin="Office2007">
                           
                        </telerik:RadGrid>


    </div>
    </div>

</asp:Content>
