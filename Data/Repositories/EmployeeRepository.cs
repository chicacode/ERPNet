using ERPNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, ERPNetContext>
    {
        private readonly ERPNetContext _context;
    
        public EmployeeRepository( ERPNetContext context ) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Employee>> GetAll ( )
        { 
            return await _context.Employee
                .ToListAsync ();
        }
        public async Task<Employee> GetEmployee ( int id )
        {
            return await _context.Employee
                .SingleOrDefaultAsync ( e => e.Id == id );
        }


        public async Task<Employee> AddEmployee ( Employee employee )
        {
          
            var newEmployee = new Employee ();

            newEmployee.Name = employee.Name;
            newEmployee.LastName = employee.LastName;
            newEmployee.PositionJob = employee.PositionJob;
            newEmployee.Salary = employee.Salary;
            newEmployee.UserName = employee.UserName;
            newEmployee.Password = employee.Password;
            _context.Set<Employee> ().Add ( newEmployee );
            await _context.SaveChangesAsync ();

            return newEmployee;
        }

    }
}
