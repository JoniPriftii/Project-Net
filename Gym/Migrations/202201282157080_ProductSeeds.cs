namespace Gym.Migrations
{
    using Gym.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class ProductSeeds : DbMigration
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public override void Up()
        {
            IList<Product> products = new List<Product>()
            {
                new Product
                {
                    ProductId=2 ,
                    Name="Gym Shirt",
                    Category="Clothes" ,
                    Price=25,
                    ImageName="gymshirt",

                },
                new Product
                {
                    ProductId=3 ,
                    Name="Gym Hoodie",
                    Category="Clothes" ,
                    Price=15,
                    ImageName="gymhoodie"
                },
                new Product
                {
                    ProductId=4 ,
                    Name="Pure Whey Protein",
                    Category="Suplements" ,
                    Price=85,
                    ImageName="gymprotein"
                },


    };

            context.Products.AddRange(products);
            context.SaveChanges();


        }

        public override void Down()
        {
        }
    }
}
