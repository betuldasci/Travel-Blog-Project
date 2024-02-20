namespace TravelBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullIsStatusDb4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "IsStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "IsStatus", c => c.Boolean());
        }
    }
}
