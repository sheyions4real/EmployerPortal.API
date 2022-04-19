using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class EmployerAllocation : BaseIdentity
    {
        [ForeignKey(nameof(Employer))]
        public string EmployerCode { get; set; }
        public Employer Employer { get; set; }



        public RelationshipManager RelationshipManager { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public string EmployerMobile_Phone { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerContact_Officer_Name { get; set; }
        public string State_Of_Posting { get; set; }

    }
}
