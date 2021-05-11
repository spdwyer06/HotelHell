namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "BuildingNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Hotel", "StreetAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotel", "StreetAddress");
            DropColumn("dbo.Hotel", "BuildingNumber");
        }
    }
}
