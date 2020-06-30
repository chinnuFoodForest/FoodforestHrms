namespace FoodForestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Dob", c => c.DateTime());
            AddColumn("dbo.Employee", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "ResignDate", c => c.DateTime());
            AddColumn("dbo.Employee", "Email", c => c.String());
            AddColumn("dbo.Employee", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Employee", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "EmployeeId", c => c.String());
        }
        
        public override void Down()
        { 
            DropColumn("dbo.Employee", "EmployeeId");
            DropColumn("dbo.Employee", "Status");
            DropColumn("dbo.Employee", "Phone");
            DropColumn("dbo.Employee", "Email");
            DropColumn("dbo.Employee", "ResignDate");
            DropColumn("dbo.Employee", "JoinDate");
            DropColumn("dbo.Employee", "Dob");
        }
    }
}
