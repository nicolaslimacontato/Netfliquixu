using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEuEscuro.UI.adm
{
    public partial class DefaultAdm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblSession.Text = $"Seja bem vindo {Session["Usuario"].ToString().ToUpper()} sua sessão inicia às {DateTime.Now.ToString("t")}";

            //Response.AppendHeader("Refresh",String.Concat((Session.Timeout*10),";URL=../Login.aspx"));
        }

        //logout
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}