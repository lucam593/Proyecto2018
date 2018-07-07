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
                <table id="tablePedidos" class="table" style="background-color:aqua">
                    <tr>
                        <th>
                            Numero de pedido
                        </th>
                        <th>
                            Nombre de cliente
                        </th>
                        <th>
                            Lista de pedidos
                        </th>
                    </tr>
                        <%foreach (var item in listOfPedidos)
                            {
                                string numero = item.NumeroPedido.ToString();
                                string nombreCliente = item.Cliente.NombreDeUsuario;
                                List<BL.BL_DetallePedido> detalles = item.DetallePedido;
                                %>
                    <tr>
                        <td>
                            <label><%=numero %></label>
                        </td>
                        
                        <td>
                            <label><%= nombreCliente %></label>
                        </td>
                        <td>
                            <%foreach (var plato in detalles)
                                {%>
                            <label><%= plato.Plato.Descripcion%></label>

                                    
                                <%} %>
                        </td>
                    </tr>
                           <% } %>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
