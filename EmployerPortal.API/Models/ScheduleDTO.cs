using System;

namespace EmployerPortal.API.Models
{
    public class CreateScheduleDTO 
    {
        public int IDNO { get; set; }

        public string EmployerCode { get; set; }
        public EmployerDTO Employer { get; set; }
        public string RefNo { get; set; }
        public double Amount { get; set; }
        public double Amount_Processed { get; set; }
        public double Refund_Amount { get; set; }
        public string Description { get; set; }
        public DateTime ValueDate { get; set; }
        public bool Checked { get; set; }
        public string StatusCode { get; set; }
    }

    public class ScheduleDTO : CreateScheduleDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
