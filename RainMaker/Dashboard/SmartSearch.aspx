<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SmartSearch.aspx.cs" Inherits="RainMaker.Dashboard.SmartSearch1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
        <div id="page-wrapper">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <label><h2>Search Complaint's</h2></label>
                            
                        <asp:TextBox ID="SmartText" runat="server" OnTextChanged="loadSearches" CssClass="btn-group-justified" placeholder="Smart Search" Font-Size="Medium"></asp:TextBox>
                             </h1>
                        
                        <!-- <ol class="breadcrumb"> -->
                            <!-- <li class="active"> -->
                                <!-- <i class="fa fa-dashboard"></i> Dashboard -->
                            <!-- </li> -->
                        <!-- </ol> -->
                    </div>
                    <div class="col-lg-2"><label>Count:</label><label id="CountLabel" runat="server">0</label></div>
                           <br />  
                </div>
                <!-- /.row -->
				<div class="row">
                    <div class="col-lg-12">
                        <div class="table-responsive ">
                        <asp:GridView CssClass="table table-condensed table-bordered table-hover table-striped" BorderWidth="5px" RowStyle-CssClass="info" HeaderStyle-CssClass="warning" ID="SearchResults" runat="server" AutoGenerateColumns="true"  Width="100%"  ViewStateMode="Enabled"  >

                        </asp:GridView>
                            </div>
                    </div>
				</div>

				
				
                <!-- <div class="row"> -->
                    <!-- <div class="col-lg-12"> -->
                        <!-- <div class="alert alert-info alert-dismissable"> -->
                            <!-- <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button> -->
                            <!-- <i class="fa fa-info-circle"></i>  <strong>Like SB Admin?</strong> Try out <a href="http://startbootstrap.com/template-overviews/sb-admin-2" class="alert-link">SB Admin 2</a> for additional features! -->
                        <!-- </div> -->
                    <!-- </div> -->
                <!-- </div> -->
                <!-- /.row -->

                <!-- /.row -->

                <!-- /.row -->

                <div class="row">
                <!-- /.row -->

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

    </div>

           </div>
    <!-- /#wrapper -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="js/plugins/morris/raphael.min.js"></script>
    <script src="js/plugins/morris/morris.min.js"></script>
    <script src="js/plugins/morris/morris-data.js"></script>

   
</asp:Content>
