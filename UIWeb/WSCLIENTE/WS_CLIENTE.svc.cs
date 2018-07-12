using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;

namespace UIWeb.WSCLIENTE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WS_CLIENTE" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WS_CLIENTE.svc or WS_CLIENTE.svc.cs at the Solution Explorer and start debugging.
    public class WS_CLIENTE : IWS_CLIENTE
    {
        public BL_Cliente cargarCliente(string nombreUsuario, string password)
        {
            BL_Cliente blCliente = new BL_Cliente();
            blCliente.cargarCliente(nombreUsuario, password);
            return blCliente;
        }

        public List<BL_Plato> listaPlatos()
        {
            ManejadorPlatos mplatos = new ManejadorPlatos();
            return mplatos.cargarPlatos();
        }

        public bool modificarDireccionCliente(string nombreUsuario, string newNombre, string newDireccion, string newContrasenha)

        {
            BL_Cliente blCliente = new BL_Cliente();
            blCliente.NombreDeUsuario = nombreUsuario;
            blCliente.modificarDireccionCliente(newNombre, newDireccion, newContrasenha);
            return true;
        }

        public List<BL_Plato> platoxCod(int cod)
        {
            BL_Plato plato = new BL_Plato();
            plato.cargarPlato((short)cod);
            List<BL_Plato> platillos = new List<BL_Plato>();
            platillos.Add(plato);
            return platillos;
        }

        public List<bool> registrarCliente(string nombreUsuario, string contrasenha, string rol, string direccion, string nombreCompleto, string correo, Boolean habilitado)
        {
            BL_Cliente blCliente = new BL_Cliente();
            blCliente.insertarCliente(nombreUsuario, contrasenha, rol, direccion, nombreCompleto, correo, habilitado);
            List<bool> lista = new List<bool>();
            lista.Add(true);
            return lista;
        }
    }
}
