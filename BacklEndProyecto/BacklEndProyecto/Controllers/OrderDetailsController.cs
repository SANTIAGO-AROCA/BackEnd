using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: api/OrderDetails
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailsService.GetAllOrderDetailsAsync();
            return Ok(orderDetails);
        }

        // GET: api/OrderDetails/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetails>> GetOrderDetailsById(int id)
        {
            var orderDetails = await _orderDetailsService.GetOrderDetailsByIdAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        // POST: api/OrderDetails
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrderDetails([FromForm] int productId, int productQuantity, string details, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderDetails orderDetails = new OrderDetails
            {
                ProductId = productId,
                ProductQuantity = productQuantity,
                Details = details,
                IsDeleted = isDeleted,
                Produts = null
            };

            await _orderDetailsService.CreateOrderDetailsAsync(orderDetails);
            return CreatedAtAction(nameof(GetOrderDetailsById), new { id = orderDetails.OrderDetailsId }, orderDetails);
        }

        // PUT: api/OrderDetails/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderDetails(int id, [FromForm] int productId, int productQuantity, string details, bool isDeleted)
        {
            var existingOrderDetails = await _orderDetailsService.GetOrderDetailsByIdAsync(id);
            if (existingOrderDetails == null)
            {
                return NotFound();
            }

            existingOrderDetails.ProductId = productId;
            existingOrderDetails.ProductQuantity = productQuantity;
            existingOrderDetails.Details = details;
            existingOrderDetails.IsDeleted = isDeleted;

            await _orderDetailsService.UpdateOrderDetailsAsync(existingOrderDetails);
            return NoContent();
        }

        // DELETE: api/OrderDetails/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderDetails(int id)
        {
            var orderDetails = await _orderDetailsService.GetOrderDetailsByIdAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            await _orderDetailsService.DeleteOrderDetailsAsync(id);
            return NoContent();
        }
    }

}
