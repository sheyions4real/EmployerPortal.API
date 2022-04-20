using EmployerPortal.API.Data;
using EmployerPortal.API.IRepository;
using System;
using System.Threading.Tasks;

namespace EmployerPortal.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DatabaseContext _dbContext;

        private IGenericRepository<Employer> _employers;
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<Schedule> _schedules;
        private IGenericRepository<RelationshipManager> _relationshipManagers;
        private IGenericRepository<EmployerAllocation> _employerAllocations;
        private IGenericRepository<NewPaymentSchedule> _newPaymentSchedules;





        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        // initializes the implemented repository to IGeneric Repository and if it null then Initialize with GenericRepositoty passing the databaseContext
        // inthe Controller you will use the Repository object to access the methodss to perform the operations

        public IGenericRepository<Employer> EmployerRepo => _employers ?? new GenericRepository<Employer>(_dbContext);

        public IGenericRepository<Employee> EmployeeRepo => _employees ?? new GenericRepository<Employee>(_dbContext);

        public IGenericRepository<RelationshipManager> RelationshipManagerRepo => _relationshipManagers ?? new GenericRepository<RelationshipManager>(_dbContext);

        public IGenericRepository<Schedule> ScheduleRepo => _schedules ?? new GenericRepository<Schedule>(_dbContext);

        public IGenericRepository<NewPaymentSchedule> NewPaymentScheduleRepo => _newPaymentSchedules ?? new GenericRepository<NewPaymentSchedule>(_dbContext);

        public IGenericRepository<EmployerAllocation> EmployerAllocationRepo => _employerAllocations ?? new GenericRepository<EmployerAllocation>(_dbContext);





        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }




        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
