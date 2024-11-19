using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsTypesController : ControllerBase
    {
        private readonly IPaymentMethodsTypesService _paymentMethodsService;

        public PaymentMethodsTypesController(IPaymentMethodsTypesService paymentMethodsService)
        {
            _paymentMethodsService = paymentMethodsService;
        }

        // GET: api/PaymentMethodsTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PaymentMethodsTypes>>> GetAllPaymentMethods()
        {
            var paymentMethods = await _paymentMethodsService.GetAllPaymentMethodsAsync();
            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethodsTypes/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentMethodsTypes>> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        // POST: api/PaymentMethodsTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePaymentMethod([FromForm] string paymentMethodName, string paymentMethodDescription, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentMethodsTypes paymentMethod = new PaymentMethodsTypes
            {
                PaymentMethodName = paymentMethodName,
                PaymentMethodDescription = paymentMethodDescription,
                IsDeleted = isDeleted
            };

            await _paymentMethodsService.CreatePaymentMethodAsync(paymentMethod);
            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = paymentMethod.PaymentMethodId }, paymentMethod);
        }

        // PUT: api/PaymentMethodsTypes/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePaymentMethod(int id, [FromForm] string paymentMethodName, string paymentMethodDescription, bool isDeleted)
        {
            var existingPaymentMethod = await _paymentMethodsService.GetPaymentMethodByIdAsync(id);
            if (existingPaymentMethod == null)
            {
                return NotFound();
            }

            existingPaymentMethod.PaymentMethodName = paymentMethodName;
            existingPaymentMethod.PaymentMethodDescription = paymentMethodDescription;
            existingPaymentMethod.IsDeleted = isDeleted;

            await _paymentMethodsService.UpdatePaymentMethodAsync(existingPaymentMethod);
            return NoContent();
        }

        // DELETE: api/PaymentMethodsTypes/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePaymentMethod(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            await _paymentMethodsService.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }

}
