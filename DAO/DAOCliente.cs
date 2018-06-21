using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAOCliente
    {
        ProyectoEntities entidades = new ProyectoEntities();

        public void cargarCliente(TO_Cliente toCliente) {
            var cliente = from cl in entidades.Cliente where cl.NombreUsuario == toCliente.NombreDeUsuario select cl;
            if (cliente.Count() > 0) 
            {
                toCliente.Habilitado = cliente.First().Habilitado;
                toCliente.Direccion = cliente.First().Direccion;
                toCliente.NombreCompleto = cliente.First().Nombre_Completo;
                toCliente.Correo = cliente.First().Correo;
            }
        }

        public void generarPedido(TO_Pedido toPedido) {
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
                //detallePedido.CodigoPlato = toDetallePedido.Plato;
                detallePedido.Cantidad = toDetallePedido.Cantidad;
                entidades.SaveChanges();
            }
        }
    }
}
