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
            <div class="col-md-offset-3 col-md-6">
                <table id="tablePedidos" class="table" style="background-color:red">
                    <tr>
                        <th>
                            Codigo
                        </th>
                        <th>
                            Nombre
                        </th>
                    </tr>
                        <%foreach (var item in listOfPlatos)
                            {
                                string codi = item.Codigo.ToString();
                                string nomb = item.Nombre;
                                %>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="<%=codi %>"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="<%= nomb %>"></asp:Label>
                        </td>
                    </tr>
                           <% } %>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:DropDownList ID="ddlPrueba" runat="server">
    </asp:DropDownList>
</asp:Content>
