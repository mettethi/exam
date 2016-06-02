namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helplists", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Helplists", "Time");
        }
    }
}
