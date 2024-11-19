using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsStatesController : ControllerBase
    {
        private readonly IProductsStatesService _productsStatesService;

        public ProductsStatesController(IProductsStatesService productsStatesService)
        {
            _productsStatesService = productsStatesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductsStates>>> GetAllProductsStates()
        {
            var states = await _productsStatesService.GetAllProductsStatesAsync();
            return Ok(states);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsStates>> GetProductsStateById(int id)
        {
            var state = await _productsStatesService.GetProductsStateByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductsState([FromBody] ProductsStates productsState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productsStatesService.CreateProductsStateAsync(productsState);
            return CreatedAtAction(nameof(GetProductsStateById), new { id = productsState.ProductStateId }, productsState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductsState(int id, [FromBody] ProductsStates productsState)
        {
            var existingState = await _productsStatesService.GetProductsStateByIdAsync(id);
            if (existingState == null)
            {
                return NotFound();
            }

            existingState.ProductStateName = productsState.ProductStateName;
            existingState.ProductStateDescription = productsState.ProductStateDescription;
            existingState.IsDeleted = productsState.IsDeleted;

            await _productsStatesService.UpdateProductsStateAsync(existingState);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProductsState(int id)
        {
            var state = await _productsStatesService.GetProductsStateByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            await _productsStatesService.DeleteProductsStateAsync(id);
            return NoContent();
        }
    }

}
