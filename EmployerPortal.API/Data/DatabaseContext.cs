using EmployerPortal.API.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployerPortal.API.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>  // Use DbContext for Ef and IdentityDbContextDbContext from Identity Core authentication
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Add this line because you are using the IdentityDbContext

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeSeedConfiguration());
            modelBuilder.ApplyConfiguration(new EmployerSeedConfiguration());
            modelBuilder.ApplyConfiguration(new RelationshipManagerSeedConfiguration());
            modelBuilder.ApplyConfiguration(new EmployerAllocationSeedConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleSeedConfiguration());
            modelBuilder.ApplyConfiguration(new IndustrySeedConfiguration());
            modelBuilder.ApplyConfiguration(new StateSeedConfiguration());


            //modelBuilder.Entity<Employer>()
            // .HasKey(code => code.Id);

            //// declare EmployerCode as unique key
            modelBuilder.Entity<Employer>()
                .HasIndex(code => code.EmployerCode)
                .IsUnique();
                
                
     



            // we will apply if from the SeedConfiguration file
            //modelBuilder.Entity<Employer>()
            //    .HasData(
            //        new Employer
            //        {
            //            Id = 1,
            //            EmployerCode = "PR0000613584",
            //            EmployerName = "OAK PENSIONS LIMITED",
            //            Address = "15B OKO AWO STREET  VICTORIA ISLAND, LAGOS",
            //            City = "LAGOS",
            //            State = "LAGOS",
            //            Mobile_Phone = "07002255625",
            //            Email = "info@oakpensions.com",
            //            Contact_Officer_Name ="Akinwumi A.",
            //            Sector =  "Private",
            //            Industry ="Finance"
            //        },
            //        new Employer
            //        {
            //            Id = 2,
            //            EmployerCode = "PR0000041041",
            //            EmployerName = "DUETHEL PRO SERVICES LIMITED",
            //            Address = "PLOT 590 ZONE A.O NAIC HOUSE CBD",
            //            City = "Abuja",
            //            State = "FCT",
            //            Mobile_Phone = "08126696169",
            //            Email = "",
            //            Contact_Officer_Name = "AYEKAME ELUKPO",
            //            Sector = "Private",
            //            Industry = "Finance"


            //        },
            //        new Employer
            //        {
            //            Id = 3,
            //            EmployerCode = "PR0000041042",
            //            EmployerName = "WINCREST CONSULT LIMITED",
            //            Address = "16 YASHIM DOGARA CRESCENT DAWAKI ABUJA",
            //            City = "Abuja",
            //            State = "FCT",
            //            Mobile_Phone = "08163313858",
            //            Email = "",
            //            Contact_Officer_Name = "",
            //            Sector = "Private",
            //            Industry = "Finance"
            //        }

            //);





            //modelBuilder.Entity<Employee>()
            //   .HasData(
            //        new Employee
            //        {
            //            Id= 1,
            //            Pin = "PEN100599222817",
            //            Title = "Mr",
            //            Surname = "Omagene",
            //            Firstname = "Sheyi",
            //            Othernames = "Matthew",
            //            Gender = "M",
            //            Ssn = "",
            //            Date_Of_Birth = "1986-10-26",
            //            Mobile_Phone = "08134454808",
            //            Email = "sheyions4real@yahoo.co.uk",
            //            EmployerName = "OAK PENSIONS LIMITED",
            //            EmployerCode = "PR0000613584",
            //            Date_Employed = "2012-04-01",
            //            Date_Created = "2012-04-01",
            //            Upload_Date = "2012-04-01",
            //            Agent_Code = "",
            //            Scheme_Id = "2000006",
            //            State_Of_Posting = "LA",
            //            Client_Status = "C",
            //            Pin_Invalid = "0"
            //        }
            //    );



            //modelBuilder.Entity<RelationshipManager>()
            //    .HasData(
            //        new RelationshipManager
            //        {
            //            Id =1,
            //            Title = "Mr",
            //            Surname = "Adetula",
            //            Firstname = "Omololu",
            //            Othernames = "Olasupo",
            //            Gender = "M",
            //            Mobile_Phone = "08029510718",
            //            Email = "lolua@oakpensions.com",
            //            AgentCode = "LAG101",
            //            BranchCode = "LA",
            //            StateOfPosting = "LA"
            //        }
            //    );



            //modelBuilder.Entity<EmployerAllocation>()
            //    .HasData(
            //        new EmployerAllocation
            //        {
            //            Id =1,
            //            EmployerCode = "PR0000613584",
            //            RelationshipManagerID = 1,
            //            EmployerAddress = "266 Murtala Muhammed Way, Alagomeji Yaba",
            //            EmployerCity = "Lagos",
            //            EmployerState = "LA",
            //            EmployerMobile_Phone = "07002255625",
            //            EmployerEmail = "info@oakpensions.com",
            //            EmployerContact_Officer_Name = "Henry Christopher",
            //            Officer_Position = "Head, HR",
            //            State_Of_Posting = "LA",
            //        }
            //    );


            //modelBuilder.Entity<Schedule>()
            //    .HasData(

            //        new Schedule
            //        {
            //            Id = 1,
            //            IDNO = 200734,
            //            EmployerCode = "PR0000613584",
            //            RefNo = "S50268032-2",
            //            Amount = 2021556.46,
            //            Amount_Processed = 0.00,
            //            Refund_Amount = 0.00,
            //            Description = "REM  N-10042361295/PR0000613584/NIP0341903290-000000364600 91004236129",
            //            ValueDate = new DateTime(2019-03-29),
            //            Checked = false,
            //            StatusCode = "R"
            //        }
            //    );

        }








        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerAllocation> EmployerAllocations { get; set; }
        public DbSet<RelationshipManager> RelationshipManagers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<NewPaymentSchedule> NewPaymentSchedules { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<State> States { get; set; }
    }
}
