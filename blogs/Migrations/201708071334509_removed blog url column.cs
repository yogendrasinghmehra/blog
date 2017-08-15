namespace blogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedblogurlcolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "BlogExampleUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogExampleUrl", c => c.String());
        }
    }
}
