using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class StoragesRepository : GenericRepository<Storage, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        private readonly ProductRepository _productRepository;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly MovementsRepository _movementsRepository;
        public StoragesRepository ( 
            ERPNetContext context,
            ProductRepository productRepository,
            WarehouseRepository warehouseRepository,
            MovementsRepository movementsRepository
            ) : base ( context )
        {
            _context = context;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _movementsRepository = movementsRepository;
        }

        public async Task<List<Storage>> GetStorages ( )
        {
            return await _context.Storage
                .Include ( s => s.Product )
                .Include ( s => s.Product.Category )
                .Include ( s => s.Warehouse )
                .Include ( s => s.Warehouse.Address )
                .Include ( s => s.InputOutputs )
                .ToListAsync ();
        }

        public async Task<Storage> GetStorage ( int id )
        {
            var storage = await _context.Storage
              .Include ( s => s.Product )
              .Include ( s => s.Product.Category )
              .Include ( s => s.Warehouse )
              .Include ( s => s.Warehouse.Address )
               .Include ( s => s.InputOutputs )
              .SingleOrDefaultAsync ( s => s.Id == id );

            return storage;
        }
    }
}
