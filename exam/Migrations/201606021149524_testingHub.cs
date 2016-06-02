namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingHub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.StatisticId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Statistics");
        }
    }
}
