using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployerPortal.Data
{
    public class BaseIdentity
    {
       
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // automatically will be the identity column
          public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
