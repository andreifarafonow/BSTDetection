namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TasksRedesign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CamId", c => c.Int(nullable: false));
            DropColumn("dbo.Tasks", "Cams");
            DropColumn("dbo.Tasks", "CompletedCams");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "CompletedCams", c => c.String());
            AddColumn("dbo.Tasks", "Cams", c => c.String());
            DropColumn("dbo.Tasks", "CamId");
        }
    }
}
