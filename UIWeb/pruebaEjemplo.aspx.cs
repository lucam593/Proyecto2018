using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb
{
    public partial class pruebaEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BL_Cliente blCliente = new BL_Cliente();
            blCliente.NombreDeUsuario = TextBox1.Text.Trim();
            blCliente.modificarDireccionCliente(TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox3.Text.Trim());
        }
    }
}