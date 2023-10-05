using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Service.WebServicesTests.ProjetoWSServiceReference;

namespace PM.Service.WebServices.Tests
{
    [TestClass()]
    public class ProjetoWSTests
    {
        //[TestMethod()]
        //public void Adicionar_Membro_Ao_Projeto_Sucesso()
        //{
        //    var client = new ProjetoWSSoapClient();

        //    var resultado = client.AdicionarMembroProjeto(1,1);

        //    Assert.IsTrue(resultado.Sucesso);
        //}

        [TestMethod()]
        public void Adicionar_Membro_Inexistente_Ao_Projeto()
        {
            var client = new ProjetoWSSoapClient();

            var resultado = client.AdicionarMembroProjeto(1, 99999999);

            Assert.IsFalse(resultado.Sucesso);
            Assert.IsTrue(resultado.Codigo == 410);
        }

        [TestMethod()]
        public void Adicionar_Membro_A_Projeto_Inexistente()
        {
            var client = new ProjetoWSSoapClient();

            var resultado = client.AdicionarMembroProjeto(999999999, 1);

            Assert.IsFalse(resultado.Sucesso);
            Assert.IsTrue(resultado.Codigo == 412);
        }

        [TestMethod()]
        public void Adicionar_Membro_Duplicado_A_Projeto()
        {
            var client = new ProjetoWSSoapClient();

            var resultado = client.AdicionarMembroProjeto(1, 1);

            Assert.IsFalse(resultado.Sucesso);
            Assert.IsTrue(resultado.Codigo == 413);
        }

        [TestMethod()]
        public void Adicionar_Membro_Que_Nao_E_Funcionario()
        {
            var client = new ProjetoWSSoapClient();

            var resultado = client.AdicionarMembroProjeto(1, 3);

            Assert.IsFalse(resultado.Sucesso);
            Assert.IsTrue(resultado.Codigo == 411);
        }
    }
}