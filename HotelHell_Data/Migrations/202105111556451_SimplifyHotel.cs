namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyHotel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hotel", "BuildingNumber");
            DropColumn("dbo.Hotel", "StreetAddress");
            DropColumn("dbo.Hotel", "City");
            DropColumn("dbo.Hotel", "State");
            DropColumn("dbo.Hotel", "ZipCode");
            DropColumn("dbo.Hotel", "CreatedAt");
            DropColumn("dbo.Hotel", "ModifiedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotel", "ModifiedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Hotel", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Hotel", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Hotel", "State", c => c.String(nullable: false));
            AddColumn("dbo.Hotel", "City", c => c.String(nullable: false));
            AddColumn("dbo.Hotel", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.Hotel", "BuildingNumber", c => c.Int(nullable: false));
        }
    }
}
