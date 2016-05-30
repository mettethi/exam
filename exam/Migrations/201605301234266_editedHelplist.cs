namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedHelplist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helplists", "Helped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Helplists", "Assignment_ID", c => c.Int());
            AddColumn("dbo.Helplists", "User_ID", c => c.Int());
            CreateIndex("dbo.Helplists", "Assignment_ID");
            CreateIndex("dbo.Helplists", "User_ID");
            AddForeignKey("dbo.Helplists", "Assignment_ID", "dbo.Assignments", "ID");
            AddForeignKey("dbo.Helplists", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helplists", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Helplists", "Assignment_ID", "dbo.Assignments");
            DropIndex("dbo.Helplists", new[] { "User_ID" });
            DropIndex("dbo.Helplists", new[] { "Assignment_ID" });
            DropColumn("dbo.Helplists", "User_ID");
            DropColumn("dbo.Helplists", "Assignment_ID");
            DropColumn("dbo.Helplists", "Helped");
        }
    }
}
