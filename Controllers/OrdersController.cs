using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet ( "orders" )]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _repository.GetAll ();

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
        [HttpGet ( "order/{id}" )]
        public async Task<ActionResult<Order>> GetOrder ( int id)
        {
            var order = await _repository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost ( "orders" )]
        public async Task<ActionResult<Order>> PostOrder ( Order order )
        {
            var orderNew = new Order
            {
                OrderNumber = order.OrderNumber,
                OrderPriority = order.OrderPriority,
                OrderState = order.OrderState,
                CreationOrder = DateTime.Now,
                DoneByEmployeeOrder = DateTime.Now,
                CustomerId = (_customerRepository.Get ( order.Customer.Id )).Id,
                EmployeeId = (_employeeRepository.GetEmployee ( order.Employee.Id )).Id
            };

            return await _repository.Add ( orderNew );
        }

        // PUT: api/Orders/5
        [HttpPut( "order/{id}" )]
        public async Task<ActionResult<Order>> PutOrder (int id, Order order)
        {
            var orderEdited = await _repository.Get( id );

            orderEdited.OrderNumber = order.OrderNumber;
            orderEdited.OrderPriority = order.OrderPriority;
            orderEdited.OrderState = order.OrderState;
            orderEdited.CustomerId = order.CustomerId;
            orderEdited.EmployeeId = order.EmployeeId;

            return await _repository.Update ( orderEdited );
        }

    }
}
