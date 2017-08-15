namespace blogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddbtablescolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "BlogExampleUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "TagName", c => c.String());
            AlterColumn("dbo.Blogs", "BlogExampleUrl", c => c.String());
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String());
        }
    }
}
