namespace EntityFrameworkTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacao_coluna_Valido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PedidoDeVendas", "Valido", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoDeVendas", "Valido");
        }
    }
}
