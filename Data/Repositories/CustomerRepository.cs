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
        //public async Task<Customer> GetByPerson ( int id )
        //{
        //    return await _context.Customer
               
        //        .SingleOrDefaultAsync ( e => e.PersonId == id );
        //}

        //public async Task<Customer> AddByPerson ( Person customer )
        //{
        //    Person person = new Person ();

        //    person.Name = customer.Name;
        //    person.LastName = customer.LastName;


        //    _context.Set<Person> ().Add ( person );
        //    await _context.SaveChangesAsync ();


        //    var newCustomer = new Customer ();

        //    newCustomer.Id = customer.Customer.Id;
        //    newCustomer.PersonId = customer.Customer.PersonId;
 
        //    _context.Set<Customer> ().Add ( newCustomer );
        //    await _context.SaveChangesAsync ();


        //    return newCustomer;
        //}
        //public int GetCustomerByPersonId ( int customerId )
        //{
        //    var personId = _peopleRepository.GetPerson ( customerId );

        //    return _context.Customer
        //        .FirstOrDefault ( x => x.PersonId == customerId )
        //        .Id;
        //}
    }
}
