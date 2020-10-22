using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        
        public ProductRepository ( ERPNetContext context
          ) : base( context )
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts ( )
        {
            return await _context.Product
                .ToListAsync ();
        }

        public async Task<Product> GetProduct ( int id )
        {
            var product = await _context.Product
                .SingleOrDefaultAsync ( p => p.Id == id );

            return product;
        }
    }
}
