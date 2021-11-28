namespace Book_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustomerWithDOB : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES (10, Aashma Shrestha, False, 4, 5/20/1999)");
        }
        
        public override void Down()
        {
        }
    }
}
