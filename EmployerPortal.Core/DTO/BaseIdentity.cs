using System;

namespace EmployerPortal.Core.DTOs
{
    public class BaseIdentity
    {

        public int Id { get; set; } // automatically will be the identity column
          public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
