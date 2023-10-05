using System;
using System.Linq;
using System.Web.Services;

namespace PM.Service.WebServices
{
    /// <summary>
    /// Summary description for ProjetoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ProjetoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public PMResponse AdicionarMembroProjeto(long idProjeto, long idMembro)
        {
            try
            {
                var pessoa = Aplicacao.Cadastro.Pessoa.Consultar(idMembro);
                var projeto = Aplicacao.Cadastro.Projeto.Consultar(idProjeto);

                if (pessoa == null)
                    return new PMResponse { Codigo = 410, Sucesso = false, Mensagem = String.Format($"O Membro informado ({0}) não foi encontrado.", idMembro ) };

                if (pessoa.Funcionario == false)
                    return new PMResponse { Codigo = 411, Sucesso = false, Mensagem = String.Format($"O Membro informado ({0}) não pode ser adicionado ao projeto pois não é funcionário.", idMembro) };

                if (projeto == null)
                    return new PMResponse { Codigo = 412, Sucesso = false, Mensagem = String.Format($"O Projeto informado ({0}) não foi encontrado.", idProjeto) };

                if (projeto.Membros.ToList().Exists(m => m.Id == pessoa.Id))
                    return new PMResponse { Codigo = 413, Sucesso = false, Mensagem = "O Membro informado foi vinculado ao projeto. Operação cancelada." };

                projeto.InserirMembro(idProjeto, idMembro);
                return new PMResponse { Codigo = 200, Sucesso = false, Mensagem = String.Format($"Novo membro ({0} - {1}) adicionado com sucesso ao projeto:({3} - {4})", 
                    pessoa.Id.ToString(), pessoa.Nome, projeto.Id, projeto.Nome ) };
            }
            catch (Exception ex)
            {
                return new PMResponse { Codigo = 500, Sucesso = false, Mensagem = ex.Message };
            }
        }
    }

    [Serializable]
    public struct PMResponse
    {
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set;}
    }
}
