using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.API.Data
{
    public class EmployerAllocation : BaseIdentity
    {
       
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public string EmployerCode { get; set; }

        public RelationshipManager RelationshipManager { get; set; }
        public int RelationshipManagerID { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public string EmployerMobile_Phone { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerContact_Officer_Name { get; set; }
        public string Officer_Position { get; set; }

        [ForeignKey("States")]
        public string State_Of_Posting { get; set; }

  

    }
}
