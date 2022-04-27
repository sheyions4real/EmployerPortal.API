using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.Data
{
    public class RelationshipManager : BaseIdentity
    {
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string Gender { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string AgentCode { get; set; }
        public string BranchCode { get; set; }

        [ForeignKey("States")]
        public string StateOfPosting { get; set; }
        public State State { get; set; }

        public virtual IList<EmployerAllocation> EmployerAllocations { get; set; }
    }
}
