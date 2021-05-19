namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationDateProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "ReservationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "ReservationDate");
        }
    }
}
