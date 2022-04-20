using Microsoft.AspNetCore.Identity;

namespace EmployerPortal.API.Data
{
    public class ApiUser :IdentityUser
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string UserCategory { get; set; }  
    }
}
