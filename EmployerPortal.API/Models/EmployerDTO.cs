using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Models
{
    public class CreateEmployerDTO 
    {
        public string EmployerCode { get; set; }
        public string EmployerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string Contact_Officer_Name { get; set; }
        public string Sector { get; set; }
        public int? IndustryId { get; set; }
        public string NatureOfBusiness { get; set; }
    }


    public class EmployerDTO : CreateEmployerDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }


        public IndustryDTO Industry { get; set; }

        public virtual IList<EmployeeDTO> Employees { get; set; }
        public virtual IList<ScheduleDTO> Schedules { get; set; }
        public virtual IList<NewPaymentScheduleDTO> NewPaymentSchedules { get; set; }
        public virtual IList<RelationshipManagerDTO> RelationshipManagers { get; set; }
        public virtual IList<EmployerAllocationDTO> EmployerAllocations { get; set; }
    }

    }
