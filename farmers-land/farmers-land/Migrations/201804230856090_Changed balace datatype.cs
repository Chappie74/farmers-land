namespace farmers_land.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedbalacedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Balance", c => c.Single(nullable: false));
        }
    }
}
