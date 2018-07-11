﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cocina.aspx.cs" Inherits="UIWeb.Cocina.Cocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .div{
        text-align:center;
        background-color: white; 
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-offset-3 col-md-6 p-3 mb-2 bg-info div">
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>
        <br />
        <asp:Table ID="Table1" runat="server"  CssClass="table table-bordered text-center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnLog" runat="server" Text="btnLog" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="btnRegister" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar un Username" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="labelError" runat="server" Text="Error"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
    </div>



</asp:Content>
