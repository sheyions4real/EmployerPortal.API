using EmployerPortal.API.Models;
using System.Threading.Tasks;

namespace EmployerPortal.API.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);

        Task<string> GenerateToken();
    }
}
