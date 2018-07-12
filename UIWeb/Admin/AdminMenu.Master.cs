using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIWeb.Admin
{
    public partial class AdminMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminss"] != null)
            {
                
                usuarioID.InnerText = " " + Session["adminss"].ToString();
            } else
            {
                Response.Redirect("IniSesion.aspx");
            }
            
        }
    }
}