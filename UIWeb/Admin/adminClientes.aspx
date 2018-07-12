<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" CodeBehind="adminClientes.aspx.cs" Inherits="UIWeb.Admin.adminClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <asp:GridView ID="gvClientes" CssClass="table table-bordered bs-table" runat="server" OnRowEditing="gvClientes_RowEditing"
        OnRowCancelingEdit="gvClientes_RowCancelingEdit" OnRowUpdating="gvClientes_RowUpdating" 

         AutoGenerateColumns="false" Height="109px" Width="290px" ShowFooter="true" ShowHeaderWhenEmpty="true" DataKeyNames="NombreDeUsuario">
        
         <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:TemplateField ControlStyle-Width="200px" HeaderText="Nombre de Cliente">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("NombreDeUsuario") %>'  runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreDeUsuario" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("NombreDeUsuario") %>'></asp:TextBox>
                </EditItemTemplate>    
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Nombre Completo">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("NombreCompleto") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreCompleto" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("NombreCompleto") %>'></asp:TextBox>
                </EditItemTemplate>
               </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Correo">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Correo") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCorreo" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("Correo") %>'></asp:TextBox>
                </EditItemTemplate>
               </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Dirección">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Direccion") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDireccion" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("Direccion") %>'></asp:TextBox>
                </EditItemTemplate>
               </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Habilitado">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckHabilitadoin" runat="server" AutoPostBack="true" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Habilitado"))%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="ckHabilitado" Enabled="true" runat="server" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("Habilitado"))%>' />
                    </EditItemTemplate>
                </asp:TemplateField>


            <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="Edit" CssClass="btn btn-info" Text="Editar" ToolTip="Edit" Width="60px" Height="30px"/>
                   
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" CssClass="btn btn-success" CommandName="Update" Text="Guardar" ToolTip="Update" Width="70px" Height="30px" OnClientClick="return confirm('¿Seguro que quiere modificar el tiempo?');"/>
                    <asp:Button runat="server"  CssClass="btn btn-default" CommandName="Cancel" Text="Cancelar" ToolTip="Cancel" Width="80px" Height="30px"/>
                </EditItemTemplate>
              
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <br />
    <asp:Label ID="lblMessageExito" Text="" runat="server" ForeColor="Green"></asp:Label>
    <br />
    <asp:Label ID="lblMessageFail" Text="" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
