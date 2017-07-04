namespace ProjetoLoja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "CEP", c => c.String(nullable: false));
            AddColumn("dbo.Pedidoes", "Endereco", c => c.String(nullable: false));
            AddColumn("dbo.Pedidoes", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "Bairro", c => c.String(nullable: false));
            AddColumn("dbo.Pedidoes", "Cidade", c => c.String(nullable: false));
            AddColumn("dbo.Pedidoes", "Estado", c => c.String(nullable: false));
            AddColumn("dbo.Pedidoes", "FormaPagamento", c => c.String(nullable: false));
            AlterColumn("dbo.Pedidoes", "Itens", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedidoes", "Itens", c => c.String());
            DropColumn("dbo.Pedidoes", "FormaPagamento");
            DropColumn("dbo.Pedidoes", "Estado");
            DropColumn("dbo.Pedidoes", "Cidade");
            DropColumn("dbo.Pedidoes", "Bairro");
            DropColumn("dbo.Pedidoes", "Numero");
            DropColumn("dbo.Pedidoes", "Endereco");
            DropColumn("dbo.Pedidoes", "CEP");
        }
    }
}
