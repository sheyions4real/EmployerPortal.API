using System;

namespace EmployerPortal.Core.DTOs
{
    public class CreateNewPaymentScheduleDTO 
    {
        public string EmployerCode { get; set; }
        public EmployerDTO Employer { get; set; }



        public int ContributionMonth { get; set; }
        public int ContributionYear { get; set; }
        public decimal ScheduleAmount { get; set; }
        public string Narration { get; set; }
        public string ScheduleFile { get; set; }
        public string ConfirmationOfPayment { get; set; }
        public bool? Status { get; set; }
    }

    public class NewPaymentScheduleDTO : CreateNewPaymentScheduleDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
    
}
