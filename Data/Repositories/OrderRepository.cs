using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly OrderProductRepository _orderProductRepository;
        public OrderRepository (
            ERPNetContext context,
            EmployeeRepository employeeRepository,
            CustomerRepository customerRepository,
            OrderProductRepository orderProductRepository
            ) : base ( context )
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<List<Order>> GetOrders ( )
        {
            return await _context.Order
                .Include ( o => o.Customer )
                .ThenInclude ( c => c.Person )
                .Include ( o => o.Employee )
                .ThenInclude ( e => e.Person )
                .Include ( o => o.Address )
                .Include ( o => o.OrderState )
                .Include ( o => o.OrderPriority )
                .Include ( o => o.Products )
                .ToListAsync ();
        }

        public async Task<List<Order>> GetOrdersByCustomer ( int customerId )
        {
            return await _context.Order
                .Include ( o => o.Customer )
                .ThenInclude ( c => c.Person )
                .Include ( o => o.Employee )
                .ThenInclude ( e => e.Person )
                .Include( o => o.Address)
                .Include ( o => o.OrderState )
                .Include ( o => o.OrderPriority )
                .Include ( o => o.Products )
                .Where( o => o.CustomerId == customerId )
                .ToListAsync ();
        }
     
        public async Task<List<Order>> GetOrdersByEmployee ( int employeeId )
        {
            return await _context.Order
                .Include ( o => o.Customer )
                .ThenInclude ( c => c.Person )
                .Include ( o => o.Employee )
                .ThenInclude ( e => e.Person )
                .Include ( o => o.Address )
                .Include ( o => o.OrderState )
                .Include ( o => o.OrderPriority )
                .Include ( o => o.Products )
                .Where ( o => o.EmployeeId == employeeId )
                .ToListAsync ();
        }
        public async Task<Order> GetOrder ( int id)
        {
            return await _context.Order
                .Include ( o => o.Customer )
                .ThenInclude ( c => c.Person )
                .Include ( o => o.Employee )
                .ThenInclude ( e => e.Person )
                .Include ( o => o.Address )
                .Include ( o => o.OrderState )
                .Include ( o => o.OrderPriority )
                .Include ( o => o.Products )
                .SingleOrDefaultAsync ( o => o.Id == id );
        }

    }
}
