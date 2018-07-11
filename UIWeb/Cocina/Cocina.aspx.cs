using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.Cocina
{
    public partial class Cocina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ErrorLogin"]!=null)
            {
                labelError.Text = Session["ErrorLogin"].ToString();
            }
            
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Usuario blUser = new BL_Usuario();
                blUser.NombreDeUsuario = txtUser.Text;
                blUser.Contrasena = txtPassword.Text;
                blUser.Rol = "Cocina";
                blUser.seleccionarUsuarioCocina();

                Session["UName"] = txtUser.Text;

                Response.Redirect("PedidoCocina.aspx");


            }
            catch (Exception)
            {
                labelError.Text = "Error de autenticacion";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            BL_Usuario blUsuario = new BL_Usuario();
            blUsuario.NombreDeUsuario = txtUser.Text;
            blUsuario.Contrasena = txtPassword.Text;
            blUsuario.Rol = "Cocina";
            blUsuario.registrarUsuarioCocina();
        }
    }
}