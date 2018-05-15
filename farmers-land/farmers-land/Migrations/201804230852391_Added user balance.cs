namespace farmers_land.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeduserbalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Balance", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Balance");
        }
    }
}
