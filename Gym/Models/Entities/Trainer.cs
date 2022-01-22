using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Experience description is required")]
        [Display(Name = "Experience Description")]
        [StringLength(1000, ErrorMessage = "String must not be longer than 1000", MinimumLength = 200)]
        public string ExperienceDescription { get; set; }

        [Required(ErrorMessage = "Image Name is required")]
        [Display(Name = "Image Name")]
        [MaxLength(500)]
        public string ImageName { get; set; }

        public int? ExercisePlanId { get; set; }

        public virtual ExercisePlan ExercisePlan { get; set; }
    }
}