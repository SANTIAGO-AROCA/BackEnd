using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        // GET: api/Payments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Payments>>> GetAllPayments()
        {
            var payments = await _paymentsService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // GET: api/Payments/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Payments>> GetPaymentById(int id)
        {
            var payment = await _paymentsService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        // POST: api/Payments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePayment([FromForm] int paymentType, int accountId,
            int paymentMethodTypeId, DateTime payDate, int paymentState, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payments payment = new Payments
            {
                PaymentType = paymentType,
                AccountId = accountId,
                PaymentMethodTypeID = paymentMethodTypeId,
                PayDate = payDate,
                PaymentState = paymentState,
                IsDeleted = isDeleted,
                PaymentStates = null, // Set navigation property if necessary
                PaymentMethodsTypes = null // Set navigation property if necessary
            };

            await _paymentsService.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentId }, payment);
        }

        // PUT: api/Payments/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePayment(int id, [FromForm] int paymentType, int accountId,
            int paymentMethodTypeId, DateTime payDate, int paymentState, bool isDeleted)
        {
            var existingPayment = await _paymentsService.GetPaymentByIdAsync(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            existingPayment.PaymentType = paymentType;
            existingPayment.AccountId = accountId;
            existingPayment.PaymentMethodTypeID = paymentMethodTypeId;
            existingPayment.PayDate = payDate;
            existingPayment.PaymentState = paymentState;
            existingPayment.IsDeleted = isDeleted;

            await _paymentsService.UpdatePaymentAsync(existingPayment);
            return NoContent();
        }

        // DELETE: api/Payments/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePayment(int id)
        {
            var payment = await _paymentsService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _paymentsService.DeletePaymentAsync(id);
            return NoContent();
        }
    }

}
