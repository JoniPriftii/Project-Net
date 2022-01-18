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
        [Required(ErrorMessage = "Please fill the required fields")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill the required fields")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please fill the required fields")]
        [Display(Name = "Duration")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Please fill the required fields")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please fill the required fields")]
        [Display(Name = "Sessions")]
        public int Sessions { get; set; }

        public  virtual Trainier Trainier { get; set; }

        public ICollection<Client> Client { get; set; }
    }
}