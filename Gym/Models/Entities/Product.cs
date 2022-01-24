
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Gym.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        [MaxLength(50)]
        public string Category { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image Name is required")]
        [Display(Name = "Image Name")]
        [MaxLength(500)]
        public string ImageName { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}

