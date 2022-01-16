using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Client
    {

        public int ClientId { get; set; }
        [Required(ErrorMessage = "Do not leave name space blank")]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Do not leave surname space blank")]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter your height")]
        [Display(Name = "Body Height")]
        [Range(100, 210)]
        public int Height { get; set; }
        [Required(ErrorMessage = "Enter your weight")]
        [Display(Name = "Body Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Do not leave phone number blank")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }




        public int? DietId { get; set; }
        public int? PlanId { get; set; }
        public int? ProductId { get; set; }


        public virtual Diet Diet { get; set; }

        public virtual Plan Plan { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}