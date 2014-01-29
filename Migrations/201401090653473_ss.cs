namespace ConferenceDashborad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                        District = c.String(),
                        Contact = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AreaSettings",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        District = c.String(),
                        Area = c.String(),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.Delegates",
                c => new
                    {
                        DelgateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Cls = c.String(),
                        School = c.String(),
                        Address = c.String(),
                        AreaId = c.Int(nullable: false),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.DelgateId)
                .ForeignKey("dbo.AreaSettings", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Delegates", new[] { "AreaId" });
            DropForeignKey("dbo.Delegates", "AreaId", "dbo.AreaSettings");
            DropTable("dbo.Delegates");
            DropTable("dbo.AreaSettings");
            DropTable("dbo.UserProfile");
        }
    }
}
