using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class PeopleRepository : GenericRepository<Person, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public PeopleRepository ( ERPNetContext context ) : base ( context )
        {
            _context = context;
        }

        public async Task<Person> GetPerson ( int id )
        {
            return await _context.Person
                .SingleOrDefaultAsync ( p => p.Id == id );
        }

        public async Task<Person> GetPersonName ( string name )
        {
            return await _context.Person
               .SingleOrDefaultAsync ( p => p.Name == name );

        }

    }
}
