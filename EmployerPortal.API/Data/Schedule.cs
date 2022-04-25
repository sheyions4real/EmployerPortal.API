using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class Schedule : BaseIdentity
    {
        public int IDNO { get; set; }


       
        public int EmployerId { get; set; }
        public string EmployerCode { get; set; }
        public Employer Employer { get; set; }




        public string RefNo { get; set; }
        public double Amount { get; set; }
        public double Amount_Processed { get; set; }
        public double Refund_Amount { get; set; }
        public string Description { get; set; }
        public DateTime ValueDate { get; set; }
        public bool Checked { get; set; }
        public string StatusCode { get; set; }


    }
}
