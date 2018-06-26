using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    class DAO_Usuario
    {
        public void insertarUsuario(string userName, string password, string rol, ProyectoEntidades entidades)
        {
            Usuario user = new Usuario();
            user.NombreUsuario = userName;

            user.Rol = rol;
            user.Contrasena = password;
            entidades.Usuarios.Add(user);
        }

        public TO_Usuarios cargarUsuario(string userName, ProyectoEntidades entidades)
        {
            var user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();

            TO_Usuarios toUser = new TO_Usuarios();
            toUser.NombreDeUsuario = user.NombreUsuario;
            toUser.Contrasena = user.Contrasena;
            toUser.Rol = user.Rol;

            return toUser;

        }

        public void modificarUsuario(string userName, string nuevoUserName, string nuevoPassword, ProyectoEntidades entidades)
        {
            Usuario user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();
            user.NombreUsuario = userName;
            user.Contrasena = nuevoPassword;
        }
    }
}
