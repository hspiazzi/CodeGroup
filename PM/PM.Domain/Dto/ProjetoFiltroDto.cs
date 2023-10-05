using System;

namespace PM.Domain.Dto
{
    public class ProjetoFiltroDto
    {
        public long? Id { get; set; }

        public string Nome { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataPrevisaoFim { get; set; }

        public DateTime? DataFim { get; set; }

        public string Descricao { get; set; }

        public decimal? Orcamento { get; set; }

        public string Status { get; set; }

        public string Risco { get; set; }

        public long? IdGerente { get; set; }
    }
}
