namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildWorkspaces",
                c => new
                    {
                        ChileWorkspaceId = c.Int(nullable: false, identity: true),
                        WorkspaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChileWorkspaceId)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
                .Index(t => t.WorkspaceId);
            
            CreateTable(
                "dbo.InnerOuterWorkspaces",
                c => new
                    {
                        OuterWorkspace = c.Int(nullable: false),
                        InnerWorkspace = c.Int(nullable: false),
                        Parent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OuterWorkspace, t.InnerWorkspace })
                .ForeignKey("dbo.ChildWorkspaces", t => t.OuterWorkspace, cascadeDelete: true)
                .ForeignKey("dbo.ChildWorkspaces", t => t.InnerWorkspace, cascadeDelete: false)
                .ForeignKey("dbo.ParentWorkspaces", t => t.Parent, cascadeDelete: true)
                .Index(t => t.OuterWorkspace)
                .Index(t => t.InnerWorkspace)
                .Index(t => t.Parent);
            
            CreateTable(
                "dbo.ParentWorkspaces",
                c => new
                    {
                        ParentWorkspaceId = c.Int(nullable: false, identity: true),
                        WorkspaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentWorkspaceId)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: false)
                .Index(t => t.WorkspaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InnerOuterWorkspaces", "Parent", "dbo.ParentWorkspaces");
            DropForeignKey("dbo.ParentWorkspaces", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.InnerOuterWorkspaces", "InnerWorkspace", "dbo.ChildWorkspaces");
            DropForeignKey("dbo.InnerOuterWorkspaces", "OuterWorkspace", "dbo.ChildWorkspaces");
            DropForeignKey("dbo.ChildWorkspaces", "WorkspaceId", "dbo.Workspaces");
            DropIndex("dbo.InnerOuterWorkspaces", new[] { "Parent" });
            DropIndex("dbo.ParentWorkspaces", new[] { "WorkspaceId" });
            DropIndex("dbo.InnerOuterWorkspaces", new[] { "InnerWorkspace" });
            DropIndex("dbo.InnerOuterWorkspaces", new[] { "OuterWorkspace" });
            DropIndex("dbo.ChildWorkspaces", new[] { "WorkspaceId" });
            DropTable("dbo.ParentWorkspaces");
            DropTable("dbo.InnerOuterWorkspaces");
            DropTable("dbo.ChildWorkspaces");
        }
    }
}
