namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                UPDATE Movies
                SET NumberInStock = 3, NumberAvailable = 3
                WHERE NumberInStock=0;    
            ");
        }
        
        public override void Down()
        {
        }
    }
}
