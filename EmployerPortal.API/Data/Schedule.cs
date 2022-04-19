using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class Schedule : BaseIdentity
    {
        public int IDNO { get; set; }


        [ForeignKey(nameof(Employer))]
        public string EmployerCode { get; set; }
        public Employer Employer { get; set; }




        public string RefNo { get; set; }
        public decimal Amount { get; set; }
        public decimal Amount_Processed { get; set; }
        public decimal Refund_Amount { get; set; }
        public string Description { get; set; }
        public DateTime ValueDate { get; set; }
        public bool? Checked { get; set; }


    }
}
