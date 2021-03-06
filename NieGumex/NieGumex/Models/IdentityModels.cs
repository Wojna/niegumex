﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace NieGumex.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string LastName { get; set; }

        //[Required]
        //public string Nazwa { get; set; }

        //[Required]
        //public string Miejscowosc { get; set; }

        //[Required]
        //public string Ulica { get; set; }

        //[Required]
        //public int nrDomu { get; set; }

        //[Required]
        //public string kodPocztowy { get; set; }

        //[Required]
        //public string NIP { get; set; }

        //[Required]
        //public string numerKonta { get; set; }

        //[Required]
        //public string GNL { get; set; }

        //[Required]
        //public string Wojewodztwo { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;

        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ProduktyContext", throwIfV1Schema: false)
        { 
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}