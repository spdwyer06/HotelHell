namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorHotelVacancyLogic : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hotel", "NumOfRoomsAvail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotel", "NumOfRoomsAvail", c => c.Int(nullable: false));
        }
    }
}
