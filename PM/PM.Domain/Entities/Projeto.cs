using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.Domain.Entities
{
    [Table("projeto")]
    public class Projeto
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }

        [DataType(DataType.DateTime)]
        [Column("data_inicio")]
        public Nullable<DateTime> DataInicio { get; set; }

        [DataType(DataType.DateTime)]
        [Column("data_previsao_fim")]
        public Nullable<DateTime> DataPrevisaoFim { get; set; }

        [DataType(DataType.DateTime)]
        [Column("data_fim")]
        public Nullable<DateTime> DataFim { get; set; }

        [StringLength(5000, ErrorMessage = "O campo Descrição deve ter no máximo 5000 caracteres.")]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("orcamento")]
        public double? Orcamento { get; set; }

        [StringLength(45)]
        [Column("status")]
        public string Status { get; set; }

        [StringLength(45)]
        [Column("risco")]
        public string Risco { get; set; }

        [Required]
        [Column("idgerente")]
        public long IdGerente { get; set; }

        public virtual Pessoa Gerente { get; set; }

        public virtual IEnumerable<Pessoa> Membros { get; set; }
    }
}
