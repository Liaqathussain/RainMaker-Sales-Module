<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="RainMaker.WebForm5" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

    <script type="text/javascript">
        function OnKeyPress(sender, eventArgs) {
            var c = eventArgs.get_keyCode();
            if (c == 13) {
                __doPostBack('btnUpdate', '');
                alert("ok");

            }
        } 
   </script> 
   
    <div id="page-wrapper">
    <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px; margin-top: -3.6em">
                <h6 class="center-block" style="text-align: center; color: White;">
                   Department SMS</h6>
            </div>
        </div>
    <div class="container-fluid">
    <%--<asp:Button ID="btnViewHistoryFiberDetails" OnClick="btnviewFiberHistory_Click" runat="server" Text="View History" />--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table>
    
    <tr>
    
    <td>
                                          City
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCity" 
                                                OnSelectedIndexChanged="cmbCity_SelectedIndexChanged" AutoPostBack="true" 
                                                runat="server" style="margin-left: 0px" >
                                            </telerik:RadComboBox>
                                        </td>

                                        <td>
                                            
                                        </td>

                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>

                                         <td>
                                            
                                        </td>

                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            
                                        </td>

                                        <td>
                                            Groups
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbGroup" OnSelectedIndexChanged="cmbGroup_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                            </telerik:RadComboBox>
                                        </td>

    </tr>

    
    
    
    </table>
    <table>
    
    
     <tr>
                <td>
                    <asp:CheckBox ID="chkIsSelectAll" OnCheckedChanged="chkIsSelectAll_changed" AutoPostBack="true" runat="server" Text="Select All" />
                    
                </td>
            </tr>
    
    </table>
       
         <%--<telerik:RadGrid ID="grdEmployee" OnNeedDataSource="grdEmployee_NeedDataSource" AllowPaging="True"  runat="server" Skin="Office2007">

          <Columns>
                                <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    </Columns>

         </telerik:RadGrid>--%>


           <telerik:RadGrid ID="grdEmployee" runat="server"  AllowSorting="True"
                            GridLines="None" Skin="Office2007" OnNeedDataSource="grdEmployee_NeedDataSource">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView  >
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                                   
                                </Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrev" />
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        </br>

         
        
   </ContentTemplate>     
   </asp:UpdatePanel>

   <table>
         <tr>
            <td>Sms  </td>
            <td><telerik:RadTextBox ID="tbSMS" runat="server" TextMode="MultiLine" Width="500px" Height="100px" >
                                </telerik:RadTextBox></td>
            <td>
                    <telerik:RadButton ID="btSend" OnClick="btnSend_Click" runat="server" Text="Send">
                    </telerik:RadButton>
                    </td>
            <td>
            <asp:Label ID="lblNotify" Visible="false" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
            </tr>
       
         </table>

    
   
    
   
  </div>
    </div>
</asp:Content>
