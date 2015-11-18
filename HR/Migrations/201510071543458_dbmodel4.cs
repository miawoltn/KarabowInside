namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardId = c.Int(nullable: false, identity: true),
                        AwardName = c.String(nullable: false),
                        AwardDescription = c.String(),
                        AwardPrestige = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AwardId);
            
            CreateTable(
                "dbo.EmployeeAward",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        AwardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.AwardId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Awards", t => t.AwardId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.AwardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAward", "AwardId", "dbo.Awards");
            DropForeignKey("dbo.EmployeeAward", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeAward", new[] { "AwardId" });
            DropIndex("dbo.EmployeeAward", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeAward");
            DropTable("dbo.Awards");
        }
    }
}
