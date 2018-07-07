<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PedidoCocina.aspx.cs" Inherits="UIWeb.Cocina.PedidoCocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 238px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%-- Aqui empieza el codigo para el ajax implementado con ASP.NET --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%-- Aqui va todo el contenido q va a hacer uso del ajax, osea lo q se quiere cargar sin postback --%>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <%-- Aqui termina el contenido --%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="col-md-offset-3 col-md-6">
        <table id="tablePedidos" class="table" style="background-color:azure">
            
    </table>
    </div>
    <asp:DropDownList ID="ddlPrueba" runat="server">
    </asp:DropDownList>
</asp:Content>
