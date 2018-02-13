<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SingleSMS.aspx.cs" Inherits="RainMaker.SMS_Integrator.SingleSMS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h5 class="center-block" style="text-align: center; color: White;">
                    Single SMS</h5>
            </div>
        </div>
        <div class="container">        

            <table>
            <tr>
            <td>
             Mobile No
            </td>
            <td>
             <telerik:RadTextBox ID="tbMobileNo" runat="server"></telerik:RadTextBox>
             <asp:Label ID="lblValidationMsg"  ForeColor="Red" runat="server" Text="Format for eg 923xxxxxxxxx"></asp:Label>
            </td>

            </tr>

            <tr>
            <td>
            Message
            
            </td>
            <td>
             <telerik:RadTextBox ID="tbSMS" runat="server" TextMode="MultiLine" Height="200px" Width="300px"></telerik:RadTextBox>
            <asp:Label ID="lblSave" Visible="false" ForeColor="Blue" runat="server" Text=""></asp:Label>
            </td>

            <td>
            <asp:Label ID="lblNotify" Visible="false" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
            </tr>            
            </table>

            <table>
            <tr>
            <td >
            <telerik:RadButton ID="btSend" Text="Send" OnClick="btnSend_Click" style="margin-left: 193px;" runat="server" >
            </telerik:RadButton>
            </td>
            </tr>
            </table>
        </div>
    </div>
</asp:Content>
