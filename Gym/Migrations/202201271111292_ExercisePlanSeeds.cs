namespace Gym.Migrations
{
    using Gym.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class ExercisePlanSeeds : DbMigration
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public override void Up()
        {
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
            context.SaveChanges();
        }

        public override void Down()
        {
        }
    }
}