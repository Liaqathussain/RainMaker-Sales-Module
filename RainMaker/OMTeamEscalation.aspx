<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OMTeamEscalation.aspx.cs" Inherits="RainMaker.WebForm4" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   O&M Team Escalation</h6>
            </div>
        </div>
    <div class="container-fluid">

   
        
    <asp:UpdatePanel ID="UPPanel2" runat="server">
        <ContentTemplate>
            
                <%--<table class="nav-justified">--%>
                 <table class="nav-justified">
            <tr>
                <td>
                     <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" Text="Update" />
                     
                </td>

                <td>                     
                     <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" />
                </td>
            </tr>



                    <tr>
                        <td>
                            <table class="nav-justified">
                                <tr>
                                    <td>
                                        SignUp ID
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtSignUpID" runat="server">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        City
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbCity" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        Customer Code
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbCustomerCode" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <%--<td>
                                        Region
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbRegion" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </td>--%>
                                    <td>
                                        Node
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="cmbNode" runat="server" Width="150px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                    
                                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                    
                                    </td>



                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="table-responsive">
                        <div class="table-responsive">
                        <asp:GridView ID="GVTeam" runat="server"  AutoGenerateColumns="False"
                            
                             ShowFooter="True" 
                            Width="915px" >
                            <Columns>
                              
                               <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" Text="Select" Width="80px" runat="server" />
                                </ItemTemplate>

                                 </asp:TemplateField>
                                <asp:BoundField DataField="ComplaintID" HeaderText ="Complaint ID" />
                                <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" />
                                <asp:BoundField DataField="CircuitName" HeaderText="Circuit Name" />
                                <asp:BoundField DataField="Node" HeaderText="Node" />
                                <asp:BoundField DataField="City" HeaderText="City" />

                          

                                <asp:TemplateField HeaderText="Team">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                    </div>
                    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
    
</asp:Content>
