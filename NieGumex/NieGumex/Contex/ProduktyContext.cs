using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NieGumex.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using NieGumex.Migrations;

namespace NieGumex.Contex
{
    public class ProduktyContext : IdentityDbContext
    {
        public ProduktyContext()
            : base("ProduktyContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProduktyContext, Configuration>());
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Facture> Facture { get; set; }
    }
}