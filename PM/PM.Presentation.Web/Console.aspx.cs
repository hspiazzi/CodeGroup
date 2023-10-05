using Ext.Net;
using System;

namespace PM.Presentation.Web
{
    public partial class Console : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                Modulos.Home.Home.Show(this.tabPrincipal);
            }
        }

        protected void Projetos_Click(object sender, DirectEventArgs e)
        {
            Modulos.Cadastro.Projeto.Listar.Show(this.tabPrincipal);
        }

        protected void Pessoas_Click(object sender, DirectEventArgs e)
        {
            Modulos.Cadastro.Pessoa.Listar.Show(this.tabPrincipal);
        }
    }
}