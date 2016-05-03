namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FotoOpona", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FotoOpona");
        }
    }
}
