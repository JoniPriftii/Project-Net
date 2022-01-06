
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Products.Models;
{ 
public class Products


{
    [Display(Name="Id")]
    public int ID { get; set; }

    [Display(Name = "Name")]
    public string Name { get; set; }

    [Display(Name = "Category")]
    public string Category { get; set; }

    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [Display(Name = "ImageName")]
    public string ImageName { get; set;}
}
}

