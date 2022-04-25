using AutoMapper;
using EmployerPortal.API.Data;
using EmployerPortal.API.Models;

namespace EmployerPortal.API.Configurations
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {
            CreateMap<Employer, EmployerDTO>().ReverseMap();
            CreateMap<CreateEmployer, Employer>().ReverseMap();


            CreateMap<CreateEmployer, CreateEmployerDTO>().ReverseMap();


            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployerAllocation, EmployerAllocationDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<RelationshipManager, RelationshipManagerDTO>().ReverseMap();
            CreateMap<NewPaymentSchedule, NewPaymentScheduleDTO>().ReverseMap();
            CreateMap<UserDTO, ApiUser>().ReverseMap();
            CreateMap<LoginUserDTO, ApiUser>().ReverseMap();
            CreateMap<StateDTO, State>().ReverseMap();
            CreateMap<IndustryDTO, Industry>().ReverseMap();


            CreateMap<Employer, CreateEmployerDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<EmployerAllocation, CreateEmployerAllocationDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();
            CreateMap<RelationshipManager, CreateRelationshipManagerDTO>().ReverseMap();
            CreateMap<NewPaymentSchedule, CreateNewPaymentScheduleDTO>().ReverseMap();




        }
    }
}
