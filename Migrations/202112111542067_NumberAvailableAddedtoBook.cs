namespace Book_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAvailableAddedtoBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("Update Books SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
