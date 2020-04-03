using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS6.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        [Required]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0, Double.MaxValue, ErrorMessage = "Cena musi być dodatnia")]
        public decimal price { get; set; }
    }
}
