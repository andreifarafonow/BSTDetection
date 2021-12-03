namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskEmployeeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "EmployeeId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "EmployeeId", c => c.Int(nullable: false));
        }
    }
}
