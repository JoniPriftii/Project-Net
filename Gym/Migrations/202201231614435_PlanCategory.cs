namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DietPlans", "Category", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DietPlans", "Category");
        }
    }
}
