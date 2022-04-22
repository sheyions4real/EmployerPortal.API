using EmployerPortal.API.Data;
using EmployerPortal.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployerPortal.API.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private  ApiUser _apiUser;


       
        

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            
           
        }

        // generate the token after user is authenicated
        public async Task<string> GenerateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value)),
                signingCredentials: signingCredentials
                );

            return token;
        }

        // get the user claims
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.Name, _apiUser.UserName)
           };

            var roles= await _userManager.GetRolesAsync(_apiUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        }






        // validate the login user and return the user object to get the claims
        public async Task<bool> ValidateUser(LoginUserDTO loginUserDTO)
        {
            _apiUser = await _userManager.FindByNameAsync(loginUserDTO.Email);
            return (_apiUser != null && await _userManager.CheckPasswordAsync(_apiUser, loginUserDTO.Password)) ;
            
        }
    }
}
