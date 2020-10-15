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
    public class PeopleController : GenericController<Person, PeopleRepository>
    {
        private readonly PeopleRepository _repository;

        public PeopleController ( PeopleRepository repository ) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> EditPerson( Person personEd )
        {

            var person = await _repository.GetPerson ( personEd.Id );
            person.Name = personEd.Name;
            person.LastName = personEd.LastName;

            var updatePerson = await _repository.Update ( person );

            return (IActionResult)updatePerson;
            //_context.Entry(person).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

    }
}
