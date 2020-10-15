using ERPNet.Models;
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
    }
}
