﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class Clients
    {
        [Required(ErrorMessage ="Do not leave Client ID blank")]
        [Display(Name= "ID Number")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Do not leave name space blank")]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Do not leave surname space blank")]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter your height")]
        [Display(Name = "Body Height")]
        [Range(0, 210)]
        public int Height { get; set; }
        [Required(ErrorMessage = "Enter your weight")]
        [Display(Name = "Body Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Do not leave phone number blank")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }

    }
}