using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class UserInformationViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<UserDietPlanViewModel> UserDiets { get; set; }
        public IList<ExercisePlanViewModel> UserExercises { get; set; }

    }
}