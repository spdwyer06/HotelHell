namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropsForRoomAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "Available");
        }
    }
}
