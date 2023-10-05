namespace PM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataNascimento = c.DateTime(),
                        CPF = c.String(maxLength: 14),
                        Funcionario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        nome = c.String(maxLength: 200),
                        DataInicio = c.DateTime(nullable: false),
                        DataPrevisaoFim = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Orcamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(maxLength: 45),
                        Risco = c.String(maxLength: 45),
                        IdGerente = c.Long(nullable: false),
                        Gerente_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Pessoa");
            DropIndex("dbo.Projeto", new[] { "Gerente_Id" });
            DropTable("dbo.Projeto");
            DropTable("dbo.Pessoa");
        }
    }
}
