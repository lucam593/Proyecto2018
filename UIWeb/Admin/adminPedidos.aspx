<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" CodeBehind="adminPedidos.aspx.cs" Inherits="UIWeb.Admin.adminPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var txtFiltro = '#' + '<%=txtFiltro.ClientID%>';
            var grillaJedis = '#' + 'gvPedidos';
            $(txtFiltro).quicksearch(grillaJedis + 'tbody tr');

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <asp:TextBox runat="server" ID="txtFiltro"></asp:TextBox>
    <asp:GridView ID="gvPedidos" CssClass="table table-bordered bs-table" runat="server" OnRowEditing="gvPedidos_RowEditing"
        OnRowCancelingEdit="gvPedidos_RowCancelingEdit" OnRowUpdating="gvPedidos_RowUpdating" 

         AutoGenerateColumns="false" Height="109px" Width="290px" ShowFooter="true" ShowHeaderWhenEmpty="true" DataKeyNames="NumeroPedido">
        
         <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:TemplateField ControlStyle-Width="200px" HeaderText="Numero de Pedido">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("NumeroPedido") %>'  runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNumeroPedido" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("NumeroPedido") %>'></asp:TextBox>
                </EditItemTemplate>    
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Cliente">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Cliente.NombreDeUsuario") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCliente" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("Cliente.NombreDeUsuario") %>'></asp:TextBox>
                </EditItemTemplate>
               </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Estado.NombreEstado") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEstado" Enabled="true" CssClass="form-control" runat="server" Text='<%# Eval("Estado.NombreEstado") %>'></asp:TextBox>
                </EditItemTemplate>
               </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Fecha") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFecha" Enabled="false" CssClass="form-control" runat="server" Text='<%# Eval("Fecha") %>'></asp:TextBox>
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
