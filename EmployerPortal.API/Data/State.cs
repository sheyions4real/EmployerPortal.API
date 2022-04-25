using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Data
{
    public class State : BaseIdentity
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string ZoneCode { get; set; }
        public string Region { get; set; }


        public virtual IList<Employer> Employers { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<RelationshipManager> RelationshipManagers { get; set; }

    }
}
