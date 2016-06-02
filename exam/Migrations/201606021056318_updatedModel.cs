namespace exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Helplists", "Helped");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Helplists", "Helped", c => c.Boolean(nullable: false));
        }
    }
}
