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
    public class MovementsController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public MovementsController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/Movements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movements>>> GetMovements()
        {
            return await _context.Movements.ToListAsync();
        }

        // GET: api/Movements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movements>> GetMovements(int id)
        {
            var movements = await _context.Movements.FindAsync(id);

            if (movements == null)
            {
                return NotFound();
            }

            return movements;
        }

        // PUT: api/Movements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovements(int id, Movements movements)
        {
            if (id != movements.Id)
            {
                return BadRequest();
            }

            _context.Entry(movements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementsExists(id))
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

        // POST: api/Movements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movements>> PostMovements(Movements movements)
        {
            _context.Movements.Add(movements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovements", new { id = movements.Id }, movements);
        }

        // DELETE: api/Movements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movements>> DeleteMovements(int id)
        {
            var movements = await _context.Movements.FindAsync(id);
            if (movements == null)
            {
                return NotFound();
            }

            _context.Movements.Remove(movements);
            await _context.SaveChangesAsync();

            return movements;
        }

        private bool MovementsExists(int id)
        {
            return _context.Movements.Any(e => e.Id == id);
        }
    }
}
