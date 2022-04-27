using System;

namespace EmployerPortal.Core.DTOs
{
    public class EmployerAllocationDTO : CreateEmployerAllocationDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }



    public class CreateEmployerAllocationDTO 
    {
        public string EmployerCode { get; set; }
        public EmployerDTO Employer { get; set; }

        public RelationshipManagerDTO RelationshipManager { get; set; }
        public int RelationshipManagerID { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public string EmployerMobile_Phone { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerContact_Officer_Name { get; set; }
        public string Officer_Position { get; set; }
        public string State_Of_Posting { get; set; }
    }
}
