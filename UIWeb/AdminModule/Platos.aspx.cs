using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.AdminModule
{
    public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManejadorPlatos platos = new ManejadorPlatos();
            gdvPlatos.DataSource = platos.cargarPlatos();
            gdvPlatos.DataBind();
        }
    }
}