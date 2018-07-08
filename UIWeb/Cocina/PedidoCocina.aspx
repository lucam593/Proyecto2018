﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PedidoCocina.aspx.cs" Inherits="UIWeb.Cocina.PedidoCocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 238px;
        }
        .trgreen {
            background-color: #b3ff99;
        }
        .tryellow {
            background-color: #ffff99;
        }
        .trred {
            background-color: #ffad99;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%-- Aqui empieza el codigo para el ajax implementado con ASP.NET --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container text-center">
                <div class="col-md-offset-3 col-md-6">
                    <br />
                    <asp:Button ID="up" runat="server" Text="&uarr;" class="btn btn-primary btn-md" style="width:25%" OnClick="up_Click"/><asp:Button ID="down" runat="server" Text="&darr;" class="btn btn-primary btn-md" style="width:25%" />
                    <br />
                     <br />
                    <asp:Button ID="entrega" runat="server" Text="Entregar" class="btn btn-success" style="width:25%"/><asp:Button ID="desentrega" runat="server" Text="Revertir Entrega" class="btn btn-danger" style="width:25%"/>
                </div>
            </div>
            <br />
            <br />

            <div class="col-md-offset-3 col-md-6">
                <table id="tablePedidos" class="table">
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

                        <th>
                            Estado
                        </th>
                    </tr>
                        <%foreach (var item in listOfPedidos)
                            {
                                string numero = item.NumeroPedido.ToString();
                                string nombreCliente = item.Cliente.NombreDeUsuario;
                                string estado = item.Estado.NombreEstado.Trim();
                                List<BL.BL_DetallePedido> detalles = item.DetallePedido;
                                string color = "";

                                if (estado.Equals("A Tiempo"))
                                {
                                    color = "trgreen";
                                }else

                                if (estado.Equals("Sobre Tiempo"))
                                {
                                    color = "tryellow";
                                }else

                                if (estado.Equals("Demorado"))
                                {
                                    color = "trred";
                                }
                                %>
                    <tr id="<%=numero %>" class="<%=color %>"">
                        <td>
                            <label><%=numero %></label>
                        </td>
                        
                        <td>
                            <label><%= nombreCliente %></label>
                        </td>
                        
                        <td>
                            <%foreach (var plato in detalles)
                                {%>
                            <label><%= plato.Plato.Descripcion%></label><br />

                                    
                                <%} %>
                        </td>
                                                            
                        <td>
                            <label><%= estado %></label>
                        </td>        
                            
                    </tr>
                           <% } %>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
