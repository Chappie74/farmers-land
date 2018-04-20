namespace farmers_land.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "age");
        }
    }
}
