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
    public class WarehousesController : GenericController<Warehouse, WarehouseRepository>
    {
        private readonly WarehouseRepository _repository;
        private readonly AddressesRepository _addressRepository;

        public WarehousesController(
            WarehouseRepository repository,
            AddressesRepository addressRepository
            ) :base (repository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            var warehouses = await _repository.GetWareHouses ();

            return warehouses;
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var warehouse = await _repository.GetWarehouse ( id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // PUT: api/Warehouses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Warehouse>> PutWarehouse(int id, Warehouse warehouse)
        {
            var wareEdited = await _repository.GetWarehouse ( id );
            var addressId = (await _addressRepository.GetAddress ( warehouse.Id )).Id;
            wareEdited.Name = warehouse.Name;
            wareEdited.AddressId = addressId;

            return await _repository.Update ( wareEdited );
        }
       
    }
}
