<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilme.aspx.cs" Inherits="CEuEscuro.UI.user.ConsultaFilme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="FormularioManagerFilm">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 my-4 p-5 card shadow-lg border-1" style="border-radius: 15px;">
                    <div class="form-group d-flex">
                        <asp:TextBox ID="txtFilter" runat="server" placeholder="Filter by Genre:" MaxLength="150"></asp:TextBox>
                        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
                        <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
                        <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive mx-auto pt-3 px-3 gv2 card shadow-lg border-1 table-custom container-fluid">
        <asp:GridView ID="gv2" AutoGenerateColumns="false" CssClass="table table-bordered table-hover text-center table-custom" runat="server">
            <Columns>
                <asp:BoundField DataField="IdFilm" HeaderText="Código" />
                <asp:BoundField DataField="TituloFilm" HeaderText="Título" />
                <asp:BoundField DataField="ProdutoraFilm" HeaderText="Produtora" />
                <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação" />
                <asp:BoundField DataField="Genero_Id" HeaderText="Gênero" />
                <asp:ImageField DataImageUrlField="UrlImgFilm" HeaderText="Imagem" ControlStyle-Width="100"></asp:ImageField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
