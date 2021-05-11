namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveZipFromHotel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hotel", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotel", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
