namespace NieGumex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja704 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        FactureID = c.Int(nullable: false, identity: true),
                        FactureName = c.String(nullable: false, maxLength: 50),
                        DataWystawienia = c.DateTime(nullable: false),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Nazwa = c.String(nullable: false),
                        Miejscowosc = c.String(nullable: false),
                        Ulica = c.String(nullable: false),
                        NumerDomu = c.String(nullable: false),
                        KodPocztowy = c.String(nullable: false),
                        Nip = c.String(nullable: false),
                        Produkt = c.String(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaNetto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CenaBrutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StawkaVat = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FactureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Factures");
        }
    }
}
