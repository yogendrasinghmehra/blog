namespace blogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedblogmodelcolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "BlogExampleUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogExampleUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "BlogDescription", c => c.String());
        }
    }
}
