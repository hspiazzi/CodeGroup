using PM.Domain.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM.Aplicacao.Cadastro
{
    public interface IPessoa
    {
        Pessoa Atualizar();
        Pessoa Consultar(long id);
        int Excluir();
        Pessoa Inserir();
        List<Pessoa> Listar(PessoaFiltroDto filtro);
        void Salvar();
        List<ValidationResult> Validar();
    }
}