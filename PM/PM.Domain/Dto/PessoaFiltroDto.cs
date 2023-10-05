namespace PM.Domain.Dto
{
    public class PessoaFiltroDto
    {
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public bool? Funcionario { get; set; }
    }
}
