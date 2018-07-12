using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.Admin
{
    public partial class IniSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Adminss"] = null;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Usuario blUser = new BL_Usuario();
                blUser.NombreDeUsuario = usuario.Text;
                blUser.Contrasena = cont.Text;
                blUser.Rol = "Admin";
                blUser.seleccionarUsuarioCocina();

                Session["Adminss"] = usuario.Text;

                Response.Redirect("adminInicio.aspx");


            }
            catch (Exception)
            {
                lblerror.Text = "Error de autenticación";
            }
        }
    }
}