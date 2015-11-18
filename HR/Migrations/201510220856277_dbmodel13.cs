namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false),
                        Name = c.String(),
                        About = c.String(),
                        BranchManager = c.Int(nullable: false),
                        Email = c.String(),
                        FeedbackPage = c.String(),
                        DevelopmentStatus = c.Int(nullable: false),
                        ParentProject = c.Int(nullable: false),
                        ParentBranch = c.Int(nullable: true),
                        ProfilePictrue = c.String(),
                        CoverPicture1 = c.String(),
                        CoverPicture2 = c.String(),
                        CoverPicture3 = c.String(),
                        CoverPicture4 = c.String(),
                        Repository = c.String(),
                        Websites = c.String(),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Branches", t => t.ParentBranch)
                .ForeignKey("dbo.Projects", t => t.ParentProject, cascadeDelete: true)
                .ForeignKey("dbo.DevelopmentStatus", t => t.DevelopmentStatus, cascadeDelete: true)
                .Index(t => t.ParentBranch)
                .Index(t => t.ParentProject)
                .Index(t => t.DevelopmentStatus);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        ProjectManger = c.Int(nullable: false),
                        ProfilePicture = c.String(),
                        CoverPicture1 = c.String(),
                        CoverPicture2 = c.String(),
                        CoverPicture3 = c.String(),
                        CoverPicture4 = c.String(),
                        WebSite = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.ProjectManger, cascadeDelete: true)
                .Index(t => t.ProjectManger);
            
            CreateTable(
                "dbo.DevelopmentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectBoards",
                c => new
                    {
                        BoardId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Post = c.String(),
                        PostBy = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BoardId)
                .ForeignKey("dbo.Employees", t => t.PostBy, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.PostBy)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        ProjectfileId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        FileName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectfileId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectFiles", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectBoards", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectBoards", "PostBy", "dbo.Employees");
            DropForeignKey("dbo.Branches", "DevelopmentStatus", "dbo.DevelopmentStatus");
            DropForeignKey("dbo.Branches", "ParentProject", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectManger", "dbo.Employees");
            DropForeignKey("dbo.Branches", "ParentBranch", "dbo.Branches");
            DropIndex("dbo.ProjectFiles", new[] { "ProjectId" });
            DropIndex("dbo.ProjectBoards", new[] { "ProjectId" });
            DropIndex("dbo.ProjectBoards", new[] { "PostBy" });
            DropIndex("dbo.Branches", new[] { "DevelopmentStatus" });
            DropIndex("dbo.Branches", new[] { "ParentProject" });
            DropIndex("dbo.Projects", new[] { "ProjectManger" });
            DropIndex("dbo.Branches", new[] { "ParentBranch" });
            DropTable("dbo.ProjectFiles");
            DropTable("dbo.ProjectBoards");
            DropTable("dbo.DevelopmentStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.Branches");
        }
    }
}
