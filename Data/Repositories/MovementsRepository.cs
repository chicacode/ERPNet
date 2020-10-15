using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class MovementsRepository : GenericRepository<Movements, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public MovementsRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }
    }
}
