<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UIWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .div{
        text-align:center;
        background-color: white;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-3 col-md-6 div h-100">

        <asp:Button runat="server" Text="Administrador" CssClass="btn btn-primary" OnClick="Unnamed1_Click" />
        <br />
                <br />
        <asp:Button runat="server" Text="Cocina" CssClass="btn btn-primary" OnClick="Unnamed2_Click" />
                <br />
                <br />
        <asp:Button runat="server" Text="Cliente"  CssClass="btn btn-primary" OnClick="Unnamed3_Click"/>
    </div>
</asp:Content>
