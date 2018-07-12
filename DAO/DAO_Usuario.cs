using System;
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

        public TO_Usuarios cargarUsuario(string userName, ProyectoEntidades entidades)
        {
            var user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();

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

        public void modificarUsuarioAd(string usuario, string cont, string rol)
        {
            ProyectoEntidades entidades = new ProyectoEntidades();
            Usuario user = (from usr in entidades.Usuarios where usr.NombreUsuario == usuario select usr).Single();
            user.Rol = rol;
            user.Contrasena = cont;
            entidades.SaveChanges();
        }

        public void eliminarUsuario(string usuario)
        {
            ProyectoEntidades entidades = new ProyectoEntidades();
            Usuario user = (from usr in entidades.Usuarios where usr.NombreUsuario == usuario select usr).Single();

            entidades.Usuarios.Remove(user);
            entidades.SaveChanges();
        }

        public void modificarUsuario(string userName, string nuevoUserName, string nuevoPassword, ProyectoEntidades entidades)
        {
            Usuario user = (from usr in entidades.Usuarios where usr.NombreUsuario == userName select usr).Single();
            user.NombreUsuario = nuevoUserName;
            user.Contrasena = nuevoPassword;
        }

        public List<TO_Usuarios> cargarUsuarios()
        {
            var ent = new ProyectoEntidades();
            var consulta = from c in ent.Usuarios select c;
            var list = consulta.ToList();

            List<TO_Usuarios> toUsuarios = new List<TO_Usuarios>();

            foreach (var item in list)
            {
                if (item.Rol != "Cliente")
                {
                TO_Usuarios toUser = new TO_Usuarios();
                toUser.Rol = item.Rol;
                toUser.NombreDeUsuario = item.NombreUsuario;
                toUser.Contrasena = item.Contrasena;
                toUsuarios.Add(toUser);
                }
            }
            return toUsuarios;
        }

    }
}
