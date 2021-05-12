namespace HotelHell_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Reservation", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Reservation", new[] { "CustomerId" });
            DropIndex("dbo.Reservation", new[] { "RoomId" });
            DropTable("dbo.Reservation");
        }
    }
}
