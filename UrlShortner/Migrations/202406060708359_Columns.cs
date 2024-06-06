namespace UrlShortner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urls", "Clicks", c => c.Int(nullable: false));
            AddColumn("dbo.Urls", "IPAddress", c => c.String(maxLength: 255));
            AddColumn("dbo.Urls", "UserAgent", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urls", "UserAgent");
            DropColumn("dbo.Urls", "IPAddress");
            DropColumn("dbo.Urls", "Clicks");
        }
    }
}
