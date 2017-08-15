namespace blogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddbtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        BlogTitle = c.String(),
                        BlogDescription = c.String(),
                        BlogExampleUrl = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "TagId", "dbo.Tags");
            DropIndex("dbo.Blogs", new[] { "TagId" });
            DropTable("dbo.users");
            DropTable("dbo.Tags");
            DropTable("dbo.Blogs");
        }
    }
}
