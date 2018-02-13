<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestExportExcel.aspx.cs" Inherits="RainMaker.TestExportExcel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
     
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   View Complains</h6>
            </div>
        </div>
    <div class="container-fluid">
   
   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/Excel_HTML.png"
            OnClick="ImageButton_Click" AlternateText="Html" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Images/Excel_ExcelML.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="Images/Excel_BIFF.png"
            OnClick="ImageButton_Click" AlternateText="Biff" />
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="Images/Excel_XLSX.png"
            OnClick="ImageButton_Click" AlternateText="Xlsx" />


            <table>
            <tr>
            <td>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Apply Custom Styles"></asp:CheckBox>
            </td>
            </tr>
            <tr>
            <td>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Apply Custom Styles"></asp:CheckBox>
            </td>
            </tr>
            
            </table>

           <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server" AllowPaging="true"
            PageSize="7" AutoGenerateColumns="false" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"
            OnItemCreated="RadGrid1_ItemCreated" OnHTMLExporting="RadGrid1_HtmlExporting" OnItemCommand="RadGrid1_ItemCommand"
            OnBiffExporting="RadGrid1_BiffExporting">
            <MasterTableView CommandItemDisplay="Top">
                <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                <Columns>
                    <telerik:GridBoundColumn DataField="LAT" HeaderText="LAT" HeaderStyle-Width="100px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LNG" HeaderText="LNG" HeaderStyle-Width="130px">
                    </telerik:GridBoundColumn>
                    
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

    </div>
    </div>



</asp:Content>
