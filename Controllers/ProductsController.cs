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
    public class ProductsController : GenericController<Product, ProductRepository>
    {
        private readonly ProductRepository _repository;
        private readonly CategoriesRepository _categoryRepository;
        public ProductsController(
            ProductRepository repository,
            CategoriesRepository categoryRepository
            ) : base (repository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        // GET: api/Products
        [HttpGet ( "products" )]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetProducts ();
        }

        // GET: api/Products/5
        [HttpGet( "Product/{id}" )]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product = await _repository.GetProduct (id);
              
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut( "Product/{id}" )]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var editProduct = await _repository.GetProduct ( product.Id);

            // edit each property
            editProduct.Name = product.Name;
            editProduct.Description = product.Description;
            editProduct.TotalQuantity = product.TotalQuantity;

            var categoryId = _categoryRepository.getCategoryById ( product.Category.Name );

            editProduct.CategoryId = categoryId;

            return (IActionResult)await _repository.Update ( editProduct );
        }

        // POST: api/Products

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            var categoryId = _categoryRepository.getCategoryById ( product.Category.Name );
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                TotalQuantity = product.TotalQuantity,
                CategoryId = categoryId
            };

           return await _repository.Add ( newProduct );
        }

        // DELETE: api/Products/5
        [HttpDelete( "Product/{id}" )]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _repository.GetProduct ( id );
            if (product == null)
            {
                return NotFound();
            }

            return await _repository.Delete ( product.Id );

        }

    }
}
