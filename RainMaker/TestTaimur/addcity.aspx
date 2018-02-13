<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcity.aspx.cs" Inherits="RainMaker.TestTaimur.addcity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 330px">
    <form id="form1" runat="server">
    <div>
    
        Region&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="122px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />   City Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
    
        <asp:Button ID="insertdata" runat="server" onclick="Button3_Click" 
            Text="insert" />
        <br />
        <asp:Button ID="updatedata" runat="server" Text="update" />
        <asp:Button ID="deletedata" runat="server" Text="delete" />
    
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
&nbsp;</form>
</body>
</html>
