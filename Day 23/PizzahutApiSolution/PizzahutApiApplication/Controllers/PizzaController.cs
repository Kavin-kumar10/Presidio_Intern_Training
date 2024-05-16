using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzahutApiApplication.Exceptions;
using PizzahutApiApplication.Interfaces;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        readonly private IPizzaService _service;

        public PizzaController(IPizzaService service) {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Pizza>>> GetAvailablePizzas()
        {
            try
            {
                var result = await _service.GetAllAvailablePizza();
                return Ok(result);
            }
            catch(NoItemsFoundException nife)
            {
                return BadRequest(new ErrorModel(404,nife.Message));
            }
        }

    }
}
