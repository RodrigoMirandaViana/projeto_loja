namespace ProjetoLoja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtobolas",
                c => new
                    {
                        ProdutobolaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponibilidade = c.Boolean(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutobolaID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtobolas", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Produtobolas", new[] { "CategoriaID" });
            DropTable("dbo.Produtobolas");
        }
    }
}
