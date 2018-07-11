﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAO_Usuario
    {
        public void insertarUsuario(string userName, string password, string rol, ProyectoEntidades entidades)
        {
            Usuario user = new Usuario();

            user.NombreUsuario = userName;
            user.Rol = rol;
            user.Contrasena = password;

            entidades.Usuarios.Add(user);
        }

        public void insertarUsuario(string userName, string password, string rol)
        {

            ProyectoEntidades entidades = new ProyectoEntidades();
            Usuario user = new Usuario();

            user.NombreUsuario = userName;
            user.Rol = rol;
            user.Contrasena = password;

            entidades.Usuarios.Add(user);
            entidades.SaveChanges();
        }

        public TO_Usuarios cargarUsuario(string userName, string password, ProyectoEntidades entidades)
        {
            var user = (from usr in entidades.Usuarios where usr.NombreUsuario.Trim() == userName && usr.Contrasena.Trim() == password select usr).Single();

            TO_Usuarios toUser = new TO_Usuarios();
            toUser.NombreDeUsuario = user.NombreUsuario;
            toUser.Contrasena = user.Contrasena;
            toUser.Rol = user.Rol;

            return toUser;

        }

        public TO_Usuarios cargarUsuario(string userName)
        {
            ProyectoEntidades entidades = new ProyectoEntidades();
            var user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();

            TO_Usuarios toUser = new TO_Usuarios();
            toUser.NombreDeUsuario = user.NombreUsuario.Trim();
            toUser.Contrasena = user.Contrasena.Trim();
            toUser.Rol = user.Rol.Trim();

            return toUser;
        }

        public void modificarUsuario(string userName, string nuevoUserName, string nuevoPassword, ProyectoEntidades entidades)
        {
            Usuario user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();
            user.NombreUsuario = nuevoUserName;
            user.Contrasena = nuevoPassword;
        }
    }
}
