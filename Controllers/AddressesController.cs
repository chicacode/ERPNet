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
    public class AddressesController : GenericController<Address, AddressesRepository>
    {
        private readonly ERPNetContext _context;
        private readonly AddressesRepository _repository;

        public AddressesController( ERPNetContext context, AddressesRepository repository ): base(repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(int id, Address address)
        {

            var addressEdited = await _repository.GetAddress ( address.Id );

            addressEdited.Id = address.Id;
            addressEdited.AddressNumber = address.AddressNumber;
            addressEdited.AddressStreet = address.AddressStreet;
            addressEdited.AddressContactName = address.AddressContactName;
            addressEdited.AddressZipCode = address.AddressZipCode;
            addressEdited.AddressCity = address.AddressCity;
            addressEdited.AddressCountry = address.AddressCountry;


            if(id != address.Id)
            {
                return BadRequest();
            }

           await _repository.Update ( addressEdited );

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress ( Address address )
        {

            var newAddress = new Address
            {
                Id = address.Id,
                AddressNumber = address.AddressNumber,
                AddressStreet = address.AddressStreet,
                AddressContactName = address.AddressContactName,
                AddressZipCode = address.AddressZipCode,
                AddressCity = address.AddressCity,
                AddressCountry = address.AddressCountry

            };

           return await _repository.Add ( newAddress );
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public Task<ActionResult<Address>> DeleteAddress ( int id)
        {
            return _repository.DeleteAddress ( id );
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
