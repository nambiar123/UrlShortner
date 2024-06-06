namespace UrlShortner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongUrl = c.String(nullable: false, maxLength: 2048),
                        ShortUrl = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urls");
        }
    }
}
