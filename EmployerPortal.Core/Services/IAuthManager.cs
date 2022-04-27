using EmployerPortal.Core.DTOs;
using System.Threading.Tasks;

namespace EmployerPortal.Core.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);

        Task<string> GenerateToken();
    }
}
