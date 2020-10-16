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
    public class StoragesController : GenericController<Storage, StoragesRepository>
    {
        private readonly StoragesRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly WarehouseRepository _warehouseRepository;

        public StoragesController( 
            StoragesRepository repository,
            ProductRepository productRepository,
            WarehouseRepository warehouseRepository
            ) :base(repository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
        }

        // GET: api/Storages
        [HttpGet ( "Storages" )]
        public async Task<IEnumerable<Storage>> GetStorage()
        {
            return await _repository.GetStorages ();
        }

        // GET: api/Storages/5
        [HttpGet( "Storage/{id}" )]
        public async Task<ActionResult<Storage>> GetStorage(int id)
        {
          return await _repository.GetStorage (id);
        }

        // PUT: api/Storages/5
        [HttpPut( "Storage/{id}" )]
        public async Task<IActionResult> PutStorage ( int id, Storage storage)
        {

            var editStorage = await _repository.GetStorage ( id );

            editStorage.LastUpdate = storage.LastUpdate;
            editStorage.PartialQuantity = storage.PartialQuantity;
            editStorage.Product = storage.Product;
            editStorage.Warehouse = storage.Warehouse;

            var productId = _productRepository.GetProduct ( storage.Product.Id );

            var warehouseId = _warehouseRepository.GetWarehouse (storage.Warehouse.Id);

            editStorage.ProductId = productId.Id;
            editStorage.WarehouseId = warehouseId.Id;

            return (IActionResult)await _repository.Update ( editStorage );

        }

        // POST: api/Storages
        [HttpPost]
        public async Task<ActionResult<Storage>> PostStorage(Storage storage)
        {
            var newStorage = new Storage
            {
                LastUpdate = storage.LastUpdate,
                PartialQuantity = storage.PartialQuantity,
                ProductId = storage.ProductId,
                WarehouseId = storage.WarehouseId
            };

            return await _repository.Add ( newStorage );
        }
    }
}
