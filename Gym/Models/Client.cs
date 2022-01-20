using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Client
    {

        public int ClientId { get; set; }
        [Required(ErrorMessage = "Enter your First Name")]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your height")]
        [Display(Name = "Body Height")]
        [Range(100, 210)]
        public int Height { get; set; }
        [Required(ErrorMessage = "Enter your weight")]
        [Display(Name = "Body Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<ClientDietPlan> ClientDietPlan { get; set; }

        public virtual ICollection<ClientExercisePlan> ClientExercisePlan { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}