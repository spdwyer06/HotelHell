namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreToHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "City", c => c.String(nullable: false));
            AddColumn("dbo.Hotel", "State", c => c.String(nullable: false));
            AddColumn("dbo.Hotel", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotel", "ZipCode");
            DropColumn("dbo.Hotel", "State");
            DropColumn("dbo.Hotel", "City");
        }
    }
}
