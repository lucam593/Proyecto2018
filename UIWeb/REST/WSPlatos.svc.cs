using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;

namespace UIWeb.REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSPlatos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSPlatos.svc or WSPlatos.svc.cs at the Solution Explorer and start debugging.
    public class WSPlatos : IWSPlatos
    {
      
        public List<BL_Plato> listaPlatos()
        {
            ManejadorPlatos mplatos = new ManejadorPlatos();
            return mplatos.cargarPlatos();
        }

        public BL_Plato platoxCod(int cod)
        {
            BL_Plato plato = new BL_Plato();
             plato.cargarPlato((short) cod);
            return plato;
        }

        public void registrarPedido(string nombreCliente, List<string> listaPlatos, string cantidad)
        {
            BL_Pedido blPedido = new BL_Pedido();

            foreach (var item in listaPlatos)
            {
                BL_DetallePedido tempDetPedido = new BL_DetallePedido();
                BL_Plato tempPlato = new BL_Plato();
                tempPlato.cargarPlato(short.Parse(item));
                tempDetPedido.Cantidad = short.Parse(cantidad);
                tempDetPedido.Plato = tempPlato;
                blPedido.DetallePedido.Add(tempDetPedido);
            }

            blPedido.Cliente.NombreDeUsuario = nombreCliente;

            blPedido.ingresarPedido();

        }



    }
}
