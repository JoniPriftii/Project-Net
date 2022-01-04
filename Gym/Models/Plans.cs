using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Plans
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public string Duration { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Sessions")]
        public int Sessions { get; set; }

    }
}