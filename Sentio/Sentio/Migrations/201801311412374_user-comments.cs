namespace Sentio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usercomments : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserEvents", newName: "EventApplicationUsers");
            DropPrimaryKey("dbo.EventApplicationUsers");
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.EventApplicationUsers", new[] { "Event_Id", "ApplicationUser_Id" });
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropPrimaryKey("dbo.EventApplicationUsers");
            AlterColumn("dbo.Comments", "UserId", c => c.String());
            AddPrimaryKey("dbo.EventApplicationUsers", new[] { "ApplicationUser_Id", "Event_Id" });
            RenameTable(name: "dbo.EventApplicationUsers", newName: "ApplicationUserEvents");
        }
    }
}
