namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel6 : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Workspaces",
                c => new
                {
                    WorkspaceId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    About = c.String(),
                    CoverPicture1 = c.String(),
                    CoverPictures2 = c.String(),
                    CoverPicture3 = c.String(),
                    CoverPicture4 = c.String(),
                    Email = c.String(),
                    ProfilePicture = c.String(),
                    Website = c.String(),
                })
                .PrimaryKey(t => t.WorkspaceId);

            CreateTable(
               "dbo.EmployeeWorkspace",
               c => new
               {
                   EmployeeId = c.Int(nullable: false),
                   WorkspaceId = c.Int(nullable: false),
               })
               .PrimaryKey(t => new { t.EmployeeId, t.WorkspaceId })
               .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
               .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
               .Index(t => t.EmployeeId)
               .Index(t => t.WorkspaceId);
        }
        
        public override void Down()
        {
        }
    }
}
