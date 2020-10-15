using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public OrderRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

    }
}
