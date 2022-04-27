using AutoMapper;
using EmployerPortal.Core.DTOs;
using EmployerPortal.Core.Services;
using EmployerPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EmployerPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApiUser> _userManager; // User manager comes from IdentiyCore
                                                            // private readonly SignInManager<ApiUser> _signInManager; //// User manager comes from IdentiyCore
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;


        public AccountController(UserManager<ApiUser> userManager,
          //  SignInManager<ApiUser> signInManager, 
          IAuthManager authManager,
            ILogger<AccountController> logger,
            IMapper mapper)
        {
            _userManager = userManager;
            // _signInManager = signInManager;
            _authManager = authManager;
            _logger = logger;
            _mapper = mapper;

        }




        // All controller actions here
        // cant have two action with the same verb since we declared [Route("api/[controller]")] at class level
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = user.Email;

                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    // return BadRequest($"User registration Attempt Failed"); // safer
                    return BadRequest(ModelState); // this is not too save as it can give hacker vital information
                }


                // assign user to role
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Ok(userDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);

            }
        }

        // Login authentication to generate token
        // All controller actions here

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _authManager.ValidateUser(userDTO);
                if (!result)
                {
                    return Unauthorized();
                }

                // since user is validated return token
                return Accepted(new { Token = await _authManager.GenerateToken() });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);


            }
        }



        //// All controller actions here
        //// this signinmanager will use sessions so its not needed since we are using token
        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        //{
        //    _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {

        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);
        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(userDTO);
        //        }

        //        return Accepted();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
        //        return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);


        //    }
        //}

    }
}
