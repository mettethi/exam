namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Helplists", "Assignment_ID", "dbo.Assignments");
            DropIndex("dbo.Helplists", new[] { "Assignment_ID" });
            RenameColumn(table: "dbo.Helplists", name: "Assignment_ID", newName: "AssignmentID");
            AlterColumn("dbo.Helplists", "AssignmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Helplists", "AssignmentID");
            AddForeignKey("dbo.Helplists", "AssignmentID", "dbo.Assignments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helplists", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.Helplists", new[] { "AssignmentID" });
            AlterColumn("dbo.Helplists", "AssignmentID", c => c.Int());
            RenameColumn(table: "dbo.Helplists", name: "AssignmentID", newName: "Assignment_ID");
            CreateIndex("dbo.Helplists", "Assignment_ID");
            AddForeignKey("dbo.Helplists", "Assignment_ID", "dbo.Assignments", "ID");
        }
    }
}
