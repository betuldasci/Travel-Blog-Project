namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citydB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "ImageUrl");
        }
    }
}
