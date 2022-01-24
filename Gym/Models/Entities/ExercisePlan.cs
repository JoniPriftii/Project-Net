using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class ExercisePlan
    {
        [ForeignKey("Trainer")]
        public int ExercisePlanId { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string ExercisePlanName { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "String must not be longer than 500", MinimumLength = 30)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [Display(Name = "Duration in days")]
        public int DurationInDays { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [Display(Name = "Sessions")]
        public int Sessions { get; set; }

        [Required(ErrorMessage = "Please fill out the required field")]
        [Display(Name = "Image Name")]
        [MaxLength(500)]
        public string ImageName { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<UserExercisePlan> UserExercisePlan { get; set; }
    }
}