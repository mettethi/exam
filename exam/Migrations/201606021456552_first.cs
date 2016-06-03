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
                "dbo.Statistics",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.StatisticId)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Helplists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.AssignmentID);
            
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
            DropForeignKey("dbo.Helplists", "UserID", "dbo.Users");
            DropForeignKey("dbo.Helplists", "AssignmentID", "dbo.Assignments");
            DropForeignKey("dbo.Statistics", "AssignmentId", "dbo.Assignments");
            DropIndex("dbo.Helplists", new[] { "AssignmentID" });
            DropIndex("dbo.Helplists", new[] { "UserID" });
            DropIndex("dbo.Statistics", new[] { "AssignmentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Helplists");
            DropTable("dbo.Statistics");
            DropTable("dbo.Assignments");
        }
    }
}
