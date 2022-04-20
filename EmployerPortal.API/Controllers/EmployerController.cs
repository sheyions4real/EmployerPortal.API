using AutoMapper;
using EmployerPortal.API.IRepository;
using EmployerPortal.API.Models;
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





        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // since the route is [Route("api/[controller]")] when access using a GET method type it will hit this action automatically
        // get all employers
        public async Task<IActionResult> GetEmployers()
        {
            try
            {
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




        [HttpGet("{id:int}")]
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
                var employer = await _unitOfWork.EmployerRepo.Get(q => q.Id == Id, new List<string> { "Employees","Schedules","EmployerAllocations" }  );
                var result = _mapper.Map<EmployerDTO>(employer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetEmployer)}");
                return StatusCode(500, "Internal Server Error Please Try again later");
            }
        }




    }
}
