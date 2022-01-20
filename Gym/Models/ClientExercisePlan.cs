using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class ClientExercisePlan
    {
        [Key]
        [Column(Order = 1)]
        public int ClientId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlanId { get; set; }
        public bool IsActive { get; set; }
    }
}