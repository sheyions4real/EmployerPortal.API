using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Data
{
    public class Industry : BaseIdentity
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public virtual IList<Employer> Employees { get; set; }
       

    }
}
