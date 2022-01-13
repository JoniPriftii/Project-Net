using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Diets
    {
        public string DietId { get; set; }
       
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "ClientName")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Suggested Weight")] 
        public int Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Display(Name = "Suggested Height")]
        public int Height { get; set; }

        public string ImageName { get; set; }

        [StringLength(500, ErrorMessage = "String must not be longer than 500" MinLength = "200")]
        public string Description { get; set; }
    }
}
