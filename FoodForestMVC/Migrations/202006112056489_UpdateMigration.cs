namespace FoodForestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeVM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeVM");
        }
    }
}
