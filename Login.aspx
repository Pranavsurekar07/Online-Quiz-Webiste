<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestDemo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-grid.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page-title">
                <div style="margin-left: auto; margin-right: auto; text-align: center;">
                    <h2>Login Page</h2>
                    <br />
                </div>
            </div>
            <div style="text-align: center">
                <label>Enter Email :</label>
                <asp:TextBox ID="txtEmail" runat="server" Height="18px" Width="176px"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ValidationGroup="reqSubValid" ErrorMessage="Please Enter Email Address" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div class="form-group" style="text-align: center">
                <asp:Button ID="btnLogin" runat="server" class="btn btn-primary" Text="Login" ValidationGroup="reqSubValid" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
