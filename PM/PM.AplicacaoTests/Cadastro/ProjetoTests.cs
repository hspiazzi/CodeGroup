using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Domain.Dto;
using System;
using System.Linq;

namespace PM.Aplicacao.Cadastro.Tests
{
    [TestClass()]
    public class ProjetoTests
    {
        [TestMethod()]
        public void ListarTodos()
        {
            // Arranjo
            var projetos = new Aplicacao.Cadastro.Projeto().Listar(new ProjetoFiltroDto());

            // Assert
            Assert.IsTrue(projetos.Count > 0);
        }

        [TestMethod()]
        public void Listar_Projetos_Com_Filtro()
        {
            var filtro = new ProjetoFiltroDto();
            filtro.Status = "Encerrado";

            // Arranjo
            var projetos = new Aplicacao.Cadastro.Projeto().Listar(filtro);

            // Assert
            Assert.IsTrue(projetos.Count == 1);
        }

        [TestMethod()]
        public void Consultar_Projeto_Existente_Por_Id()
        {
            // Arranjo
            var projetos = new Aplicacao.Cadastro.Projeto().Consultar(1);

            // Assert
            Assert.IsNotNull(projetos);
        }

        [TestMethod()]
        public void Consultar_Projeto_Não_Existente_Por_Id()
        {
            // Arranjo
            var projetos = new Aplicacao.Cadastro.Projeto().Consultar(99999999);

            // Assert
            Assert.IsNull(projetos);
        }

        [TestMethod()]
        public void Inclusão_E_Exclusão_De_Projeto()
        {
            // Arranjo
            var projeto = new Aplicacao.Cadastro.Projeto();
            projeto.Nome = "Teste Inclusão de Projeto";
            projeto.DataInicio = DateTime.Now;
            projeto.DataPrevisaoFim = DateTime.Now.AddDays(30);
            projeto.Status = "Em Análise";
            projeto.IdGerente = 1;

            // Assert Inclusão
            projeto = projeto.Inserir();
            var resultado = projeto.Consultar(projeto.Id);
            Assert.IsNotNull(projeto);

            //Assert Exclusão
            Assert.IsTrue(projeto.Excluir() > 0);
            var resultado2 = projeto.Consultar(projeto.Id);
            Assert.IsNull(resultado2);
        }

        [TestMethod()]
        public void Atualização_De_Dados_Projeto()
        {
            var projeto = new Aplicacao.Cadastro.Projeto().Consultar(4);
            Assert.IsNotNull(projeto);

            string novoNome = "Atualização de Nome do Projeto " + DateTime.Now.ToString();
            projeto.Nome = novoNome;

            //Atualiza Dados:
            projeto = projeto.Atualizar();

            //Assert Exclusão
            var resultado = projeto.Consultar(projeto.Id);
            Assert.IsNotNull(projeto);
            Assert.IsTrue(projeto.Nome == novoNome);
        }

        [TestMethod()]
        public void Validar_Entidade_Projeto_Sucesso()
        {
            var projeto = new Aplicacao.Cadastro.Projeto();
            projeto.Nome = "Teste Inclusão de Projeto";
            projeto.DataInicio = DateTime.Now;
            projeto.DataPrevisaoFim = DateTime.Now.AddDays(30);
            projeto.Status = "Em Análise";
            projeto.IdGerente = 1;

            var resultado = projeto.Validar().Count();
            Assert.IsTrue(resultado == 0);
        }

        [TestMethod()]
        public void Validar_Entidade_Projeto_Com_Informação_Faltando()
        {
            var projeto = new Aplicacao.Cadastro.Projeto();
            var resultado = projeto.Validar().Count();
            Assert.IsTrue(resultado > 0);
        }
    }
}