<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CEuEscuro.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/style.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link rel="shortcut icon" href="imgflix/favicon.png" type="image/x-icon" />
    <title>Film</title>
</head>
<body class="bg-dark">
    <header>
        <nav class="navbar navbar-expand-lg navbar-custom position-absolute w-100 justify-content-center">
            <div class="container d-flex justify-content-between align-items-center">
                <a class="navbar-brand fonte-titulo" href="#">
                    <img src="imgflix/logo.png" alt="logo" class="img-fluid" />
                </a>
            </div>
        </nav>
    </header>
    <main class="mainbackground">
        <section id="login" class="container d-flex justify-content-center align-items-center vh-100">
            <div class="card p-4" style="max-width: 600px;">
                <h1 class="text-center text-light mb-4">Entrar</h1>
                <form id="form1" runat="server">
                    <div class="form-outline mb-4">
                        <label class="form-label shadow-none text-light" for="txtNomeUsuario">Seu Email</label>
                        <asp:TextBox ID="txtNomeUsuario" CssClass="form-control form-control-lg inputs" placeholder="Nome" MaxLength="150" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-outline mb-4">
                        <label class="form-label shadow-none text-light" for="txtSenhaUsuario">Senha</label>
                        <asp:TextBox ID="txtSenhaUsuario" CssClass="form-control form-control-lg inputs" placeholder="Senha" TextMode="Password" MaxLength="6" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-center botaologin">
                        <asp:Button ID="btnEntrar" CssClass="btn btn-primary btn-lg text-white btn-flex mx-5" Text="Entrar" runat="server" OnClick="btnLogar_Click" />
                        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary btn-lg text-white btn-flex mx-5" Text="Cancelar" runat="server" />
                    </div>
                    <div class="form-outline mt-5 mb-3 d-flex justify-content-center">
                        <a class="fw-bold text-light text-center">Esqueceu a Senha?</a>
                    </div>
                    <p class="text-center text-light mt-4 mb-0 h6">Novo por aqui? <a href="#!" class="fw-bold text-light"><u>Assine agora.</u></a></p>
                    <div class="text-center pt-4">
                        <asp:Label ID="lblMensagem" runat="server" Text="" CssClass="h4 fw-bold text-light"></asp:Label>
                    </div>
                </form>
            </div>
        </section>
    </main>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"
        integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js"
        integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy"
        crossorigin="anonymous"></script>
    <script src="script/script.js"></script>
</body>
</html>
