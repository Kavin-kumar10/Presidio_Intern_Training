using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestTrackerAPIApp.Exceptions;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Modals.DTOs;

namespace RequestTrackerAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateController : ControllerBase
    {
        private readonly IActivateService _activateService;

        public ActivateController(IActivateService activateservice) {
            _activateService = activateservice;
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        [Route("Activate")]
        [ProducesResponseType(typeof(ActivateDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ActivateDTO>> ActivateUser(int employeeId)
        {
            try
            {
                var result = await _activateService.ActivateEmployee(employeeId);
                return result;
            }
            catch(NoSuchEmployeeException nsee)
            {
                return BadRequest(new ErrorModel(404,nsee.Message));
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("Deactivate")]
        [ProducesResponseType(typeof(ActivateDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ActivateDTO>> DeActivateUser(int employeeId)
        {
            try
            {
                var result = await _activateService.DeActivateEmployee(employeeId);
                return result;
            }
            catch (NoSuchEmployeeException nsee)
            {
                return BadRequest(new ErrorModel(404, nsee.Message));
            }
        }
    }
}
