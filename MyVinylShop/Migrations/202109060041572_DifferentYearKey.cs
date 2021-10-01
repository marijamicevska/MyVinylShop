namespace MyVinylShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DifferentYearKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vinyls", "YearId", "dbo.Years");
            DropIndex("dbo.Vinyls", new[] { "YearId" });
            DropPrimaryKey("dbo.Years");
            AddColumn("dbo.Vinyls", "Year_YearName", c => c.Int());
            AlterColumn("dbo.Years", "YearId", c => c.Int(nullable: false));
            AlterColumn("dbo.Years", "YearName", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Years", "YearName");
            CreateIndex("dbo.Vinyls", "Year_YearName");
            AddForeignKey("dbo.Vinyls", "Year_YearName", "dbo.Years", "YearName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vinyls", "Year_YearName", "dbo.Years");
            DropIndex("dbo.Vinyls", new[] { "Year_YearName" });
            DropPrimaryKey("dbo.Years");
            AlterColumn("dbo.Years", "YearName", c => c.Int(nullable: false));
            AlterColumn("dbo.Years", "YearId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Vinyls", "Year_YearName");
            AddPrimaryKey("dbo.Years", "YearId");
            CreateIndex("dbo.Vinyls", "YearId");
            AddForeignKey("dbo.Vinyls", "YearId", "dbo.Years", "YearId", cascadeDelete: true);
        }
    }
}
