using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Plan
    {
        
        public int PlanId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public string Duration { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Sessions")]
        public int Sessions { get; set; }



        public int? TrainierId { get; set; }
        public int? ClientId { get; set; }

        public virtual Trainier Trainier { get; set; }
        public ICollection<Client> Client { get; set; }
    }
}