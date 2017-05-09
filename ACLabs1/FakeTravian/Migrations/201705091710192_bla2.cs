namespace FakeTravian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cities", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Cities", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        BuildingTypeId = c.Int(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingId)
                .ForeignKey("dbo.BuildingTypes", t => t.BuildingTypeId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.BuildingTypeId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.BuildingTypes",
                c => new
                    {
                        BuildingTypeId = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BuildingTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buildings", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Buildings", "BuildingTypeId", "dbo.BuildingTypes");
            DropIndex("dbo.Buildings", new[] { "CityId" });
            DropIndex("dbo.Buildings", new[] { "BuildingTypeId" });
            DropTable("dbo.BuildingTypes");
            DropTable("dbo.Buildings");
            RenameIndex(table: "dbo.Cities", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Cities", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
