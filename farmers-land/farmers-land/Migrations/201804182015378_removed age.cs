namespace farmers_land.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "age", c => c.Int(nullable: false));
        }
    }
}
