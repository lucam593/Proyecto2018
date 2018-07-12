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
    public partial class adminPlatos : System.Web.UI.Page
    {

        BL_Plato platos = new BL_Plato();
        ManejadorPlatos manager = new ManejadorPlatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPlatos();


            }




        }

        void cargarPlatos()
        {

            var platoes = manager.cargarPlatos();



            if (platoes.Count > 0)
            {
                gvPlatos.DataSource = platoes;
                gvPlatos.DataBind();
            }
            else
            {
                DataTable databl = new DataTable();
                databl.Rows.Add(databl.NewRow());
                gvPlatos.DataSource = databl;
                gvPlatos.DataBind();
                gvPlatos.Rows[0].Cells.Clear();
                gvPlatos.Rows[0].Cells.Add(new TableCell());
                gvPlatos.Rows[0].Cells[0].ColumnSpan = databl.Columns.Count;
                gvPlatos.Rows[0].Cells[0].Text = "!No se encontraron datos!";
                gvPlatos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvPlatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                   
                        platos.guardarPlato(
                            (gvPlatos.FooterRow.FindControl("txtNombrefoot") as TextBox).Text.Trim(),
                            (gvPlatos.FooterRow.FindControl("txtDescripcionfoot") as TextBox).Text.Trim(),
                            (Convert.ToDouble((gvPlatos.FooterRow.FindControl("txtPreciofoot") as TextBox).Text.Trim())),
                             (gvPlatos.FooterRow.FindControl("txtFotografiafoot") as TextBox).Text.Trim(),
                             (gvPlatos.FooterRow.FindControl("ckHabilitadofoot") as CheckBox).Checked);

                        lblMessageExito.Text = "Se registro correctamente";
                        lblMessageFail.Text = "";
                    }
                    else
                    {
                        lblMessageExito.Text = "";
                        lblMessageFail.Text = "Error al guardar el plato";
                    }

                
                cargarPlatos();
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }

        }

        protected void gvPlatos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPlatos.EditIndex = e.NewEditIndex;
            cargarPlatos();
            lblMessageExito.Text = "";
            lblMessageFail.Text = "";
        }

        protected void gvPlatos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPlatos.EditIndex = -1;
            cargarPlatos();
            lblMessageExito.Text = "";
            lblMessageFail.Text = "";
        }

        protected void gvPlatos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                
                platos.modificarUsuario(
                     Convert.ToInt16( gvPlatos.DataKeys[e.RowIndex].Value.ToString()),
                    (gvPlatos.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim(),
                            (gvPlatos.Rows[e.RowIndex].FindControl("txtDescripcion") as TextBox).Text.Trim(),
                            (Convert.ToDouble((gvPlatos.Rows[e.RowIndex].FindControl("txtPrecio") as TextBox).Text.Trim())),
                             (gvPlatos.Rows[e.RowIndex].FindControl("txtFotografia") as TextBox).Text.Trim(),
                             (gvPlatos.Rows[e.RowIndex].FindControl("ckHabilitado") as CheckBox).Checked);
                gvPlatos.EditIndex = -1;
                cargarPlatos();
                lblMessageExito.Text = "Se modificó correctamente";
                lblMessageFail.Text = "";
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }

        protected void gvPlatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                platos.eliminarPlato(
                   Convert.ToInt16(gvPlatos.DataKeys[e.RowIndex].Value.ToString()))
                   ;

                cargarPlatos();
                lblMessageExito.Text = "Se eliminó correctamente";
                lblMessageFail.Text = "";
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }
    }
}