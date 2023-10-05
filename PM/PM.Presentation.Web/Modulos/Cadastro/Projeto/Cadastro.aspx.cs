using Ext.Net;
using PM.Infra.Common.Extensions;
using System;
using System.Web.UI;

namespace PM.Presentation.Web.Modulos.Cadastro.Projeto
{
    public partial class Cadastro : System.Web.UI.Page
    {
        const string controlePaiId = "tabProjeto";
        public string WindowId = "winCadProjeto";
        private string WindowTitle = "CADASTRO DE PROJETOS";
        private string WindowWidht = "600";
        private string WindowHeight = "480";
        private string WindowMaximizable = "true";
        private string WindowMinimizable = "false";
        private Ext.Net.Icon WindowIcon = Icon.ApplicationForm;
        private string WindowModal = "true";
        private string WindowNoCache = "true";
        private string WindowNoCenter = "true";
        private string WindowURL = "/Modulos/Cadastro/Projeto/Cadastro";

        public void Show(Page page, string id)
        {
            if (!String.IsNullOrEmpty(id))
                WindowURL = WindowURL + "?id=" + id;


            string _script = @" parent.Ext.net.ResourceMgr.destroyCmp('" + WindowId + @"');
                                parent.Ext.create('Ext.window.Window', {
                                id: '" + WindowId + @"',
                                title: '" + WindowTitle + @"',
                                iconCls:'" + WindowIcon.ToString() + @"',
                                width: " + WindowWidht + @",
                                height: " + WindowHeight + @",
                                maximizable:" + WindowMaximizable + @",
                                minimizable:" + WindowMinimizable + @",
                                resizable: 'false',
                                modal: " + WindowModal + @",
                                nocache: " + WindowNoCache + @",
                                center: " + WindowNoCenter + @",
                                closeAction: 'destroy',
                                loader:{
                                        loadMask:{showMask:true},
                                        renderer:'frame',
                                        url:'" + WindowURL + @"'
                                    }
                                }).show();";

            Ext.Net.X.AddScript(_script);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (!Ext.Net.X.IsAjaxRequest)
            {
                if (!String.IsNullOrEmpty(id))
                {
                    // Form Editar
                    CarregarDados(id);
                }
                else
                {
                    // Form Inclusão
                    CarregarGerentes(0);
                }

                this.txtNome.Focus();
            }
        }

        private void CarregarGerentes(long idGerente)
        {
            try
            {
                var pessoa = new Aplicacao.Cadastro.Pessoa();
                var lista = pessoa.Listar(new Domain.Dto.PessoaFiltroDto { Funcionario = true });

                // Popula controle:
                this.comboGerente.GetStore().DataSource = lista;
                this.comboGerente.DataBind();

                // Atribui item selecionado:
                if (idGerente > 0)
                {
                    this.comboGerente.SelectedItems.Clear();
                    this.comboGerente.SelectedItems.Add(new ListItem { Value = idGerente.ToString() });
                    this.comboGerente.UpdateSelectedItems();
                }
            }
            catch (Exception ex)
            {
                Ext.Net.X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Erro",
                    Message = "Ocorreu um erro no sistema."
                });
            }
        }

        private void CarregarDados(string id)
        {
            try
            {
                var projeto = new Aplicacao.Cadastro.Projeto().Consultar(long.Parse(id));
                if (projeto != null)
                {
                    this.txtId.Text = projeto.Id.ToString();
                    this.txtNome.Text = projeto.Nome;
                    this.comboRisco.SelectedItem.Value  = projeto.Risco;
                    this.comboStatus.SelectedItem.Value = projeto.Status;
                    this.txtOrcamento.Value = projeto.Orcamento;

                    this.txtDataInicio.Text = projeto.DataInicio.ToString();
                    this.txtDataPrevisaoFim.Text = projeto.DataPrevisaoFim.ToString();
                    this.txtDataFim.Text = projeto.DataFim.ToString();

                    this.comboGerente.SelectedItem.Value = projeto.IdGerente.ToString();
                    this.txtDescricao.Text = projeto.Descricao;

                    //Carregar Gerentes
                    CarregarGerentes(projeto.IdGerente);
                }
            }
            catch (Exception ex)
            {
                Ext.Net.X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Erro",
                    Message = "Ocorreu um erro no sistema."
                });
            }

        }

        protected void btnOK_Click(object sender, DirectEventArgs e)
        {
            this.Salvar();
        }

        private void Salvar()
        {
            try
            {
                var projeto = new Aplicacao.Cadastro.Projeto();

                if (txtId.Text != "")
                    projeto.Id = long.Parse(txtId.Text);

                projeto.Nome = txtNome.Text;
                projeto.Risco = comboRisco.SelectedItem.Value.ToString();
                projeto.Status = comboStatus.SelectedItem.Value.ToString();
                projeto.Orcamento = long.Parse(txtOrcamento.Value.ToString());
                
                if(this.txtDataInicio.Value.ToString().isDate() && DateTime.Parse(this.txtDataInicio.Value.ToString()) > DateTime.Now.AddYears(-100))
                    projeto.DataInicio = DateTime.Parse(this.txtDataInicio.Value.ToString());
                
                if(this.txtDataPrevisaoFim.Value.ToString().isDate() && DateTime.Parse(this.txtDataPrevisaoFim.Value.ToString()) > DateTime.Now.AddYears(-100))
                    projeto.DataPrevisaoFim = DateTime.Parse(this.txtDataPrevisaoFim.Value.ToString());
                
                if(txtDataFim.Value.ToString().isDate() && DateTime.Parse(this.txtDataFim.Value.ToString()) > DateTime.Now.AddYears(-100))
                    projeto.DataFim = DateTime.Parse(this.txtDataFim.Value.ToString());

                if(comboGerente.SelectedItem != null)
                    projeto.IdGerente = long.Parse(comboGerente.SelectedItem.Value.ToString());

                projeto.Descricao = txtDescricao.Text;

                projeto.Salvar();

                // Mensagem de sucesso:
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Successo",
                    Message = "Dados gravados com sucesso!",
                    Handler = String.Format(@"parent.parent.Ext.net.ResourceMgr.getCmp('{0}').getBody().atualizarLista();
                                              parent.parent.Ext.net.ResourceMgr.getCmp('{1}').destroy();",
                                              controlePaiId, WindowId)
                });
            }
            catch (Exception ex)
            {
                Ext.Net.X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Erro",
                    Message = "Ocorreu um erro no sistema."
                });
            }

        }
    }
}