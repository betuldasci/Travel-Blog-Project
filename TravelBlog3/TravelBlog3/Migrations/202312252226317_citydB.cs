namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citydB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CityId", c => c.Int());
            CreateIndex("dbo.Blogs", "CityId");
            AddForeignKey("dbo.Blogs", "CityId", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CityId", "dbo.Cities");
            DropIndex("dbo.Blogs", new[] { "CityId" });
            DropColumn("dbo.Blogs", "CityId");
        }
    }
}
