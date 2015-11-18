namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel5 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.EmployeeAward", newName: "Awards");
            //RenameTable(name: "dbo.EmployeeRole", newName: "Roles");
            //RenameTable(name: "dbo.EmployeeTitle", newName: "Titles");
            //RenameTable(name: "dbo.EmployeeWorkspace", newName: "Workspaces");
            //DropForeignKey("dbo.EmployeeAward", "EmployeeId", "dbo.Employees");
            //DropForeignKey("dbo.EmployeeAward", "AwardId", "dbo.Awards");
            //DropForeignKey("dbo.EmployeeRole", "EmployeeId", "dbo.Employees");
            //DropForeignKey("dbo.EmployeeRole", "RoleId", "dbo.Roles");
            //DropForeignKey("dbo.EmployeeTitle", "EmployeeId", "dbo.Employees");
            //DropForeignKey("dbo.EmployeeTitle", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Workspaces", "ChildWorkspace_WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.Workspaces", "InnerWorkspaces_WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.Workspaces", "OuterWorkspace_WorkspaceId", "dbo.Workspaces");
            //DropForeignKey("dbo.EmployeeWorkspace", "EmployeeId", "dbo.Employees");
            //DropForeignKey("dbo.EmployeeWorkspace", "WorkspaceId", "dbo.Workspaces");
            //DropIndex("dbo.EmployeeAward", new[] { "EmployeeId" });
            //DropIndex("dbo.EmployeeAward", new[] { "AwardId" });
            //DropIndex("dbo.EmployeeRole", new[] { "EmployeeId" });
            //DropIndex("dbo.EmployeeRole", new[] { "RoleId" });
            //DropIndex("dbo.EmployeeTitle", new[] { "EmployeeId" });
            //DropIndex("dbo.EmployeeTitle", new[] { "TitleId" });
            DropIndex("dbo.Workspaces", new[] { "ChildWorkspace_WorkspaceId" });
            DropIndex("dbo.Workspaces", new[] { "InnerWorkspaces_WorkspaceId" });
            DropIndex("dbo.Workspaces", new[] { "OuterWorkspace_WorkspaceId" });
            //DropIndex("dbo.EmployeeWorkspace", new[] { "EmployeeId" });
            //DropIndex("dbo.EmployeeWorkspace", new[] { "WorkspaceId" });
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        CertificateName = c.String(nullable: false),
                        CertificateDescription = c.String(),
                        CertificatePrestige = c.String(),
                    })
                .PrimaryKey(t => t.CertificateId);
            
            CreateTable(
                "dbo.EmployeeAwards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AwardId = c.Int(nullable: false),                        
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Awards", t => t.AwardId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.AwardId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeCertificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CertificateId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        About = c.String(),
                        CoverPicture1 = c.String(),
                        CoverPicture2 = c.String(),
                        CoverPicture3 = c.String(),
                        CoverPicture4 = c.String(),
                        Head = c.Int(nullable: false),
                        ProfilePicture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Employees", t => t.Head, cascadeDelete: false)
                .Index(t => t.Head);
            
            //AddColumn("dbo.Awards", "Employee_EmployeeId", c => c.Int());
            //AddColumn("dbo.Roles", "Employee_EmployeeId", c => c.Int());
            //AddColumn("dbo.Titles", "Employee_EmployeeId", c => c.Int());
            //AddColumn("dbo.Workspaces", "Employee_EmployeeId", c => c.Int());
            //AddColumn("dbo.EmployeeAwards", "Id", c => c.Int(nullable: false, identity: true));
            //DropPrimaryKey("dbo.EmployeeAward");
            //AddPrimaryKey("dbo.EmployeeAwards", "Id");
            //CreateIndex("dbo.Awards", "Employee_EmployeeId");
            //CreateIndex("dbo.Roles", "Employee_EmployeeId");
            //CreateIndex("dbo.Titles", "Employee_EmployeeId");
            //CreateIndex("dbo.Workspaces", "Employee_EmployeeId");
            //AddForeignKey("dbo.Awards", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            //AddForeignKey("dbo.Roles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            //AddForeignKey("dbo.Titles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            //AddForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Workspaces", "ChildWorkspace_WorkspaceId");
            DropColumn("dbo.Workspaces", "InnerWorkspaces_WorkspaceId");
            DropColumn("dbo.Workspaces", "OuterWorkspace_WorkspaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workspaces", "OuterWorkspace_WorkspaceId", c => c.Int());
            AddColumn("dbo.Workspaces", "InnerWorkspaces_WorkspaceId", c => c.Int());
            AddColumn("dbo.Workspaces", "ChildWorkspace_WorkspaceId", c => c.Int());
            DropForeignKey("dbo.EmployeeGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Head", "dbo.Employees");
            DropForeignKey("dbo.EmployeeGroups", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCertificates", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCertificates", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.EmployeeAwards", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Titles", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Roles", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Awards", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeAwards", "AwardId", "dbo.Awards");
            DropIndex("dbo.EmployeeGroups", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "Head" });
            DropIndex("dbo.EmployeeGroups", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeCertificates", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeCertificates", new[] { "CertificateId" });
            DropIndex("dbo.EmployeeAwards", new[] { "EmployeeId" });
            DropIndex("dbo.Workspaces", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Titles", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Roles", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Awards", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EmployeeAwards", new[] { "AwardId" });
            DropPrimaryKey("dbo.EmployeeAwards");
            AddPrimaryKey("dbo.EmployeeAward", new[] { "EmployeeId", "AwardId" });
            DropColumn("dbo.EmployeeAwards", "Id");
            DropColumn("dbo.Workspaces", "Employee_EmployeeId");
            DropColumn("dbo.Titles", "Employee_EmployeeId");
            DropColumn("dbo.Roles", "Employee_EmployeeId");
            DropColumn("dbo.Awards", "Employee_EmployeeId");
            DropTable("dbo.Groups");
            DropTable("dbo.EmployeeGroups");
            DropTable("dbo.EmployeeCertificates");
            DropTable("dbo.EmployeeAwards");
            DropTable("dbo.Certificates");
            CreateIndex("dbo.EmployeeWorkspace", "WorkspaceId");
            CreateIndex("dbo.EmployeeWorkspace", "EmployeeId");
            CreateIndex("dbo.Workspaces", "OuterWorkspace_WorkspaceId");
            CreateIndex("dbo.Workspaces", "InnerWorkspaces_WorkspaceId");
            CreateIndex("dbo.Workspaces", "ChildWorkspace_WorkspaceId");
            CreateIndex("dbo.EmployeeTitle", "TitleId");
            CreateIndex("dbo.EmployeeTitle", "EmployeeId");
            CreateIndex("dbo.EmployeeRole", "RoleId");
            CreateIndex("dbo.EmployeeRole", "EmployeeId");
            CreateIndex("dbo.EmployeeAward", "AwardId");
            CreateIndex("dbo.EmployeeAward", "EmployeeId");
            AddForeignKey("dbo.EmployeeWorkspace", "WorkspaceId", "dbo.Workspaces", "WorkspaceId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeWorkspace", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Workspaces", "OuterWorkspace_WorkspaceId", "dbo.Workspaces", "WorkspaceId");
            AddForeignKey("dbo.Workspaces", "InnerWorkspaces_WorkspaceId", "dbo.Workspaces", "WorkspaceId");
            AddForeignKey("dbo.Workspaces", "ChildWorkspace_WorkspaceId", "dbo.Workspaces", "WorkspaceId");
            AddForeignKey("dbo.EmployeeTitle", "TitleId", "dbo.Titles", "TitleId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeTitle", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeRole", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeRole", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAward", "AwardId", "dbo.Awards", "AwardId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAward", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            RenameTable(name: "dbo.Workspaces", newName: "EmployeeWorkspace");
            RenameTable(name: "dbo.Titles", newName: "EmployeeTitle");
            RenameTable(name: "dbo.Roles", newName: "EmployeeRole");
            RenameTable(name: "dbo.Awards", newName: "EmployeeAward");
        }
    }
}
