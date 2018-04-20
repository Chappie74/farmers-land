namespace farmers_land.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedsomeextrafieldsrequiredforausertologin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Address");
        }
    }
}
