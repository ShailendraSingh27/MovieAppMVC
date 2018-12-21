namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Conjuring',1,'2017-12-17',   '2018-5-18',18)");
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Wall.E',2,'2017-12-22','2018-2-5',38)");
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Friends',3,'2008-10-12','2010-5-15',8)");
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Avengers',4,'2011-1-15','2013-4-16',5)");
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Girl Next Door',5,'2012-9-9','2014-12-05',25)");
            Sql("INSERT INTO Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Avatar',6,'2015-6-27','2016-7-27',3)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Movies");
        }
    }
}
