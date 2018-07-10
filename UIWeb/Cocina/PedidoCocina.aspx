<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PedidoCocina.aspx.cs" Inherits="UIWeb.Cocina.PedidoCocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .myth {
            background-color: black;
            color: white;
            padding: 15px;
        }
        .mydiv {
            background-color: white;
            padding: 10px;
        }
        .cetrar {
            text-align: center;
        }
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
            <br />
            <br />

 
            <div class="col-md-offset-3 col-md-6 mydiv">
           

                <asp:Button ID="Button1" runat="server" Text="Revertir Entrega" class="btn btn-danger btn-block" OnClick="desentrega_Click"/>
                <br />
                <asp:Table ID="tablePedidosASP" runat="server" CssClass="table table-bordered text-center">
                    <asp:TableHeaderRow ID="headerRow" CssClass='myth'>
                        <asp:TableHeaderCell Text="Numero de pedido">
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Nombre de Cliente">
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Lista de pedidos " >
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Estado">
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                        </asp:TableHeaderCell>

                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
