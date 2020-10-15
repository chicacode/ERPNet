using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
