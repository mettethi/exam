namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Helplists", "User_ID", "dbo.Users");
            DropIndex("dbo.Helplists", new[] { "User_ID" });
            RenameColumn(table: "dbo.Helplists", name: "User_ID", newName: "UserID");
            AlterColumn("dbo.Helplists", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Helplists", "UserID");
            AddForeignKey("dbo.Helplists", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helplists", "UserID", "dbo.Users");
            DropIndex("dbo.Helplists", new[] { "UserID" });
            AlterColumn("dbo.Helplists", "UserID", c => c.Int());
            RenameColumn(table: "dbo.Helplists", name: "UserID", newName: "User_ID");
            CreateIndex("dbo.Helplists", "User_ID");
            AddForeignKey("dbo.Helplists", "User_ID", "dbo.Users", "ID");
        }
    }
}
