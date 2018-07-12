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
    public partial class adminUsuarios : System.Web.UI.Page
    {
        BL_Usuario usuarios = new BL_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuarios();


            }

        }

        void cargarUsuarios()
        {

            var users = usuarios.cargarUsuarios();



            if (users.Count > 0)
            {
                gvUsuarios.DataSource = users;
                gvUsuarios.DataBind();
            }
            else
            {
                DataTable databl = new DataTable();
                databl.Rows.Add(databl.NewRow());
                gvUsuarios.DataSource = databl;
                gvUsuarios.DataBind();
                gvUsuarios.Rows[0].Cells.Clear();
                gvUsuarios.Rows[0].Cells.Add(new TableCell());
                gvUsuarios.Rows[0].Cells[0].ColumnSpan = databl.Columns.Count;
                gvUsuarios.Rows[0].Cells[0].Text = "!No se encontraron datos!";
                gvUsuarios.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                    if ((gvUsuarios.FooterRow.FindControl("txtRolfoot") as TextBox).Text.Trim().Equals("Admin") ||
                        (gvUsuarios.FooterRow.FindControl("txtRolfoot") as TextBox).Text.Trim().Equals("Cocina"))
                    {
                        usuarios.registrarUsuario(
                            (gvUsuarios.FooterRow.FindControl("txtNombreUsuariofoot") as TextBox).Text.Trim(),
                            (gvUsuarios.FooterRow.FindControl("txtContrasenafoot") as TextBox).Text.Trim(),
                            (gvUsuarios.FooterRow.FindControl("txtRolfoot") as TextBox).Text.Trim());
                        lblMessageExito.Text = "Se registro correctamente";
                        lblMessageFail.Text = "";
                    }
                    else
                    {
                        lblMessageExito.Text = "";
                        lblMessageFail.Text = "El campo rol debe especificamente «Cocina» o «Admin»";
                    }

                }
                cargarUsuarios();
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }

        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsuarios.EditIndex = e.NewEditIndex;
            cargarUsuarios();
        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsuarios.EditIndex = -1;
            cargarUsuarios();
        }

        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                usuarios.modificarUsuario(
                    (gvUsuarios.Rows[e.RowIndex].FindControl("txtNombreUsuario") as TextBox).Text.Trim(),
                    (gvUsuarios.Rows[e.RowIndex].FindControl("txtContrasena") as TextBox).Text.Trim(),
                    (gvUsuarios.Rows[e.RowIndex].FindControl("txtRol") as TextBox).Text.Trim());
                gvUsuarios.EditIndex = -1;
                cargarUsuarios();
                lblMessageExito.Text = "Se modificó correctamente";
                lblMessageFail.Text = "";
            }
            catch (Exception ex)
            {
                lblMessageExito.Text = "";
                lblMessageFail.Text = "" + ex.Message;
            }
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
             
                usuarios.eliminarUsuario(
                    gvUsuarios.DataKeys[e.RowIndex].Value.ToString())
                   ;
               
                cargarUsuarios();
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