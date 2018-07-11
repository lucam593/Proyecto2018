using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.Cocina
{
    public partial class Cocina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                BL_Usuario blUser = new BL_Usuario();
                blUser.NombreDeUsuario = Login1.UserName;
                blUser.Contrasena = Login1.Password;
                blUser.Rol = "Cocina";
                blUser.seleccionarUsuario();

                FormsAuthentication.RedirectFromLoginPage(blUser.NombreDeUsuario, false);
                

            }
            catch (Exception ex)
            {
                Login1.FailureText = ex.ToString();
            }


        }
    }
}