using PM.Domain.Dto;
using PM.Domain.Entities;
using System.Data;

namespace PM.Infra.Dao
{
    public interface IProjetoDao
    {
        DataSet Alterar(Projeto projeto);
        DataSet Consultar(long id);
        int Excluir(long id);
        DataSet Inserir(Projeto projeto);
        int InserirMembro(long idProjeto, long idMembro);
        DataSet Listar(ProjetoFiltroDto filtro);
    }
}