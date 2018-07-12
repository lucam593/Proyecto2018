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
            DAO_Usuario daoUsuario = new DAO_Usuario();
            TO_Usuarios usuario = new TO_Usuarios();
            usuario = daoUsuario.cargarUsuario(toCliente.NombreDeUsuario, toCliente.Contrasena, entidades);

            toCliente.NombreDeUsuario = usuario.NombreDeUsuario;
            toCliente.Contrasena = usuario.Contrasena;
            toCliente.Rol = usuario.Rol;

            Cliente cliente = (from cl in entidades.Clientes where cl.NombreUsuario == toCliente.NombreDeUsuario select cl).Single();
                toCliente.Habilitado = cliente.Habilitado;
                toCliente.Direccion = cliente.Direccion;
                toCliente.NombreCompleto = cliente.Nombre_Completo;
                toCliente.Correo = cliente.Correo;
        }

        public void insertarCliente(TO_Cliente toCliente)
        {
            try
            {
                DAO_Usuario user = new DAO_Usuario();
                user.insertarUsuario(toCliente.NombreDeUsuario, toCliente.Contrasena, "Cliente", entidades);

                Cliente cliente = new Cliente();
                cliente.NombreUsuario = toCliente.NombreDeUsuario;

                cliente.Correo = toCliente.Correo;
                cliente.Direccion = toCliente.Direccion;
                cliente.Habilitado = toCliente.Habilitado;
                cliente.Nombre_Completo = toCliente.NombreCompleto;

                entidades.Clientes.Add(cliente);
                entidades.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }


  
   public List<TO_Cliente> cargarClientes()
        {
            var ent = new ProyectoEntidades();
            var consulta = from c in ent.Clientes select c;
            var list = consulta.ToList();

            List<TO_Cliente> toclientes = new List<TO_Cliente>();

            foreach (var item in list)
            {
                
                    TO_Cliente cliente = new TO_Cliente();
                cliente.NombreDeUsuario = item.NombreUsuario;
                cliente.NombreCompleto = item.Nombre_Completo;
                cliente.Correo = item.Correo;
                cliente.Direccion = item.Direccion;
                cliente.Habilitado = item.Habilitado;
                    toclientes.Add(cliente);
                
            }
            return toclientes;
        }

        public void modificarEstado(string nombre, bool ck)
        {
            ProyectoEntidades entidades = new ProyectoEntidades();
            Cliente cliente = (from cli in entidades.Clientes where cli.NombreUsuario == nombre select cli).Single();
            cliente.Habilitado = ck;
            entidades.SaveChanges();
        }

        public void modificarCliente(TO_Cliente toCliente, string nuevoNombreUsuario, string nuevoPassword)
        {
            Cliente cliente = (from cl in entidades.Clientes where cl.NombreUsuario == toCliente.NombreDeUsuario select cl).Single();
            cliente.Nombre_Completo = toCliente.NombreCompleto;
            cliente.Direccion = toCliente.Direccion;

            DAO_Usuario daoUsuario = new DAO_Usuario();
            daoUsuario.modificarUsuario(toCliente.NombreDeUsuario, toCliente.Contrasena, entidades);

            entidades.SaveChanges();
        }
    }
}
