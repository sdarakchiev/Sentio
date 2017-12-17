namespace Sentio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articlemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Author");
        }
    }
}
