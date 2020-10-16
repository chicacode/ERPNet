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
        private readonly CategoriesRepository _categoryRepository;
        
        public ProductRepository ( ERPNetContext context, 
            CategoriesRepository categoryRepository ) : base( context )
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Product>> GetProducts ( )
        {
            return await _context.Product
                .Include ( p => p.Category )
                .ToListAsync ();
        }

        public async Task<Product> GetProduct ( int id )
        {
            var product = await _context.Product
                .Include ( p => p.Category )
                .SingleOrDefaultAsync ( p => p.Id == id );

            return product;
        }
    }
}
