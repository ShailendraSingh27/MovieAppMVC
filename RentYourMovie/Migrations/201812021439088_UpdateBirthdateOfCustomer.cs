namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdateOfCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='1/05/2018' WHERE Id=3");
            Sql("UPDATE Customers SET BirthDate='9/08/2013' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
