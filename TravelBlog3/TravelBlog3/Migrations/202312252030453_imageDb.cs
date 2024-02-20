namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ImageUrl");
        }
    }
}
