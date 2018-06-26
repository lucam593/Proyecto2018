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

        public void generarPedido(TO_Pedido toPedido)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = toPedido.Cliente.NombreDeUsuario;
            pedido.Estado = "A_Tiempo";
            pedido.Fecha = System.DateTime.Now;
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
                    toPedido.NumeroPedido = Convert.ToInt16(pedido.NumeroPedido);
                    toPedido.Estado.NombreEstado = pedido.Estado;
                    toPedido.Fecha = pedido.Fecha;
                }
            }
        }
    }
}
