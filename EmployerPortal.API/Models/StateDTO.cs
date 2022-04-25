using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Models
{
    public class StateDTO : BaseIdentity
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string ZoneCode { get; set; }
        public string Region { get; set; }


        public virtual IList<EmployerDTO> Employers { get; set; }
        public virtual IList<EmployeeDTO> Employees { get; set; }
        public virtual IList<RelationshipManagerDTO> RelationshipManagers { get; set; }

    }
}
