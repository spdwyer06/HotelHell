namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToTestHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestHotel", "NumOfRoomsAvail", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestHotel", "NumOfRoomsAvail");
        }
    }
}
