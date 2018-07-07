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

        //Este es el codigo del boton q llama un plato de la base de datos y lo asigna al label de prueba
        protected void Button1_Click(object sender, EventArgs e)
        {
            BL_Plato blPlato = new BL_Plato();
            blPlato.cargarPlato(1);
            Label1.Text = blPlato.Descripcion;
        }
    }
}