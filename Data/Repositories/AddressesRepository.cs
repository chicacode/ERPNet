using ERPNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class AddressesRepository : GenericRepository<Address, ERPNetContext>
    {
        private readonly ERPNetContext _context;

        public AddressesRepository ( ERPNetContext context ) : base( context )
        {
            _context = context;
        }
        public async Task<Address> GetAddress (int id )
        {
            return await _context.Address
                .SingleOrDefaultAsync ( a => a.Id == id );
        }
        public async Task<ActionResult<Address>> DeleteAddress ( [FromBody] int id )
        {
            var address = await _context.Address.FindAsync ( id );
  
            _context.Address.Remove ( address );
            await _context.SaveChangesAsync ();

            return address;
        }

    }
}
