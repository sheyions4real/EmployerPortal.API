using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerPortal.Core.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="Your Password is Limited to {2} to {1} characters", MinimumLength =8)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }




    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is Limited to {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
 
}
