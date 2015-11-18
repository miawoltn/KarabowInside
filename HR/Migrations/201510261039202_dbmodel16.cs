namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeJobs",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.JobId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Project = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Projects", t => t.Project, cascadeDelete: false)
                .Index(t => t.Project);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Project", "dbo.Projects");
            DropForeignKey("dbo.EmployeeJobs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeJobs", new[] { "JobId" });
            DropIndex("dbo.Jobs", new[] { "Project" });
            DropIndex("dbo.EmployeeJobs", new[] { "EmployeeId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.EmployeeJobs");
        }
    }
}
