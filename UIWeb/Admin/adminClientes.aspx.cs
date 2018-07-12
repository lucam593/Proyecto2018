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
    public partial class adminClientes : System.Web.UI.Page
    {
        BL_Cliente cliente = new BL_Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarClientes();


            }
        }

        void cargarClientes()
        {

            var clientes = cliente.cargarClientes();



            if (clientes.Count > 0)
            {
                gvClientes.DataSource = clientes;
                gvClientes.DataBind();
            }
            else
            {
                DataTable databl = new DataTable();
                databl.Rows.Add(databl.NewRow());
                gvClientes.DataSource = databl;
                gvClientes.DataBind();
                gvClientes.Rows[0].Cells.Clear();
                gvClientes.Rows[0].Cells.Add(new TableCell());
                gvClientes.Rows[0].Cells[0].ColumnSpan = databl.Columns.Count;
                gvClientes.Rows[0].Cells[0].Text = "!No se encontraron datos!";
                gvClientes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            cargarClientes();
        }

        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                cliente.modificarEstado(
                     (gvClientes.DataKeys[e.RowIndex].Value.ToString()),
                    (gvClientes.Rows[e.RowIndex].FindControl("ckHabilitado") as CheckBox).Checked);
                gvClientes.EditIndex = -1;
                cargarClientes();
                lblMessageExito.Text = "Se modificó correctamente";
                lblMessageFail.Text = "";
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            cargarClientes();
        }
    }
}