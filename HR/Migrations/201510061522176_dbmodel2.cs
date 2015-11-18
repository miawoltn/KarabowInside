namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeProfiles", "CoverPicture1", c => c.String());
            AddColumn("dbo.EmployeeProfiles", "CoverPicture2", c => c.String());
            AddColumn("dbo.EmployeeProfiles", "CoverPicture3", c => c.String());
            AddColumn("dbo.EmployeeProfiles", "CoverPicture4", c => c.String());
            DropColumn("dbo.EmployeeProfiles", "CoverPicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeProfiles", "CoverPicture", c => c.String());
            DropColumn("dbo.EmployeeProfiles", "CoverPicture4");
            DropColumn("dbo.EmployeeProfiles", "CoverPicture3");
            DropColumn("dbo.EmployeeProfiles", "CoverPicture2");
            DropColumn("dbo.EmployeeProfiles", "CoverPicture1");
        }
    }
}
