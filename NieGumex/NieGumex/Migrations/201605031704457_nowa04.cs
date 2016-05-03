namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factures", "numerKonta", c => c.String(nullable: false));
            AddColumn("dbo.Factures", "Wojewodztwo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factures", "Wojewodztwo");
            DropColumn("dbo.Factures", "numerKonta");
        }
    }
}
