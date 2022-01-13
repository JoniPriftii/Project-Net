using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Diets
    {
        [Display(Name = "DietId")]
        public string DietId { get; set; }
       
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "ClientName")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Weight")] 
        public int Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Display(Name = "Height")]
        public int Height { get; set; }
    }
}