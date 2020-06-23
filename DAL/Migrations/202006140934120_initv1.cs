namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauThus",
                c => new
                    {
                        maCauThu = c.Int(nullable: false, identity: true),
                        hoTen = c.String(),
                        diaChi = c.String(),
                        maDoiBong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.maCauThu)
                .ForeignKey("dbo.DoiBongs", t => t.maDoiBong, cascadeDelete: true)
                .Index(t => t.maDoiBong);
            
            CreateTable(
                "dbo.DoiBongs",
                c => new
                    {
                        maDoiBong = c.Int(nullable: false, identity: true),
                        tenDoiBong = c.String(),
                    })
                .PrimaryKey(t => t.maDoiBong);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CauThus", "maDoiBong", "dbo.DoiBongs");
            DropIndex("dbo.CauThus", new[] { "maDoiBong" });
            DropTable("dbo.DoiBongs");
            DropTable("dbo.CauThus");
        }
    }
}
