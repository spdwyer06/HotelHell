namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestHotel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room", "TestHotel_Id", "dbo.TestHotel");
            DropIndex("dbo.Room", new[] { "TestHotel_Id" });
            DropColumn("dbo.Room", "TestHotel_Id");
            DropTable("dbo.TestHotel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestHotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumOfRoomsAvail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Room", "TestHotel_Id", c => c.Int());
            CreateIndex("dbo.Room", "TestHotel_Id");
            AddForeignKey("dbo.Room", "TestHotel_Id", "dbo.TestHotel", "Id");
        }
    }
}
