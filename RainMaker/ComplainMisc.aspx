<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ComplainMisc.aspx.cs" Inherits="RainMaker.WebForm7" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 200px;
        }
        .style3
        {
            width: 155px;
        }
        .style4
        {
            width: 363px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    function OnKeyPress(sender, eventArgs) {
        var c = eventArgs.get_keyCode();
        if (c == 13) {
            __doPostBack('btnUpdate', '');
            alert("ok");

        }
    } 
   </script>


    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

    
    <asp:Panel ID="MainFSCpanel" runat="server" Visible="true">
    <div id="page-wrapper">
    <div class="container-fluid">
    <%--<asp:Button ID="btnViewHistoryFiberDetails" OnClick="btnviewFiberHistory_Click" runat="server" Text="View History" />--%>
        <table class="nav-justified">
            <tr>
                <td>
                    <telerik:RadButton ID="btnUpdate" runat="server" OnClick="btUpdateComplain_Click"
                        Text="Update">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btCancel" runat="server" Text="Cancel" OnClick="btncancel_Click">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Basic Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td width="200px">
                                Complain Ticket No.
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbComplainTicketNo" ReadOnly="true" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                Complain Status
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbComplainStatus" ReadOnly="true" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td style="font-weight: bold">
                                Engineer Name
                                <asp:Label ID="lblEngineerName" runat="server" Font-Bold="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="176px">
                                Complain Received D/T
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbComplaintReceivedDT" ReadOnly="true" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                </td>
                <td>
                    Complain Logged By
                </td>
                <td>
                    <telerik:RadTextBox ID="tbComplainLoggedBy" ReadOnly="true" runat="server" Width="175px">
                    </telerik:RadTextBox>
                </td>
                <td style="font-weight: bold">
                    Date / Time
                    <asp:Label ID="lblDateTime" runat="server" Font-Bold="false" Width="175px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="176px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        </td> </tr>
        <asp:Panel ID="pnlComplainClosure" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Closing Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td class="style1">
                                Customer FeedBack
                            </td>
                            <td class="style4">
                                <asp:RadioButtonList ID="rbCustomerFeedback" runat="server" OnSelectedIndexChanged="rbCustomerFeedback_SelectedIndexChanged"  AutoPostBack="true" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Positive</asp:ListItem>
                                    <asp:ListItem>Negative</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                                <%--<asp:HyperLink ID="HyperLink2" runat="server">View Complete Complain Details</asp:HyperLink>--%>
                                <asp:Button ID="btClosureComplain" OnClick="btnviewDetails_Click" runat="server" Text="View Details" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Further Action
                            </td>
                            <td class="style4">
                                <asp:RadioButtonList ID="rbFurtherAction" OnSelectedIndexChanged="rbFurtherAction_SelectedIndexChanged" AutoPostBack="true"   runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Re-Initiated</asp:ListItem>
                                    <asp:ListItem Enabled="false">New Complaint Logged</asp:ListItem>
                                    <asp:ListItem Selected="True">N/A</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Complaint Status
                            </td>
                            <td class="style4">
                                <telerik:RadComboBox ID="cmbComplaintStatus" runat="server" Width="175px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Assigned to Department
                            </td>
                            <td class="style4">
                                <telerik:RadComboBox ID="cmbAssignedtoDepartment" runat="server" Width="175px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                New Complaint Reference
                            </td>
                            <td class="style4">
                                <telerik:RadTextBox ID="tbNewComplaintReference" runat="server" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Remarks
                            </td>
                            <td class="style4">
                                <telerik:RadTextBox ID="tbRemarks" runat="server" TextMode="MultiLine" Width="300px" Height="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlComplainInProcessForm" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Follow up Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td width="200px">
                                Complain Status
                            </td>
                            <td class="style2" width="200px">
                                <telerik:RadComboBox ID="cmbCaseCategory0" runat="server" Width="175px" OnSelectedIndexChanged="cmbCaseCategory0_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3" width="200px">
                                ETTR
                            </td>
                            <td width="200px">
                                <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server" Width="175px" MinDate="1900-01-01">
                                </telerik:RadDateTimePicker>
                            </td>
                            <td width="200px">
                                <asp:Button ID="btnviewDetails" OnClick="btnviewDetails_Click" runat="server" Text="View Details" />
                                <%--<asp:HyperLink ID="HyperLink1" href="ComplainForm.aspx"  onclick="btnviewDetails_Click" runat="server">View Details</asp:HyperLink>                                --%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Assigned Department
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="cmbCaseCategory1" runat="server" Width="175px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                                ETA
                            </td>
                            <td>
                                <telerik:RadDateTimePicker ID="RadDateTimePicker3" MinDate="1900-01-01" runat="server">
                                </telerik:RadDateTimePicker>
                            </td>
                            <td>
                                Person Name ETA/ETTR
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbLoggedBy0" runat="server" Width="175px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                            </td>                           
                        </tr>
                        
                        <tr>
                            <td>
                                Picture One Selecter
                            </td>
                            <td>
                                <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server">
                                </telerik:RadAsyncUpload>
                            </td>
                            
                            <td>
                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" />
                                <%--<asp:LinkButton ID="ShowPic" OnClick="ShowPic_Click" runat="server">ViewPic1</asp:LinkButton>--%>
                                 <asp:LinkButton ID="ShowPic1" OnClick="ShowPic_Click" runat="server">ViewPic-1</asp:LinkButton>
                                 <asp:LinkButton ID="ShowPic2" OnClick="ShowPic2_Click" runat="server">ViewPic-2</asp:LinkButton>

                            </td>
                        </tr>
                                                
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td class="style5">
                                Remarks
                            </td>
                            <td class="style6">
                                <telerik:RadTextBox ID="tbLoggedBy3" runat="server" Width=" 300px" Height="200px" TextMode="MultiLine">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style5">
                                Query Responses
                            </td>
                            <td class="style6">
                                <telerik:RadTextBox ID="tbIPResponses" runat="server" Width="300px" Height="200px" TextMode="MultiLine">
                                </telerik:RadTextBox>
                            </td>
                            <td class="" width="">
                                <asp:Label ID="lblRequest" runat="server" Text="Request Type"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioRequestTypeNE" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Support Request</asp:ListItem>
                                    <asp:ListItem>Service Request</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                         
                    </table>
                </td>
            </tr>
        </asp:Panel>

        <%--<asp:Panel ID="pnlEscalation" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Team Escalation
                </td>
            </tr>

            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td width="200px">
                                Team 
                            </td>
                            <td class="style2" width="200px">
                                <telerik:RadComboBox ID="cmbTeam" runat="server" Width="175px" >
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3" width="200px">
                                Priority
                            </td>
                            <td class="style2" width="200px">
                                <telerik:RadComboBox ID="cmbPriority" runat="server" Width="175px" >
                                </telerik:RadComboBox>
                            </td>
                            <td width="200px">
                                <asp:Button ID="btnSaveEscalationForm" runat="server" Text="Save" />                                
                            </td>
                        </tr>
                                        
                    </table>
                </td>
            </tr>
         </asp:Panel>--%>

         <asp:Panel ID="pnlEscalation" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Team Escalation
                </td>
            </tr>

            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td width="200px">
                                Team 
                            </td>
                            <td class="style2" width="200px">
                                <telerik:RadComboBox ID="cmbTeam" OnSelectedIndexChanged="cmbTeam_SelectedIndexChanged"  runat="server" Width="175px" >
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3" width="200px">
                                Priority
                            </td>
                            <td class="style2" width="200px">
                                <telerik:RadComboBox ID="cmbPriority" OnSelectedIndexChanged="cmbPriority_SelectedIndexChanged"  runat="server" Width="175px" >
                                </telerik:RadComboBox>
                            </td>
                            <td width="200px">
                                <asp:Button ID="btnSaveEscalationForm"   runat="server" Text="Save" />                                
                            </td>
                        </tr>
                                        
                    </table>
                </td>
            </tr>
         </asp:Panel>

        <asp:Panel ID="pnlComplainSolving" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Solving Information
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td class="style3">
                                Complain Status
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="cmbComplainStatus" runat="server" Width="175px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                                Assigned Department
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="cmbAssignedDepartment" runat="server" Width="175px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                                Person Solving Complain
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbPersonSolvingComplain" runat="server" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Solving Date TIme
                            </td>
                            <td class="style2">
                                <telerik:RadDateTimePicker ID="dtSolving" runat="server" Width="175px">
                                </telerik:RadDateTimePicker>
                            </td>
                            <td class="style3">
                                FCR
                            </td>
                            <td class="style2">
                                <asp:RadioButtonList ID="rbFCR" runat="server" RepeatDirection="Horizontal" Width="175px">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="style3">
                                Last Mile Infra
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="cmbLastMileInfra" runat="server" Width="200px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                        <td class="style3">
                                Problem Diagnosed at
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbProblemDiagnosedat" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="cmbProblemDiagnosedat_SelectedIndexChanged" Width="200px">
                                </telerik:RadComboBox>
                            </td>
                           
                            <td class="style3">
                                Reason of Outage
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="cmbReasonofOutage" runat="server" Width="200px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">
                                Remarks
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbRemarksSolving" runat="server" TextMode="MultiLine" Width="300px" Height="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:Label ID="lblCauses" runat="server" Text="Causes"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbCauses" runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblRootCauseAnalysis" runat="server" Text="Root Cause Analysis"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbRootCauseAnalysis" runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblPreventiveMeasures" runat="server" Text="Preventive Measures"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="tbPreventiveMeasures" runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td class="style3">
                                &nbsp;
                            </td>
                            <td style="float: right">
                                <%--<asp:HyperLink ID="HyperLink3" href="ComplainForm.aspx" runat="server">View Details</asp:HyperLink>--%>
                                <asp:Button ID="btnSolvingDetails" OnClick="btnviewDetails_Click" runat="server" Text="View Details" />

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>




          <asp:Panel ID="pnlFiberDetails" runat="server" Visible="false">
            <tr>
                <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                    Fiber Details
                </td>
            </tr>
            <tr>
                <td>
                    <table class="nav-justified">
                        <tr>
                        <td >
                                Join Name
                            </td>
                            <td >
                                <telerik:RadTextBox ID="txtJoinName" runat="server" >
                                </telerik:RadTextBox>
                            </td>

                             <td class="style3">
                                Tube Name From Customer 
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtTubeNameFromCustomer" runat="server" >
                                </telerik:RadTextBox>
                            </td>

                             <td class="style3">
                                Core Color From Customer
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtCoreColorFromCustomer" runat="server" >
                                </telerik:RadTextBox>
                            </td>
                        </tr>


                        <tr>
                        <td class="style3">
                                Tube Name From Node
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtTubeNameFromNode" runat="server" >
                                </telerik:RadTextBox>
                            </td>

                             <td class="style3">
                                Core Color From Node
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtCoreColorFromNode" runat="server" >
                                </telerik:RadTextBox>
                            </td>

                             <td class="style3">
                                Cut Distance
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtCutDistance" runat="server" >
                                </telerik:RadTextBox>
                            </td>
                        </tr>

                        <tr>                        
                        <td>
                        
                        <asp:Button ID="btnViewHistoryFiberDetails" OnClick="btnviewFiberHistory_Click" runat="server" Text="View History" />
                        
                        </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </asp:Panel>








        <tr>
            <td bgcolor="#03828A" style="font-family: Calibri; font-weight: bold; color: #FFFFFF">
                List of Customer Effected
            </td>
        </tr>
        <tr>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td>
                            Total Count:
                            <asp:Label ID="lblTotalCount" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="float: right">
                            <asp:CheckBox ID="cbCheckAll" runat="server" Text="Check All" />
                        </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label>
        
        
        
        
                    
                    </td>
                    </tr>

                    <tr>
                    <td>
        <asp:Label ID="lblSucessCount" runat="server" Text="Label"></asp:Label>            
                    </td>
                    
                    </tr>
                    <tr>
        <td><asp:Label ID="lblFailedCount" runat="server" Text="Label"></asp:Label>            
            </td>        
                    </tr>

                </table>
            </td>
        </tr>
        </table>
        <telerik:RadGrid ID="gvActiveCircuits" runat="server" AllowPaging="True" AllowSorting="True"
            OnItemCommand="gvActiveCircuits_ItemCommand" OnNeedDataSource="gvActiveCircuits_NeedDataSource"
            GridLines="None" Skin="Office2007">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_Select" runat="server" ClientIDMode="AutoID"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn CommandName="Select" Text="Select" UniqueName="column">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="Complain" HeaderText="Complain" Text="Complain"
                        UniqueName="column1">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="ComplainHistory" HeaderText="ComplainHistory"
                        Text="ComplainHistory" UniqueName="column2">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="StatusHistory" HeaderText="StatusHistory"
                        Text="StatusHistory" UniqueName="column3">
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
            <PagerStyle Mode="NextPrev" />
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableImageSprites="True">
            </HeaderContextMenu>
        </telerik:RadGrid>
        
    </div>
    </div>
    </asp:Panel>
    <div class="container">
        <asp:Panel ID="ViewHistory" runat="server" Visible="false">
            <h3 class="center-block" style="text-align: center;">
                View History</h3>
            <table >
                <style scope="scoped">
                    tr
                    {
                        border: 1px solid black;
                    }
                    td
                    {
                        border-left: 1px solid black;
                    }
                </style>
                <tr>
                    <td>
                        <label>
                        Customer Name:</label>
                    </td>
                    <td>
                        <label ID="lbl_CusName" runat="server">
                        Customer Name:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Ticket Number:</label>
                    </td>
                    <td>
                        <label ID="lbl_TicNum" runat="server">
                        Ticket Number:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Complain Recieved Time:</label>
                    </td>
                    <td>
                        <label ID="lbl_ComRec" runat="server">
                        Complain Recieved Time:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Last Updated Time:</label>
                    </td>
                    <td>
                        <label ID="lbl_LUT" runat="server">
                        Last Updated Time:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Complain Status:</label>
                    </td>
                    <td>
                        <label ID="lbl_CS" runat="server">
                        Complain Status:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Assigned Department:</label>
                    </td>
                    <td>
                        <label ID="lbl_AD" runat="server">
                        Assigned Department:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Caller Name/Number:</label>
                    </td>
                    <td>
                        <label ID="lbl_CN" runat="server">
                        Caller Name/Number:</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                        Last Remarks:</label>
                    </td>
                    <td>
                        <label ID="lbl_LR" runat="server">
                        Last Remarks:</label>
                    </td>
                </tr>
                </tr>
            </table>
            <br />
            <br />
            <div class="table-responsive">
                <telerik:RadGrid ID="RadGrid2" Skin="Office2007"  runat="server">
                </telerik:RadGrid>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
