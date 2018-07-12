﻿using System;
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

        public void modificarDireccionCliente(TO_Cliente toCliente)
        {
            Cliente cliente = (from cl in entidades.Clientes where cl.NombreUsuario == toCliente.NombreDeUsuario select cl).Single();
            cliente.Direccion = toCliente.Direccion;

            entidades.SaveChanges();
        }
    }
}
