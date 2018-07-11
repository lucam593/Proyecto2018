using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UIWeb.Admin
{
    public partial class adminPlatos : System.Web.UI.Page
    {

        private int totalItemSeleccionados = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ManejadorPlatos managerP = new ManejadorPlatos();
                var platos = managerP.cargarPlatos();
                gvPlatos.DataSource = platos;
                gvPlatos.DataBind();
            }
           
            
           
            
        }

        protected void gvPlatosUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblInfo.Text = " ¡Modificación realizada OK! ";
            lblInfo.CssClass = "label label-success";
            }
            else
            {
                lblInfo.Text = " ¡Se ha producido un error al intentar modificar el cliente! ";
                lblInfo.CssClass = "label label-danger";
                e.ExceptionHandled = true;
            }
        }

        protected void gvPlatosDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblInfo.Text = " ¡Cliente/s eliminado/s OK! ";
            lblInfo.CssClass = "label label-success";
            } else
            {
                lblInfo.Text = " ¡Se ha producido un error al intentar elimnar el/los cliente/s! ";
            lblInfo.CssClass = "label label-danger";
            e.ExceptionHandled = true;
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender , EventArgs e)
        {
            GridViewRow filapag = gvPlatos.BottomPagerRow;
            DropDownList listapag = (DropDownList) filapag.Cells[0].FindControl("PageDropDownList");
            gvPlatos.PageIndex = listapag.SelectedIndex;
            lblInfo.Text = "";
        }


        protected void gvPlatosEditing(object sender, GridViewEditEventArgs e)
        {
            lblInfo.Text = "";
        }

        protected void gvPlatosDataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvPlatos.BottomPagerRow;
            DropDownList ddlist = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            Label pagelb = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

            if (ddlist != null)
            {
                for (int i = 0; i < gvPlatos.PageCount -1; i++)
                {
                    int pagerN = i + 1;
                    ListItem item = new ListItem(pagerN.ToString());
                    if (i == gvPlatos.PageIndex)
                    {
                        item.Selected = true;
                    }

                    ddlist.Items.Add(item);

                }
            }

            if (pagelb != null)
            {
                int currentP = gvPlatos.PageIndex + 1;
                pagelb.Text = "Página " + currentP.ToString() + "de " + gvPlatos.PageCount.ToString();
            }
        }

       
        protected void chk_HabilitadoChanged(object sender, EventArgs e)
        { }

       
    }
}