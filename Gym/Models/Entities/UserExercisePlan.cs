using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class UserExercisePlan
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ExercisePlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}