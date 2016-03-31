namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nazwa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Cena", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Cena", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
