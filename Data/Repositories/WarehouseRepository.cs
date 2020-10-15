using ERPNet.Models;
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
    }
}
