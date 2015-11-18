namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeProfiles", "Name", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeProfiles", "Name", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
