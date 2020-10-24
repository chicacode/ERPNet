using ERPNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public override async Task<List<Address>> GetAll ()
        {
            return await _context.Address
                .ToListAsync ();
        }

        public override async Task<Address> Get ( int id )
        {
            return await _context.Address
                .SingleOrDefaultAsync ( a => a.Id == id );
        }

        public async Task<Address> AddAddress ( Address address )
        {
            var newAddress = new Address ();

            newAddress.AddressNumber = address.AddressNumber;
            newAddress.AddressStreet = address.AddressStreet;
            newAddress.AddressContactName = address.AddressContactName;
            newAddress.AddressZipCode = address.AddressZipCode;
            newAddress.AddressCity = address.AddressCity;
            newAddress.AddressCountry = address.AddressCountry;

            _context.Set<Address> ().Add ( newAddress );
            await _context.SaveChangesAsync ();

            return newAddress;
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
