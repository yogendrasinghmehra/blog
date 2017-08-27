namespace blogs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlikemodelnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.likes_detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpAddress = c.String(nullable: false),
                        BlogId = c.Int(nullable: false),
                        LikeStatus = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.likes_detail", "BlogId", "dbo.Blogs");
            DropIndex("dbo.likes_detail", new[] { "BlogId" });
            DropTable("dbo.likes_detail");
        }
    }
}
