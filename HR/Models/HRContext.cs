using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Models
{
    public class HRContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public HRContext()
            : base("name=HRContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<EmployementStatus> EmployementStatus { get; set; }
        public DbSet<EmployementType> EmployementType { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfile { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<EmployeeAward> EmployeeAwards { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<EmployeeCertificate> EmployeeCertificates { get; set; }
        public DbSet<EmployeeWorkspace> EmployeeWorkspaces { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public DbSet<WorkspaceBoard> WorkspaceBoard { get; set; }
        public DbSet<GroupBoard> GroupBoard { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<DevelopmentStatus> DevelopmentStatus { get; set; }  
        public DbSet<ProjectBoard> ProjectBoard { get; set; }
        public DbSet<ProjectFile> ProjectFile { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<EmployeeEvent> EmployeeEvent { get; set; }
        public DbSet<OperationOnEmployee> OperationOnEmployee { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<OperationOnGuest> OperationOnGuest { get; set; }
        public DbSet<GuestEvent> GuestEvent { get; set; }
        public DbSet<ParentWorkspace> ParentWorkspace { get; set; }
        public DbSet<ChildWorkspace> ChildWorkspace { get; set; }
        public DbSet<InnerOuterWorkspace> InnerOuterWorkspace { get; set; }    
        public DbSet<Job> Job { get; set; }
        public DbSet<EmployeeJob> EmployeeJob { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<Version> Version { get; set; }
        //public DbSet<ProductFile> ProductFile { get; set; }
        //public DbSet<ProductGroup> ProductGroup { get; set; }

    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

             //modelBuilder.Entity<Employee>()
             //                  .HasMany<CompanyFile>(c => c.CompanyFiles)
             //                  .WithMany(s => s.Employees)
             //                  .Map(ea =>
             //                  {
             //                      ea.MapLeftKey("EmployeeId");
             //                      ea.MapRightKey("CompanyFileId");
             //                      ea.ToTable("EmployeeFile");
             //                  });
             //modelBuilder.Entity<Employee>()
             //                  .HasMany<Group>(c => c.Groups)
             //                  .WithMany(s => s.Members)
             //                  .Map(ea =>
             //                  {
             //                      ea.MapLeftKey("EmployeeId");
             //                      ea.MapRightKey("GroupId");
             //                      ea.ToTable("EmployeeGroup");
             //                  });           

             //modelBuilder.Entity<Employee>()
             //                  .HasMany<Job>(j => j.Jobs)
             //                  .WithMany(s => s.Employees)
             //                  .Map(ea =>
             //                  {
             //                      ea.MapLeftKey("EmployeeId");
             //                      ea.MapRightKey("JobId");
             //                      ea.ToTable("EmployeeJob");
             //                  });

             //modelBuilder.Entity<Product>()
             //                 .HasMany<Project>(w => w.Projects)
             //                 .WithMany(s => s.Products)
             //                 .Map(ea =>
             //                 {
             //                     ea.MapLeftKey("ProductId");
             //                     ea.MapRightKey("ProjectId");
             //                     ea.ToTable("ProductProject");
             //                 });

             //modelBuilder.Entity<Product>()
             //                 .HasMany<Version>(v => v.Versions)
             //                 .WithMany(p => p.Products)
             //                 .Map(ea =>
             //                 {
             //                     ea.MapLeftKey("ProductId");
             //                     ea.MapRightKey("VersionId");
             //                     ea.ToTable("ProductVersion");
             //                 });

             //modelBuilder.Entity<Employee>()
             //                .HasMany<Team>(w => w.Teams)
             //                .WithMany(s => s.Members)
             //                .Map(ea =>
             //                {
             //                    ea.MapLeftKey("EmployeeId");
             //                    ea.MapRightKey("TeamId");
             //                    ea.ToTable("TeamMembers");
             //                });

             //modelBuilder.Entity<Product>()
             //                 .HasMany<ProductGroup>(p => p.ProductGroups)
             //                 .WithMany(s => s.Products)
             //                 .Map(ea =>
             //                 {
             //                     ea.MapLeftKey("ProductId");
             //                     ea.MapRightKey("ProductGroupId");
             //                     ea.ToTable("ProductInGroup");
             //                 });
        }
    }

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       

        [Display(Name = "Other Names")]
        public string OtherName { get; set; }

        [DataType(DataType.EmailAddress)]
       public string Email { get; set; }

            
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        
        [Required]
        public string Passport { get; set; }
        

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


        [Required]
        public string Gender { get; set; }


        [Required]
        [Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Branch Office")]
        [ForeignKey("BranchOffice")]
        public int BranchId { get; set; }   

        [Required]
        [Display(Name="Company Email")]
        [DataType(DataType.EmailAddress)]
        public string CompanyEmail { get; set; }

        [Required]
        [Display(Name = "Company Phone Number")]
        public string CompanyPhoneNumber { get; set; }


        [Required]
        [Display(Name = "Employement Status")]
        [ForeignKey("EmployementStatus")]
        public int EmployementStatusId { get; set; }


        [Required]
        [Display(Name = "Employement Type")]
        [ForeignKey("EmployementType")]
        public int EmployementTypeId { get; set; }

        public BranchOffice BranchOffice { get; set; } 
        public EmployementStatus EmployementStatus { get; set; }         
        public EmployementType EmployementType { get; set; }
       
    }
    public class BranchOffice
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Required]
        [Display(Name = "Branch Address")]
        public string BranchAddress { get; set; }
    }
    public class EmployementStatus
    {
        [Key]
        public int EmployementStatusdId { get; set; }
        public string Status { get; set; }
    }
    public class EmployementType
    {
        [Key]
        public int EmploymentTypeId { get; set; }
        public string Type { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeRole
    {
        [Key, ForeignKey("Employee")]
        [Column(Order=1)]
        public int EmployeeId { get; set; }

        [Key, ForeignKey("Role")]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
    public class Title
    {
        [Key]
        public int TitleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class EmployeeTitle
    {
        [Key,ForeignKey("Employee")]
        [Column(Order=1)]
        public int EmployeeId { get; set; }

        [Key, ForeignKey("Title")]
        [Column(Order = 2)]
        public int TitleId { get; set; }

        public Employee Employee { get; set; }
        public Title Title { get; set; }
    }
    public class EmployeeProfile
    {
        [Key, ForeignKey("Employee")]
        public int EmployeeId { get; set; }


        [StringLength(25)]
        public string Name { get; set; }


        public string About { get; set; }

        [Display(Name = "Job Interest")]
        public string JobInterest { get; set; }

        [Display(Name = "Job Tools")]
        public string JobTools { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }
        public string Websites { get; set; }
        public Employee Employee { get; set; }

    }
    public class Workspace
    {
        [Key]
        public int WorkspaceId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPictures2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string Website { get; set; }
    }
    public class ParentWorkspace
    {
        [Key]
        public int ParentWorkspaceId { get; set; }

        [ForeignKey("Workspace")]
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
    }

    public class ChildWorkspace
    {
        [Key]
        public int ChileWorkspaceId { get; set; }

        [ForeignKey("Workspace")]
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
    }

    public class InnerOuterWorkspace
    {     
        [Key,ForeignKey("Child_Workspace")]
        [Column(Order=1)]
        public int OuterWorkspace { get; set; }
        public ChildWorkspace Child_Workspace { get; set; }

        [Key,ForeignKey("ChildWorkspace")]
        [Column(Order=2)]
        public int InnerWorkspace { get; set; }
        public ChildWorkspace ChildWorkspace { get; set; }

        [ForeignKey("ParentWorkspace")]
        public int Parent { get; set; }
        public ParentWorkspace ParentWorkspace { get; set; }
    }

    public class EmployeeWorkspace
    {
        [Key, ForeignKey("Employee")]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }

        [Key, ForeignKey("Workspace")]
        [Column(Order = 2)]
        public int WorkspaceId { get; set; }

        public Employee Employee { get; set; }
        public Workspace Workspace { get; set; }
    }
    public class Award
    {
        [Key]
        public int AwardId { get; set; }

        [Required]
        [Display(Name = "Award Name")]
        public string AwardName { get; set; }

        [Display(Name = "Award Description")]
        public string AwardDescription { get; set; }

        [Display(Name = "Award Prestige")]
        public int AwardPrestige { get; set; }
    }
    public class EmployeeAward
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Award")]
        public int AwardId { get; set; }

        public Employee Employee { get; set; }
        public Award Award { get; set; }
    }

   

    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }

        [Required]
        [Display(Name = "Certificate Name")]
        public string CertificateName { get; set; }

        [Display(Name = "Certificate Description")]
        public string CertificateDescription { get; set; }

        [Display(Name = "Certificate Prestige")]
        public string CertificatePrestige { get; set; }
    }
    public class EmployeeCertificate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Certificate")]
        public int CertificateId { get; set; }

        public Employee Employee { get; set; }
        public Certificate Certificate { get; set; }
    }

   // public class CompanyFile
   // {
   //     [Key]
   //     public int CompanyFileId { get; set; }

   //     [Required]
   //     [Display(Name = "CompanyFile Title")]
   //     public string CompanyFileTitle { get; set; }

   //     [Display(Name = "CompanyFile Description")]
   //     public string CompanyFileDescription { get; set; }

   //     [Display(Name = "CompanyFile Format")]
   //     public string CompanyFileFormat { get; set; }

   //     public List<Employee> Employees { get; set; }
   // }
    
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }
        public string About { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int Head { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }
    public class EmployeeGroup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public bool IsAdmin { get; set; }
        public Employee Employee { get; set; }
        public Group Group { get; set; }
    }
    public class GroupBoard
    {
        [Key]
        public int BoardId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string Post { get; set; }

        [ForeignKey("Employee")]
        public int PostBy { get; set; }
        public Employee Employee { get; set; }

        public DateTime PostDate { get; set; }
    }
    public class WorkspaceBoard
    {
        [Key]
        public int BoardId { get; set; }

        [ForeignKey("Workspace")]
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }

        public string Post { get; set; }

        [ForeignKey("Employee")]
        public int PostBy { get; set; }
        public Employee Employee { get; set; }

        public DateTime PostDate { get; set; }
    }
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        [ForeignKey("Employee")]
        public int ProjectManger { get; set; }
        public string ProfilePicture { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }
        public string WebSite { get; set; }

        public Employee Employee { get; set; }
    }
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int BranchManager { get; set; }
        public string Email { get; set; }
        public string FeedbackPage { get; set; }
        [ForeignKey("Status")]
        public int DevelopmentStatus { get; set; }
        public DevelopmentStatus Status { get; set; }
        [ForeignKey("Project")]
        public int ParentProject { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Parent")]
        public int ParentBranch { get; set; }
        public Branch Parent { get; set; }
        public string ProfilePictrue { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }
        public string Repository { get; set; }
        public string Websites { get; set; }
    }
    public class DevelopmentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class ProjectBoard
    {
        [Key]
        public int BoardId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string Post { get; set; }

        [ForeignKey("Employee")]
        public int PostBy { get; set; }
        public Employee Employee { get; set; }

        public DateTime PostDate { get; set; }
    }
    public class ProjectFile
    {
        [Key]
        public int ProjectfileId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }
    }
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string Descripton { get; set; }
    }
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }
    }
    public class EmployeeEvent
    {
        [Key]
        public int EmployementEventId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }


        [ForeignKey("Operation")]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }


        [ForeignKey("Employee")]
        public int AffectedParty { get; set; }
        public Employee Employee { get; set; }

        public DateTime TimeStamp { get; set; }
    }
    public class OperationOnEmployee
    {
        [Key]
        public int OperationOnEmployeeId { get; set; }

        [ForeignKey("Operation")]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }


        [ForeignKey("Executor")]
        public int Executioner { get; set; }
        public Employee Executor { get; set; }


        [ForeignKey("Authorizer")]
        public int Authority { get; set; }
        public Employee Authorizer { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime TimeStamp { get; set; }

    }
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Picture { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        [ForeignKey("Employee")]
        public int Guarantor { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Guest")]
        public int VisitingGuest { get; set; }
        public Guest Guest { get; set; }
        public string Purpose { get; set; }
    }
    public class GuestEvent
    {
        [Key]
        public int GuestEventId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }


        [ForeignKey("Operation")]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }


        [ForeignKey("Guest")]
        public int AffectedParty { get; set; }
        public Guest Guest { get; set; }

        public DateTime TimeStamp { get; set; }

    }
    public class OperationOnGuest
    {
        [Key]
        public int OperationOnEmployeeId { get; set; }

        [ForeignKey("Operation")]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("Executor")]
        public int Executioner { get; set; }
        public Employee Executor { get; set; }

        [ForeignKey("Authorizer")]
        public int Authority { get; set; }
        public Employee Authorizer { get; set; }

        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public DateTime TimeStamp { get; set; }

    }
    public class Job
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("ProjectJob")]
        public int Project { get; set; }
        public Project ProjectJob { get; set; }
    }

    public class EmployeeJob
    {
        [Key,ForeignKey("Employee")]
        [Column(Order=1)]
        public int EmployeeId { get; set; }
        [Key,ForeignKey("Job")]
        [Column(Order=2)]
        public int JobId { get; set; }

        public Employee Employee { get; set; }
        public Job Job { get; set; }
    }
   // public class Stage
   // {
   //     [Key]
   //     public int StageId {get; set;}

   //     public string Name {get; set;}

   //     public DateTime DateOpened {get; set;}

   //     public DateTime DateClosed {get; set;}

   //     public string Description {get; set;}

   //     [ForeignKey("DevelopmentStage")]
   //     public int Status {get; set;}
   //     public DevelopmentStatus DevelopmentStage { get; set; }
   // }
   
   
    
    //public class Product
   //{
   //    [Key]
   //    public int ProdutId { get; set; }

   //    public string Name { get; set; }

   //    [ForeignKey("Employee")]
   //    public int ProductManager { get; set; }
   //    public Employee Employee { get; set; }

   //    public List<Project> Projects { get; set; }

   //    public List<ProductGroup> ProductGroups { get; set; }

   //    public List<Version> Versions { get; set; }
   //}

   //public class Version
   //{
   //    [Key]
   //    public int VersionId { get; set; }

   //    public string Name { get; set; }

   //    public string About { get; set; }

   //    public string Copyright { get; set; }

   //    public string CoverPicture { get; set; }

   //    [ForeignKey("DevStatus")]
   //    public int Status { get; set; }
   //    public DevelopmentStatus DevStatus { get; set; }

   //    [DataType(DataType.EmailAddress)]
   //    public string Email { get; set; }

   //    public string FeedbackPage { get; set; }

   //    public string License { get; set; }

   //    public string PrivacyPolicy { get; set; }

   //    [ForeignKey("Employee")]
   //    public int VersionManager { get; set; }
   //    public Employee Employee { get; set; }

   //    public string ProfilePicture { get; set; }

   //    public string Terms { get; set; }

   //    public string Website { get; set; }

   //    public List<Product> Products { get; set; }
   //}

   // public class ProductFile
   // {
   //     [Key]
   //     public int ProductFileId { get; set; }

   //     [ForeignKey("Product")]
   //     public int ProductId { get; set; }
   //     public Product Product { get; set; }

   //     public string FileName { get; set; }

   //     public string Description { get; set; }
   // }
   
   // public class Team
   // {
   //     [Key]
   //     public int TeamId { get; set; }

   //     public string Name { get; set; }

   //     public string Description { get; set; }


   //     [ForeignKey("Employee")]
   //     public int TeamManager { get; set; }
   //     public Employee Employee { get; set; }

   //     public string Resources { get; set; }

   //     public List<Employee> Members { get; set; }
   // }

   // public class ProductGroup
   // {
   //     [Key]
   //     public int ProductGroupId { get; set; }

   //     public string Name { get;set; }

   //     public string Description { get; set; }

   //     [ForeignKey("Employee")]
   //     public int GroupManager { get; set; }
   //     public Employee Employee { get; set; }

   //     public List<Product> Products { get; set; }
   // }

   // public class Website
   // {
   //     [Key]
   //     public int Id { get; set; }

   //     [ForeignKey("Employee")]
   //     public int EmployeeId { get; set; }

   //     public string Name { get; set; }

   //     public string Link { get; set; }

   //     public Employee Employee { get; set; }

   // }

    //helper class

}
