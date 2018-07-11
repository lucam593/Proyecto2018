<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cocina.aspx.cs" Inherits="UIWeb.Cocina.Cocina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .div{
        text-align:center;
        background-color: white;
    }
    .lbldiv{
        background-color: black;
        text-align:center;
    }
    .label {
        font-size: 30px;
        font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
        color: white;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        <br />
    <div class="col-md-offset-3 col-md-6 div h-100">
        <br />
        <br />
        <div class="lbldiv">
            <br />
            <asp:Label ID="Label3" runat="server" Text="Login" CssClass="label"></asp:Label>
            <br />
            <br />
        </div>
        <br />
        <asp:Table ID="Table1" runat="server"  CssClass="table table-bordered text-center" BorderStyle="Solid" BorderColor="Transparent">
            <asp:TableRow BorderStyle="Solid" BorderColor="Transparent">
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label> 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow BorderStyle="Solid" BorderColor="Transparent">
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow BorderStyle="Solid" BorderColor="Transparent">
                <asp:TableCell>
                    <asp:Button ID="btnLog" runat="server" Text="Log In" OnClick="btnLog_Click" CssClass="btn btn-primary"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="Sign In" OnClick="btnRegister_Click" CssClass="btn btn-success"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />
        <asp:Label ID="labelError" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>



</asp:Content>
