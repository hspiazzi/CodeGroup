using PM.Domain.Model;
using System.Data.Entity;

namespace PM.Repository
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext() : base("name=LocalDbContext")
        {
            // Configure o nome da conexão da cadeia de conexão, você pode personalizá-lo.
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure o mapeamento das entidades aqui, se necessário.
            base.OnModelCreating(modelBuilder);
        }
    }
}
