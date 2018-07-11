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

        private string setColor(string estado)
        {
            if (estado.Equals("A Tiempo"))
            {
                return "#B3FF9A";
            }
            else

            if (estado.Equals("Sobre Tiempo"))
            {
                return "#FEFF99";
            }
            else

            if (estado.Equals("Demorado"))
            {
                return "#FFAD98";
            }
            return "";
        }

        private void crearBoton(Button boton)
        {
            boton.Text = "Entregar";
            boton.Style.Add("background-color", "#4CAF50");
            boton.Style.Add("color", "#ffffff");
            boton.Attributes.Add("class", "btn btn-md");
            boton.Click += new System.EventHandler(eventoButton);
        }

        private void createHeaderRow()
        {
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Style.Add("background-color", "black");
            headerRow.Style.Add("color", "white");
            headerRow.Style.Add("padding", "15px");

            TableHeaderCell numeroPedido = new TableHeaderCell();
            numeroPedido.Text = "Numero de Pedido";
            headerRow.Cells.Add(numeroPedido);

            TableHeaderCell nombreCliente = new TableHeaderCell();
            nombreCliente.Text = "Nombre de cliente";
            headerRow.Cells.Add(nombreCliente);

            TableHeaderCell detallePedido = new TableHeaderCell();
            detallePedido.Text = "Detalle de pedido";
            headerRow.Cells.Add(detallePedido);

            TableHeaderCell estado = new TableHeaderCell();
            estado.Text = "Estado";
            headerRow.Cells.Add(estado);

            TableHeaderCell boton = new TableHeaderCell();
            headerRow.Cells.Add(boton);

            tablePedidosASP.Rows.Add(headerRow);
        }
        private void addRow(string numero, string nombreCliente, List<BL.BL_DetallePedido> detalles, string estado, string color)
        {



            TableRow row = new TableRow ();
            row.Style.Add("background-color", color);
            row.Style.Add("font-weight", "bold");
            TableCell cellNumero = new TableCell();
            cellNumero.Text = numero.ToString();
            row.Cells.Add(cellNumero);
            TableCell cellNombre = new TableCell();
            cellNombre.Text = nombreCliente;
            row.Cells.Add(cellNombre);
            TableCell cellPlatos = new TableCell();
            foreach (var plato in detalles)
            {

                cellPlatos.Text += plato.Plato.Descripcion + "<br/>";
            }
            row.Cells.Add(cellPlatos);
            TableCell cellEstado = new TableCell();
            cellEstado.Text = estado.ToString();
            row.Cells.Add(cellEstado);

            TableCell cellButton = new TableCell();
            Button boton = new Button();
            boton.ID = numero;
            crearBoton(boton);
            cellButton.Controls.Add(boton);
            row.Cells.Add(cellButton);

            tablePedidosASP.Rows.Add(row);
        }

        private void cargarTabla()
        {
            createHeaderRow();
            if (listOfPedidos.Count < 10)
            {
                for (int i = 0; i < listOfPedidos.Count; i++)
                {
                    BL_Pedido item = listOfPedidos.ElementAt<BL_Pedido>(i);
                    string numero = item.NumeroPedido.ToString();
                    string nombreCliente = item.Cliente.NombreDeUsuario;
                    string estado = item.Estado.NombreEstado.Trim();
                    List<BL.BL_DetallePedido> detalles = item.DetallePedido;
                    string color = setColor(estado);
                    addRow(numero, nombreCliente, detalles, estado, color);
                }
            }
            else if(listOfPedidos.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    BL_Pedido item = listOfPedidos.ElementAt<BL_Pedido>(i);
                    string numero = item.NumeroPedido.ToString();
                    string nombreCliente = item.Cliente.NombreDeUsuario;
                    string estado = item.Estado.NombreEstado.Trim();
                    List<BL.BL_DetallePedido> detalles = item.DetallePedido;
                    string color = setColor(estado);
                    addRow(numero, nombreCliente, detalles, estado, color);
                }
                
            }
            if (listOfPedidos.Count > 10)
            {
                morePedidos.Text = "↧ Existen más pedidos ↧";
            }
            else
            {
                morePedidos.Text = "" ;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UName"] == null)
            {
                Session["ErrorLogin"] = "Usuario no valido";
                Response.Redirect("Cocina.aspx");
            }
            listOfPedidos = cargarDdl();
            actualizarEstadosLista();
            cargarTabla();
            Timer1.Interval = 300000;
            Timer1.Enabled = true;
        }
        private BL_Pedido getOrdenFromLista(short id)
        {
            foreach (var item in listOfPedidos)
            {
                if (item.NumeroPedido == id)
                {
                    return item;
                }
            }
            return null;
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

        protected void eventoButton(object sender, EventArgs e)
        {
            Button boton = ((Button)sender);
            short idOrden = short.Parse(boton.ID);
            BL_Pedido blPedido = new BL_Pedido();
            blPedido.NumeroPedido = idOrden;
            BL_Pedido temp = getOrdenFromLista(idOrden);
            if (temp != null)
            {
                listOfPedidos.Remove(temp);
            }
            tablePedidosASP.Rows.Clear();
            cargarTabla();
            Session["LastStatus"] = blPedido.getEstado();
            Session["LastOrder"] = blPedido.NumeroPedido;
            blPedido.entregarPedido(idOrden);

        }
        private void actualizarEstadosLista()
        {
            Manejador_Pedido manejadorPedido = new Manejador_Pedido();
            manejadorPedido.listaPedidos = this.listOfPedidos;
            manejadorPedido.actualizarEstados();

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            actualizarEstadosLista();
        }

        protected void desentrega_Click(object sender, EventArgs e)
        {
            if (Session["LastOrder"] != null)
            {
                BL_Pedido blPedido = new BL_Pedido();
                blPedido.revertirEntrega((short)Session["LastOrder"], (string)Session["LastStatus"]);
            }
        }
    }
}