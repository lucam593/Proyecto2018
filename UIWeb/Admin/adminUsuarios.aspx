<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" CodeBehind="adminUsuarios.aspx.cs" Inherits="UIWeb.Admin.adminUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="#" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <asp:GridView ID="gvUsuarios" CssClass="table table-bordered bs-table" runat="server" OnRowCommand="gvUsuarios_RowCommand" OnRowEditing="gvUsuarios_RowEditing"
        OnRowCancelingEdit="gvUsuarios_RowCancelingEdit" OnRowUpdating="gvUsuarios_RowUpdating" OnRowDeleting="gvUsuarios_RowDeleting"

         AutoGenerateColumns="false" Height="109px" Width="290px" ShowFooter="true" ShowHeaderWhenEmpty="true" DataKeyNames="NombreDeUsuario">
        
         <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:TemplateField ControlStyle-Width="200px" HeaderText="Nombre de Usuario">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("NombreDeUsuario") %>'  runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreUsuario" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("NombreDeUsuario") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNombreUsuariofoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Contraseña">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Contrasena") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtContrasena" CssClass="form-control" runat="server" Text='<%# Eval("Contrasena") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtContrasenafoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField  ControlStyle-Width="100px" HeaderText="Rol">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Rol") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtRol" runat="server" CssClass="form-control" Text='<%# Eval("Rol") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRolfoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="Edit" CssClass="btn btn-info" Text="Editar" ToolTip="Edit" Width="60px" Height="30px"/>
                    <asp:Button runat="server" CommandName="Delete" CssClass="btn btn-danger" Text="Borrar" ToolTip="Delete" Width="60px" Height="30px" OnClientClick="return confirm('¿Eliminar usuario?');"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" CssClass="btn btn-success" CommandName="Update" Text="Guardar" ToolTip="Update" Width="70px" Height="30px" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del usuario?');"/>
                    <asp:Button runat="server"  CssClass="btn btn-default" CommandName="Cancel" Text="Cancelar" ToolTip="Cancel" Width="80px" Height="30px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button runat="server" CssClass="btn btn-success" CommandName="AddNew" ToolTip="AddNew" Text="Agregar" Width="70px" Height="30px"/>
                </FooterTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <br />
    <asp:Label ID="lblMessageExito" Text="" runat="server" ForeColor="Green"></asp:Label>
    <br />
    <asp:Label ID="lblMessageFail" Text="" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
