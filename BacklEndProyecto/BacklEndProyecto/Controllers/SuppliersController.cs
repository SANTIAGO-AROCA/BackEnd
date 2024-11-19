using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Suppliers>>> GetAllSuppliers()
        {
            var suppliers = await _suppliersService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Suppliers>> GetSupplierById(int id)
        {
            var supplier = await _suppliersService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSupplier([FromBody] string sName, string sDescription,
            string sState, string sAddress, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Suppliers supplier = new Suppliers
            {
                SupplierName = sName,
                SupplierDescription = sDescription,
                SupplierAddress = sAddress,
                SupplierState = sState,
                SupplierStates = null,
                IsDeleted = isDeleted 
            };

            await _suppliersService.CreateSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.SupplierId }, supplier);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] string sName, string sDescription,
            string sState, string sAddress, bool isDeleted)
        {
            var existingSupplier = await _suppliersService.GetSupplierByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }

            existingSupplier.SupplierName = sName;
            existingSupplier.SupplierDescription = sDescription;
            existingSupplier.SupplierState = sState;
            existingSupplier.SupplierAddress = sAddress;
            existingSupplier.IsDeleted = isDeleted;

            await _suppliersService.UpdateSupplierAsync(existingSupplier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteSupplier(int id)
        {
            var supplier = await _suppliersService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            await _suppliersService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }

}
