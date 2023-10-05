using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.Domain.Entities
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nome")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Column("datanascimento")]
        public Nullable<DateTime> DataNascimento { get; set; }

        [StringLength(14)]
        [Column("cpf")]
        public string CPF { get; set; }

        [Column("funcionario")]
        public bool Funcionario { get; set; }
    }
}
