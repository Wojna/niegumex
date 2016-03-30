﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NieGumex.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50,MinimumLength =4)]
        public string Nazwa { get; set; }

        [Required]
        public decimal Cena { get; set; }

        [Required]
        [Display(Name ="Liczba Kompletów")]
        public int LiczbaKompletow { get; set; }
    }
}