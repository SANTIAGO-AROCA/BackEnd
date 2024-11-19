using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersStatesController : ControllerBase
    {
        private readonly ISuppliersStatesService _suppliersStatesService;

        public SuppliersStatesController(ISuppliersStatesService suppliersStatesService)
        {
            _suppliersStatesService = suppliersStatesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SuppliersStates>>> GetAllSuppliersStates()
        {
            var suppliersStates = await _suppliersStatesService.GetAllSuppliersStatesAsync();
            return Ok(suppliersStates);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SuppliersStates>> GetSuppliersStateById(int id)
        {
            var suppliersState = await _suppliersStatesService.GetSuppliersStateByIdAsync(id);
            if (suppliersState == null)
            {
                return NotFound();
            }
            return Ok(suppliersState);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSuppliersState([FromBody] SuppliersStates suppliersState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _suppliersStatesService.CreateSuppliersStateAsync(suppliersState);
            return CreatedAtAction(nameof(GetSuppliersStateById), new { id = suppliersState.SupplierStateId }, suppliersState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSuppliersState(int id, [FromBody] SuppliersStates suppliersState)
        {
            var existingSuppliersState = await _suppliersStatesService.GetSuppliersStateByIdAsync(id);
            if (existingSuppliersState == null)
            {
                return NotFound();
            }

            existingSuppliersState.SupplierState = suppliersState.SupplierState;
            existingSuppliersState.SupplierStateDescription = suppliersState.SupplierStateDescription;
            existingSuppliersState.IsDeleted = suppliersState.IsDeleted;

            await _suppliersStatesService.UpdateSuppliersStateAsync(existingSuppliersState);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSuppliersState(int id)
        {
            var suppliersState = await _suppliersStatesService.GetSuppliersStateByIdAsync(id);
            if (suppliersState == null)
            {
                return NotFound();
            }

            await _suppliersStatesService.DeleteSuppliersStateAsync(id);
            return NoContent();
        }
    }

}
