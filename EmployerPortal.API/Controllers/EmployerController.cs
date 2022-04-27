using AutoMapper;
using EmployerPortal.Core.Models;
using EmployerPortal.Core.DTOs;
using EmployerPortal.Core.IRepository;
using EmployerPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployerPortal.API.Controllers
{

    // global to all methods
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class EmployerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; // accessed with dependency injection via the constructor
        private readonly ILogger<EmployerController> _logger;
        private readonly IMapper _mapper;


        // dependency injection
        public EmployerController(IUnitOfWork unitOfWork, ILogger<EmployerController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }









        [Authorize]
        //[ResponseCache(Duration =60)] // --- Local to this method -- add caching attribute in the response header primarily
        //[ResponseCache(CacheProfileName = "120SecondsDuration")] // --- Global // this profile has been configured globally in the start up.cs file

        //setting custom global cacheing proporeties to override the global in the serviceExtension
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge= 60)]
        //[HttpCacheValidation(MustRevalidate =false)]

        [HttpGet]
        [ActionName("GetEmployers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get all employers
        public async Task<IActionResult> GetEmployers()
        {

            //// manually throw new exception to test the Global Exception handler
            // throw new Exception();

            // use the Request Params to reduce the result of the result to paging [10 - 50 records return in different pages]
            try
            {
                // var employers = await _unitOfWork.EmployerRepo.GetAll();
                var employers = await _unitOfWork.EmployerRepo.GetAll();
                var results = _mapper.Map<IList<EmployerDTO>>(employers);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetEmployers)}");
                return StatusCode(500, "Internal Server Error Please Try again later");
            }
        }





        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get all employers
        [Authorize]
        [ResponseCache(Duration = 60)]
        [HttpGet("GetEmployersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployers([FromQuery] RequestParams param)
        {
            // use the Request Params to reduce the result of the result to paging [10 - 50 records return in different pages]
            try
            {
                // var employers = await _unitOfWork.EmployerRepo.GetAll();
                var employers = await _unitOfWork.EmployerRepo.GetAll(param);
                var results = _mapper.Map<IList<EmployerDTO>>(employers);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(this.GetEmployers)}");
                return StatusCode(500, "Internal Server Error Please Try again later");
            }
        }



        [Authorize]   // or extend the Route attibute [HttpGet("{id:int}"), Authorize] or at controller level
        [HttpGet("{Id:int}")]
        [ActionName("GetEmployerByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get employer by Id
        // they are both Get methods actions but this accept Id
        public async Task<IActionResult> GetEmployer(int Id)
        {
            try
            {
                // the Get generic method receives an expression, we can includes the EmployerAllocation, Schedules and relationship managers
                var employer = await _unitOfWork.EmployerRepo.Get(q => q.Id == Id, new List<string> { "Employees", "Schedules", "EmployerAllocations" });
                var result = _mapper.Map<EmployerDTO>(employer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetEmployer)}");
                return StatusCode(500, "Internal Server Error Please Try again later");
            }
        }





        // Create new Employer by HttpPost
        [HttpPost]
        [Authorize]//(Roles = "Administrator")] // only Administrator can create Employer
                   // [ActionName(nameof(CreateEmployer))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmployer([FromBody] CreateEmployerDTO employerDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post Post attempt in {nameof(CreateEmployer)}");
                return BadRequest(ModelState);
            }

            try
            {
                var employer = _mapper.Map<Employer>(employerDTO);

                await _unitOfWork.EmployerRepo.Insert(employer);
                await _unitOfWork.Save();

                // like redirect to Action in mvc
                // once the employee model is saved it will automatically append the Id to the model
                // ensure the Get Employer HttpGet definition is labeled with the Action Name

                var createdResource = employer;
                var actionName = "GetEmployerByID";
                //var controllerName = nameof(EmployerController);
                var routeValues = new { employer.Id };

                return CreatedAtAction(actionName, routeValues, employer);
                //return Created(employer);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateEmployer)}");
                return Problem($"Something Went Wrong in the {nameof(CreateEmployer)} Error {ex.Message}", statusCode: 500);
            }


        }



        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployer(int Id, [FromBody] CreateEmployerDTO employerDTO)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                _logger.LogError($"Invalid Post Post attempt in {nameof(UpdateEmployer)}");
                return BadRequest(ModelState);
            }

            try
            {

                var employer = await _unitOfWork.EmployerRepo.Get(q => q.Id == Id);

                if (employer == null)
                {
                    _logger.LogError($"Invalid Put Operation attempt in {nameof(UpdateEmployer)}");
                    return BadRequest($"Submitted Data is Invalid. No Employer with Id {Id} Found");
                }

                _mapper.Map(employerDTO, employer);

                // var updateEmployer = _mapper.Map<Employer>(employerDTO);

                _unitOfWork.EmployerRepo.Update(employer);
                await _unitOfWork.Save();

                return NoContent();

                // like redirect to Action in mvc
                // once the employee model is saved it will automatically append the Id to the model
                // ensure the Get Employer HttpGet definition is labeled with the Action Name

                //return Created(employer);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateEmployer)}");
                return Problem($"Something Went Wrong in the {nameof(UpdateEmployer)} Error {ex.Message}", statusCode: 500);
            }

        }



        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployer(int Id)
        {
            if (Id < 1)
            {
                _logger.LogError($"Invalid Delete Request attempted in {nameof(DeleteEmployer)}");
                return BadRequest("Invalid ID Parameter");
            }
            try
            {

                var employer = await _unitOfWork.EmployerRepo.Get(q => q.Id == Id);

                if (employer == null)
                {
                    _logger.LogError($"Invalid Delete Operation attempt in {nameof(UpdateEmployer)}");
                    return BadRequest($"Submitted Data is Invalid. No Employer with Id {Id} Found");
                }

                await _unitOfWork.EmployerRepo.Delete(employer.Id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteEmployer)}");
                return Problem($"Something Went Wrong in the {nameof(DeleteEmployer)} Error {ex.Message}", statusCode: 500);
            }
        }








    }
}

