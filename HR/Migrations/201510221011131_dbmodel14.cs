namespace HR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmodel14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEvents",
                c => new
                    {
                        EmployementEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        OperationId = c.Int(nullable: false),
                        AffectedParty = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployementEventId)
                .ForeignKey("dbo.Employees", t => t.AffectedParty, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Operations", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.AffectedParty)
                .Index(t => t.EventId)
                .Index(t => t.OperationId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventType = c.String(),
                        Descripton = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OperationId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Picture = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.GuestEvents",
                c => new
                    {
                        GuestEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        OperationId = c.Int(nullable: false),
                        AffectedParty = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuestEventId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.AffectedParty, cascadeDelete: true)
                .ForeignKey("dbo.Operations", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.AffectedParty)
                .Index(t => t.OperationId);
            
            CreateTable(
                "dbo.OperationOnEmployees",
                c => new
                    {
                        OperationOnEmployeeId = c.Int(nullable: false, identity: true),
                        OperationId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Executioner = c.Int(nullable: false),
                        Authority = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OperationOnEmployeeId)
                .ForeignKey("dbo.Employees", t => t.Authority, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Executioner, cascadeDelete: false)
                .ForeignKey("dbo.Operations", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.Authority)
                .Index(t => t.EmployeeId)
                .Index(t => t.EventId)
                .Index(t => t.Executioner)
                .Index(t => t.OperationId);
            
            CreateTable(
                "dbo.OperationOnGuests",
                c => new
                    {
                        OperationOnEmployeeId = c.Int(nullable: false, identity: true),
                        OperationId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Executioner = c.Int(nullable: false),
                        Authority = c.Int(nullable: false),
                        GuestId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OperationOnEmployeeId)
                .ForeignKey("dbo.Employees", t => t.Authority, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Executioner, cascadeDelete: false)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .ForeignKey("dbo.Operations", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.Authority)
                .Index(t => t.EventId)
                .Index(t => t.Executioner)
                .Index(t => t.GuestId)
                .Index(t => t.OperationId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        Guarantor = c.Int(nullable: false),
                        VisitingGuest = c.Int(nullable: false),
                        Purpose = c.String(),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Employees", t => t.Guarantor, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.VisitingGuest, cascadeDelete: true)
                .Index(t => t.Guarantor)
                .Index(t => t.VisitingGuest);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VisitingGuest", "dbo.Guests");
            DropForeignKey("dbo.Visits", "Guarantor", "dbo.Employees");
            DropForeignKey("dbo.OperationOnGuests", "OperationId", "dbo.Operations");
            DropForeignKey("dbo.OperationOnGuests", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.OperationOnGuests", "Executioner", "dbo.Employees");
            DropForeignKey("dbo.OperationOnGuests", "EventId", "dbo.Events");
            DropForeignKey("dbo.OperationOnGuests", "Authority", "dbo.Employees");
            DropForeignKey("dbo.OperationOnEmployees", "OperationId", "dbo.Operations");
            DropForeignKey("dbo.OperationOnEmployees", "Executioner", "dbo.Employees");
            DropForeignKey("dbo.OperationOnEmployees", "EventId", "dbo.Events");
            DropForeignKey("dbo.OperationOnEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OperationOnEmployees", "Authority", "dbo.Employees");
            DropForeignKey("dbo.GuestEvents", "OperationId", "dbo.Operations");
            DropForeignKey("dbo.GuestEvents", "AffectedParty", "dbo.Guests");
            DropForeignKey("dbo.GuestEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.EmployeeEvents", "OperationId", "dbo.Operations");
            DropForeignKey("dbo.EmployeeEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.EmployeeEvents", "AffectedParty", "dbo.Employees");
            DropIndex("dbo.Visits", new[] { "VisitingGuest" });
            DropIndex("dbo.Visits", new[] { "Guarantor" });
            DropIndex("dbo.OperationOnGuests", new[] { "OperationId" });
            DropIndex("dbo.OperationOnGuests", new[] { "GuestId" });
            DropIndex("dbo.OperationOnGuests", new[] { "Executioner" });
            DropIndex("dbo.OperationOnGuests", new[] { "EventId" });
            DropIndex("dbo.OperationOnGuests", new[] { "Authority" });
            DropIndex("dbo.OperationOnEmployees", new[] { "OperationId" });
            DropIndex("dbo.OperationOnEmployees", new[] { "Executioner" });
            DropIndex("dbo.OperationOnEmployees", new[] { "EventId" });
            DropIndex("dbo.OperationOnEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.OperationOnEmployees", new[] { "Authority" });
            DropIndex("dbo.GuestEvents", new[] { "OperationId" });
            DropIndex("dbo.GuestEvents", new[] { "AffectedParty" });
            DropIndex("dbo.GuestEvents", new[] { "EventId" });
            DropIndex("dbo.EmployeeEvents", new[] { "OperationId" });
            DropIndex("dbo.EmployeeEvents", new[] { "EventId" });
            DropIndex("dbo.EmployeeEvents", new[] { "AffectedParty" });
            DropTable("dbo.Visits");
            DropTable("dbo.OperationOnGuests");
            DropTable("dbo.OperationOnEmployees");
            DropTable("dbo.GuestEvents");
            DropTable("dbo.Guests");
            DropTable("dbo.Operations");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeEvents");
        }
    }
}
