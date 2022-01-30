using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class UserDietPlanViewModel
    {
        public int DietPlanId { get; set; }

        
        public string Name { get; set; }

        public string Category { get; set; }
        public int Weight { get; set; }

        public int Height { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }

        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}