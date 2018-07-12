<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="adminPlatos.aspx.cs" Inherits="UIWeb.Admin.adminPlatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
    <asp:GridView ID="gvPlatos" CssClass="table table-bordered bs-table" runat="server" OnRowCommand="gvPlatos_RowCommand" OnRowEditing="gvPlatos_RowEditing"
        OnRowCancelingEdit="gvPlatos_RowCancelingEdit" OnRowUpdating="gvPlatos_RowUpdating" OnRowDeleting="gvPlatos_RowDeleting"

         AutoGenerateColumns="false" Height="109px" Width="290px" ShowFooter="true" ShowHeaderWhenEmpty="true" DataKeyNames="Codigo">
        
         <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />

        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="Codigo_Plato" ControlStyle-Width="70px" />
           
             <asp:TemplateField ControlStyle-Width="200px" HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Nombre") %>'  runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Text='<%# Eval("Nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNombrefoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField ControlStyle-Width="200px"  HeaderText="Descripción">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Descripcion") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDescripcionfoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

             <asp:TemplateField  ControlStyle-Width="100px" HeaderText="Precio">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Precio") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Text='<%# Eval("Precio") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPreciofoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            
                <asp:TemplateField  ControlStyle-Width="350px" HeaderText="Fotografia">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Fotografia") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFotografia" runat="server" CssClass="form-control" Text='<%# Eval("Fotografia") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFotografiafoot" CssClass="form-control" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Habilitado">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckHabilitadoin" runat="server" AutoPostBack="true" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Habilitado"))%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="ckHabilitado" Enabled="true" runat="server" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("Habilitado"))%>' />
                    </EditItemTemplate>
                 <FooterTemplate>
                    <asp:CheckBox ID="ckHabilitadofoot" Enabled="true" runat="server" Checked="true" AutoPostBack="true" ></asp:CheckBox>
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
    
    
    
    
  <%-- <%-- <div class="container">
        

          
             

           
               
                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Precio">
                    <ItemTemplate>
                        <asp:Label ID="lblPrecio" runat="server"><%# Eval("Precio")%></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtPrecio" runat="server" Text='<%# Bind("Precio")%>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Fotografía">
                    <ItemTemplate>
                        <asp:Label ID="lblFoto" runat="server"><%# Eval("Fotografia")%></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtFoto" runat="server" Text='<%# Bind("Fotografia")%>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Habilitado">
                    <ItemTemplate>
                        <asp:CheckBox ID="ckHabilitado" runat="server" AutoPostBack="true" Enabled="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="ckHabilitado" Enabled="true" runat="server" AutoPostBack="true" OnCheckedChanged="chk_HabilitadoChanged" />
                    </EditItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       

    </div>--%>
</asp:Content>
