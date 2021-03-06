﻿using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<List<Order>> GetAll ()
        {
            return await _context.Order
                .Include ( o => o.Address )
                .Include( o => o.Customer )
                .Include( o => o.Employee )
                .Include ( o => o.Products )
                .ToListAsync ();
        }

        public override async Task<Order> Get ( int id )
        {
            return await _context.Order
                .Include ( o => o.Address )
                .Include ( o => o.Customer )
                .Include ( o => o.Employee )
                .SingleOrDefaultAsync ( e => e.Id == id );
        }
        public async Task<List<Order>> GetOrdersByCustomer ( int customerId )
        {
            return await _context.Order
                .Include ( o => o.Customer)
                .Include ( o => o.Address )
                .Include ( o => o.Products )
                .Where( o => o.CustomerId == customerId )
                .ToListAsync ();
        }
     
        public async Task<List<Order>> GetOrdersByEmployee ( int employeeId )
        {
            return await _context.Order
                .Include ( o => o.Employee )
                .Include ( o => o.Address )
                .Include ( o => o.Products )
                .Where ( o => o.EmployeeId == employeeId )
                .ToListAsync ();
        }

        public async Task<Order> AddOrder ( Order order )
        {
            var newOrder = new Order
            {
                OrderNumber = order.OrderNumber,
                OrderPriority = order.OrderPriority,
                OrderState = order.OrderState,
                CreationOrder = order.CreationOrder,
                DoneByEmployeeOrder = order.DoneByEmployeeOrder
            };
            newOrder.CreationOrder = order.CreationOrder;
            _context.Set<Order> ().Add ( newOrder );
            await _context.SaveChangesAsync ();

            return newOrder;
        }
    }
}
