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

        public OrderRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders ( )
        {
            return await _context.Order
                .Include ( o => o.Customer.Person)
                //.Include ( o => o.Employee.Person.Employee.Id )
                .Include ( o => o.Address)
                //.Include ( o => o.OrderState )
               // .Include ( o => o.OrderPriority )
                .Include ( o => o.Products )
                .ToListAsync ();
        }

        public async Task<List<Order>> GetOrdersByCustomer ( int customerId )
        {
            return await _context.Order
                .Include ( o => o.Customer.Person )
                .Include ( o => o.Address )
                .Include ( o => o.Products )
                .Where( o => o.CustomerId == customerId )
                .ToListAsync ();
        }
     
        public async Task<List<Order>> GetOrdersByEmployee ( int employeeId )
        {
            return await _context.Order
                .Include ( o => o.Employee.Person )
                .Include ( o => o.Address )
                .Include ( o => o.Products )
                .Where ( o => o.EmployeeId == employeeId )
                .ToListAsync ();
        }
        public async Task<Order> GetOrder ( int id)
        {
            return await _context.Order
                .Include ( o => o.Customer )
                .Include ( o => o.Address )
                .Include ( o => o.Products )
                .SingleOrDefaultAsync ( o => o.Id == id );
        }

    }
}
