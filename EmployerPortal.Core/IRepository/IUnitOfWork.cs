using EmployerPortal.Data;
using System;
using System.Threading.Tasks;

namespace EmployerPortal.Core.IRepository
{
    public interface IUnitOfWork : IDisposable // the IDisposable provide a means for managing unused resoruces
    {
        IGenericRepository<Employer> EmployerRepo { get; }
        IGenericRepository<Employee> EmployeeRepo { get; }
        IGenericRepository<RelationshipManager> RelationshipManagerRepo { get; }
        IGenericRepository<Schedule> ScheduleRepo { get; }
        IGenericRepository<NewPaymentSchedule> NewPaymentScheduleRepo { get; }
        IGenericRepository<EmployerAllocation> EmployerAllocationRepo { get; }

        Task Save();



    }
}
