namespace BookingAppStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDBExample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "discount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "discount");
        }
    }
}
