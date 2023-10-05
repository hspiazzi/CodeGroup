using PM.Domain.Dto;
using PM.Domain.Entities;
using System.Data;

namespace PM.Infra.Dao
{
    public interface IPessoaDao
    {
        DataSet Alterar(Pessoa pessoa);
        DataSet Consultar(long id);
        int Excluir(long id);
        DataSet Inserir(Pessoa pessoa);
        DataSet Listar(PessoaFiltroDto filtro);
    }
}