using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class CategoriesRepository : GenericRepository<Category, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public CategoriesRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

        public int getCategoryById ( string name)
        {
            return _context.Category
                .FirstOrDefault ( p => p.Name == name )
                .Id;
        }
    }
}
