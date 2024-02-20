namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogCities", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogCities", "CityId", "dbo.Cities");
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.BlogCities", "BlogId", "dbo.Blogs", "Id");
            AddForeignKey("dbo.BlogCities", "CityId", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogCities", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BlogCities", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropColumn("dbo.Users", "RoleId");
            AddForeignKey("dbo.BlogCities", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogCities", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
    }
}
