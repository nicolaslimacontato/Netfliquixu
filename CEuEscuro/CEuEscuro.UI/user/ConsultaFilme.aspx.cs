using CEuEscuro.BLL;
using CEuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEuEscuro.UI.user
{

    public partial class ConsultaFilme : System.Web.UI.Page
    {
        FilmeBLL filmeBLL = new FilmeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGV2();
        }
        public void PopularGV2()
        {
            gv2.DataSource = filmeBLL.GetFilmAll();
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }

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
    }
}