using CEuEscuro.BLL;
using CEuEscuro.DTO;
using CEuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CEuEscuro.UI.adm
{
    public partial class ManagerFilme : System.Web.UI.Page
    {
        FilmeDTO filmeDTO = new FilmeDTO();
        FilmeBLL filmeBLL = new FilmeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                PopularGV2();
                PopularDDLClassif();
                PopularDDLGenero();
            }
        }

        public void PopularGV2()
        {
            gv2.DataSource = filmeBLL.GetFilmAll();
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
            img1.ImageUrl = string.Empty;
        }

        //validation

        public bool ValidaPage()
        {
            bool valid;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite um titulo!!";
                txtTitulo.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite uma Produtora!!";
                txtProdutora.Focus();
                valid = false;
            }
            else if (!Fup.HasFile && img1.ImageUrl == string.Empty)
            {
                lblFup.Text = "Envie uma imagem!!";
                Fup.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public void PopularDDLClassif()
        {
            ddlClassificacao.DataSource = filmeBLL.LoadDDLClassificacao();
            ddlClassificacao.DataBind();
        }
        public void PopularDDLGenero()
        {
            ddlGenero.DataSource = filmeBLL.LoadDDLGenero();
            ddlGenero.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            PopularGV2();
            Clear.ClearControl(this);
            txtSearch.Focus();
        }

        //Search by id
        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filmeId = int.Parse(gv2.SelectedRow.Cells[1].Text);
            filmeDTO = filmeBLL.GetById(filmeId);
            //preenchendo os cmapos
            txtId.Text = filmeDTO.IdFilm.ToString();
            txtTitulo.Text = filmeDTO.TituloFilm.ToString();
            txtProdutora.Text = filmeDTO.ProdutoraFilm.ToString();
            ddlClassificacao.SelectedValue = filmeDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = filmeDTO.Genero_Id.ToString();
            txtTitulo.Focus();

            img1.ImageUrl = filmeDTO.UrlImgFilm;
            lblImg.Text = img1.ImageUrl;

            txtTitulo.Focus();
        }

        //Search by Name

        public void SearchByName(string titulo)
        {
            titulo = txtSearch.Text.Trim();
            filmeDTO = filmeBLL.GetByName(titulo);
            //preenchendo os campos
            txtId.Text = filmeDTO.IdFilm.ToString();
            txtTitulo.Text = filmeDTO.TituloFilm.ToString();
            txtProdutora.Text = filmeDTO.ProdutoraFilm.ToString();
            ddlClassificacao.SelectedValue = filmeDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = filmeDTO.Genero_Id.ToString();
            txtTitulo.Focus();

            img1.ImageUrl = filmeDTO.UrlImgFilm;
            lblImg.Text = img1.ImageUrl;
            txtTitulo.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titulo = txtSearch.Text.Trim();
            filmeDTO = filmeBLL.GetByName(titulo);
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblSearch.Text = "Digite um Titulo pra busca!";
                txtSearch.Focus();
                return;
            }
            else if (filmeDTO.TituloFilm == null)
            {
                lblSearch.Text = "Filme não cadastrado";
                txtSearch.Text = string.Empty;
                PopularGV2();
                return;
            }
            else
            {
                SearchByName(titulo);
                lblSearch.Text = string.Empty;
            }
        }

        //Filter

        public void FilterGV2()
        {
            string filter = txtFilter.Text.Trim();
            gv2.DataSource = filmeBLL.FilterFilm(filter);
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = txtFilter.Text.Trim();
            var result = filmeBLL.FilterFilm(filter);

            if (string.IsNullOrEmpty(txtFilter.Text) || result.Count == 0)
            {
                Clear.ClearControl(this);
                lblFilter.Text = "Digite um gênero existente";
                txtFilter.Text = string.Empty;
                txtFilter.Focus();
                PopularGV2();
            }
            else
            {
                FilterGV2();
                Clear.ClearControl(this);
                txtFilter.Focus();
            }
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            PopularGV2();
            txtFilter.Text = string.Empty;
            txtFilter.Focus();
        }

        //Record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {
                //preenchendo dados fornecidos pelo usuario
                filmeDTO.TituloFilm = txtTitulo.Text.Trim();
                filmeDTO.ProdutoraFilm = txtProdutora.Text.Trim();
                filmeDTO.Classificacao_Id = ddlClassificacao.SelectedValue;
                filmeDTO.Genero_Id = ddlGenero.SelectedValue;
                //image
                if(Fup.HasFile)
                {
                    string str = Fup.FileName;
                    Fup.PostedFile.SaveAs(Server.MapPath($"~/img/{str}"));
                    string pathImg = $"~/img/{str}";
                    filmeDTO.UrlImgFilm = pathImg;
                }
                else 
                {
                    filmeDTO.UrlImgFilm = img1.ImageUrl;
                }
                //checando campo id

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    filmeBLL.CreateFilm(filmeDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O titulo {filmeDTO.TituloFilm.ToUpper()} foi cadastrado com sucesso!!";
                }
                else
                {
                    filmeDTO.IdFilm = int.Parse(txtId.Text);
                    filmeBLL.UpdateFilm(filmeDTO);
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O titulo {filmeDTO.TituloFilm.ToUpper()} foi editado com sucesso!!";
                }
            }
        }
        //Delete

        public string nomeTituloDelete(int idFilm)
        {
            FilmeDTO titulo = filmeBLL.GetById(idFilm);
            return titulo.TituloFilm;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int idFilm = int.Parse(txtId.Text);
            string titulo = nomeTituloDelete(idFilm);

            filmeBLL.DeleteFilm(idFilm);
            Clear.ClearControl(this);
            txtSearch.Focus();
            PopularGV2();
            lblMessage.Text = $"O filme {titulo.ToUpper()} foi deletado com sucesso!!";

        }
    }
}