namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeAddCoord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CoordX", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "CoordY", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "CoordY");
            DropColumn("dbo.Employees", "CoordX");
        }
    }
}
