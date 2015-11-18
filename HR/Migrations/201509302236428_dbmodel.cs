namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BranchOffices",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        BranchAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OtherName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Passport = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        ResidentialAddress = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CompanyEmail = c.String(nullable: false),
                        CompanyPhoneNumber = c.String(nullable: false),
                        EmployementStatusId = c.Int(nullable: false),
                        EmployementTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.BranchOffices", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.EmployementStatus", t => t.EmployementStatusId, cascadeDelete: true)
                .ForeignKey("dbo.EmployementTypes", t => t.EmployementTypeId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.EmployementStatusId)
                .Index(t => t.EmployementTypeId);
            
            CreateTable(
                "dbo.EmployementStatus",
                c => new
                    {
                        EmployementStatusdId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.EmployementStatusdId);
            
            CreateTable(
                "dbo.EmployementTypes",
                c => new
                    {
                        EmploymentTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.EmploymentTypeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
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
                        ChildWorkspace_WorkspaceId = c.Int(),
                        InnerWorkspaces_WorkspaceId = c.Int(),
                        OuterWorkspace_WorkspaceId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkspaceId)
                .ForeignKey("dbo.Workspaces", t => t.ChildWorkspace_WorkspaceId)
                .ForeignKey("dbo.Workspaces", t => t.InnerWorkspaces_WorkspaceId)
                .ForeignKey("dbo.Workspaces", t => t.OuterWorkspace_WorkspaceId)
                .Index(t => t.ChildWorkspace_WorkspaceId)
                .Index(t => t.InnerWorkspaces_WorkspaceId)
                .Index(t => t.OuterWorkspace_WorkspaceId);
            
            CreateTable(
                "dbo.EmployeeRole",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.RoleId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeTitle",
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
            DropForeignKey("dbo.EmployeeWorkspace", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.EmployeeWorkspace", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Workspaces", "OuterWorkspace_WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.Workspaces", "InnerWorkspaces_WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.Workspaces", "ChildWorkspace_WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.EmployeeTitle", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.EmployeeTitle", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.EmployeeRole", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployementTypeId", "dbo.EmployementTypes");
            DropForeignKey("dbo.Employees", "EmployementStatusId", "dbo.EmployementStatus");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.BranchOffices");
            DropIndex("dbo.EmployeeWorkspace", new[] { "WorkspaceId" });
            DropIndex("dbo.EmployeeWorkspace", new[] { "EmployeeId" });
            DropIndex("dbo.Workspaces", new[] { "OuterWorkspace_WorkspaceId" });
            DropIndex("dbo.Workspaces", new[] { "InnerWorkspaces_WorkspaceId" });
            DropIndex("dbo.Workspaces", new[] { "ChildWorkspace_WorkspaceId" });
            DropIndex("dbo.EmployeeTitle", new[] { "TitleId" });
            DropIndex("dbo.EmployeeTitle", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeRole", new[] { "RoleId" });
            DropIndex("dbo.EmployeeRole", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "EmployementTypeId" });
            DropIndex("dbo.Employees", new[] { "EmployementStatusId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropTable("dbo.EmployeeWorkspace");
            DropTable("dbo.EmployeeTitle");
            DropTable("dbo.EmployeeRole");
            DropTable("dbo.Workspaces");
            DropTable("dbo.Titles");
            DropTable("dbo.Roles");
            DropTable("dbo.EmployementTypes");
            DropTable("dbo.EmployementStatus");
            DropTable("dbo.Employees");
            DropTable("dbo.BranchOffices");
        }
    }
}