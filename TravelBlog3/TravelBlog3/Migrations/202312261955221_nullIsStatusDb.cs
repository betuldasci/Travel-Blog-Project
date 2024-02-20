namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullIsStatusDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "IsStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "IsStatus", c => c.Boolean(nullable: false));
        }
    }
}
