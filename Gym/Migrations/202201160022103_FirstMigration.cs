namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        DietId = c.Int(),
                        PlanId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .ForeignKey("dbo.Plans", t => t.PlanId)
                .Index(t => t.DietId)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImageName = c.String(),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.DietId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Duration = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sessions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.Trainiers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Experience = c.String(),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Product_ID = c.Int(nullable: false),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Client_ClientId })
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductClients", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.ProductClients", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Trainiers", "Id", "dbo.Plans");
            DropForeignKey("dbo.Clients", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.Clients", "DietId", "dbo.Diets");
            DropIndex("dbo.ProductClients", new[] { "Client_ClientId" });
            DropIndex("dbo.ProductClients", new[] { "Product_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Trainiers", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "PlanId" });
            DropIndex("dbo.Clients", new[] { "DietId" });
            DropTable("dbo.ProductClients");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Trainiers");
            DropTable("dbo.Plans");
            DropTable("dbo.Diets");
            DropTable("dbo.Clients");
        }
    }
}
