<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NRFItemsView.aspx.cs" Inherits="RainMaker.NRF.NRFItemsView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <style scoped>
        td
        {
            padding-top: 5px;
        }
    </style>

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
                margin-left: 0.2em; height: 30px;">
                <h6 class="center-block" style="text-align: center; color: White;">
                    Infra Costing</h6>
            </div>
        </div>
        <div class="container-fluid">
            <div>
            </div>
            <%--<telerik:RadButton ID="btSave" Text="Save" runat="server" OnClientClicked="OnClientButtonClicked"
                OnClick="btSave_Click">
            </telerik:RadButton>--%>
            <asp:UpdatePanel ID="UPPanel1" runat="server">
                <ContentTemplate>
                    <table class="style12">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <%-- <tr>
                    <td style="background-color: #03828a; font-weight: bold; font-size: medium; font-family: Calibri;
                        color: #FFFFFF;" width="1000px" bgcolor="#03828A">
                        Infra Costing
                    </td>
                </tr>--%>
                        <tr>
                            <td>
                                <table class="nav-justified">
                                    <tr>
                                        <td>
                                            Customer Name
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCustomerName" runat="server">
                                            </telerik:RadComboBox>
                                            <asp:Label ID="lblCustomerNameMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
                                        </td>
                                        <td>
                                            Circuit Name
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCircuitName" runat="server">
                                            </telerik:RadTextBox>
                                            <asp:Label ID="lblCircuitNameMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Site Address
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtSiteAddress" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCity" ReadOnly="true" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            Building
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbBuilding" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbBuilding_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Area
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbArea" AutoPostBack="true" runat="server" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Line of Business
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbLOB" runat="server" AutoPostBack="True" >
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Infra
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbInfra" runat="server" AutoPostBack="True" >
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Service
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbService" runat="server" AutoPostBack="True" >
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            POC Name:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCName" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            POC Contact:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCContact" runat="server">
                                                <ClientEvents OnKeyPress="keyPressPocContact" />
                                            </telerik:RadTextBox>
                                            <%--<telerik:RadNumericTextBox ID="txtPOCContact" runat="server">
                                    </telerik:RadNumericTextBox>--%>
                                        </td>
                                        <td>
                                            POC Email:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCEmail" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Capacity
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbCapacity" runat="server" AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            Industry
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbIndustry" runat="server" AutoPostBack="True">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            NRF Type
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtNRFType" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Region
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtRegion" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <asp:Label ID="lblNRFTypeError" runat="server" Style="color: Red;" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdnAreaID" runat="server" />
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="ItemPanel">
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManagerProxy>
                    <telerik:RadAjaxPanel ID="ItemPanel" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                        Width="100%">
                        <telerik:RadGrid runat="server" ID="grid_ItemDetail" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" ShowFooter="True" OnNeedDataSource="grid_ItemDetail_NeedDataSource"
                            OnUpdateCommand="grid_ItemDetail_UpdateCommand" OnInsertCommand="grid_ItemDetail_InsertCommand"
                            OnDeleteCommand="grid_ItemDetail_DeleteCommand" OnItemCreated="grid_ItemDetail_ItemCreated">
                            <MasterTableView CommandItemDisplay="Top" AutoGenerateColumns="false" EditMode="InPlace">
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" FooterText="Total" HeaderStyle-Width="7%"
                                        ItemStyle-BackColor="White" ItemStyle-Width="7%" UniqueName="EditCommandColumn1">
                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#000066" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" Width="7%" />
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridTemplateColumn DataField="ItemCode" HeaderStyle-Width="15%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="15%" UniqueName="ItemCode">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrItemCode" runat="server" Text="Item Code"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox ID="tbItemCode" runat="server" AutoPostBack="true" ClientEvents-OnButtonClick="ItemLookup"
                                                ShowButton="true" Text='<%# Bind("ItemCode") %>' Width="100%">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="15%" />
                                        <ItemStyle BackColor="White" Width="15%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ItemName" HeaderStyle-Width="19%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="19%" UniqueName="ItemName">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrItemDescription" runat="server" Text="Item Name"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbItemName" runat="server" Text='<%# Eval("ItemName") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="19%" />
                                        <ItemStyle BackColor="White" Width="19%" />
                                    </telerik:GridTemplateColumn>
                                    <%--<telerik:GridTemplateColumn DataField="Unit" HeaderStyle-Width="17%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="17%" UniqueName="Unit">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrUnit" runat="server" Text="Unit"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbUnit" runat="server" Text='<%# Eval("Unit") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="17%" />
                                        <ItemStyle BackColor="White" Width="17%" />
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridTemplateColumn DataField="UnitCost" DataType="System.Double" HeaderStyle-Width="7%"
                                        ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="7%"
                                        UniqueName="UnitCost">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrUnitCost" runat="server" Text="Unit Cost"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbUnitCost" runat="server" Text='<%# Eval("UnitCost") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="7%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Quantity" DataType="System.Double" DefaultInsertValue="0"
                                        HeaderStyle-Width="5%" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="5%" UniqueName="Quantity">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrQuantity" runat="server" Text="Qty."> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity","{0:0,0}") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="tbQuantity" runat="server" EnabledStyle-HorizontalAlign="Right"
                                                FocusedStyle-HorizontalAlign="Right" oncopy="return false" oncut="return false"
                                                onpaste="return false" Text='<%# Bind("Quantity","{0:0,0}") %>' Width="30px">
                                                <NumberFormat AllowRounding="true" DecimalDigits="0" />
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="5%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn Aggregate="Sum" DataField="Amount" DataType="System.Decimal"
                                        DefaultInsertValue="0.00" FooterAggregateFormatString="{0:0,0.00}" FooterStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="7%" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="7%" UniqueName="Amount">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrAmount" runat="server" Text="Amount"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount","{0:0,0.00}") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="tbAmount" runat="server" EnabledStyle-HorizontalAlign="Right"
                                                FocusedStyle-HorizontalAlign="Right" oncopy="return false" oncut="return false"
                                                onpaste="return false" Text='<%# Bind("Amount","{0:0,0.00}") %>' Width="50px">
                                                <NumberFormat AllowRounding="true" DecimalDigits="2" />
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#000066" HorizontalAlign="Right" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="7%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Edit" UniqueName="Edit" Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrEdit" runat="server" Text="Edit"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbEdit" runat="server" Text='<%# Eval("Edit") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogHeight="150px"
                                        ConfirmDialogType="RadWindow" ConfirmDialogWidth="275px " ConfirmText="&lt;br\&gt; Are you sure to delete this line? &lt;br\&gt; "
                                        ConfirmTitle="Delete" HeaderStyle-Width="3%" ItemStyle-BackColor="White" ItemStyle-Width="3%"
                                        Text="Delete" UniqueName="DeleteColumn">
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="3%" />
                                        <ItemStyle BackColor="White" Width="3%" />
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                            <HeaderContextMenu EnableAutoScroll="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <asp:HiddenField ID="hdnItemLookup" runat="server" />
                    </telerik:RadAjaxPanel>
                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                        Modal="true" ShowContentDuringLoad="false" VisibleStatusbar="false" Behavior="Default"
                        InitialBehavior="None" Skin="Office2007">
                        <Windows>
                            <telerik:RadWindow ID="Win_Lookup" runat="server" Width="600px" Height="450px" Behaviors="Default"
                                Modal="true" OnClientClose="GetLookupValue" NavigateUrl="Lookup.aspx">
                            </telerik:RadWindow>
                        </Windows>
                    </telerik:RadWindowManager>
                    <br />
                    <div>
                    </div>
                    <div id="test" style="border: 1px solid #ccc; background-color: #03828a;">
                        <p>
                            ROI and MRC
                        </p>
                    </div>
                    <table width="100%" cellpadding="2" style="border: thin solid #C9DAEE; padding: inherit;
                        margin: auto;">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblMRC" runat="server" CssClass="lbl" Text="MRC" Width="44px" />
                            </td>
                            <td class="style3">
                                <telerik:RadTextBox ID="txtMRC" runat="server" AutoPostBack="true" OnTextChanged="txtMRC_TextChanged">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style2">
                                <asp:Label ID="lblROI" runat="server" CssClass="lbl" Text="ROI" Width="36px" />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtROI" runat="server" AutoPostBack="true" OnTextChanged="txtROI_TextChanged">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table>
                <tr>
                    <td>
                    </td>
                    
                </tr>
            </table>
            
        </div>
        </div>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function ItemLookup(sender, args) {

                document.getElementById('<%= hdnItemLookup.ClientID  %>').Text = sender.get_id();
                var oWnd = radopen("Lookup.aspx?Lookup=Item&Year1=" + "05/01/2017", "Win_Lookup");
                oWnd.Show();

            }

            function keyPress(sender, args) {
                var separatorPos = sender._textBoxElement.value.indexOf(sender.get_numberFormat().DecimalSeparator);
                if (args.get_keyCharacter().match(/[0-9]/) && separatorPos != -1 && sender.get_caretPosition() > separatorPos + sender.get_numberFormat().DecimalDigits)
                { args.set_cancel(true); }
            }

            function RefreshMe() {
                window.location.reload();
            }


            function GetLookupValue(oWindow, oArg) {

                var ctrl;
                var oArg = oArg.get_argument();
                if (oArg) {
                    switch (oArg.LookupName) {

                        case "Requisition":


                            break;
                        case "Vendor":

                            break;
                        case "Site":

                            break;
                        case "Customer":

                            break;
                        case "Project":

                            break;
                        case "Circuit":

                            break;


                        case "Item":

                            ctrl = document.getElementById("<%= hdnItemLookup.ClientID  %>").Text;
                            ctrl = $find(ctrl);
                            break;
                    }
                    ctrl.set_value(oArg.ReturnValue);
                    //                    alert(ctrl.set_value(oArg.ReturnValue));
                }
            }

            function keyPressPocContact(sender, args) {
                var text = sender.get_value() + args.get_keyCharacter();
                if (!text.match('^[0-9]+$'))
                    args.set_cancel(true);
            }


            function EmailFormat(sender, args) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!re.test(sender.get_value()))
                    alert("Please enter a valid email address");
            }

            function NumberFormat(sender, args) {
                alert("umair test");
                var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
                if ((sender.get_value() == (phoneno))) {
                    return true;
                }
                else {
                    alert("message");
                    return false;
                }
            }

            function OnClientButtonClicked(sender, args) {


                var CircuitName = document.getElementById('<%=txtCircuitName.ClientID %>').value;
                var CustomerName = document.getElementById('<%=cmbCustomerName.ClientID %>').value;
                var Area = document.getElementById('<%=cmbArea.ClientID %>').value;

                if (CircuitName == "") {
                    alert("Circuit Name cannot be empty");
                    args.set_cancel(false);

                }

                if (CustomerName == 'Please Select') {

                    alert("Please Select customer name");
                    args.set_cancel(true);
                }

                if (Area == 'Please Select') {
                    alert("Please Select Area");
                    args.set_cancel(false);
                }



            }

        </script>
    </telerik:RadCodeBlock>


</asp:Content>
