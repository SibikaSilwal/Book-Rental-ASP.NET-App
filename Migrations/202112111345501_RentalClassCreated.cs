namespace Book_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalClassCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        book_Id = c.Int(nullable: false),
                        customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.customer_Id, cascadeDelete: true)
                .Index(t => t.book_Id)
                .Index(t => t.customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "book_Id", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "book_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
