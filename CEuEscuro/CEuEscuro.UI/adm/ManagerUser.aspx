<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManagerUser.aspx.cs" Inherits="CEuEscuro.UI.adm.ManagerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--formulario--%>
    <div id="FormularioUserManager">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 my-4 p-5 card shadow-lg border-1" style="border-radius: 15px;">
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtIdUsuario" CssClass="form-control .inputs text-light" placeholder="Id:" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtNomeUsuario" CssClass="form-control .inputs text-light" MaxLength="150" placeholder="Nome:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtEmailUsuario" CssClass="form-control .inputs text-light" MaxLength="150" placeholder="Email:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblEmailUsuario" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtSenhaUsuario" CssClass="form-control .inputs text-light" MaxLength="6" placeholder="Senha:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblSenhaUsuario" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtDtNascUsuario" CssClass="form-control .inputs text-light" onkeypress="$(this).mask('00/00/0000')" placeholder="Data Nasc:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblDtNascUsuario" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:DropDownList ID="ddl1" CssClass="form-control" Width="160px" Height="35px" AutoPostBack="false" DataValueField="IdTipoUsuario" DataTextField="DescricaoTipoUsuario" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <asp:Button ID="btnRecord" CssClass="btn btn-primary" runat="server" Text="Record" OnClick="btnRecord_Click" />
                        <asp:Button ID="btnClear" CssClass="btn btn-warning text-light fw-bold  " runat="server" Text="Clear" OnClick="btnClear_Click" />
                        <asp:Button ID="btnDelete" CssClass="btn btn-secondary" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente excluir este registro?'))return false" runat="server" Text="Delete" />
                    </div>
                    <div class="form-group d-flex">
                        <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Buscar pelo name:" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSearch" CssClass="btn btn-success mx-3 text-light d-flex text-center justify-content-center align-content-center" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fw-bold"></asp:Label>

    <div class="table-responsive mx-auto pt-3 px-3 gv2 card shadow-lg border-1 table-custom container-fluid">
        <%--gridView--%>
        <asp:GridView ID="gv1" OnSelectedIndexChanged="gv1_SelectedIndexChanged" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover text-center table-custom">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" ControlStyle-CssClass="btn btn-primary" />
                <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
                <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
                <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
                <asp:BoundField DataField="DtNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permissão" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
