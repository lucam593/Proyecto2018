<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" CodeBehind="adminEstados.aspx.cs" Inherits="UIWeb.Admin.adminEstados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <asp:GridView ID="gvEstados" CssClass="table table-bordered bs-table" runat="server" OnRowEditing="gvEstados_RowEditing"
        OnRowCancelingEdit="gvEstados_RowCancelingEdit" OnRowUpdating="gvEstados_RowUpdating" 

         AutoGenerateColumns="false" Height="109px" Width="290px" ShowFooter="true" ShowHeaderWhenEmpty="true" DataKeyNames="NombreEstado">
        
         <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:TemplateField ControlStyle-Width="200px" HeaderText="Nombre de Estado">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("NombreEstado") %>'  runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreEstado" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("NombreEstado") %>'></asp:TextBox>
                </EditItemTemplate>    
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Limite en Minutos">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("LimiteMinutos") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLimiteMinutos" CssClass="form-control" runat="server" Text='<%# Eval("LimiteMinutos") %>'></asp:TextBox>
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
