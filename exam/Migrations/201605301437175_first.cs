namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Helplists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Helped = c.Boolean(nullable: false),
                        Assignment_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assignments", t => t.Assignment_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Assignment_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helplists", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Helplists", "Assignment_ID", "dbo.Assignments");
            DropIndex("dbo.Helplists", new[] { "User_ID" });
            DropIndex("dbo.Helplists", new[] { "Assignment_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Helplists");
            DropTable("dbo.Assignments");
        }
    }
}
