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
    public class AddressesController : GenericController<Address, AddressesRepository>
    {
        private readonly AddressesRepository _repository;

        public AddressesController( AddressesRepository repository ): base(repository)
        {
            _repository = repository;
        }

        // POST: api/Addresses
        [HttpPost ( "address" )]
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

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Address>> EditAddress( Address address)
        {

            var addressEdited = await _repository.Get ( address.Id );

            addressEdited.Id = address.Id;
            addressEdited.AddressNumber = address.AddressNumber;
            addressEdited.AddressStreet = address.AddressStreet;
            addressEdited.AddressContactName = address.AddressContactName;
            addressEdited.AddressZipCode = address.AddressZipCode;
            addressEdited.AddressCity = address.AddressCity;
            addressEdited.AddressCountry = address.AddressCountry;

            return await _repository.Update ( addressEdited );
        
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public Task<ActionResult<Address>> DeleteAddress ( int id)
        {
            return _repository.DeleteAddress ( id );
        }

    }
}
