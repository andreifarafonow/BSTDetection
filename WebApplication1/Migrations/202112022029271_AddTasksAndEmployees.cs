namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTasksAndEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgLink = c.String(),
                        InWork = c.Boolean(nullable: false),
                        Fullness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Cams = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(),
                        CompletedCams = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.Employees");
        }
    }
}
