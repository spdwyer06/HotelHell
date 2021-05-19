namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavoriteOptionToHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "IsFavorite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotel", "IsFavorite");
        }
    }
}
