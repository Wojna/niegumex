using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NieGumex.ViewModels
{
    public class ProductsVm
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Nazwa { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        [Display(Name = "Liczba Dostepnych Kompletów")]
        public int LiczbaKompletow { get; set; }

        public bool WantIt { get; set; }
    }
}