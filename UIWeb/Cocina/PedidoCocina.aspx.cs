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
        public List<BL_Pedido> listOfPedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            listOfPedidos = cargarDdl();
        }

        protected List<BL_Pedido> cargarDdl() {
            Manejador_Pedido manejadorPedido = new Manejador_Pedido();
            manejadorPedido.cargarPedidosCocina();
            return manejadorPedido.listaPedidos;
        }

        protected List<BL_Plato> cargarPlatos()
        {
            List<BL_Plato> listaPlatos = new List<BL_Plato>();
            ManejadorPlatos platos = new ManejadorPlatos();
            listaPlatos = platos.cargarPlatos();
            return listaPlatos;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            short codPed = short.Parse(btn.ID);
            BL_Pedido pedido = new BL_Pedido();
            pedido.entregarPedido(codPed);
        }
    }
}