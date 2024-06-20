<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManagerFilme.aspx.cs" Inherits="CEuEscuro.UI.adm.ManagerFilme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Formulário --%>
    <div id="FormularioManagerFilm">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 my-4 p-5 card shadow-lg border-1" style="border-radius: 15px;">
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtId" CssClass="form-control .inputs text-light" placeholder="Id:" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtTitulo" CssClass="form-control .inputs text-light" MaxLength="150" placeholder="Titulo:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtProdutora" CssClass="form-control .inputs text-light" MaxLength="150" placeholder="Produtora:" runat="server"></asp:TextBox>
                        <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <span>Selecione a classificação:</span>
                    </div>
                    <div class="form-group mb-3">
                        <asp:DropDownList ID="ddlClassificacao" CssClass="form-control" Width="160px" Height="35px" AutoPostBack="false" DataValueField="IdClassificacao" DataTextField="DescricaoClassificacao" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <asp:DropDownList ID="ddlGenero" CssClass="form-control" Width="160px" Height="35px" AutoPostBack="false" DataValueField="IdGenero" DataTextField="DescricaoGenero" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3 mt-3">
                        <asp:FileUpload ID="Fup" CssClass="form-control-file" runat="server" />
                        <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:Image ID="img1" runat="server" Width="100" />
                        <asp:Label ID="lblImg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:Button ID="btnRecord" CssClass="btn btn-primary" runat="server" Text="Record" OnClick="btnRecord_Click" />
                        <asp:Button ID="btnClear" CssClass="btn btn-warning text-light fw-bold" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        <asp:Button ID="btnDelete" CssClass="btn btn-secondary" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro?'))return false" />
                    </div>
                    <div class="form-group d-flex mb-3">
                        <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Search:" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSearch" CssClass="btn btn-success mx-3 text-light d-flex text-center justify-content-center align-content-center" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group d-flex">
                        <asp:TextBox ID="txtFilter" CssClass="form-control" placeholder="Filter by Genre:" MaxLength="150" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFilter" CssClass="btn btn-success mx-3 text-light d-flex text-center justify-content-center align-content-center" runat="server" Text="Filter" OnClick="btnFilter_Click" />
                        <asp:Button ID="btnClearFilter" CssClass="btn btn-warning mx-3 text-light d-flex text-center justify-content-center align-content-center fw-bold" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
                        <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblMessage" CssClass="fw-bold" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%-- GridView --%>
    <div class="table-responsive mx-auto pt-3 px-3 gv2 card shadow-lg border-1 table-custom container-fluid">
        <asp:GridView ID="gv2" AutoGenerateColumns="false" CssClass="table table-bordered table-hover text-center table-custom" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" ControlStyle-CssClass="btn btn-custom" />
                <asp:BoundField DataField="IdFilm" HeaderText="Código" />
                <asp:BoundField DataField="TituloFilm" HeaderText="Título" />
                <asp:BoundField DataField="ProdutoraFilm" HeaderText="Produtora" />
                <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
                <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
                <asp:ImageField DataImageUrlField="UrlImgFilm" HeaderText="Imagem" ControlStyle-Width="100"></asp:ImageField>
            </Columns>
            <SelectedRowStyle BackColor="#0FDB8F" ForeColor="AliceBlue" Font-Bold="true" />
        </asp:GridView>
    </div>

</asp:Content>
