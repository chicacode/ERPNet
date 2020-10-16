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
    public class OrdersController : GenericController<Order, OrderRepository>
    {
        private readonly OrderRepository _repository;
        private readonly CustomerRepository _customerRepository;
        private readonly EmployeeRepository _employeeRepository;
        public OrdersController( 
            OrderRepository repository,
            CustomerRepository customerRepository,
            EmployeeRepository employeeRepository
            ) : base ( repository )
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _repository.GetOrders ();

            return orders;
        }

        [Route("customer")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrdersByCustomer ( int customerId)
        {
            var orders = await _repository.GetOrdersByCustomer ( customerId );

            return orders;
        }

        [Route ( "employee" )]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrdersByEmployee ( int employeeId )
        {
            var orders = await _repository.GetOrdersByEmployee ( employeeId );

            return orders;
        }

        // GET: api/Orders/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<Order>> GetOrder ( int id)
        {
            var order = await _repository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            var orderEdited = await _repository.GetOrder ( id );

            orderEdited.OrderNumber = order.OrderNumber;
            orderEdited.OrderPriority = order.OrderPriority;
            orderEdited.OrderState = order.OrderState;
            orderEdited.CustomerId = _customerRepository.GetCustomerByPersonId ( order.Customer.Person.Id);
            orderEdited.EmployeeId = _employeeRepository.GetEmployeeId ( order.Employee.Person.Id );

            return (IActionResult)await _repository.Update ( orderEdited );
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder ( Order order )
        {
            var orderNew = new Order
            {
                OrderNumber = order.OrderNumber,
                OrderPriority = order.OrderPriority,
                OrderState = order.OrderState,
                CreationOrder = DateTime.Now,
                DoneByEmployeeOrder = DateTime.Now,
                CustomerId = _customerRepository.GetCustomerByPersonId ( order.Customer.Person.Id ),
                EmployeeId = _employeeRepository.GetEmployeeId ( order.Employee.Person.Id )
            };

            return await _repository.Add ( orderNew );
        }
    }
}
