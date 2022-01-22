using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class ClientDietPlan
    {
        [Key]
        [Column(Order = 1)]
        public int ClientId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int DietPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}