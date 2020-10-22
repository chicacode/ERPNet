using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;
        public OrderProductRepository ( 
            ERPNetContext context,
            OrderRepository orderRepository,
            ProductRepository productRepository
            ) : base ( context )
        {
            _context = context;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderProduct>> GetOrderProducts ( )
        {
            return await _context.OrderProduct
                .Include ( o => o.Order )
                .Include ( o => o.Product )
                .Include ( o => o.PriceItem )
                .Include ( o => o.PriceItemIva )
                .Include ( o => o.TotalPrice )
                .ToListAsync ();
        }
    }
}
