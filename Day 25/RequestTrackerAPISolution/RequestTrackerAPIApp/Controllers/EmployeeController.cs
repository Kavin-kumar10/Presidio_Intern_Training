using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestTrackerAPIApp.Exceptions;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;
using System.Numerics;

namespace RequestTrackerAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return employees.ToList();
            }
            catch (NoEmployeesFoundException nefe) {
                return NotFound(new ErrorModel(404,nefe.Message));
            }
        }


        [HttpPut]
        public async Task<ActionResult<Employee>> Put(int id, string ph)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, ph);
                return Ok(employee);
            }
            catch (Exception NoSuchEmployeeException) { 
                return NotFound(NoSuchEmployeeException.Message);   
            }
        }

        [HttpPost]
        [Route("GetEmployeeByPhone")]
        public async Task<ActionResult<Employee>> Post([FromBody]string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (Exception NoEmployeesFoundException)
            {
                return NotFound(NoEmployeesFoundException.Message);
            }

        }
    }
}
