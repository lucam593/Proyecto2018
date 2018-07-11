<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMenu.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="adminPlatos.aspx.cs" Inherits="UIWeb.Admin.adminPlatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>
            <span style="float: left;">
                <asp:Label ID="lblInfo" runat="server" /></span>
            <span style="float: right;"><small>Total platos:</small>
                <asp:Label ID="lblPlatos" runat="server" CssClass="label label-warning" /></span>
        </h3>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <asp:GridView ID="gvPlatos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered bs-table" DataKeyNames="Codigo" OnDataBound="gvPlatosDataBound" OnRowDeleted="gvPlatosDeleted" OnRowEditing="gvPlatosEditing" OnRowUpdated="gvPlatosUpdated" OnPreRender="gvPreRender">
            <EditRowStyle BackColor="#FFFFCC" />
            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
            <HeaderStyle BackColor="#337AB7" Font-Bold="True" ForeColor="White" />
            <EmptyDataTemplate>
                ¡No hay platos con los parámetros seleccionados!
            </EmptyDataTemplate>

            <PagerTemplate>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-lg-1" style="text-align: right;">
                        <h5>
                            <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                    </div>
                    <div class="col-lg-1" style="text-align: left;">
                        <asp:DropDownList ID="PageDropDownList" Width="50px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                    </div>
                    <div class="col-lg-10" style="text-align: right;">
                        <h3>
                            <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                    </div>
                </div>
            </PagerTemplate>

            <Columns>
                <%--CheckBox para seleccionar varios registros...--%>
               

                <%--botones de acción sobre los registros...--%>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <%--Botones de eliminar y editar ...--%>
                        <asp:Button ID="btnDelete" runat="server" Text="Quitar" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Eliminar plato?');" />
                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <%--Botones de grabar y cancelar la edición de registro...--%>
                        <asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del plato?');" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--campos no editables...--%>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="Codigo_Plato" ControlStyle-Width="70px" />


                <%--campos editables...--%>
                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server"><%# Eval("Nombre")%></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("Nombre")%>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Descripción">
                    <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server"><%# Eval("Descripcion")%></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtDesc" runat="server" Text='<%# Bind("Descripcion")%>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
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
       

    </div>
</asp:Content>
