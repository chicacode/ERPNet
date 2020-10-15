using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class StoragesRepository : GenericRepository<Storage, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public StoragesRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }
    }
}
