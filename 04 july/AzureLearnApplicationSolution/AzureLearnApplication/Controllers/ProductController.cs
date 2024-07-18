using AzureLearnApplication.Interfaces;
using AzureLearnApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureLearnApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductServices _services;

        public ProductController(IProductServices services) { 
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var result = await _services.GetAll();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int ProductId)
        {
            try
            {
                var result = await _services.GetById(ProductId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
