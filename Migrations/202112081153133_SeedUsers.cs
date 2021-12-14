namespace Book_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'199cfc8d-d310-45e1-9c1e-4830674dd770', N'admin@book.com', 0, N'AFn1GAHx5mwx/MoaM5i9DCqk262qu7HpV6WLvoaH8OBP0GD2bBE8g5Lxn9+aXCGdrA==', N'57fc3c79-49c9-44f6-acb7-2f98cc1ec9ec', NULL, 0, 0, NULL, 1, 0, N'admin@book.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'66d6b058-7797-40c4-bddd-04329c23ae5a', N'guest@book.com', 0, N'ABang23dSBuP1zV9kWiDUveHJUZjQWnccy1hVPd38i8nvdPQE/dDXL8IWl5ghuftGw==', N'8420b7d5-81c4-4247-b07a-902475026c1c', NULL, 0, 0, NULL, 1, 0, N'guest@book.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f2b8aa0a-90c3-470f-a372-aabf6422b26c', N'ssilwal2@ramapo.edu', 0, N'ALfng4DZ1RZxL7fSJil9bZlyKVKreE9D2FcCE4ASwmVHjwydJFmAiyfODzJ0FTYO4w==', N'99439720-9cdc-4a87-bc55-bfc42f5e3d11', NULL, 0, 0, NULL, 1, 0, N'ssilwal2@ramapo.edu')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9e41c60d-93db-49b7-936d-13a2aebc53c6', N'CanManageBooks')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'199cfc8d-d310-45e1-9c1e-4830674dd770', N'9e41c60d-93db-49b7-936d-13a2aebc53c6')
");
        }
        
        public override void Down()
        {
        }
    }
}
