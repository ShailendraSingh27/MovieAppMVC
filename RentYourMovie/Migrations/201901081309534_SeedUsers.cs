namespace RentYourMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'618197e3-e976-4c11-a401-7bbbeea614e5', N'StoreManager', N'AFXfcjrcn83MaPoKxRrolZj6ZtDh4YuPnkaTcrRFW0BzCTbWQ6PehMa2iQMJdZBbRg==', N'ebb3b996-fa58-44f5-a120-711eb01a7dce', N'ApplicationUser')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'c76475e9-a43c-4943-b3e3-e4803edb6239', N'guestUser', N'AITspPLrroCWPjBgte5BVSPYyXIVzcEohtCJoaumbxfPYdSUrUJwQeAJF6aSBxjTCQ==', N'b9de0e13-bead-4866-be62-5863f543e9ee', N'ApplicationUser')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cbc74088-c0a3-4111-af84-f59e41423fe2', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'618197e3-e976-4c11-a401-7bbbeea614e5', N'cbc74088-c0a3-4111-af84-f59e41423fe2')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
