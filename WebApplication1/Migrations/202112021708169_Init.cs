namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoordX = c.Double(nullable: false),
                        CoordY = c.Double(nullable: false),
                        Address = c.String(),
                        IsFull = c.Double(nullable: false),
                        ImgLink = c.String(),
                        InWork = c.Boolean(nullable: false),
                        Gun = c.Boolean(nullable: false),
                        Animal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cams");
        }
    }
}
