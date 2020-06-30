namespace FoodForestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeVM", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeVM", "FirstName", c => c.String());
        }
    }
}
