<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lookup.aspx.cs" Inherits="RainMaker.NRF.Lookup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8"/>
    <title></title>
    <style type="text/css">
	  html, body, form
	  {
	    padding: 0;
	    margin: 0;
	  /*so that the autosize will work correctly, otherwise it will get the dimensions of the content - 500x500 and the margins and paddings will cause scrollbars*/
	  }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    
    <telerik:RadFormDecorator ID="RadFormDecorator1" DecoratedControls="All" runat="server" Skin="Office2007" />
    
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Office2007">   
    </telerik:RadAjaxLoadingPanel>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script language="javascript" type="text/javascript">
            var LookupName;
            var ReturnValue;

            function SelectRow(sender, args) {
                ReturnValue = args.getDataKeyValue("ID");
            }

            function CloseMe() {
                var oWindow = null;
                var oArg = new Object();
                oArg.ReturnValue = ReturnValue;
                oArg.LookupName = document.getElementById('<%= hdnLookupName.ClientID %>').value;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                if (oArg.ReturnValue) oWindow.close(oArg);
            }  
        </script>
    </telerik:RadCodeBlock>
    
    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Width ="100%" LoadingPanelID ="RadAjaxLoadingPanel1">
    <div style="width:100%">
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="grid_Lookup" runat="server" AllowFilteringByColumn="True" 
                    AllowPaging="True" AllowSorting="True" GridLines="None"
                    OnColumnCreated="grid_Lookup_ColumnCreated" Skin="Office2007">
                    <GroupingSettings CaseSensitive="false"/>
                    <MasterTableView TableLayout="Auto" DataKeyNames="ID" ClientDataKeyNames="ID">
                    </MasterTableView>
                    <ClientSettings ClientEvents-OnRowClick="SelectRow">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnRowClick="SelectRow" OnRowDblClick="CloseMe">
                        </ClientEvents>
                    </ClientSettings>
                    <PagerStyle Width="100%" />
                    <HeaderContextMenu EnableAutoScroll="True">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td align="right">
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                    <asp:Button ID="btnSelect" runat ="server" Width ="77px" 
                        onclick="btnSelect_Click" Text="Select" />
                </telerik:RadAjaxPanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </div>
    <asp:HiddenField ID="hdnLookupName" runat="server" />
    </telerik:RadAjaxPanel>    
    </div>
    </form>
</body>
</html>
