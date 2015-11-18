namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workspaces", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Workspaces", "Employee_EmployeeId");
            AddForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            DropForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Workspaces", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Workspaces", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workspaces", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Workspaces", "Employee_EmployeeId");
            AddForeignKey("dbo.Workspaces", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
