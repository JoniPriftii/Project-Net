using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Trainier
    {

        public int TrainierId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Image Name is required")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        public int? ExercisePlanId { get; set; }

        public virtual ExercisePlan ExercisePlan { get; set; }
    }
}