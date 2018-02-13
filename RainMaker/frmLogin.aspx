<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="RainMaker.frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
            <title>BSS Login</title>
            
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">
            <link rel="stylesheet" href="Styles/Site.css" />
            <link rel="Stylesheet" href="Styles/css/sb-admin.css" />  
            <script type = "text/javascript" >
                function preventBack() { window.history.forward(); }
                setTimeout("preventBack()", 0);
                window.onunload = function () { null };
            </script>
            <style type="text/css">
                body{ background-color:#03828a;}
            </style>
</head>
<body>
    <form id="form1" runat="server">
                <div class="pen-title" style="text-align:center;color:White;">
  <h1>RAIN MAKER</h1><span>  </span>
</div>
<!-- Form Module-->
<div class="module form-module">
  <div class="toggle"><i class="fa fa-times fa-pencil">X</i>
    <div class="tooltip">Click Me</div>
  </div>
            <div class="form">
                <h2>Login to your account</h2>
                <form>
                <asp:TextBox ID="tbuser" runat="server" placeholder="User Name"></asp:TextBox>
                <asp:TextBox ID="tbpass"  runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnlogin" runat="server" Text="Login" onclick="btnlogin_Click" style="height: 40px" />
                <asp:Label ID="lblnotify" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </form>
            </div>
           <%-- <input type="text" placeholder="Username"/>
            <input type="password" placeholder="Password"/>
            <button>Login</button>--%>
            
            <div class="form">
            <h2>Create an account</h2>
              <form>
                <asp:TextBox ID="reguser" runat="server"></asp:TextBox>
                <asp:TextBox ID="regpass" runat="server"></asp:TextBox>
                <asp:TextBox ID="regemail" runat="server"></asp:TextBox>
                <asp:TextBox ID="regtel" runat="server"></asp:TextBox>
                <asp:Button ID="regbutton" runat="server" Text="Register" />
              </form>
            </div>
            <%--<input type="text" placeholder="Username"/>
            <input type="password" placeholder="Password"/>
            <input type="email" placeholder="Email Address"/>
            <input type="tel" placeholder="Phone Number"/>
            <button>Register</button>--%>
        
            <div class="cta"><a href="http://bss.apps.multi.net.pk">Forgot your password?</a></div>
            </div>
            <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
           
            <script src="Scripts/js/index.js"></script>
    </form>
</body>
</html>
