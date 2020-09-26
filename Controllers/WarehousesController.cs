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
    public class WarehousesController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public WarehousesController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouse()
        {
            return await _context.Warehouse.ToListAsync();
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var warehouse = await _context.Warehouse.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // PUT: api/Warehouses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(int id, Warehouse warehouse)
        {
            if (id != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            _context.Entry(warehouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
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

        // POST: api/Warehouses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            _context.Warehouse.Add(warehouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarehouse", new { id = warehouse.WarehouseId }, warehouse);
        }

        // DELETE: api/Warehouses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Warehouse>> DeleteWarehouse(int id)
        {
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouse.Remove(warehouse);
            await _context.SaveChangesAsync();

            return warehouse;
        }

        private bool WarehouseExists(int id)
        {
            return _context.Warehouse.Any(e => e.WarehouseId == id);
        }
    }
}
