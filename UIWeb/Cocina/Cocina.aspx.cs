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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                BL_Usuario blUser = new BL_Usuario();
                blUser.NombreDeUsuario = TextBox1.Text.Trim();
                blUser.Contrasena = TextBox2.Text.Trim();
                blUser.Rol = "Cocina";
                blUser.seleccionarUsuario();
                Response.Redirect("PedidoCocina.aspx");
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.ToString();
            }



        }
    }
}