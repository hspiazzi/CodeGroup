﻿using Ext.Net;
using PM.Domain.Dto;
using System;

namespace PM.Presentation.Web.Modulos.Cadastro.Projeto
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                CarregaLista();
            }
        }
        protected void Data_Refresh(object sender, StoreReadDataEventArgs e)
        {
            CarregaLista();
        }

        [DirectMethod()]
        public void Atualizar()
        {
            CarregaLista();
        }

        protected void CarregaLista()
        {
            try
            {
                //Monta Filtro de Consulta:
                ProjetoFiltroDto filtro = new ProjetoFiltroDto();

                //Consulta Banco de Dados:
                var lista = new Aplicacao.Cadastro.Projeto().Listar(filtro);

                //Preeenche lista:
                this.gridProjeto.GetStore().DataSource = lista;
                this.gridProjeto.GetStore().DataBind();
                this.gridProjeto.Refresh();
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

        protected void btnAtualizar_Click(object sender, DirectEventArgs e)
        {
            CarregaLista();
        }

        protected void btnExcluir_Click(object sender, DirectEventArgs e)
        {
            try
            {
                var strId = e.ExtraParams["Id"];

                if (String.IsNullOrEmpty(strId) == false)
                {
                    var id = Int64.Parse(strId);

                    var projeto = new Aplicacao.Cadastro.Projeto().Consultar(id);
                    if (projeto != null)
                    {
                        if (projeto.Excluir() > 0)
                            CarregaLista();
                    }
                }
                else
                {
                    Ext.Net.X.Msg.Show(new MessageBoxConfig
                    {
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO,
                        Title = "Alerta",
                        Message = "Selecione um registro para excluir."
                    });
                }
             }
            catch (Exception ex)
            {
                Ext.Net.X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Erro",
                    Message = ex.Message
                });
            }
        }

        protected void btnNovo_Click(object sender, DirectEventArgs e)
        {
            Modulos.Cadastro.Projeto.Cadastro win = new Cadastro();
            win.Show(this.Page, "");
        }

        protected void btnEditar_Click(object sender, DirectEventArgs e)
        {
            var strId = e.ExtraParams["Id"];

            if (String.IsNullOrEmpty(strId) == false)
                EditarRegistro(strId);
            else
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Atenção!",
                    Message = "Selecione um registro para Editar."
                });
        }

        protected void gridRow_DblClick(object sender, DirectEventArgs e)
        {
            var strId = e.ExtraParams["Id"];

            if (String.IsNullOrEmpty(strId) == false)
                EditarRegistro(strId);
            else
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Atenção!",
                    Message = "Selecione um registro para Editar."
                });
        }

        protected void gridRow_ContextMenu(object sender, DirectEventArgs e)
        {
            var strId = e.ExtraParams["Id"];

            if (String.IsNullOrEmpty(strId) == false)
                EditarRegistro(strId);
            else
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Atenção!",
                    Message = "Selecione um registro para Editar."
                });
        }

        private void EditarRegistro(string id)
        {
            Modulos.Cadastro.Projeto.Cadastro win = new Cadastro();
            win.Show(this.Page, id);
        }

        public static void Show(TabPanel tab)
        {
            Ext.Net.Panel p = new Ext.Net.Panel();
            p.ID = "tabProjeto";
            p.Title = "&nbsp; Projetos";
            p.Icon = Icon.Bricks;
            p.Closable = true;
            p.IDMode = IDMode.Explicit;
            p.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            p.CloseAction = CloseAction.Destroy;
            p.Loader = new ComponentLoader
            {
                AutoLoad = true,
                LoadMask = { ShowMask = true },
                Mode = LoadMode.Frame,
                ShowWarningOnFailure = true,
                Url = Ext.Net.X.ResourceManager.ResolveClientUrl("~/Modulos/Cadastro/Projeto/Listar")
            };
            p.Render(tab);
            tab.SetActiveTab(p);
        }
    } 
} 