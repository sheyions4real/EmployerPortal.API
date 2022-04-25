using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class NewPaymentSchedule : BaseIdentity
    {
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public string EmployerCode { get; set; }
       



        public int ContributionMonth { get; set; }
        public int ContributionYear { get; set; }
        public decimal ScheduleAmount { get; set; }
        public string Narration { get; set; }
        public string ScheduleFile { get; set; }
        public string ConfirmationOfPayment { get; set; }
        public bool? Status { get; set; }

    }
}
