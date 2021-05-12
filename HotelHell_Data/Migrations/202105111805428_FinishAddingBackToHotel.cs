namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishAddingBackToHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Hotel", "ModifiedAt", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotel", "ModifiedAt");
            DropColumn("dbo.Hotel", "CreatedAt");
        }
    }
}
