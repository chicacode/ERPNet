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
      

        //public async Task<Employee> AddByPerson ( Person employee )
        //{
        //    Person person = new Person ();

        //    person.Name = employee.Name;
        //    person.LastName = employee.LastName;
         

        //    _context.Set<Person> ().Add ( person );
        //    await _context.SaveChangesAsync ();


        //    var newEmployee = new Employee ();

        //    newEmployee.PersonId = employee.Employee.PersonId;
        //    newEmployee.PositionJob = employee.Employee.PositionJob;
        //    newEmployee.Salary = employee.Employee.Salary;
        //    newEmployee.UserName = employee.Employee.UserName;
        //    newEmployee.Password = employee.Employee.Password;

            

        //    _context.Set<Employee> ().Add ( newEmployee );
        //    await _context.SaveChangesAsync ();


        //    return newEmployee;
        //}

        //public int GetEmployeeId ( int employeeId )
        //{
        //    var personId = _peopleRepository.GetPerson ( employeeId );

        //    return _context.Employee
        //            .FirstOrDefault ( x => x.PersonId == employeeId )
        //            .Id;
        //}

    }
}
