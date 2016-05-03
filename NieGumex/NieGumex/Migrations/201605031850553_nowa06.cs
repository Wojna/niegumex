namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factures", "EAN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factures", "EAN");
        }
    }
}
