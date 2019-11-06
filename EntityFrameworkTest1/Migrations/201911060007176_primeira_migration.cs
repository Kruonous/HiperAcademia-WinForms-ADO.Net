namespace EntityFrameworkTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Vivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedidoDeVendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacao = c.String(),
                        cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.cliente_Id)
                .Index(t => t.cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDeVendas", "cliente_Id", "dbo.Clientes");
            DropIndex("dbo.PedidoDeVendas", new[] { "cliente_Id" });
            DropTable("dbo.PedidoDeVendas");
            DropTable("dbo.Clientes");
        }
    }
}
