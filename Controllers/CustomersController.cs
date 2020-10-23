using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _repository.GetAll ();
        }

        // GET: api/Customers/5
        [HttpGet ( "customer/{id}" )]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _repository.Get( id );
             
            if(customer == null)
            {
                return NotFound();
            }

            return customer;
        }


        //PUT: api/Customers/5
        [HttpPut ( "edit/{id}" )]
        //public async Task<IActionResult> PutCustomer ( int id, Customer customer )
        //{
        //    //var personId = (await _repository.GetByPerson ( customer.Id )).Id;

        //    //var person = new Person
        //    //{
        //    //    Id = personId,
        //    //    Name = customer.Person.Name,
        //    //    LastName = customer.Person.LastName
        //    //};

        //    //var customerEdited = await _repository.GetCustomer ( customer.Id );

        //    //customerEdited.Orders = customer.Orders;
        //    ////customerEdited.Person = customer.Person;


        //    //return (IActionResult)await _repository.Update ( customerEdited );
        //}

        // POST: api/Customers
        [HttpPost ( "customer" )]
        public async Task<ActionResult<Customer>> PostCustomer ( Customer customer )
        {
            var newCustomer = await _repository.Add ( customer);

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
