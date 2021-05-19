namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckOutProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "CheckInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservation", "CheckOutDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservation", "ReservationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "ReservationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservation", "CheckOutDate");
            DropColumn("dbo.Reservation", "CheckInDate");
        }
    }
}
