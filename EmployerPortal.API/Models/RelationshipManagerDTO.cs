using System;
using System.Collections.Generic;

namespace EmployerPortal.API.Models
{
    public class CreateRelationshipManagerDTO 
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
        public string StateOfPosting { get; set; }
        public StateDTO State { get; set; }
    }

    public class RelationshipManagerDTO : CreateRelationshipManagerDTO
    {
        public int Id { get; set; } // automatically will be the identity column
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }

        public virtual IList<EmployerAllocationDTO> EmployerAllocations { get; set; }
    }
}
