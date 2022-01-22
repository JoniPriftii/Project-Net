using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class DietPlan
    {
        public int DietPlanId { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Suggested Weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Display(Name = "Suggested Height")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Image Name is required")]
        [Display(Name = "Image Name")]
        [MaxLength(500)]
        public string ImageName { get; set; }

        [StringLength(1000, ErrorMessage = "String must not be longer than 1000", MinimumLength = 200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration in days is required")]
        [Display(Name = "Duration in days")]
        public int DurationInDays { get; set; }

        public virtual ICollection<ClientDietPlan> ClientDietPlans { get; set; }
    }
}
