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
            // Retrieve all the customers by person
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


        //PUT: api/Customers/5
        [HttpPut ( "edit/{id}" )]
        public async Task<IActionResult> PutCustomer ( int id, Customer customer )
        {
            var personId = (await _repository.GetByPerson ( customer.Id )).Id;

            var person = new Person
            {
                Id = personId,
                Name = customer.Person.Name,
                LastName = customer.Person.LastName
            };

            var customerEdited = await _repository.GetCustomer ( customer.Id );

            customerEdited.Orders = customer.Orders;
            customerEdited.Person = customer.Person;


            return (IActionResult)await _repository.Update ( customerEdited );
        }

        // POST: api/Customers
        [HttpPost ( "person" )]
        public async Task<ActionResult<Customer>> PostCustomer ( Customer customer )
        {
            var newCustomer = await _repository.AddByPerson ( customer.Person );

            return CreatedAtAction ( "GetCustomer", new { id = customer.Id }, newCustomer );
        }

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
