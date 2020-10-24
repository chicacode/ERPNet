using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public OrderProductRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

        public override async Task<List<OrderProduct>> GetAll()
        {
            return await _context.OrderProduct
                .Include ( o => o.Order )
                .Include ( o => o.Product )
                .ToListAsync ();
        }
    }
}
