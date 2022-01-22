namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientDietPlans",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        DietPlanId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.DietPlanId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DietPlans", t => t.DietPlanId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.DietPlanId);
            
            CreateTable(
                "dbo.ClientExercisePlans",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        ExercisePlanId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.ExercisePlanId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ExercisePlans", t => t.ExercisePlanId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ExercisePlanId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClientId);
            
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
                "dbo.DietPlans",
                c => new
                    {
                        DietPlanId = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 500),
                        Description = c.String(maxLength: 1000),
                        DurationInDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietPlanId);
            
            CreateTable(
                "dbo.ExercisePlans",
                c => new
                    {
                        ExercisePlanId = c.Int(nullable: false),
                        ExercisePlanName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        DurationInDays = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sessions = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ExercisePlanId)
                .ForeignKey("dbo.Trainers", t => t.ExercisePlanId)
                .Index(t => t.ExercisePlanId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        ExperienceDescription = c.String(nullable: false, maxLength: 1000),
                        ImageName = c.String(nullable: false, maxLength: 500),
                        ExercisePlanId = c.Int(),
                    })
                .PrimaryKey(t => t.TrainerId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.ProductClients",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Client_ClientId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ExercisePlans", "ExercisePlanId", "dbo.Trainers");
            DropForeignKey("dbo.ClientExercisePlans", "ExercisePlanId", "dbo.ExercisePlans");
            DropForeignKey("dbo.ClientDietPlans", "DietPlanId", "dbo.DietPlans");
            DropForeignKey("dbo.ProductClients", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.ProductClients", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ClientExercisePlans", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientDietPlans", "ClientId", "dbo.Clients");
            DropIndex("dbo.ProductClients", new[] { "Client_ClientId" });
            DropIndex("dbo.ProductClients", new[] { "Product_ProductId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ExercisePlans", new[] { "ExercisePlanId" });
            DropIndex("dbo.ClientExercisePlans", new[] { "ExercisePlanId" });
            DropIndex("dbo.ClientExercisePlans", new[] { "ClientId" });
            DropIndex("dbo.ClientDietPlans", new[] { "DietPlanId" });
            DropIndex("dbo.ClientDietPlans", new[] { "ClientId" });
            DropTable("dbo.ProductClients");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trainers");
            DropTable("dbo.ExercisePlans");
            DropTable("dbo.DietPlans");
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientExercisePlans");
            DropTable("dbo.ClientDietPlans");
        }
    }
}
