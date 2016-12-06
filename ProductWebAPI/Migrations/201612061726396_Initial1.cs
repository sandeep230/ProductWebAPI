namespace ProductWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Review", "Username");
        }
    }
}
