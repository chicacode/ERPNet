using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class AddressesRepository : GenericRepository<Address, ERPNetContext>
    {
        private readonly ERPNetContext _context;

        public AddressesRepository ( ERPNetContext context ) :base(context)
        {
            _context = context;
        }

        public async Task<Address> GetAddress (int id )
        {
            return await _context.Address
                .SingleOrDefaultAsync ( a => a.Id == id );
        }


    }
}
