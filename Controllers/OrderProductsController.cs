using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using ERPNet.Data.Repositories;

namespace ERPNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : GenericController<OrderProduct, OrderProductRepository>
    {
        private readonly OrderProductRepository _repository;

        public OrderProductsController( OrderProductRepository repository ) : base(repository)
        {
            _repository = repository;
        }

        // GET: api/OrderProducts
        [HttpGet ( "ordersproducts" )]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetOrderProducts()
        {
            var orderProducts = await _repository.GetOrderProducts ();

            return orderProducts;
        }


    }
}
