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
    public partial class adminEstados : System.Web.UI.Page
    {
        BL_Estado estados = new BL_Estado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEstados();


            }
        }

        private void cargarEstados()
        {
            var estadoes = estados.cargarEstados();



            if (estadoes.Count > 0)
            {
                gvEstados.DataSource = estadoes;
                gvEstados.DataBind();
            }
            else
            {
                DataTable databl = new DataTable();
                databl.Rows.Add(databl.NewRow());
                gvEstados.DataSource = databl;
                gvEstados.DataBind();
                gvEstados.Rows[0].Cells.Clear();
                gvEstados.Rows[0].Cells.Add(new TableCell());
                gvEstados.Rows[0].Cells[0].ColumnSpan = databl.Columns.Count;
                gvEstados.Rows[0].Cells[0].Text = "!No se encontraron datos!";
                gvEstados.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvEstados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                estados.modificarEstado(
                    (gvEstados.DataKeys[e.RowIndex].Value.ToString()),
                    (Convert.ToInt16((gvEstados.Rows[e.RowIndex].FindControl("txtLimiteMinutos") as TextBox).Text.Trim())));
                gvEstados.EditIndex = -1;
                cargarEstados();
                lblMessageExito.Text = "Se modificó correctamente";
                lblMessageFail.Text = "";
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }

        protected void gvEstados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEstados.EditIndex = e.NewEditIndex;
            cargarEstados();
        }

        protected void gvEstados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEstados.EditIndex = -1;
            cargarEstados();
        }
    }
}