using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using Microsoft.AspNetCore.Cors;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public StoragesController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/Storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetStorage()
        {
            return await _context.Storage
                .Include( s => s.Product )
                .Include ( s => s.Product.Category )
                .Include ( s => s.Warehouse )
                .Include( s => s.Warehouse.Address )
                .ToListAsync();
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStorage(int id)
        {
            //var storage = await _context.Storage.FindAsync(id);

            var storage = await _context.Storage
              .Include ( s => s.Product )
              .Include ( s => s.Product.Category )
              .Include ( s => s.Warehouse )
              .Include ( s => s.Warehouse.Address )
              .SingleOrDefaultAsync ( s => s.Id == id );

            if (storage == null)
            {
                return NotFound();
            }

            return storage;
        }

        // PUT: api/Storages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage(int id, Storage storage)
        {
            if (id != storage.Id)
            {
                return BadRequest();
            }

            var editStorage = await _context.Storage.FindAsync ( id );

            if(editStorage == null)
            {
                return NotFound ();
            }
            // edit each property
            editStorage.LastUpdate = storage.LastUpdate;
            editStorage.PartialQuantity = storage.PartialQuantity;
            editStorage.Product = storage.Product;
            editStorage.Warehouse = storage.Warehouse;

            var productId = _context.Product
                .FirstOrDefault ( p => p.Name == storage.Product.Name)
                .Id;

            var warehouseId = _context.Warehouse
               .FirstOrDefault ( w => w.Name == storage.Warehouse.Name )
               .Id;

            editStorage.ProductId = productId;
            editStorage.WarehouseId = warehouseId;

            _context.Entry ( editStorage ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
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

        // POST: api/Storages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Storage>> PostStorage(Storage storage)
        {

            var newStorage = new Storage
            {
                LastUpdate = storage.LastUpdate,
                PartialQuantity = storage.PartialQuantity,
                ProductId = storage.ProductId,
                WarehouseId = storage.WarehouseId
            };

            _context.Storage.Add ( newStorage );
            await _context.SaveChangesAsync ();

            return CreatedAtAction("GetStorage", new { id = storage.Id }, newStorage );
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Storage>> DeleteStorage(int id)
        {
            var storage = await _context.Storage.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }

            _context.Storage.Remove(storage);
            await _context.SaveChangesAsync();

            return storage;
        }

        private bool StorageExists(int id)
        {
            return _context.Storage.Any(e => e.Id == id);
        }
    }
}
