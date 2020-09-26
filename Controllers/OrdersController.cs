using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using EmployeeWebMySQL.Models;
using Microsoft.AspNetCore.Cors;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public OrdersController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
