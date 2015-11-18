namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel9 : DbMigration
    {
        public override void Up()
        {
            Down();
            DropForeignKey("dbo.Awards", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Awards", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Workspaces", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Awards", "Employee_EmployeeId");
            DropColumn("dbo.Workspaces", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workspaces", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Awards", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Workspaces", "Employee_EmployeeId");
            CreateIndex("dbo.Awards", "Employee_EmployeeId");
            AddForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Awards", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
