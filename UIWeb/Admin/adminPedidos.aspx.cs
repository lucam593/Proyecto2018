using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data;

namespace UIWeb.Admin
{
    public partial class adminPedidos : System.Web.UI.Page
    {
        BL_Pedido pedido = new BL_Pedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPedidos();


            }
        }

        private void cargarPedidos()
        {
            var pedidos = pedido.cargarPedidos();



            if (pedidos.Count > 0)
            {
                gvPedidos.DataSource = pedidos;
                gvPedidos.DataBind();
            }
            else
            {
                DataTable databl = new DataTable();
                databl.Rows.Add(databl.NewRow());
                gvPedidos.DataSource = databl;
                gvPedidos.DataBind();
                gvPedidos.Rows[0].Cells.Clear();
                gvPedidos.Rows[0].Cells.Add(new TableCell());
                gvPedidos.Rows[0].Cells[0].ColumnSpan = databl.Columns.Count;
                gvPedidos.Rows[0].Cells[0].Text = "!No se encontraron datos!";
                gvPedidos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvPedidos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var estado = (gvPedidos.Rows[e.RowIndex].FindControl("txtEstado") as TextBox).Text.Trim();
                if (estado.Equals("A Tiempo") || estado.Equals("Sobre Tiempo") || estado.Equals("Demorado") ||
                    estado.Equals("Anulado") || estado.Equals("Entregado)"))
                {


                    pedido.modificarEstado(
                        Convert.ToInt16((gvPedidos.DataKeys[e.RowIndex].Value.ToString())),
                        (gvPedidos.Rows[e.RowIndex].FindControl("txtEstado") as TextBox).Text.Trim());
                    gvPedidos.EditIndex = -1;
                    cargarPedidos();
                    lblMessageExito.Text = "Se modificó correctamente";
                    lblMessageFail.Text = "";
                } else
                {
                    lblMessageExito.Text = "";
                    lblMessageFail.Text = "Los estados deben ser «A Tiempo»,«Sobre Tiempo», «Demorado», «Anulado» y «Entregado» especificamente ";
                }
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }

        protected void gvPedidos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPedidos.EditIndex = -1;
            cargarPedidos();
        }

        protected void gvPedidos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPedidos.EditIndex = e.NewEditIndex;
            cargarPedidos();
        }
    }
}