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
    public class ProductsController : GenericController<Product, ProductRepository>
    {
        private readonly ProductRepository _repository;
        public ProductsController(ProductRepository repository ) : base (repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet ( "products" )]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetAll ();
        }

        // GET: api/Products/5
        [HttpGet( "product/{id}" )]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product = await _repository.Get (id);
              
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost("product")]
        public async Task<ActionResult<Product>> PostProduct ( Product product )
        {

            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                TotalQuantity = product.TotalQuantity,
                Price = product.Price,
                CategoryName = product.CategoryName
            };

            return await _repository.Add ( newProduct );
        }


        // PUT: api/Products/5
        [HttpPut ( "product/{id}" )]
        public async Task<ActionResult<Product>> PutProduct (  Product product)
        {
            var editProduct = await _repository.Get( product.Id);

            editProduct.Id = product.Id;
            editProduct.Name = product.Name;
            editProduct.Description = product.Description;
            editProduct.TotalQuantity = product.TotalQuantity;
            editProduct.Price = product.Price;
            editProduct.CategoryName = product.CategoryName;

            return await _repository.Update ( editProduct );
        }

        // DELETE: api/Products/5
        [HttpDelete( "product/{id}" )]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _repository.Get ( id );
            if (product == null)
            {
                return NotFound();
            }

            return await _repository.Delete ( product.Id );

        }

    }
}
