namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTitles",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.TitleId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTitles", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.EmployeeTitles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeTitles", new[] { "TitleId" });
            DropIndex("dbo.EmployeeTitles", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeTitles");
        }
    }
}
