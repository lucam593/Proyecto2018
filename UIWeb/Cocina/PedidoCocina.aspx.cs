using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.Cocina
{
    public partial class PedidoCocina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDdl();
        }

        protected void cargarDdl() {
            Manejador_Pedido manejadorPedido = new Manejador_Pedido();
            manejadorPedido.cargarPedidosCocina();
            ddlPrueba.DataSource = manejadorPedido.listaPedidos;
            ddlPrueba.DataTextField = "NumeroPedido";
            ddlPrueba.DataValueField = "NumeroPedido";
            ddlPrueba.DataBind();
        }
    }
}