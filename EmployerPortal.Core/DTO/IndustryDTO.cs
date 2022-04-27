using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.Core.DTOs
{
    public class IndustryDTO : BaseIdentity
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public virtual IList<EmployerDTO> Employees { get; set; }
       

    }
}
