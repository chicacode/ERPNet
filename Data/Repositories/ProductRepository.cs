using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public ProductRepository ( ERPNetContext context ) : base( context )
        {
            _context = context;
        }

        public override async Task<List<Product>> GetAll ( )
        {
            return await _context.Product
                .ToListAsync ();
        }

        public override async Task<Product> Get ( int id )
        {
            var product = await _context.Product
                .SingleOrDefaultAsync ( p => p.Id == id );

            return product;
        }

        public async Task<Product> AddProduct ( Product product )
        {

            var newProduct = new Product ();

            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.TotalQuantity = product.TotalQuantity;
            newProduct.Price = product.Price;
            newProduct.CategoryName = product.CategoryName;
            _context.Set<Product> ().Add ( newProduct );
            await _context.SaveChangesAsync ();

            return newProduct;
        }
    }
}
