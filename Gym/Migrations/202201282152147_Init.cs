namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietPlans",
                c => new
                    {
                        DietPlanId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Category = c.String(nullable: false, maxLength: 70),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 500),
                        Description = c.String(maxLength: 2000),
                        DurationInDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietPlanId);
            
            CreateTable(
                "dbo.UserDietPlans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DietPlanId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.DietPlanId })
                .ForeignKey("dbo.DietPlans", t => t.DietPlanId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.DietPlanId);
            
            CreateTable(
                "dbo.ExercisePlans",
                c => new
                    {
                        ExercisePlanId = c.Int(nullable: false, identity: true),
                        ExercisePlanName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        DurationInDays = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sessions = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ExercisePlanId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        ExperienceDescription = c.String(nullable: false, maxLength: 2000),
                        ImageName = c.String(nullable: false, maxLength: 500),
                        ExercisePlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.ExercisePlans", t => t.ExercisePlanId, cascadeDelete: true)
                .Index(t => t.ExercisePlanId);
            
            CreateTable(
                "dbo.UserExercisePlans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ExercisePlanId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.ExercisePlanId })
                .ForeignKey("dbo.ExercisePlans", t => t.ExercisePlanId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ExercisePlanId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Category = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ApplicationUserProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Product_ProductId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserExercisePlans", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDietPlans", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ApplicationUserProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserExercisePlans", "ExercisePlanId", "dbo.ExercisePlans");
            DropForeignKey("dbo.Trainers", "ExercisePlanId", "dbo.ExercisePlans");
            DropForeignKey("dbo.UserDietPlans", "DietPlanId", "dbo.DietPlans");
            DropIndex("dbo.ApplicationUserProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.ApplicationUserProducts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserExercisePlans", new[] { "ExercisePlanId" });
            DropIndex("dbo.UserExercisePlans", new[] { "Id" });
            DropIndex("dbo.Trainers", new[] { "ExercisePlanId" });
            DropIndex("dbo.UserDietPlans", new[] { "DietPlanId" });
            DropIndex("dbo.UserDietPlans", new[] { "Id" });
            DropTable("dbo.ApplicationUserProducts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Products");
            DropTable("dbo.UserExercisePlans");
            DropTable("dbo.Trainers");
            DropTable("dbo.ExercisePlans");
            DropTable("dbo.UserDietPlans");
            DropTable("dbo.DietPlans");
        }
    }
}
