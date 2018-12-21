namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) VALUES (1,'Horror')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (2,'Animated')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (4,'Action')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (5,'Drama')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (6,'Fantasy')");
           
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
