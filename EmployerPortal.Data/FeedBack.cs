using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.Data
{
    public class Feedback : BaseIdentity
    {


        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public string EmployerCode { get; set; }
 


        public string Title { get; set; }
        public string Details { get; set; }
        public string Priority { get; set; }
       
        public string Repsonse { get; set; }
        public string ResponseDate { get; set; }

        public RelationshipManager RelationshipManager { get; set; }
        public string RelationshipManagerID { get; set; }


        public bool Checked { get; set; }
        public string StatusCode { get; set; }


    }
}
