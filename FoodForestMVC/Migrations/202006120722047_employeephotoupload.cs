namespace FoodForestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeephotoupload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ImagePath", c => c.String());
            AddColumn("dbo.EmployeeVM", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeVM", "ImagePath");
            DropColumn("dbo.Employee", "ImagePath");
        }
    }
}
