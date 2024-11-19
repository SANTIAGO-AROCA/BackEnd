using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatesController : ControllerBase
    {
        private readonly IPaymentStatesService _paymentStatesService;

        public PaymentStatesController(IPaymentStatesService paymentStatesService)
        {
            _paymentStatesService = paymentStatesService;
        }

        // GET: api/PaymentStates
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PaymentStates>>> GetAllPaymentStates()
        {
            var paymentStates = await _paymentStatesService.GetAllPaymentStatesAsync();
            return Ok(paymentStates);
        }

        // GET: api/PaymentStates/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentStates>> GetPaymentStateById(int id)
        {
            var paymentState = await _paymentStatesService.GetPaymentStateByIdAsync(id);
            if (paymentState == null)
            {
                return NotFound();
            }
            return Ok(paymentState);
        }

        // POST: api/PaymentStates
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePaymentState([FromBody] PaymentStates paymentState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _paymentStatesService.CreatePaymentStateAsync(paymentState);
            return CreatedAtAction(nameof(GetPaymentStateById), new { id = paymentState.PaymentStateId }, paymentState);
        }

        // PUT: api/PaymentStates/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePaymentState(int id, [FromBody] PaymentStates paymentState)
        {
            if (id != paymentState.PaymentStateId)
            {
                return BadRequest();
            }

            var existingPaymentState = await _paymentStatesService.GetPaymentStateByIdAsync(id);
            if (existingPaymentState == null)
            {
                return NotFound();
            }

            existingPaymentState.PaymentStateDescription = paymentState.PaymentStateDescription;
            existingPaymentState.PaymentStatesName = paymentState.PaymentStatesName;
            existingPaymentState.IsDeleted = paymentState.IsDeleted;

            await _paymentStatesService.UpdatePaymentStateAsync(existingPaymentState);
            return NoContent();
        }

        // DELETE: api/PaymentStates/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePaymentState(int id)
        {
            var paymentState = await _paymentStatesService.GetPaymentStateByIdAsync(id);
            if (paymentState == null)
            {
                return NotFound();
            }

            await _paymentStatesService.DeletePaymentStateAsync(id);
            return NoContent();
        }
    }

}
