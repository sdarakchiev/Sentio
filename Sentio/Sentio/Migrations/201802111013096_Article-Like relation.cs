namespace Sentio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleLikerelation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Likes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Likes", "UserId");
            AddForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "UserId" });
            AlterColumn("dbo.Likes", "UserId", c => c.String());
        }
    }
}
