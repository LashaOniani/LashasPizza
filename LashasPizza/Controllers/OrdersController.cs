using LashasPizza.Data;
using LashasPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LashasPizza.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder(Orders order)
        {
            _context.Orderss.Add(order);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOrder(Orders order)
        {
            var existingOrder = _context.Orderss.SingleOrDefault(o => o.Id == order.Id);
            if (existingOrder == null)
            {
                return NotFound($"Order with id {order.Id} not found");
            }
            existingOrder.OrderStatus = order.OrderStatus;

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _context.Orderss.SingleOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with id {id} not found");
            }
            return Ok(order);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrdersByCustomerId(int id)
        {
            if (id <= 0) return BadRequest("Invalid order ID");
            var orders = _context.Orderss.Where(o => o.CustomerId == id).ToList();
            if (orders == null || orders.Count == 0)
            {
                return NotFound($"No orders found for customer with id {id}");
            }
            return Ok(orders);
        }
    }
}
