using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/Orders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAllOrders()
        {
            var orders = await _ordersService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Orders>> GetOrdersById(int id)
        {
            var order = await _ordersService.GetOrdersByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrders([FromForm] int userId, int orderDetailsId, DateTime orderDate, int paymentId, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Orders order = new Orders
            {
                UserId = userId,
                OrderDetailsId = orderDetailsId,
                OrderDate = orderDate,
                PaymentId = paymentId,
                IsDeleted = isDeleted,
                users = null,
                Payments = null
            };

            await _ordersService.CreateOrdersAsync(order);
            return CreatedAtAction(nameof(GetOrdersById), new { id = order.OrderId }, order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrders(int id, [FromForm] int userId, int orderDetailsId, DateTime orderDate, int paymentId, bool isDeleted)
        {
            var existingOrder = await _ordersService.GetOrdersByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.UserId = userId;
            existingOrder.OrderDetailsId = orderDetailsId;
            existingOrder.OrderDate = orderDate;
            existingOrder.PaymentId = paymentId;
            existingOrder.IsDeleted = isDeleted;

            await _ordersService.UpdateOrdersAsync(existingOrder);
            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrders(int id)
        {
            var order = await _ordersService.GetOrdersByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _ordersService.DeleteOrdersAsync(id);
            return NoContent();
        }
    }

}
