<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="UIWeb.AdminModule.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administración Four Colors</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Login ID="LoginAdmin" runat="server" OnLoggedIn="LoginAdmin_LoggedIn">
            <LoginButtonStyle CssClass="btn btn-outline-success" />
        </asp:Login>
    </form>
    
</body>
</html>
