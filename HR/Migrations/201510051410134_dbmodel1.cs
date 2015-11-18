namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProfiles",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                        About = c.String(),
                        CoverPicture = c.String(),
                        JobInterest = c.String(),
                        JobTools = c.String(),
                        ProfilePicture = c.String(),
                        Websites = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProfiles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeProfiles", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeProfiles");
        }
    }
}
