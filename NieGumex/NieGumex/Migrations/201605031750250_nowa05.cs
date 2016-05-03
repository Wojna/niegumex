namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factures", "DataPlatnosci", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "EAN", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "FotoOpona", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "FotoOpona", c => c.String());
            DropColumn("dbo.Products", "EAN");
            DropColumn("dbo.Factures", "DataPlatnosci");
        }
    }
}
