using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Trainier
    {
   
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name ="Surname")]
        public string Surname { get; set; }

        [Display(Name ="Experience")]
        public string Experience { get; set; }
        

    }
}