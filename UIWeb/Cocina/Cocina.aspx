<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cocina.aspx.cs" Inherits="UIWeb.Cocina.Cocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-offset-3 col-md-6 p-3 mb-2 bg-info text-white">
        <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label ID="labelError" runat="server" Text="Error"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="User"></asp:Label><asp:TextBox ID="txtUser" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnLog" runat="server" Text="btnLog" />
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="btnRegister" />
    </div>



</asp:Content>
