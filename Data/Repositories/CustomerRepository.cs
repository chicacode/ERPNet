using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        private readonly PeopleRepository _peopleRepository;

        public CustomerRepository ( 
            ERPNetContext context,
            PeopleRepository peopleRepository
            ) : base(context)
        {
            _context = context;
            _peopleRepository = peopleRepository;
        }


        public async Task<List<Customer>> GetAllCustomers ( )
        {
            return await _context.Customer
                .Include ( e => e.Person )
                .ToListAsync ();
        }
        public async Task<Customer> GetCustomer ( int id )
        {
            return await _context.Customer
                .Include ( e => e.Person )
                .SingleOrDefaultAsync ( e => e.Id == id );
        }
        public async Task<Customer> GetByPerson ( int id )
        {
            return await _context.Customer
                .Include ( e => e.Person )
                .SingleOrDefaultAsync ( e => e.PersonId == id );
        }

        public async Task<Customer> AddByPerson ( Person customer )
        {
            Person person = new Person ();

            person.Name = customer.Name;
            person.LastName = customer.LastName;


            _context.Set<Person> ().Add ( person );
            await _context.SaveChangesAsync ();


            var newCustomer = new Customer ();

            newCustomer.Id = customer.Customer.Id;
            newCustomer.PersonId = customer.Customer.PersonId;
 
            _context.Set<Customer> ().Add ( newCustomer );
            await _context.SaveChangesAsync ();


            return newCustomer;
        }
        public int GetCustomerByPersonId ( int customerId )
        {
            var personId = _peopleRepository.GetPerson ( customerId );

            return _context.Customer
                .FirstOrDefault ( x => x.PersonId == customerId )
                .Id;
        }
    }
}
