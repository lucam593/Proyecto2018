using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAO_Pedido
    {
        ProyectoEntidades entidades = new ProyectoEntidades();

        public void insertarPedido(TO_Pedido toPedido)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = toPedido.Cliente.NombreDeUsuario;
            pedido.Estado = "A Tiempo";
            pedido.Fecha = System.DateTime.Now;

            entidades.Pedidoes.Add(pedido);
            entidades.SaveChanges();
            //int nextIdentity = Convert.ToInt32(entidades.Database.SqlQuery<decimal>("Select IDENT_CURRENT ('Routing.RouteDescriptionTable')", new object[0]).FirstOrDefault());

            //var x = from c in entidades.Pedido select c;
            //x.Last().NumeroPedido;

            foreach (TO_DetallePedido toDetallePedido in toPedido.DetallePedido)
            {
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.NumeroPedido = pedido.NumeroPedido;
                detallePedido.Codigo_Plato = toDetallePedido.Plato.CodigoPlato;
                detallePedido.Cantidad = toDetallePedido.Cantidad;

                entidades.DetallePedidoes.Add(detallePedido);
                entidades.SaveChanges();
            }
        }

        public void caragarPedidosDeCliente(TO_ListaPedidos listaPedidos, TO_Cliente toCliente)
        {
            listaPedidos.listaPedidos = new List<TO_Pedido>();
            var pedidos = from aux in entidades.Pedidoes where aux.Cliente == toCliente.NombreDeUsuario select aux;
            if (pedidos.Count() > 0)
            {
                foreach (Pedido pedido in pedidos)
                {
                    TO_Pedido toPedido = new TO_Pedido();
                    toPedido.Cliente = toCliente;
                    toPedido.NumeroPedido = Convert.ToInt16(pedido.NumeroPedido);
                    toPedido.Estado.NombreEstado = pedido.Estado;
                    toPedido.Fecha = pedido.Fecha;
                    listaPedidos.listaPedidos.Add(toPedido);
                }
            }
        }

        public void cargarPedidosCocina(TO_ListaPedidos listaPedidos)
        {
            listaPedidos.listaPedidos = new List<TO_Pedido>();
            var pedidos = from aux in entidades.Pedidoes where aux.Estado != "Anulado" && aux.Estado != "Entregado" select aux;
            if (pedidos.Count() > 0)
            {
                foreach (Pedido pedido in pedidos)
                {
                    TO_Pedido toPedido = new TO_Pedido();
                    toPedido.Cliente.NombreDeUsuario = pedido.Cliente;
                    toPedido.NumeroPedido = Convert.ToInt16(pedido.NumeroPedido);
                    toPedido.Estado.NombreEstado = pedido.Estado;
                    toPedido.Fecha = pedido.Fecha;
                    listaPedidos.listaPedidos.Add(toPedido);
                }
            }
        }

        public void cargarPedido(TO_Pedido toPedido) {
            var detallesPedido = from aux in entidades.DetallePedidoes where aux.NumeroPedido == toPedido.NumeroPedido select aux;
            if (detallesPedido.Count() > 0)
            {
                toPedido.DetallePedido = new List<TO_DetallePedido>();

                foreach (DetallePedido detallePedido in detallesPedido)
                {
                    TO_DetallePedido toDetallePedido = new TO_DetallePedido();
                    toDetallePedido.NumeroPedido = Convert.ToInt16(detallePedido.NumeroPedido);
                    TO_Plato toPlato = new TO_Plato();
                    toPlato.CodigoPlato = Convert.ToInt16(detallePedido.Codigo_Plato);
                    toDetallePedido.Plato = toPlato;
                    toDetallePedido.Cantidad = Convert.ToInt16(detallePedido.Cantidad);
                    toPedido.DetallePedido.Add(toDetallePedido);
                }
            }
        }

        public void cambiarSiguienteEstado(TO_Pedido toPedido) {
            var pedido = from auxPedido in entidades.Pedidoes where auxPedido.NumeroPedido == toPedido.NumeroPedido select auxPedido;
            var siguienteEstado = from auxEstado in entidades.Estadoes where auxEstado.Indice == (toPedido.Estado.Indice + 1) select auxEstado;
            pedido.First().Estado = siguienteEstado.First().NombreEstado;

            toPedido.Estado.NombreEstado = siguienteEstado.First().NombreEstado;
            toPedido.Estado.LimiteMinutos = Convert.ToInt16(siguienteEstado.First().LimiteMinutos);
            toPedido.Estado.Indice = Convert.ToInt16(siguienteEstado.First().Indice);

            entidades.SaveChanges();
        }

        public void alterarEstadoPedido(Int16 numPedido, string estadoAnterior)
        {
            var pedido = (from aux in entidades.Pedidoes where aux.NumeroPedido == numPedido select aux).Single();

            pedido.Estado = estadoAnterior;

            entidades.SaveChanges();
        }
    }
}
