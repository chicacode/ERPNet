using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using Microsoft.AspNetCore.Cors;
using ERPNet.Data.Repositories;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : GenericController<Customer, CustomerRepository>
    {
        private readonly CustomerRepository _repository;

        public CustomersController( CustomerRepository repository ) : base (repository)
        {
            _repository = repository;
        }

        // GET: api/Customers
        [HttpGet ( "byperson" )]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customer = await _repository.GetAllCustomers ();

            return customer;
        }

        // GET: api/Customers/5
        [HttpGet( "person/{id}" )]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomer ( id );
             
            if(customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        //[HttpPut( "edit/{id}" )]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    var personId = (await _peopleRepository.GetPerson ( customer.Id )).Id;

        //    var person = new Person
        //    {
        //        Id = personId,
        //        Name = customer.Person.Name,
        //        LastName = customer.Person.LastName
        //    };

        //    return await _peopleController.EditPerson ( person );
        //}

        // POST: api/Customers
        //[HttpPost ( "person" )]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //   var person = (await _peopleRepository.GetPerson ( customer.Id ));

        //    if( person == null)
        //    {
        //        var personCustomer = new Person
        //        {
        //            Name = customer.Person.Name,
        //            LastName = customer.Person.LastName
        //        };

        //        await _peopleRepository.Add ( personCustomer );
        //    }
        //    else
        //    {
        //        person.Name = customer.Person.Name;
        //        person.LastName = customer.Person.LastName;

        //        await _peopleRepository.Update ( person );

        //    }
        //    //Fix latter
        //    var newCustomer = new Customer
        //    {
        //        PersonId = (await _peopleRepository.GetPersonName ( customer.Person.Name )).Id
        //    };

        //    return await _repository.Add ( newCustomer );
        //}

        // DELETE: api/Employees/5
        [HttpDelete ( "{id}" )]
        public async Task<ActionResult<Customer>> DeleteECustomer ( int id )
        {
            var customer = await _repository.Delete ( id );
            if(customer == null)
            {
                return NotFound ();
            }

            return customer;
        }

    }
}
