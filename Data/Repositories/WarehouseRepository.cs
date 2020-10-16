using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public WarehouseRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

        public async Task<List<Warehouse>> GetWareHouses ( )
        {
            return await _context.Warehouse
              .Include ( s => s.Address )
              .ToListAsync ();
        }

        public async Task<Warehouse> GetWarehouse ( int id )
        {
            var warehouse = await _context.Warehouse.FindAsync ( id );

            return warehouse;
        }



    }
}
