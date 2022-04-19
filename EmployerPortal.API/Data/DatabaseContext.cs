using Microsoft.EntityFrameworkCore;

namespace EmployerPortal.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerAllocation> EmployerAllocations { get; set; }
        public DbSet<RelationshipManager> RelationshipManagers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<NewPaymentSchedule> NewPaymentSchedules { get; set; }


    }
}
