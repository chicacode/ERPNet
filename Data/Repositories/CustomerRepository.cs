using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, ERPNetContext>
    {
        private readonly ERPNetContext _context;
    
        public CustomerRepository ( ERPNetContext context ) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Customer>> GetAll ( )
        {
            return await _context.Customer
                 .ToListAsync ();
        }
        public override async Task<Customer> Get ( int id )
        {
            return await _context.Customer
                .SingleOrDefaultAsync ( e => e.Id == id );
        }


        public async Task<Customer> AddCustomer ( Customer customer )
        {
         
            var newCustomer = new Customer ();

            newCustomer.Name = customer.Name;
            newCustomer.LastName = customer.LastName;
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.Email = customer.Email;
            _context.Set<Customer> ().Add ( newCustomer );
            await _context.SaveChangesAsync ();

            return newCustomer;
        }

    }
}
