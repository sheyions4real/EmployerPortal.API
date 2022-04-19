using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.API.Data
{
    public class Employer : BaseIdentity
    {
        [Key]
        public string EmployerCode { get; set; }
        public string EmployerName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string Contact_Officer_Name { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }

    }
}
