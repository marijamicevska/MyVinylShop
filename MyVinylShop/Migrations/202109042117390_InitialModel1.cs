namespace MyVinylShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Vinyls",
                c => new
                    {
                        VinylId = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        VinylName = c.String(),
                        VinylPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Release = c.String(),
                        Description = c.String(),
                        VinylURL = c.String(),
                    })
                .PrimaryKey(t => t.VinylId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.YearId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vinyls", "YearId", "dbo.Years");
            DropForeignKey("dbo.Vinyls", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Vinyls", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Vinyls", new[] { "GenreId" });
            DropIndex("dbo.Vinyls", new[] { "YearId" });
            DropIndex("dbo.Vinyls", new[] { "ArtistId" });
            DropTable("dbo.Years");
            DropTable("dbo.Genres");
            DropTable("dbo.Vinyls");
            DropTable("dbo.Artists");
        }
    }
}
