using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestTrackerAPIApp.Exceptions;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;

namespace RequestTrackerAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService) { 
            _requestService = requestService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> ShowAllRequest()
        {
            try
            {
                var result = await _requestService.ShowRequests();
                return result.OrderByDescending(r => r.RequestDate).Where(r=>r.RequestStatus == "PENDING").ToList();
            }
            catch (NoRequestFound nrf)
            {
                return BadRequest(new ErrorModel(404, nrf.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetMyRequest")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> ShowMyRequest(int employeeId)
        {
            try
            {
                var result = await _requestService.ShowMyRequests(employeeId);
                return result.OrderByDescending(r => r.RequestDate).ToList();
            }
            catch (NoRequestFound nrf)
            {
                return BadRequest(new ErrorModel(404, nrf.Message));
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Request),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Request>> RaiseRequest(Request request)
        {
            try
            {
                var result = await _requestService.Raise_Request(request);
                return result;
            }
            catch(UnableToAddRequest utar)
            {
                return BadRequest(new ErrorModel(404, utar.Message));
            }
        }
    }
}
