using Ext.Net;
using PM.Infra.Common.Extensions;
using System;
using System.Web.UI;

namespace PM.Presentation.Web.Modulos.Cadastro.Pessoa
{
    public partial class Cadastro : System.Web.UI.Page
    {
        const string controlePaiId = "tabPessoa";
        public string WindowId = "winCadPessoa";
        private string WindowTitle = "CADASTRO DE PESSOAS";
        private string WindowWidht = "480";
        private string WindowHeight = "300";
        private string WindowMaximizable = "true";
        private string WindowMinimizable = "false";
        private Ext.Net.Icon WindowIcon = Icon.ApplicationForm;
        private string WindowModal = "true";
        private string WindowNoCache = "true";
        private string WindowNoCenter = "true";
        private string WindowURL = "/Modulos/Cadastro/Pessoa/Cadastro";

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

                this.txtNome.Focus();
            }
        }

        private void CarregarDados(string id)
        {
            try
            {
                var pessoa = new Aplicacao.Cadastro.Pessoa().Consultar(long.Parse(id)); ;
                
                if (pessoa != null)
                {
                    this.txtId.Text = pessoa.Id.ToString();
                    this.txtNome.Text = pessoa.Nome;
                    this.comboFuncionario.SelectedItem.Value = pessoa.Funcionario.ToString();
                    this.txtCPF.Value = pessoa.CPF;
                    this.txtDataNascimento.Text = pessoa.DataNascimento.ToString();
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
                var pessoa = new Aplicacao.Cadastro.Pessoa();

                if (txtId.Text != "")
                    pessoa.Id = long.Parse(txtId.Text);

                pessoa.Nome = txtNome.Text;
                pessoa.Funcionario = bool.Parse(comboFuncionario.SelectedItem.Value);
                pessoa.CPF = this.txtCPF.Text;

                if (this.txtDataNascimento.Value.ToString().isDate() && DateTime.Parse(this.txtDataNascimento.Value.ToString()) > DateTime.Now.AddYears(-100))
                    pessoa.DataNascimento = DateTime.Parse(this.txtDataNascimento.Value.ToString());

                pessoa.Salvar();

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