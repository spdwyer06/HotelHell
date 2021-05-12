namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZipBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotel", "ZipCode");
        }
    }
}
