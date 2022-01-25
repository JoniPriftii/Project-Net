namespace Gym.Migrations
{
   using Gym.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gym.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gym.Models.ApplicationDbContext context)
        {
            /*
             //-----------------------DietPlan Seeds------------------------------

            IList<DietPlan> dietPlans = new List<DietPlan>()
            {
               new DietPlan
               {
                    DietPlanId=1, 
                    Name="Carbohydrates Diet Plan", 
                    Category="Loose Weight", 
                    Description="Carbs are the body’s main source of energy and should make up half of your daily calorie requirement. " +
                    "However, it’s important to choose the right type of carbs. Simple carbs, such as bread, biscuit, white rice and wheat flour, contain too much sugar and are bad for you."+
                    "Instead, opt for complex carbs that are high in fiber and packed with nutrients as compared to simple carbs.This is because Fiber - rich complex carbs are harder to digest, leaving you feeling full for longer, and are therefore the best option for weight control. "+
                    "Brown rice, millets such as ragi and oats are all good complex carb choices.",
                    DurationInDays= 30, 
                    Height=180, 
                    Weight=90, 
                   ImageName="CarbohydratesDietPlan"
               },
                new DietPlan
                {
                    DietPlanId=2,
                    Name="Proteins Diet Plan",
                    Category="Loose Weight",
                    Description="Most people fail to meet their daily protein requirement. This is troublesome, as proteins are essential to help the body build and repair tissue, muscles, cartilage and skin, as well as pump blood. "+
                    "Hence, a high protein diet can help you also lose weight, as it helps build muscle – which burns more calories than fat."+
                    "For instance, about 30% of your diet should consist of protein in the form of whole dals, paneer, chana, milk, leafy greens, eggs, white meat or sprouts. Having one helping of protein with every meal is essential.",
                    DurationInDays= 30,
                    Height=175,
                    Weight=95,
                    ImageName="ProteinsDietPlan"
                },
                new DietPlan
                {
                    DietPlanId=3,
                    Name="Proteins Diet Plan",
                    Category="Build Muscle",
                    Description="Most people fail to meet their daily protein requirement. This is troublesome, as proteins are essential to help the body build and repair tissue, muscles, cartilage and skin, as well as pump blood. "+
                    "Hence, a high protein diet can help you also lose weight, as it helps build muscle – which burns more calories than fat."+
                    "For instance, about 30% of your diet should consist of protein in the form of whole dals, paneer, chana, milk, leafy greens, eggs, white meat or sprouts. Having one helping of protein with every meal is essential.",
                    DurationInDays= 30,
                    Height=180,
                    Weight=90,
                    ImageName="ProteinBuildMuscle"
                },
                new DietPlan
                {
                    DietPlanId=4,
                    Name="Protein Supplements ",
                    Category="Gain Weight",
                    Description="Taking protein supplements is a common strategy for athletes and bodybuilders who want to gain weight. "+
                    "There are many types available, including whey, soy, egg, and pea protein. Whey protein supplements and mass gainers (supplements that can help you gain muscle mass) can be very easy and cost-effective strategies to gain weight, especially when combined with strength training."+
                    "Protein is made from dairy and has been shown to help improve health markers and reduce the risk of disease. Protein supplements may be even more important if you’re also training since your daily protein requirements increase."+
                    "Like meats and other animal products, whey protein contains all the essential amino acids required to stimulate muscle growth. You can use it before or after your workout and at any other point during the day."+
                    "The easiest way to add protein powder into your diet is with a protein smoothie, especially for breakfast.That gives you the rest of the day to add in nutritious meals and snacks to make sure you get a balanced nutrient intake."+
                    "Start your day off with a high energy breakfast. For even more protein, try adding in peanut butter, almond butter, flaxseeds, or chia seeds. Unflavored whey protein can be added to dishes such as soups, mashed potatoes, and oatmeal to increase protein content.",
                    DurationInDays= 30,
                    Height=183,
                    Weight=88,
                    ImageName="ProteinsDietPlan"
                },
                new DietPlan
                {
                    DietPlanId=5,
                    Name="Red meats",
                    Category="Build Muscle",
                    Description="Red meats are probably one of the best muscle-building foods available.For example, 6 ounces (170 grams) of steak contains around 5 grams of leucine."+
                    "Leucine is the key aminoacid your body needs to stimulate muscle protein synthesis and add new muscle tissue. It also contains 456 calories and nearly 49 grams of protein."+
                        "In addition to this, red meats are one of the best natural sources of dietary creatine, which is possibly the world’s best muscle-building supplement. Consider choosing fattier cuts, which provide more calories than leaner meats, helping you take in extra calories and add weight."+
                    "In one study, 100 older women added 6 ounces (170 grams) of red meat to their diets and performed resistance training 6 days a week for 6 weeks."+
                    "The women gained lean mass, had an 18 percent increase in strength, and had an increase in the important muscle - building hormone IGF - 1."+
                    "Both lean and fatty meats are a great source of protein, though fatty meat provides more calories, which can help you gain weight.One of the best - known fatty beef dishes is brisket. Brisket is known for being time-consuming to prepare, but it can be much easier if you own a slow cooker."+
                    "Start this brisket recipe in the morning and you’ll have a nutritious dinner waiting for you in the evening — approximately 300 calories per 3 - ounce(85 grams) serving.",
                    DurationInDays= 50,
                    Height=178,
                    Weight=96,
                    ImageName="RedMeat"
                },
                new DietPlan
                {
                    DietPlanId=6,
                    Name="Products to gain weight",
                    Category="Gain Weight",
                    Description="Gaining weight can be equally difficult as losing weight and is always a time-consuming process."+
                    "However, the following foods will help you gain weight fast and safe, and you will start seeing a positive result in the weight gain process:"+
                    "Milk"+
                    "Protein shakes"+
                    "Rice"+
                    "Red meat"+
                    "Nuts and nut butter" +
                    "Whole grain bread"+
                    "Other starches"+
                    "Protein supplements"+
                    "Salmon"+
                    "Dried fruits"+
                    "Cereal bars"+
                    "Fats and oil"+
                    "Cheese"+
                    "Yogurt"+
                    "Pasta",
                    DurationInDays= 35,
                    Height=178,
                    Weight=60,
                    ImageName="ProductsToGainWeight"
                },
            };
             context.DietPlans.AddRange(dietPlans);

            base.Seed(context);
            



               //-----------------------Exercise Seeds------------------------------


               IList<ExercisePlan> exercises = new List<ExercisePlan>()
               {
                   new ExercisePlan 
                   {
                       ExercisePlanId = 1 ,
                       ExercisePlanName = "Beginner Boxing" ,
                       Description = "For 13 years, professional boxing courses developed by professionals in the field of boxing, have developed the defensive and offensive skills of many trainers who have followed our course." +
                       "Discipline, courage and hard work, motivate and push strongly towards the goal of creating modern fighters in the ring as well as in everyday life." +
                       "This plan is perfect for beginners and for all enthusiasts of this field who have always wanted to develop their defensive ability and dexterity.",
                       DurationInDays = 90,
                       Price = 150,
                       ImageName = "ExerciseBox1",
                       Sessions = 3 
                   },
                   new ExercisePlan 
                   { 
                       ExercisePlanId = 2 , 
                       ExercisePlanName = "Advance Boxing" , 
                       Description = "For 13 years, professional boxing courses developed by professionals in the field of boxing, have developed the defensive and offensive skills of many trainers who have followed our course." +
                       "Discipline, courage and hard work, motivate and push strongly towards the goal of creating modern fighters in the ring as well as in everyday life." +
                       "This plan is perfect for beginners and for all enthusiasts of this field who have always wanted to develop their defensive ability and dexterity.",
                       DurationInDays = 120,
                       Price = 300,
                       ImageName = "ExerciseBox2",
                       Sessions = 5 
                   },
                    new ExercisePlan 
                    { 
                         ExercisePlanId = 3 , 
                         ExercisePlanName = "Regular Gym",
                         Description = "For 13 years, professional boxing courses developed by professionals in the field of boxing, have developed the defensive and offensive skills of many trainers who have followed our course." +
                         "Discipline, courage and hard work, motivate and push strongly towards the goal of creating modern fighters in the ring as well as in everyday life." +
                         "This plan is perfect for beginners and for all enthusiasts of this field who have always wanted to develop their defensive ability and dexterity.",                    DurationInDays = 30, 
                         Price = 30 , 
                         ImageName = "ExerciseGym", 
                         Sessions = 3 
                    },
                    new ExercisePlan 
                    {
                         ExercisePlanId = 4 ,
                         ExercisePlanName = "Yoga" ,
                         Description = "For 13 years, professional boxing courses developed by professionals in the field of boxing, have developed the defensive and offensive skills of many trainers who have followed our course." +
                         "Discipline, courage and hard work, motivate and push strongly towards the goal of creating modern fighters in the ring as well as in everyday life." +
                         "This plan is perfect for beginners and for all enthusiasts of this field who have always wanted to develop their defensive ability and dexterity.",                    DurationInDays = 30, 
                         Price = 20 , 
                         ImageName = "ExerciseYoga" , 
                         Sessions = 4
                    }

               };
               _ = context.ExercisePlans.AddRange(exercises);




    //-----------------------Trainer Seeds------------------------------


    IList<Trainer> trainer = new List<Trainer>()
    {
        new Trainer 
        {
            TrainerId = 1, 
            FirstName = "Leslie", 
            LastName="Smith", 
            ExperienceDescription ="I work in a musculoskeletal sports injury clinic and is also the first team sports therapist for Cambridge United Football Club. "+
            "I completed a BSc Sports Therapy degree at the University of Hertfordshire, graduating in 2019. During my degree, i completed an 11-month industry placement, where he developed the contacts and relationships that led to get my job. "+
            "I was offered the chance to work with Cambridge United FC’s first team.",
            ImageName ="trainer1",
            ExercisePlanId=1
        },
        new Trainer 
        { 
            TrainerId = 2, 
            FirstName = "Emily ", 
            LastName="Davies", 
            ExperienceDescription="I am graduated from Bournemouth University in 2020 as a sports therapist.My current job is as a part-time sports therapy lecturer at Bournemouth University, which I obtained through my lecturer shortly after my finishing my studies."+
            "I am the unit lead for one of the first year modules - Early careers professionalism. My degree was incredibly relevant to my current job as this is the subject that I teach. "+
            "The experiences I gained throughout my degree developed my knowledge and skillset within sports therapy, which I am now able to share with my students.",
            ImageName ="trainer3",
            ExercisePlanId=2
        },
        new Trainer 
        { 
            TrainerId = 3, 
            FirstName = "Kal", 
            LastName=" Ratcliffe", 
            ExperienceDescription="I studied for a BSc Nutritional Therapy at the University of West London, graduating in 2018.I am self-employed and have my own clinic/practice, which I set up shortly after graduating."+
            "My degree was vital as it provided me with the theoretical and practical knowledge of the science of nutrition. I have invested in developing both my clinical practice and myself by working with a business coach",
            ImageName ="Trainer2", 
            ExercisePlanId=3
        },
        new Trainer 
        { 
            TrainerId = 4, 
            FirstName = "Helena ", 
            LastName="Potter", 
            ExperienceDescription="I studied History with a year abroad at the University of Birmingham. Volunteering and part-time work are the main ways into coaching, and many coaches continue in this capacity alongside other employment."+
            "Getting involved with activities in your chosen sport at a regional level is advisable.",
            ImageName ="trainer5",
            ExercisePlanId=4
        },
    };
    _ = context.Trainers.AddRange(trainer);




    //------------------- Produktes Seeds ----------------------------


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

    context.Products.AddRange(products);*/















            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //IList<Trainier> trainers = new List<Trainier>();

            //trainers.Add(new Trainier() { FirstName = "Griselda", LastName = "Duka" });

            //context.Trainiers.AddRange(trainers);

            //context.Trainers.Add(new Trainer() { FirstName = "Griselda", LastName = "Duka", ExperienceDescription = "This is a test!", ImageName = "Ska" });

            //string[] roles = new string[] { "Admin" };

            //foreach (string role in roles)
            //{
            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}

            //foreach (string role in roles)
            //{
            //    var existingRole = context.Roles.FirstOrDefault(r => r.Name == role);
            //    if (existingRole == null)
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}

        }


    }
}
