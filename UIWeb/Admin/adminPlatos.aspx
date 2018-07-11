<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" CodeBehind="adminPlatos.aspx.cs" Inherits="UIWeb.Admin.adminPlatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <asp:GridView ID="gvPlatos" runat="server"></asp:GridView>

    </div>
</asp:Content>
