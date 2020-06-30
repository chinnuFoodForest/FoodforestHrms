namespace FoodForestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeetablecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "MiddleName", c => c.String()); 
        }
        
        public override void Down()
        { 
            DropColumn("dbo.Employee", "MiddleName");
        }
    }
}
