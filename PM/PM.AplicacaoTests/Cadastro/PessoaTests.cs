using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Domain.Dto;
using System;

namespace PM.Aplicacao.Cadastro.Tests
{
    [TestClass()]
    public class PessoaTests
    {
        [TestMethod()]
        public void Listar_Todos()
        {
            // Arranjo
            var pessoas = new Aplicacao.Cadastro.Pessoa().Listar(new PessoaFiltroDto());

            // Assert
            Assert.IsTrue(pessoas.Count > 0);
        }

        [TestMethod()]
        public void Listar_Pessoas_Com_Filtro_Funcionario()
        {
            // Arranjo
            var pessoas = new Aplicacao.Cadastro.Pessoa().Listar(new PessoaFiltroDto { Funcionario = true });

            // Assert
            Assert.IsTrue(pessoas.Exists(f => f.Funcionario == true));
        }

        [TestMethod()]
        public void Consultar_Pessoa_Existente_Por_Id()
        {
            // Arranjo
            var pessoa = new Aplicacao.Cadastro.Pessoa().Consultar(1);

            // Assert
            Assert.IsTrue(pessoa != null);
            Assert.IsTrue(pessoa.Id == 1);
        }

        [TestMethod()]
        public void Consultar_Pessoa_Não_Existente_Por_Id()
        {
            // Arranjo
            var pessoa = new Aplicacao.Cadastro.Pessoa().Consultar(999999);

            // Assert
            Assert.IsTrue(pessoa == null);
        }

        [TestMethod()]
        public void Inclusão_E_Exclusão_De_Pessoa()
        {
            // Arranjo
            var pessoa = new Aplicacao.Cadastro.Pessoa();
            pessoa.Nome = "Teste Inclusão de Funcionário";
            pessoa.CPF = "12345678900";
            pessoa.DataNascimento = DateTime.Now.AddYears(-18);
            pessoa.Funcionario = true;

            // Assert Inclusão
            pessoa = pessoa.Inserir();
            var resultado = pessoa.Consultar(pessoa.Id);
            Assert.IsNotNull(pessoa);

            //Assert Exclusão
            Assert.IsTrue(pessoa.Excluir() > 0);
            var resultado2 = pessoa.Consultar(pessoa.Id);
            Assert.IsNull(resultado2);
        }

        [TestMethod()]
        public void Atualização_De_Dados_Pessoa()
        {
            var pessoa = new Aplicacao.Cadastro.Pessoa().Consultar(1);
            Assert.IsNotNull(pessoa);
            
            string novoNome = "Atualização de Nome " + DateTime.Now.ToString();
            pessoa.Nome = novoNome;
            
            //Atualiza Dados:
            pessoa = pessoa.Atualizar();

            //Assert Exclusão
            var resultado = pessoa.Consultar(pessoa.Id);
            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.Nome == novoNome);
        }
    }
}