
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Products.Controllers
{
    public class ProductController : Controller
    {
        //Get: Products
        public ActionResult Index()
        {
            ViewBag.Product = "Gym Shop Product List Page";

            List<Products> IList = new List<Products>()

            {
               new Products {ID=1 , Name="Long Sleeve Shirt",Category="Clothes",Price=30.00$},
               new Products {ID=2, Name="Hoodie Sweater", Category="Clothes", Price=50.00$ },
                new Products {ID=3, Name="Unisex Fashion Hoodie ", Category="Clothes", Price=45.00$ },
                new Products {ID=4, Name="Protein Shaker", Category="Bottle", Price=15.00$ }
           };

            return View(IList);

        }

    }


}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Products.Controllers
{
    public class ProductController : Controller
    {
        //Get: Products
        public ActionResult Index()
        {
            ViewBag.Product = "Gym Shop Product List Page";

            List<Products> IList = new List<Products>()

            {
               new Products {ID=1 , Name="Long Sleeve Shirt",Category="Clothes",Price=30.00$},
               new Products {ID=2, Name="Hoodie Sweater", Category="Clothes", Price=50.00$ },
                new Products {ID=3, Name="Unisex Fashion Hoodie ", Category="Clothes", Price=45.00$ },
                new Products {ID=4, Name="Protein Shaker", Category="Bottle", Price=15.00$ }
           };

            return View(IList);

        }

    }


}

