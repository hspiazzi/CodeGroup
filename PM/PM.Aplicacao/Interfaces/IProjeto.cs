using PM.Domain.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM.Aplicacao.Cadastro
{
    public interface IProjeto
    {
        string GerenteNome { get; set; }

        Projeto Atualizar();
        Projeto Consultar(long id);
        int Excluir();
        Projeto Inserir();
        int InserirMembro(long idProjeto, long idMembro);
        List<Projeto> Listar(ProjetoFiltroDto filtro);
        void Salvar();
        List<ValidationResult> Validar();
    }
}