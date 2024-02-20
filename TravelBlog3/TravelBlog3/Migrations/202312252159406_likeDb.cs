namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likeDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "LikeCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "LikeCount");
        }
    }
}
