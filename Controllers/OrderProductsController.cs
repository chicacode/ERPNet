
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ERPNet.Data;
using ERPNet.Models;
using ERPNet.Data.Repositories;
using Microsoft.AspNetCore.Cors;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
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
        [HttpGet ( "byitems" )]
        public async Task<IEnumerable<OrderProduct>> GetOrderProducts()
        {
            return await _repository.GetAll ();
        }
        // GET: api/Ordersproducts/5
        [HttpGet ( "Ordersproducts/{id}" )]
        public async Task<ActionResult<OrderProduct>> GetOrderProduct ( int id )
        {
            var orderP = await _repository.Get ( id );

            if(orderP == null)
            {
                return NotFound ();
            }

            return orderP;
        }

    }
}
