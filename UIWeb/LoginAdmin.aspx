<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="UIWeb.LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="logAdmin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" FailureText="Error al iniciar sesión. Intentalo nuevamente." Font-Names="Verdana" Font-Size="10pt" LoginButtonText="Entrar" PasswordLabelText="Contraseña:" RememberMeText="Recuerdarme la proxima vez." TextLayout="TextOnTop" TitleText="Inicio de Sesión" UserNameLabelText="Nombre de Usuario:">
    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
</asp:Login>
</asp:Content>
