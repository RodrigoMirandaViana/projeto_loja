namespace ProjetoLoja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        Itens = c.String(),
                    })
                .PrimaryKey(t => t.PedidoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedidoes");
        }
    }
}
