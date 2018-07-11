<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="IniSesion.aspx.cs" Inherits="UIWeb.Admin.IniSesion" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row vertical-offset-100">
            <div class="col-md-4 col-md-offset-4" style="margin-top: 6%">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Iniciar Sesión</h3>
                    </div>
                    <div class="panel-body">
                        <form accept-charset="UTF-8" role="form">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox runat="server" class="form-control" placeholder="Usuario" ID="usuario" type="text" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Se requiere un nombre de usuario." ControlToValidate="usuario"></asp:RequiredFieldValidator>
                                    &nbsp;
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" runat="server" placeholder="Contraseña" ID="cont" type="password" value=""></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cont" ErrorMessage="*Se requiere una contraseña"></asp:RequiredFieldValidator>
                                </div>

                                <asp:Button runat="server" class="btn btn-lg btn-success btn-block" ID="btnEntrar" Text="Entrar" OnClick="btnEntrar_Click" />
                                <br />
                                <asp:Label ID="lblerror" CssClass="text-danger lead" runat="server" Text=""></asp:Label>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
