namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Titles", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Roles", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Titles", "Employee_EmployeeId");
            CreateIndex("dbo.Roles", "Employee_EmployeeId");
            AddForeignKey("dbo.Titles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Roles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            DropForeignKey("dbo.Roles", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Titles", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Roles", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Titles", new[] { "Employee_EmployeeId" });
            //AddColumn("dbo.Workspaces", "Employee_EmployeeId", c => c.Int());
            //CreateIndex("dbo.Workspaces", "Employee_EmployeeId");
            //AddForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Roles", "Employee_EmployeeId");
            DropColumn("dbo.Titles", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Titles", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Roles", "Employee_EmployeeId", c => c.Int());
            DropForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Workspaces", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Workspaces", "Employee_EmployeeId");
            CreateIndex("dbo.Titles", "Employee_EmployeeId");
            CreateIndex("dbo.Roles", "Employee_EmployeeId");
            AddForeignKey("dbo.Titles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Roles", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
