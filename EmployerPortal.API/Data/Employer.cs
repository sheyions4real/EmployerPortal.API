using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class Employer : BaseIdentity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int Id { get; set; } // automatically will be the identity column
        //public string CreatedBy { get; set; }
        //public DateTime DateCreated { get; set; }


        //public string ModifiedBy { get; set; }
        //public DateTime DateModified { get; set; }

        public string EmployerCode { get; set; }
        public string EmployerName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

       
        [ForeignKey("States")]
        public string State { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string Contact_Officer_Name { get; set; }
        public string Sector { get; set; }
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }
        public string NatureOfBusiness { get; set; }

        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<Schedule> Schedules { get; set; }
        public virtual IList<NewPaymentSchedule> NewPaymentSchedules { get; set; }
        public virtual IList<RelationshipManager> RelationshipManagers { get; set; }
        public virtual IList<EmployerAllocation> EmployerAllocations { get; set; }

    }







    public class CreateEmployer //: BaseIdentity
    {
       
       

        public string EmployerCode { get; set; }
        public string EmployerName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }


        [ForeignKey("States")]
        public string State { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string Contact_Officer_Name { get; set; }
        public string Sector { get; set; }
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }
        public string NatureOfBusiness { get; set; }

    }
}
