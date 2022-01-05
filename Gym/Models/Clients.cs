using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Clients
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Range(0, 210)]
        public int Height { get; set; }
        public int Weight { get; set; }
        [Required]
        public int Phone { get; set; }

    }
}