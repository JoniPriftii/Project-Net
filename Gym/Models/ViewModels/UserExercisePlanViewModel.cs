using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class UserExercisePlanViewModel
    {
        public int ExercisePlanId { get; set; }
        
        public string ExercisePlanName { get; set; }
       
        public string Description { get; set; }
        public int DurationInDays { get; set; }
        
        public decimal Price { get; set; }
        public int Sessions { get; set; }

        public string ImageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}