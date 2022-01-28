namespace Gym.Migrations
{
    using Gym.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class TrainerSeed : DbMigration
    {
        public override void Up()
        {
            ApplicationDbContext context = new ApplicationDbContext();

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
            _ = context.SaveChanges();
        }

        public override void Down()
        {
        }
    }
}
