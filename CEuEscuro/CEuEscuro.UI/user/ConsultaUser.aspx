<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaUser.aspx.cs" Inherits="CEuEscuro.UI.user.ConsultaUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--gridView--%>

    <div class="table-responsive mx-auto pt-3 px-3 gv2 card shadow-lg border-1 table-custom container-fluid">
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover text-center table-custom">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
                <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                <%--<asp:BoundField DataField="SenhaUsuario" HeaderText="Senha"/>--%>
                <asp:BoundField DataField="DtNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
