using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Diet
    {
        public int DietId { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Suggested Weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Display(Name = "Suggested Height")]
        public int Height { get; set; }

        public string ImageName { get; set; }

        [StringLength(500, ErrorMessage = "String must not be longer than 500", MinimumLength = 200)]
        public string Description { get; set; }






        public ICollection<Client> Client { get; set; }
    }
}
