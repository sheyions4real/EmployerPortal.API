using System;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Models
{
    public class EmployeeDTO
    {
        public string Pin { get; set; }
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage="Surname is too Long")]
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string Gender { get; set; }
        public string Ssn { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string EmployerName { get; set; }

      
        public string EmployerCode { get; set; }
        public EmployerDTO Employer { get; set; }


        public string Date_Employed { get; set; }
        public string Date_Created { get; set; }
        public string Upload_Date { get; set; }
        public string Agent_Code { get; set; }
        public string Scheme_Id { get; set; }
        public string State_Of_Posting { get; set; }
        public string Client_Status { get; set; }
        public string Pin_Invalid { get; set; }
    }


    public class CreateEmployeeDTO : EmployeeDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }

}
