using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAOCliente
    {
        ProyectoEntidades entidades = new ProyectoEntidades();

        public void cargarCliente(TO_Cliente toCliente) {
            var cliente = from cl in entidades.Clientes where cl.NombreUsuario == toCliente.NombreDeUsuario select cl;
            if (cliente.Count() > 0) 
            {
                toCliente.Habilitado = cliente.First().Habilitado;
                toCliente.Direccion = cliente.First().Direccion;
                toCliente.NombreCompleto = cliente.First().Nombre_Completo;
                toCliente.Correo = cliente.First().Correo;
            }
        }
    }
}
