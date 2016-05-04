using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NieGumex.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NieGumex.Contex
{
    public class ProduktyContext : IdentityDbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Facture> Facture { get; set; }
    }
}