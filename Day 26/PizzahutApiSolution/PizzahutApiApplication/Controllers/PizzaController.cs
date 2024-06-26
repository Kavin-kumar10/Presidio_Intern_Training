﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        [HttpPost]
        [Route("GetPizzaById")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> GetPizza(int PizzaId)
        {
            try
            {
                var result = await _service.GetById(PizzaId);
                return Ok(result);
            }
            catch(NoItemsFoundException nife)
            {
                return BadRequest(new ErrorModel(404, nife.Message));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pizza>> AddNewPizza(Pizza pizza)
        {
            try
            {
                var result = await _service.CreatePizza(pizza);
                return Ok(result);
            }
            catch(CannotCreateItem cci)
            {
                return BadRequest(new ErrorModel(400, cci.Message));
            }
        }

    }
}
