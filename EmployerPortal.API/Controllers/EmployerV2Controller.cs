using AutoMapper;
using EmployerPortal.Core.Models;
using EmployerPortal.Core.DTOs;
using EmployerPortal.Core.IRepository;
using EmployerPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployerPortal.API.Controllers
{

    //version 2 of the API.
    // this ew version uses the dbcontext to access data rather than the unitofwork
    /// <summary>
    /// This Version uses global exception handling
    /// to access the api
    /// use https://localhost:5001/api/v2/Employer  // using controller route
    /// or https://localhost:5001/api/Employer?api-version=2.0
    /// </summary>
    //[Route("api/V2/[controller]")] // delcare it this way or use same route but [ApiVersion(2.0)]

    [Route("api/{v:apiversion}/[controller]")]  // local host/api/2.0/employerv2
                                                // [Route("api/V2/[controller]")]  // local host/api/2.0/employerv2
    [ApiVersion("2.0", Deprecated = true)] // use this if the route of verion 1 and 2 are thesame . // add Deprecated if this endpoint is deprecated
    public class EmployerV2Controller : Controller
    {

        // not save and not best practice
        private readonly DatabaseContext _context;

        private readonly IUnitOfWork _unitOfWork; // accessed with dependency injection via the constructor
        private readonly ILogger<EmployerV2Controller> _logger;
        private readonly IMapper _mapper;


        // dependency injection
        public EmployerV2Controller(IUnitOfWork unitOfWork, ILogger<EmployerV2Controller> logger, IMapper mapper, DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }









        // [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get all employers
        public async Task<IActionResult> GetEmployers()
        {

            //// manually throw new exception to test the Global Exception handler
            // throw new Exception();

            // use the Request Params to reduce the result of the result to paging [10 - 50 records return in different pages]

            // var employers = await _unitOfWork.EmployerRepo.GetAll();
             var employers = await _context.Employers.FindAsync();
            // var results = _mapper.Map<IList<EmployerDTO>>(employers);
            return  Ok(employers);

        }





        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get all employers
        [Authorize]
        [HttpGet("GetEmployersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployersList([FromQuery] RequestParams param)
        {
            // use the Request Params to reduce the result of the result to paging [10 - 50 records return in different pages]

            // var employers = await _unitOfWork.EmployerRepo.GetAll();
            var employers = await _unitOfWork.EmployerRepo.GetAll(param);
            var results = _mapper.Map<IList<EmployerDTO>>(employers);
            return Ok(results);

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

            // the Get generic method receives an expression, we can includes the EmployerAllocation, Schedules and relationship managers
            var employer = await _unitOfWork.EmployerRepo.Get(q => q.Id == Id, new List<string> { "Employees", "Schedules", "EmployerAllocations" });
            var result = _mapper.Map<EmployerDTO>(employer);

            return Ok(result);


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


            var employer = _mapper.Map<Employer>(employerDTO);

            await _unitOfWork.EmployerRepo.Insert(employer);
            await _unitOfWork.Save();

            // like redirect to Action in mvc
            // once the employee model is saved it will automatically append the Id to the model
            // ensure the Get Employer HttpGet definition is labeled with the Action Name

            var createdResource = employer;
            var actionName = "GetEmployerByID";
            // var controllerName = nameof(EmployerV2Controller);
            var routeValues = new { employer.Id };

            return CreatedAtAction(actionName, routeValues, employer);
            //return Created(employer);



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






    }
}
