using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NieGumex.Models
{
    public class Facture
    {
        [Key]
        public int FactureID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string FactureName { get; set; }

        [Required]
        public DateTime DataWystawienia { get; set; }

        [Required]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        public string Miejscowosc { get; set; }

        [Required]
        public string Ulica { get; set; }

        [Required]
        public string NumerDomu { get; set; }

        [Required]
        public string KodPocztowy { get; set; }

        [Required]
        public string Nip { get; set; }

        [Required]
        public string Produkt { get; set; }

        [Required]
        public int Ilosc { get; set; }

        [Required]
        public decimal CenaNetto { get; set; }

        [Required]
        public decimal CenaBrutto { get; set; }

        [Required]
        public string StawkaVat { get; set; }
    }
}