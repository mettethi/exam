namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedStatistic : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Statistics", "AssignmentId");
            AddForeignKey("dbo.Statistics", "AssignmentId", "dbo.Assignments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "AssignmentId", "dbo.Assignments");
            DropIndex("dbo.Statistics", new[] { "AssignmentId" });
        }
    }
}
