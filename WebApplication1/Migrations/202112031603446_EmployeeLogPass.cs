namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeLogPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Login", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Login");
        }
    }
}
