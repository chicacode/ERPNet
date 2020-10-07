using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;

namespace ERPNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public OrderProductsController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/OrderProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetOrderProduct()
        {
            return await _context.OrderProduct.ToListAsync();
        }

        // GET: api/OrderProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProduct>> GetOrderProduct(int id)
        {
            var orderProduct = await _context.OrderProduct.FindAsync(id);

            if (orderProduct == null)
            {
                return NotFound();
            }

            return orderProduct;
        }

        // PUT: api/OrderProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderProduct(int id, OrderProduct orderProduct)
        {
            if (id != orderProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderProductExists(id))
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

        // POST: api/OrderProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderProduct>> PostOrderProduct(OrderProduct orderProduct)
        {
            _context.OrderProduct.Add(orderProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderProduct", new { id = orderProduct.Id }, orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderProduct>> DeleteOrderProduct(int id)
        {
            var orderProduct = await _context.OrderProduct.FindAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            _context.OrderProduct.Remove(orderProduct);
            await _context.SaveChangesAsync();

            return orderProduct;
        }

        private bool OrderProductExists(int id)
        {
            return _context.OrderProduct.Any(e => e.Id == id);
        }
    }
}
