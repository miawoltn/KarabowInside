namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupBoards",
                c => new
                    {
                        BoardId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Post = c.String(),
                        PostBy = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BoardId)
                .ForeignKey("dbo.Employees", t => t.PostBy, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.PostBy)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.WorkspaceBoards",
                c => new
                    {
                        BoardId = c.Int(nullable: false, identity: true),
                        WorkspaceId = c.Int(nullable: false),
                        Post = c.String(),
                        PostBy = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BoardId)
                .ForeignKey("dbo.Employees", t => t.PostBy, cascadeDelete: true)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
                .Index(t => t.PostBy)
                .Index(t => t.WorkspaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkspaceBoards", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.WorkspaceBoards", "PostBy", "dbo.Employees");
            DropForeignKey("dbo.GroupBoards", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupBoards", "PostBy", "dbo.Employees");
            DropIndex("dbo.WorkspaceBoards", new[] { "WorkspaceId" });
            DropIndex("dbo.WorkspaceBoards", new[] { "PostBy" });
            DropIndex("dbo.GroupBoards", new[] { "GroupId" });
            DropIndex("dbo.GroupBoards", new[] { "PostBy" });
            DropTable("dbo.WorkspaceBoards");
            DropTable("dbo.GroupBoards");
        }
    }
}
