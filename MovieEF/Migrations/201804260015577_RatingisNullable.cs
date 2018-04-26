namespace MovieEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingisNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
        }
    }
}
