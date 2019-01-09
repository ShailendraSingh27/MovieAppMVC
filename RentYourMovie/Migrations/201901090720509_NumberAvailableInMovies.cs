namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAvailableInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET NumberInStock = NumberAvailable");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
