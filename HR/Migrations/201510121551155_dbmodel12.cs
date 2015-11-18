namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeGroups", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeGroups", "IsAdmin");
        }
    }
}
