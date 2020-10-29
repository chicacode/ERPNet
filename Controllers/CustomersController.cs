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

        // POST: api/Customers
        [HttpPost ( "customer" )]
        public async Task<ActionResult<Customer>> PostCustomer ( Customer customer )
        {
            var newCustomer = await _repository.AddCustomer ( customer );

            return CreatedAtAction ( "GetCustomer", new { id = customer.Id }, newCustomer );
        }

        //PUT: api/Customers/5
        [HttpPut ( "edit/{id}" )]
        public async Task<ActionResult<Customer>> EditCustomer ( Customer customer )
        {
            var customerEdited = await _repository.Get ( customer.Id );

            customerEdited.Id = customer.Id;
            customerEdited.Name = customer.Name;
            customerEdited.LastName = customer.LastName;
            customerEdited.PhoneNumber = customer.PhoneNumber;
            customerEdited.Email = customer.Email;
            
            return await _repository.Update ( customerEdited );
        }

        // DELETE: api/customer/5
        [HttpDelete ( "customer/{id}" )]
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
