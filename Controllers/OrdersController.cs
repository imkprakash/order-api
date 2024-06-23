
// OrdersController.cs
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<List<OrderItem>> ordersHistory = new List<List<OrderItem>>();

        // POST: api/orders
        [HttpPost]
        public IActionResult PostOrder([FromBody] List<OrderItem> orderItems)
        {
            if (orderItems == null || orderItems.Count == 0)
            {
                return BadRequest("Order items are null or empty");
            }

            // Add received order items to ordersHistory
            ordersHistory.Add(orderItems);

            // Assuming the client application needs a response (e.g., order confirmation)
            return Ok("Order received successfully");
        }

        // GET: api/orders/last
        [HttpGet("last")]
        public IActionResult GetLastOrder()
        {
            if (ordersHistory.Count == 0)
            {
                return NotFound("No orders found");
            }

            var lastOrder = ordersHistory.Last();
            return Ok(lastOrder);
        }
    }
}
